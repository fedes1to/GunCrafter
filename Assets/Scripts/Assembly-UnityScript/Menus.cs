using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using ChartboostSDK;
using CompilerGenerated;
using GooglePlayGames;
using Heyzap;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityScript.Lang;

[Serializable]
public class Menus : MonoBehaviour
{
	[Serializable]
	internal class _0024TraverseMenuHierarchy_0024locals_0024551
	{
		internal IEnumerator _0024_0024iterator_0024139;
	}

	[Serializable]
	internal class _0024AddButtonListener_0024locals_0024552
	{
		internal __Menus_AddButtonListener_0024callable1_00242022_61__ _0024Func;

		internal int _0024i;
	}

	[Serializable]
	internal class _0024AddOnPointerDownListener_0024locals_0024553
	{
		internal __Menus_AddButtonListener_0024callable1_00242022_61__ _0024Func;

		internal int _0024i;
	}

	[Serializable]
	internal class _0024AddOnPointerEnterListener_0024locals_0024554
	{
		internal __Menus_AddButtonListener_0024callable1_00242022_61__ _0024Func;

		internal int _0024i;
	}

	[Serializable]
	internal class _0024Popup_0024locals_0024555
	{
		internal __Menus_PopupSingleCallback_0024callable2_00243643_34__ _0024Callback;
	}

	[Serializable]
	internal class _0024Popup_0024locals_0024556
	{
		internal __Menus_Popup_0024callable3_00243785_46__ _0024Callback;
	}

	[Serializable]
	internal class _0024TextInput_0024locals_0024557
	{
		internal int _0024Min;

		internal __Menus_TextInput_0024callable7_00246626_26__ _0024CheckFunction;

		internal __Menus_LoginCheck_0024callable5_00246585_26__ _0024ParseFunction;

		internal __Menus_TextInput_0024callable6_00246624_145__ _0024SubmitFunction;
	}

	[Serializable]
	internal class _0024TraverseMenuHierarchy_0024closure_0024135
	{
		internal Transform _0024Child_0024558;

		internal Menus _0024this_0024559;

		internal _0024TraverseMenuHierarchy_0024locals_0024551 _0024_0024locals_0024560;

		public _0024TraverseMenuHierarchy_0024closure_0024135(Transform _0024Child_0024558, Menus _0024this_0024559, _0024TraverseMenuHierarchy_0024locals_0024551 _0024_0024locals_0024560)
		{
			this._0024Child_0024558 = _0024Child_0024558;
			this._0024this_0024559 = _0024this_0024559;
			this._0024_0024locals_0024560 = _0024_0024locals_0024560;
		}

		public void Invoke()
		{
			_0024this_0024559.ButtonWasPressedBroadcast(_0024Child_0024558.name);
			UnityRuntimeServices.Update(_0024_0024locals_0024560._0024_0024iterator_0024139, _0024Child_0024558);
		}
	}

	[Serializable]
	internal class _0024TraverseMenuHierarchy_0024closure_0024136
	{
		internal Transform _0024Child_0024561;

		internal Menus _0024this_0024562;

		internal _0024TraverseMenuHierarchy_0024locals_0024551 _0024_0024locals_0024563;

		public _0024TraverseMenuHierarchy_0024closure_0024136(Transform _0024Child_0024561, Menus _0024this_0024562, _0024TraverseMenuHierarchy_0024locals_0024551 _0024_0024locals_0024563)
		{
			this._0024Child_0024561 = _0024Child_0024561;
			this._0024this_0024562 = _0024this_0024562;
			this._0024_0024locals_0024563 = _0024_0024locals_0024563;
		}

		public void Invoke()
		{
			_0024this_0024562.InputFieldChangedBroadcast(_0024Child_0024561.name);
			UnityRuntimeServices.Update(_0024_0024locals_0024563._0024_0024iterator_0024139, _0024Child_0024561);
		}
	}

	[Serializable]
	internal class _0024TraverseMenuHierarchy_0024closure_0024137
	{
		internal Menus _0024this_0024564;

		internal Transform _0024Child_0024565;

		internal _0024TraverseMenuHierarchy_0024locals_0024551 _0024_0024locals_0024566;

		public _0024TraverseMenuHierarchy_0024closure_0024137(Menus _0024this_0024564, Transform _0024Child_0024565, _0024TraverseMenuHierarchy_0024locals_0024551 _0024_0024locals_0024566)
		{
			this._0024this_0024564 = _0024this_0024564;
			this._0024Child_0024565 = _0024Child_0024565;
			this._0024_0024locals_0024566 = _0024_0024locals_0024566;
		}

		public void Invoke()
		{
			_0024this_0024564.SliderChangedBroadcast(_0024Child_0024565.name, ((Slider)_0024Child_0024565.gameObject.GetComponent(typeof(Slider))).value);
			UnityRuntimeServices.Update(_0024_0024locals_0024566._0024_0024iterator_0024139, _0024Child_0024565);
		}
	}

	[Serializable]
	internal class _0024AddButtonListener_0024closure_0024140
	{
		internal _0024AddButtonListener_0024locals_0024552 _0024_0024locals_0024567;

		public _0024AddButtonListener_0024closure_0024140(_0024AddButtonListener_0024locals_0024552 _0024_0024locals_0024567)
		{
			this._0024_0024locals_0024567 = _0024_0024locals_0024567;
		}

		public void Invoke()
		{
			_0024_0024locals_0024567._0024Func(_0024_0024locals_0024567._0024i);
		}
	}

	[Serializable]
	internal class _0024AddOnPointerDownListener_0024closure_0024141
	{
		internal _0024AddOnPointerDownListener_0024locals_0024553 _0024_0024locals_0024568;

		public _0024AddOnPointerDownListener_0024closure_0024141(_0024AddOnPointerDownListener_0024locals_0024553 _0024_0024locals_0024568)
		{
			this._0024_0024locals_0024568 = _0024_0024locals_0024568;
		}

		public void Invoke()
		{
			_0024_0024locals_0024568._0024Func(_0024_0024locals_0024568._0024i);
		}
	}

	[Serializable]
	internal class _0024AddOnPointerEnterListener_0024closure_0024142
	{
		internal _0024AddOnPointerEnterListener_0024locals_0024554 _0024_0024locals_0024569;

		public _0024AddOnPointerEnterListener_0024closure_0024142(_0024AddOnPointerEnterListener_0024locals_0024554 _0024_0024locals_0024569)
		{
			this._0024_0024locals_0024569 = _0024_0024locals_0024569;
		}

		public void Invoke()
		{
			_0024_0024locals_0024569._0024Func(_0024_0024locals_0024569._0024i);
		}
	}

	[Serializable]
	internal class _0024Popup_0024closure_0024151
	{
		internal _0024Popup_0024locals_0024555 _0024_0024locals_0024570;

		public _0024Popup_0024closure_0024151(_0024Popup_0024locals_0024555 _0024_0024locals_0024570)
		{
			this._0024_0024locals_0024570 = _0024_0024locals_0024570;
		}

		public void Invoke()
		{
			PopupMenu.SetActive(false);
			_0024_0024locals_0024570._0024Callback();
		}
	}

	[Serializable]
	internal class _0024Popup_0024closure_0024152
	{
		internal Menus _0024this_0024571;

		internal _0024Popup_0024locals_0024556 _0024_0024locals_0024572;

		public _0024Popup_0024closure_0024152(Menus _0024this_0024571, _0024Popup_0024locals_0024556 _0024_0024locals_0024572)
		{
			this._0024this_0024571 = _0024this_0024571;
			this._0024_0024locals_0024572 = _0024_0024locals_0024572;
		}

		public void Invoke()
		{
			PopupMenu.SetActive(false);
			_0024this_0024571.ButtonWasPressedBroadcast(_0024this_0024571.PopupButton1.name);
			_0024_0024locals_0024572._0024Callback(true);
		}
	}

	[Serializable]
	internal class _0024Popup_0024closure_0024153
	{
		internal Menus _0024this_0024573;

		internal _0024Popup_0024locals_0024556 _0024_0024locals_0024574;

		public _0024Popup_0024closure_0024153(Menus _0024this_0024573, _0024Popup_0024locals_0024556 _0024_0024locals_0024574)
		{
			this._0024this_0024573 = _0024this_0024573;
			this._0024_0024locals_0024574 = _0024_0024locals_0024574;
		}

		public void Invoke()
		{
			PopupMenu.SetActive(false);
			_0024this_0024573.ButtonWasPressedBroadcast(_0024this_0024573.PopupButton2.name);
			_0024_0024locals_0024574._0024Callback(false);
		}
	}

	[Serializable]
	internal class _0024TextInput_0024closure_0024162
	{
		internal Menus _0024this_0024575;

		internal _0024TextInput_0024locals_0024557 _0024_0024locals_0024576;

		public _0024TextInput_0024closure_0024162(Menus _0024this_0024575, _0024TextInput_0024locals_0024557 _0024_0024locals_0024576)
		{
			this._0024this_0024575 = _0024this_0024575;
			this._0024_0024locals_0024576 = _0024_0024locals_0024576;
		}

		public void Invoke()
		{
			_0024this_0024575.TextInputChange(_0024_0024locals_0024576._0024CheckFunction, _0024_0024locals_0024576._0024ParseFunction, _0024_0024locals_0024576._0024Min);
		}
	}

	[Serializable]
	internal class _0024TextInput_0024closure_0024163
	{
		internal Menus _0024this_0024577;

		internal _0024TextInput_0024locals_0024557 _0024_0024locals_0024578;

		public _0024TextInput_0024closure_0024163(Menus _0024this_0024577, _0024TextInput_0024locals_0024557 _0024_0024locals_0024578)
		{
			this._0024this_0024577 = _0024this_0024577;
			this._0024_0024locals_0024578 = _0024_0024locals_0024578;
		}

