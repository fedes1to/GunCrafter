using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

[Serializable]
public class App : MonoBehaviour
{
	[NonSerialized]
	public static bool IsPortrait;

	[NonSerialized]
	public static string Name;

	[NonSerialized]
	public static string BundleDisplayName;

	[NonSerialized]
	public static string BundleID;

	[NonSerialized]
	public static string BundleIDiOS;

	[NonSerialized]
	public static string BundleIDAndroid;

	[NonSerialized]
	public static string NaquaticURL;

	[NonSerialized]
	public static string SystemName;

	[NonSerialized]
	public static string MultiplayerName;

	[NonSerialized]
	public static string PushName;

	[NonSerialized]
	public static string AppleID;

	[NonSerialized]
	public static string ChartboostiOSID;

	[NonSerialized]
	public static string ChartboostiOSSig;

	[NonSerialized]
	public static string ChartboostGoogleID;

	[NonSerialized]
	public static string ChartboostGoogleSig;

	[NonSerialized]
	public static string ChartboostAmazonID;

	[NonSerialized]
	public static string ChartboostAmazonSig;

	[NonSerialized]
	public static string WindowsStoreBundleID;

	[NonSerialized]
	public static string WindowsPhoneBundleID;

	[NonSerialized]
	public static List<IAP> IAPProducts;

	[NonSerialized]
	public static IAP IAPItem;

	[NonSerialized]
	public static LeaderboardClass[] Leaderboards = new LeaderboardClass[24]
	{
		new LeaderboardClass("Total Wins", "totalWins", "CgkI7ZX42cwFEAIQBg", false, false),
		new LeaderboardClass("Friends", "friends", "CgkI7ZX42cwFEAIQBw", false, false),
		new LeaderboardClass("Friend Wins", "friendWins", "CgkI7ZX42cwFEAIQCA", true, false),
		new LeaderboardClass("Rank", "level", "CgkI7ZX42cwFEAIQCQ", false, false),
		new LeaderboardClass("Block Score", "blockScore", "CgkI7ZX42cwFEAIQCg", false, false),
		new LeaderboardClass("Castle Score", "castleScore", "CgkI7ZX42cwFEAIQCw", false, false),
		new LeaderboardClass("Egypt Score", "egyptScore", "CgkI7ZX42cwFEAIQDA", false, false),
		new LeaderboardClass("Graveyard Score", "graveyardScore", "CgkI7ZX42cwFEAIQDQ", false, false),
		new LeaderboardClass("Home Score", "homeScore", "CgkI7ZX42cwFEAIQDg", false, false),
		new LeaderboardClass("Flower Score", "flowerScore", "CgkI7ZX42cwFEAIQDw", false, false),
		new LeaderboardClass("Truck Score", "truckScore", "CgkI7ZX42cwFEAIQEA", false, false),
		new LeaderboardClass("Music Score", "musicScore", "CgkI7ZX42cwFEAIQEQ", false, false),
		new LeaderboardClass("Rocket Score", "rocketScore", "CgkI7ZX42cwFEAIQEg", false, false),
		new LeaderboardClass("Platform Score", "platformScore", "CgkI7ZX42cwFEAIQEw", false, false),
		new LeaderboardClass("Sea Score", "seaScore", "CgkI7ZX42cwFEAIQFA", false, false),
		new LeaderboardClass("Showdown Score", "showdownScore", "CgkI7ZX42cwFEAIQFQ", false, false),
		new LeaderboardClass("Science Score", "scienceScore", "CgkI7ZX42cwFEAIQFg", false, false),
		new LeaderboardClass("Space Score", "spaceScore", "CgkI7ZX42cwFEAIQFw", false, false),
		new LeaderboardClass("Island Score", "islandScore", "CgkI7ZX42cwFEAIQGA", false, false),
		new LeaderboardClass("Treasure Score", "treasureScore", "CgkI7ZX42cwFEAIQGQ", false, false),
		new LeaderboardClass("Windmill Score", "windmillScore", "CgkI7ZX42cwFEAIQGg", false, false),
		new LeaderboardClass("Retro Score", "retroScore", "CgkI7ZX42cwFEAIQGw", false, false),
		new LeaderboardClass("Billiards Score", "billiardsScore", "CgkI7ZX42cwFEAIQHA", false, false),
		new LeaderboardClass("Tank Score", "tankScore", "CgkI7ZX42cwFEAIQHQ", false, false)
	};

