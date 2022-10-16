using System;
using CompilerGenerated;
using UnityEngine.Purchasing;

[Serializable]
public class IAP
{
	public string Name;

	public string Description;

	public int PriceTier;

	public string iOSID;

	public string GoogleID;

	public string AmazonID;

	public ProductType Type;

	public string NameChinese;

	public string DescriptionChinese;

	public string NameFrench;

	public string DescriptionFrench;

	public string NameGerman;

	public string DescriptionGerman;

	public string NameItalian;

	public string DescriptionItalian;

	public string NameJapanese;

	public string DescriptionJapanese;

	public string NameKorean;

	public string DescriptionKorean;

	public string NameRussian;

	public string DescriptionRussian;

	public string NameSpanish;

	public string DescriptionSpanish;

	public __IAP_NameLocalized_0024callable0_0024275_29__ NameLocalized;

	public __IAP_NameLocalized_0024callable0_0024275_29__ DescriptionLocalized;

	public IAP()
	{
		Name = string.Empty;
		Description = string.Empty;
		PriceTier = 1;
		iOSID = string.Empty;
		GoogleID = string.Empty;
		AmazonID = string.Empty;
		Type = ProductType.Consumable;
		NameChinese = string.Empty;
		DescriptionChinese = string.Empty;
		NameFrench = string.Empty;
		DescriptionFrench = string.Empty;
		NameGerman = string.Empty;
		DescriptionGerman = string.Empty;
		NameItalian = string.Empty;
		DescriptionItalian = string.Empty;
		NameJapanese = string.Empty;
		DescriptionJapanese = string.Empty;
		NameKorean = string.Empty;
		DescriptionKorean = string.Empty;
		NameRussian = string.Empty;
		DescriptionRussian = string.Empty;
		NameSpanish = string.Empty;
		DescriptionSpanish = string.Empty;
		NameLocalized = _0024_0024initializer_0024_0024closure_0024131;
		DescriptionLocalized = _0024_0024initializer_0024_0024closure_0024133;
	}

	internal string _0024_0024initializer_0024_0024closure_0024131()
	{
		string text = string.Empty;
		if (Settings.Language == "Chinese")
		{
			text = NameChinese;
		}
		else if (Settings.Language == "French")
		{
			text = NameFrench;
		}
		else if (Settings.Language == "German")
		{
			text = NameGerman;
		}
		else if (Settings.Language == "Italian")
		{
			text = NameItalian;
		}
		else if (Settings.Language == "Japanese")
		{
			text = NameJapanese;
		}
		else if (Settings.Language == "Korean")
		{
			text = NameKorean;
		}
		else if (Settings.Language == "Russian")
		{
			text = NameRussian;
		}
		else if (Settings.Language == "Spanish")
		{
			text = NameSpanish;
		}
		if (text == string.Empty)
		{
			text = Name;
		}
		return text;
	}

	internal string _0024_0024initializer_0024_0024closure_0024133()
	{
		string text = string.Empty;
		if (Settings.Language == "Chinese")
		{
			text = DescriptionChinese;
		}
		else if (Settings.Language == "French")
		{
			text = DescriptionFrench;
		}
		else if (Settings.Language == "German")
		{
			text = DescriptionGerman;
		}
		else if (Settings.Language == "Italian")
		{
			text = DescriptionItalian;
		}
		else if (Settings.Language == "Japanese")
		{
			text = DescriptionJapanese;
		}
		else if (Settings.Language == "Korean")
		{
			text = DescriptionKorean;
		}
		else if (Settings.Language == "Russian")
		{
			text = DescriptionRussian;
		}
		else if (Settings.Language == "Spanish")
		{
			text = DescriptionSpanish;
		}
		if (text == string.Empty)
		{
			text = Description;
		}
		return text;
	}
}
