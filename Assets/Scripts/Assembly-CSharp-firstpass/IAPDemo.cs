using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Store;
using UnityEngine.UI;

[AddComponentMenu("Unity IAP/Demo")]
public class IAPDemo : MonoBehaviour, IStoreListener
{
	[Serializable]
	public class UnityChannelPurchaseError
	{
		public string error;

		public UnityChannelPurchaseInfo purchaseInfo;
	}

	[Serializable]
	public class UnityChannelPurchaseInfo
	{
		public string productCode;

		public string gameOrderId;

		public string orderQueryToken;
	}

	private class UnityChannelLoginHandler : ILoginListener
	{
		internal Action initializeSucceededAction;

		internal Action<string> initializeFailedAction;

		internal Action<UserInfo> loginSucceededAction;

		internal Action<string> loginFailedAction;

		public void OnInitialized()
		{
			initializeSucceededAction();
		}

		public void OnInitializeFailed(string message)
		{
			initializeFailedAction(message);
		}

		public void OnLogin(UserInfo userInfo)
		{
			loginSucceededAction(userInfo);
		}

		public void OnLoginFailed(string message)
		{
			loginFailedAction(message);
		}
	}

	[CompilerGenerated]
	private sealed class _003CAwake_003Ec__AnonStorey0
	{
		internal ConfigurationBuilder builder;

		internal Action initializeUnityIap;

		internal IAPDemo _0024this;

		internal void _003C_003Em__0()
		{
			UnityPurchasing.Initialize(_0024this, builder);
		}