	[NonSerialized]
	public static AchievementClass[] Achievements = new AchievementClass[5]
	{
		new AchievementClass("Baby Steps", "Play a match", "playAMatch", "CgkI7ZX42cwFEAIQAQ", 5, 0, false),
		new AchievementClass("Friendly", "1 person entered your code", "friend1", "CgkI7ZX42cwFEAIQAg", 200, 1, false),
		new AchievementClass("Glory", "Win 100 matches", "wins1", "CgkI7ZX42cwFEAIQAw", 500, 2, false),
		new AchievementClass("Veteran", "Reach level 10", "level1", "CgkI7ZX42cwFEAIQBA", 250, 3, false),
		new AchievementClass("All Star", "Reach level 30", "level2", "CgkI7ZX42cwFEAIQBQ", 1000, 4, false)
	};

	[NonSerialized]
	public static MoreApp[] MoreApps = new MoreApp[6]
	{
		new MoreApp("MonsterCrafter", "660928091", "com.naquatic.monstercrafter", "com.naquatic.monstercrafter", string.Empty, string.Empty),
		new MoreApp("ShootingShowdown2", "798989168", "com.naquatic.shootingshowdown2", "com.naquatic.shootingshowdown2", string.Empty, string.Empty),
		new MoreApp("BasketballShowdown", "567631021", "com.naquatic.basketballshowdown", "com.naquatic.basketballshowdown", string.Empty, string.Empty),
		new MoreApp("Soccer2015", "889768907", "com.naquatic.soccershowdown2015", "com.naquatic.soccershowdown2015", string.Empty, string.Empty),
		new MoreApp("Fiend", "572389697", "com.naquatic.GunCollector", string.Empty, string.Empty, string.Empty),
		new MoreApp("HockeyShowdown", "594105589", "com.naquatic.hockeyshowdown", string.Empty, string.Empty, string.Empty)
	};

	[NonSerialized]
	public static SystemLanguage[] SupportedLanguages = new SystemLanguage[7]
	{
		SystemLanguage.English,
		SystemLanguage.Spanish,
		SystemLanguage.French,
		SystemLanguage.Chinese,
		SystemLanguage.German,
		SystemLanguage.Russian,
		SystemLanguage.Japanese
	};

	[NonSerialized]
	public static UnlockClass[] Unlocks = new UnlockClass[14]
	{
		new UnlockClass("SaveSlot1", 50),
		new UnlockClass("SaveSlot2", 200),
		new UnlockClass("SaveSlot3", 500),
		new UnlockClass("SaveSlot4", 1000),
		new UnlockClass("SaveSlot5", 2000),
		new UnlockClass("Grid1", 100),
		new UnlockClass("Grid2", 1000),
		new UnlockClass("Grid3", 3000),
		new UnlockClass("Grid4", 6000),
		new UnlockClass("Set1", 50),
		new UnlockClass("Set2", 150),
		new UnlockClass("Set3", 1000),
		new UnlockClass("Set4", 3000),
		new UnlockClass("Set5", 6000)
	};

	[NonSerialized]
	public static Metadata.Genre PrimaryFirstSubCategory;

	[NonSerialized]
	public static Metadata.Genre PrimarySecondSubCategory;

	[NonSerialized]
	public static Dictionary<Metadata.Language, string> Titles;

	[NonSerialized]
	public static Dictionary<Metadata.Language, string> Subtitles;

	[NonSerialized]
	public static Dictionary<Metadata.Language, string> ShortDescriptions;

	[NonSerialized]
	public static Dictionary<Metadata.Language, string> PromotionalText;

	[NonSerialized]
	public static Dictionary<Metadata.Language, string> Keywords;

	[NonSerialized]
	public static Dictionary<Metadata.Language, string> ReleaseNotes;

	[NonSerialized]
	public static string TrailerThumbnail;

	[NonSerialized]
	public static string TrailerYoutube;

