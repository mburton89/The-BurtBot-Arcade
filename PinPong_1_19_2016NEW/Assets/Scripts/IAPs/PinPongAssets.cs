using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store {
	
	public class PinPongAssets : IStoreAssets{
		
		public int GetVersion() {
			return 0;
		}  

		public VirtualCurrency[] GetCurrencies() {
			return new VirtualCurrency[]{};           
		}
		 
		public VirtualGood[] GetGoods() { 
			return new VirtualGood[] {
				REMOVE_ADS
			};
		}  

		public VirtualCurrencyPack[] GetCurrencyPacks() {
			return new VirtualCurrencyPack[] {};
		}
		

		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{};  
		}
		
//		public VirtualCategory[] GetNonConsumableItems(){
//			return new LifetimeVG[] {};
//		}  

		public const string REMOVE_ADS_ID = "removeadspinpong";  
		//public const string REMOVE_ADS_ID = "android.test.purchased";   

		public static VirtualGood REMOVE_ADS = new LifetimeVG( 
			"Nonexistent Ads Edition",                    // name
			"No more ads!", 							  // description
			"removeadspinpong",                           // item id
			new PurchaseWithMarket(REMOVE_ADS_ID, 0.99)); // the way this virtual good is purchased
	}    
}