using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Boo.Lang;
using ChartboostSDK;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Lang;

[Serializable]
public class Splash : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_00241269 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal GameObject _0024NewUI_00241270;

			internal float _0024f_00241271;

			internal Splash _0024self__00241272;

			public _0024(Splash self_)
			{
				_0024self__00241272 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241272.gameObject.AddComponent(typeof(Settings));
					Menus.InitializeVR();
					_0024self__00241272.InitializeSplashImages();
					_0024self__00241272.InitializeQualitySettings();
					Menus.InitializeNaquaticSDK();
					Menus.ShowTestSuite = _0024self__00241272.ShowMediationTestSuiteInDebug;
					_0024self__00241272.StartCoroutine(Menus.InitializeAds());
					Menus.InitializeAchievements();
					Loc.LoadResource();
					result = (Yield(2, _0024self__00241272.StartCoroutine(Menus.InitializeGameCenter(_0024self__00241272.GameCenterWaitTime))) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241272.UseInternetCheckIn)
					{
						if (_0024self__00241272.RequireInternetCheckIn)
						{
							_0024NewUI_00241270 = GameObject.Find("UI");
							_0024self__00241272.PopupMenu = _0024NewUI_00241270.transform.Find("Popup").gameObject;
							((Button)_0024self__00241272.PopupMenu.transform.Find("PopupButtons/PopupTwo1").gameObject.GetComponent(typeof(Button))).onClick.AddListener(_0024self__00241272._0024Start_0024closure_0024179);
							((Button)_0024self__00241272.PopupMenu.transform.Find("PopupButtons/PopupTwo2").gameObject.GetComponent(typeof(Button))).onClick.AddListener(_0024self__00241272._0024Start_0024closure_0024180);
							((Text)_0024self__00241272.PopupMenu.transform.Find("PopupButtons/PopupTwo1/PopupButton1Text").gameObject.GetComponent(typeof(Text))).text = Loc.L("PlayOffline").ToUpper();
							((Text)_0024self__00241272.PopupMenu.transform.Find("PopupButtons/PopupTwo2/PopupButton2Text").gameObject.GetComponent(typeof(Text))).text = Loc.L("TRY AGAIN").ToUpper();
							((Text)_0024self__00241272.PopupMenu.transform.Find("PopupImage/PopupText").gameObject.GetComponent(typeof(Text))).text = Loc.L("errorServer");
						}
						Saver.Set("VerifyKillSwitch", Saver.GetInt("VerifyKillSwitch") - 1);
						if (Saver.GetInt("VerifyKillSwitch") > 0)
						{
							result = (Yield(3, new WaitForSeconds(1.5f)) ? 1 : 0);
							break;
						}
						_0024self__00241272.StartCoroutine(_0024self__00241272.CheckConnection());
						goto case 4;
					}
					result = (Yield(5, new WaitForSeconds(1.5f)) ? 1 : 0);
					break;
				case 4:
					if (!Verified)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
				case 5:
					_0024f_00241271 = default(float);
					goto IL_0345;
				case 6:
					_0024f_00241271 += Time.deltaTime;
					goto IL_0345;
				case 7:
					_0024f_00241271 += Time.deltaTime;
					goto IL_03df;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0345:
					if (_0024f_00241271 < 6f && !Menus.ChartboostInitialized)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					if (Menus.ChartboostInitialized)
					{
						_0024f_00241271 = 0f;
						goto IL_03df;
					}
					goto IL_03ef;
					IL_03ef:
					_0024self__00241272.StartCoroutine(_0024self__00241272.LoadMenu());
					YieldDefault(1);
					goto case 1;
					IL_03df:
					if (_0024f_00241271 < 5f && (!(PlayerPrefs.GetString("FirstAdEver") == string.Empty) || !Chartboost.hasInterstitial(CBLocation.Startup)) && (!(PlayerPrefs.GetString("FirstAdEver") != string.Empty) || !Chartboost.hasInterstitial(CBLocation.HomeScreen)))
					{
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					goto IL_03ef;
				}
				return (byte)result != 0;
			}
		}

		internal Splash _0024self__00241273;

		public _0024Start_00241269(Splash self_)
		{
			_0024self__00241273 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241273);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LoadMenu_00241274 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AsyncOperation _0024LoadingOperation_00241275;

			internal float _0024Counter_00241276;

			internal float _0024_0024533_00241277;

			internal Rect _0024_0024534_00241278;

			internal Splash _0024self__00241279;

			public _0024(Splash self_)
			{
				_0024self__00241279 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024LoadingOperation_00241275 = Application.LoadLevelAsync(1);
					_0024Counter_00241276 = default(float);
					goto case 2;
				case 2:
					if (!_0024LoadingOperation_00241275.isDone)
					{
						_0024Counter_00241276 += Time.deltaTime * 0.75f;
						float num = (_0024_0024533_00241277 = Mathf.Clamp(_0024self__00241279.LoadingBarWidth + 230f * Settings.Scale * _0024LoadingOperation_00241275.progress * 2.1f * 0.3f + _0024Counter_00241276 * Settings.Scale, 0f, _0024self__00241279.LoadingBar.pixelInset.width - 16f * Settings.Scale));
						Rect rect = (_0024_0024534_00241278 = _0024self__00241279.LoadingBarFill.pixelInset);
						float num3 = (_0024_0024534_00241278.width = _0024_0024533_00241277);
						Rect rect3 = (_0024self__00241279.LoadingBarFill.pixelInset = _0024_0024534_00241278);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Splash _0024self__00241280;

		public _0024LoadMenu_00241274(Splash self_)
		{
			_0024self__00241280 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241280);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FlashBar_00241281 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Cycle_00241282;

			internal float _0024Cycle2_00241283;

			internal float _0024LoadingFade_00241284;

			internal float _0024Alpha_00241285;

			internal float _0024_0024535_00241286;

			internal Rect _0024_0024536_00241287;

			internal Splash _0024self__00241288;

			public _0024(Splash self_)
			{
				_0024self__00241288 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0203
				int result;
				switch (_state)
				{
				default:
					_0024Cycle_00241282 = default(float);
					_0024Cycle2_00241283 = default(float);
					_0024LoadingFade_00241284 = default(float);
					_0024Alpha_00241285 = default(float);
					goto case 2;
				case 2:
				{
					_0024Alpha_00241285 += Time.deltaTime * 0.4f;
					_0024Alpha_00241285 = Mathf.Clamp(_0024Alpha_00241285, 0f, 0.4f);
					_0024Cycle_00241282 += Time.deltaTime * 3f;
					_0024Cycle2_00241283 = (Mathf.Cos(_0024Cycle_00241282) + 1f) / 2f * 0.8f;
					_0024self__00241288.LoadingBarWidth += Time.deltaTime * Settings.Scale * 5f;
					float num = (_0024_0024535_00241286 = Mathf.Clamp(_0024self__00241288.LoadingBarWidth, 0f, 40f * Settings.Scale));
					Rect rect = (_0024_0024536_00241287 = _0024self__00241288.LoadingBarFill.pixelInset);
					float num3 = (_0024_0024536_00241287.width = _0024_0024535_00241286);
					Rect rect3 = (_0024self__00241288.LoadingBarFill.pixelInset = _0024_0024536_00241287);
					_0024self__00241288.LoadingBar.color = new Color(_0024Cycle2_00241283 * _0024self__00241288.LoadingBarColor.r, _0024Cycle2_00241283 * _0024self__00241288.LoadingBarColor.g, _0024Cycle2_00241283 * _0024self__00241288.LoadingBarColor.b, _0024Alpha_00241285);
					_0024self__00241288.LoadingBarFill.color = new Color(_0024self__00241288.LoadingBarFillColor.r, _0024self__00241288.LoadingBarFillColor.g, _0024self__00241288.LoadingBarFillColor.b, _0024Alpha_00241285);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Splash _0024self__00241289;

		public _0024FlashBar_00241281(Splash self_)
		{
			_0024self__00241289 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241289);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Create3DGUI_00241290 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024Plan_00241291;

			internal float _0024ScaleOffset_00241292;

			internal float _0024_0024549_00241293;

			internal Color _0024_0024550_00241294;

			internal GameObject _0024Target_00241295;

			public _0024(GameObject Target)
			{
				_0024Target_00241295 = Target;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_03ff
				int result;
				switch (_state)
				{
				default:
					_0024Plan_00241291 = GameObject.CreatePrimitive(PrimitiveType.Plane);
					UnityEngine.Object.Destroy((Collider)_0024Plan_00241291.GetComponent(typeof(Collider)));
					_0024Plan_00241291.name = _0024Target_00241295.name;
					((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).material = new Material(Menus.VRTextureShaderString);
					((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).sharedMaterial.renderQueue = (int)(3000f + _0024Target_00241295.transform.localPosition.z + 10f);
					_0024Plan_00241291.transform.eulerAngles = new Vector3(90f, 180f, 0f);
					((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = ((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).texture;
					goto case 2;
				case 2:
				{
					_0024ScaleOffset_00241292 = 2f / Settings.Scale;
					_0024Plan_00241291.transform.localScale = new Vector3(((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).pixelInset.width, 1f, ((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).pixelInset.height) * 0.0001f * _0024ScaleOffset_00241292;
					_0024Plan_00241291.transform.localPosition = (new Vector3(((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).pixelInset.x, ((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).pixelInset.y, 0f) + new Vector3(((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).pixelInset.width, ((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).pixelInset.height, 0f) * 0.5f) * 0.001f * _0024ScaleOffset_00241292 + new Vector3(0f, 0f, 1f - ((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).transform.localPosition.z / 20000f) + new Vector3(0f, 0.2f, 0f);
					((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).sharedMaterial.color = ((GUITexture)_0024Target_00241295.GetComponent(typeof(GUITexture))).color;
					float num = (_0024_0024549_00241293 = ((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).sharedMaterial.color.a * 2f);
					Color color = (_0024_0024550_00241294 = ((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).sharedMaterial.color);
					float num2 = (_0024_0024550_00241294.a = _0024_0024549_00241293);
					Color color3 = (((Renderer)_0024Plan_00241291.GetComponent(typeof(Renderer))).sharedMaterial.color = _0024_0024550_00241294);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024Target_00241296;

		public _0024Create3DGUI_00241290(GameObject Target)
		{
			_0024Target_00241296 = Target;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Target_00241296);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReCheckConnection_00241297 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Splash _0024self__00241298;

			public _0024(Splash self_)
			{
				_0024self__00241298 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241298.StartCoroutine(_0024self__00241298.CheckConnection());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Splash _0024self__00241299;

		public _0024ReCheckConnection_00241297(Splash self_)
		{
			_0024self__00241299 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241299);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CheckConnection_00241300 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024Call_00241301;

			internal string[] _0024AllData_00241302;

			internal int _0024ParsedInt_00241303;

			internal DateTime _0024NewDate_00241304;

			internal Splash _0024self__00241305;

			public _0024(Splash self_)
			{
				_0024self__00241305 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024Call_00241301 = new WWW("https://naquatic.com/System/" + App.SystemName + "/firstScript.php?" + Settings.DeviceID);
					result = (Yield(2, _0024Call_00241301) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024Call_00241301.error))
					{
						MonoBehaviour.print(_0024Call_00241301.text);
						if (_0024Call_00241301.text == "-11339911")
						{
							Saver.Set("VerifyKillSwitch", 8);
							Verified = true;
							VerifyKillSwitch = true;
						}
						else
						{
							_0024AllData_00241302 = Regex.Split(_0024Call_00241301.text, ":");
							_0024ParsedInt_00241303 = default(int);
							if (Extensions.get_length((System.Array)_0024AllData_00241302) == 2 && _0024AllData_00241302[0] == "1" && int.TryParse(_0024AllData_00241302[1], out _0024ParsedInt_00241303))
							{
								Verified = true;
								_0024NewDate_00241304 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
								TheTime = _0024NewDate_00241304.AddSeconds(_0024ParsedInt_00241303);
								MonoBehaviour.print(TheTime);
							}
							else if (_0024self__00241305.RequireInternetCheckIn)
							{
								_0024self__00241305.PopupMenu.SetActive(true);
							}
						}
					}
					else if (_0024self__00241305.RequireInternetCheckIn)
					{
						_0024self__00241305.PopupMenu.SetActive(true);
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Splash _0024self__00241306;

		public _0024CheckConnection_00241300(Splash self_)
		{
			_0024self__00241306 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00241306);
		}
	}

	public int QualityForAniso;

	public int QualityForAA2;

	public int QualityForAA4;

	public bool WaitForXcodeStart;

	public Color LoadingBarColor;

	public Color LoadingBarFillColor;

	private GUITexture m_Splash;

	private GUITexture LoadingBar;

	private GUITexture LoadingBarFill;

	private float LoadingBarWidth;

	public int GameCenterWaitTime;

	public bool UseInternetCheckIn;

	public bool RequireInternetCheckIn;

	private GameObject PopupMenu;

	[NonSerialized]
	public static bool Verified;

	[NonSerialized]
	public static DateTime TheTime;

	[NonSerialized]
	public static bool VerifyKillSwitch;

	[NonSerialized]
	public static bool PlayOffline;

	public bool ShowMediationTestSuiteInDebug;

	public Splash()
	{
		QualityForAniso = 3;
		QualityForAA2 = 4;
		QualityForAA4 = 5;
		LoadingBarColor = Color.white;
		LoadingBarFillColor = Color.white;
		GameCenterWaitTime = 30;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00241269(this).GetEnumerator();
	}

	public virtual IEnumerator LoadMenu()
	{
		return new _0024LoadMenu_00241274(this).GetEnumerator();
	}

	public virtual IEnumerator FlashBar()
	{
		return new _0024FlashBar_00241281(this).GetEnumerator();
	}

	public virtual void InitializeSplashImages()
	{
		GameObject gameObject = new GameObject("Splash");
		GameObject gameObject2 = new GameObject("LoadingBar");
		GameObject gameObject3 = new GameObject("LoadingBarFill");
		gameObject.transform.position = new Vector3(0.5f, 0.5f, 0f);
		gameObject2.transform.position = new Vector3(0.5f, 0.5f, 1900f);
		gameObject3.transform.position = new Vector3(0.5f, 0.5f, 1901f);
		gameObject.transform.localScale = new Vector3(0f, 0f, 1f);
		gameObject2.transform.localScale = new Vector3(0f, 0f, 1f);
		gameObject3.transform.localScale = new Vector3(0f, 0f, 1f);
		m_Splash = (GUITexture)gameObject.AddComponent(typeof(GUITexture));
		LoadingBar = (GUITexture)gameObject2.AddComponent(typeof(GUITexture));
		LoadingBarFill = (GUITexture)gameObject3.AddComponent(typeof(GUITexture));
		int num = Screen.height;
		if (Screen.width > Screen.height)
		{
			num = Screen.width;
		}
		if (num > 512)
		{
			if (!Settings.IsPro)
			{
				m_Splash.texture = (Texture)Resources.Load("Splash@4x");
			}
			else
			{
				m_Splash.texture = (Texture)Resources.Load("SplashPro@4x");
				if (!m_Splash.texture)
				{
					m_Splash.texture = (Texture)Resources.Load("Splash@4x");
				}
			}
		}
		else if (!Settings.IsPro)
		{
			m_Splash.texture = (Texture)Resources.Load("Splash");
		}
		else
		{
			m_Splash.texture = (Texture)Resources.Load("SplashPro");
			if (!m_Splash.texture)
			{
				m_Splash.texture = (Texture)Resources.Load("Splash");
			}
		}
		if (Settings.IsPro)
		{
			LoadingBarColor = new Color(1f, 0.87f, 0.01f);
		}
		m_Splash.pixelInset = new Rect(-num / 2, -num / 2, num, num);
		LoadingBar.texture = (Texture)Resources.Load("SplashLoadingBar" + Settings.Suffix);
		LoadingBarFill.texture = (Texture)Resources.Load("SplashLoadingBarFill" + Settings.Suffix);
		float num2 = (float)(LoadingBar.texture.width / Settings.SuffixInteger) * Settings.Scale;
		Rect pixelInset = LoadingBar.pixelInset;
		float num4 = (pixelInset.width = num2);
		Rect rect2 = (LoadingBar.pixelInset = pixelInset);
		float num5 = (float)(LoadingBar.texture.height / Settings.SuffixInteger) * Settings.Scale;
		Rect pixelInset2 = LoadingBar.pixelInset;
		float num7 = (pixelInset2.height = num5);
		Rect rect4 = (LoadingBar.pixelInset = pixelInset2);
		float num8 = (float)(LoadingBarFill.texture.width / Settings.SuffixInteger) * Settings.Scale;
		Rect pixelInset3 = LoadingBarFill.pixelInset;
		float num10 = (pixelInset3.width = num8);
		Rect rect6 = (LoadingBarFill.pixelInset = pixelInset3);
		float num11 = (float)(LoadingBarFill.texture.height / Settings.SuffixInteger) * Settings.Scale;
		Rect pixelInset4 = LoadingBarFill.pixelInset;
		float num13 = (pixelInset4.height = num11);
		Rect rect8 = (LoadingBarFill.pixelInset = pixelInset4);
		LoadingBar.pixelInset = new Rect((0f - LoadingBar.pixelInset.width) / 2f, 5f * Settings.Scale - (float)(Screen.height / 2), LoadingBar.pixelInset.width, LoadingBar.pixelInset.height);
		LoadingBarFill.pixelInset = new Rect(LoadingBar.pixelInset.x + 7f * Settings.Scale, LoadingBar.pixelInset.y + 7.5f * Settings.Scale, 0f, LoadingBarFill.pixelInset.height);
		int num14 = 0;
		Color color = LoadingBar.color;
		float num15 = (color.a = num14);
		Color color3 = (LoadingBar.color = color);
		int num16 = 0;
		Color color4 = LoadingBarFill.color;
		float num17 = (color4.a = num16);
		Color color6 = (LoadingBarFill.color = color4);
		if (Menus.IsVR)
		{
			Screen.lockCursor = true;
			((Camera)GetComponent(typeof(Camera))).enabled = false;
			GameObject gameObject4 = GameObject.CreatePrimitive(PrimitiveType.Plane);
			UnityEngine.Object.Destroy((Collider)gameObject4.GetComponent(typeof(Collider)));
			gameObject4.name = "Splash";
			((Renderer)gameObject4.GetComponent(typeof(Renderer))).material = new Material(Menus.VRTextureShaderString);
			((Renderer)gameObject4.GetComponent(typeof(Renderer))).sharedMaterial.renderQueue = 3010;
			gameObject4.transform.eulerAngles = new Vector3(90f, 180f, 0f);
			((Renderer)gameObject4.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = (Texture)Resources.Load("VR/NaquaticSplash");
			float num18 = 2f / Settings.Scale;
			gameObject4.transform.localScale = new Vector3(((Renderer)gameObject4.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture.width, 1f, ((Renderer)gameObject4.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture.height) * 0.0002f * num18;
			gameObject4.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, 1f);
			((Renderer)gameObject4.GetComponent(typeof(Renderer))).sharedMaterial.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			LoadingBarColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			LoadingBarFillColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			StartCoroutine(Create3DGUI(LoadingBar.gameObject));
			StartCoroutine(Create3DGUI(LoadingBarFill.gameObject));
		}
		StartCoroutine("FlashBar");
	}

	public virtual IEnumerator Create3DGUI(GameObject Target)
	{
		return new _0024Create3DGUI_00241290(Target).GetEnumerator();
	}

	public virtual void InitializeQualitySettings()
	{
		if (Settings.Quality < QualityForAniso)
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		}
	}

	public virtual void ChoosePlayOffline()
	{
		PlayOffline = true;
		Verified = true;
		VerifyKillSwitch = true;
	}

	public virtual void ChooseReCheckConnection()
	{
		StartCoroutine(ReCheckConnection());
	}

	public virtual IEnumerator ReCheckConnection()
	{
		return new _0024ReCheckConnection_00241297(this).GetEnumerator();
	}

	public virtual IEnumerator CheckConnection()
	{
		return new _0024CheckConnection_00241300(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}

	internal void _0024Start_0024closure_0024179()
	{
		PopupMenu.SetActive(false);
		ChoosePlayOffline();
	}

	internal void _0024Start_0024closure_0024180()
	{
		PopupMenu.SetActive(false);
		ChooseReCheckConnection();
	}
}