		internal void _003C_003Em__1()
		{
			initializeUnityIap();
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitUI_003Ec__AnonStorey1
	{
		internal string txId;

		internal void _003C_003Em__0(bool success, string signData, string signature)
		{
			Debug.LogFormat("ValidateReceipt transactionId {0}, success {1}, signData {2}, signature {3}", txId, success, signData, signature);
		}
	}

	private IStoreController m_Controller;

	private IAppleExtensions m_AppleExtensions;

	private IMoolahExtension m_MoolahExtensions;

	private ISamsungAppsExtensions m_SamsungExtensions;

	private IMicrosoftExtensions m_MicrosoftExtensions;

	private IUnityChannelExtensions m_UnityChannelExtensions;

	private bool m_IsGooglePlayStoreSelected;

	private bool m_IsSamsungAppsStoreSelected;

	private bool m_IsCloudMoolahStoreSelected;

	private bool m_IsUnityChannelSelected;

	private string m_LastTransationID;

	private string m_LastReceipt;

	private string m_CloudMoolahUserName;

	private bool m_IsLoggedIn;

	private UnityChannelLoginHandler unityChannelLoginHandler;

	private bool m_FetchReceiptPayloadOnPurchase;

	private int m_SelectedItemIndex = -1;

	private bool m_PurchaseInProgress;

	private Selectable m_InteractableSelectable;

	[CompilerGenerated]
	private static Action<string> _003C_003Ef__am_0024cache0;

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		m_Controller = controller;
		m_AppleExtensions = extensions.GetExtension<IAppleExtensions>();
		m_SamsungExtensions = extensions.GetExtension<ISamsungAppsExtensions>();
		m_MoolahExtensions = extensions.GetExtension<IMoolahExtension>();
		m_MicrosoftExtensions = extensions.GetExtension<IMicrosoftExtensions>();
		m_UnityChannelExtensions = extensions.GetExtension<IUnityChannelExtensions>();
		InitUI(controller.products.all);
		m_AppleExtensions.RegisterPurchaseDeferredListener(OnDeferred);
		Debug.Log("Available items:");
		Product[] all = controller.products.all;
		foreach (Product product in all)
		{
			if (product.availableToPurchase)
			{
				Debug.Log(string.Join(" - ", new string[7]
				{
					product.metadata.localizedTitle,
					product.metadata.localizedDescription,
					product.metadata.isoCurrencyCode,
					product.metadata.localizedPrice.ToString(),
					product.metadata.localizedPriceString,
					product.transactionID,
					product.receipt
				}));
			}
		}
		if (m_Controller.products.all.Length > 0)
		{
			m_SelectedItemIndex = 0;
		}
		for (int j = 0; j < m_Controller.products.all.Length; j++)
		{
			Product product2 = m_Controller.products.all[j];
			string text = string.Format("{0} | {1} => {2}", product2.metadata.localizedTitle, product2.metadata.localizedPriceString, product2.metadata.localizedPrice);
			GetDropdown().options[j] = new Dropdown.OptionData(text);
		}
		GetDropdown().RefreshShownValue();
		UpdateHistoryUI();
		LogProductDefinitions();
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
	{
		Debug.Log("Purchase OK: " + e.purchasedProduct.definition.id);
		Debug.Log("Receipt: " + e.purchasedProduct.receipt);
		m_LastTransationID = e.purchasedProduct.transactionID;
		m_LastReceipt = e.purchasedProduct.receipt;
		m_PurchaseInProgress = false;
		if (m_IsUnityChannelSelected)
		{
			UnifiedReceipt unifiedReceipt = JsonUtility.FromJson<UnifiedReceipt>(e.purchasedProduct.receipt);
			if (unifiedReceipt != null && !string.IsNullOrEmpty(unifiedReceipt.Payload))
			{
				UnityChannelPurchaseReceipt unityChannelPurchaseReceipt = JsonUtility.FromJson<UnityChannelPurchaseReceipt>(unifiedReceipt.Payload);
				Debug.LogFormat("UnityChannel receipt: storeSpecificId = {0}, transactionId = {1}, orderQueryToken = {2}", unityChannelPurchaseReceipt.storeSpecificId, unityChannelPurchaseReceipt.transactionId, unityChannelPurchaseReceipt.orderQueryToken);
			}
		}
		UpdateHistoryUI();
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
	{
		Debug.Log("Purchase failed: " + item.definition.id);
		Debug.Log(r);
		if (m_IsUnityChannelSelected)
		{
			string lastPurchaseError = m_UnityChannelExtensions.GetLastPurchaseError();
			UnityChannelPurchaseError unityChannelPurchaseError = JsonUtility.FromJson<UnityChannelPurchaseError>(lastPurchaseError);
			if (unityChannelPurchaseError != null && unityChannelPurchaseError.purchaseInfo != null)
			{
				UnityChannelPurchaseInfo purchaseInfo = unityChannelPurchaseError.purchaseInfo;
				Debug.LogFormat("UnityChannel purchaseInfo: productCode = {0}, gameOrderId = {1}, orderQueryToken = {2}", purchaseInfo.productCode, purchaseInfo.gameOrderId, purchaseInfo.orderQueryToken);
			}
			if (r == PurchaseFailureReason.DuplicateTransaction)
			{
				Debug.Log("Duplicate transaction detected, unlock this item");
			}
		}
		m_PurchaseInProgress = false;
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("Billing failed to initialize!");
		switch (error)
		{
		case InitializationFailureReason.AppNotKnown:
			Debug.LogError("Is your App correctly uploaded on the relevant publisher console?");
			break;
		case InitializationFailureReason.PurchasingUnavailable:
			Debug.Log("Billing disabled!");
			break;
		case InitializationFailureReason.NoProductsAvailable:
			Debug.Log("No products available for purchase!");
			break;
		}
	}

	public void Awake()
	{
		_003CAwake_003Ec__AnonStorey0 _003CAwake_003Ec__AnonStorey = new _003CAwake_003Ec__AnonStorey0();
		_003CAwake_003Ec__AnonStorey._0024this = this;
		StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
		standardPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
		_003CAwake_003Ec__AnonStorey.builder = ConfigurationBuilder.Instance(standardPurchasingModule);
		_003CAwake_003Ec__AnonStorey.builder.Configure<IMicrosoftConfiguration>().useMockBillingSystem = true;
		m_IsGooglePlayStoreSelected = Application.platform == RuntimePlatform.Android && standardPurchasingModule.appStore == AppStore.GooglePlay;
		_003CAwake_003Ec__AnonStorey.builder.Configure<IMoolahConfiguration>().appKey = "d93f4564c41d463ed3d3cd207594ee1b";
		_003CAwake_003Ec__AnonStorey.builder.Configure<IMoolahConfiguration>().hashKey = "cc";
		_003CAwake_003Ec__AnonStorey.builder.Configure<IMoolahConfiguration>().SetMode(CloudMoolahMode.AlwaysSucceed);
		m_IsCloudMoolahStoreSelected = Application.platform == RuntimePlatform.Android && standardPurchasingModule.appStore == AppStore.CloudMoolah;
		m_IsUnityChannelSelected = Application.platform == RuntimePlatform.Android && standardPurchasingModule.appStore == AppStore.XiaomiMiPay;
		_003CAwake_003Ec__AnonStorey.builder.Configure<IUnityChannelConfiguration>().fetchReceiptPayloadOnPurchase = m_FetchReceiptPayloadOnPurchase;
		ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();
		foreach (ProductCatalogItem allProduct in productCatalog.allProducts)
		{
			if (allProduct.allStoreIDs.Count > 0)
			{
				IDs ds = new IDs();
				foreach (StoreID allStoreID in allProduct.allStoreIDs)
				{
					ds.Add(allStoreID.id, allStoreID.store);
				}
				_003CAwake_003Ec__AnonStorey.builder.AddProduct(allProduct.id, allProduct.type, ds);
			}
			else
			{
				_003CAwake_003Ec__AnonStorey.builder.AddProduct(allProduct.id, allProduct.type);
			}
		}
		_003CAwake_003Ec__AnonStorey.builder.AddProduct("100.gold.coins", ProductType.Consumable, new IDs
		{
			{ "100.gold.coins.mac", "MacAppStore" },
			{ "000000596586", "TizenStore" },
			{ "com.ff", "MoolahAppStore" }
		});
		_003CAwake_003Ec__AnonStorey.builder.AddProduct("500.gold.coins", ProductType.Consumable, new IDs
		{
			{ "500.gold.coins.mac", "MacAppStore" },
			{ "000000596581", "TizenStore" },
			{ "com.ee", "MoolahAppStore" }
		});
		_003CAwake_003Ec__AnonStorey.builder.AddProduct("sword", ProductType.NonConsumable, new IDs
		{
			{ "sword.mac", "MacAppStore" },
			{ "000000596583", "TizenStore" }
		});
		_003CAwake_003Ec__AnonStorey.builder.AddProduct("subscription", ProductType.Subscription, new IDs { { "subscription.mac", "MacAppStore" } });
		_003CAwake_003Ec__AnonStorey.builder.Configure<IAmazonConfiguration>().WriteSandboxJSON(_003CAwake_003Ec__AnonStorey.builder.products);
		_003CAwake_003Ec__AnonStorey.builder.Configure<ISamsungAppsConfiguration>().SetMode(SamsungAppsMode.AlwaysSucceed);
		m_IsSamsungAppsStoreSelected = Application.platform == RuntimePlatform.Android && standardPurchasingModule.appStore == AppStore.SamsungApps;
		_003CAwake_003Ec__AnonStorey.builder.Configure<ITizenStoreConfiguration>().SetGroupId("100000085616");
		_003CAwake_003Ec__AnonStorey.initializeUnityIap = _003CAwake_003Ec__AnonStorey._003C_003Em__0;
		if (!m_IsUnityChannelSelected)
		{
			_003CAwake_003Ec__AnonStorey.initializeUnityIap();
			return;
		}
		AppInfo appInfo = new AppInfo();
		appInfo.appId = "abc123appId";
		appInfo.appKey = "efg456appKey";
		appInfo.clientId = "hij789clientId";
		appInfo.clientKey = "klm012clientKey";
		appInfo.debug = false;
		unityChannelLoginHandler = new UnityChannelLoginHandler();
		UnityChannelLoginHandler obj = unityChannelLoginHandler;
		if (_003C_003Ef__am_0024cache0 == null)
		{
			_003C_003Ef__am_0024cache0 = _003CAwake_003Em__0;
		}
		obj.initializeFailedAction = _003C_003Ef__am_0024cache0;
		unityChannelLoginHandler.initializeSucceededAction = _003CAwake_003Ec__AnonStorey._003C_003Em__1;
		StoreService.Initialize(appInfo, unityChannelLoginHandler);
	}

	private void OnTransactionsRestored(bool success)
	{
		Debug.Log("Transactions restored.");
	}

	private void OnDeferred(Product item)
	{
		Debug.Log("Purchase deferred: " + item.definition.id);
	}

	private void InitUI(IEnumerable<Product> items)
	{
		m_InteractableSelectable = GetDropdown();
		if (!NeedRestoreButton())
		{
			GetRestoreButton().gameObject.SetActive(false);
		}
		GetRegisterButton().gameObject.SetActive(NeedRegisterButton());
		GetLoginButton().gameObject.SetActive(NeedLoginButton());
		GetValidateButton().gameObject.SetActive(NeedValidateButton());
		foreach (Product item in items)
		{
			string text = string.Format("{0} - {1}", item.definition.id, item.definition.type);
			GetDropdown().options.Add(new Dropdown.OptionData(text));
		}
		GetDropdown().RefreshShownValue();
		GetDropdown().onValueChanged.AddListener(_003CInitUI_003Em__1);
		GetBuyButton().onClick.AddListener(_003CInitUI_003Em__2);
		if (GetRestoreButton() != null)
		{
			GetRestoreButton().onClick.AddListener(_003CInitUI_003Em__3);
		}
		if (GetLoginButton() != null && m_IsUnityChannelSelected)
		{
			GetLoginButton().onClick.AddListener(_003CInitUI_003Em__4);
		}
		if (GetValidateButton() != null && m_IsUnityChannelSelected)
		{
			GetValidateButton().onClick.AddListener(_003CInitUI_003Em__5);
		}
	}

	public void UpdateHistoryUI()
	{
		if (m_Controller != null)
		{
			string text = "Item\n\n";
			string text2 = "Purchased\n\n";
			Product[] all = m_Controller.products.all;
			foreach (Product product in all)
			{
				text = text + "\n\n" + product.definition.id;
				text2 += "\n\n";
				text2 += product.hasReceipt;
			}
			GetText(false).text = text;
			GetText(true).text = text2;
		}
	}

	protected void UpdateInteractable()
	{
		if (m_InteractableSelectable == null)
		{
			return;
		}
		bool flag = m_Controller != null;
		if (flag != m_InteractableSelectable.interactable)
		{
			if (GetRestoreButton() != null)
			{
				GetRestoreButton().interactable = flag;
			}
			GetBuyButton().interactable = flag;
			GetDropdown().interactable = flag;
			GetRegisterButton().interactable = flag;
			GetLoginButton().interactable = flag;
		}
	}

	public void Update()
	{
		UpdateInteractable();
	}

	private bool NeedRestoreButton()
	{
		return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.tvOS || Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64 || Application.platform == RuntimePlatform.MetroPlayerARM || m_IsSamsungAppsStoreSelected || m_IsCloudMoolahStoreSelected;
	}

	private bool NeedRegisterButton()
	{
		return false;
	}

	private bool NeedLoginButton()
	{
		return m_IsUnityChannelSelected;
	}

	private bool NeedValidateButton()
	{
		return m_IsUnityChannelSelected;
	}

	private Text GetText(bool right)
	{
		string text = ((!right) ? "TextL" : "TextR");
		return GameObject.Find(text).GetComponent<Text>();
	}

	private Dropdown GetDropdown()
	{
		return GameObject.Find("Dropdown").GetComponent<Dropdown>();
	}

	private Button GetBuyButton()
	{
		return GameObject.Find("Buy").GetComponent<Button>();
	}

	private Button GetRestoreButton()
	{
		return GetButton("Restore");
	}

	private Button GetRegisterButton()
	{
		return GetButton("Register");
	}

	private Button GetLoginButton()
	{
		return GetButton("Login");
	}

	private Button GetValidateButton()
	{
		return GetButton("Validate");
	}

	private Button GetButton(string buttonName)
	{
		GameObject gameObject = GameObject.Find(buttonName);
		if (gameObject != null)
		{
			return gameObject.GetComponent<Button>();
		}
		return null;
	}

	private void LogProductDefinitions()
	{
		Product[] all = m_Controller.products.all;
		Product[] array = all;
		foreach (Product product in array)
		{
			Debug.Log(string.Format("id: {0}\nstore-specific id: {1}\ntype: {2}\nenabled: {3}\n", product.definition.id, product.definition.storeSpecificId, product.definition.type.ToString(), (!product.definition.enabled) ? "disabled" : "enabled"));
		}
	}

	[CompilerGenerated]
	private static void _003CAwake_003Em__0(string message)
	{
		Debug.LogError("Failed to initialize and login to UnityChannel: " + message);
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__1(int selectedItem)
	{
		Debug.Log("OnClickDropdown item " + selectedItem);
		m_SelectedItemIndex = selectedItem;
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__2()
	{
		if (m_PurchaseInProgress)
		{
			Debug.Log("Please wait, purchasing ...");
			return;
		}
		if (NeedLoginButton() && !m_IsLoggedIn)
		{
			Debug.LogWarning("Purchase notifications will not be forwarded server-to-server. Login incomplete.");
		}
		m_PurchaseInProgress = true;
		m_Controller.InitiatePurchase(m_Controller.products.all[m_SelectedItemIndex], "aDemoDeveloperPayload");
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__3()
	{
		if (m_IsCloudMoolahStoreSelected)
		{
			if (!m_IsLoggedIn)
			{
				Debug.LogError("CloudMoolah purchase restoration aborted. Login incomplete.");
			}
			else
			{
				m_MoolahExtensions.RestoreTransactionID(_003CInitUI_003Em__6);
			}
		}
		else if (m_IsSamsungAppsStoreSelected)
		{
			m_SamsungExtensions.RestoreTransactions(OnTransactionsRestored);
		}
		else if (Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64 || Application.platform == RuntimePlatform.MetroPlayerARM)
		{
			m_MicrosoftExtensions.RestoreTransactions();
		}
		else
		{
			m_AppleExtensions.RestoreTransactions(OnTransactionsRestored);
		}
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__4()
	{
		unityChannelLoginHandler.loginSucceededAction = _003CInitUI_003Em__7;
		unityChannelLoginHandler.loginFailedAction = _003CInitUI_003Em__8;
		StoreService.Login(unityChannelLoginHandler);
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__5()
	{
		_003CInitUI_003Ec__AnonStorey1 _003CInitUI_003Ec__AnonStorey = new _003CInitUI_003Ec__AnonStorey1();
		_003CInitUI_003Ec__AnonStorey.txId = m_LastTransationID;
		m_UnityChannelExtensions.ValidateReceipt(_003CInitUI_003Ec__AnonStorey.txId, _003CInitUI_003Ec__AnonStorey._003C_003Em__0);
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__6(RestoreTransactionIDState restoreTransactionIDState)
	{
		Debug.Log("restoreTransactionIDState = " + restoreTransactionIDState);
		bool success = restoreTransactionIDState != RestoreTransactionIDState.RestoreFailed && restoreTransactionIDState != RestoreTransactionIDState.NotKnown;
		OnTransactionsRestored(success);
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__7(UserInfo userInfo)
	{
		m_IsLoggedIn = true;
		Debug.LogFormat("Succeeded logging into UnityChannel. channel {0}, userId {1}, userLoginToken {2} ", userInfo.channel, userInfo.userId, userInfo.userLoginToken);
	}

	[CompilerGenerated]
	private void _003CInitUI_003Em__8(string message)
	{
		m_IsLoggedIn = false;
		Debug.LogError("Failed logging into UnityChannel. " + message);
	}
}