	public static void Initialize()
	{
		if (!Settings.IsPro)
		{
			Name = "GunCrafter";
			BundleDisplayName = "GunCrafter";
			BundleID = "com.naquatic.guncraft";
			NaquaticURL = "guncrafter";
			SystemName = "Guncrafter";
			MultiplayerName = "Guncrafter";
			PushName = "Guncrafter";
			AppleID = "606711756";
			ChartboostiOSID = "516e155917ba471a1c00001e";
			ChartboostiOSSig = "52cb823f5b6d1e5541b7c6ccc6a9192997c2768f";
			ChartboostGoogleID = "516e159e17ba47961c000000";
			ChartboostGoogleSig = "e37916aa84151af1a33da2427d8ef2639747e0de";
			ChartboostAmazonID = "51ee370716ba47b936000003";
			ChartboostAmazonSig = "f75d2543e18f9535e44a673a0e417d09624d38be";
			WindowsStoreBundleID = string.Empty;
			WindowsPhoneBundleID = string.Empty;
			IAPProducts = new List<IAP>();
			IAPItem = new IAP();
			IAPItem.Name = "Bag of Gold";
			IAPItem.Description = "200 Gold for unlockicng items";
			IAPItem.PriceTier = 2;
			IAPItem.iOSID = "com.naquatic.guncraft.gold1";
			IAPItem.GoogleID = "com.naquatic.guncraft.gold1managed";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.Consumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Case of Gold";
			IAPItem.Description = "3000 Gold for unlocking items";
			IAPItem.PriceTier = 20;
			IAPItem.iOSID = "com.naquatic.guncraft.gold2";
			IAPItem.GoogleID = "com.naquatic.guncraft.gold2managed";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.Consumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Truck of Gold";
			IAPItem.Description = "10000 Gold for unlocking items";
			IAPItem.PriceTier = 50;
			IAPItem.iOSID = "com.naquatic.guncraft.gold3";
			IAPItem.GoogleID = "com.naquatic.guncraft.gold3managed";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.Consumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Pro Pack";
			IAPItem.Description = "Unlock Everything";
			IAPItem.PriceTier = 60;
			IAPItem.iOSID = "com.naquatic.guncraft.propack";
			IAPItem.GoogleID = "com.naquatic.guncraft.propackmanaged";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.NonConsumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Unlock All Levels";
			IAPItem.Description = "Unlocks every level in the game";
			IAPItem.PriceTier = 2;
			IAPItem.iOSID = "com.naquatic.guncraft.alllevels";
			IAPItem.GoogleID = string.Empty;
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.NonConsumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Gold Doubler";
			IAPItem.Description = "Earn 2x the Gold";
			IAPItem.PriceTier = 5;
			IAPItem.iOSID = "com.naquatic.guncraft.doubler";
			IAPItem.GoogleID = string.Empty;
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.NonConsumable;
			IAPProducts.Add(IAPItem);
		}
		else
		{
			Name = "GunCrafter Pro";
			BundleDisplayName = "GunCrafter";
			BundleID = "com.naquatic.guncrafterpro";
			NaquaticURL = "guncrafter";
			SystemName = "Guncrafter";
			MultiplayerName = "Guncrafter";
			PushName = "GuncrafterPro";
			AppleID = "655853606";
			ChartboostiOSID = "51a7bd2c16ba470a56000009";
			ChartboostiOSSig = "1cd6940bd517657b6d353ccd587ace89e48a1b65";
			ChartboostGoogleID = "51a7bdf717ba471150000009";
			ChartboostGoogleSig = "19e8e401ad73a9af2eacfdd5cd6da27857c011c9";
			ChartboostAmazonID = string.Empty;
			ChartboostAmazonSig = string.Empty;
			WindowsStoreBundleID = string.Empty;
			WindowsPhoneBundleID = string.Empty;
			IAPProducts = new List<IAP>();
			IAPItem = new IAP();
			IAPItem.Name = "Bag of Gold";
			IAPItem.Description = "300 Gold for unlocking items";
			IAPItem.PriceTier = 2;
			IAPItem.iOSID = "com.naquatic.guncrafterpro.gold1";
			IAPItem.GoogleID = "com.naquatic.guncrafterpro.gold1managed";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.Consumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Case of Gold";
			IAPItem.Description = "1000 Gold for unlocking items";
			IAPItem.PriceTier = 5;
			IAPItem.iOSID = "com.naquatic.guncrafterpro.gold2";
			IAPItem.GoogleID = "com.naquatic.guncrafterpro.gold2managed";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.Consumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Truck of Gold";
			IAPItem.Description = "7000 Gold for unlocking items";
			IAPItem.PriceTier = 20;
			IAPItem.iOSID = "com.naquatic.guncrafterpro.gold3";
			IAPItem.GoogleID = "com.naquatic.guncrafterpro.gold3managed";
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.Consumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Unlock All Levels";
			IAPItem.Description = "Unlocks every level in the game";
			IAPItem.PriceTier = 1;
			IAPItem.iOSID = "com.naquatic.guncrafterpro.alllevels";
			IAPItem.GoogleID = string.Empty;
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.NonConsumable;
			IAPProducts.Add(IAPItem);
			IAPItem = new IAP();
			IAPItem.Name = "Gold Doubler";
			IAPItem.Description = "Earn 2x the Gold";
			IAPItem.PriceTier = 5;
			IAPItem.iOSID = "com.naquatic.guncrafterpro.doubler";
			IAPItem.GoogleID = string.Empty;
			IAPItem.AmazonID = string.Empty;
			IAPItem.Type = ProductType.NonConsumable;
			IAPProducts.Add(IAPItem);
		}
	}

	public static void InitializeMetadata()
	{
	}

	public virtual void Main()
	{
	}
}
