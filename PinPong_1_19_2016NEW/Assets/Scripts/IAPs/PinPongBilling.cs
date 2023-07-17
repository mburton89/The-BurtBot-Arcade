using UnityEngine;
using System.Collections;
using Soomla;
using Soomla.Store;
using System;  
using System.Collections.Generic; 

//namespace Soomla.Store.Example {

public class PinPongBilling : MonoBehaviour{   
	
	//public string supportive = "";
	
	void Start () {  
		SoomlaStore.Initialize(new PinPongAssets());       
		StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted; 
		StoreEvents.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;       
		StoreEvents.OnMarketPurchase += onMarketPurchase;                                    
	}

	public void onMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string, string> extra) {
		PlayerPrefs.SetInt("hasMadePurchase",1);    
//		PlayerPrefs.SetInt("displayThankYou",1);
		
		Social.ReportProgress("CgkIqeb0_poSEAIQEA", 100.0f,(bool success) => { 
			
		}); 
	}
	

	public void onMarketRefund(PurchasableVirtualItem pvi) {  
		
	}

	public void onItemPurchased(PurchasableVirtualItem pvi, string payload) {
		
	}

	public void onGoodEquipped(EquippableVG good) {
		
	}

	public void onGoodUnequipped(EquippableVG good) {
		
	}

	public void onGoodUpgrade(VirtualGood good, UpgradeVG currentUpgrade) {
		
	}

	public void onBillingSupported() {
		
	}

	public void onBillingNotSupported() {
		
	}

	public void onMarketPurchaseStarted(PurchasableVirtualItem pvi) {
		
	}

	public void onItemPurchaseStarted(PurchasableVirtualItem pvi) {
		
	}

	public void onMarketPurchaseCancelled(PurchasableVirtualItem pvi) {
		
	}

	public void onUnexpectedErrorInStore(string message) {
		
	}

	public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
		
	}

	public void onGoodBalanceChanged(VirtualGood good, int balance, int amountAdded) {
		
	}

	public void onRestoreTransactionsStarted() {
		
	}

	public void onRestoreTransactionsFinished(bool success) {
		
	}

	public void onSoomlaStoreInitialized() {
		
	}
	
	#if UNITY_ANDROID && !UNITY_EDITOR
	public void onIabServiceStarted() {
		
	}
	public void onIabServiceStopped() {
		
	}
	#endif
}
//}
