using System;
using UnityEngine;

[Serializable]
public class LanguageTree
{
	public SystemLanguage SystemLang;

	public Metadata.Language Primary;

	public Metadata.Language[] Lang;

	public string PromoBlurbiOS;

	public string PromoBlurbGoogle;

	public string PromoBlurbAmazon;

	public LanguageTree(SystemLanguage Sy, Metadata.Language P, Metadata.Language[] L)
	{
		SystemLang = Sy;
		Primary = P;
		Lang = L;
		if (Primary == Metadata.Language.en_US)
		{
			PromoBlurbiOS = "\n\n• JOIN OVER 100 MILLION GAMERS WORLDWIDE •\nFollow @Naquatic on Facebook and Twitter to find out why our apps like MonsterCrafter and Shooting Showdown have been featured by everyone from Apple to IGN, AppAdvice, and TouchArcade.";
			PromoBlurbGoogle = "\n\n• JOIN OVER 100 MILLION GAMERS WORLDWIDE •\nFollow @Naquatic on Facebook and Twitter to find out why our apps like MonsterCrafter and Shooting Showdown have been featured by everyone from Google to Apple, Amazon, Microsoft, and IGN.";
			PromoBlurbAmazon = "\n\n• JOIN OVER 100 MILLION GAMERS WORLDWIDE •\nFollow @Naquatic on Facebook and Twitter to find out why our apps like MonsterCrafter and Shooting Showdown have been featured by everyone from Amazon to Apple, Google, Microsoft, and IGN.";
		}
		else if (Primary == Metadata.Language.es_ES)
		{
			PromoBlurbiOS = "\n\n• 100 MILLONES DE JUGADORES ALREDEDOR DEL MUNDO •\nDescubre por qué los apps de Naquatic, como MonsterCrafter y Shooting Showdown, han estado entre los más jugados y sugeridos por todo el mundo desde Apple a IGN, AppAdvice y TouchArcade.";
			PromoBlurbGoogle = "\n\n• 100 MILLONES DE JUGADORES ALREDEDOR DEL MUNDO •\nDescubre por qué los apps de Naquatic, como MonsterCrafter y Shooting Showdown, han estado entre los más jugados y sugeridos por todo el mundo desde Google a Apple, Amazon, Microsoft, y IGN.";
			PromoBlurbAmazon = "\n\n• 100 MILLONES DE JUGADORES ALREDEDOR DEL MUNDO •\nDescubre por qué los apps de Naquatic, como MonsterCrafter y Shooting Showdown, han estado entre los más jugados y sugeridos por todo el mundo desde Amazon a Apple, Google, Microsoft, y IGN.";
		}
		else if (Primary == Metadata.Language.fr_FR)
		{
			PromoBlurbiOS = "\n\n• REJOIGNEZ PLUS DE 100 MILLIONS DE JOUEURS PARTOUT DANS LE MONDE •\nEt découvrez pourquoi les Apps de Naquatic comme «MonsterCrafter» et «Shooting Showdown» se sont retrouvé en tête des chartes et ont été mis en avant par tout le monde, allant de Apple jusqu'à IGN, AppAdvice et Toucharcade.";
			PromoBlurbGoogle = "\n\n• REJOIGNEZ PLUS DE 100 MILLIONS DE JOUEURS PARTOUT DANS LE MONDE •\nEt découvrez pourquoi les Apps de Naquatic comme «MonsterCrafter» et «Shooting Showdown» se sont retrouvé en tête des chartes et ont été mis en avant par tout le monde, allant de Google jusqu'à Apple, Amazon, Microsoft, et IGN.";
			PromoBlurbAmazon = "\n\n• REJOIGNEZ PLUS DE 100 MILLIONS DE JOUEURS PARTOUT DANS LE MONDE •\nEt découvrez pourquoi les Apps de Naquatic comme «MonsterCrafter» et «Shooting Showdown» se sont retrouvé en tête des chartes et ont été mis en avant par tout le monde, allant de Amazon jusqu'à Apple, Google, Microsoft, et IGN.";
		}
		else if (Primary == Metadata.Language.zh_Hans)
		{
			PromoBlurbiOS = "\n\n• 参加逾100万的玩家 •\n发现为什么游戏像\"MonsterCrafter\"和 \"Shooting Showdown\" 已被 Apple, IGN, 和 TouchArcade 赞扬了。";
			PromoBlurbGoogle = "\n\n• 参加逾100万的玩家 •\n发现为什么游戏像\"MonsterCrafter\"和 \"Shooting Showdown\" 已被 Google, Apple, Amazon, Microsoft, 和 IGN 赞扬了。";
			PromoBlurbAmazon = "\n\n• 参加逾100万的玩家 •\n发现为什么游戏像\"MonsterCrafter\"和 \"Shooting Showdown\" 已被 Amazon, Apple, Google, Microsoft, 和 IGN 赞扬了。";
		}
		else if (Primary == Metadata.Language.de_DE)
		{
			PromoBlurbiOS = "\n\n• SPIELE MIT WELTWEIT ÜBER 100 MILLIONEN SPIELERN •\nFinde selbst heraus, warum sich Apps von Naquatic wie \"MonsterCrafter\" und \"Shooting Showdown\" ganz oben in den Bestenlisten befinden und von Apple über IGN, AppAdvice bis hin zu TouchArcade empfohlen werden.";
			PromoBlurbGoogle = "\n\n• SPIELE MIT WELTWEIT ÜBER 100 MILLIONEN SPIELERN •\nFinde selbst heraus, warum sich Apps von Naquatic wie \"MonsterCrafter\" und \"Shooting Showdown\" ganz oben in den Bestenlisten befinden und von Google über Apple, Amazon, Microsoft bis hin zu IGN empfohlen werden.";
			PromoBlurbAmazon = "\n\n• SPIELE MIT WELTWEIT ÜBER 100 MILLIONEN SPIELERN •\nFinde selbst heraus, warum sich Apps von Naquatic wie \"MonsterCrafter\" und \"Shooting Showdown\" ganz oben in den Bestenlisten befinden und von Amazon über Apple, Google, Microsoft bis hin zu IGN empfohlen werden.";
		}
		else if (Primary == Metadata.Language.ru)
		{
			PromoBlurbiOS = "\n\n• ПРИСОЕДИНЯЙТЕСЬ К БОЛЕЕ ЧЕМ 100 МИЛЛИОНАМ ИГРОКОВ ПО ВСЕМУ МИРУ •\nУзнайте, почему игры Naquatic, такие как MonsterCrafter и Shooting Showdown, поднимались до верхних строчек рейтингов и были отмечены всеми, начиная с Apple и заканчивая IGN, AppAdvice и TouchArcade.";
			PromoBlurbGoogle = "\n\n• ПРИСОЕДИНЯЙТЕСЬ К БОЛЕЕ ЧЕМ 100 МИЛЛИОНАМ ИГРОКОВ ПО ВСЕМУ МИРУ •\nУзнайте, почему игры Naquatic, такие как MonsterCrafter и Shooting Showdown, поднимались до верхних строчек рейтингов и были отмечены всеми, начиная с Google и заканчивая Apple, Amazon, Microsoft и IGN.";
			PromoBlurbAmazon = "\n\n• ПРИСОЕДИНЯЙТЕСЬ К БОЛЕЕ ЧЕМ 100 МИЛЛИОНАМ ИГРОКОВ ПО ВСЕМУ МИРУ •\nУзнайте, почему игры Naquatic, такие как MonsterCrafter и Shooting Showdown, поднимались до верхних строчек рейтингов и были отмечены всеми, начиная с Amazon и заканчивая Apple, Google, Microsoft и IGN.";
		}
		else if (Primary == Metadata.Language.ja)
		{
			PromoBlurbiOS = "\n\n• 10,000 万人を越す世界中のプレーヤーに加わろう •\n「MonsterCrafter」や「Shooting Showdown」といったNaquatic 開発のアプリがトップチャートを賑わせ、Apple や IGN、AppAdvice、TouchArcade といった場所で紹介された理由を探ってみよう。";
			PromoBlurbGoogle = "\n\n• 10,000 万人を越す世界中のプレーヤーに加わろう •\n「MonsterCrafter」や「Shooting Showdown」といったNaquatic 開発のアプリがトップチャートを賑わせ、Google や Apple、Amazon、Microsoft、IGN といった場所で紹介された理由を探ってみよう。";
			PromoBlurbAmazon = "\n\n• 10,000 万人を越す世界中のプレーヤーに加わろう •\n「MonsterCrafter」や「Shooting Showdown」といったNaquatic 開発のアプリがトップチャートを賑わせ、Amazon や Apple、Google、Microsoft、IGN といった場所で紹介された理由を探ってみよう。";
		}
		else if (Primary == Metadata.Language.it)
		{
			PromoBlurbiOS = "\n\n• UNISCITI A OLTRE 100 MILIONI DI GIOCATORI •\nSegui @Naquatic su Facebook e Twitter per scoprire perché le nostre app come MonsterCrafter e Shooting Showdown sono state presentate da tutti, da Apple a IGN, AppAdvice e TouchArcade.";
			PromoBlurbGoogle = "\n\n• UNISCITI A OLTRE 100 MILIONI DI GIOCATORI •\nSegui @Naquatic su Facebook e Twitter per scoprire perché le nostre app come MonsterCrafter e Shooting Showdown sono state presentate da tutti, da Google a Apple, Amazon e Microsoft.";
			PromoBlurbAmazon = "\n\n• UNISCITI A OLTRE 100 MILIONI DI GIOCATORI •\nSegui @Naquatic su Facebook e Twitter per scoprire perché le nostre app come MonsterCrafter e Shooting Showdown sono state presentate da tutti, da Amazon a Apple, Google e Microsoft.";
		}
		else if (Primary == Metadata.Language.ko)
		{
			PromoBlurbiOS = "\n\n• 수백만 명의 게이머와 함께 •\n 페이스북과 트위터에서 @Naquatic 계정을 팔로우하시면 Apple, IGN, AppAdvice, TouchArcade 등으로부터 극찬받은 MonsterCrafter, Shooting Showdown 등 신작 게임 소식을 받아보실 수 있습니다.";
			PromoBlurbGoogle = "\n\n• 수백만 명의 게이머와 함께 •\n 페이스북과 트위터에서 @Naquatic 계정을 팔로우하시면 Google, Apple, Amazon, Microsoft 등으로부터 극찬받은 MonsterCrafter, Shooting Showdown 등 신작 게임 소식을 받아보실 수 있습니다.";
			PromoBlurbAmazon = "\n\n• 수백만 명의 게이머와 함께 •\n 페이스북과 트위터에서 @Naquatic 계정을 팔로우하시면 Amazon, Apple, Google, Microsoft 등으로부터 극찬받은 MonsterCrafter, Shooting Showdown 등 신작 게임 소식을 받아보실 수 있습니다.";
		}
	}
}
