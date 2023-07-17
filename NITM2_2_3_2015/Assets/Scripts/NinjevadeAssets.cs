using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store {

	public class NinjevadeAssets : IStoreAssets{

		public int GetVersion() {
			return 0;
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualCurrency[] GetCurrencies() {
			return new VirtualCurrency[]{};           
		}
		
//		/// <summary>
//		/// see parent.
//		/// </summary>
//		public VirtualGood[] GetGoods() {
//			return new VirtualGood[] {};
//		}

		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualGood[] GetGoods() { 
			return new VirtualGood[] {
				NINJEVADE_99_UNLOCK,    
				NINJEVADE_199_UNLOCK,  
				NINJEVADE_299_UNLOCK,
				NINJEVADE_399_UNLOCK,
				NINJEVADE_499_UNLOCK,
				PAY_FOR_NINJEVADE
			};
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualCurrencyPack[] GetCurrencyPacks() {
			return new VirtualCurrencyPack[] {};
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{};
		}

		//UN-COMMENT
//		public VirtualCategory[] GetNonConsumableItems(){
//			return new LifetimeVG[] {}; //add Names
//		}  


		//THIS IS THE REAL THING
		public const string NINJEVADE_99_UNLOCK_ID = "ninjevade99"; 
		public const string NINJEVADE_199_UNLOCK_ID = "ninjevade199";
		public const string NINJEVADE_299_UNLOCK_ID = "ninjevade299";
		public const string NINJEVADE_399_UNLOCK_ID = "ninjevade399";
		public const string NINJEVADE_499_UNLOCK_ID = "ninjevade499";

		public const string PAY_FOR_NINJEVADE_ID = "payforninjevade"; 


//		public const string NINJEVADE_99_UNLOCK_ID = "android.test.purchased";
//		public const string NINJEVADE_199_UNLOCK_ID = "android.test.canceled";
//		public const string NINJEVADE_299_UNLOCK_ID = "android.test.refunded";
//		public const string NINJEVADE_399_UNLOCK_ID = "android.test.item_unavailable";
//		public const string NINJEVADE_499_UNLOCK_ID = "ninjevade499"; 
//		
//		public const string PAY_FOR_NINJEVADE_ID = "android.test.purchased";  

	

		//NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF 
		public static VirtualGood NINJEVADE_99_UNLOCK = new LifetimeVG(
			"Full Unlock",                                       		// name
			"Unlocks all characters and themes", 						// description
			"ninjevade99",                                       		// item id
			new PurchaseWithMarket(NINJEVADE_99_UNLOCK_ID, 0.99)); // the way this virtual good is purchased

		public static VirtualGood NINJEVADE_199_UNLOCK = new LifetimeVG(
			"Full Unlock 2",                                       		// name
			"Unlocks all characters and themes", 						// description
			"ninjevade199",                                       		// item id
			new PurchaseWithMarket(NINJEVADE_199_UNLOCK_ID, 1.99)); // the way this virtual good is purchased

		public static VirtualGood NINJEVADE_299_UNLOCK = new LifetimeVG(
			"Full Unlock 3",                                       		// name
			"Unlocks all characters and themes", 						// description
			"ninjevade299",                                       		// item id
			new PurchaseWithMarket(NINJEVADE_299_UNLOCK_ID, 2.99)); // the way this virtual good is purchased

		public static VirtualGood NINJEVADE_399_UNLOCK = new LifetimeVG(
			"Full Unlock 4",                                       		// name
			"Unlocks all characters and themes", 						// description
			"ninjevade399",                                       		// item id
			new PurchaseWithMarket(NINJEVADE_399_UNLOCK_ID, 3.99)); // the way this virtual good is purchased

		public static VirtualGood NINJEVADE_499_UNLOCK = new LifetimeVG(
			"Full Unlock 5",                                       		// name
			"Unlocks all characters and themes", 						// description
			"ninjevade499",                                       		// item id
			new PurchaseWithMarket(NINJEVADE_499_UNLOCK_ID, 4.99)); // the way this virtual good is purchased

		public static VirtualGood PAY_FOR_NINJEVADE = new SingleUseVG(
			"Gratuity",                                   		// name
			"Payment for Ninjevade. Also, unlocks all characters and themes",
			"payforninjevade",                                   		// item id
			new PurchaseWithMarket(PAY_FOR_NINJEVADE_ID, 0.99)); // the way this virtual good is purchased 


		//TEST
//		public static VirtualGood PAY_FOR_NINJEVADE = new SingleUseVG(
//			"Gratuity",                                   		// name
//			"Payment for Ninjevade. Also, unlocks all characters and themes",
//			"payforninjevade",                                   		// item id
//			new PurchaseWithMarket(new MarketItem(PAY_FOR_NINJEVADE_ID, MarketItem.Consumable.CONSUMABLE), 0.99)); // the way this virtual good is purchased
//    

		//NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF NINJEVADE STUFF 
//		public static VirtualGood NINJEVADE_99_UNLOCK = new LifetimeVG(
//			"Full Unlock",                                       		// name
//			"Unlocks all characters and themes", 						// description
//			"android.test.purchased",                                       		// item id
//			new PurchaseWithMarket(NINJEVADE_99_UNLOCK_ID, 0.99)); // the way this virtual good is purchased
//		
//		public static VirtualGood NINJEVADE_199_UNLOCK = new LifetimeVG(
//			"Full Unlock 2",                                       		// name
//			"Unlocks all characters and themes", 						// description
//			"android.test.canceled",                                       		// item id
//			new PurchaseWithMarket(NINJEVADE_199_UNLOCK_ID, 1.99)); // the way this virtual good is purchased
//		
//		public static VirtualGood NINJEVADE_299_UNLOCK = new LifetimeVG(
//			"Full Unlock 3",                                       		// name
//			"Unlocks all characters and themes", 						// description
//			"android.test.refunded",                                       		// item id
//			new PurchaseWithMarket(NINJEVADE_299_UNLOCK_ID, 2.99)); // the way this virtual good is purchased
//		
//		public static VirtualGood NINJEVADE_399_UNLOCK = new LifetimeVG(
//			"Full Unlock 4",                                       		// name
//			"Unlocks all characters and themes", 						// description
//			"android.test.item_unavailable",                                       		// item id
//			new PurchaseWithMarket(NINJEVADE_399_UNLOCK_ID, 3.99)); // the way this virtual good is purchased
//		
//		public static VirtualGood NINJEVADE_499_UNLOCK = new LifetimeVG( 
//			"Full Unlock 5",                                       		// name
//			"Unlocks all characters and themes", 						// description
//			"ninjevade499",                                       		// item id
//			new PurchaseWithMarket(NINJEVADE_499_UNLOCK_ID, 4.99)); // the way this virtual good is purchased
//		
//		public static VirtualGood PAY_FOR_NINJEVADE = new SingleUseVG(
//			"Gratuity",                                   		// name
//			"Payment for Ninjevade. Also, unlocks all characters and themes",
//			"android.test.purchased",                                   		// item id
//			new PurchaseWithMarket(PAY_FOR_NINJEVADE_ID, 0.99)); // the way this virtual good is purchased 
	}    
}
