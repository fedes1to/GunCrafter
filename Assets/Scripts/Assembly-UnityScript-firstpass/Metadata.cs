using System;
using UnityEngine;

[Serializable]
public class Metadata
{
	[Serializable]
	public enum Genre
	{
		Action = 0,
		Adventure = 1,
		Arcade = 2,
		Board = 3,
		Card = 4,
		Casino = 5,
		Dice = 6,
		Educational = 7,
		Family = 8,
		Music = 9,
		Puzzle = 10,
		Racing = 11,
		RolePlaying = 12,
		Simulation = 13,
		Sports = 14,
		Strategy = 15,
		Trivia = 16,
		Word = 17
	}

	[Serializable]
	public enum Language
	{
		de_DE = 0,
		en_AU = 1,
		en_CA = 2,
		en_GB = 3,
		en_US = 4,
		es_ES = 5,
		es_MX = 6,
		fr_CA = 7,
		fr_FR = 8,
		it = 9,
		ja = 10,
		ko = 11,
		ru = 12,
		zh_Hans = 13
	}

	[NonSerialized]
	public static LanguageTree[] Langs = new LanguageTree[9]
	{
		new LanguageTree(SystemLanguage.English, Language.en_US, new Language[4]
		{
			Language.en_US,
			Language.en_AU,
			Language.en_CA,
			Language.en_GB
		}),
		new LanguageTree(SystemLanguage.Spanish, Language.es_ES, new Language[2]
		{
			Language.es_ES,
			Language.es_MX
		}),
		new LanguageTree(SystemLanguage.French, Language.fr_FR, new Language[2]
		{
			Language.fr_FR,
			Language.fr_CA
		}),
		new LanguageTree(SystemLanguage.Chinese, Language.zh_Hans, new Language[1] { Language.zh_Hans }),
		new LanguageTree(SystemLanguage.German, Language.de_DE, new Language[1] { Language.de_DE }),
		new LanguageTree(SystemLanguage.Russian, Language.ru, new Language[1] { Language.ru }),
		new LanguageTree(SystemLanguage.Japanese, Language.ja, new Language[1] { Language.ja }),
		new LanguageTree(SystemLanguage.Italian, Language.it, new Language[1] { Language.it }),
		new LanguageTree(SystemLanguage.Korean, Language.ko, new Language[1] { Language.ko })
	};

	public static string GooglePlayLanguageCode(Language Lang)
	{
		object result;
		switch (Lang)
		{
		case Language.it:
			result = "it_IT";
			break;
		case Language.ja:
			result = "ja_JP";
			break;
		case Language.ko:
			result = "ko_KR";
			break;
		case Language.ru:
			result = "ru_RU";
			break;
		case Language.zh_Hans:
			result = "zh_CN";
			break;
		case Language.es_MX:
			result = "es_US";
			break;
		default:
			result = Lang.ToString();
			break;
		}
		return (string)result;
	}

	public virtual void Main()
	{
	}
}
