using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityScript.Lang;

[Serializable]
public class MyStoreClass : MonoBehaviour, IStoreListener
{
	public Menus MenuReference;

	public virtual void Initialize(ConfigurationBuilder builder)
	{
		UnityPurchasing.Initialize(this, builder);
	}

	public virtual void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		MenuReference.UnibillReady(controller, extensions);
	}

	public virtual void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed InitializationFailureReason: " + error);
	}

	public virtual PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		MenuReference.PurchaseCompleted(args);
		return PurchaseProcessingResult.Complete;
	}

	public virtual void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		MenuReference.PurchaseFailed(product, failureReason);
	}

	public virtual void RestorePurchases()
	{
		if (Menus.AndroidStorefront() != AndroidStorefronts.Amazon)
		{
			return;
		}
		for (int i = default(int); i < Extensions.get_length((System.Array)Menus.StoreController.products.all); i++)
		{
			if (Menus.StoreController.products.all[i].definition.type == ProductType.NonConsumable && !string.IsNullOrEmpty(Menus.StoreController.products.all[i].receipt))
			{
				MenuReference.PurchaseCompleted(Menus.StoreController.products.all[i].definition.id);
			}
		}
	}
}
