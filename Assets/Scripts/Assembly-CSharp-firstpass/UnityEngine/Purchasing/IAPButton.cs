using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityEngine.Purchasing
{
	[RequireComponent(typeof(Button))]
	[AddComponentMenu("Unity IAP/IAP Button")]
	[HelpURL("https://docs.unity3d.com/Manual/UnityIAP.html")]
	public class IAPButton : MonoBehaviour
	{
		public enum ButtonType
		{
			Purchase = 0,
			Restore = 1
		}

		[Serializable]
		public class OnPurchaseCompletedEvent : UnityEvent<Product>
		{
		}

		[Serializable]
		public class OnPurchaseFailedEvent : UnityEvent<Product, PurchaseFailureReason>
		{
		}

		public class IAPButtonStoreManager : IStoreListener
		{
			private static IAPButtonStoreManager instance = new IAPButtonStoreManager();

			private ProductCatalog catalog;

			private List<IAPButton> activeButtons = new List<IAPButton>();

			private IAPListener m_Listener;

			protected IStoreController controller;

			protected IExtensionProvider extensions;

			public static IAPButtonStoreManager Instance
			{
				get
				{
					return instance;
				}
			}

			public IStoreController StoreController
			{
				get
				{
					return controller;
				}
			}

			public IExtensionProvider ExtensionProvider
			{
				get
				{
					return extensions;
				}
			}

			private IAPButtonStoreManager()
			{
				catalog = ProductCatalog.LoadDefaultCatalog();
				StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
				standardPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
				ConfigurationBuilder builder = ConfigurationBuilder.Instance(standardPurchasingModule);
				IAPConfigurationHelper.PopulateConfigurationBuilder(ref builder, catalog);
				UnityPurchasing.Initialize(this, builder);
			}

			public bool HasProductInCatalog(string productID)
			{
				foreach (ProductCatalogItem allProduct in catalog.allProducts)
				{
					if (allProduct.id == productID)
					{
						return true;
					}
				}
				return false;
			}

			public Product GetProduct(string productID)
			{
				if (controller != null && controller.products != null && !string.IsNullOrEmpty(productID))
				{
					return controller.products.WithID(productID);
				}
				return null;
			}

			public void AddButton(IAPButton button)
			{
				activeButtons.Add(button);
			}

			public void RemoveButton(IAPButton button)
			{
				activeButtons.Remove(button);
			}

			public void AddListener(IAPListener listener)
			{
				if (m_Listener != null)
				{
					Debug.LogWarning("There is more than one active IAPListener. Only the most recent IAPListener will receive purchase events.");
				}
				m_Listener = listener;
			}

			public void RemoveListener(IAPListener listener)
			{
				if (m_Listener == listener)
				{
					m_Listener = null;
				}
			}

			public void InitiatePurchase(string productID)
			{
				if (controller == null)
				{
					Debug.LogError("Purchase failed because Purchasing was not initialized correctly");
					{
						foreach (IAPButton activeButton in activeButtons)
						{
							if (activeButton.productId == productID)
							{
								activeButton.OnPurchaseFailed(null, PurchaseFailureReason.PurchasingUnavailable);
							}
						}
						return;
					}
				}
				controller.InitiatePurchase(productID);
			}

			public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
			{
				this.controller = controller;
				this.extensions = extensions;
				foreach (IAPButton activeButton in activeButtons)
				{
					activeButton.UpdateText();
				}
			}

			public void OnInitializeFailed(InitializationFailureReason error)
			{
				Debug.LogError(string.Format("Purchasing failed to initialize. Reason: {0}", error.ToString()));
			}

			public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
			{
				foreach (IAPButton activeButton in activeButtons)
				{
					if (activeButton.productId == e.purchasedProduct.definition.id)
					{
						return activeButton.ProcessPurchase(e);
					}
				}
				if (m_Listener != null)
				{
					return m_Listener.ProcessPurchase(e);
				}
				Debug.LogWarning("Purchase not correctly processed for product \"" + e.purchasedProduct.definition.id + "\". Add an active IAPButton to process this purchase, or add an IAPListener to receive any unhandled purchase events.");
				return PurchaseProcessingResult.Pending;
			}

			public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
			{
				foreach (IAPButton activeButton in activeButtons)
				{
					if (activeButton.productId == product.definition.id)
					{
						activeButton.OnPurchaseFailed(product, reason);
						return;
					}
				}
				if (m_Listener != null)
				{
					m_Listener.OnPurchaseFailed(product, reason);
				}
				else
				{
					Debug.LogWarning("Failed purchase not correctly handled for product \"" + product.definition.id + "\". Add an active IAPButton to handle this failure, or add an IAPListener to receive any unhandled purchase failures.");
				}
			}
		}

		[HideInInspector]
		public string productId;

		[Tooltip("The type of this button, can be either a purchase or a restore button")]
		public ButtonType buttonType;

		[Tooltip("Consume the product immediately after a successful purchase")]
		public bool consumePurchase = true;

		[Tooltip("Event fired after a successful purchase of this product")]
		public OnPurchaseCompletedEvent onPurchaseComplete;

		[Tooltip("Event fired after a failed purchase of this product")]
		public OnPurchaseFailedEvent onPurchaseFailed;

		[Tooltip("[Optional] Displays the localized title from the app store")]
		public Text titleText;

		[Tooltip("[Optional] Displays the localized description from the app store")]
		public Text descriptionText;

		[Tooltip("[Optional] Displays the localized price from the app store")]
		public Text priceText;

		private void Start()
		{
			Button component = GetComponent<Button>();
			if (buttonType == ButtonType.Purchase)
			{
				if ((bool)component)
				{
					component.onClick.AddListener(PurchaseProduct);
				}
				if (string.IsNullOrEmpty(productId))
				{
					Debug.LogError("IAPButton productId is empty");
				}
				if (!IAPButtonStoreManager.Instance.HasProductInCatalog(productId))
				{
					Debug.LogWarning("The product catalog has no product with the ID \"" + productId + "\"");
				}
			}
			else if (buttonType == ButtonType.Restore && (bool)component)
			{
				component.onClick.AddListener(Restore);
			}
		}

		private void OnEnable()
		{
			if (buttonType == ButtonType.Purchase)
			{
				IAPButtonStoreManager.Instance.AddButton(this);
				UpdateText();
			}
		}

		private void OnDisable()
		{
			if (buttonType == ButtonType.Purchase)
			{
				IAPButtonStoreManager.Instance.RemoveButton(this);
			}
		}

		private void PurchaseProduct()
		{
			if (buttonType == ButtonType.Purchase)
			{
				Debug.Log("IAPButton.PurchaseProduct() with product ID: " + productId);
				IAPButtonStoreManager.Instance.InitiatePurchase(productId);
			}
		}

		private void Restore()
		{
			if (buttonType == ButtonType.Restore)
			{
				if (Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64 || Application.platform == RuntimePlatform.MetroPlayerARM)
				{
					IAPButtonStoreManager.Instance.ExtensionProvider.GetExtension<IMicrosoftExtensions>().RestoreTransactions();
				}
				else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.tvOS)
				{
					IAPButtonStoreManager.Instance.ExtensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions(OnTransactionsRestored);
				}
				else if (Application.platform == RuntimePlatform.Android && StandardPurchasingModule.Instance().appStore == AppStore.SamsungApps)
				{
					IAPButtonStoreManager.Instance.ExtensionProvider.GetExtension<ISamsungAppsExtensions>().RestoreTransactions(OnTransactionsRestored);
				}
				else if (Application.platform == RuntimePlatform.Android && StandardPurchasingModule.Instance().appStore == AppStore.CloudMoolah)
				{
					IAPButtonStoreManager.Instance.ExtensionProvider.GetExtension<IMoolahExtension>().RestoreTransactionID(_003CRestore_003Em__0);
				}
				else
				{
					Debug.LogWarning(Application.platform.ToString() + " is not a supported platform for the Codeless IAP restore button");
				}
			}
		}

		private void OnTransactionsRestored(bool success)
		{
			Debug.Log("Transactions restored: " + success);
		}

		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
		{
			Debug.Log(string.Format("IAPButton.ProcessPurchase(PurchaseEventArgs {0} - {1})", e, e.purchasedProduct.definition.id));
			onPurchaseComplete.Invoke(e.purchasedProduct);
			return (!consumePurchase) ? PurchaseProcessingResult.Pending : PurchaseProcessingResult.Complete;
		}

		public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
		{
			Debug.Log(string.Format("IAPButton.OnPurchaseFailed(Product {0}, PurchaseFailureReason {1})", product, reason));
			onPurchaseFailed.Invoke(product, reason);
		}

		private void UpdateText()
		{
			Product product = IAPButtonStoreManager.Instance.GetProduct(productId);
			if (product != null)
			{
				if (titleText != null)
				{
					titleText.text = product.metadata.localizedTitle;
				}
				if (descriptionText != null)
				{
					descriptionText.text = product.metadata.localizedDescription;
				}
				if (priceText != null)
				{
					priceText.text = product.metadata.localizedPriceString;
				}
			}
		}

		[CompilerGenerated]
		private void _003CRestore_003Em__0(RestoreTransactionIDState restoreTransactionIDState)
		{
			OnTransactionsRestored(restoreTransactionIDState != RestoreTransactionIDState.RestoreFailed && restoreTransactionIDState != RestoreTransactionIDState.NotKnown);
		}
	}
}