		public void Invoke()
		{
			_0024this_0024577.TextInputSubmit(_0024_0024locals_0024578._0024SubmitFunction);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LoadGame_0024995 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal int _0024Mode_0024996;

			internal Menus _0024self__0024997;

			public _0024(int Mode, Menus self_)
			{
				_0024Mode_0024996 = Mode;
				_0024self__0024997 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					LoadingGame = true;
					_0024self__0024997.SendMessage("LoadingGame", SendMessageOptions.DontRequireReceiver);
					if (LoadingMatchText != null)
					{
						LoadingMatchText.text = string.Empty;
					}
					if (_0024self__0024997.ModeChangeFadeOut)
					{
						result = (Yield(2, _0024self__0024997.StartCoroutine("Fade", 0.5f)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (_0024Mode_0024996 <= 0)
					{
						IsSinglePlayer = true;
						IsSim = false;
					}
					else
					{
						IsSinglePlayer = false;
					}
					if (_0024Mode_0024996 == 0)
					{
						IsRematch = false;
						IsFriendMatch = false;
						if (RuntimeServices.EqualityOperator(OnlinePlayers, null))
						{
							OnlinePlayers = new System.Collections.Generic.List<OnlinePlayer>();
						}
						else
						{
							OnlinePlayers.Clear();
						}
						if (!_0024self__0024997.FirstLoad)
						{
							_0024self__0024997.FirstLoad = true;
						}
						_0024self__0024997.StopCoroutine("GameCenterTimeoutCountdown");
					}
					LastMode = GameMode;
					GameMode = _0024Mode_0024996;
					GameEnded = false;
					MatchAction = string.Empty;
					Saver.Save();
					if (_0024Mode_0024996 == 0)
					{
						FoundOpponent = false;
					}
					if (LastMode != 0)
					{
						_0024self__0024997.GameCenterDisconnect();
					}
					((Game)_0024self__0024997.GetComponent(typeof(Game))).StopAllCoroutines();
					_0024self__0024997.SendMessage("ResetVariables", SendMessageOptions.DontRequireReceiver);
					_0024self__0024997.RematchReset();
					_0024self__0024997.StartCoroutine(_0024self__0024997.Fade(0f));
					LoadingGame = false;
					_0024self__0024997.SendMessage("SetupGame", _0024Mode_0024996, SendMessageOptions.DontRequireReceiver);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Mode_0024998;

		internal Menus _0024self__0024999;

		public _0024LoadGame_0024995(int Mode, Menus self_)
		{
			_0024Mode_0024998 = Mode;
			_0024self__0024999 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024Mode_0024998, _0024self__0024999);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ButtonPress_00241000 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00241001;

			internal GameObject _0024TheButt_00241002;

			internal Menus _0024self__00241003;

			public _0024(GameObject TheButt, Menus self_)
			{
				_0024TheButt_00241002 = TheButt;
				_0024self__00241003 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024TheButt_00241002.activeInHierarchy)
					{
						goto case 1;
					}
					SelectedButton = _0024TheButt_00241002.name;
					if (!IsTutorial || _0024TheButt_00241002.name == TutorialAllow || TutorialAllow == string.Empty)
					{
						if (_0024TheButt_00241002.name == "EXIT")
						{
							_0024TheButt_00241002.transform.parent.gameObject.SetActive(false);
							for (_0024i_00241001 = _0024self__00241003.RecentlyHighlighted.Count - 1; _0024i_00241001 >= 0; _0024i_00241001--)
							{
								if (_0024self__00241003.RecentlyHighlighted[_0024i_00241001].activeInHierarchy && ((GUITexture)_0024self__00241003.RecentlyHighlighted[_0024i_00241001].GetComponent(typeof(GUITexture))).enabled)
								{
									_0024self__00241003.HighlightButton(_0024self__00241003.RecentlyHighlighted[_0024i_00241001]);
									break;
								}
							}
							if (IsTutorial && _0024TheButt_00241002.name == TutorialAllow)
							{
								TutorialState++;
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (IsTutorial && _0024TheButt_00241002.name == TutorialAllow)
						{
							TutorialState++;
						}
						_0024self__00241003.ReleasedTheButton = true;
						_0024self__00241003.ReleaseButton();
						_0024self__00241003.SendMessage("ButtonWasPressed", _0024TheButt_00241002.name);
					}
					goto IL_0218;
				case 2:
					_0024TheButt_00241002.transform.parent.gameObject.SetActive(false);
					goto IL_0218;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0218:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024TheButt_00241004;

		internal Menus _0024self__00241005;

		public _0024ButtonPress_00241000(GameObject TheButt, Menus self_)
		{
			_0024TheButt_00241004 = TheButt;
			_0024self__00241005 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024TheButt_00241004, _0024self__00241005);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ScrollInertia_00241006 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024463_00241007;

			internal Vector3 _0024_0024464_00241008;

			internal float _0024_0024465_00241009;

			internal Vector3 _0024_0024466_00241010;

			internal float _0024_0024467_00241011;

			internal Vector3 _0024_0024468_00241012;

			internal float _0024_0024469_00241013;

			internal Vector3 _0024_0024470_00241014;

			internal GameObject _0024Scroll_00241015;

			internal Menus _0024self__00241016;

			public _0024(GameObject Scroll, Menus self_)
			{
				_0024Scroll_00241015 = Scroll;
				_0024self__00241016 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (Mathf.Abs(Inertia) > 0.02f)
					{
						if (!_0024self__00241016.CurrentScrollHorizontal)
						{
							float num = (_0024_0024467_00241011 = _0024Scroll_00241015.transform.localPosition.y + Inertia * Time.deltaTime * 1f);
							Vector3 vector = (_0024_0024468_00241012 = _0024Scroll_00241015.transform.localPosition);
							float num2 = (_0024_0024468_00241012.y = _0024_0024467_00241011);
							Vector3 vector3 = (_0024Scroll_00241015.transform.localPosition = _0024_0024468_00241012);
							float num3 = (_0024_0024469_00241013 = Mathf.Clamp(_0024Scroll_00241015.transform.localPosition.y, 0f, _0024self__00241016.ActiveScrollLimit * 640f / (float)Screen.height * Settings.Scale / 2f));
							Vector3 vector4 = (_0024_0024470_00241014 = _0024Scroll_00241015.transform.localPosition);
							float num4 = (_0024_0024470_00241014.y = _0024_0024469_00241013);
							Vector3 vector6 = (_0024Scroll_00241015.transform.localPosition = _0024_0024470_00241014);
						}
						else
						{
							float num5 = (_0024_0024463_00241007 = _0024Scroll_00241015.transform.localPosition.x + Inertia * Time.deltaTime * 1f);
							Vector3 vector7 = (_0024_0024464_00241008 = _0024Scroll_00241015.transform.localPosition);
							float num6 = (_0024_0024464_00241008.x = _0024_0024463_00241007);
							Vector3 vector9 = (_0024Scroll_00241015.transform.localPosition = _0024_0024464_00241008);
							float num7 = (_0024_0024465_00241009 = Mathf.Clamp(_0024Scroll_00241015.transform.localPosition.x, _0024self__00241016.ActiveScrollLimit * 960f / (float)Screen.width * Settings.Scale / 2f, 0f));
							Vector3 vector10 = (_0024_0024466_00241010 = _0024Scroll_00241015.transform.localPosition);
							float num8 = (_0024_0024466_00241010.x = _0024_0024465_00241009);
							Vector3 vector12 = (_0024Scroll_00241015.transform.localPosition = _0024_0024466_00241010);
						}
						Inertia -= Inertia * Time.deltaTime * 4f;
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

		internal GameObject _0024Scroll_00241017;

		internal Menus _0024self__00241018;

		public _0024ScrollInertia_00241006(GameObject Scroll, Menus self_)
		{
			_0024Scroll_00241017 = Scroll;
			_0024self__00241018 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Scroll_00241017, _0024self__00241018);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CheckController_00241019 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024Horizontal_00241020;

			internal int _0024Vertical_00241021;

			internal System.Collections.Generic.List<GameObject> _0024Potentials_00241022;

			internal int _0024i_00241023;

			internal GameObject _0024PotentialButton_00241024;

			internal float _0024Extreme_00241025;

			internal float _0024OppositeExtreme_00241026;

			internal Menus _0024self__00241027;

			public _0024(Menus self_)
			{
				_0024self__00241027 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0be8
				int result;
				switch (_state)
				{
				default:
					if (Input.GetJoystickNames().Length > 0)
					{
						IsController = true;
						if (!(ControllerAxis(5) >= 0.1f))
						{
							_0024self__00241027.TriggerLeftReleased = true;
						}
						if (!(ControllerAxis(4) >= 0.1f))
						{
							_0024self__00241027.TriggerRightReleased = true;
						}
						if (!IsVR)
						{
							if ((!(Mathf.Abs(ControllerAxis(1)) <= 0.5f) && !_0024self__00241027.ShiftedY) || (!(Mathf.Abs(ControllerAxis(0)) <= 0.5f) && !_0024self__00241027.ShiftedX))
							{
								_0024Horizontal_00241020 = 0;
								_0024Vertical_00241021 = 0;
								if (!(ControllerAxis(1) <= 0.5f))
								{
									_0024Vertical_00241021 = -1;
								}
								else if (!(ControllerAxis(1) >= -0.5f))
								{
									_0024Vertical_00241021 = 1;
								}
								if (!(ControllerAxis(0) <= 0.5f))
								{
									_0024Horizontal_00241020 = 1;
								}
								else if (!(ControllerAxis(0) >= -0.5f))
								{
									_0024Horizontal_00241020 = -1;
								}
								if (_0024Vertical_00241021 != 0)
								{
									_0024self__00241027.ShiftedY = true;
								}
								if (_0024Horizontal_00241020 != 0)
								{
									_0024self__00241027.ShiftedX = true;
								}
								if (_0024self__00241027.ChosenButton == null)
								{
									if (_0024Vertical_00241021 == -1)
									{
										_0024self__00241027.CurrentY = 999999f;
									}
									else if (_0024Vertical_00241021 == 1)
									{
										_0024self__00241027.CurrentY = -999999f;
									}
									if (_0024Horizontal_00241020 == -1)
									{
										_0024self__00241027.CurrentX = 999999f;
									}
									else if (_0024Horizontal_00241020 == 1)
									{
										_0024self__00241027.CurrentX = -999999f;
									}
								}
								if (_0024Vertical_00241021 == -1 || _0024Vertical_00241021 == 1)
								{
									_0024Potentials_00241022 = new System.Collections.Generic.List<GameObject>();
									for (_0024i_00241023 = default(int); _0024i_00241023 < Extensions.get_length((System.Array)_0024self__00241027.Buttons); _0024i_00241023++)
									{
										if (_0024self__00241027.Buttons[_0024i_00241023].activeInHierarchy && ((GUITexture)_0024self__00241027.Buttons[_0024i_00241023].GetComponent(typeof(GUITexture))).enabled && _0024self__00241027.Buttons[_0024i_00241023] != _0024self__00241027.ChosenButton && ((_0024Vertical_00241021 == -1 && ((GUITexture)_0024self__00241027.Buttons[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y < _0024self__00241027.CurrentY) || (_0024Vertical_00241021 == 1 && !(((GUITexture)_0024self__00241027.Buttons[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y <= _0024self__00241027.CurrentY))))
										{
											_0024Potentials_00241022.Add(_0024self__00241027.Buttons[_0024i_00241023]);
										}
									}
									_0024PotentialButton_00241024 = null;
									if (_0024Vertical_00241021 == -1)
									{
										_0024Extreme_00241025 = -99999f;
									}
									else
									{
										_0024Extreme_00241025 = 99999f;
									}
									_0024OppositeExtreme_00241026 = 99999f;
									if (_0024self__00241027.ChosenButton != null)
									{
										for (_0024i_00241023 = 0; _0024i_00241023 < _0024Potentials_00241022.Count; _0024i_00241023++)
										{
											if (!(Mathf.Abs(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x - ((GUITexture)_0024self__00241027.ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.x) >= _0024OppositeExtreme_00241026))
											{
												_0024OppositeExtreme_00241026 = Mathf.Abs(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x - ((GUITexture)_0024self__00241027.ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.x);
											}
										}
									}
									for (_0024i_00241023 = 0; _0024i_00241023 < _0024Potentials_00241022.Count; _0024i_00241023++)
									{
										if ((_0024self__00241027.ChosenButton == null || !(Mathf.Abs(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x - ((GUITexture)_0024self__00241027.ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.x) >= _0024OppositeExtreme_00241026 + 5f * Settings.Scale)) && ((_0024Vertical_00241021 == -1 && ((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y > _0024Extreme_00241025) || (_0024Vertical_00241021 == 1 && !(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y >= _0024Extreme_00241025))))
										{
											_0024Extreme_00241025 = ((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y;
											_0024PotentialButton_00241024 = _0024Potentials_00241022[_0024i_00241023];
										}
									}
									if (_0024PotentialButton_00241024 != null)
									{
										_0024self__00241027.HighlightButton(_0024PotentialButton_00241024);
									}
								}
								if (_0024Horizontal_00241020 == -1 || _0024Horizontal_00241020 == 1)
								{
									_0024Potentials_00241022 = new System.Collections.Generic.List<GameObject>();
									for (_0024i_00241023 = 0; _0024i_00241023 < Extensions.get_length((System.Array)_0024self__00241027.Buttons); _0024i_00241023++)
									{
										if (_0024self__00241027.Buttons[_0024i_00241023].activeInHierarchy && ((GUITexture)_0024self__00241027.Buttons[_0024i_00241023].GetComponent(typeof(GUITexture))).enabled && _0024self__00241027.Buttons[_0024i_00241023] != _0024self__00241027.ChosenButton && ((_0024Horizontal_00241020 == -1 && ((GUITexture)_0024self__00241027.Buttons[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x < _0024self__00241027.CurrentX) || (_0024Horizontal_00241020 == 1 && !(((GUITexture)_0024self__00241027.Buttons[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x <= _0024self__00241027.CurrentX))))
										{
											_0024Potentials_00241022.Add(_0024self__00241027.Buttons[_0024i_00241023]);
										}
									}
									_0024PotentialButton_00241024 = null;
									if (_0024Horizontal_00241020 == -1)
									{
										_0024Extreme_00241025 = -99999f;
									}
									else
									{
										_0024Extreme_00241025 = 99999f;
									}
									_0024OppositeExtreme_00241026 = 99999f;
									if (_0024self__00241027.ChosenButton != null)
									{
										for (_0024i_00241023 = 0; _0024i_00241023 < _0024Potentials_00241022.Count; _0024i_00241023++)
										{
											if (!(Mathf.Abs(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y - ((GUITexture)_0024self__00241027.ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.y) >= _0024OppositeExtreme_00241026))
											{
												_0024OppositeExtreme_00241026 = Mathf.Abs(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y - ((GUITexture)_0024self__00241027.ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.y);
											}
										}
									}
									for (_0024i_00241023 = 0; _0024i_00241023 < _0024Potentials_00241022.Count; _0024i_00241023++)
									{
										if ((_0024self__00241027.ChosenButton == null || !(Mathf.Abs(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.y - ((GUITexture)_0024self__00241027.ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.y) >= _0024OppositeExtreme_00241026 + 5f * Settings.Scale)) && ((_0024Horizontal_00241020 == -1 && ((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x > _0024Extreme_00241025) || (_0024Horizontal_00241020 == 1 && !(((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x >= _0024Extreme_00241025))))
										{
											_0024Extreme_00241025 = ((GUITexture)_0024Potentials_00241022[_0024i_00241023].GetComponent(typeof(GUITexture))).pixelInset.x;
											_0024PotentialButton_00241024 = _0024Potentials_00241022[_0024i_00241023];
										}
									}
									if (_0024PotentialButton_00241024 != null)
									{
										_0024self__00241027.HighlightButton(_0024PotentialButton_00241024);
									}
									_0024self__00241027.HighlightButton(_0024self__00241027.ControllerHighestButton());
								}
							}
							if (_0024self__00241027.ShiftedY && !(Mathf.Abs(ControllerAxis(1)) >= 0.4f))
							{
								_0024self__00241027.ShiftedY = false;
							}
							if (_0024self__00241027.ShiftedX && !(Mathf.Abs(ControllerAxis(0)) >= 0.4f))
							{
								_0024self__00241027.ShiftedX = false;
							}
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					IsController = false;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241028;

		public _0024CheckController_00241019(Menus self_)
		{
			_0024self__00241028 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241028);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InitializeMenus_00241029 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Material _0024Mat_00241030;

			internal Texture2D _0024OriginalTexture_00241031;

			internal Texture2D _0024NewTexture_00241032;

			internal int _0024l_00241033;

			internal UnityScript.Lang.Array _0024AllData_00241034;

			internal int _0024j_00241035;

			internal int _0024m_00241036;

			internal int _0024k_00241037;

			internal int _0024n_00241038;

			internal GUIText[] _0024GUITextOriginals_00241039;

			internal Vector3[] _0024GUITextOriginalPositions_00241040;

			internal Vector2[] _0024GUITextOriginalOffsets_00241041;

			internal bool[] _0024GUITextOriginalEnableds_00241042;

			internal bool[] _0024GUITextOriginalActives_00241043;

			internal Transform[] _0024GUITextOriginalParents_00241044;

			internal int _0024v_00241045;

			internal int _0024_0024265_00241046;

			internal Material[] _0024_0024266_00241047;

			internal int _0024_0024267_00241048;

			internal Menus _0024self__00241049;

			public _0024(Menus self_)
			{
				_0024self__00241049 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Loc.LoadResource();
					ScreenSafeArea = SafeArea.GetSafeArea();
					_0024_0024265_00241046 = 0;
					_0024_0024266_00241047 = _0024self__00241049.LocalizedMaterials;
					for (_0024_0024267_00241048 = _0024_0024266_00241047.Length; _0024_0024265_00241046 < _0024_0024267_00241048; _0024_0024265_00241046++)
					{
						_0024OriginalTexture_00241031 = (Texture2D)_0024_0024266_00241047[_0024_0024265_00241046].mainTexture;
						_0024NewTexture_00241032 = (Texture2D)Resources.Load("Localization/" + Settings.Language + "/" + _0024OriginalTexture_00241031.name);
						if (_0024NewTexture_00241032 != null)
						{
							_0024_0024266_00241047[_0024_0024265_00241046].mainTexture = _0024NewTexture_00241032;
						}
						else
						{
							_0024_0024266_00241047[_0024_0024265_00241046].mainTexture = _0024OriginalTexture_00241031;
						}
					}
					_0024self__00241049.MenusArray = new UnityScript.Lang.Array();
					if (NewUI == null)
					{
						_0024self__00241049.ParentsArray = new UnityScript.Lang.Array();
						_0024self__00241049.ChildrenArray = new UnityScript.Lang.Array();
						_0024self__00241049.ButtonsArray = new UnityScript.Lang.Array();
						_0024self__00241049.ButtonsTouchZonesArray = new UnityScript.Lang.Array();
						_0024self__00241049.ScrollsArray = new UnityScript.Lang.Array();
						_0024self__00241049.ScrollsDirectionArray = new UnityScript.Lang.Array();
						_0024self__00241049.ScrollsLimitArray = new UnityScript.Lang.Array();
						_0024self__00241049.GUITextsArray = new UnityScript.Lang.Array();
						_0024self__00241049.GUITexturesArray = new UnityScript.Lang.Array();
						_0024self__00241049.OriginalTexturePositions = new UnityScript.Lang.Array();
						_0024self__00241049.OriginalTextPositions = new UnityScript.Lang.Array();
						_0024self__00241049.OriginalTextSizes = new UnityScript.Lang.Array();
						if ((Camera)_0024self__00241049.GetComponent(typeof(Camera)) != null && (GUILayer)((Camera)_0024self__00241049.GetComponent(typeof(Camera))).GetComponent(typeof(GUILayer)) != null && ((GUILayer)((Camera)_0024self__00241049.GetComponent(typeof(Camera))).GetComponent(typeof(GUILayer))).enabled)
						{
							Debug.LogError("Camera has enabled GUILayer which conflicts with autogenerated GUI Camera in Menu.js");
						}
						_0024self__00241049.SetupVR();
						if (IsVR)
						{
							if (Settings.Scale == 1f)
							{
								Settings.Suffix = string.Empty;
							}
							else if (Settings.Scale == 2f)
							{
								Settings.Suffix = string.Empty;
							}
							else
							{
								Settings.Suffix = "@2x";
							}
						}
						_0024self__00241049.DarkTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
						_0024self__00241049.DarkTexture.SetPixel(0, 0, Color.black);
						_0024self__00241049.DarkTexture.Apply();
						_0024self__00241049.TraverseMenuHierarchy(_0024self__00241049.GUI.transform);
					}
					else
					{
						MainCanvas = (Canvas)NewUI.GetComponent(typeof(Canvas));
						MainCanvasRect = (RectTransform)MainCanvas.GetComponent(typeof(RectTransform));
						_0024self__00241049.TraverseMenuHierarchy(NewUI.transform);
					}
					_0024self__00241049.m_Menus = new GameObject[_0024self__00241049.MenusArray.length];
					_0024self__00241049.OriginalState = new bool[_0024self__00241049.MenusArray.length];
					_0024self__00241049.OriginalMenuNames = new string[_0024self__00241049.MenusArray.length];
					for (_0024l_00241033 = default(int); _0024l_00241033 < _0024self__00241049.MenusArray.length; _0024l_00241033++)
					{
						GameObject[] menus = _0024self__00241049.m_Menus;
						int num = _0024l_00241033;
						object obj = _0024self__00241049.MenusArray[_0024l_00241033];
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						menus[num] = (GameObject)obj;
						_0024AllData_00241034 = _0024self__00241049.m_Menus[_0024l_00241033].name.Split(" "[0]);
						_0024self__00241049.OriginalMenuNames[_0024l_00241033] = _0024self__00241049.m_Menus[_0024l_00241033].name;
						GameObject obj2 = _0024self__00241049.m_Menus[_0024l_00241033];
						object obj3 = _0024AllData_00241034[0];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						obj2.name = (string)obj3;
						_0024self__00241049.OriginalState[_0024l_00241033] = _0024self__00241049.m_Menus[_0024l_00241033].activeSelf;
					}
					if (NewUI == null)
					{
						_0024self__00241049.Parents = new GameObject[_0024self__00241049.ParentsArray.length];
						for (_0024j_00241035 = default(int); _0024j_00241035 < _0024self__00241049.ParentsArray.length; _0024j_00241035++)
						{
							GameObject[] parents = _0024self__00241049.Parents;
							int num2 = _0024j_00241035;
							object obj4 = _0024self__00241049.ParentsArray[_0024j_00241035];
							if (!(obj4 is GameObject))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(GameObject));
							}
							parents[num2] = (GameObject)obj4;
						}
						_0024self__00241049.Children = new GameObject[_0024self__00241049.ChildrenArray.length];
						for (_0024m_00241036 = default(int); _0024m_00241036 < _0024self__00241049.ChildrenArray.length; _0024m_00241036++)
						{
							GameObject[] children = _0024self__00241049.Children;
							int num3 = _0024m_00241036;
							object obj5 = _0024self__00241049.ChildrenArray[_0024m_00241036];
							if (!(obj5 is GameObject))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(GameObject));
							}
							children[num3] = (GameObject)obj5;
						}
						_0024self__00241049.Buttons = new GameObject[_0024self__00241049.ButtonsArray.length];
						_0024self__00241049.ButtonsTouchZones = new Vector2[_0024self__00241049.ButtonsArray.length];
						for (_0024k_00241037 = default(int); _0024k_00241037 < _0024self__00241049.ButtonsArray.length; _0024k_00241037++)
						{
							GameObject[] buttons = _0024self__00241049.Buttons;
							int num4 = _0024k_00241037;
							object obj6 = _0024self__00241049.ButtonsArray[_0024k_00241037];
							if (!(obj6 is GameObject))
							{
								obj6 = RuntimeServices.Coerce(obj6, typeof(GameObject));
							}
							buttons[num4] = (GameObject)obj6;
							_0024self__00241049.ButtonsTouchZones[_0024k_00241037] = (Vector2)_0024self__00241049.ButtonsTouchZonesArray[_0024k_00241037];
						}
						_0024self__00241049.Scrolls = new GameObject[_0024self__00241049.ScrollsArray.length];
						_0024self__00241049.ScrollsDirection = new bool[_0024self__00241049.ScrollsArray.length];
						for (_0024n_00241038 = default(int); _0024n_00241038 < _0024self__00241049.ScrollsArray.length; _0024n_00241038++)
						{
							GameObject[] scrolls = _0024self__00241049.Scrolls;
							int num5 = _0024n_00241038;
							object obj7 = _0024self__00241049.ScrollsArray[_0024n_00241038];
							if (!(obj7 is GameObject))
							{
								obj7 = RuntimeServices.Coerce(obj7, typeof(GameObject));
							}
							scrolls[num5] = (GameObject)obj7;
							_0024self__00241049.ScrollsDirection[_0024n_00241038] = RuntimeServices.UnboxBoolean(_0024self__00241049.ScrollsDirectionArray[_0024n_00241038]);
						}
						_0024self__00241049.VRSetupMenus();
						_0024self__00241049.FirstMenuInitialization = false;
						_0024GUITextOriginals_00241039 = new GUIText[_0024self__00241049.GUITextsArray.length];
						_0024GUITextOriginalPositions_00241040 = new Vector3[_0024self__00241049.GUITextsArray.length];
						_0024GUITextOriginalOffsets_00241041 = new Vector2[_0024self__00241049.GUITextsArray.length];
						_0024GUITextOriginalEnableds_00241042 = new bool[_0024self__00241049.GUITextsArray.length];
						_0024GUITextOriginalActives_00241043 = new bool[_0024self__00241049.GUITextsArray.length];
						_0024GUITextOriginalParents_00241044 = new Transform[_0024self__00241049.GUITextsArray.length];
						for (_0024v_00241045 = default(int); _0024v_00241045 < _0024self__00241049.GUITextsArray.length; _0024v_00241045++)
						{
							GUIText[] array = _0024GUITextOriginals_00241039;
							int num6 = _0024v_00241045;
							object obj8 = _0024self__00241049.GUITextsArray[_0024v_00241045];
							if (!(obj8 is GUIText))
							{
								obj8 = RuntimeServices.Coerce(obj8, typeof(GUIText));
							}
							array[num6] = (GUIText)obj8;
							_0024GUITextOriginalOffsets_00241041[_0024v_00241045] = ((GUIText)_0024GUITextOriginals_00241039[_0024v_00241045].GetComponent(typeof(GUIText))).pixelOffset;
							_0024GUITextOriginalEnableds_00241042[_0024v_00241045] = ((GUIText)_0024GUITextOriginals_00241039[_0024v_00241045].GetComponent(typeof(GUIText))).enabled;
							_0024GUITextOriginalActives_00241043[_0024v_00241045] = _0024GUITextOriginals_00241039[_0024v_00241045].gameObject.activeSelf;
							_0024GUITextOriginalParents_00241044[_0024v_00241045] = _0024GUITextOriginals_00241039[_0024v_00241045].transform.parent;
							_0024GUITextOriginalPositions_00241040[_0024v_00241045] = _0024GUITextOriginals_00241039[_0024v_00241045].transform.position;
							((GUIText)_0024GUITextOriginals_00241039[_0024v_00241045].GetComponent(typeof(GUIText))).pixelOffset = Vector2.zero;
							((GUIText)_0024GUITextOriginals_00241039[_0024v_00241045].GetComponent(typeof(GUIText))).enabled = true;
							_0024GUITextOriginals_00241039[_0024v_00241045].gameObject.SetActive(true);
							_0024GUITextOriginals_00241039[_0024v_00241045].transform.parent = null;
							_0024GUITextOriginals_00241039[_0024v_00241045].transform.position = Vector3.zero;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0c8e;
				case 2:
					for (_0024v_00241045 = 0; _0024v_00241045 < _0024self__00241049.GUITextsArray.length; _0024v_00241045++)
					{
						((GUIText)_0024GUITextOriginals_00241039[_0024v_00241045].GetComponent(typeof(GUIText))).pixelOffset = _0024GUITextOriginalOffsets_00241041[_0024v_00241045];
						((GUIText)_0024GUITextOriginals_00241039[_0024v_00241045].GetComponent(typeof(GUIText))).enabled = _0024GUITextOriginalEnableds_00241042[_0024v_00241045];
						_0024GUITextOriginals_00241039[_0024v_00241045].gameObject.SetActive(_0024GUITextOriginalActives_00241043[_0024v_00241045]);
						_0024GUITextOriginals_00241039[_0024v_00241045].transform.parent = _0024GUITextOriginalParents_00241044[_0024v_00241045];
						_0024GUITextOriginals_00241039[_0024v_00241045].transform.position = _0024GUITextOriginalPositions_00241040[_0024v_00241045];
					}
					goto IL_0c8e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0c8e:
					ToggleMusic(Saver.GetBoolean("MuteMusic"));
					ToggleSounds(Saver.GetBoolean("MuteSounds"));
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241050;

		public _0024InitializeMenus_00241029(Menus self_)
		{
			_0024self__00241050 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241050);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DetectResolutionChanges_00241051 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Menus _0024self__00241052;

			public _0024(Menus self_)
			{
				_0024self__00241052 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_00bd
				int result;
				switch (_state)
				{
				default:
					if (NewUI != null)
					{
						goto case 1;
					}
					_0024self__00241052.LastScreenWidth = Screen.width;
					_0024self__00241052.LastScreenHeight = Screen.height;
					goto case 2;
				case 2:
					if (Screen.width != _0024self__00241052.LastScreenWidth || Screen.height != _0024self__00241052.LastScreenHeight)
					{
						_0024self__00241052.SendMessage("ResolutionChanged", SendMessageOptions.DontRequireReceiver);
					}
					_0024self__00241052.LastScreenWidth = Screen.width;
					_0024self__00241052.LastScreenHeight = Screen.height;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241053;

		public _0024DetectResolutionChanges_00241051(Menus self_)
		{
			_0024self__00241053 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241053);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CycleWheel_00241054 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_00241055;

			internal float _0024ColValue_00241056;

			internal Menus _0024self__00241057;

			public _0024(Menus self_)
			{
				_0024self__00241057 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					LoadingMenu.SetActive(true);
					if (NewUI != null && LoadingAnimation != null)
					{
						LoadingAnimation.Play();
					}
					_0024Counter_00241055 = default(float);
					goto case 2;
				case 2:
					if (LoadingMenu.activeInHierarchy)
					{
						_0024Counter_00241055 += Time.deltaTime * 4f;
						_0024ColValue_00241056 = 0.5f + Mathf.Sin(_0024Counter_00241055) * 0.25f;
						if (NewUI != null)
						{
							LoadingTextUI.color = new Color(_0024ColValue_00241056, _0024ColValue_00241056, _0024ColValue_00241056, 1f);
							LoadingMatchTextUI.color = LoadingTextUI.color;
						}
						else
						{
							_0024self__00241057.LoadingWheel.color = new Color(_0024ColValue_00241056, _0024ColValue_00241056, _0024ColValue_00241056, 0.5f);
							LoadingText.material.color = new Color(_0024ColValue_00241056 + 0.3f, _0024ColValue_00241056 + 0.3f, _0024ColValue_00241056 + 0.3f, 0.75f);
							LoadingMatchText.material.color = LoadingText.material.color;
						}
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

		internal Menus _0024self__00241058;

		public _0024CycleWheel_00241054(Menus self_)
		{
			_0024self__00241058 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241058);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PopupExitDelaySingle_00241059 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024Delay_00241060;

			internal Menus _0024self__00241061;

			public _0024(float Delay, Menus self_)
			{
				_0024Delay_00241060 = Delay;
				_0024self__00241061 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241061.PopupExitButton.interactable = false;
					result = (Yield(2, new WaitForSeconds(_0024Delay_00241060)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241061.PopupExitButton.interactable = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024Delay_00241062;

		internal Menus _0024self__00241063;

		public _0024PopupExitDelaySingle_00241059(float Delay, Menus self_)
		{
			_0024Delay_00241062 = Delay;
			_0024self__00241063 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024Delay_00241062, _0024self__00241063);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PopupExitDelayMulti_00241064 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024Delay_00241065;

			internal Menus _0024self__00241066;

			public _0024(float Delay, Menus self_)
			{
				_0024Delay_00241065 = Delay;
				_0024self__00241066 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241066.PopupButton1.interactable = false;
					_0024self__00241066.PopupButton2.interactable = false;
					result = (Yield(2, new WaitForSeconds(_0024Delay_00241065)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241066.PopupButton1.interactable = true;
					_0024self__00241066.PopupButton2.interactable = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024Delay_00241067;

		internal Menus _0024self__00241068;

		public _0024PopupExitDelayMulti_00241064(float Delay, Menus self_)
		{
			_0024Delay_00241067 = Delay;
			_0024self__00241068 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024Delay_00241067, _0024self__00241068);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Fade_00241069 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024TargetAlpha_00241070;

			internal Menus _0024self__00241071;

			public _0024(float TargetAlpha, Menus self_)
			{
				_0024TargetAlpha_00241070 = TargetAlpha;
				_0024self__00241071 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (NewUI != null)
					{
						_0024self__00241071.FadeImage.color = new Color(0f, 0f, 0f, _0024self__00241071.FadeImage.color.a);
					}
					else
					{
						_0024self__00241071.FadeTexture.texture = _0024self__00241071.DarkTexture;
					}
					_0024self__00241071.FadeSpeed = 0.4f;
					_0024self__00241071.StopCoroutine("FadeInOut");
					result = (Yield(2, _0024self__00241071.StartCoroutine("FadeInOut", _0024TargetAlpha_00241070)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024TargetAlpha_00241072;

		internal Menus _0024self__00241073;

		public _0024Fade_00241069(float TargetAlpha, Menus self_)
		{
			_0024TargetAlpha_00241072 = TargetAlpha;
			_0024self__00241073 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241072, _0024self__00241073);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Fade_00241074 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024TargetAlpha_00241075;

			internal float _0024Speed_00241076;

			internal Menus _0024self__00241077;

			public _0024(float TargetAlpha, float Speed, Menus self_)
			{
				_0024TargetAlpha_00241075 = TargetAlpha;
				_0024Speed_00241076 = Speed;
				_0024self__00241077 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (NewUI != null)
					{
						_0024self__00241077.FadeImage.color = new Color(0f, 0f, 0f, _0024self__00241077.FadeImage.color.a);
					}
					else
					{
						_0024self__00241077.FadeTexture.texture = _0024self__00241077.DarkTexture;
					}
					_0024self__00241077.FadeSpeed = _0024Speed_00241076;
					_0024self__00241077.StopCoroutine("FadeInOut");
					result = (Yield(2, _0024self__00241077.StartCoroutine("FadeInOut", _0024TargetAlpha_00241075)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024TargetAlpha_00241078;

		internal float _0024Speed_00241079;

		internal Menus _0024self__00241080;

		public _0024Fade_00241074(float TargetAlpha, float Speed, Menus self_)
		{
			_0024TargetAlpha_00241078 = TargetAlpha;
			_0024Speed_00241079 = Speed;
			_0024self__00241080 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241078, _0024Speed_00241079, _0024self__00241080);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeLight_00241081 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024TargetAlpha_00241082;

			internal Menus _0024self__00241083;

			public _0024(float TargetAlpha, Menus self_)
			{
				_0024TargetAlpha_00241082 = TargetAlpha;
				_0024self__00241083 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (NewUI != null)
					{
						_0024self__00241083.FadeImage.color = new Color(1f, 1f, 1f, _0024self__00241083.FadeImage.color.a);
					}
					else
					{
						_0024self__00241083.FadeTexture.texture = _0024self__00241083.LightTexture;
					}
					_0024self__00241083.FadeSpeed = 0.4f;
					_0024self__00241083.StopCoroutine("FadeInOut");
					result = (Yield(2, _0024self__00241083.StartCoroutine("FadeInOut", _0024TargetAlpha_00241082)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024TargetAlpha_00241084;

		internal Menus _0024self__00241085;

		public _0024FadeLight_00241081(float TargetAlpha, Menus self_)
		{
			_0024TargetAlpha_00241084 = TargetAlpha;
			_0024self__00241085 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241084, _0024self__00241085);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeLight_00241086 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024TargetAlpha_00241087;

			internal float _0024Speed_00241088;

			internal Menus _0024self__00241089;

			public _0024(float TargetAlpha, float Speed, Menus self_)
			{
				_0024TargetAlpha_00241087 = TargetAlpha;
				_0024Speed_00241088 = Speed;
				_0024self__00241089 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (NewUI != null)
					{
						_0024self__00241089.FadeImage.color = new Color(1f, 1f, 1f, _0024self__00241089.FadeImage.color.a);
					}
					else
					{
						_0024self__00241089.FadeTexture.texture = _0024self__00241089.LightTexture;
					}
					_0024self__00241089.FadeSpeed = _0024Speed_00241088;
					_0024self__00241089.StopCoroutine("FadeInOut");
					result = (Yield(2, _0024self__00241089.StartCoroutine("FadeInOut", _0024TargetAlpha_00241087)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024TargetAlpha_00241090;

		internal float _0024Speed_00241091;

		internal Menus _0024self__00241092;

		public _0024FadeLight_00241086(float TargetAlpha, float Speed, Menus self_)
		{
			_0024TargetAlpha_00241090 = TargetAlpha;
			_0024Speed_00241091 = Speed;
			_0024self__00241092 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241090, _0024Speed_00241091, _0024self__00241092);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeColor_00241093 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024TargetAlpha_00241094;

			internal Color _0024Col_00241095;

			internal Menus _0024self__00241096;

			public _0024(float TargetAlpha, Color Col, Menus self_)
			{
				_0024TargetAlpha_00241094 = TargetAlpha;
				_0024Col_00241095 = Col;
				_0024self__00241096 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241096.FadeImage.color = new Color(_0024Col_00241095.r, _0024Col_00241095.g, _0024Col_00241095.b, _0024self__00241096.FadeImage.color.a);
					_0024self__00241096.FadeSpeed = 0.4f;
					_0024self__00241096.StopCoroutine("FadeInOut");
					result = (Yield(2, _0024self__00241096.StartCoroutine("FadeInOut", _0024TargetAlpha_00241094)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024TargetAlpha_00241097;

		internal Color _0024Col_00241098;

		internal Menus _0024self__00241099;

		public _0024FadeColor_00241093(float TargetAlpha, Color Col, Menus self_)
		{
			_0024TargetAlpha_00241097 = TargetAlpha;
			_0024Col_00241098 = Col;
			_0024self__00241099 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241097, _0024Col_00241098, _0024self__00241099);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeColor_00241100 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024TargetAlpha_00241101;

			internal Color _0024Col_00241102;

			internal float _0024Speed_00241103;

			internal Menus _0024self__00241104;

			public _0024(float TargetAlpha, Color Col, float Speed, Menus self_)
			{
				_0024TargetAlpha_00241101 = TargetAlpha;
				_0024Col_00241102 = Col;
				_0024Speed_00241103 = Speed;
				_0024self__00241104 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241104.FadeImage.color = new Color(_0024Col_00241102.r, _0024Col_00241102.g, _0024Col_00241102.b, _0024self__00241104.FadeImage.color.a);
					_0024self__00241104.FadeSpeed = _0024Speed_00241103;
					_0024self__00241104.StopCoroutine("FadeInOut");
					result = (Yield(2, _0024self__00241104.StartCoroutine("FadeInOut", _0024TargetAlpha_00241101)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024TargetAlpha_00241105;

		internal Color _0024Col_00241106;

		internal float _0024Speed_00241107;

		internal Menus _0024self__00241108;

		public _0024FadeColor_00241100(float TargetAlpha, Color Col, float Speed, Menus self_)
		{
			_0024TargetAlpha_00241105 = TargetAlpha;
			_0024Col_00241106 = Col;
			_0024Speed_00241107 = Speed;
			_0024self__00241108 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241105, _0024Col_00241106, _0024Speed_00241107, _0024self__00241108);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeInOut_00241109 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024CurrentAlpha_00241110;

			internal float _0024_0024519_00241111;

			internal Color _0024_0024520_00241112;

			internal float _0024_0024521_00241113;

			internal Color _0024_0024522_00241114;

			internal float _0024_0024523_00241115;

			internal Color _0024_0024524_00241116;

			internal float _0024_0024525_00241117;

			internal Color _0024_0024526_00241118;

			internal float _0024TargetAlpha_00241119;

			internal Menus _0024self__00241120;

			public _0024(float TargetAlpha, Menus self_)
			{
				_0024TargetAlpha_00241119 = TargetAlpha;
				_0024self__00241120 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (IsVR)
					{
						((Renderer)_0024self__00241120.VRFade.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = _0024self__00241120.FadeTexture.texture;
					}
					if (NewUI != null)
					{
						if (_0024self__00241120.FirstFade)
						{
							_0024self__00241120.FadeCanvasGroup.blocksRaycasts = false;
						}
						else
						{
							_0024self__00241120.FadeCanvasGroup.blocksRaycasts = true;
						}
						_0024TargetAlpha_00241119 *= 2f;
						_0024self__00241120.FadeSpeed *= 2f;
						_0024CurrentAlpha_00241110 = _0024self__00241120.FadeImage.color.a;
						_0024self__00241120.FadeImage.enabled = true;
					}
					else
					{
						_0024CurrentAlpha_00241110 = _0024self__00241120.FadeTexture.color.a;
						_0024self__00241120.FadeTexture.enabled = true;
					}
					if (!(_0024TargetAlpha_00241119 <= _0024CurrentAlpha_00241110))
					{
						_0024self__00241120.IsFadingOut = true;
						if ((bool)_0024self__00241120.FadeCanvasGroup)
						{
							_0024self__00241120.FadeCanvasGroup.blocksRaycasts = true;
						}
					}
					goto case 2;
				case 2:
					if (_0024CurrentAlpha_00241110 > _0024TargetAlpha_00241119)
					{
						_0024CurrentAlpha_00241110 -= _0024self__00241120.FadeSpeed * Time.deltaTime;
						if (!(NewUI != null))
						{
							float num = (_0024_0024521_00241113 = Mathf.Clamp(_0024CurrentAlpha_00241110, 0f, 0.5f));
							Color color = (_0024_0024522_00241114 = _0024self__00241120.FadeTexture.color);
							float num2 = (_0024_0024522_00241114.a = _0024_0024521_00241113);
							Color color3 = (_0024self__00241120.FadeTexture.color = _0024_0024522_00241114);
						}
						else
						{
							float num3 = (_0024_0024519_00241111 = Mathf.Clamp(_0024CurrentAlpha_00241110, 0f, 1f));
							Color color4 = (_0024_0024520_00241112 = _0024self__00241120.FadeImage.color);
							float num4 = (_0024_0024520_00241112.a = _0024_0024519_00241111);
							Color color6 = (_0024self__00241120.FadeImage.color = _0024_0024520_00241112);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (_0024CurrentAlpha_00241110 < _0024TargetAlpha_00241119)
					{
						_0024CurrentAlpha_00241110 += _0024self__00241120.FadeSpeed * Time.deltaTime;
						if (!(NewUI != null))
						{
							float num5 = (_0024_0024525_00241117 = Mathf.Clamp(_0024CurrentAlpha_00241110, 0f, 0.5f));
							Color color7 = (_0024_0024526_00241118 = _0024self__00241120.FadeTexture.color);
							float num6 = (_0024_0024526_00241118.a = _0024_0024525_00241117);
							Color color9 = (_0024self__00241120.FadeTexture.color = _0024_0024526_00241118);
						}
						else
						{
							float num7 = (_0024_0024523_00241115 = Mathf.Clamp(_0024CurrentAlpha_00241110, 0f, 1f));
							Color color10 = (_0024_0024524_00241116 = _0024self__00241120.FadeImage.color);
							float num8 = (_0024_0024524_00241116.a = _0024_0024523_00241115);
							Color color12 = (_0024self__00241120.FadeImage.color = _0024_0024524_00241116);
						}
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024TargetAlpha_00241119 == 0f)
					{
						if (NewUI != null)
						{
							_0024self__00241120.FadeImage.enabled = false;
						}
						else
						{
							_0024self__00241120.FadeTexture.enabled = false;
						}
					}
					_0024self__00241120.IsFadingOut = false;
					if ((bool)_0024self__00241120.FadeCanvasGroup)
					{
						_0024self__00241120.FadeCanvasGroup.blocksRaycasts = false;
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

		internal float _0024TargetAlpha_00241121;

		internal Menus _0024self__00241122;

		public _0024FadeInOut_00241109(float TargetAlpha, Menus self_)
		{
			_0024TargetAlpha_00241121 = TargetAlpha;
			_0024self__00241122 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024TargetAlpha_00241121, _0024self__00241122);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeAudio_00241123 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024SourceVolume_00241124;

			internal AudioSource _0024TheSource_00241125;

			internal float _0024TargetVolume_00241126;

			internal float _0024TheSpeed_00241127;

			internal bool _0024DestroyAfterFadeout_00241128;

			public _0024(AudioSource TheSource, float TargetVolume, float TheSpeed, bool DestroyAfterFadeout)
			{
				_0024TheSource_00241125 = TheSource;
				_0024TargetVolume_00241126 = TargetVolume;
				_0024TheSpeed_00241127 = TheSpeed;
				_0024DestroyAfterFadeout_00241128 = DestroyAfterFadeout;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024TargetVolume_00241126 != 0f)
					{
						_0024TheSource_00241125.Play();
					}
					_0024SourceVolume_00241124 = _0024TheSource_00241125.volume;
					if (!(_0024SourceVolume_00241124 >= _0024TargetVolume_00241126))
					{
						goto case 2;
					}
					goto case 3;
				case 2:
					if (_0024SourceVolume_00241124 < _0024TargetVolume_00241126)
					{
						if (!_0024TheSource_00241125)
						{
							goto case 1;
						}
						_0024SourceVolume_00241124 += Time.deltaTime * _0024TheSpeed_00241127;
						_0024TheSource_00241125.volume = _0024SourceVolume_00241124;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_011c;
				case 3:
					if (!(_0024SourceVolume_00241124 > _0024TargetVolume_00241126))
					{
						goto IL_011c;
					}
					if (!_0024TheSource_00241125)
					{
						goto case 1;
					}
					_0024SourceVolume_00241124 -= Time.deltaTime * _0024TheSpeed_00241127;
					_0024TheSource_00241125.volume = _0024SourceVolume_00241124;
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 1:
					{
						result = 0;
						break;
					}
					IL_011c:
					if ((bool)_0024TheSource_00241125)
					{
						_0024TheSource_00241125.volume = _0024TargetVolume_00241126;
						if (_0024TargetVolume_00241126 == 0f)
						{
							_0024TheSource_00241125.Stop();
							if (_0024DestroyAfterFadeout_00241128)
							{
								UnityEngine.Object.Destroy(_0024TheSource_00241125);
							}
						}
						YieldDefault(1);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AudioSource _0024TheSource_00241129;

		internal float _0024TargetVolume_00241130;

		internal float _0024TheSpeed_00241131;

		internal bool _0024DestroyAfterFadeout_00241132;

		public _0024FadeAudio_00241123(AudioSource TheSource, float TargetVolume, float TheSpeed, bool DestroyAfterFadeout)
		{
			_0024TheSource_00241129 = TheSource;
			_0024TargetVolume_00241130 = TargetVolume;
			_0024TheSpeed_00241131 = TheSpeed;
			_0024DestroyAfterFadeout_00241132 = DestroyAfterFadeout;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024TheSource_00241129, _0024TargetVolume_00241130, _0024TheSpeed_00241131, _0024DestroyAfterFadeout_00241132);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InitializeAds_00241133 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024ChartboostManager_00241134;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!Application.isEditor)
					{
						HeyzapAds.Start("ca6ccb389ceaefa2fcf217e18ab6c62e", 0);
					}
					if (Debug.isDebugBuild && ShowTestSuite)
					{
						HeyzapAds.ShowDebugLogs();
						HeyzapAds.ShowMediationTestSuite();
					}
					else
					{
						HeyzapAds.HideDebugLogs();
					}
					HZIncentivizedAd.SetDisplayListener(_0024InitializeAds_0024closure_0024157);
					HZInterstitialAd.SetDisplayListener(_0024InitializeAds_0024closure_0024158);
					if (!Application.isEditor)
					{
						_0024ChartboostManager_00241134 = new GameObject();
						_0024ChartboostManager_00241134.name = "Chartboost";
						_0024ChartboostManager_00241134.AddComponent(typeof(Chartboost));
						UnityEngine.Object.DontDestroyOnLoad(_0024ChartboostManager_00241134);
					}
					if (AndroidStorefront() == AndroidStorefronts.Google)
					{
						CBExternal.initWithAppId(App.ChartboostGoogleID, App.ChartboostGoogleSig);
					}
					else
					{
						CBExternal.initWithAppId(App.ChartboostAmazonID, App.ChartboostAmazonSig);
					}
					if (!Application.isEditor)
					{
						CBExternal.setGameObjectName(_0024ChartboostManager_00241134.name);
					}
					Saver.Set("LastPauseBoost", DateTime.Now.ToString());
					Chartboost.didInitialize += ChartboostDidInitialize;
					goto case 2;
				case 2:
					result = ((ChartboostInitialized ? YieldDefault(3) : YieldDefault(2)) ? 1 : 0);
					break;
				case 3:
					if (PlayerPrefs.GetString("FirstAdEver") == string.Empty)
					{
						Chartboost.cacheInterstitial(CBLocation.Startup);
					}
					else
					{
						Chartboost.cacheInterstitial(CBLocation.HomeScreen);
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MuteAudioForAd_00241135 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AudioListener _0024TheListener_00241136;

			internal float _0024f_00241137;

			internal Menus _0024self__00241138;

			public _0024(Menus self_)
			{
				_0024self__00241138 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(AudioListener)_0024self__00241138.gameObject.GetComponent(typeof(AudioListener)))
					{
						goto case 1;
					}
					_0024TheListener_00241136 = (AudioListener)_0024self__00241138.gameObject.GetComponent(typeof(AudioListener));
					if (!_0024self__00241138.CurrentlyUnmuting)
					{
						_0024self__00241138.TargetVolume = AudioListener.volume;
					}
					_0024f_00241137 = default(float);
					goto IL_00dc;
				case 2:
					_0024f_00241137 += Time.deltaTime * 2f;
					goto IL_00dc;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00dc:
					if (_0024f_00241137 < 1f)
					{
						AudioListener.volume = Mathf.Lerp(_0024self__00241138.TargetVolume, 0f, _0024f_00241137);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					AudioListener.volume = 0f;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241139;

		public _0024MuteAudioForAd_00241135(Menus self_)
		{
			_0024self__00241139 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241139);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024UnMuteAudioForAd_00241140 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AudioListener _0024TheListener_00241141;

			internal float _0024f_00241142;

			internal Menus _0024self__00241143;

			public _0024(Menus self_)
			{
				_0024self__00241143 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)(AudioListener)_0024self__00241143.gameObject.GetComponent(typeof(AudioListener)))
					{
						_0024TheListener_00241141 = (AudioListener)_0024self__00241143.gameObject.GetComponent(typeof(AudioListener));
						_0024self__00241143.CurrentlyUnmuting = true;
						if (_0024self__00241143.TargetVolume != -1f)
						{
							_0024f_00241142 = default(float);
							goto IL_00df;
						}
					}
					goto case 1;
				case 2:
					_0024f_00241142 += Time.deltaTime * 2f;
					goto IL_00df;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00df:
					if (_0024f_00241142 < 1f)
					{
						AudioListener.volume = Mathf.Lerp(0f, _0024self__00241143.TargetVolume, _0024f_00241142);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					AudioListener.volume = _0024self__00241143.TargetVolume;
					_0024self__00241143.CurrentlyUnmuting = false;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241144;

		public _0024UnMuteAudioForAd_00241140(Menus self_)
		{
			_0024self__00241144 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241144);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InitializeVideoAds_00241145 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_00241146;

			internal Menus _0024self__00241147;

			public _0024(Menus self_)
			{
				_0024self__00241147 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241147.StartCoroutine(_0024self__00241147.FetchPauseAd());
					if (_0024self__00241147.HasRewardedVideos)
					{
						_0024i_00241146 = default(int);
						goto IL_0085;
					}
					goto IL_00ac;
				case 2:
					if (_0024self__00241147.ForcedInitialVideoFetch)
					{
						goto IL_009b;
					}
					_0024i_00241146++;
					goto IL_0085;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ac:
					YieldDefault(1);
					goto case 1;
					IL_0085:
					if (_0024i_00241146 < _0024self__00241147.VideoAdCacheDelay)
					{
						result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
						break;
					}
					goto IL_009b;
					IL_009b:
					_0024self__00241147.StartCoroutine("FetchVideo");
					goto IL_00ac;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241148;

		public _0024InitializeVideoAds_00241145(Menus self_)
		{
			_0024self__00241148 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241148);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FetchPauseAd_00241149 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = ((Debug.isDebugBuild ? Yield(3, new WaitForSeconds(5f)) : Yield(2, new WaitForSeconds(60f))) ? 1 : 0);
					break;
				case 2:
				case 3:
					Chartboost.cacheInterstitial(CBLocation.Pause);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FetchVideo_00241150 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					HZIncentivizedAd.Fetch();
					goto IL_005b;
				case 3:
					if (!HZIncentivizedAd.IsAvailable())
					{
						HZIncentivizedAd.Fetch();
					}
					goto IL_005b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005b:
					if (!HZIncentivizedAd.IsAvailable())
					{
						result = (Yield(3, new WaitForSeconds(30f)) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024AdHold_00241151 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					HoldAds = true;
					result = (Yield(2, new WaitForSeconds(8f)) ? 1 : 0);
					break;
				case 2:
					HoldAds = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LeaderboardsCall_00241152 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Menus _0024self__00241153;

			public _0024(Menus self_)
			{
				_0024self__00241153 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241153.BoardsError.gameObject.SetActive(false);
					_0024self__00241153.BoardsTitle.text = App.Leaderboards[CurrentBoard].Name.ToUpper();
					_0024self__00241153.Loading(Loc.L("Getting Scores"));
					_0024self__00241153.BoardsLeftNum.text = string.Empty;
					_0024self__00241153.BoardsLeftName.text = string.Empty;
					_0024self__00241153.BoardsLeftScore.text = string.Empty;
					_0024self__00241153.BoardsRightNum.text = string.Empty;
					_0024self__00241153.BoardsRightName.text = string.Empty;
					_0024self__00241153.BoardsRightScore.text = string.Empty;
					result = (Yield(2, new WaitForSeconds(0.65f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241153.GetScores(CurrentBoard + 1, _0024self__00241153.LeaderboardsGotScores, _0024self__00241153.LeaderboardsScoresFailed);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241154;

		public _0024LeaderboardsCall_00241152(Menus self_)
		{
			_0024self__00241154 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241154);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ClaimPrizeHit_00241155 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024name_00241156;

			internal int _0024check_00241157;

			internal Menus _0024self__00241158;

			public _0024(Menus self_)
			{
				_0024self__00241158 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (TimeUntilNextPrize <= 0f)
					{
						_0024self__00241158.LoadingDark(Loc.L("Connecting to store"));
						if (!Saver.GetBoolean("ClaimedPrizeBefore"))
						{
							FirstPrize = true;
							Saver.Set("ClaimedPrizeBefore", true);
							result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
							break;
						}
						FirstPrize = false;
						_0024name_00241156 = Settings.DeviceID;
						_0024name_00241156 = WWW.EscapeURL(_0024name_00241156);
						_0024check_00241157 = (_0024name_00241156.Length + 2) * (_0024name_00241156.Length + 5) * (_0024name_00241156.Length + 1);
						_0024self__00241158.StartCoroutine(_0024self__00241158.CallScript(App.SystemName + "/claiming.php?tag=" + _0024name_00241156 + "&vcode=" + _0024check_00241157, _0024self__00241158.DataLoaded, _0024self__00241158.RequestFailed));
						YieldDefault(1);
					}
					goto case 1;
				case 2:
					_0024self__00241158.DataLoaded(new string[1] { "1" });
					TutorialState++;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241159;

		public _0024ClaimPrizeHit_00241155(Menus self_)
		{
			_0024self__00241159 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241159);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SyncServerTime_00241160 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024Call_00241161;

			internal string[] _0024AllData_00241162;

			internal long _0024ParsedInt_00241163;

			internal Menus _0024self__00241164;

			public _0024(Menus self_)
			{
				_0024self__00241164 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					UsesServerTime = true;
					_0024Call_00241161 = new WWW("https://naquatic.com/System/" + App.SystemName + "/firstScript.php?" + Settings.DeviceID);
					result = (Yield(2, _0024Call_00241161) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024Call_00241161.error))
					{
						_0024AllData_00241162 = Regex.Split(_0024Call_00241161.text, ":");
						_0024ParsedInt_00241163 = default(long);
						if (Extensions.get_length((System.Array)_0024AllData_00241162) == 2 && _0024AllData_00241162[0] == "1" && long.TryParse(_0024AllData_00241162[1], out _0024ParsedInt_00241163))
						{
							_0024self__00241164.StoreServerTime(_0024ParsedInt_00241163);
						}
						else
						{
							ServerTimeSynced = false;
						}
					}
					else
					{
						ServerTimeSynced = false;
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

		internal Menus _0024self__00241165;

		public _0024SyncServerTime_00241160(Menus self_)
		{
			_0024self__00241165 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00241165);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResyncServerTimeAfterFailure_00241166 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal Menus _0024self__00241167;

			public _0024(Menus self_)
			{
				_0024self__00241167 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241167.ResyncCountdownInProgress)
					{
						goto case 1;
					}
					_0024self__00241167.ResyncCountdownInProgress = true;
					result = (Yield(2, new WaitForSeconds(240f)) ? 1 : 0);
					break;
				case 2:
					result = (Yield(3, _0024self__00241167.StartCoroutine(_0024self__00241167.SyncServerTime())) ? 1 : 0);
					break;
				case 3:
					_0024self__00241167.ResyncCountdownInProgress = false;
					if (ServerTimeSynced)
					{
						_0024self__00241167.SendMessage("ResyncServerTimeSuccess", SendMessageOptions.DontRequireReceiver);
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

		internal Menus _0024self__00241168;

		public _0024ResyncServerTimeAfterFailure_00241166(Menus self_)
		{
			_0024self__00241168 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241168);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PrizeCounter_00241169 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024Hours_00241170;

			internal int _0024Minutes_00241171;

			internal int _0024Seconds_00241172;

			internal string _0024ExtraZeroSec_00241173;

			internal string _0024ExtraZeroMin_00241174;

			internal float _0024_0024529_00241175;

			internal Color _0024_0024530_00241176;

			internal float _0024_0024531_00241177;

			internal Color _0024_0024532_00241178;

			internal Menus _0024self__00241179;

			public _0024(Menus self_)
			{
				_0024self__00241179 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_02dd
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					TimeSinceLastPrize = (float)DateTime.Now.Subtract(Saver.GetDate("LastPrize")).TotalSeconds;
					if (_0024self__00241179.StorePrizeText != null)
					{
						if (!(TimeSinceLastPrize <= (float)_0024self__00241179.TimeBetweenPrizes))
						{
							float num = (_0024_0024529_00241175 = 1f);
							Color color = (_0024_0024530_00241176 = _0024self__00241179.StorePrizeText.material.color);
							float num2 = (_0024_0024530_00241176.a = _0024_0024529_00241175);
							Color color3 = (_0024self__00241179.StorePrizeText.material.color = _0024_0024530_00241176);
							_0024self__00241179.StorePrizeText.text = Loc.L("CLAIM");
						}
						else
						{
							TimeUntilNextPrize = (float)_0024self__00241179.TimeBetweenPrizes - TimeSinceLastPrize;
							_0024Hours_00241170 = (int)Mathf.Floor(TimeUntilNextPrize / 60f / 60f);
							_0024Minutes_00241171 = (int)Mathf.Floor(TimeUntilNextPrize / 60f % 60f);
							_0024Seconds_00241172 = (int)(TimeUntilNextPrize % 60f);
							float num3 = (_0024_0024531_00241177 = 0.5f);
							Color color4 = (_0024_0024532_00241178 = _0024self__00241179.StorePrizeText.material.color);
							float num4 = (_0024_0024532_00241178.a = _0024_0024531_00241177);
							Color color6 = (_0024self__00241179.StorePrizeText.material.color = _0024_0024532_00241178);
							_0024ExtraZeroSec_00241173 = string.Empty;
							_0024ExtraZeroMin_00241174 = string.Empty;
							if (_0024Seconds_00241172 < 10)
							{
								_0024ExtraZeroSec_00241173 = "0";
							}
							if (_0024Minutes_00241171 < 10)
							{
								_0024ExtraZeroMin_00241174 = "0";
							}
							if (_0024self__00241179.TimeBetweenPrizes > 3600)
							{
								_0024self__00241179.StorePrizeText.text = _0024Hours_00241170.ToString() + ":" + _0024ExtraZeroMin_00241174 + _0024Minutes_00241171.ToString() + ":" + _0024ExtraZeroSec_00241173 + _0024Seconds_00241172.ToString();
							}
							else
							{
								_0024self__00241179.StorePrizeText.text = _0024ExtraZeroMin_00241174 + _0024Minutes_00241171.ToString() + ":" + _0024ExtraZeroSec_00241173 + _0024Seconds_00241172.ToString();
							}
						}
					}
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241180;

		public _0024PrizeCounter_00241169(Menus self_)
		{
			_0024self__00241180 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241180);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FindMatch_00241181 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WWWForm _0024Form_00241182;

			internal WWW _0024Call_00241183;

			internal float _0024RandomWait_00241184;

			internal bool _0024Bailed_00241185;

			internal float _0024Counter_00241186;

			internal int _0024Mode_00241187;

			internal Menus _0024self__00241188;

			public _0024(int Mode, Menus self_)
			{
				_0024Mode_00241187 = Mode;
				_0024self__00241188 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					NextMode = _0024Mode_00241187;
					IsFriendMatch = false;
					RematchData.Clear();
					GenerateRandom();
					_0024self__00241188.LoadingExit(Loc.L("Finding match"));
					_0024Form_00241182 = new WWWForm();
					_0024Form_00241182.AddField("SystemName", App.MultiplayerName);
					_0024Form_00241182.AddField("DeviceID", Settings.DeviceID);
					_0024Form_00241182.AddField("GameMode", NextMode.ToString());
					_0024Form_00241182.AddField("OpponentDatabaseID", "0");
					_0024Form_00241182.AddField("Advantage", Advantage);
					_0024Form_00241182.AddField("Level", _0024self__00241188.Level().ToString());
					_0024Form_00241182.AddField("Wins", Saver.GetInt("totalWins"));
					_0024Form_00241182.AddField("Losses", Saver.GetInt("totalLosses"));
					_0024Call_00241183 = new WWW("https://naquatic.com/System/" + App.SystemName + "/GameRetrieve.php", _0024Form_00241182);
					_0024RandomWait_00241184 = UnityEngine.Random.Range(0.5f, 5f);
					_0024Bailed_00241185 = default(bool);
					_0024Counter_00241186 = default(float);
					goto case 2;
				case 2:
					if ((!_0024Call_00241183.isDone && _0024Counter_00241186 < 20f) || _0024Counter_00241186 < _0024RandomWait_00241184)
					{
						if (SelectedButton == "EXIT")
						{
							_0024Bailed_00241185 = true;
							_0024Counter_00241186 = 999f;
						}
						_0024Counter_00241186 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00241188.Hid("Loading");
					if (_0024Call_00241183.isDone && string.IsNullOrEmpty(_0024Call_00241183.error) && !_0024Bailed_00241185 && _0024Call_00241183.text != string.Empty)
					{
						_0024self__00241188.StartMatch(_0024Call_00241183.text);
					}
					else if (!_0024Bailed_00241185)
					{
						if (!string.IsNullOrEmpty(_0024Call_00241183.error))
						{
							Debug.Log(_0024Call_00241183.error);
						}
						_0024self__00241188.Popup(Loc.L("MatchmakingFailed"), Loc.L("TryLater"));
					}
					_0024Call_00241183.Dispose();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Mode_00241189;

		internal Menus _0024self__00241190;

		public _0024FindMatch_00241181(int Mode, Menus self_)
		{
			_0024Mode_00241189 = Mode;
			_0024self__00241190 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Mode_00241189, _0024self__00241190);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReportYourSimData_00241191 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWWForm _0024Form_00241192;

			internal WWW _0024PostForm_00241193;

			internal Menus _0024self__00241194;

			public _0024(Menus self_)
			{
				_0024self__00241194 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (Extensions.get_length(MatchAction) > Menu.MinActionForReporting)
					{
						_0024self__00241194.SendMessage("MatchPrefixGenerate");
						_0024Form_00241192 = new WWWForm();
						_0024Form_00241192.AddField("SystemName", App.MultiplayerName);
						_0024Form_00241192.AddField("DeviceID", Settings.DeviceID);
						_0024Form_00241192.AddField("Advantage", Advantage);
						_0024Form_00241192.AddField("Level", _0024self__00241194.Level().ToString());
						_0024Form_00241192.AddField("GameMode", Mathf.Abs(GameMode).ToString());
						_0024Form_00241192.AddField("PlayerName", WWW.EscapeURL(PlayerName));
						_0024Form_00241192.AddField("RandomSeed", RandomSeed.ToString());
						_0024Form_00241192.AddField("MatchPrefix", MatchPrefix);
						_0024Form_00241192.AddField("MatchAction", MatchAction);
						_0024PostForm_00241193 = new WWW("https://naquatic.com/System/" + App.SystemName + "/GameReport.php", _0024Form_00241192);
						result = (Yield(2, _0024PostForm_00241193) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241195;

		public _0024ReportYourSimData_00241191(Menus self_)
		{
			_0024self__00241195 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00241195);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RetainRandomSeed_00241196 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					RetainingRandomSeed = true;
					result = (Yield(2, new WaitForSeconds(10f)) ? 1 : 0);
					break;
				case 2:
					RetainingRandomSeed = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RematchProcessBegan_00241197 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WWWForm _0024Form_00241198;

			internal WWW _0024Call_00241199;

			internal float _0024Counter_00241200;

			internal float _0024RandomWait_00241201;

			internal float _0024RandomQuitWait_00241202;

			internal float _0024WillRematch_00241203;

			internal string _0024CurrentData_00241204;

			internal Menus _0024self__00241205;

			public _0024(Menus self_)
			{
				_0024self__00241205 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					RematchResponse = 0;
					WaitingForRematch = false;
					if (IsSim && RematchData.length == 0)
					{
						_0024Form_00241198 = new WWWForm();
						_0024Form_00241198.AddField("SystemName", App.MultiplayerName);
						_0024Form_00241198.AddField("DeviceID", Settings.DeviceID);
						_0024Form_00241198.AddField("GameMode", NextMode.ToString());
						_0024Form_00241198.AddField("OpponentDatabaseID", OpponentDatabaseID);
						_0024Form_00241198.AddField("Advantage", Advantage);
						_0024Form_00241198.AddField("Level", _0024self__00241205.Level().ToString());
						_0024Form_00241198.AddField("Wins", Saver.GetInt("totalWins"));
						_0024Form_00241198.AddField("Losses", Saver.GetInt("totalLosses"));
						_0024Call_00241199 = new WWW("https://naquatic.com/System/" + App.SystemName + "/GameRetrieve.php", _0024Form_00241198);
					}
					_0024Counter_00241200 = default(float);
					_0024RandomWait_00241201 = UnityEngine.Random.Range(0.5f, 10f);
					_0024RandomQuitWait_00241202 = UnityEngine.Random.Range(6f, 25f);
					_0024WillRematch_00241203 = UnityEngine.Random.Range(0f, 1f);
					if (IsSim)
					{
						goto case 2;
					}
					goto IL_037a;
				case 2:
					if (_0024Counter_00241200 < _0024RandomWait_00241201)
					{
						_0024Counter_00241200 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024WillRematch_00241203 >= 0.2f))
					{
						_0024self__00241205.SendMessage("RematchDeniedByOpponent", SendMessageOptions.DontRequireReceiver);
						goto case 1;
					}
					if (RematchData.length > 0)
					{
						_0024CurrentData_00241204 = RematchData[0].ToString();
						RematchData.RemoveAt(0);
						_0024self__00241205.StartCoroutine(_0024self__00241205.RematchRequestedByOpponent(_0024CurrentData_00241204));
						goto IL_0322;
					}
					goto case 3;
				case 3:
					if (!_0024Call_00241199.isDone)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (string.IsNullOrEmpty(_0024Call_00241199.error))
					{
						if (_0024Call_00241199.text == string.Empty)
						{
							_0024self__00241205.SendMessage("RematchDeniedByOpponent", SendMessageOptions.DontRequireReceiver);
						}
						else
						{
							RematchData = new UnityScript.Lang.Array();
							RematchData = Regex.Split(_0024Call_00241199.text, ",,,,,,,,");
							_0024CurrentData_00241204 = RematchData[0].ToString();
							RematchData.RemoveAt(0);
							_0024self__00241205.StartCoroutine(_0024self__00241205.RematchRequestedByOpponent(_0024CurrentData_00241204));
						}
					}
					else
					{
						_0024self__00241205.SendMessage("RematchDeniedByOpponent", SendMessageOptions.DontRequireReceiver);
					}
					goto IL_0322;
				case 4:
					if (_0024Counter_00241200 < _0024RandomQuitWait_00241202)
					{
						_0024Counter_00241200 += Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (IsSim)
					{
						_0024self__00241205.SendMessage("RematchDeniedByOpponent", SendMessageOptions.DontRequireReceiver);
					}
					goto IL_037a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0322:
					_0024Counter_00241200 = 0f;
					goto case 4;
					IL_037a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241206;

		public _0024RematchProcessBegan_00241197(Menus self_)
		{
			_0024self__00241206 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241206);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RematchRequestedByOpponent_00241207 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024Message_00241208;

			internal Menus _0024self__00241209;

			public _0024(string Message, Menus self_)
			{
				_0024Message_00241208 = Message;
				_0024self__00241209 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					RematchResponse = 1;
					if (NewUI != null)
					{
						_0024self__00241209.GameOverSpeech.text = Loc.L("GO_PlayAgain");
					}
					else
					{
						((GUIText)_0024self__00241209.Get("GameOverSpeech").GetComponent(typeof(GUIText))).text = Loc.L("GO_PlayAgain");
					}
					goto case 2;
				case 2:
					if (!WaitingForRematch)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (RematchResponse == 1)
					{
						_0024self__00241209.RematchStart(_0024Message_00241208);
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

		internal string _0024Message_00241210;

		internal Menus _0024self__00241211;

		public _0024RematchRequestedByOpponent_00241207(string Message, Menus self_)
		{
			_0024Message_00241210 = Message;
			_0024self__00241211 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Message_00241210, _0024self__00241211);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RematchHideButton_00241212 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Menus _0024self__00241213;

			public _0024(Menus self_)
			{
				_0024self__00241213 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (NewUI != null)
					{
						_0024self__00241213.GameOverRematch.interactable = false;
					}
					else
					{
						((GUITexture)_0024self__00241213.Get("GameOverRematch").GetComponent(typeof(GUITexture))).color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
						if (_0024self__00241213.Get("GameOverRematchText") != null)
						{
							((GUIText)_0024self__00241213.Get("GameOverRematchText").GetComponent(typeof(GUIText))).material.color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
						}
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

		internal Menus _0024self__00241214;

		public _0024RematchHideButton_00241212(Menus self_)
		{
			_0024self__00241214 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241214);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InitializeGameCenter_00241215 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024GCManager_00241216;

			internal bool _0024usesLeaderboards_00241217;

			internal bool _0024usesAchievements_00241218;

			internal bool _0024usesWhispersync_00241219;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (AndroidStorefront() == AndroidStorefronts.Google)
					{
						PlayGamesPlatform.DebugLogEnabled = true;
						PlayGamesPlatform.Activate();
						Social.localUser.Authenticate(_0024adaptor_0024__Menus_0024callable10_00248379_64___0024Action_00244.Adapt(_0024InitializeGameCenter_0024closure_0024165));
					}
					else if (AndroidStorefront() == AndroidStorefronts.Amazon && !Application.isEditor)
					{
						_0024GCManager_00241216 = new GameObject();
						_0024GCManager_00241216.AddComponent(typeof(GameCircleManager));
						UnityEngine.Object.DontDestroyOnLoad(_0024GCManager_00241216);
						_0024usesLeaderboards_00241217 = true;
						_0024usesAchievements_00241218 = false;
						_0024usesWhispersync_00241219 = false;
						AGSClient.SetPopUpEnabled(false);
						AGSClient.Init(_0024usesLeaderboards_00241217, _0024usesAchievements_00241218, _0024usesWhispersync_00241219);
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GameCenterMatchmakerFoundMatch_00241220 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024GCID_00241221;

			internal Menus _0024self__00241222;

			public _0024(string GCID, Menus self_)
			{
				_0024GCID_00241221 = GCID;
				_0024self__00241222 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241222.DebugMultiplayer)
					{
						Debug.Log("GameCenterMatchmakerFoundMatch was called with your GCID: " + _0024GCID_00241221);
					}
					if (!GameCenterFoundMatchRecently)
					{
						if (!_0024self__00241222.NewMultiplayerSystem)
						{
							GameCenterSend("Camera", "StartMatch", _0024self__00241222.GameCenterGenerateSyncData(string.Empty), true);
						}
						else
						{
							MyGCID = _0024GCID_00241221;
							_0024self__00241222.GameCenterGenerateSyncData(_0024GCID_00241221);
							_0024self__00241222.StartCoroutine("GameCenterSendWelcome");
						}
						_0024self__00241222.SendMessage("ReportMatchmakerFoundMatch", string.Empty, SendMessageOptions.DontRequireReceiver);
						GameCenterFoundMatchRecently = true;
						result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
						break;
					}
					goto IL_00de;
				case 2:
					GameCenterFoundMatchRecently = false;
					goto IL_00de;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00de:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024GCID_00241223;

		internal Menus _0024self__00241224;

		public _0024GameCenterMatchmakerFoundMatch_00241220(string GCID, Menus self_)
		{
			_0024GCID_00241223 = GCID;
			_0024self__00241224 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024GCID_00241223, _0024self__00241224);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GameCenterSendWelcome_00241225 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_00241226;

			internal string _0024ThePrefix_00241227;

			internal int _0024p_00241228;

			internal string _0024TheString_00241229;

			internal Menus _0024self__00241230;

			public _0024(Menus self_)
			{
				_0024self__00241230 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0226
				int result;
				switch (_state)
				{
				default:
					for (_0024i_00241226 = default(int); _0024i_00241226 < OnlinePlayers.Count; _0024i_00241226++)
					{
						_0024ThePrefix_00241227 = string.Empty;
						for (_0024p_00241228 = default(int); _0024p_00241228 < OnlinePlayers[_0024i_00241226].Prefix.length; _0024p_00241228++)
						{
							if (_0024ThePrefix_00241227 != string.Empty)
							{
								_0024ThePrefix_00241227 += ",,,";
							}
							_0024ThePrefix_00241227 += OnlinePlayers[_0024i_00241226].Prefix[_0024p_00241228];
						}
						_0024TheString_00241229 = OnlinePlayers[_0024i_00241226].Mode + "," + "0," + NEscapeURL(OnlinePlayers[_0024i_00241226].Name) + "," + OnlinePlayers[_0024i_00241226].Seed.ToString() + "," + OnlinePlayers[_0024i_00241226].Key + "," + OnlinePlayers[_0024i_00241226].GCID + ",,,," + _0024ThePrefix_00241227;
						GameCenterSend("Camera", "GameCenterPlayerConnected", _0024TheString_00241229, true);
					}
					_0024self__00241230.StopCoroutine("RetainRandomSeed");
					_0024self__00241230.StartCoroutine("RetainRandomSeed");
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241231;

		public _0024GameCenterSendWelcome_00241225(Menus self_)
		{
			_0024self__00241231 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241231);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GameCenterTimeoutCountdown_00241232 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Menus _0024self__00241233;

			public _0024(Menus self_)
			{
				_0024self__00241233 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_001c
				int result;
				switch (_state)
				{
				case 2:
					if (!GameEnded)
					{
						_0024self__00241233.SecondsUntilGameCenterTimeout -= Time.deltaTime;
						if (_0024self__00241233.SecondsUntilGameCenterTimeout > 0f)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__00241233.MultiplayerYouDisconnectedMidMatch();
					}
					else
					{
						YieldDefault(1);
					}
					goto default;
				default:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Menus _0024self__00241234;

		public _0024GameCenterTimeoutCountdown_00241232(Menus self_)
		{
			_0024self__00241234 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00241234);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CallScript_00241235 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024counter_00241236;

			internal WWW _0024call_00241237;

			internal string[] _0024result_00241238;

			internal string _0024script_00241239;

			internal __Menus_GetScores_0024callable4_00246265_52__ _0024returnFunction_00241240;

			internal __Menus_PopupSingleCallback_0024callable2_00243643_34__ _0024failFunction_00241241;

			public _0024(string script, __Menus_GetScores_0024callable4_00246265_52__ returnFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ failFunction)
			{
				_0024script_00241239 = script;
				_0024returnFunction_00241240 = returnFunction;
				_0024failFunction_00241241 = failFunction;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024counter_00241236 = default(float);
					_0024call_00241237 = new WWW("https://naquatic.com/System/" + _0024script_00241239);
					goto case 2;
				case 2:
					if (!_0024call_00241237.isDone && _0024counter_00241236 < 16f)
					{
						_0024counter_00241236 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024call_00241237.isDone || !string.IsNullOrEmpty(_0024call_00241237.error))
					{
						if (_0024failFunction_00241241 != null)
						{
							_0024failFunction_00241241();
						}
					}
					else
					{
						_0024result_00241238 = _0024call_00241237.text.Split(":"[0]);
						if (_0024returnFunction_00241240 != null)
						{
							_0024returnFunction_00241240(_0024result_00241238);
						}
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

		internal string _0024script_00241242;

		internal __Menus_GetScores_0024callable4_00246265_52__ _0024returnFunction_00241243;

		internal __Menus_PopupSingleCallback_0024callable2_00243643_34__ _0024failFunction_00241244;

		public _0024CallScript_00241235(string script, __Menus_GetScores_0024callable4_00246265_52__ returnFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ failFunction)
		{
			_0024script_00241242 = script;
			_0024returnFunction_00241243 = returnFunction;
			_0024failFunction_00241244 = failFunction;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024script_00241242, _0024returnFunction_00241243, _0024failFunction_00241244);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024KeyboardEntry_00241245 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024TextLastFrame_00241246;

			internal GUIText _0024TheTargetText_00241247;

			internal int _0024TheMaxLength_00241248;

			internal __Menus_LoginCheck_0024callable5_00246585_26__ _0024TheCheckFunction_00241249;

			internal __Menus_PopupSingleCallback_0024callable2_00243643_34__ _0024TheUpdateFunction_00241250;

			internal Menus _0024self__00241251;

			public _0024(GUIText TheTargetText, int TheMaxLength, __Menus_LoginCheck_0024callable5_00246585_26__ TheCheckFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ TheUpdateFunction, Menus self_)
			{
				_0024TheTargetText_00241247 = TheTargetText;
				_0024TheMaxLength_00241248 = TheMaxLength;
				_0024TheCheckFunction_00241249 = TheCheckFunction;
				_0024TheUpdateFunction_00241250 = TheUpdateFunction;
				_0024self__00241251 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241251.TargetText = _0024TheTargetText_00241247;
					_0024self__00241251.CheckFunction = _0024TheCheckFunction_00241249;
					_0024self__00241251.MaxLength = _0024TheMaxLength_00241248;
					_0024self__00241251.KeyboardRestrictTouch = true;
					_0024self__00241251.StartCoroutine(_0024self__00241251.AdHold());
					TouchScreenKeyboard.hideInput = false;
					Keyboard = TouchScreenKeyboard.Open(_0024self__00241251.TargetText.text, TouchScreenKeyboardType.Default, false);
					_0024TextLastFrame_00241246 = null;
					goto case 2;
				case 2:
					if (!Keyboard.done && !Keyboard.wasCanceled)
					{
						if (Keyboard.text != _0024TextLastFrame_00241246)
						{
							Keyboard.text = _0024self__00241251.CheckFunction(Keyboard.text);
							if (Extensions.get_length(Keyboard.text) > _0024self__00241251.MaxLength - 1)
							{
								Keyboard.text = Keyboard.text.Substring(0, _0024self__00241251.MaxLength);
							}
							if (_0024TheUpdateFunction_00241250 != null)
							{
								_0024TheUpdateFunction_00241250();
							}
						}
						_0024self__00241251.TargetText.text = Keyboard.text;
						_0024TextLastFrame_00241246 = Keyboard.text;
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

		internal GUIText _0024TheTargetText_00241252;

		internal int _0024TheMaxLength_00241253;

		internal __Menus_LoginCheck_0024callable5_00246585_26__ _0024TheCheckFunction_00241254;

		internal __Menus_PopupSingleCallback_0024callable2_00243643_34__ _0024TheUpdateFunction_00241255;

		internal Menus _0024self__00241256;

		public _0024KeyboardEntry_00241245(GUIText TheTargetText, int TheMaxLength, __Menus_LoginCheck_0024callable5_00246585_26__ TheCheckFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ TheUpdateFunction, Menus self_)
		{
			_0024TheTargetText_00241252 = TheTargetText;
			_0024TheMaxLength_00241253 = TheMaxLength;
			_0024TheCheckFunction_00241254 = TheCheckFunction;
			_0024TheUpdateFunction_00241255 = TheUpdateFunction;
			_0024self__00241256 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024TheTargetText_00241252, _0024TheMaxLength_00241253, _0024TheCheckFunction_00241254, _0024TheUpdateFunction_00241255, _0024self__00241256);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024UnlockResponse_00241257 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024Instance_00241258;

			internal Menus _0024self__00241259;

			public _0024(string Instance, Menus self_)
			{
				_0024Instance_00241258 = Instance;
				_0024self__00241259 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (SelectedButton == string.Empty)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (SelectedButton == "PopupTwo1")
					{
						Saver.Set("Unlocked" + _0024Instance_00241258, true);
						_0024self__00241259.SendMessage("AddCurrency", -UnlockValue(_0024Instance_00241258));
						_0024self__00241259.SendMessage("UnlockCompleted", _0024Instance_00241258);
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

		internal string _0024Instance_00241260;

		internal Menus _0024self__00241261;

		public _0024UnlockResponse_00241257(string Instance, Menus self_)
		{
			_0024Instance_00241260 = Instance;
			_0024self__00241261 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Instance_00241260, _0024self__00241261);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CrewAdvance_00241262 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024Call_00241263;

			internal string[] _0024AllData_00241264;

			internal WWWForm _0024Form_00241265;

			internal Menus _0024self__00241266;

			public _0024(WWWForm Form, Menus self_)
			{
				_0024Form_00241265 = Form;
				_0024self__00241266 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024Call_00241263 = new WWW("https://naquatic.com/System/" + App.SystemName + "/CrewAdvance.php", _0024Form_00241265);
					result = (Yield(2, _0024Call_00241263) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024Call_00241263.error))
					{
						_0024AllData_00241264 = Regex.Split(_0024Call_00241263.text, ":");
						if (Extensions.get_length((System.Array)_0024AllData_00241264) >= 2)
						{
							Saver.Set("Secret", _0024AllData_00241264[1]);
							Saver.Save();
							if (_0024AllData_00241264[0] == "-1")
							{
								_0024self__00241266.SendMessage("CrewAdvanceFailed", string.Empty, SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								_0024self__00241266.SendMessage("CrewAdvanceSucceeded", string.Empty, SendMessageOptions.DontRequireReceiver);
							}
						}
						else
						{
							_0024self__00241266.SendMessage("CrewAdvanceFailed", string.Empty, SendMessageOptions.DontRequireReceiver);
						}
					}
					else
					{
						_0024self__00241266.SendMessage("CrewAdvanceFailed", string.Empty, SendMessageOptions.DontRequireReceiver);
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

		internal WWWForm _0024Form_00241267;

		internal Menus _0024self__00241268;

		public _0024CrewAdvance_00241262(WWWForm Form, Menus self_)
		{
			_0024Form_00241267 = Form;
			_0024self__00241268 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024Form_00241267, _0024self__00241268);
		}
	}

	private GameObject GUI;

	[NonSerialized]
	public static GameObject NewUI;

	[NonSerialized]
	public static Menus Menu;

	[NonSerialized]
	public static bool InstanceExists;

	public bool ModeChangeFadeOut;

	[NonSerialized]
	public static int GameMode;

	[NonSerialized]
	public static int LastMode;

	[NonSerialized]
	public static int NextMode;

	[NonSerialized]
	public static int RandomSeed;

	[NonSerialized]
	public static bool IsSim = true;

	[NonSerialized]
	public static bool IsSinglePlayer = true;

	[NonSerialized]
	public static bool GameEnded;

	[NonSerialized]
	public static bool FirstOpen = true;

	[NonSerialized]
	public static bool IsTutorial;

	[NonSerialized]
	public static int TutorialState;

	[NonSerialized]
	public static string TutorialAllow;

	[NonSerialized]
	public static bool LoadingGame;

	private bool FirstLoad;

	[NonSerialized]
	public static int RandomLimit = 1000;

	[NonSerialized]
	public static int[] randomTable = new int[400]
	{
		16, 17, 0, 17, 3, 12, 9, 19, 15, 12,
		14, 15, 11, 7, 18, 8, 19, 16, 0, 10,
		6, 4, 8, 7, 11, 2, 7, 0, 18, 17,
		7, 5, 6, 3, 6, 11, 2, 16, 3, 12,
		8, 6, 13, 9, 14, 8, 18, 2, 9, 7,
		19, 14, 15, 5, 11, 3, 10, 3, 3, 4,
		13, 15, 13, 17, 17, 5, 6, 18, 2, 14,
		19, 12, 12, 13, 4, 3, 11, 17, 0, 15,
		6, 0, 9, 16, 4, 17, 6, 15, 3, 3,
		3, 3, 12, 17, 6, 1, 14, 19, 0, 0,
		5, 5, 14, 2, 18, 12, 15, 0, 6, 7,
		11, 3, 4, 4, 9, 12, 1, 11, 4, 17,
		6, 10, 13, 12, 7, 4, 13, 17, 18, 19,
		14, 18, 15, 4, 2, 4, 16, 19, 2, 9,
		11, 6, 17, 8, 0, 1, 7, 4, 5, 4,
		10, 15, 19, 16, 18, 18, 11, 13, 1, 17,
		9, 3, 4, 3, 10, 7, 13, 15, 12, 14,
		5, 4, 12, 16, 12, 11, 2, 11, 5, 15,
		11, 6, 7, 17, 18, 0, 4, 9, 11, 18,
		0, 9, 0, 15, 1, 16, 5, 19, 0, 13,
		19, 9, 10, 10, 7, 1, 18, 5, 4, 11,
		6, 3, 15, 9, 8, 14, 18, 19, 9, 11,
		11, 12, 10, 5, 12, 15, 2, 15, 5, 16,
		10, 6, 19, 1, 18, 3, 3, 9, 3, 13,
		1, 2, 9, 2, 16, 16, 1, 8, 13, 8,
		0, 14, 5, 13, 10, 13, 9, 10, 17, 15,
		14, 14, 18, 19, 16, 8, 9, 5, 13, 14,
		17, 1, 17, 8, 14, 7, 19, 13, 6, 5,
		13, 12, 0, 4, 1, 11, 1, 12, 18, 1,
		16, 16, 10, 4, 15, 14, 11, 0, 7, 2,
		1, 11, 8, 5, 14, 8, 0, 8, 15, 3,
		10, 19, 15, 13, 19, 1, 10, 14, 14, 19,
		16, 17, 1, 13, 0, 7, 7, 16, 5, 7,
		10, 6, 1, 6, 10, 8, 5, 1, 8, 13,
		6, 2, 1, 19, 0, 7, 3, 2, 8, 17,
		2, 2, 15, 16, 5, 8, 2, 10, 9, 2,
		14, 7, 0, 16, 6, 19, 18, 1, 10, 12,
		2, 18, 7, 8, 10, 4, 12, 9, 4, 9,
		14, 8, 12, 13, 18, 16, 17, 7, 11, 10,
		12, 17, 8, 2, 16, 19, 5, 6, 18, 9
	};

	[NonSerialized]
	public static CustomTouch[] Touches;

	[NonSerialized]
	public static CustomTouch[] TouchesAll;

	private GameObject HighlightedButton;

	private GameObject HighlightedText;

	private Color HighlightedButtonOriginalColor;

	private bool HighlightedButtonOriginalEnabled;

	private Color HighlightedTextOriginalColor;

	private GameObject ActiveScroll;

	private float ActiveScrollLimit;

	private bool CurrentScrollHorizontal;

	[NonSerialized]
	public static string SelectedButton = string.Empty;

	private int TouchOnMenuButton;

	private Vector2 MousePositionLastFrame;

	private int TouchCountLastFrame;

	[NonSerialized]
	public static bool DeterminedWindowsExternalInput;

	[NonSerialized]
	public static bool WindowsExternalInput;

	[NonSerialized]
	public static bool JustLockedCursor;

	[NonSerialized]
	public static bool IsController;

	[NonSerialized]
	public static bool TriggerRightInitialized;

	[NonSerialized]
	public static bool TriggerLeftInitialized;

	private bool TriggerRightReleased;

	private bool TriggerLeftReleased;

	private bool MouseTouched;

	private System.Collections.Generic.List<GameObject> RecentlyHighlighted;

	private bool ReleasedTheButton;

	private TouchObject[] ActiveButtonsLastFrame;

	[NonSerialized]
	public static float SliderChangedValue;

	private bool ShiftedY;

	private bool ShiftedX;

	private GameObject ChosenButton;

	private float CurrentY;

	private float CurrentX;

	private GameObject ControllerHighlightedButton;

	private Color ControllerHighlightedButtonOriginalColor;

	[NonSerialized]
	public static Canvas MainCanvas;

	[NonSerialized]
	public static RectTransform MainCanvasRect;

	public FontColors[] Colors;

	public Material[] LocalizedMaterials;

	[NonSerialized]
	public static TouchScreenKeyboard Keyboard;

	private GameObject GUICamera;

	private bool[] OriginalState;

	private UnityScript.Lang.Array MenusArray;

	private GameObject[] m_Menus;

	private UnityScript.Lang.Array ParentsArray;

	private GameObject[] Parents;

	[NonSerialized]
	public static System.Collections.Generic.List<GameObject> RootParents;

	private UnityScript.Lang.Array ChildrenArray;

	private GameObject[] Children;

	private UnityScript.Lang.Array ButtonsArray;

	private GameObject[] Buttons;

	private UnityScript.Lang.Array ButtonsTouchZonesArray;

	private Vector2[] ButtonsTouchZones;

	private UnityScript.Lang.Array ScrollsArray;

	private GameObject[] Scrolls;

	private UnityScript.Lang.Array ScrollsDirectionArray;

	private bool[] ScrollsDirection;

	private UnityScript.Lang.Array ScrollsLimitArray;

	[NonSerialized]
	private static float Inertia;

	private UnityScript.Lang.Array GUITextsArray;

	private UnityScript.Lang.Array GUITexturesArray;

	private Texture2D DarkTexture;

	private bool FirstMenuInitialization;

	private string[] OriginalMenuNames;

	private UnityScript.Lang.Array OriginalTexturePositions;

	private int OriginalTextureIndex;

	private UnityScript.Lang.Array OriginalTextPositions;

	private UnityScript.Lang.Array OriginalTextSizes;

	private int OriginalTextIndex;

	private int LastScreenWidth;

	private int LastScreenHeight;

	[NonSerialized]
	public static bool MuteSounds;

	[NonSerialized]
	public static bool MuteMusic;

	[NonSerialized]
	public static bool IsVR;

	private GameObject GUI3D;

	[NonSerialized]
	public static Transform OVRCameraController;

	[NonSerialized]
	public static Transform OVRCameraLeft;

	[NonSerialized]
	public static Transform OVRCameraRight;

	private UnityScript.Lang.Array GUITexturesArray3D;

	private GameObject[] GUITextureParents;

	private GUITexture[] GUITextures;

	private GameObject[] GUITextures3D;

	private UnityScript.Lang.Array GUITextsArray3D;

	private GameObject[] GUITextParents;

	private GUIText[] GUITexts;

	private GameObject[] GUITexts3D;

	private TextMesh[] GUITextsMeshes3D;

	private GameObject LitButton;

	private GameObject VRFade;

	private Shader VRTextureShader;

	private Shader VRTextShader;

	private GameObject VRDot;

	private bool UseVRDot;

	private Transform VRGunsReloadShoot;

	private Transform VRGunsReloadLookDown;

	[NonSerialized]
	public static GameObject VRCrosshairParent;

	private Texture2D VRCrosshairH;

	private Texture2D VRCrosshairV;

	private GUITexture GunsCrosshairH1;

	private Transform VRCrosshairH1;

	private Transform VRCrosshairH2;

	private Transform VRCrosshairV1;

	private Transform VRCrosshairV2;

	private Transform VRPointFont1;

	private Transform VRPointFontShadow1;

	[NonSerialized]
	public static Vector3 VRPointFontPosition1;

	private Transform VRPointFont2;

	private Transform VRPointFontShadow2;

	[NonSerialized]
	public static Vector3 VRPointFontPosition2;

	[NonSerialized]
	public static bool VRGamepadAiming;

	private bool GunsModulePresent;

	[NonSerialized]
	public static string VRTextureShaderString = "Shader \"Mobile/Transparent/Vertex Color Simple\" {\n" + "Properties {\n" + "_Color (\"Main Color\", Color) = (1,1,1,1)\n" + "_MainTex (\"Base (RGB) Trans (A)\", 2D) = \"white\" {}\n" + "}\n" + "Category {\n" + "Tags {\"Queue\"=\"Transparent\" \"IgnoreProjector\"=\"True\" \"RenderType\"=\"Transparent\"}\n" + "ZWrite Off\n" + "ZTest Always\n" + "Alphatest Greater 0\n" + "Blend SrcAlpha OneMinusSrcAlpha\n" + "SubShader {\n" + "Material {\n" + "Diffuse [_Color]\n" + "Ambient [_Color]\n" + "}\n" + "Pass {\n" + "ColorMaterial AmbientAndDiffuse\n" + "Fog { Mode Off }\n" + "Lighting Off\n" + "SetTexture [_MainTex] {" + "Combine texture * primary, texture * primary" + "}" + "SetTexture [_MainTex] {" + "constantColor [_Color]" + "Combine previous * constant DOUBLE, previous * constant" + "}" + "}" + "}" + "}" + "}";

	[NonSerialized]
	public static string VRTextShaderString = "Shader \"GUI/3D Text Shader\" {\n" + "Properties {\n" + "_MainTex (\"Font Texture\", 2D) = \"white\" {}\n" + "_Color (\"Text Color\", Color) = (1,1,1,1)\n" + "}\n" + "SubShader {\n" + "Tags { \"Queue\"=\"Transparent\" \"IgnoreProjector\"=\"True\" \"RenderType\"=\"Transparent\" }\n" + "Lighting Off Cull Off ZWrite Off Fog { Mode Off }\n" + "ZTest Always\n" + "Blend SrcAlpha OneMinusSrcAlpha\n" + "Pass {\n" + "Color [_Color]\n" + "SetTexture [_MainTex] {\n" + "combine primary, texture * primary\n" + "}\n" + "}}}";

	private Vector2 CrosshairOffset;

	private Quaternion CrosshairRotationLastFrame;

	private float VRMenuDistance;

	[NonSerialized]
	public static GameObject LoadingMenu;

	private GUITexture LoadingWheel;

	[NonSerialized]
	public static GUIText LoadingText;

	[NonSerialized]
	public static GUIText LoadingMatchText;

	private GameObject LoadingExitButton;

	private GameObject LoadingDarkButton;

	[NonSerialized]
	public static Animation LoadingAnimation;

	[NonSerialized]
	public static Text LoadingTextUI;

	[NonSerialized]
	public static Text LoadingMatchTextUI;

	[NonSerialized]
	public static Button LoadingButton;

	[NonSerialized]
	public static Image LoadingImage;

	[NonSerialized]
	public static string PopupInstance;

	private int PopupType;

	private GUITexture PopupImage;

	private GUIText PopupHeadText;

	private GUIText PopupText;

	private GUIText Popup1Text;

	private GUIText PopupTwo1Text;

	private GUIText PopupTwo2Text;

	private GameObject PopupShareHolder;

	public int PopupBreakLength;

	public bool NoPopupHead;

	[NonSerialized]
	public static GameObject PopupMenu;

	private Animation PopupAnimation;

	private Button PopupButton1;

	private Button PopupButton2;

	private Text PopupButton1Text;

	private Text PopupButton2Text;

	private Button PopupExitButton;

	private Image PopupButtonIcon;

	private Text PopupUIText;

	private Text PopupUIHeadText;

	[NonSerialized]
	public static __Menus_PopupSingleCallback_0024callable2_00243643_34__ PopupSingleCallback;

	private GUITexture FadeTexture;

	private bool IsFadingOut;

	private Texture2D LightTexture;

	private float FadeSpeed;

	public int FadeDepth;

	public int NewUIFadeDepth;

	private Image FadeImage;

	private bool FirstFade;

	private CanvasGroup FadeCanvasGroup;

	[NonSerialized]
	public static Rect ScreenSafeArea;

	[NonSerialized]
	public static GameObject FadeMenu;

	[NonSerialized]
	public static AudioSource EffectsSource;

	public AudioClip TapSound;

	public float TapVolume;

	public AudioClip BackSound;

	public float BackVolume;

	[NonSerialized]
	public static bool Mute;

	public bool UseIAP;

	[NonSerialized]
	public static bool RetrievedAndroidStorefrontThisSession;

	[NonSerialized]
	public static AndroidStorefronts RetainedAndroidStorefront;

	[NonSerialized]
	public static bool PlatformUsesOwnNotifications;

	[NonSerialized]
	public static string AndroidStorefrontPath = "Naquatic/AndroidStorefront";

	private bool IsARestore;

	[NonSerialized]
	public static bool UnibillIsReady;

	[NonSerialized]
	public static IStoreController StoreController;

	[NonSerialized]
	public static IExtensionProvider StoreExtensionProvider;

	private MyStoreClass IAPClass;

	private System.Collections.Generic.List<Button> MoreButtons;

	private GameObject[] MoreCheckmarks;

	public bool AdsEnabledFree;

	public bool AdsEnabledPro;

	public bool HasRewardedVideos;

	public int MinutesBetweenInterstitialVideos;

	public int VideoAdCacheDelay;

	[NonSerialized]
	public static bool MadePurchase;

	private int AdFirstRun;

	private int ReturnAdFirstRun;

	[NonSerialized]
	public static bool HoldAds;

	[NonSerialized]
	public static float OriginalVolume = 1f;

	[NonSerialized]
	public static bool ShowTestSuite;

	[NonSerialized]
	public static float EditorTimeSinceVideo;

	[NonSerialized]
	public static bool ChartboostInitialized;

	private float TargetVolume;

	private bool CurrentlyUnmuting;

	private bool ForcedInitialVideoFetch;

	[NonSerialized]
	public static bool ShownInterstitialReturnAd;

	private GUIText BoardsLeftNum;

	private GUIText BoardsLeftName;

	private GUIText BoardsLeftScore;

	private GUIText BoardsRightNum;

	private GUIText BoardsRightName;

	private GUIText BoardsRightScore;

	private GUIText BoardsTitle;

	private GUIText BoardsError;

	[NonSerialized]
	private static int CurrentBoard;

	[NonSerialized]
	private static string GameName;

	public bool UseNaquaticLeaderboards;

	public bool PayOutAchievementValue;

	[NonSerialized]
	public static string PlayerName = string.Empty;

	public int PlayNameMaxLength;

	private __Menus_LoginCheck_0024callable5_00246585_26__ LoginCheck;

	[NonSerialized]
	public static GameObject LoginMenu;

	private Text LoginHead;

	private Button LoginSubmit;

	[NonSerialized]
	public static Text LoginText;

	private Text LoginError;

	[NonSerialized]
	public static InputField LoginInput;

	[NonSerialized]
	private static string kExperienceKey = "n3d2er2sa";

	public int kMaxLevel;

	public int kFactor;

	public int ExperienceFunction;

	public int TimeBetweenPrizes;

	[NonSerialized]
	public static float TimeSinceLastPrize;

	[NonSerialized]
	public static bool FirstPrize;

	[NonSerialized]
	public static float TimeUntilNextPrize;

	private GUIText StorePrizeText;

	[NonSerialized]
	public static Dictionary<string, float> Tunes;

	[NonSerialized]
	public static Dictionary<string, string> TunesStrings;

	[NonSerialized]
	public static System.Collections.Generic.List<string> TunesList;

	[NonSerialized]
	public static bool RefreshedTunes;

	[NonSerialized]
	public static bool ServerTimeSynced;

	[NonSerialized]
	public static DateTime LastServerTime;

	[NonSerialized]
	public static bool UsesServerTime;

	[NonSerialized]
	public static System.Collections.Generic.List<bool> TuningVariableIsString;

	[NonSerialized]
	public static bool ReceivedTuneVariable;

	[NonSerialized]
	public static bool Banned;

	private int SupplementalServerSeconds;

	private int ServerTimeReverifySubtraction;

	private bool ResyncCountdownInProgress;

	private DateTime LastPauseTime;

	private GUIText FriendEnterBoxBody;

	private Text FriendEnterBoxBodyUI;

	private GameObject FriendAdd;

	private Button FriendAddUI;

	private GUIText FriendCodeText;

	private Text FriendCodeTextUI;

	public int MinActionForReporting;

	[NonSerialized]
	public static string OpponentName = string.Empty;

	[NonSerialized]
	public static int OpponentDatabaseID;

	[NonSerialized]
	public static int OpponentFriends;

	[NonSerialized]
	public static string MatchPrefix;

	[NonSerialized]
	public static string MatchAction = string.Empty;

	[NonSerialized]
	public static int Advantage;

	[NonSerialized]
	public static string MatchActionOpp;

	[NonSerialized]
	public static UnityScript.Lang.Array RematchData = new UnityScript.Lang.Array();

	[NonSerialized]
	public static bool IsFriendMatch;

	public int MinimumModeForMultiplayerSync;

	[NonSerialized]
	public static bool RetainingRandomSeed;

	[NonSerialized]
	public static bool FoundOpponent;

	[NonSerialized]
	public static string MyKey;

	[NonSerialized]
	public static string MyGCID;

	public bool DebugMultiplayer;

	public bool MultiplayerAllowRematch;

	[NonSerialized]
	public static int RematchResponse;

	[NonSerialized]
	public static bool WaitingForRematch;

	public bool WaitForRematchCue;

	[NonSerialized]
	public static bool IsRematch;

	private GameObject GameOverMenu;

	private Text GameOverSpeech;

	private Button GameOverRematch;

	private Button GameOverQuit;

	public bool UseGameCenterForPlayerName;

	public bool NewMultiplayerSystem;

	[NonSerialized]
	private static bool GameCenterFoundMatchRecently;

	[NonSerialized]
	private static bool GameServicesAuthenticated;

	[NonSerialized]
	private static int GameServicesTargetMode;

	[NonSerialized]
	private static int GameCenterPlayersToMatch;

	[NonSerialized]
	public static System.Collections.Generic.List<OnlinePlayer> OnlinePlayers;

	[NonSerialized]
	public static int YourIndex;

	public float SecondsForGameCenterTimeout;

	private float SecondsUntilGameCenterTimeout;

	private string[] GCIDKeys;

	private RTMListener GameServicesMultiplayerListener;

	[NonSerialized]
	public static bool GameServicesInRoom;

	[NonSerialized]
	public static GameObject CustomKeyboard;

	private GUIText TargetText;

	private __Menus_LoginCheck_0024callable5_00246585_26__ CheckFunction;

	private int MaxLength;

	private GameObject KeyboardNumbers;

	private GameObject KeyboardLetters;

	private bool KeyboardRestrictTouch;

	[NonSerialized]
	public static GameObject PublishingPurchaseReceiver;

	public bool IsPublishingProject;

	public bool PublishingCaptureBackButton;

	[NonSerialized]
	public static DateTime DefaultDate;

	[NonSerialized]
	public static string FlurryStats = string.Empty;

	public Menus()
	{
		ModeChangeFadeOut = true;
		TouchOnMenuButton = -1;
		TriggerRightReleased = true;
		TriggerLeftReleased = true;
		Colors = new FontColors[10]
		{
			new FontColors("Main", new Color(1f, 1f, 1f, 0.91f)),
			new FontColors("MainDarkish", new Color(0.9f, 0.9f, 0.9f, 0.91f)),
			new FontColors("MainDark", new Color(0.78f, 0.78f, 0.78f, 0.91f)),
			new FontColors("MainDarker", new Color(0.65f, 0.65f, 0.65f, 0.91f)),
			new FontColors("MainDarkest", new Color(0.44f, 0.44f, 0.44f, 0.91f)),
			new FontColors("Currency", new Color(1f, 0.8f, 0.27f, 1f)),
			new FontColors("Level", new Color(1f, 0.22f, 0.22f, 1f)),
			new FontColors("Timer", new Color(0.13f, 0.13f, 0.13f, 1f)),
			new FontColors("Friend", new Color(0.21f, 1f, 0.13f, 1f)),
			new FontColors("Upgrade", new Color(0.34f, 0.97f, 0.36f, 1f))
		};
		FirstMenuInitialization = true;
		UseVRDot = true;
		VRMenuDistance = 0.9f;
		PopupBreakLength = 25;
		FadeDepth = 300;
		FirstFade = true;
		TapVolume = 0.8f;
		BackVolume = 0.3f;
		UseIAP = true;
		AdsEnabledFree = true;
		AdsEnabledPro = true;
		HasRewardedVideos = true;
		MinutesBetweenInterstitialVideos = 7;
		VideoAdCacheDelay = 20;
		TargetVolume = -1f;
		UseNaquaticLeaderboards = true;
		PlayNameMaxLength = 20;
		kMaxLevel = 100;
		kFactor = 20;
		TimeBetweenPrizes = 3600;
		MinActionForReporting = 100;
		MinimumModeForMultiplayerSync = 1;
		MultiplayerAllowRematch = true;
		SecondsForGameCenterTimeout = 999999f;
	}

	public virtual void Awake()
	{
		if (!InstanceExists)
		{
			InstanceExists = true;
			gameObject.AddComponent(typeof(Settings));
			Menu = this;
			InitializeTouch();
			GUI = GameObject.Find("GUI");
			NewUI = GameObject.Find("UI");
			if (!(GUI == null) || !(NewUI == null))
			{
				StartCoroutine(InitializeMenus());
				InitializePopup();
				InitializeLoading();
				InitializeFade();
				InitializeAudio();
				InitializeIAP();
				InitializePrizes();
				InitializeAchievements();
				InitializeLeaderboards();
				InitializePush();
				StartCoroutine(InitializeVideoAds());
				InitializeUser();
				InitializeFriends();
				InitializeRematch();
				InitializeKeyboard();
				InitializePublishing();
			}
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual IEnumerator LoadGame(int Mode)
	{
		return new _0024LoadGame_0024995(Mode, this).GetEnumerator();
	}

	public static void GenerateRandom()
	{
		if (!RetainingRandomSeed)
		{
			MyKey = RandomCharacter() + RandomCharacter() + RandomCharacter();
			for (RandomSeed = UnityEngine.Random.Range(-RandomLimit, RandomLimit); RandomSeed == 0; RandomSeed = UnityEngine.Random.Range(-RandomLimit, RandomLimit))
			{
			}
		}
	}

	public static float RandomValue()
	{
		return (float)Mathf.Abs(RandomSeed) * 1f / (float)RandomLimit;
	}

	public static void GenRandomTable()
	{
		string text = string.Empty;
		int[] array = new int[2100];
		int num = 0;
		for (num = 0; num < Extensions.get_length((System.Array)array); num++)
		{
			array[num] = num % 210;
		}
		for (num = Extensions.get_length((System.Array)array) - 1; num > 0; num--)
		{
			int num2 = UnityEngine.Random.Range(0, num + 1);
			int num3 = array[num];
			array[num] = array[num2];
			array[num2] = num3;
		}
		for (num = 0; num < Extensions.get_length((System.Array)array); num++)
		{
			text = text + array[num] + ",";
		}
		Debug.Log("public static var randomTable : int[] = [" + text + "];");
	}

	[DllImport("__Internal")]
	public static extern void NaqSDKInit();

	public static void InitializeNaquaticSDK()
	{
	}

	public virtual void InitializeTouch()
	{
		Touches = new CustomTouch[0];
		StartCoroutine(CheckController());
		RecentlyHighlighted = new System.Collections.Generic.List<GameObject>();
	}

	public virtual bool Began(CustomTouch TheTouch)
	{
		return (TheTouch.phase == TouchPhase.Began && RemoveTouch(TheTouch)) ? true : false;
	}

	public virtual bool Moved(CustomTouch TheTouch)
	{
		return (TheTouch.phase == TouchPhase.Moved && RemoveTouch(TheTouch)) ? true : false;
	}

	public virtual bool Stationary(CustomTouch TheTouch)
	{
		return (TheTouch.phase == TouchPhase.Stationary && RemoveTouch(TheTouch)) ? true : false;
	}

	public virtual bool Ended(CustomTouch TheTouch)
	{
		return (TheTouch.phase == TouchPhase.Ended && RemoveTouch(TheTouch)) ? true : false;
	}

	public virtual bool RemoveTouch(CustomTouch TheTouch)
	{
		int result;
		int num;
		if (TheTouch.TouchesAllMember)
		{
			result = 1;
		}
		else
		{
			if (TheTouch.fingerId >= 0)
			{
				num = default(int);
				while (num < Extensions.get_length((System.Array)Touches))
				{
					if (TheTouch.fingerId != Touches[num].fingerId)
					{
						num++;
						continue;
					}
					goto IL_0041;
				}
			}
			result = 0;
		}
		goto IL_0069;
		IL_0041:
		Touches[num].fingerId = -1;
		result = 1;
		goto IL_0069;
		IL_0069:
		return (byte)result != 0;
	}

	public virtual void CheckButtons()
	{
		//Discarded unreachable code: IL_0da2, IL_1089
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (HeyzapAds.OnBackPressed() || CBExternal.onBackPressed())
			{
				return;
			}
			if (IsPublishingProject && PublishingCaptureBackButton)
			{
				SendMessage("PublishingBackButton", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				Application.Quit();
			}
		}
		MouseTouched = false;
		TouchCountLastFrame = Input.touchCount;
		if (!MouseTouched)
		{
			Touches = new CustomTouch[Input.touchCount];
		}
		else
		{
			Touches = new CustomTouch[Input.touchCount + 1];
		}
		int i;
		for (i = default(int); i < Input.touchCount; i++)
		{
			Touches[i] = new CustomTouch();
			Touches[i].fingerId = Input.GetTouch(i).fingerId;
			Touches[i].position = Input.GetTouch(i).position;
			Touches[i].phase = Input.GetTouch(i).phase;
			Touches[i].delta = Input.GetTouch(i).deltaPosition;
			Touches[i].time = Input.GetTouch(i).deltaTime;
		}
		if (MouseTouched)
		{
			Touches[i] = new CustomTouch();
			Touches[i].fingerId = 999;
			Touches[i].position = Input.mousePosition;
			Touches[i].delta = Touches[i].position - MousePositionLastFrame;
			Touches[i].time = Time.deltaTime;
			if (Input.GetMouseButtonDown(0))
			{
				Touches[i].phase = TouchPhase.Began;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				Touches[i].phase = TouchPhase.Ended;
			}
			else if (Input.GetMouseButton(0))
			{
				if (MousePositionLastFrame != (Vector2)Input.mousePosition)
				{
					Touches[i].phase = TouchPhase.Moved;
				}
				else
				{
					Touches[i].phase = TouchPhase.Stationary;
				}
			}
		}
		MousePositionLastFrame = Input.mousePosition;
		if (NewUI != null)
		{
			int num = default(int);
			TouchObject[] array = new TouchObject[Extensions.get_length((System.Array)Touches)];
			if (Touches != null && Extensions.get_length((System.Array)Touches) > 0)
			{
				TouchesAll = new CustomTouch[Extensions.get_length((System.Array)Touches)];
				for (int j = default(int); j < Extensions.get_length((System.Array)Touches); j++)
				{
					TouchesAll[j] = new CustomTouch();
					TouchesAll[j].fingerId = Touches[j].fingerId;
					TouchesAll[j].position = Touches[j].position;
					TouchesAll[j].phase = Touches[j].phase;
					TouchesAll[j].delta = Touches[j].delta;
					TouchesAll[j].time = Touches[j].time;
					TouchesAll[j].TouchesAllMember = true;
				}
			}
			else
			{
				TouchesAll = new CustomTouch[0];
			}
			int k = 0;
			CustomTouch[] touches = Touches;
			for (int length = touches.Length; k < length; k++)
			{
				int num2 = ((touches[k].fingerId != 999) ? touches[k].fingerId : (-1));
				array[num] = new TouchObject(num2, EventSystem.current.IsPointerOverGameObject(num2));
				num++;
				if (touches[k].phase == TouchPhase.Ended && !RuntimeServices.EqualityOperator(ActiveButtonsLastFrame, null))
				{
					for (int l = default(int); l < Extensions.get_length((System.Array)ActiveButtonsLastFrame); l++)
					{
						if (ActiveButtonsLastFrame[l].TouchID == num2)
						{
							if (ActiveButtonsLastFrame[l].IsOverObject)
							{
								RemoveTouch(touches[k]);
							}
							break;
						}
					}
				}
				else if (EventSystem.current.IsPointerOverGameObject(num2))
				{
					RemoveTouch(touches[k]);
				}
			}
			ActiveButtonsLastFrame = array;
			return;
		}
		for (int m = default(int); m < Extensions.get_length((System.Array)Touches); m++)
		{
			if (Touches[m].phase == TouchPhase.Began)
			{
				if (!RuntimeServices.EqualityOperator(Keyboard, null) && Keyboard.active)
				{
					Keyboard.active = false;
				}
				if (KeyboardRestrictTouch)
				{
					Touches = new CustomTouch[0];
					KeyboardRestrictTouch = false;
				}
				break;
			}
		}
		if (IsFadingOut)
		{
			Touches = new CustomTouch[0];
		}
		if (Chartboost.isImpressionVisible())
		{
			Touches = new CustomTouch[0];
		}
		SelectedButton = string.Empty;
		int n = 0;
		CustomTouch[] touches2 = Touches;
		Transform transform2 = default(Transform);
		for (int length2 = touches2.Length; n < length2; n++)
		{
			ReleasedTheButton = false;
			if (TouchOnMenuButton >= 0 && TouchOnMenuButton != touches2[n].fingerId)
			{
				continue;
			}
			if (TouchOnMenuButton == touches2[n].fingerId)
			{
				RemoveTouch(touches2[n]);
			}
			if (touches2[n].phase == TouchPhase.Began)
			{
				bool flag = default(bool);
				int num3 = default(int);
				GameObject[] array2 = new GameObject[10];
				int num4;
				for (num4 = default(int); num4 < Scrolls.Length; num4++)
				{
					if (Scrolls[num4].activeInHierarchy && CheckButtonTouch((GUITexture)Scrolls[num4].GetComponent(typeof(GUITexture)), num4, touches2[n]))
					{
						array2[num3] = Scrolls[num4];
						num3++;
						flag = true;
						break;
					}
				}
				for (int j = 0; j < Buttons.Length; j++)
				{
					if (Buttons[j].activeInHierarchy && CheckButtonTouch((GUITexture)Buttons[j].GetComponent(typeof(GUITexture)), j, touches2[n]))
					{
						array2[num3] = Buttons[j];
						num3++;
					}
				}
				if (num3 > 0)
				{
					GameObject gameObject = null;
					for (int num5 = default(int); num5 < num3; num5++)
					{
						if (gameObject == null)
						{
							gameObject = array2[num5];
						}
						else if (!(array2[num5].transform.position.z <= gameObject.transform.position.z))
						{
							gameObject = array2[num5];
						}
					}
					if (flag && gameObject == Scrolls[num4])
					{
						TouchOnMenuButton = touches2[n].fingerId;
						RemoveTouch(touches2[n]);
						ActiveScroll = Scrolls[num4];
						ActiveScrollLimit = RuntimeServices.UnboxSingle(ScrollsLimitArray[num4]);
						CurrentScrollHorizontal = ScrollsDirection[num4];
						Inertia = 0f;
						StopCoroutine("ScrollInertia");
					}
					else
					{
						TouchOnMenuButton = touches2[n].fingerId;
						RemoveTouch(touches2[n]);
						HighlightedButton = gameObject;
						HighlightedButtonOriginalColor = ((GUITexture)gameObject.GetComponent(typeof(GUITexture))).color;
						HighlightedButtonOriginalEnabled = ((GUITexture)gameObject.GetComponent(typeof(GUITexture))).enabled;
						((GUITexture)gameObject.GetComponent(typeof(GUITexture))).color = new Color(0.25f, 0.25f, 0.25f, ((GUITexture)gameObject.GetComponent(typeof(GUITexture))).color.a);
						if (HighlightedButton.name == "EXIT")
						{
							float a = ((GUITexture)HighlightedButton.GetComponent(typeof(GUITexture))).color.a + 0.15f;
							Color color = ((GUITexture)HighlightedButton.GetComponent(typeof(GUITexture))).color;
							float num6 = (color.a = a);
							Color color3 = (((GUITexture)HighlightedButton.GetComponent(typeof(GUITexture))).color = color);
						}
						((GUITexture)gameObject.GetComponent(typeof(GUITexture))).enabled = true;
						SendMessage("ButtonWasTouched", HighlightedButton.name, SendMessageOptions.DontRequireReceiver);
						if (gameObject.transform.childCount != 0)
						{
							IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(gameObject.transform);
							if (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								if (!(obj is Transform))
								{
									obj = RuntimeServices.Coerce(obj, typeof(Transform));
								}
								Transform transform = (Transform)obj;
								transform2 = transform;
								UnityRuntimeServices.Update(enumerator, transform);
							}
						}
						if (transform2 != null)
						{
							HighlightedText = transform2.gameObject;
							HighlightedTextOriginalColor = ((GUIText)transform2.GetComponent(typeof(GUIText))).material.color;
							((GUIText)transform2.GetComponent(typeof(GUIText))).material.color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
						}
						if (TapSound != null && !MuteSounds)
						{
							EffectsSource.clip = TapSound;
							EffectsSource.volume = TapVolume;
							EffectsSource.Play();
						}
					}
				}
			}
			else if (touches2[n].phase == TouchPhase.Moved && ActiveScroll != null)
			{
				if (CurrentScrollHorizontal)
				{
					float x = ActiveScroll.transform.localPosition.x + touches2[n].delta.x / (float)Screen.width;
					Vector3 localPosition = ActiveScroll.transform.localPosition;
					float num7 = (localPosition.x = x);
					Vector3 vector2 = (ActiveScroll.transform.localPosition = localPosition);
					Inertia += touches2[n].delta.x / Settings.DPI * 3f;
					float x2 = Mathf.Clamp(ActiveScroll.transform.localPosition.x, ActiveScrollLimit * 960f / (float)Screen.width * Settings.Scale / 2f, 0f);
					Vector3 localPosition2 = ActiveScroll.transform.localPosition;
					float num8 = (localPosition2.x = x2);
					Vector3 vector4 = (ActiveScroll.transform.localPosition = localPosition2);
				}
				else
				{
					float y = ActiveScroll.transform.localPosition.y + touches2[n].delta.y / (float)Screen.height;
					Vector3 localPosition3 = ActiveScroll.transform.localPosition;
					float num9 = (localPosition3.y = y);
					Vector3 vector6 = (ActiveScroll.transform.localPosition = localPosition3);
					Inertia += touches2[n].delta.y / Settings.DPI * 3f;
					float y2 = Mathf.Clamp(ActiveScroll.transform.localPosition.y, 0f, ActiveScrollLimit * 640f / (float)Screen.height * Settings.Scale / 2f);
					Vector3 localPosition4 = ActiveScroll.transform.localPosition;
					float num10 = (localPosition4.y = y2);
					Vector3 vector8 = (ActiveScroll.transform.localPosition = localPosition4);
				}
			}
			else if (touches2[n].phase == TouchPhase.Stationary && ActiveScroll != null)
			{
				Inertia -= Inertia * Time.deltaTime * 18f;
			}
			if (touches2[n].phase != TouchPhase.Ended)
			{
				continue;
			}
			if (HighlightedButton != null)
			{
				for (int num11 = default(int); num11 < Buttons.Length; num11++)
				{
					if (Buttons[num11].activeInHierarchy && CheckButtonTouch((GUITexture)Buttons[num11].GetComponent(typeof(GUITexture)), num11, touches2[n]) && HighlightedButton == Buttons[num11])
					{
						StartCoroutine(ButtonPress(HighlightedButton));
						break;
					}
					if (Buttons[num11].activeInHierarchy && CheckButtonTouch((GUITexture)Buttons[num11].GetComponent(typeof(GUITexture)), num11, touches2[n]))
					{
						SendMessage("ButtonWasUntouched", Buttons[num11].name, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			if (ActiveScroll != null)
			{
				StartCoroutine("ScrollInertia", ActiveScroll);
			}
			if (!ReleasedTheButton)
			{
				ReleaseButton();
			}
		}
		if (ControllerButton(6) == 1 && ChosenButton != null)
		{
			if (!IsVR)
			{
				HighlightButton(ControllerHighestButton());
			}
			StartCoroutine(ButtonPress(ChosenButton));
			if (ChosenButton.name == "EXIT" || ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).texture.name == "Back" + Settings.Suffix)
			{
				for (int l = RecentlyHighlighted.Count - 1; l >= 0; l--)
				{
					if (RecentlyHighlighted[l].activeInHierarchy && ((GUITexture)RecentlyHighlighted[l].GetComponent(typeof(GUITexture))).enabled)
					{
						HighlightButton(RecentlyHighlighted[l]);
						break;
					}
				}
			}
		}
		if (ControllerButton(7) != 1)
		{
			return;
		}
		bool flag2 = default(bool);
		for (int l = 0; l < Extensions.get_length((System.Array)Buttons); l++)
		{
			if (!Buttons[l].activeInHierarchy || !((GUITexture)Buttons[l].GetComponent(typeof(GUITexture))).enabled)
			{
				continue;
			}
			if (Buttons[l].name == "EXIT")
			{
				HighlightButton(Buttons[l]);
				flag2 = true;
			}
			else if (((GUITexture)Buttons[l].GetComponent(typeof(GUITexture))).texture.name == "Back" + Settings.Suffix)
			{
				GameObject chosenButton = ChosenButton;
				HighlightButton(Buttons[l]);
				if (ControllerHighestButton() == Buttons[l])
				{
					HighlightButton(Buttons[l]);
					flag2 = true;
					break;
				}
				HighlightButton(chosenButton);
			}
		}
		if (!(ChosenButton != null) || !flag2)
		{
			return;
		}
		StartCoroutine(ButtonPress(ChosenButton));
		for (int l = RecentlyHighlighted.Count - 1; l >= 0; l--)
		{
			if (RecentlyHighlighted[l].activeInHierarchy && ((GUITexture)RecentlyHighlighted[l].GetComponent(typeof(GUITexture))).enabled)
			{
				HighlightButton(RecentlyHighlighted[l]);
				break;
			}
		}
	}

	public virtual IEnumerator ButtonPress(GameObject TheButt)
	{
		return new _0024ButtonPress_00241000(TheButt, this).GetEnumerator();
	}

	public virtual void HighlightButton(GameObject TheButton)
	{
		ChosenButton = TheButton;
		CurrentY = ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.y;
		CurrentX = ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.x;
		if (ControllerHighlightedButton != null)
		{
			((GUITexture)ControllerHighlightedButton.GetComponent(typeof(GUITexture))).color = ControllerHighlightedButtonOriginalColor;
		}
		for (int i = default(int); i < RecentlyHighlighted.Count; i++)
		{
			if (RecentlyHighlighted[i] == ChosenButton)
			{
				RecentlyHighlighted.RemoveAt(i);
			}
		}
		RecentlyHighlighted.Add(ChosenButton);
		ControllerHighlightedButtonOriginalColor = ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).color;
		((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).color = new Color(1f, 1f, 1f, ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).color.a);
		ControllerHighlightedButton = ChosenButton;
	}

	public virtual void Highlight(string Name)
	{
		if (!IsController)
		{
			return;
		}
		for (int i = default(int); i < Extensions.get_length((System.Array)Buttons); i++)
		{
			if (Buttons[i].activeInHierarchy && ((GUITexture)Buttons[i].GetComponent(typeof(GUITexture))).enabled && Buttons[i].name == Name)
			{
				HighlightButton(Buttons[i]);
				HighlightButton(ControllerHighestButton());
				break;
			}
		}
	}

	public virtual IEnumerator ScrollInertia(GameObject Scroll)
	{
		return new _0024ScrollInertia_00241006(Scroll, this).GetEnumerator();
	}

	public virtual void ReleaseButton()
	{
		TouchOnMenuButton = -1;
		if (HighlightedButton != null)
		{
			((GUITexture)HighlightedButton.GetComponent(typeof(GUITexture))).color = HighlightedButtonOriginalColor;
			((GUITexture)HighlightedButton.GetComponent(typeof(GUITexture))).enabled = HighlightedButtonOriginalEnabled;
			HighlightedButton = null;
		}
		if (HighlightedText != null)
		{
			((GUIText)HighlightedText.GetComponent(typeof(GUIText))).material.color = HighlightedTextOriginalColor;
			HighlightedText = null;
		}
		if (ActiveScroll != null)
		{
			ActiveScroll = null;
		}
	}

	public virtual bool CheckButtonTouch(GUITexture TargetButton, int ButtonArraySlot, CustomTouch Touch)
	{
		int num;
		if (IsVR)
		{
			num = default(int);
			while (num < Extensions.get_length((System.Array)GUITextures3D))
			{
				if (!(TargetButton == GUITextures[num]))
				{
					num++;
					continue;
				}
				goto IL_002a;
			}
		}
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		Rect rect = default(Rect);
		Vector2 vector2 = ButtonsTouchZones[ButtonArraySlot];
		rect = TargetButton.pixelInset;
		int result;
		if (!(rect.width <= 0f))
		{
			if (!(rect.height <= 0f))
			{
				Vector2 vector3 = new Vector2(rect.width / 2f * (1f - vector2.x), rect.height / 2f * (1f - vector2.y));
				if (Touch.position.x <= vector.x / 2f + rect.x + vector3.x || Touch.position.x >= vector.x / 2f + rect.x + rect.width - vector3.x || Touch.position.y <= vector.y / 2f + rect.y + vector3.y || Touch.position.y >= vector.y / 2f + rect.y + rect.height - vector3.y)
				{
					goto IL_048f;
				}
				result = 1;
			}
			else
			{
				Vector2 vector3 = new Vector2(rect.width / 2f * (1f - vector2.x), (0f - rect.height) / 2f * (1f - vector2.y));
				if (Touch.position.x <= vector.x / 2f + rect.x + vector3.x || Touch.position.x >= vector.x / 2f + rect.x + rect.width - vector3.x || Touch.position.y <= vector.y / 2f + rect.y + vector3.y + rect.height || Touch.position.y >= vector.y / 2f + rect.y - vector3.y)
				{
					goto IL_048f;
				}
				result = 1;
			}
		}
		else if (!(rect.height <= 0f))
		{
			Vector2 vector3 = new Vector2((0f - rect.width) / 2f * (1f - vector2.x), rect.height / 2f * (1f - vector2.y));
			if (Touch.position.x <= vector.x / 2f + rect.x + vector3.x + rect.width || Touch.position.x >= vector.x / 2f + rect.x - vector3.x || Touch.position.y <= vector.y / 2f + rect.y + vector3.y || Touch.position.y >= vector.y / 2f + rect.y + rect.height - vector3.y)
			{
				goto IL_048f;
			}
			result = 1;
		}
		else
		{
			Vector2 vector3 = new Vector2((0f - rect.width) / 2f * (1f - vector2.x), (0f - rect.height) / 2f * (1f - vector2.y));
			if (Touch.position.x <= vector.x / 2f + rect.x + vector3.x + rect.width || Touch.position.x >= vector.x / 2f + rect.x - vector3.x || Touch.position.y <= vector.y / 2f + rect.y + vector3.y + rect.height || Touch.position.y >= vector.y / 2f + rect.y - vector3.y)
			{
				goto IL_048f;
			}
			result = 1;
		}
		goto IL_0490;
		IL_048f:
		result = 0;
		goto IL_0490;
		IL_002a:
		result = ((LitButton == GUITextures3D[num]) ? 1 : 0);
		goto IL_0490;
		IL_0490:
		return (byte)result != 0;
	}

	public virtual void ButtonWasPressedBroadcast(string Name)
	{
		SelectedButton = Name;
		if (TapSound != null && !MuteSounds)
		{
			EffectsSource.clip = TapSound;
			EffectsSource.volume = TapVolume;
			EffectsSource.Play();
		}
		if (!IsTutorial || Name == TutorialAllow || TutorialAllow == string.Empty)
		{
			if (IsTutorial && Name == TutorialAllow)
			{
				TutorialState++;
			}
			SendMessage("ButtonWasPressed", Name, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void InputFieldChangedBroadcast(string Name)
	{
		SendMessage("InputFieldChanged", Name, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void SliderChangedBroadcast(string Name, float Value)
	{
		SliderChangedValue = Value;
		SendMessage("SliderChanged", Name, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void ButtonWasPressed(string Name)
	{
		if (Begins("Popup") || Name == "Popup")
		{
			PopupWasPressed(Name);
		}
		else if (CustomKeyboard != null && Begins("Keyboard"))
		{
			KeyboardWasPressed(Name);
		}
		else if (Begins("MORE"))
		{
			MoreWasPressed(Name);
		}
		else if (Begins("Leaderboards"))
		{
			LeaderboardsWasPressed(Name);
		}
		else if (Begins("Login"))
		{
			LoginWasPressed(Name);
		}
		else if (Begins("Friend"))
		{
			FriendsWasPressed(Name);
		}
		else if (Begins("GameOver"))
		{
			RematchWasPressed(Name);
		}
		else if (AndroidStorefront() == AndroidStorefronts.Google && Begins("GoogleGameServices"))
		{
			GoogleGameServicesWasPressed(Name);
		}
	}

	public virtual IEnumerator CheckController()
	{
		return new _0024CheckController_00241019(this).GetEnumerator();
	}

	public virtual GameObject ControllerHighestButton()
	{
		object result;
		if (ChosenButton != null)
		{
			GameObject gameObject = ChosenButton;
			for (int i = default(int); i < Extensions.get_length((System.Array)Buttons); i++)
			{
				if (Buttons[i].activeInHierarchy && ((GUITexture)Buttons[i].GetComponent(typeof(GUITexture))).enabled && !(Buttons[i].transform.position.z <= gameObject.transform.position.z) && ((GUITexture)Buttons[i].GetComponent(typeof(GUITexture))).HitTest(new Vector3(((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.x + ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.width / 2f + (float)(Screen.width / 2), ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.y + ((GUITexture)ChosenButton.GetComponent(typeof(GUITexture))).pixelInset.height / 2f + (float)(Screen.height / 2), 0f)))
				{
					gameObject = Buttons[i];
				}
			}
			result = gameObject;
		}
		else
		{
			result = null;
		}
		return (GameObject)result;
	}

	public static int ControllerButton(int Choice)
	{
		//Discarded unreachable code: IL_0056
		string buttonName = null;
		int result;
		if (!IsController)
		{
			result = 3;
		}
		else if (Choice == 4 || Choice == 5)
		{
			if (!(ControllerAxis(4) <= 0.4f))
			{
				if (Menu.TriggerRightReleased)
				{
					Menu.TriggerRightReleased = false;
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 3;
			}
		}
		else
		{
			if (Choice == 6)
			{
				buttonName = "Button 0";
			}
			if (Choice == 7)
			{
				buttonName = "Button 1";
			}
			result = (Input.GetButtonUp(buttonName) ? 2 : ((!Input.GetButton(buttonName)) ? 3 : (Input.GetButtonDown(buttonName) ? 1 : 0)));
		}
		return result;
	}

	public static float ControllerAxis(int Choice)
	{
		float result;
		if (!IsController)
		{
			result = 0f;
		}
		else
		{
			switch (Choice)
			{
			case 5:
				result = Input.GetAxis("9th Axis");
				break;
			case 4:
				result = Input.GetAxis("10th Axis");
				break;
			case 0:
				result = Input.GetAxis("X Axis");
				break;
			case 1:
				result = Input.GetAxis("Y Axis");
				break;
			case 2:
				result = Input.GetAxis("4th Axis");
				break;
			case 3:
				result = Input.GetAxis("5th Axis");
				break;
			default:
				result = 0f;
				break;
			}
		}
		return result;
	}

	public virtual IEnumerator InitializeMenus()
	{
		return new _0024InitializeMenus_00241029(this).GetEnumerator();
	}

	public virtual void TraverseMenuHierarchy(Transform Root)
	{
		_0024TraverseMenuHierarchy_0024locals_0024551 _0024TraverseMenuHierarchy_0024locals_0024 = new _0024TraverseMenuHierarchy_0024locals_0024551();
		_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139 = UnityRuntimeServices.GetEnumerator(Root);
		while (_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139.MoveNext())
		{
			object obj = _0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (NewUI != null)
			{
				if (RuntimeServices.EqualityOperator(RootParents, null))
				{
					RootParents = new System.Collections.Generic.List<GameObject>();
				}
				if (Root == MainCanvas.transform)
				{
					RootParents.Add(transform.gameObject);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
				if ((bool)(Button)transform.gameObject.GetComponent(typeof(Button)))
				{
					((Button)transform.gameObject.GetComponent(typeof(Button))).onClick.AddListener(new _0024TraverseMenuHierarchy_0024closure_0024135(transform, this, _0024TraverseMenuHierarchy_0024locals_0024).Invoke);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
				if ((bool)(InputField)transform.gameObject.GetComponent(typeof(InputField)))
				{
					((InputField)transform.gameObject.GetComponent(typeof(InputField))).onValueChange.AddListener(_0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00240.Adapt(new _0024TraverseMenuHierarchy_0024closure_0024136(transform, this, _0024TraverseMenuHierarchy_0024locals_0024).Invoke));
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
				if ((bool)(Slider)transform.gameObject.GetComponent(typeof(Slider)))
				{
					((Slider)transform.gameObject.GetComponent(typeof(Slider))).onValueChanged.AddListener(_0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00241.Adapt(new _0024TraverseMenuHierarchy_0024closure_0024137(this, transform, _0024TraverseMenuHierarchy_0024locals_0024).Invoke));
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
				if ((bool)(Text)transform.gameObject.GetComponent(typeof(Text)))
				{
					Text text = (Text)transform.gameObject.GetComponent(typeof(Text));
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
					UnityScript.Lang.Array array = text.text.Split("\""[0]);
					while (array.length > 1)
					{
						text.text = text.text.Replace("\"" + array[1].ToString() + "\"", Loc.L(array[1].ToString()));
						if (Extensions.get_length(array[1].ToString()) > 1 && array[1].ToString()[1].ToString() == array[1].ToString()[1].ToString().ToUpper())
						{
							text.text = text.text.ToUpper();
						}
						array = text.text.Split("\""[0]);
					}
				}
				if (transform.name == "MoreButtons" && Root.name == "More")
				{
					ProcessMoreImages(transform);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
			}
			else
			{
				if (transform.name == "-GUICamera")
				{
					GUICamera = transform.gameObject;
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
					continue;
				}
				if ((bool)(GUITexture)transform.gameObject.GetComponent(typeof(GUITexture)))
				{
					if (!FirstMenuInitialization && transform.gameObject.name == "Fade")
					{
						continue;
					}
					ResizeTexture((GUITexture)transform.gameObject.GetComponent(typeof(GUITexture)));
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
					ChildrenArray.Add(transform.gameObject);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
					UnityScript.Lang.Array array2 = transform.name.Split(" "[0]);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
					if (array2.length > 1)
					{
						for (int i = 1; i < array2.length; i++)
						{
							if (array2[i].ToString().StartsWith("B"))
							{
								ButtonsArray.Add(transform.gameObject);
								UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
								array2 = array2[i].ToString().Split(","[0]);
								if (array2.length > 1)
								{
									UnityScript.Lang.Array buttonsTouchZonesArray = ButtonsTouchZonesArray;
									object obj2 = array2[1];
									if (!(obj2 is string))
									{
										obj2 = RuntimeServices.Coerce(obj2, typeof(string));
									}
									float x = float.Parse((string)obj2);
									object obj3 = array2[2];
									if (!(obj3 is string))
									{
										obj3 = RuntimeServices.Coerce(obj3, typeof(string));
									}
									buttonsTouchZonesArray.Add(new Vector2(x, float.Parse((string)obj3)));
								}
								else
								{
									ButtonsTouchZonesArray.Add(new Vector2(1f, 1f));
								}
								if (transform.childCount == 0)
								{
									continue;
								}
								IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(transform);
								UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
								while (enumerator.MoveNext())
								{
									object obj4 = enumerator.Current;
									if (!(obj4 is Transform))
									{
										obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
									}
									Transform transform2 = (Transform)obj4;
									ChildrenArray.Add(transform2.gameObject);
									UnityRuntimeServices.Update(enumerator, transform2);
								}
							}
							else if (array2[i].ToString().StartsWith("S"))
							{
								ScrollsArray.Add(transform.gameObject);
								UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
								array2 = array2[i].ToString().Split(","[0]);
								if (RuntimeServices.EqualityOperator(array2[1], "H"))
								{
									ScrollsDirectionArray.Add(true);
								}
								else
								{
									ScrollsDirectionArray.Add(false);
								}
								UnityScript.Lang.Array scrollsLimitArray = ScrollsLimitArray;
								object obj5 = array2[2];
								if (!(obj5 is string))
								{
									obj5 = RuntimeServices.Coerce(obj5, typeof(string));
								}
								scrollsLimitArray.Add(float.Parse((string)obj5));
							}
						}
					}
				}
				else if ((bool)(GUIText)transform.gameObject.GetComponent(typeof(GUIText)))
				{
					ResizeText((GUIText)transform.gameObject.GetComponent(typeof(GUIText)));
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
					ChildrenArray.Add(transform.gameObject);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
				else
				{
					ParentsArray.Add(transform.gameObject);
					UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
				}
			}
			MenusArray.Add(transform.gameObject);
			UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
			TraverseMenuHierarchy(transform);
			UnityRuntimeServices.Update(_0024TraverseMenuHierarchy_0024locals_0024._0024_0024iterator_0024139, transform);
		}
	}

	public virtual IEnumerator DetectResolutionChanges()
	{
		return new _0024DetectResolutionChanges_00241051(this).GetEnumerator();
	}

	public virtual void ResolutionChanged()
	{
		Settings.GetScale();
		OriginalTextureIndex = 0;
		OriginalTextIndex = 0;
		for (int i = default(int); i < Extensions.get_length((System.Array)m_Menus); i++)
		{
			m_Menus[i].name = OriginalMenuNames[i];
		}
		TraverseMenuHierarchy(GUI.transform);
		for (int i = 0; i < Extensions.get_length((System.Array)m_Menus); i++)
		{
			UnityScript.Lang.Array array = m_Menus[i].name.Split(" "[0]);
			GameObject obj = m_Menus[i];
			object obj2 = array[0];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			obj.name = (string)obj2;
		}
	}

	public static void AddButtonListener(Button Butt, __Menus_AddButtonListener_0024callable1_00242022_61__ Func, int i)
	{
		_0024AddButtonListener_0024locals_0024552 _0024AddButtonListener_0024locals_0024 = new _0024AddButtonListener_0024locals_0024552();
		_0024AddButtonListener_0024locals_0024._0024Func = Func;
		_0024AddButtonListener_0024locals_0024._0024i = i;
		Butt.onClick.AddListener(new _0024AddButtonListener_0024closure_0024140(_0024AddButtonListener_0024locals_0024).Invoke);
	}

	public static void AddOnPointerDownListener(GameObject Obj, __Menus_AddButtonListener_0024callable1_00242022_61__ Func, int i)
	{
		_0024AddOnPointerDownListener_0024locals_0024553 _0024AddOnPointerDownListener_0024locals_0024 = new _0024AddOnPointerDownListener_0024locals_0024553();
		_0024AddOnPointerDownListener_0024locals_0024._0024Func = Func;
		_0024AddOnPointerDownListener_0024locals_0024._0024i = i;
		EventTrigger eventTrigger = (EventTrigger)Obj.AddComponent(typeof(EventTrigger));
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback.AddListener(_0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00242.Adapt(new _0024AddOnPointerDownListener_0024closure_0024141(_0024AddOnPointerDownListener_0024locals_0024).Invoke));
		eventTrigger.triggers.Add(entry);
	}

	public static void AddOnPointerEnterListener(GameObject Obj, __Menus_AddButtonListener_0024callable1_00242022_61__ Func, int i)
	{
		_0024AddOnPointerEnterListener_0024locals_0024554 _0024AddOnPointerEnterListener_0024locals_0024 = new _0024AddOnPointerEnterListener_0024locals_0024554();
		_0024AddOnPointerEnterListener_0024locals_0024._0024Func = Func;
		_0024AddOnPointerEnterListener_0024locals_0024._0024i = i;
		EventTrigger eventTrigger = (EventTrigger)Obj.AddComponent(typeof(EventTrigger));
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(_0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00242.Adapt(new _0024AddOnPointerEnterListener_0024closure_0024142(_0024AddOnPointerEnterListener_0024locals_0024).Invoke));
		eventTrigger.triggers.Add(entry);
	}

	public virtual bool Begins(string Name)
	{
		return (Extensions.get_length(SelectedButton) > Extensions.get_length(Name) && SelectedButton.Substring(0, Extensions.get_length(Name)) == Name) ? true : false;
	}

	public virtual bool Begins(string Name, string BeginningString)
	{
		return (Extensions.get_length(BeginningString) > Extensions.get_length(Name) && BeginningString.Substring(0, Extensions.get_length(Name)) == Name) ? true : false;
	}

	public virtual bool MenuParentExists(string Name)
	{
		if (NewUI != null)
		{
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(NewUI.transform);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (!(transform.name == Name))
				{
					continue;
				}
				goto IL_005c;
			}
		}
		else
		{
			int num = default(int);
			while (num < Parents.Length)
			{
				if (!(Parents[num].name == Name))
				{
					num++;
					continue;
				}
				goto IL_0097;
			}
		}
		int result = 0;
		goto IL_00b3;
		IL_00b3:
		return (byte)result != 0;
		IL_005c:
		result = 1;
		goto IL_00b3;
		IL_0097:
		result = 1;
		goto IL_00b3;
	}

	public virtual int Trim()
	{
		int result = default(int);
		return (!int.TryParse(SelectedButton.Substring(Extensions.get_length(SelectedButton) - 2, 2), out result)) ? int.Parse(SelectedButton.Substring(Extensions.get_length(SelectedButton) - 1, 1)) : int.Parse(SelectedButton.Substring(Extensions.get_length(SelectedButton) - 2, 2));
	}

	public virtual void RestartMenus()
	{
		string rhs = null;
		for (int i = default(int); i < Extensions.get_length((System.Array)m_Menus); i++)
		{
			if (!m_Menus[i])
			{
				Debug.LogError("Missing menu item. Last one was: " + rhs);
				continue;
			}
			m_Menus[i].SetActive(OriginalState[i]);
			rhs = m_Menus[i].name;
		}
	}

	public static void HideRootParents()
	{
		for (int i = default(int); i < RootParents.Count; i++)
		{
			RootParents[i].SetActive(false);
		}
	}

	public virtual void Sho(string MenuName)
	{
		if (NewUI != null)
		{
			FindActiveOrInactive(NewUI, MenuName).SetActive(true);
			return;
		}
		GameObject gameObject = null;
		for (int i = default(int); i < Parents.Length; i++)
		{
			if (MenuName == Parents[i].name)
			{
				Parents[i].SetActive(true);
				gameObject = Parents[i];
				break;
			}
		}
		for (int j = default(int); j < Children.Length; j++)
		{
			if (MenuName == Children[j].name)
			{
				Children[j].SetActive(true);
				gameObject = Children[j];
				break;
			}
		}
	}

	public virtual void HoldSho(GameObject Obj)
	{
	}

	public virtual GameObject FindActiveOrInactive(GameObject Root, string Name)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(Root.transform);
		object result;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (transform.name == Name)
				{
					result = transform.gameObject;
					break;
				}
				FindActiveOrInactive(transform.gameObject, Name);
				UnityRuntimeServices.Update(enumerator, transform);
				continue;
			}
			result = null;
			break;
		}
		return (GameObject)result;
	}

	public virtual void Hid(string MenuName)
	{
		if (NewUI != null)
		{
			FindActiveOrInactive(NewUI, MenuName).SetActive(false);
			return;
		}
		if (MenuName == "ALL")
		{
			for (int i = default(int); i < Parents.Length; i++)
			{
				Parents[i].SetActive(false);
			}
			return;
		}
		for (int j = default(int); j < Parents.Length; j++)
		{
			if (MenuName == Parents[j].name)
			{
				Parents[j].SetActive(false);
				break;
			}
		}
		for (int k = default(int); k < Children.Length; k++)
		{
			if (MenuName == Children[k].name)
			{
				Children[k].SetActive(false);
				break;
			}
		}
	}

	public virtual void ShoRec(string MenuName)
	{
		if (NewUI != null)
		{
			Debug.LogError("ShoRec() not supported in new UI");
			return;
		}
		for (int i = default(int); i < Parents.Length; i++)
		{
			if (MenuName == Parents[i].name)
			{
				Parents[i].SetActive(true);
				TraverseChildren(Parents[i].transform, true);
			}
		}
	}

	public virtual void HidRec(string MenuName)
	{
		if (NewUI != null)
		{
			Debug.LogError("HidRec() not supported in New UI");
			return;
		}
		for (int i = default(int); i < Parents.Length; i++)
		{
			if (MenuName == Parents[i].name)
			{
				Parents[i].SetActive(false);
				TraverseChildren(Parents[i].transform, false);
			}
		}
	}

	public virtual void TraverseChildren(Transform TheParent, bool MakeActive)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(TheParent);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (transform.childCount != 0)
			{
				transform.gameObject.SetActive(MakeActive);
				UnityRuntimeServices.Update(enumerator, transform);
			}
			TraverseChildren(transform, MakeActive);
			UnityRuntimeServices.Update(enumerator, transform);
		}
	}

	public virtual Component Get(string MenuName)
	{
		int num;
		int num2;
		if (NewUI != null)
		{
			Debug.LogError("Get() isn't supported by our new UI");
		}
		else
		{
			num = default(int);
			while (num < Children.Length)
			{
				if (!Children[num].activeInHierarchy || !(Children[num].name == MenuName))
				{
					num++;
					continue;
				}
				goto IL_0056;
			}
			num = 0;
			while (num < Children.Length)
			{
				if (!(Children[num].name == MenuName))
				{
					num++;
					continue;
				}
				goto IL_00f2;
			}
			num2 = default(int);
			while (num2 < Parents.Length)
			{
				if (!(Parents[num2].name == MenuName))
				{
					num2++;
					continue;
				}
				goto IL_0194;
			}
		}
		Debug.Log(MenuName + " not found");
		object result = null;
		goto IL_01cc;
		IL_01cc:
		return (Component)result;
		IL_00f2:
		result = ((!(GUITexture)Children[num].GetComponent(typeof(GUITexture))) ? ((GUIElement)(GUIText)Children[num].GetComponent(typeof(GUIText))) : ((GUIElement)(GUITexture)Children[num].GetComponent(typeof(GUITexture))));
		goto IL_01cc;
		IL_0194:
		result = Parents[num2].transform;
		goto IL_01cc;
		IL_0056:
		result = ((!(GUITexture)Children[num].GetComponent(typeof(GUITexture))) ? ((GUIElement)(GUIText)Children[num].GetComponent(typeof(GUIText))) : ((GUIElement)(GUITexture)Children[num].GetComponent(typeof(GUITexture))));
		goto IL_01cc;
	}

	public virtual void ResizeTexture(GUITexture Target)
	{
		UnityScript.Lang.Array array = Target.gameObject.name.Split(" "[0]);
		object obj = array[0];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		if (!FirstMenuInitialization)
		{
			Target.texture = null;
		}
		if (text == "EXIT" || text == "DARK")
		{
			Target.pixelInset = new Rect(-Screen.width / 2 - 20, -Screen.height / 2 - 20, Screen.width + 40, Screen.height + 40);
			Target.texture = DarkTexture;
			GUITexturesArray.Add(Target);
			VRCreateGUI(Target.gameObject, true, true);
			return;
		}
		bool flag = default(bool);
		if (array.length > 1)
		{
			for (int i = 1; i < array.length; i++)
			{
				if (array[i].ToString().StartsWith("S"))
				{
					flag = true;
				}
			}
		}
		int result = default(int);
		Transform parent = Target.transform;
		bool flag2 = true;
		UnityScript.Lang.Array array3 = default(UnityScript.Lang.Array);
		while (flag2)
		{
			for (int j = 1; j < array.length; j++)
			{
				if (array[j].ToString().StartsWith("'"))
				{
					text = array[j].ToString().Substring(1, array[j].ToString().Length - 2);
				}
				UnityScript.Lang.Array array2 = array[j].ToString().Split(","[0]);
				object obj2 = array2[0];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				if (int.TryParse((string)obj2, out result))
				{
					array3 = array[j].ToString().Split(","[0]);
					flag2 = false;
				}
			}
			parent = parent.parent;
			array = parent.name.Split(" "[0]);
		}
		object obj3 = array3[0];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		int num = int.Parse((string)obj3);
		object obj4 = array3[1];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		int num2 = int.Parse((string)obj4);
		float scale = Settings.Scale;
		if (text == "MORE")
		{
			text = ProcessMoreImage(Target);
		}
		if (!flag)
		{
			Texture2D texture2D = default(Texture2D);
			if (Settings.Language != "English")
			{
				texture2D = (Texture2D)Resources.Load("Localization/" + Settings.Language + "/" + text + Settings.Suffix);
				if (texture2D == null && Settings.Suffix == "@2x~ipad")
				{
					texture2D = (Texture2D)Resources.Load(text + "@2x");
				}
			}
			if (texture2D == null)
			{
				texture2D = (Texture2D)Resources.Load(text + Settings.Suffix);
				if (texture2D == null && Settings.Suffix == "@2x~ipad")
				{
					texture2D = (Texture2D)Resources.Load(text + "@2x");
				}
			}
			if (text != string.Empty)
			{
				if (texture2D == null)
				{
					Debug.LogError("Couldn't find texture with name: " + text);
				}
				Vector2 vector = new Vector2(texture2D.width, texture2D.height);
				Target.texture = texture2D;
			}
		}
		if (FirstMenuInitialization)
		{
			OriginalTexturePositions.Add(Target.pixelInset);
		}
		else
		{
			Target.pixelInset = (Rect)OriginalTexturePositions[OriginalTextureIndex];
			OriginalTextureIndex++;
		}
		int num3 = (int)(Target.pixelInset.width / 2f);
		int num4 = (int)(Target.pixelInset.height / 2f);
		float num5 = Target.pixelInset.width / 2f * scale;
		Rect pixelInset = Target.pixelInset;
		float num7 = (pixelInset.width = num5);
		Rect rect2 = (Target.pixelInset = pixelInset);
		float num8 = Target.pixelInset.height / 2f * scale;
		Rect pixelInset2 = Target.pixelInset;
		float num10 = (pixelInset2.height = num8);
		Rect rect4 = (Target.pixelInset = pixelInset2);
		int num11 = 480;
		int num12 = 320;
		if (App.IsPortrait)
		{
			num11 = 320;
			num12 = 480;
		}
		int width = Screen.width;
		int height = Screen.height;
		if (IsVR)
		{
			width = (int)(480f * scale);
			height = (int)(320f * scale);
		}
		else
		{
			width = (int)ScreenSafeArea.width;
			height = (int)ScreenSafeArea.height;
		}
		switch (num)
		{
		case -1:
		{
			float num19 = (float)(-width / 2) - ((float)(-num11) - Target.pixelInset.x) * scale / 2f;
			Rect pixelInset5 = Target.pixelInset;
			float num21 = (pixelInset5.x = num19);
			Rect rect10 = (Target.pixelInset = pixelInset5);
			break;
		}
		case 0:
		{
			float num16 = (Target.pixelInset.x + (float)(num3 / 2)) * scale / 2f - Target.pixelInset.width / 4f;
			Rect pixelInset4 = Target.pixelInset;
			float num18 = (pixelInset4.x = num16);
			Rect rect8 = (Target.pixelInset = pixelInset4);
			break;
		}
		case 1:
		{
			float num13 = (float)(width / 2) - ((float)num11 - Target.pixelInset.x - (float)num3) * scale / 2f - Target.pixelInset.width / 2f;
			Rect pixelInset3 = Target.pixelInset;
			float num15 = (pixelInset3.x = num13);
			Rect rect6 = (Target.pixelInset = pixelInset3);
			break;
		}
		}
		switch (num2)
		{
		case -1:
		{
			float num28 = (float)(-height / 2) - ((float)(-num12) - Target.pixelInset.y) * scale / 2f;
			Rect pixelInset8 = Target.pixelInset;
			float num30 = (pixelInset8.y = num28);
			Rect rect16 = (Target.pixelInset = pixelInset8);
			break;
		}
		case 0:
		{
			float num25 = (Target.pixelInset.y + (float)(num4 / 2)) * scale / 2f - Target.pixelInset.height / 4f;
			Rect pixelInset7 = Target.pixelInset;
			float num27 = (pixelInset7.y = num25);
			Rect rect14 = (Target.pixelInset = pixelInset7);
			break;
		}
		case 1:
		{
			float num22 = (float)(height / 2) - ((float)num12 - Target.pixelInset.y - (float)num4) * scale / 2f - Target.pixelInset.height / 2f;
			Rect pixelInset6 = Target.pixelInset;
			float num24 = (pixelInset6.y = num22);
			Rect rect12 = (Target.pixelInset = pixelInset6);
			break;
		}
		}
		GUITexturesArray.Add(Target);
		VRCreateGUI(Target.gameObject, true, false);
	}

	public virtual void ResizeText(GUIText Target)
	{
		float scale = Settings.Scale;
		UnityScript.Lang.Array array = Target.gameObject.name.Split(" "[0]);
		object obj = array[0];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		int num = -2;
		int num2 = -2;
		if (array.length > 1)
		{
			array = array[1].ToString().Split(","[0]);
			int result = default(int);
			for (int i = default(int); i < array.length; i++)
			{
				object obj2 = array[i];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				if (!int.TryParse((string)obj2, out result))
				{
					for (int j = default(int); j < Extensions.get_length((System.Array)Colors); j++)
					{
						if (RuntimeServices.EqualityOperator(array[i], Colors[j].Name))
						{
							Target.material.color = Colors[j].Col;
						}
					}
				}
				else if (num == -2)
				{
					object obj3 = array[i];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					num = int.Parse((string)obj3);
				}
				else
				{
					object obj4 = array[i];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					num2 = int.Parse((string)obj4);
				}
			}
		}
		if (num == -2)
		{
			bool flag = true;
			int result2 = default(int);
			Transform parent = Target.transform;
			while (flag)
			{
				if (array.length != 1)
				{
					if (array.length > 1)
					{
						object obj5 = array[1];
						if (!(obj5 is string))
						{
							obj5 = RuntimeServices.Coerce(obj5, typeof(string));
						}
						if (!int.TryParse((string)obj5, out result2))
						{
							goto IL_0225;
						}
					}
					flag = false;
					continue;
				}
				goto IL_0225;
				IL_0225:
				parent = parent.parent;
				array = parent.gameObject.name.Split(" "[0]);
				if (array.length > 1)
				{
					array = array[1].ToString().Split(","[0]);
				}
			}
			object obj6 = array[0];
			if (!(obj6 is string))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(string));
			}
			num = int.Parse((string)obj6);
			object obj7 = array[1];
			if (!(obj7 is string))
			{
				obj7 = RuntimeServices.Coerce(obj7, typeof(string));
			}
			num2 = int.Parse((string)obj7);
		}
		UnityScript.Lang.Array array2 = Target.text.Split("\""[0]);
		while (array2.length > 1)
		{
			Target.text = Target.text.Replace("\"" + array2[1].ToString() + "\"", Loc.L(array2[1].ToString()));
			if (Extensions.get_length(array2[1].ToString()) > 1 && array2[1].ToString()[1].ToString() == array2[1].ToString()[1].ToString().ToUpper())
			{
				Target.text = Target.text.ToUpper();
			}
			array2 = Target.text.Split("\""[0]);
		}
		if (FirstMenuInitialization)
		{
			OriginalTextPositions.Add(Target.pixelOffset);
			OriginalTextSizes.Add(Target.fontSize);
		}
		else
		{
			Target.pixelOffset = (Vector2)OriginalTextPositions[OriginalTextIndex];
			Target.fontSize = RuntimeServices.UnboxInt32(OriginalTextSizes[OriginalTextIndex]);
			OriginalTextIndex++;
		}
		Target.fontSize = (int)((float)Target.fontSize * scale / 2f);
		int num3 = 480;
		int num4 = 320;
		if (App.IsPortrait)
		{
			num3 = 320;
			num4 = 480;
		}
		int width = Screen.width;
		int height = Screen.height;
		if (IsVR)
		{
			width = (int)(480f * scale);
			height = (int)(320f * scale);
		}
		else
		{
			width = (int)ScreenSafeArea.width;
			height = (int)ScreenSafeArea.height;
		}
		switch (num)
		{
		case -1:
		{
			float x3 = (float)(-width / 2) - ((float)(-num3) - Target.pixelOffset.x) * scale / 2f;
			Vector2 pixelOffset3 = Target.pixelOffset;
			float num7 = (pixelOffset3.x = x3);
			Vector2 vector6 = (Target.pixelOffset = pixelOffset3);
			break;
		}
		case 0:
		{
			float x2 = Target.pixelOffset.x * scale / 2f;
			Vector2 pixelOffset2 = Target.pixelOffset;
			float num6 = (pixelOffset2.x = x2);
			Vector2 vector4 = (Target.pixelOffset = pixelOffset2);
			break;
		}
		case 1:
		{
			float x = (float)(width / 2) - ((float)num3 - Target.pixelOffset.x) * scale / 2f;
			Vector2 pixelOffset = Target.pixelOffset;
			float num5 = (pixelOffset.x = x);
			Vector2 vector2 = (Target.pixelOffset = pixelOffset);
			break;
		}
		}
		switch (num2)
		{
		case -1:
		{
			float y3 = (float)(-height / 2) - ((float)(-num4) - Target.pixelOffset.y) * scale / 2f;
			Vector2 pixelOffset6 = Target.pixelOffset;
			float num10 = (pixelOffset6.y = y3);
			Vector2 vector12 = (Target.pixelOffset = pixelOffset6);
			break;
		}
		case 0:
		{
			float y2 = Target.pixelOffset.y * scale / 2f;
			Vector2 pixelOffset5 = Target.pixelOffset;
			float num9 = (pixelOffset5.y = y2);
			Vector2 vector10 = (Target.pixelOffset = pixelOffset5);
			break;
		}
		case 1:
		{
			float y = (float)(height / 2) - ((float)num4 - Target.pixelOffset.y) * scale / 2f;
			Vector2 pixelOffset4 = Target.pixelOffset;
			float num8 = (pixelOffset4.y = y);
			Vector2 vector8 = (Target.pixelOffset = pixelOffset4);
			break;
		}
		}
		GUITextsArray.Add(Target);
		VRCreateGUI(Target.gameObject, false, false);
	}

	public static string VerticalText(string TheText)
	{
		string text = string.Empty;
		for (int i = default(int); i < Extensions.get_length(TheText); i++)
		{
			if (i != 0)
			{
				text += "\n";
			}
			text += TheText[i];
		}
		return text;
	}

	public virtual string BreakText(string text, int LineLength)
	{
		for (int i = LineLength; i < text.Length; i += LineLength)
		{
			int num = text.LastIndexOf(" ", i);
			if (num >= 0)
			{
				text = text.Substring(0, num) + "\n" + text.Substring(num, text.Length - num);
				i = num;
			}
		}
		return text;
	}

	public static void ToggleSounds()
	{
		ToggleSounds(!MuteSounds);
	}

	public static void ToggleSounds(bool ShouldMute)
	{
		MuteSounds = Saver.GetBoolean("MuteSounds");
		if (MuteSounds != ShouldMute)
		{
			MuteSounds = ShouldMute;
			Saver.Set("MuteSounds", ShouldMute);
			Saver.Save();
		}
	}

	public static void ToggleMusic()
	{
		ToggleMusic(!MuteMusic);
	}

	public static void ToggleMusic(bool ShouldMute)
	{
		MuteMusic = Saver.GetBoolean("MuteMusic");
		if (MuteMusic != ShouldMute)
		{
			MuteMusic = ShouldMute;
			Saver.Set("MuteMusic", ShouldMute);
			Saver.Save();
		}
	}

	public static void PlaySound(AudioSource TheSource)
	{
		if (!MuteSounds)
		{
			TheSource.Play();
		}
	}

	public static void InitializeVR()
	{
	}

	public static void ToggleGamepadAiming(bool Set)
	{
		VRGamepadAiming = Set;
		Saver.Set("GamepadAiming", Set);
	}

	public virtual void SetupVR()
	{
		if (!IsVR)
		{
			return;
		}
		Screen.lockCursor = true;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(OVRCameraController);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (transform.name == "CameraLeft")
			{
				OVRCameraLeft = transform;
				UnityRuntimeServices.Update(enumerator, transform);
			}
			else
			{
				OVRCameraRight = transform;
				UnityRuntimeServices.Update(enumerator, transform);
			}
		}
		((Camera)GetComponent(typeof(Camera))).enabled = false;
		GUI3D = new GameObject("-GUI3D");
		GUI3D.transform.parent = GUI.transform;
		GUITexturesArray3D = new UnityScript.Lang.Array();
		GUITextsArray3D = new UnityScript.Lang.Array();
		Material material = new Material(VRTextureShaderString);
		VRTextureShader = material.shader;
		material = new Material(VRTextShaderString);
		VRTextShader = material.shader;
		VRDot = GameObject.CreatePrimitive(PrimitiveType.Quad);
		UnityEngine.Object.Destroy((Collider)VRDot.GetComponent(typeof(Collider)));
		VRDot.name = "VRDot";
		VRDot.layer = 7;
		VRDot.transform.parent = OVRCameraController;
		((Renderer)VRDot.GetComponent(typeof(Renderer))).material = new Material(VRTextureShader);
		((Renderer)VRDot.GetComponent(typeof(Renderer))).sharedMaterial.renderQueue = 4999;
		((Renderer)VRDot.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = (Texture)Resources.Load("VR/VRDot" + Settings.Suffix);
		if (GetComponent("Guns") != null)
		{
			GunsModulePresent = true;
			VRCrosshairParent = new GameObject("VRCrosshairParent");
			VRCrosshairParent.transform.parent = GUI3D.transform;
			VRCrosshairParent.transform.localPosition = Vector3.zero;
			VRCrosshairH = (Texture2D)Resources.Load("VR/VRCrosshairH" + Settings.Suffix);
			VRCrosshairV = (Texture2D)Resources.Load("VR/VRCrosshairV" + Settings.Suffix);
		}
	}

	public virtual GameObject VRFindMenuParent(GameObject Tex)
	{
		Transform parent = Tex.transform;
		Transform transform = null;
		while (parent.gameObject != GUI)
		{
			transform = parent;
			parent = parent.transform.parent;
		}
		return transform.gameObject;
	}

	public virtual void VRSetupMenus()
	{
		if (!IsVR)
		{
			return;
		}
		GUITextureParents = new GameObject[Extensions.get_length((System.Array)Parents)];
		GUITextures = new GUITexture[GUITexturesArray.length];
		GUITextures3D = new GameObject[GUITexturesArray.length];
		for (int i = default(int); i < Extensions.get_length((System.Array)GUITextures); i++)
		{
			GUITexture[] gUITextures = GUITextures;
			int num = i;
			object obj = GUITexturesArray[i];
			if (!(obj is GUITexture))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GUITexture));
			}
			gUITextures[num] = (GUITexture)obj;
			GameObject[] gUITextures3D = GUITextures3D;
			int num2 = i;
			object obj2 = GUITexturesArray3D[i];
			if (!(obj2 is GameObject))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
			}
			gUITextures3D[num2] = (GameObject)obj2;
			GUITextureParents[i] = VRFindMenuParent(GUITextures[i].gameObject);
			if (GunsModulePresent)
			{
				if (GUITextures[i].name == "GunsCrosshairH1")
				{
					VRCrosshairH1 = GUITextures3D[i].transform;
					VRCrosshairH1.parent = VRCrosshairParent.transform;
					GunsCrosshairH1 = GUITextures[i];
				}
				if (GUITextures[i].name == "GunsCrosshairH2")
				{
					VRCrosshairH2 = GUITextures3D[i].transform;
					VRCrosshairH2.parent = VRCrosshairParent.transform;
				}
				if (GUITextures[i].name == "GunsCrosshairV1")
				{
					VRCrosshairV1 = GUITextures3D[i].transform;
					VRCrosshairV1.parent = VRCrosshairParent.transform;
				}
				if (GUITextures[i].name == "GunsCrosshairV2")
				{
					VRCrosshairV2 = GUITextures3D[i].transform;
					VRCrosshairV2.parent = VRCrosshairParent.transform;
				}
				if (GUITextures[i].name == "GunsReloadShoot")
				{
					VRGunsReloadShoot = GUITextures3D[i].transform;
				}
				if (GUITextures[i].name == "GunsReloadLookDown")
				{
					VRGunsReloadLookDown = GUITextures3D[i].transform;
				}
			}
		}
		GUITextParents = new GameObject[Extensions.get_length((System.Array)Parents)];
		GUITexts = new GUIText[GUITextsArray.length];
		GUITexts3D = new GameObject[GUITextsArray.length];
		GUITextsMeshes3D = new TextMesh[GUITextsArray.length];
		for (int i = 0; i < Extensions.get_length((System.Array)GUITexts); i++)
		{
			GUIText[] gUITexts = GUITexts;
			int num3 = i;
			object obj3 = GUITextsArray[i];
			if (!(obj3 is GUIText))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(GUIText));
			}
			gUITexts[num3] = (GUIText)obj3;
			GameObject[] gUITexts3D = GUITexts3D;
			int num4 = i;
			object obj4 = GUITextsArray3D[i];
			if (!(obj4 is GameObject))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(GameObject));
			}
			gUITexts3D[num4] = (GameObject)obj4;
			GUITextsMeshes3D[i] = (TextMesh)GUITexts3D[i].GetComponent("TextMesh");
			GUITextParents[i] = VRFindMenuParent(GUITexts[i].gameObject);
			if (GunsModulePresent)
			{
				if (GUITexts[i].name == "GunsPointFont1")
				{
					VRPointFont1 = GUITexts3D[i].transform;
				}
				if (GUITexts[i].name == "GunsPointFontShadow1")
				{
					VRPointFontShadow1 = GUITexts3D[i].transform;
				}
				if (GUITexts[i].name == "GunsPointFont2")
				{
					VRPointFont2 = GUITexts3D[i].transform;
				}
				if (GUITexts[i].name == "GunsPointFontShadow2")
				{
					VRPointFontShadow2 = GUITexts3D[i].transform;
				}
			}
		}
	}

	public virtual void VRSetupFade()
	{
		if (IsVR)
		{
			VRFade = UnityEngine.Object.Instantiate((GameObject)Resources.Load("VR/VRDarkCube", typeof(GameObject)));
			UnityEngine.Object.Destroy((Collider)VRFade.GetComponent(typeof(Collider)));
			VRFade.name = "Fade";
			VRFade.layer = 7;
			VRFade.transform.parent = GUI3D.transform;
			((Renderer)VRFade.GetComponent(typeof(Renderer))).material = new Material(VRTextureShader);
			((Renderer)VRFade.GetComponent(typeof(Renderer))).sharedMaterial.renderQueue = (int)(3000f + FadeTexture.transform.localPosition.z + 10f);
		}
	}

	public virtual void VRToggleDot(bool Visible)
	{
		UseVRDot = Visible;
	}

	public virtual void VRCreateGUI(GameObject Target, bool IsTexture, bool IsDarkOrExit)
	{
		if (!IsVR || !FirstMenuInitialization)
		{
			return;
		}
		GameObject gameObject;
		TextMesh textMesh = default(TextMesh);
		if (IsTexture)
		{
			gameObject = (IsDarkOrExit ? UnityEngine.Object.Instantiate((GameObject)Resources.Load("VR/VRDarkCube", typeof(GameObject))) : GameObject.CreatePrimitive(PrimitiveType.Quad));
			UnityEngine.Object.Destroy((Collider)gameObject.GetComponent(typeof(Collider)));
			UnityScript.Lang.Array array = Target.name.Split(" "[0]);
			if (array.length > 1)
			{
				for (int i = 1; i < array.length; i++)
				{
					if (array[i].ToString().StartsWith("B"))
					{
						BoxCollider boxCollider = (BoxCollider)gameObject.AddComponent(typeof(BoxCollider));
						boxCollider.center = new Vector3(0f, 0f, 0f);
						boxCollider.size = new Vector3(1f, 1f, 1E-06f);
						Rigidbody rigidbody = (Rigidbody)gameObject.AddComponent(typeof(Rigidbody));
						rigidbody.isKinematic = true;
						rigidbody.useGravity = false;
					}
				}
			}
		}
		else
		{
			gameObject = new GameObject();
			gameObject.AddComponent(typeof(MeshRenderer));
			textMesh = (TextMesh)gameObject.AddComponent(typeof(TextMesh));
			textMesh.font = ((GUIText)Target.GetComponent(typeof(GUIText))).font;
			textMesh.anchor = ((GUIText)Target.GetComponent(typeof(GUIText))).anchor;
		}
		gameObject.name = Target.name;
		gameObject.layer = 7;
		gameObject.transform.parent = GUI3D.transform;
		if (IsTexture)
		{
			((Renderer)gameObject.GetComponent(typeof(Renderer))).material = new Material(VRTextureShader);
		}
		else
		{
			((Renderer)gameObject.GetComponent(typeof(Renderer))).material = new Material(VRTextShader);
		}
		((Renderer)gameObject.GetComponent(typeof(Renderer))).sharedMaterial.renderQueue = (int)(3000f + Target.transform.localPosition.z + 10f);
		if (IsTexture)
		{
			GUITexturesArray3D.Add(gameObject);
			return;
		}
		((Renderer)gameObject.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = textMesh.font.material.mainTexture;
		GUITextsArray3D.Add(gameObject);
	}

	public virtual void LateUpdate()
	{
		if (!IsVR)
		{
			return;
		}
		if (Input.anyKeyDown)
		{
			Screen.lockCursor = true;
		}
		GUI3D.SetActive(true);
		GUICamera.SetActive(false);
		OVRCameraController.transform.position = transform.position;
		GUI3D.transform.position = transform.position;
		transform.rotation = OVRCameraLeft.rotation;
		float num = 2f / Settings.Scale;
		for (int i = default(int); i < Extensions.get_length((System.Array)GUITextures); i++)
		{
			if (GUITextureParents[i].active && GUITextures[i].gameObject.activeInHierarchy)
			{
				if (!GUITextures3D[i].active)
				{
					GUITextures3D[i].SetActive(true);
				}
				Rect pixelInset = GUITextures[i].pixelInset;
				GUITextures3D[i].transform.localPosition = (new Vector3(pixelInset.x, pixelInset.y, 0f) + new Vector3(pixelInset.width, pixelInset.height, 0f) * 0.5f) * 0.001f * num + new Vector3(0f, 0f, VRMenuDistance - GUITextures[i].transform.localPosition.z / 20000f);
				Renderer renderer = (Renderer)GUITextures3D[i].GetComponent(typeof(Renderer));
				Material sharedMaterial = ((Renderer)GUITextures3D[i].GetComponent(typeof(Renderer))).sharedMaterial;
				if (GUITextures[i].enabled)
				{
					if (!renderer.enabled)
					{
						renderer.enabled = true;
					}
					sharedMaterial.mainTexture = GUITextures[i].texture;
					sharedMaterial.color = GUITextures[i].color;
					float a = sharedMaterial.color.a * 2f;
					Color color = sharedMaterial.color;
					float num2 = (color.a = a);
					Color color3 = (sharedMaterial.color = color);
				}
				else if (renderer.enabled)
				{
					renderer.enabled = false;
				}
				if (sharedMaterial.mainTexture == DarkTexture || sharedMaterial.mainTexture == LightTexture)
				{
					GUITextures3D[i].transform.localScale = Vector3.one * 2f;
				}
				else
				{
					GUITextures3D[i].transform.localScale = new Vector3(GUITextures[i].pixelInset.width, GUITextures[i].pixelInset.height, 1f) * 0.001f * num;
				}
				if (sharedMaterial.mainTexture == null)
				{
					renderer.enabled = false;
				}
			}
			else if (GUITextures3D[i].active)
			{
				GUITextures3D[i].SetActive(false);
			}
		}
		for (int i = 0; i < Extensions.get_length((System.Array)GUITexts); i++)
		{
			if (GUITextParents[i].active && GUITexts[i].gameObject.activeInHierarchy && GUITexts[i].enabled)
			{
				if (!GUITexts3D[i].active)
				{
					GUITexts3D[i].SetActive(true);
				}
				((Renderer)GUITexts3D[i].GetComponent(typeof(Renderer))).sharedMaterial.color = GUITexts[i].material.color;
				GUITextsMeshes3D[i].lineSpacing = GUITexts[i].lineSpacing;
				GUITextsMeshes3D[i].text = GUITexts[i].text;
				GUITexts3D[i].transform.localPosition = new Vector3(GUITexts[i].pixelOffset.x, GUITexts[i].pixelOffset.y, 0f) * 0.001f * num + new Vector3(0f, 0f, VRMenuDistance - GUITexts[i].transform.localPosition.z / 20000f);
				GUITextsMeshes3D[i].fontSize = GUITexts[i].fontSize;
				GUITexts3D[i].transform.localScale = Vector3.one * 0.01f * num;
			}
			else if (GUITexts3D[i].active)
			{
				GUITexts3D[i].SetActive(false);
			}
		}
		if (FadeTexture.enabled)
		{
			((Renderer)VRFade.GetComponent(typeof(Renderer))).enabled = true;
			VRFade.transform.localScale = Vector3.one * 2f;
			VRFade.transform.rotation = transform.rotation;
			VRFade.transform.localPosition = new Vector3(0f, 0f, VRMenuDistance - FadeTexture.transform.localPosition.z / 20000f);
			((Renderer)VRFade.GetComponent(typeof(Renderer))).sharedMaterial.color = FadeTexture.color;
			float a2 = ((Renderer)VRFade.GetComponent(typeof(Renderer))).sharedMaterial.color.a * 2f;
			Color color4 = ((Renderer)VRFade.GetComponent(typeof(Renderer))).sharedMaterial.color;
			float num3 = (color4.a = a2);
			Color color6 = (((Renderer)VRFade.GetComponent(typeof(Renderer))).sharedMaterial.color = color4);
		}
		else
		{
			((Renderer)VRFade.GetComponent(typeof(Renderer))).enabled = false;
		}
		bool flag = default(bool);
		bool flag2 = default(bool);
		Ray ray = ((!GunsModulePresent || VRDot.activeInHierarchy || !GunsCrosshairH1.enabled || !GunsCrosshairH1.gameObject.activeInHierarchy || !IsController || !VRGamepadAiming) ? new Ray((OVRCameraLeft.position + OVRCameraRight.position) / 2f, OVRCameraLeft.forward) : new Ray((OVRCameraLeft.position + OVRCameraRight.position) / 2f, VRCrosshairParent.transform.forward));
		RaycastHit hitInfo = default(RaycastHit);
		float num4 = default(float);
		num4 = ((!UseVRDot) ? float.PositiveInfinity : 12f);
		if (Physics.Raycast(ray, out hitInfo, num4))
		{
			if (hitInfo.collider.gameObject.layer == 7)
			{
				flag2 = true;
			}
			else
			{
				flag = true;
			}
		}
		if (UseVRDot || flag2)
		{
			VRCrosshairParent.SetActive(false);
			VRDot.SetActive(true);
			VRDot.transform.localScale = new Vector3(4f * Settings.Scale, 4f * Settings.Scale, 1f) * 0.001f * num;
			VRDot.transform.position = (OVRCameraLeft.position + OVRCameraRight.position) / 2f;
			VRDot.transform.rotation = transform.rotation;
			if (!flag2)
			{
				VRDot.transform.Translate(new Vector3(0f, 0f, VRMenuDistance));
				int num5 = default(int);
				while (num5 < 30 && VRDot.transform.position.z < transform.position.z + VRMenuDistance)
				{
					num5++;
					VRDot.transform.Translate(0f, 0f, 0.01f);
				}
			}
			else
			{
				VRDot.transform.position = hitInfo.point;
			}
			if (flag2)
			{
				LitButton = hitInfo.collider.gameObject;
				for (int i = 0; i < Extensions.get_length((System.Array)GUITextures3D); i++)
				{
					if (GUITextures3D[i] == LitButton)
					{
						HighlightButton(GUITextures[i].gameObject);
					}
				}
			}
			else
			{
				LitButton = null;
			}
		}
		else
		{
			VRDot.SetActive(false);
			LitButton = null;
		}
		if (!GunsModulePresent || VRDot.activeInHierarchy)
		{
			return;
		}
		if (GunsCrosshairH1.enabled && GunsCrosshairH1.gameObject.activeInHierarchy)
		{
			float num6 = Vector3.Distance(transform.position, hitInfo.point);
			VRCrosshairParent.SetActive(true);
			if (!IsController || !VRGamepadAiming)
			{
				VRCrosshairParent.transform.rotation = transform.rotation;
				if (flag)
				{
					VRCrosshairParent.transform.position = hitInfo.point;
					VRCrosshairParent.transform.localScale = Vector3.one * num6;
					int num7 = 0;
					Vector3 localPosition = VRCrosshairH1.transform.localPosition;
					float num8 = (localPosition.z = num7);
					Vector3 vector2 = (VRCrosshairH1.transform.localPosition = localPosition);
					int num9 = 0;
					Vector3 localPosition2 = VRCrosshairH2.transform.localPosition;
					float num10 = (localPosition2.z = num9);
					Vector3 vector4 = (VRCrosshairH2.transform.localPosition = localPosition2);
					int num11 = 0;
					Vector3 localPosition3 = VRCrosshairV1.transform.localPosition;
					float num12 = (localPosition3.z = num11);
					Vector3 vector6 = (VRCrosshairV1.transform.localPosition = localPosition3);
					int num13 = 0;
					Vector3 localPosition4 = VRCrosshairV2.transform.localPosition;
					float num14 = (localPosition4.z = num13);
					Vector3 vector8 = (VRCrosshairV2.transform.localPosition = localPosition4);
					VRCrosshairH1.transform.localScale = 2f * VRCrosshairH1.transform.localScale / Mathf.Pow(num6, 0.2f);
					VRCrosshairH2.transform.localScale = 2f * VRCrosshairH2.transform.localScale / Mathf.Pow(num6, 0.2f);
					VRCrosshairV1.transform.localScale = 2f * VRCrosshairV1.transform.localScale / Mathf.Pow(num6, 0.2f);
					VRCrosshairV2.transform.localScale = 2f * VRCrosshairV2.transform.localScale / Mathf.Pow(num6, 0.2f);
					((Renderer)VRCrosshairH1.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairH;
					((Renderer)VRCrosshairH2.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairH;
					((Renderer)VRCrosshairV1.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairV;
					((Renderer)VRCrosshairV2.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairV;
				}
			}
			else
			{
				VRCrosshairParent.transform.localPosition = Vector3.zero;
				VRCrosshairParent.transform.rotation = transform.rotation;
				VRCrosshairParent.transform.rotation = Quaternion.RotateTowards(transform.rotation, CrosshairRotationLastFrame, 31f);
				Ray ray2 = new Ray((OVRCameraLeft.position + OVRCameraRight.position) / 2f, VRCrosshairParent.transform.forward);
				RaycastHit hitInfo2 = default(RaycastHit);
				if (Physics.Raycast(ray2, out hitInfo2, float.PositiveInfinity) && hitInfo.collider.gameObject.layer != 7)
				{
					num6 = Vector3.Distance(transform.position, hitInfo2.point);
					VRCrosshairParent.transform.localScale = Vector3.one * num6;
					int num15 = 0;
					Vector3 localPosition5 = VRCrosshairH1.transform.localPosition;
					float num16 = (localPosition5.z = num15);
					Vector3 vector10 = (VRCrosshairH1.transform.localPosition = localPosition5);
					int num17 = 0;
					Vector3 localPosition6 = VRCrosshairH2.transform.localPosition;
					float num18 = (localPosition6.z = num17);
					Vector3 vector12 = (VRCrosshairH2.transform.localPosition = localPosition6);
					int num19 = 0;
					Vector3 localPosition7 = VRCrosshairV1.transform.localPosition;
					float num20 = (localPosition7.z = num19);
					Vector3 vector14 = (VRCrosshairV1.transform.localPosition = localPosition7);
					int num21 = 0;
					Vector3 localPosition8 = VRCrosshairV2.transform.localPosition;
					float num22 = (localPosition8.z = num21);
					Vector3 vector16 = (VRCrosshairV2.transform.localPosition = localPosition8);
					VRCrosshairH1.transform.position = VRCrosshairH1.transform.position + (hitInfo2.point - transform.position);
					VRCrosshairH2.transform.position = VRCrosshairH2.transform.position + (hitInfo2.point - transform.position);
					VRCrosshairV1.transform.position = VRCrosshairV1.transform.position + (hitInfo2.point - transform.position);
					VRCrosshairV2.transform.position = VRCrosshairV2.transform.position + (hitInfo2.point - transform.position);
					VRCrosshairH1.transform.localScale = 2f * VRCrosshairH1.transform.localScale / Mathf.Pow(num6, 0.2f);
					VRCrosshairH2.transform.localScale = 2f * VRCrosshairH2.transform.localScale / Mathf.Pow(num6, 0.2f);
					VRCrosshairV1.transform.localScale = 2f * VRCrosshairV1.transform.localScale / Mathf.Pow(num6, 0.2f);
					VRCrosshairV2.transform.localScale = 2f * VRCrosshairV2.transform.localScale / Mathf.Pow(num6, 0.2f);
					((Renderer)VRCrosshairH1.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairH;
					((Renderer)VRCrosshairH2.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairH;
					((Renderer)VRCrosshairV1.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairV;
					((Renderer)VRCrosshairV2.GetComponent(typeof(Renderer))).sharedMaterial.mainTexture = VRCrosshairV;
				}
				int num23 = 1;
				if (!(ControllerAxis(3) >= 0f))
				{
					num23 = -1;
				}
				int num24 = 1;
				if (!(ControllerAxis(2) >= 0f))
				{
					num24 = -1;
				}
				CrosshairRotationLastFrame = VRCrosshairParent.transform.rotation * Quaternion.Euler(new Vector3(Mathf.Pow(ControllerAxis(3), 2f) * (float)num23 * 0.7f, Mathf.Pow(ControllerAxis(2), 2f) * (float)num24 * 0.7f, 0f));
				VRCrosshairParent.transform.LookAt(hitInfo2.point, transform.up);
			}
		}
		VRPointFont1.transform.position = VRPointFontPosition1;
		VRPointFontShadow1.transform.position = VRPointFontPosition1;
		VRPointFont2.transform.position = VRPointFontPosition2;
		VRPointFontShadow2.transform.position = VRPointFontPosition2;
		VRPointFontPosition1.y += Time.deltaTime * 3.5f;
		VRPointFontPosition2.y += Time.deltaTime * 3.5f;
		VRPointFont1.transform.localScale = Vector3.one * Vector3.Distance(transform.position, VRPointFontPosition1) * 0.01f * num;
		VRPointFontShadow1.transform.localScale = Vector3.one * Vector3.Distance(transform.position, VRPointFontPosition1) * 0.01f * num;
		VRPointFont2.transform.localScale = Vector3.one * Vector3.Distance(transform.position, VRPointFontPosition2) * 0.01f * num;
		VRPointFontShadow2.transform.localScale = Vector3.one * Vector3.Distance(transform.position, VRPointFontPosition2) * 0.01f * num;
		if (VRGunsReloadShoot.gameObject.activeInHierarchy)
		{
			VRGunsReloadShoot.transform.position = hitInfo.point;
			VRGunsReloadShoot.transform.rotation = transform.rotation;
			VRGunsReloadShoot.transform.localScale = 1.3f * VRGunsReloadShoot.transform.localScale * Mathf.Pow(Vector3.Distance(transform.position, hitInfo.point), 1f);
		}
		else if (VRGunsReloadLookDown.gameObject.activeInHierarchy)
		{
			VRGunsReloadLookDown.transform.position = hitInfo.point;
			VRGunsReloadLookDown.transform.rotation = transform.rotation;
			VRGunsReloadLookDown.transform.localScale = 1.3f * VRGunsReloadLookDown.transform.localScale * Mathf.Pow(Vector3.Distance(transform.position, hitInfo.point), 1f);
		}
	}

	public virtual void InitializeLoading()
	{
		if (MenuParentExists("Loading"))
		{
			if (NewUI != null)
			{
				LoadingMenu = NewUI.transform.Find("Loading").gameObject;
				LoadingAnimation = (Animation)LoadingMenu.GetComponent("Animation");
				LoadingTextUI = (Text)LoadingMenu.transform.Find("LoadingText").gameObject.GetComponent(typeof(Text));
				LoadingMatchTextUI = (Text)LoadingMenu.transform.Find("LoadingMatchText").gameObject.GetComponent(typeof(Text));
				LoadingButton = (Button)LoadingMenu.GetComponent(typeof(Button));
				LoadingImage = (Image)LoadingMenu.GetComponent(typeof(Image));
			}
			else
			{
				LoadingMenu = Get("Loading").gameObject;
				LoadingWheel = (GUITexture)Get("LoadingWheel").GetComponent(typeof(GUITexture));
				LoadingText = (GUIText)Get("LoadingText").GetComponent(typeof(GUIText));
				LoadingMatchText = (GUIText)Get("LoadingMatchText").GetComponent(typeof(GUIText));
				LoadingExitButton = GUI.transform.Find("Loading").transform.Find("EXIT").gameObject;
				LoadingDarkButton = GUI.transform.Find("Loading").transform.Find("DARK").gameObject;
			}
		}
	}

	public virtual void Loading(string TheText)
	{
		if (NewUI != null)
		{
			LoadingButton.interactable = false;
			LoadingImage.enabled = false;
			LoadingTextUI.text = TheText.ToUpper();
			LoadingMatchTextUI.text = string.Empty;
		}
		else
		{
			LoadingExitButton.SetActive(false);
			LoadingDarkButton.SetActive(false);
			LoadingText.text = TheText.ToUpper();
			LoadingMatchText.text = string.Empty;
		}
		StartCoroutine(CycleWheel());
	}

	public virtual void LoadingDark(string TheText)
	{
		if (NewUI != null)
		{
			LoadingButton.interactable = false;
			LoadingImage.enabled = true;
			LoadingTextUI.text = TheText.ToUpper();
			LoadingMatchTextUI.text = string.Empty;
		}
		else
		{
			LoadingExitButton.SetActive(false);
			LoadingDarkButton.SetActive(true);
			LoadingText.text = TheText.ToUpper();
			LoadingMatchText.text = string.Empty;
		}
		StartCoroutine(CycleWheel());
	}

	public virtual void LoadingExit(string TheText)
	{
		if (NewUI != null)
		{
			LoadingButton.interactable = true;
			LoadingImage.enabled = true;
			LoadingTextUI.text = TheText.ToUpper();
			LoadingMatchTextUI.text = string.Empty;
		}
		else
		{
			LoadingExitButton.SetActive(true);
			LoadingDarkButton.SetActive(false);
			LoadingText.text = TheText.ToUpper();
			LoadingMatchText.text = string.Empty;
		}
		StartCoroutine(CycleWheel());
	}

	public virtual void LoadingExit(string TheText, string MatchText)
	{
		LoadingExitButton.SetActive(true);
		LoadingDarkButton.SetActive(false);
		LoadingText.text = TheText.ToUpper();
		LoadingMatchText.text = MatchText.ToUpper();
		StartCoroutine(CycleWheel());
	}

	public virtual void LoadingMatchTextSet(string TheText)
	{
		if (NewUI != null)
		{
			LoadingMatchTextUI.text = TheText;
		}
		else
		{
			LoadingMatchText.text = TheText;
		}
	}

	public virtual IEnumerator CycleWheel()
	{
		return new _0024CycleWheel_00241054(this).GetEnumerator();
	}

	public virtual void InitializePopup()
	{
		if (NewUI != null)
		{
			PopupMenu = NewUI.transform.Find("Popup").gameObject;
			PopupAnimation = (Animation)PopupMenu.GetComponent(typeof(Animation));
			PopupButton1 = (Button)PopupMenu.transform.Find("PopupButtons/PopupTwo1").gameObject.GetComponent(typeof(Button));
			PopupButton2 = (Button)PopupMenu.transform.Find("PopupButtons/PopupTwo2").gameObject.GetComponent(typeof(Button));
			PopupButton1Text = (Text)PopupMenu.transform.Find("PopupButtons/PopupTwo1/PopupButton1Text").gameObject.GetComponent(typeof(Text));
			PopupButton2Text = (Text)PopupMenu.transform.Find("PopupButtons/PopupTwo2/PopupButton2Text").gameObject.GetComponent(typeof(Text));
			PopupExitButton = (Button)PopupMenu.GetComponent(typeof(Button));
			PopupButtonIcon = (Image)PopupMenu.transform.Find("PopupButtons/PopupTwo1/PopupButtonIcon").gameObject.GetComponent(typeof(Image));
			PopupUIText = (Text)PopupMenu.transform.Find("PopupImage/PopupText").gameObject.GetComponent(typeof(Text));
			Transform transform = PopupMenu.transform.Find("PopupImage/PopupHeadText");
			if (transform != null)
			{
				PopupUIHeadText = (Text)transform.gameObject.GetComponent(typeof(Text));
			}
		}
		else
		{
			PopupImage = (GUITexture)Get("PopupImage").GetComponent(typeof(GUITexture));
			PopupHeadText = (GUIText)Get("PopupHeadText").GetComponent(typeof(GUIText));
			PopupText = (GUIText)Get("PopupText").GetComponent(typeof(GUIText));
			Popup1Text = (GUIText)Get("Popup1Text").GetComponent(typeof(GUIText));
			PopupTwo1Text = (GUIText)Get("PopupTwo1Text").GetComponent(typeof(GUIText));
			PopupTwo2Text = (GUIText)Get("PopupTwo2Text").GetComponent(typeof(GUIText));
			Transform transform2 = GUI.transform.Find("Popup");
			if ((bool)transform2 && (bool)transform2.transform.Find("PopupShare"))
			{
				PopupShareHolder = transform2.transform.Find("PopupShare").gameObject;
			}
		}
	}

	public virtual void Popup(string TheText)
	{
		Popup(string.Empty, TheText, _0024Popup_0024closure_0024147, 0f);
	}

	public virtual void Popup(string TheText, __Menus_PopupSingleCallback_0024callable2_00243643_34__ Callback)
	{
		Popup(string.Empty, TheText, Callback, 0f);
	}

	public virtual void Popup(string TheHead, string TheText)
	{
		if (NewUI != null)
		{
			Popup(TheHead, TheText, _0024Popup_0024closure_0024148, 0f);
			return;
		}
		PopupType = 0;
		ShoRec("PopupZero");
		ShowPopup(TheHead, TheText, string.Empty, false);
	}

	public virtual void Popup(string TheText, float Delay)
	{
		Popup(string.Empty, TheText, _0024Popup_0024closure_0024149, Delay);
	}

	public virtual void Popup(string TheText, __Menus_PopupSingleCallback_0024callable2_00243643_34__ Callback, float Delay)
	{
		Popup(string.Empty, TheText, Callback, Delay);
	}

	public virtual void Popup(string TheHead, string TheText, float Delay)
	{
		Popup(TheHead, TheText, _0024Popup_0024closure_0024150, Delay);
	}

	public virtual void Popup(string TheHead, string TheText, __Menus_PopupSingleCallback_0024callable2_00243643_34__ Callback, float Delay)
	{
		_0024Popup_0024locals_0024555 _0024Popup_0024locals_0024 = new _0024Popup_0024locals_0024555();
		_0024Popup_0024locals_0024._0024Callback = Callback;
		if (Debug.isDebugBuild)
		{
			Delay = 0f;
		}
		PopupButtonIcon.gameObject.SetActive(false);
		PopupExitButton.onClick.RemoveAllListeners();
		if (_0024Popup_0024locals_0024._0024Callback != null)
		{
			PopupExitButton.onClick.AddListener(new _0024Popup_0024closure_0024151(_0024Popup_0024locals_0024).Invoke);
		}
		PopupSingleCallback = _0024Popup_0024locals_0024._0024Callback;
		if (PopupAnimation != null)
		{
			PopupAnimation.Play();
		}
		PopupMenu.SetActive(true);
		PopupButton1.gameObject.SetActive(false);
		PopupButton2.gameObject.SetActive(false);
		StopCoroutine("PopupExitDelaySingle");
		StartCoroutine("PopupExitDelaySingle", Delay);
		if (PopupUIHeadText != null)
		{
			PopupUIHeadText.text = TheHead;
			PopupUIText.text = TheText;
			return;
		}
		string empty = string.Empty;
		if (TheHead != string.Empty)
		{
			PopupUIText.text = TheHead + ". " + TheText;
		}
		else
		{
			PopupUIText.text = TheText;
		}
	}

	public virtual void Popup(string TheText, __Menus_Popup_0024callable3_00243785_46__ Callback)
	{
		Popup(string.Empty, TheText, Loc.L("Yes").ToUpper(), Loc.L("No").ToUpper(), Callback, 0f);
	}

	public virtual void Popup(string TheText, __Menus_Popup_0024callable3_00243785_46__ Callback, float Delay)
	{
		Popup(string.Empty, TheText, Loc.L("Yes").ToUpper(), Loc.L("No").ToUpper(), Callback, Delay);
	}

	public virtual void Popup(string TheHead, string TheText, __Menus_Popup_0024callable3_00243785_46__ Callback)
	{
		Popup(TheHead, TheText, Loc.L("Yes").ToUpper(), Loc.L("No").ToUpper(), Callback, 0f);
	}

	public virtual void Popup(string TheHead, string TheText, __Menus_Popup_0024callable3_00243785_46__ Callback, float Delay)
	{
		Popup(TheHead, TheText, Loc.L("Yes").ToUpper(), Loc.L("No").ToUpper(), Callback, Delay);
	}

	public virtual void Popup(string TheText, string Button0, string Button1, __Menus_Popup_0024callable3_00243785_46__ Callback)
	{
		Popup(string.Empty, TheText, Button0, Button1, Callback, 0f);
	}

	public virtual void Popup(string TheText, string Button0, string Button1, __Menus_Popup_0024callable3_00243785_46__ Callback, float Delay)
	{
		Popup(string.Empty, TheText, Button0, Button1, Callback, Delay);
	}

	public virtual void Popup(string TheHead, string TheText, string Button0, string Button1, __Menus_Popup_0024callable3_00243785_46__ Callback)
	{
		Popup(TheHead, TheText, Button0, Button1, null, Callback, 0f);
	}

	public virtual void Popup(string TheHead, string TheText, string Button0, string Button1, __Menus_Popup_0024callable3_00243785_46__ Callback, float Delay)
	{
		Popup(TheHead, TheText, Button0, Button1, null, Callback, Delay);
	}

	public virtual void Popup(string TheHead, string TheText, string Button0, string Button1, Sprite Img, __Menus_Popup_0024callable3_00243785_46__ Callback)
	{
		Popup(TheHead, TheText, Button0, Button1, Img, Callback, 0f);
	}

	public virtual void Popup(string TheHead, string TheText, string Button0, string Button1, Sprite Img, __Menus_Popup_0024callable3_00243785_46__ Callback, float Delay)
	{
		_0024Popup_0024locals_0024556 _0024Popup_0024locals_0024 = new _0024Popup_0024locals_0024556();
		_0024Popup_0024locals_0024._0024Callback = Callback;
		if (NewUI != null)
		{
			if (Img == null)
			{
				PopupButtonIcon.gameObject.SetActive(false);
			}
			else
			{
				PopupButtonIcon.gameObject.SetActive(true);
				PopupButtonIcon.sprite = Img;
			}
			PopupButton1.onClick.RemoveAllListeners();
			PopupButton2.onClick.RemoveAllListeners();
			if (_0024Popup_0024locals_0024._0024Callback != null)
			{
				PopupButton1.onClick.AddListener(new _0024Popup_0024closure_0024152(this, _0024Popup_0024locals_0024).Invoke);
				PopupButton2.onClick.AddListener(new _0024Popup_0024closure_0024153(this, _0024Popup_0024locals_0024).Invoke);
			}
			if (PopupAnimation != null)
			{
				PopupAnimation.Play();
			}
			PopupMenu.SetActive(true);
			PopupExitButton.interactable = false;
			StopCoroutine("PopupExitDelaySingle");
			PopupButton1.gameObject.SetActive(true);
			PopupButton2.gameObject.SetActive(true);
			PopupButton1Text.text = Button0.ToUpper();
			PopupButton2Text.text = Button1.ToUpper();
			if (!(Delay <= 0f))
			{
				StopCoroutine("PopupExitDelayMulti");
				StartCoroutine("PopupExitDelayMulti", Delay);
			}
			if (PopupUIHeadText != null)
			{
				PopupUIHeadText.text = TheHead;
				PopupUIText.text = TheText;
				return;
			}
			string empty = string.Empty;
			if (TheHead != string.Empty)
			{
				PopupUIText.text = TheHead + ". " + TheText;
			}
			else
			{
				PopupUIText.text = TheText;
			}
		}
		else
		{
			PopupType = 2;
			ShoRec("PopupTwo");
			PopupTwo1Text.text = Button0.ToUpper();
			PopupTwo2Text.text = Button1.ToUpper();
			ShowPopup(TheHead, TheText, PopupInstance, false);
		}
	}

	public virtual IEnumerator PopupExitDelaySingle(float Delay)
	{
		return new _0024PopupExitDelaySingle_00241059(Delay, this).GetEnumerator();
	}

	public virtual IEnumerator PopupExitDelayMulti(float Delay)
	{
		return new _0024PopupExitDelayMulti_00241064(Delay, this).GetEnumerator();
	}

	public virtual void Popup1(string TheHeadText, string TheText, string Instance, string ButtonOne)
	{
		if (NewUI != null)
		{
			Debug.LogError("Popup1() not supported in new UI system");
			return;
		}
		PopupType = 1;
		ShoRec("PopupOne");
		Popup1Text.text = ButtonOne.ToUpper();
		ShowPopup(TheHeadText, TheText, Instance, false);
	}

	public virtual void Popup2BlankReturn(bool Which)
	{
	}

	public virtual void Popup2(string TheHeadText, string TheText, string Instance)
	{
		if (NewUI != null)
		{
			Debug.LogError("Popup2() not supported in new UI system");
			return;
		}
		PopupInstance = Instance;
		Popup(TheHeadText, TheText, Popup2BlankReturn);
	}

	public virtual void Popup2(string TheHeadText, string TheText, string Instance, string ButtonOne, string ButtonTwo)
	{
		if (NewUI != null)
		{
			Debug.LogError("Popup2() not supported in new UI system");
			return;
		}
		PopupInstance = Instance;
		Popup(TheHeadText, TheText, ButtonOne, ButtonTwo, Popup2BlankReturn);
	}

	public virtual void PopupShare(string TheHeadText, string TheText, string Instance)
	{
		if (NewUI != null)
		{
			if (NewUI != null)
			{
				Debug.LogError("PopupShare() not supported in new UI system");
			}
		}
		else
		{
			PopupType = 3;
			ShoRec("PopupShare");
			ShowPopup(TheHeadText, TheText, Instance, false);
		}
	}

	public virtual void ShowPopup(string TheHeadText, string TheText, string Instance, bool DontBreakText)
	{
		if (!(NewUI != null))
		{
			if (PopupType != 3 && PopupShareHolder != null)
			{
				PopupShareHolder.SetActive(false);
			}
			PopupInstance = Instance;
			if (!DontBreakText)
			{
				TheText = BreakText(TheText, PopupBreakLength);
			}
			Sho("Popup");
			PopupHeadText.text = TheHeadText.ToUpper();
			PopupText.text = TheText.ToUpper();
			if (BackSound != null && !MuteSounds)
			{
				EffectsSource.clip = BackSound;
				EffectsSource.volume = BackVolume;
				EffectsSource.Play();
			}
		}
	}

	public virtual void PopupWasPressed(string Name)
	{
		if (NewUI != null)
		{
			return;
		}
		switch (Name)
		{
		case "PopupTwo1":
			if (PopupInstance == "UnlockNotEnough")
			{
				SendMessage("ShowStore");
			}
			else if (PopupInstance == "Rate")
			{
				Rate();
			}
			HidRec("Popup");
			break;
		case "PopupTwo2":
			HidRec("Popup");
			break;
		case "Popup1":
			HidRec("Popup");
			break;
		case "PopupShareFacebook":
			HidRec("Popup");
			break;
		case "PopupShareTwitter":
			HidRec("Popup");
			break;
		}
	}

	public virtual bool ShowiOSNativeRate()
	{
		return false;
	}

	public virtual void RateApp()
	{
		if ((bool)NewUI)
		{
			Menu.Popup(Loc.L("RateHead") + " " + Loc.L("RateBody"), NewRate);
		}
		else
		{
			Menu.Popup2(Loc.L("RateHead"), Loc.L("RateBody"), "Rate", Loc.L("Rate"), Loc.L("No"));
		}
	}

	public virtual void NewRate(bool Choice)
	{
		if (Choice)
		{
			Rate();
		}
		SendMessage("RatingPopupDismissed", Choice, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void Rate()
	{
		SendMessage("RatedApp", SendMessageOptions.DontRequireReceiver);
		if (AndroidStorefront() == AndroidStorefronts.Google)
		{
			Application.OpenURL(GenerateGoogleLink(App.BundleID));
		}
		else
		{
			Application.OpenURL(GenerateAmazonLink(App.BundleID));
		}
	}

	public virtual void InitializeFade()
	{
		FadeMenu = new GameObject("Fade");
		if (NewUI != null)
		{
			FadeMenu.layer = 5;
			FadeMenu.transform.SetParent(NewUI.transform);
			FadeMenu.transform.SetSiblingIndex(NewUI.transform.childCount - 1);
			FadeMenu.AddComponent(typeof(RectTransform));
			FadeMenu.AddComponent(typeof(CanvasRenderer));
			FadeImage = (Image)FadeMenu.AddComponent(typeof(Image));
			FadeMenu.transform.localScale = Vector3.one;
			FadeMenu.transform.localRotation = Quaternion.identity;
			FadeMenu.transform.localPosition = new Vector3(0f, 0f, NewUIFadeDepth);
			((RectTransform)FadeMenu.GetComponent(typeof(RectTransform))).anchorMin = Vector2.zero;
			((RectTransform)FadeMenu.GetComponent(typeof(RectTransform))).anchorMax = Vector2.one;
			((RectTransform)FadeMenu.GetComponent(typeof(RectTransform))).sizeDelta = Vector2.zero;
			FadeImage.color = Color.black;
			FadeMenu.AddComponent(typeof(Button));
			FadeCanvasGroup = (CanvasGroup)FadeMenu.AddComponent(typeof(CanvasGroup));
		}
		else
		{
			FadeMenu.layer = GUI.layer;
			FadeMenu.transform.position = new Vector3(0f, 0f, FadeDepth);
			FadeMenu.transform.localScale = new Vector3(0f, 0f, 1f);
			FadeMenu.transform.parent = GUI.transform;
			FadeTexture = (GUITexture)FadeMenu.AddComponent(typeof(GUITexture));
			FadeTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
			FadeTexture.texture = DarkTexture;
			VRSetupFade();
			LightTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			LightTexture.SetPixel(0, 0, Color.white);
			LightTexture.Apply();
		}
		if (!(NewUI != null))
		{
			return;
		}
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(NewUI.transform);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (transform.tag != "SafeAreaSkip" && transform != FadeImage.transform)
			{
				Rect screenSafeArea = ScreenSafeArea;
				RectTransform rectTransform = (RectTransform)transform.GetComponent(typeof(RectTransform));
				UnityRuntimeServices.Update(enumerator, transform);
				Vector2 position = screenSafeArea.position;
				Vector2 vector = screenSafeArea.position + screenSafeArea.size;
				position.x /= Screen.width;
				position.y /= Screen.height;
				vector.x /= Screen.width;
				vector.y /= Screen.height;
				Vector2 anchorMin = rectTransform.anchorMin;
				Vector2 anchorMax = rectTransform.anchorMax;
				anchorMin.x = position.x;
				anchorMax.x = vector.x;
				anchorMin.y = position.y;
				anchorMax.y = vector.y;
				rectTransform.anchorMin = anchorMin;
				rectTransform.anchorMax = anchorMax;
			}
		}
	}

	public virtual IEnumerator Fade(float TargetAlpha)
	{
		return new _0024Fade_00241069(TargetAlpha, this).GetEnumerator();
	}

	public virtual IEnumerator Fade(float TargetAlpha, float Speed)
	{
		return new _0024Fade_00241074(TargetAlpha, Speed, this).GetEnumerator();
	}

	public virtual IEnumerator FadeLight(float TargetAlpha)
	{
		return new _0024FadeLight_00241081(TargetAlpha, this).GetEnumerator();
	}

	public virtual IEnumerator FadeLight(float TargetAlpha, float Speed)
	{
		return new _0024FadeLight_00241086(TargetAlpha, Speed, this).GetEnumerator();
	}

	public virtual IEnumerator FadeColor(float TargetAlpha, Color Col)
	{
		return new _0024FadeColor_00241093(TargetAlpha, Col, this).GetEnumerator();
	}

	public virtual IEnumerator FadeColor(float TargetAlpha, Color Col, float Speed)
	{
		return new _0024FadeColor_00241100(TargetAlpha, Col, Speed, this).GetEnumerator();
	}

	public virtual IEnumerator FadeInOut(float TargetAlpha)
	{
		return new _0024FadeInOut_00241109(TargetAlpha, this).GetEnumerator();
	}

	public virtual void InitializeAudio()
	{
		EffectsSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		Mute = Saver.GetBoolean("Mute");
		if (Mute)
		{
			AudioListener.volume = 0f;
		}
	}

	public virtual void MuteAudio(bool ShouldMute)
	{
		Mute = ShouldMute;
		Saver.Set("Mute", Mute);
		Saver.Save();
		if (Mute)
		{
			AudioListener.volume = 0f;
		}
		else
		{
			AudioListener.volume = 1f;
		}
	}

	public virtual void FadeAudioAsync(AudioSource TheSource, float TargetVolume, float TheSpeed, bool DestroyAfterFadeout)
	{
		FadeAudioParams value = new FadeAudioParams(TheSource, TargetVolume, TheSpeed, DestroyAfterFadeout);
		Menu.SendMessage("FadeAudio", value);
	}

	public virtual void FadeAudio(FadeAudioParams Params)
	{
		StartCoroutine(FadeAudio(Params.Source, Params.Volume, Params.Speed, Params.DestroyAfterFade));
	}

	public virtual void FadeAudio(AudioSource TheSource, float TargetVolume, float TheSpeed)
	{
		StartCoroutine(FadeAudio(TheSource, TargetVolume, TheSpeed, false));
	}

	public virtual IEnumerator FadeAudio(AudioSource TheSource, float TargetVolume, float TheSpeed, bool DestroyAfterFadeout)
	{
		return new _0024FadeAudio_00241123(TheSource, TargetVolume, TheSpeed, DestroyAfterFadeout).GetEnumerator();
	}

	public virtual void InitializeIAP()
	{
		IAPClass = new MyStoreClass();
		IAPClass.MenuReference = this;
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
		for (int i = default(int); i < App.IAPProducts.Count; i++)
		{
			string id = App.IAPProducts[i].iOSID;
			if (AndroidStorefront() == AndroidStorefronts.Google)
			{
				if (App.IAPProducts[i].GoogleID != string.Empty)
				{
					id = App.IAPProducts[i].GoogleID;
				}
			}
			else if (App.IAPProducts[i].AmazonID != string.Empty)
			{
				id = App.IAPProducts[i].AmazonID;
			}
			configurationBuilder.AddProduct(id, App.IAPProducts[i].Type);
		}
		IAPClass.Initialize(configurationBuilder);
		if (AndroidStorefront() == AndroidStorefronts.Amazon)
		{
			PlatformUsesOwnNotifications = true;
		}
	}

	public virtual void Purchase(string ItemID)
	{
		IsARestore = false;
		StartCoroutine(AdHold());
		BeginTransaction();
		string productId = App.BundleID + "." + ItemID;
		StoreController.InitiatePurchase(productId);
	}

	public virtual void Restore()
	{
		IsARestore = true;
		BeginTransaction();
		IAPClass.RestorePurchases();
	}

	public virtual void UnibillReady(IStoreController controller, IExtensionProvider extensions)
	{
		StoreController = controller;
		StoreExtensionProvider = extensions;
		UnibillIsReady = true;
		SendMessage("UnibillInitialized", SendMessageOptions.DontRequireReceiver);
	}

	public virtual void BeginTransaction()
	{
		if (AndroidStorefront() != AndroidStorefronts.Amazon)
		{
			LoadingDark(Loc.L("Connecting to store"));
		}
	}

	public virtual void PurchaseCompleted(PurchaseEventArgs e)
	{
		PurchaseCompleted(e.purchasedProduct.definition.id);
	}

	public virtual void PurchaseCompleted(string ItemID)
	{
		MadePurchase = true;
		Saver.Set("MadePurchase", true);
		Saver.Save();
		if (PublishingPurchaseReceiver == null)
		{
			SendMessage("CompletePurchase", Regex.Replace(ItemID, App.BundleID + ".", string.Empty));
		}
		else
		{
			PublishingPurchaseReceiver.SendMessage("CompletePurchase", Regex.Replace(ItemID, App.BundleID + ".", string.Empty));
		}
		Hid("Loading");
	}

	public virtual void PurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		if (!PlatformUsesOwnNotifications)
		{
			if (failureReason == PurchaseFailureReason.UserCancelled)
			{
				Popup(Loc.L("PurchaseCancelled"), Loc.L("TryLater"));
			}
			else
			{
				Popup(Loc.L("PurchaseFailed"), Loc.L("TryLater"));
			}
		}
		SendMessage("UnibillPurchaseFailed", SendMessageOptions.DontRequireReceiver);
		Hid("Loading");
	}

	public virtual void TransactionsRestored(bool Successful)
	{
		if (!Successful && !PlatformUsesOwnNotifications)
		{
			Popup(Loc.L("Error"), Loc.L("RestoreFailed"));
		}
		Hid("Loading");
	}

	public virtual string PurchasableItemCost(string ItemID)
	{
		string text = App.BundleID + "." + ItemID;
		int num = 0;
		Product[] all = StoreController.products.all;
		int length = all.Length;
		string result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].definition.id == text)
				{
					if ((bool)PublishingPurchaseReceiver)
					{
						PublishingPurchaseReceiver.SendMessage("ReceiveItemCost", ItemID + "+" + all[num].metadata.localizedPriceString);
					}
					result = all[num].metadata.localizedPriceString;
					break;
				}
				num++;
				continue;
			}
			Debug.LogError("Couldn't find purchaseableitem with ID " + text);
			result = string.Empty;
			break;
		}
		return result;
	}

	public static AndroidStorefronts AndroidStorefront()
	{
		AndroidStorefronts result;
		if (!RetrievedAndroidStorefrontThisSession)
		{
			TextAsset textAsset = (TextAsset)Resources.Load(AndroidStorefrontPath, typeof(TextAsset));
			if (textAsset == null)
			{
				Debug.LogError("Missing Android storefront designation file. Run Naquatic -> Set Up Platform");
				AndroidStorefronts androidStorefronts = default(AndroidStorefronts);
				result = androidStorefronts;
				goto IL_0071;
			}
			RetainedAndroidStorefront = (AndroidStorefronts)Enum.Parse(typeof(AndroidStorefronts), textAsset.text);
			RetrievedAndroidStorefrontThisSession = true;
		}
		result = RetainedAndroidStorefront;
		goto IL_0071;
		IL_0071:
		return result;
	}

	public static void InitializePush()
	{
	}

	public virtual string ProcessMoreImage(GUITexture TheObject)
	{
		UnityScript.Lang.Array array = TheObject.name.Split(" "[0]);
		string text = array[0].ToString();
		string s = text.Substring(text.Length - 1, 1);
		MoreApp moreApp = App.MoreApps[int.Parse(s)];
		bool flag = default(bool);
		if ((AndroidStorefront() == AndroidStorefronts.Google && moreApp.BundleIDGoogle == string.Empty) || (AndroidStorefront() == AndroidStorefronts.Amazon && moreApp.BundleIDAmazon == string.Empty))
		{
			flag = true;
		}
		if (flag)
		{
			TheObject.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(TheObject.transform);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				float a = 0.9f;
				Color color = ((GUIText)transform.GetComponent(typeof(GUIText))).material.color;
				float num = (color.a = a);
				Color color3 = (((GUIText)transform.GetComponent(typeof(GUIText))).material.color = color);
				UnityRuntimeServices.Update(enumerator, transform);
				transform.gameObject.SetActive(true);
				UnityRuntimeServices.Update(enumerator, transform);
			}
		}
		return "More" + App.MoreApps[int.Parse(s)].ImageName;
	}

	public virtual void ProcessMoreImages(Transform TheParent)
	{
		MoreButtons = new System.Collections.Generic.List<Button>();
		for (int i = default(int); i < TheParent.childCount; i++)
		{
			if (TheParent.GetChild(i).name == "MoreButton")
			{
				MoreButtons.Add((Button)TheParent.GetChild(i).GetComponent(typeof(Button)));
			}
		}
		MoreCheckmarks = new GameObject[MoreButtons.Count];
		for (int i = 0; i < MoreButtons.Count; i++)
		{
			if (i >= Extensions.get_length((System.Array)App.MoreApps))
			{
				Debug.LogError("Expecting " + MoreButtons.Count.ToString() + " App.MoreApps entries. Only " + Extensions.get_length((System.Array)App.MoreApps).ToString() + " present");
				break;
			}
			MoreApp moreApp = App.MoreApps[i];
			MoreButtons[i].image.sprite = (Sprite)Resources.Load("More" + moreApp.ImageName, typeof(Sprite));
			bool flag = default(bool);
			if ((AndroidStorefront() == AndroidStorefronts.Google && moreApp.BundleIDGoogle == string.Empty) || (AndroidStorefront() == AndroidStorefronts.Amazon && moreApp.BundleIDAmazon == string.Empty))
			{
				flag = true;
			}
			Text text = null;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(MoreButtons[i].transform);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (transform.name == "MoreComingSoon")
				{
					text = (Text)transform.gameObject.GetComponent(typeof(Text));
					UnityRuntimeServices.Update(enumerator, transform);
				}
				else if (transform.name == "MoreCheckmark")
				{
					MoreCheckmarks[i] = transform.gameObject;
					UnityRuntimeServices.Update(enumerator, transform);
				}
			}
			if (text != null)
			{
				if (flag)
				{
					text.gameObject.SetActive(true);
					MoreButtons[i].interactable = false;
				}
				else
				{
					text.gameObject.SetActive(false);
				}
				AddButtonListener(MoreButtons[i], MoreLinkOpen, i);
				continue;
			}
			Debug.LogError("Missing MoreComingSoon text on " + moreApp.ImageName);
			break;
		}
	}

	public virtual int MoreCheckmarksUpdate()
	{
		int num = default(int);
		for (int i = default(int); i < Extensions.get_length((System.Array)MoreCheckmarks); i++)
		{
			MoreApp moreApp = App.MoreApps[i];
			string bundleID = ((AndroidStorefront() != 0) ? moreApp.BundleIDAmazon : moreApp.BundleIDGoogle);
			if (IsAppInstalled(bundleID))
			{
				MoreCheckmarks[i].gameObject.SetActive(true);
				num++;
			}
			else
			{
				MoreCheckmarks[i].gameObject.SetActive(false);
			}
		}
		return num;
	}

	public virtual void MoreLink(string ImageName)
	{
		int moreNumber = int.Parse(ImageName.Substring(ImageName.Length - 1, 1));
		MoreLinkOpen(moreNumber);
	}

	public virtual void MoreLinkOpen(int MoreNumber)
	{
		MoreApp moreApp = App.MoreApps[MoreNumber];
		if (AndroidStorefront() == AndroidStorefronts.Google && moreApp.BundleIDGoogle != string.Empty)
		{
			Application.OpenURL(GenerateGoogleLink(moreApp.BundleIDGoogle));
		}
		else if (AndroidStorefront() == AndroidStorefronts.Amazon && moreApp.BundleIDAmazon != string.Empty)
		{
			Application.OpenURL(GenerateAmazonLink(moreApp.BundleIDAmazon));
		}
	}

	public virtual void MoreWasPressed(string Name)
	{
		if (Name.Substring(0, 4) == "MORE")
		{
			MoreLink(Name);
		}
	}

	public static string GenerateiOSLink(string ID)
	{
		return "https://itunes.apple.com/app/id" + ID + "?at=10laCF&ct=" + App.PushName + ID;
	}

	public static string GenerateGoogleLink(string ID)
	{
		return "https://play.google.com/store/apps/details?id=" + ID;
	}

	public static string GenerateAmazonLink(string ID)
	{
		return "amzn://apps/android?p=" + ID + "&tag=nall06-20";
	}

	public static string GenerateAllLinks()
	{
		string lhs = null;
		bool flag = default(bool);
		if (AndroidStorefront() == AndroidStorefronts.Amazon)
		{
			flag = true;
		}
		if (!flag)
		{
			lhs += "iOS: https://itunes.apple.com/app/id" + App.AppleID;
			lhs += "\nGoogle Play: " + GenerateGoogleLink(App.BundleID);
			if (App.WindowsStoreBundleID != string.Empty)
			{
				lhs += "\nWindows Store: https://apps.microsoft.com/windows/app/" + App.WindowsStoreBundleID;
			}
		}
		return lhs + ("\nAmazon: https://www.amazon.com/gp/mas/dl/android?p=" + App.BundleID + "&tag=nall06-20");
	}

	public virtual bool IsAppInstalled(string bundleID)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		AndroidJavaObject lhs = null;
		try
		{
			lhs = androidJavaObject.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { bundleID });
		}
		catch (Exception)
		{
		}
		return (!RuntimeServices.EqualityOperator(lhs, null)) ? true : false;
	}

	[DllImport("__Internal")]
	public static extern void NaqSDKSendTextMessage(string Message);

	[DllImport("__Internal")]
	public static extern void NaqSDKSendTextMessagePic(string Message, string PicPath);

	[DllImport("__Internal")]
	public static extern void NaqSDKSendEmailPic(string Subject, string Body, string PicPath);

	[DllImport("__Internal")]
	public static extern void NaqSDKSavePic(string PicPath);

	public static void SendText(string Message)
	{
		Application.OpenURL("sms:?body=" + Message);
	}

	public static void SendEmail(string Subject, string Body)
	{
		SendEmail(Subject, Body, string.Empty, false);
	}

	public static void SendEmail(string Subject, string Body, bool IncludeDownloadLinks)
	{
		SendEmail(Subject, Body, string.Empty, IncludeDownloadLinks);
	}

	public static void SendEmail(string Subject, string Body, string PicPath, bool IncludeDownloadLinks)
	{
		string rhs = NEscapeURL(Subject);
		string text = NEscapeURL(Body);
		if (IncludeDownloadLinks)
		{
			Body += "\n\n" + GenerateAllLinks();
			text += "\n\n" + GenerateAllLinks();
		}
		if (PicPath == string.Empty)
		{
			Application.OpenURL("mailto:" + string.Empty + "?subject=" + rhs + "&body=" + text);
		}
		else
		{
			Debug.LogError("Can't send email with attachment on Android");
		}
	}

	public static void SavePic(string PicPath)
	{
		NaqSDKSavePic(PicPath);
	}

	public virtual void ShareFacebook(string Link)
	{
		Application.OpenURL("https://www.facebook.com/sharer/sharer.php?u=" + WWW.EscapeURL(Link));
		SendMessage("ShareCompleted", SendMessageOptions.DontRequireReceiver);
	}

	public virtual void ShareTwitter(string Link)
	{
		Application.OpenURL("https://twitter.com/intent/tweet?text=" + NEscapeURL(Link));
		SendMessage("ShareCompleted", SendMessageOptions.DontRequireReceiver);
	}

	public static IEnumerator InitializeAds()
	{
		return new _0024InitializeAds_00241133().GetEnumerator();
	}

	public static void ChartboostDidInitialize(bool Success)
	{
		ChartboostInitialized = Success;
	}

	public virtual IEnumerator MuteAudioForAd()
	{
		return new _0024MuteAudioForAd_00241135(this).GetEnumerator();
	}

	public virtual IEnumerator UnMuteAudioForAd()
	{
		return new _0024UnMuteAudioForAd_00241140(this).GetEnumerator();
	}

	public virtual IEnumerator InitializeVideoAds()
	{
		return new _0024InitializeVideoAds_00241145(this).GetEnumerator();
	}

	public virtual IEnumerator FetchPauseAd()
	{
		return new _0024FetchPauseAd_00241149().GetEnumerator();
	}

	public virtual IEnumerator FetchVideo()
	{
		return new _0024FetchVideo_00241150().GetEnumerator();
	}

	public virtual void ForceInitialVideoFetch()
	{
		ForcedInitialVideoFetch = true;
	}

	public virtual bool CachedVideo()
	{
		if ((bool)PublishingPurchaseReceiver)
		{
			PublishingPurchaseReceiver.SendMessage("ReceiveRewardedVideoAvailable", HZIncentivizedAd.IsAvailable());
		}
		return HZIncentivizedAd.IsAvailable();
	}

	public virtual bool OfferVideo()
	{
		if (!((DateTime.Now - Saver.GetDate("LastVideoOffer")).TotalSeconds >= -600.0))
		{
			Saver.Set("LastVideoOffer", DateTime.Now.ToString());
			Saver.Save();
		}
		int result;
		if (CachedVideo() && !((DateTime.Now - Saver.GetDate("LastVideoOffer")).TotalSeconds <= 600.0))
		{
			Saver.Set("LastVideoOffer", DateTime.Now.ToString());
			Saver.Save();
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual void DeclinedVideo()
	{
		Saver.Set("LastVideoOffer", DateTime.Now.AddMinutes(10.0).ToString());
		Saver.Save();
	}

	public virtual void RunVideo()
	{
		if (HZIncentivizedAd.IsAvailable())
		{
			Saver.Set("LastBoost", DateTime.Now.ToString());
			HZIncentivizedAd.Show();
			StopCoroutine("FetchVideo");
			StartCoroutine("FetchVideo");
		}
	}

	public virtual void RewardedVideoFinished(bool Completed)
	{
		Menu.SendMessage("FinishedRewardedVideo", Completed, SendMessageOptions.DontRequireReceiver);
		if ((bool)PublishingPurchaseReceiver)
		{
			PublishingPurchaseReceiver.SendMessage("FinishedRewardedVideo", Completed, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void FirstAd()
	{
		if (PlayerPrefs.GetString("FirstAdEver") == string.Empty)
		{
			PlayerPrefs.SetString("FirstAdEver", "No");
			RunAd("Startup");
		}
		else
		{
			RunAd("Home Screen");
		}
	}

	public virtual void ResumeAd()
	{
		if (!HoldAds && ((DateTime.Now - Saver.GetDate("LastPauseBoost")).TotalSeconds > 120.0 || Debug.isDebugBuild))
		{
			RunAd("Pause");
		}
	}

	public virtual void MenuReturnAd()
	{
		RunAd("MenuReturn");
	}

	public virtual void RunAd(string Location)
	{
		MadePurchase = Saver.GetBoolean("MadePurchase");
		if (MadePurchase)
		{
			return;
		}
		if (!Saver.GetBoolean("DeterminedAdSetting"))
		{
			if (!Settings.IsPro)
			{
				Saver.Set("AdsEnabled", AdsEnabledFree);
			}
			else
			{
				Saver.Set("AdsEnabled", AdsEnabledPro);
			}
			Saver.Set("DeterminedAdSetting", true);
		}
		if (!Saver.GetBoolean("AdsEnabled"))
		{
			return;
		}
		bool flag = true;
		if (!((DateTime.Now - Saver.GetDate("LastBoost")).TotalSeconds > (double)(60 * MinutesBetweenInterstitialVideos)) && !Debug.isDebugBuild)
		{
			return;
		}
		switch (Location)
		{
		case "Startup":
		case "Home Screen":
		case "Pause":
			if (ChartboostInitialized)
			{
				CBLocation cBLocation = null;
				cBLocation = ((Location == "Startup") ? CBLocation.Startup : ((!(Location == "Home Screen")) ? CBLocation.Pause : CBLocation.HomeScreen));
				if (Location != "Pause")
				{
					Chartboost.showInterstitial(cBLocation);
				}
				else if (Chartboost.hasInterstitial(cBLocation))
				{
					Chartboost.showInterstitial(cBLocation);
				}
				else
				{
					flag = false;
				}
			}
			break;
		case "MenuReturn":
			HZInterstitialAd.Show();
			break;
		default:
			HZInterstitialAd.Show();
			break;
		}
		if (flag)
		{
			Saver.Set("LastBoost", DateTime.Now.ToString());
		}
	}

	public virtual IEnumerator AdHold()
	{
		return new _0024AdHold_00241151().GetEnumerator();
	}

	public virtual void InitializeLeaderboards()
	{
		GameName = App.SystemName;
		if (!(NewUI != null) && MenuParentExists("Leaderboards"))
		{
			BoardsLeftNum = (GUIText)Get("LeaderboardsLeftNum").GetComponent(typeof(GUIText));
			BoardsLeftName = (GUIText)Get("LeaderboardsLeftName").GetComponent(typeof(GUIText));
			BoardsLeftScore = (GUIText)Get("LeaderboardsLeftScore").GetComponent(typeof(GUIText));
			BoardsRightNum = (GUIText)Get("LeaderboardsRightNum").GetComponent(typeof(GUIText));
			BoardsRightName = (GUIText)Get("LeaderboardsRightName").GetComponent(typeof(GUIText));
			BoardsRightScore = (GUIText)Get("LeaderboardsRightScore").GetComponent(typeof(GUIText));
			BoardsTitle = (GUIText)Get("LeaderboardsTitle").GetComponent(typeof(GUIText));
			BoardsError = (GUIText)Get("LeaderboardsError").GetComponent(typeof(GUIText));
		}
		int i = 0;
		LeaderboardClass[] leaderboards = App.Leaderboards;
		for (int length = leaderboards.Length; i < length; i++)
		{
			leaderboards[i].Score = Saver.GetInt(leaderboards[i].ID);
			leaderboards[i].Name = Loc.L(leaderboards[i].Name);
		}
		if (AndroidStorefront() == AndroidStorefronts.Google)
		{
			MenuParentExists("GoogleGameServices");
		}
	}

	public virtual void ShowLeaderboards()
	{
		if (AndroidStorefront() == AndroidStorefronts.Amazon)
		{
			if (GameCenterAuthenticated())
			{
				StartCoroutine(AdHold());
				AGSLeaderboardsClient.ShowLeaderboardsOverlay();
				return;
			}
		}
		else if (AndroidStorefront() == AndroidStorefronts.Google && GameCenterAuthenticated())
		{
			for (int i = default(int); i < Extensions.get_length((System.Array)App.Leaderboards); i++)
			{
				if (App.Leaderboards[i].GameServicesID != string.Empty)
				{
					StartCoroutine(AdHold());
					Social.ShowLeaderboardUI();
					return;
				}
			}
		}
		if (!UseNaquaticLeaderboards || NewUI != null)
		{
			NotLoggedInToSocialPopup();
			return;
		}
		Sho("Leaderboards");
		if (IsVR)
		{
			((GUITexture)Menu.Get("LeaderboardsMiddle2").GetComponent(typeof(GUITexture))).enabled = false;
		}
		LeaderboardsSetup();
	}

	public virtual void LeaderboardsSetup()
	{
		StopCoroutine("LeaderboardsCall");
		StartCoroutine("LeaderboardsCall");
	}

	public virtual IEnumerator LeaderboardsCall()
	{
		return new _0024LeaderboardsCall_00241152(this).GetEnumerator();
	}

	public virtual void LeaderboardsGotScores(string[] Message)
	{
		Hid("Loading");
		BoardsError.gameObject.SetActive(false);
		UnityScript.Lang.Array array = Message[0].Split(","[0]);
		string text = null;
		string text2 = null;
		string text3 = null;
		for (int i = default(int); i < array.length && (!IsVR || i <= 9); i++)
		{
			string[] array2 = array[i].ToString().Split("-"[0]);
			if (Extensions.get_length((System.Array)array2) < 2)
			{
				LeaderboardsScoresFailed();
				return;
			}
			text += array2[0].ToString() + "\n";
			text2 += array2[1].ToString() + "\n";
			text3 += (i + 1).ToString() + ".\n";
		}
		BoardsLeftName.text = WWW.UnEscapeURL(text);
		BoardsLeftScore.text = text2;
		BoardsLeftNum.text = text3;
		array = Message[1].Split(","[0]);
		text = string.Empty;
		text2 = string.Empty;
		text3 = string.Empty;
		int num = int.Parse(Message[2]);
		for (int i = 0; i < array.length && (!IsVR || i <= 9); i++)
		{
			string[] array2 = array[i].ToString().Split("-"[0]);
			if (i != 6 || array2[0].ToString() != WWW.EscapeURL(PlayerName))
			{
				text += array2[0].ToString() + "\n";
				text2 += array2[1].ToString() + "\n";
				text3 += (num + 1).ToString() + ".\n";
			}
			else
			{
				text += "<b><color=#47e7ff>" + array2[0].ToString() + "</color></b>\n";
				text2 += "<b><color=#47e7ff>" + array2[1].ToString() + "</color></b>\n";
				text3 += "<b><color=#47e7ff>" + (num + 1).ToString() + ".</color></b>\n";
			}
			num++;
		}
		BoardsRightName.text = WWW.UnEscapeURL(text);
		BoardsRightScore.text = text2;
		BoardsRightNum.text = text3;
	}

	public virtual void LeaderboardsScoresFailed()
	{
		Hid("Loading");
		BoardsError.gameObject.SetActive(true);
		BoardsLeftNum.text = string.Empty;
		BoardsLeftName.text = string.Empty;
		BoardsLeftScore.text = string.Empty;
		BoardsRightNum.text = string.Empty;
		BoardsRightName.text = string.Empty;
		BoardsRightScore.text = string.Empty;
	}

	public static void Score(string ID)
	{
		ReportScore(ID, 1, false);
	}

	public static void Score(string ID, int Score)
	{
		ReportScore(ID, Score, false);
	}

	public static void HighScore(string ID, int Score)
	{
		ReportScore(ID, Score, true);
	}

	public static void ReportScore(string ID, int Score, bool HighScoreMode)
	{
		for (int i = default(int); i < Extensions.get_length((System.Array)App.Leaderboards); i++)
		{
			if (!(ID == App.Leaderboards[i].ID))
			{
				continue;
			}
			int @int = Saver.GetInt(ID);
			if (HighScoreMode)
			{
				if (@int >= Score)
				{
					break;
				}
				App.Leaderboards[i].Score = Score;
			}
			else
			{
				App.Leaderboards[i].Score = @int + Score;
			}
			Saver.Set(ID, App.Leaderboards[i].Score);
			Menu.PostScore(WWW.EscapeURL(PlayerName), i + 1, App.Leaderboards[i].Score, null);
			if (AndroidStorefront() == AndroidStorefronts.Amazon)
			{
				if (GameCenterAuthenticated())
				{
					long num = App.Leaderboards[i].Score;
					AGSLeaderboardsClient.SubmitScore(App.Leaderboards[i].ID, App.Leaderboards[i].Score);
				}
			}
			else if (AndroidStorefront() == AndroidStorefronts.Google && GameCenterAuthenticated() && App.Leaderboards[i].GameServicesID != string.Empty)
			{
				Social.ReportScore(App.Leaderboards[i].Score, App.Leaderboards[i].GameServicesID, _0024ReportScore_0024closure_0024159);
			}
			break;
		}
	}

	public virtual void PostScore(string name, int catNum, int score, __Menus_PopupSingleCallback_0024callable2_00243643_34__ failFunction)
	{
		if (UseNaquaticLeaderboards)
		{
			WWWForm wWWForm = new WWWForm();
			string deviceID = Settings.DeviceID;
			wWWForm.AddField("uID", deviceID);
			wWWForm.AddField("tag", name);
			wWWForm.AddField("game", App.SystemName);
			wWWForm.AddField("cat", catNum.ToString());
			wWWForm.AddField("score", score.ToString());
			wWWForm.AddField("vcode", ((name.Length + 32) * 3 + ((App.SystemName.Length + 7) * (App.SystemName.Length + 2) * (catNum + 4) + (catNum + 9) * (score + 31))).ToString());
			WWW wWW = new WWW("https://naquatic.com/System/Soards.php", wWWForm);
		}
	}

	public virtual void GetScores(int catNum, __Menus_GetScores_0024callable4_00246265_52__ returnFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ failFunction)
	{
		string gameName = GameName;
		GameName = "System";
		StartCoroutine(Menu.CallScript("Boards.php?game=" + App.SystemName + "&uID=" + Settings.DeviceID + "&cat=" + catNum, returnFunction, failFunction));
		GameName = gameName;
	}

	public virtual void LeaderboardsWasPressed(string Name)
	{
		//Discarded unreachable code: IL_00a2
		switch (Name)
		{
		default:
			return;
		case "LeaderboardsExit":
			Hid("Leaderboards");
			Hid("Loading");
			return;
		case "LeaderboardsArrowLeft":
			do
			{
				CurrentBoard--;
				if (CurrentBoard < 0)
				{
					CurrentBoard = Extensions.get_length((System.Array)App.Leaderboards) - 1;
				}
			}
			while (App.Leaderboards[CurrentBoard].Invisible || App.Leaderboards[CurrentBoard].GameCenterOnly);
			LeaderboardsSetup();
			return;
		case "LeaderboardsArrowRight":
			break;
		}
		do
		{
			CurrentBoard++;
			if (CurrentBoard > Extensions.get_length((System.Array)App.Leaderboards) - 1)
			{
				CurrentBoard = 0;
			}
		}
		while (App.Leaderboards[CurrentBoard].Invisible || App.Leaderboards[CurrentBoard].GameCenterOnly);
		LeaderboardsSetup();
	}

	public static void InitializeAchievements()
	{
		for (int i = default(int); i < Extensions.get_length((System.Array)App.Achievements); i++)
		{
			App.Achievements[i].Progress = Saver.GetFloat(App.Achievements[i].ID);
			if (Saver.GetBoolean(App.Achievements[i].ID + "LocalReported"))
			{
				App.Achievements[i].LocalReported = true;
			}
			App.Achievements[i].Name = Loc.L(App.Achievements[i].Name);
			App.Achievements[i].Description = Loc.L(App.Achievements[i].Description);
		}
		AmazonHeroWidget();
	}

	public virtual void ShowAchievements()
	{
		if (AndroidStorefront() == AndroidStorefronts.Amazon)
		{
			if (GameCenterAuthenticated())
			{
				StartCoroutine(AdHold());
				AGSAchievementsClient.ShowAchievementsOverlay();
				return;
			}
		}
		else if (AndroidStorefront() == AndroidStorefronts.Google && GameCenterAuthenticated())
		{
			for (int i = default(int); i < Extensions.get_length((System.Array)App.Achievements); i++)
			{
				if (App.Achievements[i].GameServicesID != string.Empty)
				{
					StartCoroutine(AdHold());
					Social.ShowAchievementsUI();
					return;
				}
			}
		}
		NotLoggedInToSocialPopup();
	}

	public virtual void NotLoggedInToSocialPopup()
	{
		string rhs = null;
		if (AndroidStorefront() == AndroidStorefronts.Amazon)
		{
			rhs = "GameCircle";
		}
		else if (AndroidStorefront() == AndroidStorefronts.Google)
		{
			rhs = "Game Services";
		}
		if (NewUI != null)
		{
			Menu.Popup("Please log in to " + rhs);
		}
		else
		{
			Menu.Popup(Loc.L("Error"), "Please log in to " + rhs);
		}
	}

	public virtual void Achievement(string ID, float Progress)
	{
		Progress = Mathf.Clamp(Progress, 0f, 100f);
		int i = 0;
		AchievementClass[] achievements = App.Achievements;
		for (int length = achievements.Length; i < length; i++)
		{
			if (!(achievements[i].ID == ID))
			{
				continue;
			}
			if (!achievements[i].LocalReported)
			{
				Saver.Set(achievements[i].ID, Progress);
				achievements[i].Progress = Progress;
				if (achievements[i].Progress == 100f)
				{
					Saver.Set(achievements[i].ID + "LocalReported", true);
					achievements[i].LocalReported = true;
					if (PayOutAchievementValue)
					{
						Menu.SendMessage("AddCurrency", achievements[i].Value);
					}
				}
				Saver.Save();
			}
			if (AndroidStorefront() == AndroidStorefronts.Google)
			{
				ReportGameServicesAchievement(achievements[i]);
			}
			else
			{
				ReportGameCircleAchievement(achievements[i]);
			}
		}
	}

	public static void ReportAllGameCenterAchievements()
	{
		int i = 0;
		AchievementClass[] achievements = App.Achievements;
		for (int length = achievements.Length; i < length; i++)
		{
			if (achievements[i].Progress != 0f)
			{
				ReportGameCenterAchievement(achievements[i]);
			}
		}
	}

	public static void ReportGameCenterAchievement(AchievementClass TheAchievement)
	{
	}

	public static void ReportGameServicesAchievement(AchievementClass TheAchievement)
	{
		if (TheAchievement.GameServicesID != string.Empty && TheAchievement.Progress == 100f && GameCenterAuthenticated())
		{
			Social.ReportProgress(TheAchievement.GameServicesID, TheAchievement.Progress, _0024ReportGameServicesAchievement_0024closure_0024160);
		}
	}

	public static void ReportGameCircleAchievement(AchievementClass TheAchievement)
	{
		AmazonHeroWidget();
		if (GameCenterAuthenticated())
		{
			AGSAchievementsClient.UpdateAchievementProgress(TheAchievement.ID, TheAchievement.Progress);
		}
	}

	public static void AmazonHeroWidget()
	{
		if (AndroidStorefront() != AndroidStorefronts.Amazon || !HeroWidgetServiceWrapper.Instance().IsServiceAvailable())
		{
			return;
		}
		GroupedListHeroWidget groupedListHeroWidget = HeroWidgetServiceWrapper.Instance().CreateGroupedListHeroWidget();
		if (RuntimeServices.EqualityOperator(groupedListHeroWidget, null))
		{
			return;
		}
		GroupedListHeroWidget.GroupList groupList = HeroWidgetServiceWrapper.Instance().CreateGroupedListGroupList();
		GroupedListHeroWidget.Group group = HeroWidgetServiceWrapper.Instance().CreateGroupedListGroup();
		if (RuntimeServices.EqualityOperator(group, null))
		{
			return;
		}
		group.SetGroupName(Loc.L("Achievements").ToUpper());
		GroupedListHeroWidget.ListEntryList listEntryList = HeroWidgetServiceWrapper.Instance().CreateGroupedListListEntryList();
		for (int i = default(int); i < Extensions.get_length((System.Array)App.Achievements); i++)
		{
			GroupedListHeroWidget.ListEntry listEntry = HeroWidgetServiceWrapper.Instance().CreateGroupedListListEntry();
			if (!RuntimeServices.EqualityOperator(listEntry, null))
			{
				listEntry.SetContentIntent("Group1Item1");
				listEntry.SetVisualStyle(GroupedListHeroWidget.VisualStyle.DEFAULT);
				listEntry.SetPrimaryText(App.Achievements[i].Name.ToUpper() + " - " + Mathf.Round(App.Achievements[i].Progress).ToString("F0") + "%");
				listEntry.SetSecondaryText(App.Achievements[i].Description);
				listEntry.SetIcon(1, "https://naquatic.com/System/Amazon/HeroWidgetIcons/T" + (App.Achievements[i].TrophyImage + 1).ToString() + ".jpg");
				listEntryList.Add(listEntry);
			}
		}
		group.SetListEntries(listEntryList.GetAndroidJavaObject());
		groupList.Add(group);
		groupedListHeroWidget.SetGroups(groupList.GetAndroidJavaObject());
		HeroWidgetServiceWrapper.Instance().UpdateWidget(groupedListHeroWidget.GetAndroidJavaObject());
	}

	public static int Completion()
	{
		int num = default(int);
		int num2 = default(int);
		int i = 0;
		AchievementClass[] achievements = App.Achievements;
		for (int length = achievements.Length; i < length; i++)
		{
			num2 = (int)((float)num2 + achievements[i].Progress);
			num++;
		}
		return num2 / (num * 100);
	}

	public virtual void InitializeUser()
	{
		if (NewUI != null && MenuParentExists("Login"))
		{
			LoginMenu = NewUI.transform.Find("Login").gameObject;
			LoginInput = (InputField)LoginMenu.transform.Find("LoginBox").gameObject.GetComponent(typeof(InputField));
			LoginHead = (Text)LoginMenu.transform.Find("LoginHead").gameObject.GetComponent(typeof(Text));
			LoginText = (Text)LoginMenu.transform.Find("LoginBox/LoginText").gameObject.GetComponent(typeof(Text));
			LoginError = (Text)LoginMenu.transform.Find("LoginError").gameObject.GetComponent(typeof(Text));
			LoginSubmit = (Button)LoginMenu.transform.Find("LoginSubmit").gameObject.GetComponent(typeof(Button));
		}
		OnlinePlayers = new System.Collections.Generic.List<OnlinePlayer>();
		PlayerName = Saver.Get("PlayerName");
	}

	public virtual void TextInput(string InitialText, string HeadText, int Min, int Max, __Menus_LoginCheck_0024callable5_00246585_26__ ParseFunction, __Menus_TextInput_0024callable6_00246624_145__ SubmitFunction)
	{
		__Menus_TextInput_0024callable7_00246626_26__ checkFunction = _0024TextInput_0024closure_0024161;
		TextInput(InitialText, HeadText, Min, Max, checkFunction, ParseFunction, SubmitFunction);
	}

	public virtual void TextInput(string InitialText, string HeadText, int Min, int Max, __Menus_TextInput_0024callable7_00246626_26__ CheckFunction, __Menus_LoginCheck_0024callable5_00246585_26__ ParseFunction, __Menus_TextInput_0024callable6_00246624_145__ SubmitFunction)
	{
		_0024TextInput_0024locals_0024557 _0024TextInput_0024locals_0024 = new _0024TextInput_0024locals_0024557();
		_0024TextInput_0024locals_0024._0024Min = Min;
		_0024TextInput_0024locals_0024._0024CheckFunction = CheckFunction;
		_0024TextInput_0024locals_0024._0024ParseFunction = ParseFunction;
		_0024TextInput_0024locals_0024._0024SubmitFunction = SubmitFunction;
		LoginMenu.SetActive(true);
		LoginInput.text = InitialText;
		LoginHead.text = HeadText;
		LoginInput.onValueChange.AddListener(_0024adaptor_0024__Menus_PopupSingleCallback_0024callable2_00243643_34___0024UnityAction_00240.Adapt(new _0024TextInput_0024closure_0024162(this, _0024TextInput_0024locals_0024).Invoke));
		TextInputChange(_0024TextInput_0024locals_0024._0024CheckFunction, _0024TextInput_0024locals_0024._0024ParseFunction, _0024TextInput_0024locals_0024._0024Min);
		LoginInput.characterLimit = Max;
		LoginSubmit.onClick.RemoveAllListeners();
		LoginSubmit.onClick.AddListener(new _0024TextInput_0024closure_0024163(this, _0024TextInput_0024locals_0024).Invoke);
		LoginInput.Select();
	}

	public virtual void TextInputChange(__Menus_TextInput_0024callable7_00246626_26__ CheckFunction, __Menus_LoginCheck_0024callable5_00246585_26__ ParseFunction, int Min)
	{
		LoginInput.text = ParseFunction(LoginInput.text);
		if (Extensions.get_length(LoginInput.text) < Min)
		{
			LoginSubmit.interactable = false;
			if (Extensions.get_length(LoginInput.text) == 0)
			{
				LoginError.text = string.Empty;
			}
			else
			{
				LoginError.text = Loc.L("MinCharacters") + ": " + Min.ToString();
			}
		}
		else
		{
			LoginError.text = string.Empty;
			if (CheckFunction(LoginInput.text))
			{
				LoginSubmit.interactable = true;
			}
			else
			{
				LoginSubmit.interactable = false;
			}
		}
	}

	public virtual void TextInputSubmit(__Menus_TextInput_0024callable6_00246624_145__ SubmitFunction)
	{
		LoginMenu.SetActive(false);
		SubmitFunction(LoginText.text);
	}

	public static void SetPlayerName(string Name)
	{
		Saver.Set("PlayerName", Name);
		PlayerName = Name;
		Saver.Save();
	}

	public static void InitializePlayerName()
	{
		if (PlayerName == string.Empty)
		{
			SetPlayerName(GeneratePlayerName());
		}
	}

	public static string GeneratePlayerName()
	{
		string result;
		if (Settings.Language != "English")
		{
			result = Loc.L("Player") + UnityEngine.Random.Range(10, 99).ToString();
		}
		else
		{
			string[] array = new string[45]
			{
				"Good", "Bad", "New", "Old", "Short", "Long", "Great", "Small", "Big", "Tall",
				"Fancy", "Odd", "Shy", "Brave", "Calm", "Eager", "Kind", "Nice", "Mean", "Proud",
				"Silly", "Happy", "Jolly", "Angry", "Broad", "Round", "Wide", "Tiny", "Loud", "Noisy",
				"Quiet", "Raspy", "Quick", "Rapid", "Swift", "Fresh", "Icy", "Sweet", "Cold", "Cool",
				"Warm", "Cosmo", "Fall", "Ionic", "Thin"
			};
			string[] array2 = new string[55]
			{
				"Hive", "Fawn", "Shoe", "Lily", "Web", "Pie", "Deer", "Rhino", "Llama", "Lamb",
				"Chip", "Ox", "Yeti", "Wings", "Banjo", "Orca", "Hawk", "Soap", "Tiger", "Monk",
				"Cell", "Mage", "Bison", "Shark", "Flyer", "Band", "Quill", "Spoon", "Sage", "Cat",
				"Dog", "Bear", "Fish", "Bird", "Eagle", "Pig", "Steer", "Bull", "Hog", "Cloud",
				"Lion", "Fox", "Snake", "Panda", "Hippo", "Cobra", "Koala", "Wolf", "Otter", "Tater",
				"Stick", "Stone", "Tree", "Frog", "Toad"
			};
			result = array[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)array))] + array2[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)array2))] + UnityEngine.Random.Range(10, 99).ToString();
		}
		return result;
	}

	public virtual void Login()
	{
		Login(Menu.KeyboardName);
	}

	public virtual void Login(__Menus_LoginCheck_0024callable5_00246585_26__ Check)
	{
		InitializePlayerName();
		if (NewUI != null)
		{
			TextInput(PlayerName, Loc.L("CHOOSE NAME").ToUpper(), 4, PlayNameMaxLength, Check, LoginCompleted);
			return;
		}
		LoginCheck = Check;
		Sho("Login");
		((GUIText)Get("LoginName").GetComponent(typeof(GUIText))).text = PlayerName;
		Menu.KeyboardEntry((GUIText)Get("LoginName").GetComponent(typeof(GUIText)), PlayNameMaxLength, LoginCheck);
	}

	public virtual void LoginCompleted(string TheName)
	{
		SetPlayerName(TheName);
		SendMessage("LoginSubmitted", SendMessageOptions.DontRequireReceiver);
	}

	public virtual void LoginWasPressed(string Name)
	{
		if (NewUI != null)
		{
			return;
		}
		if (Name == "LoginNameBox")
		{
			Menu.KeyboardEntry((GUIText)Get("LoginName").GetComponent(typeof(GUIText)), PlayNameMaxLength, LoginCheck);
		}
		else if (Name == "LoginSubmit")
		{
			string text = ((GUIText)Get("LoginName").GetComponent(typeof(GUIText))).text;
			if (Extensions.get_length(text) < 4)
			{
				((GUIText)Get("LoginError").GetComponent(typeof(GUIText))).text = Loc.L("MinCharacters") + ": 4";
				return;
			}
			Hid("Login");
			LoginCompleted(((GUIText)Menu.Get("LoginName").GetComponent(typeof(GUIText))).text);
		}
	}

	public virtual int Experience()
	{
		return Saver.GetInt(kExperienceKey);
	}

	public virtual int AddExperience(int amount)
	{
		int num = Level();
		int num2 = Experience();
		num2 += amount;
		SetExperience(num2);
		if (Level() > num)
		{
			Menu.SendMessage("GainedLevel", Level(), SendMessageOptions.DontRequireReceiver);
		}
		return num2;
	}

	public virtual void SetExperience(int exp)
	{
		Saver.Set(kExperienceKey, exp);
	}

	public virtual int ExperienceForCompletingLevel(int level)
	{
		int result;
		if (ExperienceFunction != 0)
		{
			result = ((level > 0) ? ((int)(150f * Mathf.Pow(level, 1.55f))) : 0);
		}
		else
		{
			switch (level)
			{
			case 1:
				result = 5 * Menu.kFactor;
				break;
			case 99:
				result = 10000 * Menu.kFactor;
				break;
			default:
			{
				float num = (float)level * 1f / (float)Menu.kMaxLevel * 10f;
				result = (int)((150f * num * num - 9f * num * num * num) * (float)Menu.kFactor);
				break;
			}
			}
		}
		return result;
	}

	public virtual int TotalExperienceAtLevel(int level)
	{
		int num = 0;
		for (int i = 1; i < level; i++)
		{
			num += ExperienceForCompletingLevel(i);
		}
		return num;
	}

	public virtual float Progress()
	{
		int num = Level();
		float result;
		if (num == Menu.kMaxLevel)
		{
			result = 1f;
		}
		else
		{
			int num2 = ExperienceForCompletingLevel(num);
			result = 1f * (float)(Experience() - TotalExperienceAtLevel(num)) / (float)num2;
		}
		return result;
	}

	public virtual int Level()
	{
		int num = Experience();
		int num2 = 0;
		int num3 = 1;
		int result;
		while (true)
		{
			if (num3 <= Menu.kMaxLevel)
			{
				num2 += ExperienceForCompletingLevel(num3);
				if (num2 > num)
				{
					result = num3;
					break;
				}
				num3++;
				continue;
			}
			result = Menu.kMaxLevel;
			break;
		}
		return result;
	}

	public virtual void InitializePrizes()
	{
		CheckUnlocks();
		StartCoroutine(PrizeCounter());
		if (!NewUI)
		{
			StorePrizeText = (GUIText)Get("StorePrizeTimer");
		}
		Tunes = new Dictionary<string, float>();
		TunesStrings = new Dictionary<string, string>();
		TunesList = new System.Collections.Generic.List<string>();
		RefreshedTunes = Saver.GetBoolean("RefreshedTunes");
		SendMessage("InitializeTune", SendMessageOptions.DontRequireReceiver);
		Saver.Set("RefreshedTunes", true);
	}

	public virtual void CheckUnlocks()
	{
		StartCoroutine(Menu.CallScript(App.SystemName + "/checkUnlocks.php?tag=" + Settings.DeviceID + "&DeviceID=" + Settings.DeviceID, HandleUnlocks, FailUnlocks));
	}

	public virtual IEnumerator ClaimPrizeHit(bool VersionCheckBeSureToHandlePrizesInPrizeClaimed)
	{
		return new _0024ClaimPrizeHit_00241155(this).GetEnumerator();
	}

	public virtual void RequestFailed()
	{
	}

	public virtual void DataLoaded(string[] data)
	{
		Menu.Hid("Loading");
		int num = int.Parse(data[0].ToString());
		if (num == 1)
		{
			SendMessage("PrizeClaimed", FirstPrize);
			Saver.Set("NextPrize", DateTime.Now.AddSeconds(TimeBetweenPrizes).ToString());
			Saver.Set("LastPrize", DateTime.Now.ToString());
			if (NewUI == null)
			{
				Popup(Loc.L("PR_Claimed"), Loc.L("PR_ComeBack"));
			}
			Saver.Save();
		}
	}

	public static float Tune(string Name)
	{
		float result;
		if (Tunes.ContainsKey(Name))
		{
			result = Tunes[Name];
		}
		else
		{
			Debug.LogError("Tune key " + Name + " not present in Menus.Tunes dictionary");
			result = 0f;
		}
		return result;
	}

	public static string TuneString(string Name)
	{
		string result;
		if (TunesStrings.ContainsKey(Name))
		{
			result = TunesStrings[Name];
		}
		else
		{
			Debug.LogError("Tune key " + Name + " not present in Menus.TunesStrings dictionary");
			result = string.Empty;
		}
		return result;
	}

	public static void TuneAdd(string SaverVar, float Var)
	{
		if (RuntimeServices.EqualityOperator(TuningVariableIsString, null))
		{
			TuningVariableIsString = new System.Collections.Generic.List<bool>();
		}
		TuningVariableIsString.Add(false);
		ReceivedTuneVariable = true;
		if (Saver.Get(SaverVar) == string.Empty || !RefreshedTunes)
		{
			Saver.SetFloat(SaverVar, Var);
			Tunes[SaverVar] = Var;
		}
		else
		{
			Tunes[SaverVar] = Saver.GetFloat(SaverVar);
		}
		TunesList.Add(SaverVar);
	}

	public static void TuneAdd(string SaverVar, string Var)
	{
		if (RuntimeServices.EqualityOperator(TuningVariableIsString, null))
		{
			TuningVariableIsString = new System.Collections.Generic.List<bool>();
		}
		TuningVariableIsString.Add(true);
		ReceivedTuneVariable = true;
		if (Saver.Get(SaverVar) == string.Empty || !RefreshedTunes)
		{
			Saver.Set(SaverVar, Var);
			TunesStrings[SaverVar] = Var;
		}
		else
		{
			TunesStrings[SaverVar] = Saver.Get(SaverVar);
		}
		TunesList.Add(SaverVar);
	}

	public static void FailUnlocks()
	{
		Menu.SendMessage("CheckUnlocksCompleted", false, SendMessageOptions.DontRequireReceiver);
	}

	public static void HandleUnlocks(string[] data)
	{
		//Discarded unreachable code: IL_0053
		int length = data.Length;
		if (length < 2)
		{
			Menu.SendMessage("CheckUnlocksCompleted", false, SendMessageOptions.DontRequireReceiver);
			return;
		}
		int num;
		try
		{
			num = UnityBuiltins.parseInt(data[0]);
		}
		catch (Exception)
		{
			Menu.SendMessage("CheckUnlocksCompleted", false, SendMessageOptions.DontRequireReceiver);
			return;
		}
		if ((Mathf.Abs(num) == 1 || Mathf.Abs(num) == 2 || Mathf.Abs(num) == 3 || Mathf.Abs(num) == 69 || Mathf.Abs(num) == 70) && length >= 3 && Extensions.get_length(data[1]) == 6)
		{
			if (num > 0)
			{
			}
			Saver.Set("code", data[1]);
			Saver.Set("Secret", data[2]);
			int num2 = 0;
			if ((Mathf.Abs(num) == 2 || Mathf.Abs(num) == 3 || Mathf.Abs(num) == 69 || Mathf.Abs(num) == 70) && length >= 4)
			{
				num2 = 1;
				if (Mathf.Abs(num) == 2)
				{
					int num3 = UnityBuiltins.parseInt(data[3]);
					int value = (int)Mathf.Clamp(Mathf.Round((float)num3 / 13f * 100f), 0f, 100f);
					Saver.Set("Popularity", value);
					Saver.Set("NumberOfFriendsWhoEnteredYourCode", num3);
					Menu.SendMessage("PopularityRetrieved", SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					UsesServerTime = true;
					long result = default(long);
					if (long.TryParse(data[3], out result))
					{
						Menu.StoreServerTime(result);
					}
					switch (num)
					{
					case 69:
						Banned = true;
						Saver.Set("Banned", true);
						break;
					case 70:
						Saver.Set("Banned", false);
						break;
					}
				}
			}
			if (ReceivedTuneVariable)
			{
				if (length >= 4 + num2)
				{
					int num4 = default(int);
					if (length - 3 - num2 >= TunesList.Count)
					{
						for (int i = 3 + num2; i < length; i++)
						{
							if (num4 >= TuningVariableIsString.Count)
							{
								Debug.Log("More server tunes than expected. Value: " + data[i]);
								continue;
							}
							if (!TuningVariableIsString[num4])
							{
								float result2 = default(float);
								if (float.TryParse(data[i], out result2))
								{
									Tunes[TunesList[num4]] = result2;
									Saver.SetFloat(TunesList[num4], result2);
								}
								else
								{
									Debug.LogError("Tuning variable named " + TunesList[num4] + " is a number according to Game.InitializeTune(), but the server variable couldn't be parsed");
								}
							}
							else
							{
								TunesStrings[TunesList[num4]] = data[i];
								Saver.Set(TunesList[num4], data[i]);
							}
							num4++;
						}
					}
					if (ReceivedTuneVariable && length - 3 - num2 != TunesList.Count)
					{
						Debug.LogError("Game.InitializeTune() defined " + TunesList.Count.ToString() + " tunes, but we received " + (length - 3 - num2).ToString() + " from server");
					}
				}
				else
				{
					Debug.LogError("Game.InitializeTune() defined tune variables, but we didn't receive any back from server");
				}
			}
			Menu.SendMessage("CheckUnlocksCompleted", true, SendMessageOptions.DontRequireReceiver);
		}
		else if (num >= 6 && num <= 8 && length > 1)
		{
			int num5 = UnityBuiltins.parseInt(data[1]);
			switch (num)
			{
			case 6:
				if (!PublishingPurchaseReceiver)
				{
					Menu.SendMessage("AddCurrency", num5);
				}
				else
				{
					PublishingPurchaseReceiver.SendMessage("ReceiveGift", num5);
				}
				break;
			case 7:
				Menu.SendMessage("AddGems", num5);
				break;
			case 8:
				if (num5 == 1)
				{
					Saver.Set("MadePurchase", true);
					Saver.Save();
				}
				break;
			}
			Menu.CheckUnlocks();
		}
		else if (num == 9 && length > 1)
		{
			string[] array = Regex.Split(data[1], ",");
			int result3 = default(int);
			if (int.TryParse(array[0], out result3) && result3 > 0)
			{
				Menu.SendMessage("AddCurrency", result3);
			}
			if (Extensions.get_length((System.Array)array) > 1 && int.TryParse(array[1], out result3) && result3 > 0)
			{
				Menu.SendMessage("AddGems", result3);
			}
			Menu.CheckUnlocks();
		}
	}

	public virtual DateTime ServerTime()
	{
		UsesServerTime = true;
		DateTime result;
		if (!ServerTimeSynced)
		{
			StartCoroutine(ResyncServerTimeAfterFailure());
			result = DateTime.Now;
		}
		else
		{
			result = LastServerTime.AddSeconds(Time.time - (float)ServerTimeReverifySubtraction + (float)SupplementalServerSeconds);
		}
		return result;
	}

	public virtual IEnumerator SyncServerTime()
	{
		return new _0024SyncServerTime_00241160(this).GetEnumerator();
	}

	public virtual IEnumerator ResyncServerTimeAfterFailure()
	{
		return new _0024ResyncServerTimeAfterFailure_00241166(this).GetEnumerator();
	}

	public virtual void SyncServerTimeAfterPause(bool Paused)
	{
		if (!UsesServerTime)
		{
			return;
		}
		if (Paused)
		{
			LastPauseTime = DateTime.Now;
			return;
		}
		if (LastPauseTime != DefaultDate)
		{
			SupplementalServerSeconds = (int)((float)SupplementalServerSeconds + Mathf.Clamp((float)DateTime.Now.Subtract(LastPauseTime).TotalSeconds, 0f, float.PositiveInfinity));
		}
		if (SupplementalServerSeconds >= 60 || SupplementalServerSeconds < 0)
		{
			StartCoroutine(SyncServerTime());
		}
	}

	public virtual void StoreServerTime(long TheSeconds)
	{
		UsesServerTime = true;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		ServerTimeSynced = true;
		ServerTimeReverifySubtraction = (int)Time.time;
		SupplementalServerSeconds = 0;
		LastServerTime = dateTime.AddSeconds(TheSeconds);
		SendMessage("ReceivedServerTime", SendMessageOptions.DontRequireReceiver);
	}

	public virtual IEnumerator PrizeCounter()
	{
		return new _0024PrizeCounter_00241169(this).GetEnumerator();
	}

	public virtual void InitializeFriends()
	{
		string text = string.Empty;
		if (MenuParentExists("Friend"))
		{
			text = "Friend";
		}
		else if (MenuParentExists("Profile"))
		{
			text = "Profile";
		}
		if (!(text != string.Empty))
		{
			return;
		}
		if (NewUI != null)
		{
			if ((bool)NewUI.transform.Find(text).Find("FriendEnterBoxBody"))
			{
				FriendEnterBoxBodyUI = (Text)NewUI.transform.Find(text).Find("FriendEnterBoxBody").gameObject.GetComponent(typeof(Text));
			}
			if ((bool)NewUI.transform.Find(text).Find("FriendAdd"))
			{
				FriendAddUI = (Button)NewUI.transform.Find(text).Find("FriendAdd").gameObject.GetComponent(typeof(Button));
			}
			if ((bool)NewUI.transform.Find(text).Find("FriendCodeText"))
			{
				FriendCodeTextUI = (Text)NewUI.transform.Find(text).Find("FriendCodeText").gameObject.GetComponent(typeof(Text));
			}
		}
		else
		{
			FriendEnterBoxBody = (GUIText)Get("FriendEnterBoxBody").GetComponent(typeof(GUIText));
			FriendAdd = Get("FriendAdd").gameObject;
			FriendCodeText = (GUIText)Get("FriendCodeText").GetComponent(typeof(GUIText));
		}
	}

	public virtual void EnteringFriendCode()
	{
		if (!NewUI)
		{
			Menu.KeyboardEntry((GUIText)Get("FriendCodeText").GetComponent(typeof(GUIText)), 6, KeyboardLetNum);
		}
	}

	public virtual void AddFriend()
	{
		string text;
		if (!NewUI)
		{
			text = FriendCodeText.text.ToUpper();
			if (text.Length != 6)
			{
				FriendEnterBoxBody.text = Loc.L("LengthWarning_1") + " 6 " + Loc.L("LengthWarning_2");
				return;
			}
			FriendEnterBoxBody.text = Loc.L("Adding") + "...";
			FriendAdd.SetActive(false);
		}
		else
		{
			text = FriendCodeTextUI.text.ToUpper();
			if (text.Length != 6)
			{
				FriendEnterBoxBodyUI.text = Loc.L("LengthWarning_1") + " 6 " + Loc.L("LengthWarning_2");
				return;
			}
			FriendEnterBoxBodyUI.text = Loc.L("Adding") + "...";
			FriendAddUI.interactable = false;
		}
		int num = 0;
		for (int i = 0; i < 6; i++)
		{
			int num2 = text[i];
			num += num2;
		}
		int num3 = (Settings.DeviceID.Length + 2) * 3 + (num + 3) * (num + 5) + 1;
		StartCoroutine(CallScript(App.SystemName + "/friends.php?tag=" + WWW.EscapeURL(Settings.DeviceID) + "&code=" + text + "&vcode=" + num3, FriendCompleted, FriendError));
	}

	public virtual void FriendCompleted(string[] Message)
	{
		switch (Message[0])
		{
		case "1":
		{
			string empty = string.Empty;
			if (Message.Length >= 2)
			{
				empty = WWW.UnEscapeURL(Message[1]);
			}
			if (!NewUI)
			{
				FriendEnterBoxBody.text = Loc.L("Added");
			}
			else
			{
				FriendEnterBoxBodyUI.text = Loc.L("Added");
			}
			Score("friends");
			SendMessage("AddFriends", Saver.GetInt("friends"), SendMessageOptions.DontRequireReceiver);
			Saver.Save();
			break;
		}
		case "2":
			if (!NewUI)
			{
				FriendEnterBoxBody.text = Loc.L("NoCode");
			}
			else
			{
				FriendEnterBoxBodyUI.text = Loc.L("NoCode");
			}
			break;
		case "3":
			if (!NewUI)
			{
				FriendEnterBoxBody.text = Loc.L("AlreadyFriends");
			}
			else
			{
				FriendEnterBoxBodyUI.text = Loc.L("AlreadyFriends");
			}
			break;
		case "4":
			if (!NewUI)
			{
				FriendEnterBoxBody.text = Loc.L("NoCode");
			}
			else
			{
				FriendEnterBoxBodyUI.text = Loc.L("NoCode");
			}
			break;
		}
		if (!NewUI)
		{
			FriendAdd.SetActive(true);
		}
		else
		{
			FriendAddUI.interactable = true;
		}
	}

	public virtual void FriendError()
	{
		if (!NewUI)
		{
			FriendEnterBoxBody.text = Loc.L("TryLater");
			FriendAdd.SetActive(true);
		}
		else
		{
			FriendEnterBoxBodyUI.text = Loc.L("TryLater");
			FriendAddUI.interactable = true;
		}
	}

	public virtual void FriendsWasPressed(string Name)
	{
		switch (Name)
		{
		case "FriendCodeBox":
			EnteringFriendCode();
			break;
		case "FriendAdd":
			AddFriend();
			break;
		case "FriendEmailCode":
		{
			string subject = Loc.L("FriendSubject");
			string body = Loc.L("FriendBody_1") + " " + App.Name + ": " + Saver.Get("code") + "\n\n" + Loc.L("FriendLast");
			SendEmail(subject, body, true);
			break;
		}
		}
	}

	public virtual void RetrieveFriendCode()
	{
		if ((bool)PublishingPurchaseReceiver)
		{
			PublishingPurchaseReceiver.SendMessage("ReturnFriendCode", Saver.Get("code"));
		}
	}

	public virtual IEnumerator FindMatch(int Mode)
	{
		return new _0024FindMatch_00241181(Mode, this).GetEnumerator();
	}

	public static void AppendMatchAction(string TheData)
	{
		MatchAction += TheData;
	}

	public static string RoundToTenths(float Value)
	{
		string result = (Mathf.Round(Value * 10f) / 10f).ToString("F1");
		if (Mathf.Round(Value * 10f) / 10f == Mathf.Round(Value))
		{
			result = Mathf.Round(Value).ToString("F0");
		}
		return result;
	}

	public virtual IEnumerator ReportYourSimData()
	{
		return new _0024ReportYourSimData_00241191(this).GetEnumerator();
	}

	public virtual void StartMatch(string Message)
	{
		if (!NewMultiplayerSystem)
		{
			UnityScript.Lang.Array array = Regex.Split(Message, ",,,,");
			UnityScript.Lang.Array array2 = array[0].ToString().Split(","[0]);
			object obj = array2[0];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			int num = int.Parse((string)obj);
			object obj2 = array2[1];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			OpponentDatabaseID = int.Parse((string)obj2);
			if (GameMode == 0)
			{
				OpponentName = WWW.UnEscapeURL(array2[2].ToString());
			}
			object obj3 = array2[3];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			int num2 = int.Parse((string)obj3);
			if (array.length > 2)
			{
				IsSim = true;
				MatchActionOpp = array[2].ToString();
				NextMode = num;
				RandomSeed = num2 * -1;
			}
			else
			{
				IsSim = false;
				NextMode = Mathf.Clamp(NextMode, MinimumModeForMultiplayerSync, 999);
				if (Mathf.Clamp(num, MinimumModeForMultiplayerSync, 999) > NextMode)
				{
					NextMode = Mathf.Clamp(num, MinimumModeForMultiplayerSync, 999);
				}
				if (Mathf.Abs(num2) > Mathf.Abs(RandomSeed))
				{
					RandomSeed = num2 * -1;
				}
				StopCoroutine("RetainRandomSeed");
				StartCoroutine("RetainRandomSeed");
			}
			UnityScript.Lang.Array value = Regex.Split(array[1].ToString(), ",,,");
			SendMessage("MatchPrefixOpponent", value);
		}
		else
		{
			OnlinePlayers.Sort(_0024adaptor_0024__Menus_0024callable9_00247870_25___0024Comparison_00243.Adapt(_0024StartMatch_0024closure_0024164));
			for (int i = default(int); i < OnlinePlayers.Count; i++)
			{
				if (OnlinePlayers[i].IsYou)
				{
					YourIndex = i;
				}
				if (i == OnlinePlayers.Count - 1)
				{
					RandomSeed = Mathf.Abs(OnlinePlayers[i].Seed);
					NextMode = Mathf.Clamp(OnlinePlayers[i].Mode, MinimumModeForMultiplayerSync, 999);
				}
			}
			if (DebugMultiplayer)
			{
				string text = "Calling BeginGame. RandomSeed is " + RandomSeed.ToString() + " and OnlinePlayers are: ";
				for (int i = 0; i < OnlinePlayers.Count; i++)
				{
					if (i != 0)
					{
						text += " ~ ";
					}
					text += "Player: " + i.ToString() + "; ";
					text += OnlinePlayers[i].DebugData();
				}
				Debug.Log(text);
			}
		}
		SendMessage("BeginGame", NextMode);
		FoundOpponent = true;
	}

	public virtual IEnumerator RetainRandomSeed()
	{
		return new _0024RetainRandomSeed_00241196().GetEnumerator();
	}

	public virtual void OnApplicationPause(bool pause)
	{
		SyncServerTimeAfterPause(pause);
		if (pause)
		{
			MultiplayerYouDisconnectedMidMatch();
			Saver.Set("LastPauseBoost", DateTime.Now.ToString());
			SendMessage("ApplicationPaused", true, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			ResumeAd();
			SendMessage("ApplicationPaused", false, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void OnApplicationFocus(bool GainedFocus)
	{
	}

	public virtual void MultiplayerYouDisconnectedMidMatch()
	{
		if (!FoundOpponent)
		{
			return;
		}
		if (DebugMultiplayer)
		{
			Debug.Log("Game paused, causing you to disconnect");
		}
		if (!GameEnded)
		{
			Saver.Set("totalLosses", Saver.GetInt("totalLosses") + 1);
			if ((bool)NewUI)
			{
				Menu.Popup(Loc.L("YouDisconnected"), 1f);
			}
			else
			{
				Popup(Loc.L("Disconnected"), Loc.L("YouDisconnected"));
			}
			SendMessage("YouDisconnected", SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			if (!MultiplayerAllowRematch)
			{
				return;
			}
			if ((bool)NewUI)
			{
				Menu.Popup(Loc.L("YouDisconnected"), 1f);
			}
			else if (Settings.Language != "English")
			{
				Popup(Loc.L("Disconnected"), Loc.L("YouDisconnected"));
			}
			else
			{
				Popup(Loc.L("Disconnected"), "The connection to your opponent has been interrupted");
			}
		}
		if (!IsSim)
		{
			Menu.GameCenterDisconnect();
		}
		((Game)GetComponent(typeof(Game))).StopAllCoroutines();
		StartCoroutine(Menu.LoadGame(0));
	}

	public virtual string MultiplayerTrimValue(float Variable, int SpotsAfterDecimal)
	{
		float num = Mathf.Pow(10f, SpotsAfterDecimal);
		float num2 = Mathf.Pow(100f, SpotsAfterDecimal);
		string text = (Mathf.Round(Variable * num) / num).ToString("F" + SpotsAfterDecimal.ToString());
		if (SpotsAfterDecimal != 0)
		{
			if (Mathf.Round(Variable * num) / num == Mathf.Round(Variable * num2) / num2)
			{
				text = Variable.ToString("F" + (SpotsAfterDecimal - 1).ToString());
			}
			if (text.Substring(0, 1) == "0")
			{
				text = text.Substring(1, text.Length - 1);
			}
		}
		return text;
	}

	public virtual void InitializeRematch()
	{
		if (NewUI != null && MenuParentExists("GameOver"))
		{
			GameOverMenu = NewUI.transform.Find("GameOver").gameObject;
			if (GameOverMenu.transform.Find("GameOverSpeechBubble/GameOverSpeech") != null)
			{
				GameOverSpeech = (Text)GameOverMenu.transform.Find("GameOverSpeechBubble/GameOverSpeech").gameObject.GetComponent(typeof(Text));
			}
			if (GameOverMenu.transform.Find("GameOverRematch") != null)
			{
				GameOverRematch = (Button)GameOverMenu.transform.Find("GameOverRematch").gameObject.GetComponent(typeof(Button));
			}
			if (GameOverMenu.transform.Find("GameOverQuit") != null)
			{
				GameOverQuit = (Button)GameOverMenu.transform.Find("GameOverQuit").gameObject.GetComponent(typeof(Button));
			}
		}
	}

	public virtual void RematchReset()
	{
		if (NewUI != null && GameOverSpeech != null && GameOverRematch != null)
		{
			GameOverSpeech.text = "...";
			GameOverRematch.interactable = true;
		}
	}

	public virtual IEnumerator RematchProcessBegan()
	{
		return new _0024RematchProcessBegan_00241197(this).GetEnumerator();
	}

	public virtual IEnumerator RematchRequestedByOpponent(string Message)
	{
		return new _0024RematchRequestedByOpponent_00241207(Message, this).GetEnumerator();
	}

	public virtual void RematchDeniedByOpponent()
	{
		IsRematch = false;
		RematchResponse = -1;
		if (NewUI != null)
		{
			GameOverSpeech.text = Loc.L("GO_GiveUp");
			GameOverRematch.interactable = false;
			return;
		}
		((GUIText)Get("GameOverSpeech").GetComponent(typeof(GUIText))).text = Loc.L("GO_GiveUp");
		((GUITexture)Get("GameOverRematch").GetComponent(typeof(GUITexture))).color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
		if (Get("GameOverRematchText") != null)
		{
			((GUIText)Get("GameOverRematchText").GetComponent(typeof(GUIText))).material.color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
		}
	}

	public virtual void RematchStart(string Message)
	{
		if (!NewUI)
		{
			HidRec("GameOver");
		}
		IsRematch = true;
		if (IsSim && Message != string.Empty)
		{
			StartMatch(Message);
		}
		else
		{
			StartCoroutine(GameCenterMatchmakerFoundMatch(string.Empty));
		}
	}

	public virtual IEnumerator RematchHideButton()
	{
		return new _0024RematchHideButton_00241212(this).GetEnumerator();
	}

	public virtual void RematchWasPressed(string Name)
	{
		if (Name == "GameOverRematch")
		{
			if (!WaitingForRematch && !WaitForRematchCue)
			{
				WaitingForRematch = true;
				if (!IsSim)
				{
					GameCenterSend("Camera", "RematchRequestedByOpponent", string.Empty, true);
				}
				StartCoroutine(RematchHideButton());
			}
		}
		else if (Name == "GameOverQuit")
		{
			if (!IsSim)
			{
				GameCenterSend("Camera", "RematchDeniedByOpponent", string.Empty, true);
				GameCenterDisconnect();
			}
			if (!NewUI)
			{
				HidRec("GameOver");
			}
		}
	}

	public static IEnumerator InitializeGameCenter(int GameCenterWaitTime)
	{
		return new _0024InitializeGameCenter_00241215().GetEnumerator();
	}

	public static bool GameCenterAuthenticated()
	{
		return (AndroidStorefront() == AndroidStorefronts.Google && GameServicesAuthenticated) || ((AndroidStorefront() == AndroidStorefronts.Amazon && AGSClient.IsServiceReady()) ? true : false);
	}

	public static bool RealtimeMultiplayer()
	{
		return AndroidStorefront() != AndroidStorefronts.Amazon && (GameCenterAuthenticated() ? true : false);
	}

	public virtual IEnumerator GameCenterMatchmakerFoundMatch(string GCID)
	{
		return new _0024GameCenterMatchmakerFoundMatch_00241220(GCID, this).GetEnumerator();
	}

	public virtual IEnumerator GameCenterSendWelcome()
	{
		return new _0024GameCenterSendWelcome_00241225(this).GetEnumerator();
	}

	public static string Profanity(string str)
	{
		string[] array = new string[9] { "asshole", "bitch", "bastard", "cunt", "fuck", "shit", "nigger", "faggot", "kike" };
		string[] array2 = new string[8] { "f", "a", "n", "d", "r", "u", "l", "t" };
		for (int i = 0; i < Extensions.get_length((System.Array)array); i++)
		{
			if (str.ToLower().Contains(array[i]))
			{
				string text = string.Empty;
				for (int j = 0; j < Extensions.get_length(array[i]); j++)
				{
					text += array2[UnityEngine.Random.Range(0, 8)];
				}
				str = str.ToLower().Replace(array[i], text);
			}
		}
		return str;
	}

	public virtual void GameCenterPlayerConnected(string Message)
	{
		UnityScript.Lang.Array array = Regex.Split(Message, ",,,,");
		UnityScript.Lang.Array array2 = array[0].ToString().Split(","[0]);
		for (int i = default(int); i < OnlinePlayers.Count; i++)
		{
			if (RuntimeServices.EqualityOperator(OnlinePlayers[i].Key, array2[4]))
			{
				return;
			}
		}
		OnlinePlayers.Add(new OnlinePlayer());
		int index = OnlinePlayers.Count - 1;
		OnlinePlayer onlinePlayer = OnlinePlayers[index];
		object obj = array2[0];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		onlinePlayer.Mode = int.Parse((string)obj);
		OnlinePlayer onlinePlayer2 = OnlinePlayers[index];
		object obj2 = array2[1];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		onlinePlayer2.DatabaseID = int.Parse((string)obj2);
		OnlinePlayers[index].Name = Profanity(NUnEscapeURL(array2[2].ToString()));
		OnlinePlayer onlinePlayer3 = OnlinePlayers[index];
		object obj3 = array2[3];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		onlinePlayer3.Seed = int.Parse((string)obj3);
		OnlinePlayer onlinePlayer4 = OnlinePlayers[index];
		object obj4 = array2[4];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		onlinePlayer4.Key = (string)obj4;
		OnlinePlayer onlinePlayer5 = OnlinePlayers[index];
		object obj5 = array2[5];
		if (!(obj5 is string))
		{
			obj5 = RuntimeServices.Coerce(obj5, typeof(string));
		}
		onlinePlayer5.GCID = (string)obj5;
		OnlinePlayers[index].Prefix = Regex.Split(array[1].ToString(), ",,,");
		if (OnlinePlayers[index].Seed == RandomSeed)
		{
			OnlinePlayers[index].IsYou = true;
		}
		if (DebugMultiplayer)
		{
			Debug.Log("Received welcome message from player " + (OnlinePlayers.Count - 1).ToString() + ": " + Message);
		}
		if (OnlinePlayers.Count == GameCenterPlayersToMatch)
		{
			StopCoroutine("GameCenterSendWelcome");
			Hid("Loading");
			Hid("GoogleGameServices");
			StartMatch(string.Empty);
		}
	}

	public virtual IEnumerator GameCenterTimeoutCountdown()
	{
		return new _0024GameCenterTimeoutCountdown_00241232(this).GetEnumerator();
	}

	public virtual void StartGameCenterTimeoutCountdown()
	{
		StopCoroutine("GameCenterTimeoutCountdown");
		StartCoroutine("GameCenterTimeoutCountdown");
	}

	public virtual void GameCenterMatchFailed(string Message)
	{
		if (DebugMultiplayer)
		{
			Debug.Log("GameCenterMatchFailed was called");
		}
		StartCoroutine(LoadGame(0));
	}

	public static int OnlineKeyToIndex(string Key)
	{
		int num = default(int);
		int result;
		while (true)
		{
			if (num < OnlinePlayers.Count)
			{
				if (OnlinePlayers[num].Key == Key)
				{
					result = num;
					break;
				}
				num++;
				continue;
			}
			Debug.LogError("Couldn't find online player with key " + Key);
			result = 0;
			break;
		}
		return result;
	}

	public static string RandomCharacter()
	{
		string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ23456789";
		int max = Extensions.get_length(text);
		return string.Empty + text[UnityEngine.Random.Range(0, max)];
	}

	public virtual string GameCenterGenerateSyncData(string GCID)
	{
		GenerateRandom();
		SendMessage("MatchPrefixGenerate");
		string result;
		if (!NewMultiplayerSystem)
		{
			result = NextMode + "," + "0," + PlayerName + "," + RandomSeed.ToString() + ",,,," + MatchPrefix;
		}
		else
		{
			string text = NextMode + "," + "0," + NEscapeURL(PlayerName) + "," + RandomSeed.ToString() + "," + MyKey + "," + GCID + ",,,," + MatchPrefix;
			GameCenterPlayerConnected(text);
			result = text;
		}
		return result;
	}

	public virtual void GameCenterInviteRequestWasReceived(string message)
	{
	}

	public static void GameCenterInviteRequestWasSentOrReceived(string Message)
	{
	}

	public virtual void GameCenterDisconnect()
	{
		if (AndroidStorefront() == AndroidStorefronts.Google && GameCenterAuthenticated())
		{
			PlayGamesPlatform.Instance.RealTime.LeaveRoom();
		}
	}

	public virtual void GameCenterPlayerDisconnected(string GCID)
	{
		if (DebugMultiplayer)
		{
			Debug.Log("GameCenterPlayerDisconnected with GCID: " + GCID);
		}
		if (GCID == MyGCID || GameMode == 0 || IsSim || IsSinglePlayer)
		{
			return;
		}
		if (NewMultiplayerSystem)
		{
			for (int i = default(int); i < OnlinePlayers.Count; i++)
			{
				if (OnlinePlayers[i].GCID == GCID && !OnlinePlayers[i].Disconnected)
				{
					OnlinePlayers[i].Disconnected = true;
					SendMessage("MultiplayerPlayerDisconnected", GCID, SendMessageOptions.DontRequireReceiver);
					break;
				}
			}
		}
		else
		{
			SendMessage("LoadGame", (object)0);
			Popup(Loc.L("OpponentDisconnected"), Loc.L("SoreLoser"));
		}
	}

	public virtual void AsyncOpponentDisconnected()
	{
		if (GameMode != 0 && IsSim)
		{
			Menu.SendMessage("LoadGame", (object)0);
			Menu.Popup(Loc.L("OpponentDisconnected"), Loc.L("SoreLoser"));
		}
	}

	public virtual void GameCenterInviteFriend(int Mode)
	{
		GameCenterInviteFriend(Mode, 2, 2);
	}

	public virtual void GameCenterInviteFriend(int Mode, int MinPlayers, int MaxPlayers)
	{
		OnlinePlayers.Clear();
		NextMode = Mode;
		GameCenterPlayersToMatch = MaxPlayers;
		if (GameCenterAuthenticated())
		{
			GameServicesTargetMode = Mode;
			if (RuntimeServices.EqualityOperator(GameServicesMultiplayerListener, null))
			{
				GameServicesMultiplayerListener = new RTMListener();
			}
			if (GameServicesMultiplayerListener.MenusInstance == null)
			{
				GameServicesMultiplayerListener.MenusInstance = this;
			}
			Menu.Sho("GoogleGameServices");
		}
	}

	public static void GameCenterSend(string ObjectName, string FunctionName, string Data, bool Important)
	{
		if (((!IsSim && !IsSinglePlayer) || GameMode == 0) && AndroidStorefront() == AndroidStorefronts.Google)
		{
			Menu.GameServicesMultiplayerListener.GameServicesSendMessage(ObjectName, FunctionName, Data, Important);
		}
	}

	public virtual void GameCenterReceiveMessage(string TheString)
	{
		SecondsUntilGameCenterTimeout = SecondsForGameCenterTimeout;
		string[] array = Regex.Split(TheString, "~~_~~_~~");
		Menu.SendMessage(array[1], array[2], SendMessageOptions.DontRequireReceiver);
	}

	public virtual void GoogleGameServicesWasPressed(string Name)
	{
		switch (Name)
		{
		case "GoogleGameServicesArrow":
			Menu.Hid("GoogleGameServices");
			break;
		case "GoogleGameServicesSendInvite":
			if (GameCenterAuthenticated())
			{
				PlayGamesPlatform.Instance.RealTime.LeaveRoom();
				LoadingDark("Connecting");
				StartCoroutine(AdHold());
				PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen((uint)(GameCenterPlayersToMatch - 1), (uint)(GameCenterPlayersToMatch - 1), 0u, GameServicesMultiplayerListener);
			}
			break;
		case "GoogleGameServicesViewInvites":
			if (GameCenterAuthenticated())
			{
				PlayGamesPlatform.Instance.RealTime.LeaveRoom();
				LoadingDark("Connecting");
				StartCoroutine(AdHold());
				PlayGamesPlatform.Instance.RealTime.AcceptFromInbox(GameServicesMultiplayerListener);
			}
			break;
		case "GoogleGameServicesFindMatch":
			if (GameCenterAuthenticated())
			{
				PlayGamesPlatform.Instance.RealTime.LeaveRoom();
				LoadingDark("Connecting");
				StartCoroutine(AdHold());
				PlayGamesPlatform.Instance.RealTime.CreateQuickGame((uint)(GameCenterPlayersToMatch - 1), (uint)(GameCenterPlayersToMatch - 1), 0u, GameServicesMultiplayerListener);
			}
			break;
		}
	}

	public virtual IEnumerator CallScript(string script, __Menus_GetScores_0024callable4_00246265_52__ returnFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ failFunction)
	{
		return new _0024CallScript_00241235(script, returnFunction, failFunction).GetEnumerator();
	}

	public static string NEscapeURL(string str)
	{
		string result;
		if (str == null || str == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			str = str.Replace("~", string.Empty);
			str = WWW.EscapeURL(str);
			result = str.Replace("+", "%20");
		}
		return result;
	}

	public static string NUnEscapeURL(string str)
	{
		string result;
		if (str == null || str == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			str = str.Replace("%20", "+");
			result = WWW.UnEscapeURL(str);
		}
		return result;
	}

	public static string Hash(string str)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		byte[] bytes = uTF8Encoding.GetBytes(str);
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text += Convert.ToString(array[i], 16).PadLeft(2, "0"[0]);
		}
		return text.PadLeft(32, "0"[0]);
	}

	public virtual void InitializeKeyboard()
	{
	}

	public virtual bool KeyboardIsOpen()
	{
		return (!RuntimeServices.EqualityOperator(Keyboard, null) && Keyboard.active) ? true : false;
	}

	public virtual void KeyboardWasPressed(string Name)
	{
		if (NewUI != null)
		{
			return;
		}
		if (Name == "KeyboardExitX")
		{
			CustomKeyboard.SetActive(false);
			return;
		}
		string text = Name.Substring(11);
		switch (text)
		{
		case "Numbers":
			KeyboardNumbers.SetActive(true);
			KeyboardLetters.SetActive(false);
			return;
		case "Letters":
			KeyboardNumbers.SetActive(false);
			KeyboardLetters.SetActive(true);
			return;
		case "Delete":
			KeyboardDelete();
			return;
		}
		string text2 = text;
		if (text2 == "Space")
		{
			text2 = string.Empty;
		}
		KeyboardAdd(text2);
	}

	public virtual IEnumerator KeyboardEntry(GUIText TheTargetText, int TheMaxLength, __Menus_LoginCheck_0024callable5_00246585_26__ TheCheckFunction, __Menus_PopupSingleCallback_0024callable2_00243643_34__ TheUpdateFunction)
	{
		return new _0024KeyboardEntry_00241245(TheTargetText, TheMaxLength, TheCheckFunction, TheUpdateFunction, this).GetEnumerator();
	}

	public virtual void KeyboardEntry(GUIText TheTargetText, int TheMaxLength, __Menus_LoginCheck_0024callable5_00246585_26__ TheCheckFunction)
	{
		StartCoroutine(KeyboardEntry(TheTargetText, TheMaxLength, TheCheckFunction, null));
	}

	public virtual void KeyboardDelete()
	{
		if (Extensions.get_length(TargetText.text) > 0)
		{
			TargetText.text = TargetText.text.Substring(0, Extensions.get_length(TargetText.text) - 1);
		}
	}

	public virtual void KeyboardAdd(string c)
	{
		TargetText.text += c;
		TargetText.text = CheckFunction(TargetText.text);
		if (Extensions.get_length(TargetText.text) > MaxLength - 1)
		{
			TargetText.text = TargetText.text.Substring(0, MaxLength);
		}
	}

	public virtual string KeyboardLet(string TheText)
	{
		return Regex.Replace(TheText, "[^a-zA-Z]", string.Empty);
	}

	public virtual string KeyboardLetNum(string TheText)
	{
		return Regex.Replace(TheText, "[^a-zA-Z0-9]", string.Empty);
	}

	public virtual string KeyboardLetNumSpace(string TheText)
	{
		return Regex.Replace(TheText, "[^a-zA-Z0-9 ]", string.Empty);
	}

	public virtual string KeyboardLetNumUnd(string TheText)
	{
		return Regex.Replace(TheText, "[^\\w\\._]", string.Empty);
	}

	public virtual string KeyboardEmail(string TheText)
	{
		return TheText;
	}

	public virtual string KeyboardAnything(string TheText)
	{
		return TheText;
	}

	public virtual string KeyboardName(string TheText)
	{
		string result;
		if (TheText == null || TheText == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			TheText = Regex.Replace(TheText, "[^\\w\\._ ]", string.Empty);
			if (TheText == null || TheText == string.Empty)
			{
				result = string.Empty;
			}
			else
			{
//				while (TheText.Contains(' '))
//				{
//					TheText = TheText.Replace(' ', " ");
//				}
				if (TheText[0] == ' ')
				{
					TheText = TheText.Remove(0, 1);
				}
				char[] array = TheText.ToCharArray();
				string text = null;
				for (int i = default(int); i < Extensions.get_length(TheText); i++)
				{
					if (i == 0 || array[i - 1] == ' ')
					{
						array[i] = char.ToUpper(array[i]);
					}
					else if (i < Extensions.get_length(TheText))
					{
						if (TheText[i] == ' ')
						{
							array[i] = char.ToUpper(array[i]);
						}
						else
						{
							array[i] = char.ToLower(array[i]);
						}
					}
					text += array[i].ToString();
				}
				result = text;
			}
		}
		return result;
	}

	public virtual string KeyboardNameNoSpaces(string TheText)
	{
		string result;
		if (TheText == null || TheText == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			TheText = Regex.Replace(TheText, "[^\\w\\._ ]", string.Empty);
			while (TheText.Contains(" "))
			{
				TheText = TheText.Replace(" ", string.Empty);
			}
//			if (TheText[0] == " ")
//			{
//				TheText = TheText.Remove(0, 1);
//			}
			char[] array = TheText.ToCharArray();
			string text = null;
			for (int i = default(int); i < Extensions.get_length(TheText); i++)
			{
				if (i == 0)
				{
					array[i] = char.ToUpper(array[i]);
				}
				else if (i + 1 < Extensions.get_length(TheText))
				{
					array[i + 1] = char.ToLower(array[i + 1]);
				}
				text += array[i].ToString();
			}
			result = text;
		}
		return result;
	}

	public virtual string KeyboardNameNoCapRules(string TheText)
	{
		string result;
		if (TheText == null || TheText == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			TheText = Regex.Replace(TheText, "[^\\w\\._ ]", string.Empty);
			while (TheText.Contains("  "))
			{
				TheText = TheText.Replace("  ", " ");
			}
//			if (TheText[0] == " ")
//			{
//				TheText = TheText.Remove(0, 1);
//			}
			result = TheText;
		}
		return result;
	}

	public static void UnlockTry(string Instance)
	{
		if (Saver.GetInt("Currency") >= UnlockValue(Instance))
		{
			Menu.Popup2(Loc.L("Unlock"), Loc.L("UnlockSure"), Instance);
			Menu.StartCoroutine("UnlockResponse", Instance);
		}
		else if (Menu.UseIAP)
		{
			Menu.Popup2(Loc.L("NotEnough"), Loc.L("GetMoreNow"), "UnlockNotEnough");
		}
		else
		{
			Menu.Popup(Loc.L("NotEnough"), "You do not have enough credits to unlock this item. Keep playing to earn more!");
		}
	}

	public virtual IEnumerator UnlockResponse(string Instance)
	{
		return new _0024UnlockResponse_00241257(Instance, this).GetEnumerator();
	}

	public static bool Unlocked(string Instance)
	{
		return (UnlockCheckIfExists(Instance) && Saver.GetBoolean("Unlocked" + Instance)) ? true : false;
	}

	public static int UnlockValue(string Instance)
	{
		int num;
		UnlockClass[] unlocks;
		if (UnlockCheckIfExists(Instance))
		{
			num = 0;
			unlocks = App.Unlocks;
			int length = unlocks.Length;
			while (num < length)
			{
				if (!(Instance == unlocks[num].Name))
				{
					num++;
					continue;
				}
				goto IL_0032;
			}
		}
		int result = 0;
		goto IL_004b;
		IL_0032:
		result = unlocks[num].Value;
		goto IL_004b;
		IL_004b:
		return result;
	}

	public static bool UnlockCheckIfExists(string Instance)
	{
		bool flag = default(bool);
		int i = 0;
		UnlockClass[] unlocks = App.Unlocks;
		for (int length = unlocks.Length; i < length; i++)
		{
			if (Instance == unlocks[i].Name)
			{
				flag = true;
				break;
			}
		}
		int result;
		if (!flag)
		{
			Debug.LogError(Instance + " does not exist in the App.Unlocks register");
			result = 0;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public virtual void InitializePublishing()
	{
		if (IsPublishingProject)
		{
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			UnityEngine.Object.DontDestroyOnLoad(GUI);
			SendMessage("SetLanguage", Settings.Language, SendMessageOptions.DontRequireReceiver);
			StartCoroutine(Fade(0f));
		}
	}

	public virtual void PurchaseReceiver(GameObject Original)
	{
		PublishingPurchaseReceiver = Original;
	}

	public virtual void PublishingHighScore(string BoardAndScore)
	{
		string[] array = Regex.Split(BoardAndScore, "\\+");
		int result = default(int);
		if (int.TryParse(array[1], out result))
		{
			HighScore(array[0], result);
		}
		else
		{
			Debug.LogError("Couldn't report " + array[0] + " high score because supplied value is not a float");
		}
	}

	public virtual void PublishingAchievement(string AchievementAndScore)
	{
		UnityScript.Lang.Array array = Regex.Split(AchievementAndScore, "\\+");
		float result = default(float);
		object obj = array[1];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		if (float.TryParse((string)obj, out result))
		{
			object obj2 = array[0];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			Achievement((string)obj2, result);
		}
		else
		{
			Debug.LogError("Couldn't report " + array[0] + " achievement because supplied value is not a float");
		}
	}

	public static void Flurry(string Data)
	{
	}

	public virtual IEnumerator CrewAdvance(WWWForm Form)
	{
		return new _0024CrewAdvance_00241262(Form, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}

	internal void _0024Popup_0024closure_0024147()
	{
	}

	internal void _0024Popup_0024closure_0024148()
	{
	}

	internal void _0024Popup_0024closure_0024149()
	{
	}

	internal void _0024Popup_0024closure_0024150()
	{
	}

	internal static void _0024InitializeAds_0024closure_0024157(string adState, string adTag)
	{
		if (adState == "incentivized_result_complete")
		{
			Menu.SendMessage("CompletedRewardedVideo", 0, SendMessageOptions.DontRequireReceiver);
			Menu.SendMessage("RewardedVideoFinished", true);
		}
		if (adState == "incentivized_result_incomplete")
		{
			Menu.SendMessage("RewardedVideoFinished", false);
		}
		if (adState == "audio_starting")
		{
			Menu.SendMessage("MuteAudioForAd", SendMessageOptions.DontRequireReceiver);
		}
		if (adState == "audio_finished")
		{
			Menu.SendMessage("UnMuteAudioForAd", SendMessageOptions.DontRequireReceiver);
		}
	}

	internal static void _0024InitializeAds_0024closure_0024158(string adState, string adTag)
	{
		if (adState == "audio_starting")
		{
			Menu.SendMessage("MuteAudioForAd", SendMessageOptions.DontRequireReceiver);
		}
		if (adState == "audio_finished")
		{
			Menu.SendMessage("UnMuteAudioForAd", SendMessageOptions.DontRequireReceiver);
		}
	}

	internal static void _0024ReportScore_0024closure_0024159(bool success)
	{
	}

	internal static void _0024ReportGameServicesAchievement_0024closure_0024160(bool success)
	{
	}

	internal bool _0024TextInput_0024closure_0024161(string Empty)
	{
		return true;
	}

	internal int _0024StartMatch_0024closure_0024164(OnlinePlayer a, OnlinePlayer b)
	{
		int num = Mathf.Abs(a.Seed) - Mathf.Abs(b.Seed);
		if (num == 0)
		{
			num = a.Key.CompareTo(b.Key);
		}
		return num;
	}

	internal static void _0024InitializeGameCenter_0024closure_0024165(object success)
	{
		if (RuntimeServices.ToBool(success))
		{
			GameServicesAuthenticated = true;
		}
	}
}
