using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;
using System.Collections;

[Serializable]
public class Game : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetColors_0024579 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Mesh _0024mesh_0024580;

			internal Vector3[] _0024vertices_0024581;

			internal Color[] _0024colors_0024582;

			internal Color[] _0024OriginalColors_0024583;

			internal int _0024i_0024584;

			internal GameObject _0024Block_0024585;

			public _0024(GameObject Block)
			{
				_0024Block_0024585 = Block;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024mesh_0024580 = ((MeshFilter)_0024Block_0024585.GetComponent(typeof(MeshFilter))).mesh;
					_0024vertices_0024581 = _0024mesh_0024580.vertices;
					_0024colors_0024582 = new Color[_0024vertices_0024581.Length];
					if (_0024colors_0024582[0] == Color.white)
					{
						goto case 1;
					}
					_0024OriginalColors_0024583 = new Color[Extensions.get_length((System.Array)_0024colors_0024582)];
					for (_0024i_0024584 = default(int); _0024i_0024584 < Extensions.get_length((System.Array)_0024colors_0024582); _0024i_0024584++)
					{
						_0024OriginalColors_0024583[_0024i_0024584] = _0024mesh_0024580.colors[_0024i_0024584];
						_0024colors_0024582[_0024i_0024584] = Color.white;
					}
					_0024mesh_0024580.colors = _0024colors_0024582;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024mesh_0024580.colors = _0024OriginalColors_0024583;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024Block_0024586;

		public _0024SetColors_0024579(GameObject Block)
		{
			_0024Block_0024586 = Block;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Block_0024586);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DestroyFragment_0024587 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024Fragment_0024588;

			public _0024(GameObject Fragment)
			{
				_0024Fragment_0024588 = Fragment;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(1f, 1.5f))) ? 1 : 0);
					break;
				case 2:
					UnityEngine.Object.Destroy(_0024Fragment_0024588);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024Fragment_0024589;

		public _0024DestroyFragment_0024587(GameObject Fragment)
		{
			_0024Fragment_0024589 = Fragment;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024Fragment_0024589);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BeginGame_0024590 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024591;

			internal int _0024Mode_0024592;

			internal Game _0024self__0024593;

			public _0024(int Mode, Game self_)
			{
				_0024Mode_0024592 = Mode;
				_0024self__0024593 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Menu.RestartMenus();
					if (Menus.GameMode != 0)
					{
						_0024self__0024593.StartCoroutine(Menu.LoadGame(_0024Mode_0024592));
						goto IL_0104;
					}
					_0024self__0024593.CameraTargetDestination = new Vector3(4f, 3.66f, 2.6f);
					_0024self__0024593.CameraTargetRotation = new Vector3(9.5f, 0f, 0f);
					_0024Counter_0024591 = default(float);
					goto case 2;
				case 2:
					if (_0024Counter_0024591 < 3f)
					{
						_0024Counter_0024591 += Time.deltaTime;
						_0024self__0024593.Gun2Opponent.transform.Rotate(Vector3.up * Time.deltaTime * 70f, Space.World);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__0024593.StartCoroutine(_0024self__0024593.MoveToRange());
					goto IL_0104;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0104:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Mode_0024594;

		internal Game _0024self__0024595;

		public _0024BeginGame_0024590(int Mode, Game self_)
		{
			_0024Mode_0024594 = Mode;
			_0024self__0024595 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Mode_0024594, _0024self__0024595);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetupGame_0024596 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_0024597;

			internal Transform _0024Block_0024598;

			internal Vector3 _0024Pos_0024599;

			internal IEnumerator _0024_0024iterator_0024171_0024600;

			internal Transform _0024Block_0024601;

			internal IEnumerator _0024_0024iterator_0024172_0024602;

			internal bool _0024NotFirstGame_0024603;

			internal int _0024j_0024604;

			internal GameObject _0024ChosenObject_0024605;

			internal float _0024YourXPosition_0024606;

			internal float _0024OppXPosition_0024607;

			internal GUITexture[] _0024CountdownNumbers_0024608;

			internal float _0024Alpha_0024609;

			internal float _0024_0024307_0024610;

			internal Color _0024_0024308_0024611;

			internal int _0024Mode_0024612;

			internal Game _0024self__0024613;

			public _0024(int Mode, Game self_)
			{
				_0024Mode_0024612 = Mode;
				_0024self__0024613 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024613.TargetSet != null)
					{
						UnityEngine.Object.Destroy(_0024self__0024613.TargetSet);
					}
					Menu.RestartMenus();
					_0024self__0024613.VersusName.gameObject.SetActive(false);
					_0024self__0024613.CoinHUD.enabled = false;
					_0024self__0024613.PrizesThisRound = 0;
					_0024self__0024613.ScoreYou = 0;
					_0024self__0024613.ScoreOpp = 0;
					_0024self__0024613.ScoreFontYou.text = "0";
					_0024self__0024613.ScoreFontOpp.text = "0";
					_0024self__0024613.FragmentsYou0.SetActive(false);
					_0024self__0024613.FragmentsYou1.SetActive(false);
					_0024self__0024613.FragmentsOpp0.SetActive(false);
					_0024self__0024613.FragmentsOpp1.SetActive(false);
					_0024self__0024613.CameraGuns.enabled = true;
					_0024self__0024613.PlantHoverText.GetComponent<Renderer>().enabled = false;
					_0024self__0024613.FarmGroundParent.SetActive(false);
					_0024self__0024613.ChanceCube.SetActive(false);
					_0024self__0024613.DirectionalLight.transform.eulerAngles = _0024self__0024613.DirectionalLightStartingRotation;
					_0024self__0024613.GetComponent<Camera>().fieldOfView = 60f;
					if (_0024Mode_0024612 == 0)
					{
						_0024self__0024613.StartCoroutine("PrizeCounter");
						Guns.Unequip();
						if (_0024self__0024613.Gun2Opponent != null)
						{
							UnityEngine.Object.Destroy(_0024self__0024613.Gun2Opponent);
						}
						if (_0024self__0024613.GunHolder != null)
						{
							UnityEngine.Object.Destroy(_0024self__0024613.GunHolder);
						}
						_0024self__0024613.transform.position = new Vector3(3.89f, 3.87f, -0.83f);
						_0024self__0024613.CameraTargetDestination = new Vector3(3.89f, 3.87f, -0.83f);
						_0024self__0024613.transform.eulerAngles = new Vector3(18f, 0f, 0f);
						_0024self__0024613.CameraTargetRotation = new Vector3(18f, 0f, 0f);
						_0024self__0024613.CameraSwayFactor = 1f;
						_0024self__0024613.CameraMoveFactor = 1f;
						_0024self__0024613.DoorGun.eulerAngles = Vector3.zero;
						if (Menus.FirstOpen)
						{
							_0024self__0024613.StartCoroutine("ShowLogo");
							Menus.FirstOpen = false;
							if (!Saver.GetBoolean("SeenApps" + _0024self__0024613.SeenAppsVersion))
							{
								_0024self__0024613.StartCoroutine("FlashMoreAppsBadge");
							}
							else
							{
								_0024self__0024613.MainMoreBadge.enabled = false;
							}
						}
						else
						{
							_0024self__0024613.ReturnToMain();
						}
						if (Menus.LastMode != 0)
						{
							Menu.FadeAudio(_0024self__0024613.MenuMusic, 0.5f, 1f);
							if (!_0024self__0024613.OfferVideoGold && !Saver.GetBoolean("HasShared") && _0024self__0024613.WonLastGame && Saver.GetInt("totalWins") >= Saver.GetInt("totalLosses") && Saver.GetInt("totalWins") >= 2)
							{
								Saver.Set("HasShared", true);
								Menu.RateApp();
							}
							else if (!_0024self__0024613.OfferVideoGold)
							{
								Menu.MenuReturnAd();
							}
						}
						goto IL_0b2b;
					}
					_0024self__0024613.IsShooting = true;
					_0024self__0024613.CoinAudio.volume = 1f;
					Menu.Achievement("playAMatch", 100f);
					if (_0024Mode_0024612 < 0)
					{
						Menus.OpponentName = "OPP";
						Menus.GenerateRandom();
						Menu.Sho("Pause");
						_0024self__0024613.Difficulty = Saver.GetFloat("Difficulty");
					}
					Menu.Get("NameFontOpp").GetComponent<GUIText>().text = Menus.OpponentName;
					Menu.Get("ScoreFontOpp").GetComponent<GUIText>().text = "0";
					_0024self__0024613.NameFontYou.text = Menus.PlayerName;
					_0024self__0024613.TimerFont.text = "40:00";
					_0024self__0024613.TargetSet = UnityEngine.Object.Instantiate(_0024self__0024613.TargetSets[Mathf.Abs(_0024Mode_0024612) - 1], Vector3.zero, Quaternion.identity);
					TargetArray = new GameObject[_0024self__0024613.TargetSet.transform.childCount];
					_0024self__0024613.TargetsRemaining = Extensions.get_length((System.Array)TargetArray);
					_0024i_0024597 = default(int);
					_0024_0024iterator_0024171_0024600 = UnityRuntimeServices.GetEnumerator(_0024self__0024613.TargetSet.transform);
					while (_0024_0024iterator_0024171_0024600.MoveNext())
					{
						object obj = _0024_0024iterator_0024171_0024600.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024Block_0024598 = (Transform)obj;
						_0024Pos_0024599 = new Vector3(Mathf.Round(_0024Block_0024598.position.x), Mathf.Round(_0024Block_0024598.position.y), Mathf.Round(_0024Block_0024598.position.z));
						UnityRuntimeServices.Update(_0024_0024iterator_0024171_0024600, _0024Block_0024598);
						TargetDictionary[_0024Pos_0024599] = _0024Block_0024598.gameObject;
						UnityRuntimeServices.Update(_0024_0024iterator_0024171_0024600, _0024Block_0024598);
						TargetArray[_0024i_0024597] = _0024Block_0024598.gameObject;
						UnityRuntimeServices.Update(_0024_0024iterator_0024171_0024600, _0024Block_0024598);
						_0024i_0024597++;
					}
					_0024_0024iterator_0024172_0024602 = UnityRuntimeServices.GetEnumerator(_0024self__0024613.TargetSet.transform);
					while (_0024_0024iterator_0024172_0024602.MoveNext())
					{
						object obj2 = _0024_0024iterator_0024172_0024602.Current;
						if (!(obj2 is Transform))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
						}
						_0024Block_0024601 = (Transform)obj2;
						Blocks.SetLighting(_0024Block_0024601.position);
						UnityRuntimeServices.Update(_0024_0024iterator_0024172_0024602, _0024Block_0024601);
					}
					_0024NotFirstGame_0024603 = Saver.GetBoolean("NotFirstGame");
					for (_0024j_0024604 = default(int); _0024j_0024604 < _0024self__0024613.ModePresents[Mathf.Abs(_0024Mode_0024612) - 1]; _0024j_0024604++)
					{
						_0024ChosenObject_0024605 = null;
						while (_0024ChosenObject_0024605 == null || _0024ChosenObject_0024605.GetComponent<Renderer>().material == _0024self__0024613.TargetPresent || (!_0024NotFirstGame_0024603 && Mathf.Abs(_0024Mode_0024612) == 1 && (_0024ChosenObject_0024605.transform.position.z != 8f || (Mathf.Sign(Menus.RandomSeed) == -1f && _0024ChosenObject_0024605.transform.position.x > -21.5f) || (Mathf.Sign(Menus.RandomSeed) == 1f && _0024ChosenObject_0024605.transform.position.x < -18.5f))))
						{
							_0024ChosenObject_0024605 = TargetArray[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)TargetArray))];
						}
						_0024ChosenObject_0024605.GetComponent<Renderer>().material = _0024self__0024613.TargetPresent;
						((Target)_0024ChosenObject_0024605.GetComponent(typeof(Target))).IsPresent = true;
					}
					if (!_0024NotFirstGame_0024603)
					{
						Saver.Set("NotFirstGame", true);
						Saver.Save();
					}
					_0024YourXPosition_0024606 = -23f;
					_0024OppXPosition_0024607 = -17f;
					if (Mathf.Sign(Menus.RandomSeed) == 1f)
					{
						_0024YourXPosition_0024606 = -17f;
						_0024OppXPosition_0024607 = -23f;
					}
					_0024self__0024613.transform.position = new Vector3(_0024YourXPosition_0024606, 3.87f, -4f);
					Guns.OpponentBulletPosition = new Vector3(_0024OppXPosition_0024607, 3.87f, -4f);
					if (Guns.Weapon == null)
					{
						_0024self__0024613.BuildFromSave();
					}
					_0024self__0024613.StartCoroutine(((Guns)_0024self__0024613.GetComponent(typeof(Guns))).Reload());
					Menu.Sho("Score");
					Menu.Sho("Countdown");
					_0024CountdownNumbers_0024608 = new GUITexture[3];
					_0024CountdownNumbers_0024608[0] = Menu.Get("Countdown3").GetComponent<GUITexture>();
					_0024CountdownNumbers_0024608[1] = Menu.Get("Countdown2").GetComponent<GUITexture>();
					_0024CountdownNumbers_0024608[2] = Menu.Get("Countdown1").GetComponent<GUITexture>();
					_0024i_0024597 = 0;
					goto IL_0aa2;
				case 2:
					if (_0024Alpha_0024609 > 0f)
					{
						_0024Alpha_0024609 -= Time.deltaTime * 0.45f;
						float num = (_0024_0024307_0024610 = _0024Alpha_0024609);
						Color color = (_0024_0024308_0024611 = _0024CountdownNumbers_0024608[_0024i_0024597].color);
						float num2 = (_0024_0024308_0024611.a = _0024_0024307_0024610);
						Color color3 = (_0024CountdownNumbers_0024608[_0024i_0024597].color = _0024_0024308_0024611);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024CountdownNumbers_0024608[_0024i_0024597].gameObject.SetActive(false);
					_0024i_0024597++;
					goto IL_0aa2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0aa2:
					if (_0024i_0024597 < Extensions.get_length((System.Array)_0024CountdownNumbers_0024608))
					{
						Menus.EffectsSource.PlayOneShot(_0024self__0024613.BeepLow, 0.7f);
						_0024CountdownNumbers_0024608[_0024i_0024597].gameObject.SetActive(true);
						_0024Alpha_0024609 = 0.5f;
						goto case 2;
					}
					Menus.EffectsSource.PlayOneShot(_0024self__0024613.BeepHigh, 0.7f);
					Guns.AllowOpponentFire = true;
					Menu.Sho("Guns");
					Menu.Sho("Ammo");
					Menu.Sho("Crosshair");
					Menu.Sho("Reload");
					Guns.AllowFireReload = true;
					_0024self__0024613.StartCoroutine("RunGame");
					goto IL_0b2b;
					IL_0b2b:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Mode_0024614;

		internal Game _0024self__0024615;

		public _0024SetupGame_0024596(int Mode, Game self_)
		{
			_0024Mode_0024614 = Mode;
			_0024self__0024615 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Mode_0024614, _0024self__0024615);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RunGame_0024616 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024TimeRemaining_0024617;

			internal float _0024StartTime_0024618;

			internal int _0024seconds_0024619;

			internal int _0024fraction_0024620;

			internal Game _0024self__0024621;

			public _0024(Game self_)
			{
				_0024self__0024621 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_012f
				int result;
				switch (_state)
				{
				default:
					if (Menus.IsSim)
					{
						_0024self__0024621.StartCoroutine("SimMatch");
					}
					else if (Menus.GameMode < 1)
					{
						_0024self__0024621.StartCoroutine("SimPractice");
					}
					_0024self__0024621.LastFire = Time.time;
					_0024TimeRemaining_0024617 = default(float);
					_0024StartTime_0024618 = Time.time;
					goto case 2;
				case 2:
					_0024TimeRemaining_0024617 = 40f + _0024StartTime_0024618 - Time.time;
					_0024seconds_0024619 = (int)(_0024TimeRemaining_0024617 % 60f);
					_0024fraction_0024620 = (int)(_0024TimeRemaining_0024617 * 100f % 100f);
					if (!(_0024TimeRemaining_0024617 >= 0f))
					{
						_0024self__0024621.TimerFont.text = "0.00";
						_0024self__0024621.GameOver();
						goto case 1;
					}
					_0024self__0024621.TimerFont.text = string.Format("{0:0}.{1:00}", _0024seconds_0024619, _0024fraction_0024620);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024622;

		public _0024RunGame_0024616(Game self_)
		{
			_0024self__0024622 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024622);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SimMatch_0024623 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024SimData_0024624;

			internal int _0024i_0024625;

			internal UnityScript.Lang.Array _0024SimPiece_0024626;

			internal GameObject _0024OpponentTarget_0024627;

			internal GameObject _0024Targ_0024628;

			internal Vector3 _0024TargetPosition_0024629;

			internal float _0024Range_0024630;

			internal Vector2 _0024Miss_0024631;

			internal int _0024_0024197_0024632;

			internal GameObject[] _0024_0024198_0024633;

			internal int _0024_0024199_0024634;

			internal Game _0024self__0024635;

			public _0024(Game self_)
			{
				_0024self__0024635 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_03da
				int result;
				switch (_state)
				{
				default:
					_0024SimData_0024624 = Regex.Split(Menus.MatchActionOpp, ",,");
					_0024i_0024625 = 1;
					goto IL_014a;
				case 2:
					_0024self__0024635.StartCoroutine(((Guns)_0024self__0024635.GetComponent(typeof(Guns))).OpponentFire(_0024SimPiece_0024626[1].ToString() + "," + _0024SimPiece_0024626[2].ToString() + "," + _0024SimPiece_0024626[3].ToString()));
					_0024i_0024625++;
					goto IL_014a;
				case 4:
					_0024i_0024625 = 1;
					goto IL_03b3;
				case 3:
					if (_0024OpponentTarget_0024627 == null || !_0024OpponentTarget_0024627.activeInHierarchy)
					{
						_0024_0024197_0024632 = 0;
						_0024_0024198_0024633 = TargetArray;
						for (_0024_0024199_0024634 = _0024_0024198_0024633.Length; _0024_0024197_0024632 < _0024_0024199_0024634; _0024_0024197_0024632++)
						{
							if (_0024_0024198_0024633[_0024_0024197_0024632].activeInHierarchy)
							{
								_0024OpponentTarget_0024627 = _0024_0024198_0024633[_0024_0024197_0024632];
							}
						}
					}
					_0024TargetPosition_0024629 = _0024OpponentTarget_0024627.transform.position;
					_0024Range_0024630 = _0024OpponentTarget_0024627.transform.position.z / 10f / (float)(_0024self__0024635.OpponentSet / 3 + 1);
					_0024Miss_0024631 = new Vector2(UnityEngine.Random.Range(0f - _0024Range_0024630, _0024Range_0024630), UnityEngine.Random.Range(0f - _0024Range_0024630, _0024Range_0024630));
					_0024TargetPosition_0024629 += new Vector3(_0024Miss_0024631.x, _0024Miss_0024631.y, 0f);
					_0024self__0024635.StartCoroutine(((Guns)_0024self__0024635.GetComponent(typeof(Guns))).OpponentFire(_0024TargetPosition_0024629.x.ToString() + "," + _0024TargetPosition_0024629.y.ToString() + "," + _0024TargetPosition_0024629.z.ToString()));
					_0024i_0024625++;
					goto IL_03b3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03b3:
					if (_0024i_0024625 < _0024SimData_0024624.length)
					{
						_0024SimPiece_0024626 = _0024SimData_0024624[_0024i_0024625].ToString().Split(","[0]);
						object obj = _0024SimPiece_0024626[0];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						result = (Yield(3, new WaitForSeconds(float.Parse((string)obj))) ? 1 : 0);
					}
					else
					{
						result = (YieldDefault(4) ? 1 : 0);
					}
					break;
					IL_014a:
					if (_0024i_0024625 < _0024SimData_0024624.length)
					{
						_0024SimPiece_0024626 = _0024SimData_0024624[_0024i_0024625].ToString().Split(","[0]);
						object obj2 = _0024SimPiece_0024626[0];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						result = (Yield(2, new WaitForSeconds(float.Parse((string)obj2))) ? 1 : 0);
						break;
					}
					_0024OpponentTarget_0024627 = null;
					goto case 4;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024636;

		public _0024SimMatch_0024623(Game self_)
		{
			_0024self__0024636 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024636);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SimPractice_0024637 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024OpponentTarget_0024638;

			internal int _0024ShotsTaken_0024639;

			internal float _0024UsableDifficulty_0024640;

			internal GameObject _0024Targ_0024641;

			internal Vector3 _0024TargetPosition_0024642;

			internal float _0024Range_0024643;

			internal Vector2 _0024Miss_0024644;

			internal int _0024_0024201_0024645;

			internal GameObject[] _0024_0024202_0024646;

			internal int _0024_0024203_0024647;

			internal Game _0024self__0024648;

			public _0024(Game self_)
			{
				_0024self__0024648 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0288
				int result;
				switch (_state)
				{
				default:
					_0024OpponentTarget_0024638 = null;
					_0024ShotsTaken_0024639 = default(int);
					goto IL_0033;
				case 2:
					_0024ShotsTaken_0024639 = 0;
					goto IL_00b8;
				case 3:
					if (_0024OpponentTarget_0024638 == null || !_0024OpponentTarget_0024638.activeInHierarchy)
					{
						_0024_0024201_0024645 = 0;
						_0024_0024202_0024646 = TargetArray;
						for (_0024_0024203_0024647 = _0024_0024202_0024646.Length; _0024_0024201_0024645 < _0024_0024203_0024647; _0024_0024201_0024645++)
						{
							if (_0024_0024202_0024646[_0024_0024201_0024645].activeInHierarchy)
							{
								_0024OpponentTarget_0024638 = _0024_0024202_0024646[_0024_0024201_0024645];
							}
						}
					}
					_0024TargetPosition_0024642 = _0024OpponentTarget_0024638.transform.position;
					_0024Range_0024643 = _0024OpponentTarget_0024638.transform.position.z / 10f / 4f;
					_0024Miss_0024644 = new Vector2(UnityEngine.Random.Range(0f - _0024Range_0024643, _0024Range_0024643), UnityEngine.Random.Range(0f - _0024Range_0024643, _0024Range_0024643));
					_0024TargetPosition_0024642 += new Vector3(_0024Miss_0024644.x, _0024Miss_0024644.y, 0f);
					_0024self__0024648.StartCoroutine(((Guns)_0024self__0024648.GetComponent(typeof(Guns))).OpponentFire(_0024TargetPosition_0024642.x.ToString() + "," + _0024TargetPosition_0024642.y.ToString() + "," + _0024TargetPosition_0024642.z.ToString()));
					goto IL_0033;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0033:
					_0024UsableDifficulty_0024640 = (1f - _0024self__0024648.Difficulty) * 0.7f;
					_0024self__0024648.OpponentSet = (int)Mathf.Round(_0024self__0024648.Difficulty * 3f);
					_0024ShotsTaken_0024639++;
					if (!((float)_0024ShotsTaken_0024639 <= _0024self__0024648.Difficulty * 22f + 8f))
					{
						result = (Yield(2, new WaitForSeconds(0.8f)) ? 1 : 0);
						break;
					}
					goto IL_00b8;
					IL_00b8:
					result = (Yield(3, new WaitForSeconds(UnityEngine.Random.Range(0.08f, _0024UsableDifficulty_0024640 + 0.45f))) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024649;

		public _0024SimPractice_0024637(Game self_)
		{
			_0024self__0024649 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024649);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowCoin_0024650 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024StartingPoint_0024651;

			internal float _0024Counter_0024652;

			internal float _0024_0024309_0024653;

			internal Color _0024_0024310_0024654;

			internal int _0024_0024311_0024655;

			internal Rect _0024_0024312_0024656;

			internal float _0024_0024313_0024657;

			internal Rect _0024_0024314_0024658;

			internal float _0024_0024315_0024659;

			internal Color _0024_0024316_0024660;

			internal Game _0024self__0024661;

			public _0024(Game self_)
			{
				_0024self__0024661 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024self__0024661.CoinHUD.enabled = true;
					float num = (_0024_0024309_0024653 = 0.5f);
					Color color = (_0024_0024310_0024654 = _0024self__0024661.CoinHUD.color);
					float num2 = (_0024_0024310_0024654.a = _0024_0024309_0024653);
					Color color3 = (_0024self__0024661.CoinHUD.color = _0024_0024310_0024654);
					_0024StartingPoint_0024651 = (int)(5f * Settings.Scale);
					_0024Counter_0024652 = 0f;
					int num3 = (_0024_0024311_0024655 = _0024StartingPoint_0024651);
					Rect rect = (_0024_0024312_0024656 = _0024self__0024661.CoinHUD.pixelInset);
					float num5 = (_0024_0024312_0024656.y = _0024_0024311_0024655);
					Rect rect3 = (_0024self__0024661.CoinHUD.pixelInset = _0024_0024312_0024656);
					goto case 2;
				}
				case 2:
					if (_0024Counter_0024652 < 100f)
					{
						_0024Counter_0024652 += 100f * Time.deltaTime;
						float num6 = (_0024_0024313_0024657 = (float)_0024StartingPoint_0024651 + _0024Counter_0024652 * Settings.DPI / 100f);
						Rect rect4 = (_0024_0024314_0024658 = _0024self__0024661.CoinHUD.pixelInset);
						float num8 = (_0024_0024314_0024658.y = _0024_0024313_0024657);
						Rect rect6 = (_0024self__0024661.CoinHUD.pixelInset = _0024_0024314_0024658);
						float num9 = (_0024_0024315_0024659 = 0.5f - _0024Counter_0024652 / 100f);
						Color color4 = (_0024_0024316_0024660 = _0024self__0024661.CoinHUD.color);
						float num10 = (_0024_0024316_0024660.a = _0024_0024315_0024659);
						Color color6 = (_0024self__0024661.CoinHUD.color = _0024_0024316_0024660);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__0024661.CoinHUD.enabled = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024662;

		public _0024ShowCoin_0024650(Game self_)
		{
			_0024self__0024662 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024662);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GameOverCoinCount_0024663 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024PreviousCoins_0024664;

			internal int _0024i_0024665;

			internal Game _0024self__0024666;

			public _0024(Game self_)
			{
				_0024self__0024666 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024PreviousCoins_0024664 = int.Parse(_0024self__0024666.TickerText.text);
					_0024self__0024666.AddCurrency(_0024self__0024666.CoinsEarned);
					_0024self__0024666.CoinAudio.volume = 0.7f;
					_0024self__0024666.TickerText.text = _0024PreviousCoins_0024664.ToString();
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024i_0024665 = default(int);
					goto IL_00fe;
				case 3:
					_0024self__0024666.CoinAudio.Play();
					_0024self__0024666.TickerText.text = (_0024PreviousCoins_0024664 + _0024i_0024665 + 1).ToString();
					_0024i_0024665++;
					goto IL_00fe;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00fe:
					if (_0024i_0024665 < _0024self__0024666.CoinsEarned)
					{
						result = (Yield(3, new WaitForSeconds(0.3f)) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024667;

		public _0024GameOverCoinCount_0024663(Game self_)
		{
			_0024self__0024667 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024667);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GameOverXPBar_0024668 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GUITexture _0024GameOverFill_0024669;

			internal float _0024StartingWidth_0024670;

			internal float _0024_0024319_0024671;

			internal Rect _0024_0024320_0024672;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024GameOverFill_0024669 = Menu.Get("GameOverFill").GetComponent<GUITexture>();
					_0024StartingWidth_0024670 = _0024GameOverFill_0024669.pixelInset.width;
					goto case 2;
				case 2:
					if (_0024GameOverFill_0024669.pixelInset.width < Menu.Progress() * 228.5f * Settings.Scale)
					{
						float num = (_0024_0024319_0024671 = Mathf.Clamp(_0024GameOverFill_0024669.pixelInset.width + Time.deltaTime * Settings.DPI / 2.5f, 0f, Menu.Progress() * 228.5f * Settings.Scale));
						Rect rect = (_0024_0024320_0024672 = _0024GameOverFill_0024669.pixelInset);
						float num3 = (_0024_0024320_0024672.width = _0024_0024319_0024671);
						Rect rect3 = (_0024GameOverFill_0024669.pixelInset = _0024_0024320_0024672);
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowLogo_0024673 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024Alpha_0024674;

			internal float _0024_0024321_0024675;

			internal Color _0024_0024322_0024676;

			internal float _0024_0024323_0024677;

			internal Color _0024_0024324_0024678;

			internal Game _0024self__0024679;

			public _0024(Game self_)
			{
				_0024self__0024679 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Menu.Sho("Logo");
					if (!Settings.IsPro)
					{
						_0024self__0024679.Logo.gameObject.SetActive(true);
						_0024self__0024679.LogoPro.gameObject.SetActive(false);
					}
					else
					{
						_0024self__0024679.Logo.gameObject.SetActive(false);
						_0024self__0024679.LogoPro.gameObject.SetActive(true);
					}
					result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
					break;
				case 2:
					_0024Alpha_0024674 = default(float);
					goto case 3;
				case 3:
					if (_0024Alpha_0024674 < 0.5f)
					{
						_0024Alpha_0024674 += Time.deltaTime * 1f;
						_0024Alpha_0024674 = Mathf.Clamp(_0024Alpha_0024674, 0f, 0.5f);
						float num = (_0024_0024321_0024675 = _0024Alpha_0024674);
						Color color = (_0024_0024322_0024676 = _0024self__0024679.Logo.color);
						float num2 = (_0024_0024322_0024676.a = _0024_0024321_0024675);
						Color color3 = (_0024self__0024679.Logo.color = _0024_0024322_0024676);
						float num3 = (_0024_0024323_0024677 = _0024self__0024679.Logo.color.a);
						Color color4 = (_0024_0024324_0024678 = _0024self__0024679.LogoPro.color);
						float num4 = (_0024_0024324_0024678.a = _0024_0024323_0024677);
						Color color6 = (_0024self__0024679.LogoPro.color = _0024_0024324_0024678);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__0024679.LogoControl.SetActive(false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024680;

		public _0024ShowLogo_0024673(Game self_)
		{
			_0024self__0024680 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024680);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowLogoFast_0024681 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Alpha_0024682;

			internal float _0024_0024325_0024683;

			internal Color _0024_0024326_0024684;

			internal float _0024_0024327_0024685;

			internal Color _0024_0024328_0024686;

			internal Game _0024self__0024687;

			public _0024(Game self_)
			{
				_0024self__0024687 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024Alpha_0024682 = _0024self__0024687.Logo.color.a;
					goto case 2;
				case 2:
					if (_0024Alpha_0024682 < 0.5f)
					{
						_0024Alpha_0024682 += Time.deltaTime * 3f;
						_0024Alpha_0024682 = Mathf.Clamp(_0024Alpha_0024682, 0f, 0.5f);
						float num = (_0024_0024325_0024683 = _0024Alpha_0024682);
						Color color = (_0024_0024326_0024684 = _0024self__0024687.Logo.color);
						float num2 = (_0024_0024326_0024684.a = _0024_0024325_0024683);
						Color color3 = (_0024self__0024687.Logo.color = _0024_0024326_0024684);
						float num3 = (_0024_0024327_0024685 = _0024self__0024687.Logo.color.a);
						Color color4 = (_0024_0024328_0024686 = _0024self__0024687.LogoPro.color);
						float num4 = (_0024_0024328_0024686.a = _0024_0024327_0024685);
						Color color6 = (_0024self__0024687.LogoPro.color = _0024_0024328_0024686);
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

		internal Game _0024self__0024688;

		public _0024ShowLogoFast_0024681(Game self_)
		{
			_0024self__0024688 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024688);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FlashMoreAppsBadge_0024689 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024ColorTracker_0024690;

			internal Game _0024self__0024691;

			public _0024(Game self_)
			{
				_0024self__0024691 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_00fc
				int result;
				switch (_state)
				{
				default:
					_0024ColorTracker_0024690 = 0.3f;
					goto case 2;
				case 2:
					if (_0024ColorTracker_0024690 < 0.65f)
					{
						_0024ColorTracker_0024690 += 0.9f * Time.deltaTime;
						_0024self__0024691.MainMoreBadge.color = new Color(_0024ColorTracker_0024690, _0024ColorTracker_0024690, _0024ColorTracker_0024690, _0024ColorTracker_0024690);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (!(_0024ColorTracker_0024690 > 0.2f))
					{
						goto case 2;
					}
					_0024ColorTracker_0024690 -= 0.9f * Time.deltaTime;
					_0024self__0024691.MainMoreBadge.color = new Color(_0024ColorTracker_0024690, _0024ColorTracker_0024690, _0024ColorTracker_0024690, _0024ColorTracker_0024690);
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024692;

		public _0024FlashMoreAppsBadge_0024689(Game self_)
		{
			_0024self__0024692 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024692);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Tutorial_0024693 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Game _0024self__0024694;

			public _0024(Game self_)
			{
				_0024self__0024694 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Menus.Flurry("Tutorial,State,Began");
					_0024self__0024694.MainMoreBadge.gameObject.SetActive(false);
					_0024self__0024694.MainUse.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainUseText.enabled = false;
					_0024self__0024694.MainTrophy.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainTrophyText.enabled = false;
					_0024self__0024694.MainShare.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainShareText.enabled = false;
					_0024self__0024694.MainSettings.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainMore.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainMoreBadge.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					Menu.Hid("Ticker");
					Menus.IsTutorial = true;
					Menus.TutorialAllow = "MainBuild";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.MainBuild);
					goto case 2;
				case 2:
					if (Menus.TutorialState == 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.MainBuild.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainBuildText.enabled = false;
					Menus.TutorialAllow = "SavesBox0";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.SavesBoxes[0]);
					goto case 3;
				case 3:
					if (Menus.TutorialState == 1)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.SavesBoxes[0].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menus.TutorialAllow = "GridsBox0";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.GridsBoxes[0]);
					goto case 4;
				case 4:
					if (Menus.TutorialState == 2)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.GridsBoxes[0].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.SetsArrowRight.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
					Menus.TutorialAllow = "SetsSelect";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.SetsSelect);
					goto case 5;
				case 5:
					if (Menus.TutorialState == 3)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.SetsSelect.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menus.TutorialAllow = "InventoryItem0";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.InventoryItems[0]);
					goto case 6;
				case 6:
					if (Menus.TutorialState == 4)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[0]);
					goto case 7;
				case 7:
					if (Menus.TutorialState == 5)
					{
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[0].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "InventoryItem3";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.InventoryItems[3]);
					goto case 8;
				case 8:
					if (Menus.TutorialState == 6)
					{
						result = (YieldDefault(8) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[1]);
					goto case 9;
				case 9:
					if (Menus.TutorialState == 7)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[1].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[2]);
					goto case 10;
				case 10:
					if (Menus.TutorialState == 8)
					{
						result = (YieldDefault(10) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[2].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[3]);
					goto case 11;
				case 11:
					if (Menus.TutorialState == 9)
					{
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[3].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[4]);
					goto case 12;
				case 12:
					if (Menus.TutorialState == 10)
					{
						result = (YieldDefault(12) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[4].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "InventoryItem1";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.InventoryItems[1]);
					goto case 13;
				case 13:
					if (Menus.TutorialState == 11)
					{
						result = (YieldDefault(13) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[5]);
					goto case 14;
				case 14:
					if (Menus.TutorialState == 12)
					{
						result = (YieldDefault(14) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[5].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "InventoryItem2";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.InventoryItems[2]);
					goto case 15;
				case 15:
					if (Menus.TutorialState == 13)
					{
						result = (YieldDefault(15) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					Menus.TutorialAllow = "Asdf";
					_0024self__0024694.StartCoroutine("TutorialFlashBlock", _0024self__0024694.BlockTutorialFlashes[6]);
					goto case 16;
				case 16:
					if (Menus.TutorialState == 14)
					{
						result = (YieldDefault(16) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashBlock");
					_0024self__0024694.BlockTutorialFlashes[6].GetComponent<Renderer>().sharedMaterial = _0024self__0024694.BlockTutorialRegularMat;
					Menus.TutorialAllow = "InventoryBack";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.InventoryBack);
					goto case 17;
				case 17:
					if (Menus.TutorialState == 15)
					{
						result = (YieldDefault(17) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.InventoryBack.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.SaveOrTrashTrash.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					Menus.TutorialAllow = "SaveOrTrashSave";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.SaveOrTrashSave);
					goto case 18;
				case 18:
					if (Menus.TutorialState == 16)
					{
						result = (YieldDefault(18) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.SaveOrTrashTrash.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.SaveOrTrashSave.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menus.TutorialAllow = "SaveGunSubmit";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.SaveGunSubmit);
					goto case 19;
				case 19:
					if (Menus.TutorialState == 17)
					{
						result = (YieldDefault(19) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.SaveGunSubmit.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainUse.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					_0024self__0024694.MainShare.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
					Menus.TutorialAllow = "TickerImage";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.Ticker);
					goto case 20;
				case 20:
					if (Menus.TutorialState == 18)
					{
						result = (YieldDefault(20) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.Ticker.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menus.TutorialAllow = "StorePrize";
					_0024self__0024694.StartCoroutine("TutorialFlashPrize", _0024self__0024694.StorePrize);
					goto case 21;
				case 21:
					if (Menus.TutorialState == 19)
					{
						result = (YieldDefault(21) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlashPrize");
					_0024self__0024694.StorePrize.enabled = false;
					_0024self__0024694.MainBuild.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainBuildText.enabled = true;
					_0024self__0024694.MainUse.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainUseText.enabled = true;
					_0024self__0024694.MainTrophy.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainTrophyText.enabled = true;
					_0024self__0024694.MainShare.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainShareText.enabled = true;
					_0024self__0024694.MainSettings.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainMore.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					_0024self__0024694.MainMoreBadge.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					goto case 22;
				case 22:
					if (!_0024self__0024694.PopupMenu.activeInHierarchy)
					{
						result = (YieldDefault(22) ? 1 : 0);
						break;
					}
					Menus.IsTutorial = false;
					goto case 23;
				case 23:
					if (_0024self__0024694.PopupMenu.activeInHierarchy)
					{
						result = (YieldDefault(23) ? 1 : 0);
						break;
					}
					Menus.IsTutorial = true;
					Menus.TutorialAllow = "StoreBack";
					_0024self__0024694.StartCoroutine("TutorialFlash", _0024self__0024694.StoreBack);
					goto case 24;
				case 24:
					if (Menus.TutorialState == 21)
					{
						result = (YieldDefault(24) ? 1 : 0);
						break;
					}
					_0024self__0024694.StopCoroutine("TutorialFlash");
					_0024self__0024694.StoreBack.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menus.IsTutorial = false;
					_0024self__0024694.MainMoreBadge.gameObject.SetActive(true);
					Menus.Flurry("Tutorial,State,Finished");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024695;

		public _0024Tutorial_0024693(Game self_)
		{
			_0024self__0024695 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024695);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TutorialFlash_0024696 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024697;

			internal bool _0024FlashOn_0024698;

			internal GUITexture _0024Target_0024699;

			public _0024(GUITexture Target)
			{
				_0024Target_0024699 = Target;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_00d6
				int result;
				switch (_state)
				{
				default:
					_0024Counter_0024697 = default(float);
					_0024FlashOn_0024698 = default(bool);
					goto case 2;
				case 2:
					_0024Counter_0024697 += Time.deltaTime;
					if (!(_0024Counter_0024697 <= 0.25f))
					{
						_0024Counter_0024697 = 0f;
						_0024FlashOn_0024698 = !_0024FlashOn_0024698;
						if (_0024FlashOn_0024698)
						{
							_0024Target_0024699.color = new Color(1f, 1f, 1f, 0.8f);
						}
						else
						{
							_0024Target_0024699.color = new Color(0.3f, 0.3f, 0.3f, 0.5f);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GUITexture _0024Target_0024700;

		public _0024TutorialFlash_0024696(GUITexture Target)
		{
			_0024Target_0024700 = Target;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Target_0024700);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TutorialFlashPrize_0024701 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024702;

			internal bool _0024FlashOn_0024703;

			internal GUITexture _0024Target_0024704;

			public _0024(GUITexture Target)
			{
				_0024Target_0024704 = Target;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_00a6
				int result;
				switch (_state)
				{
				default:
					_0024Counter_0024702 = default(float);
					_0024FlashOn_0024703 = default(bool);
					goto case 2;
				case 2:
					_0024Counter_0024702 += Time.deltaTime;
					if (!(_0024Counter_0024702 <= 0.25f))
					{
						_0024Counter_0024702 = 0f;
						_0024FlashOn_0024703 = !_0024FlashOn_0024703;
						if (_0024FlashOn_0024703)
						{
							_0024Target_0024704.enabled = true;
						}
						else
						{
							_0024Target_0024704.enabled = false;
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GUITexture _0024Target_0024705;

		public _0024TutorialFlashPrize_0024701(GUITexture Target)
		{
			_0024Target_0024705 = Target;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Target_0024705);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TutorialFlashBlock_0024706 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024707;

			internal bool _0024FlashOn_0024708;

			internal GameObject _0024Target_0024709;

			internal Game _0024self__0024710;

			public _0024(GameObject Target, Game self_)
			{
				_0024Target_0024709 = Target;
				_0024self__0024710 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_00c4
				int result;
				switch (_state)
				{
				default:
					_0024Counter_0024707 = default(float);
					_0024FlashOn_0024708 = default(bool);
					goto case 2;
				case 2:
					_0024Counter_0024707 += Time.deltaTime;
					if (!(_0024Counter_0024707 <= 0.25f))
					{
						_0024Counter_0024707 = 0f;
						_0024FlashOn_0024708 = !_0024FlashOn_0024708;
						if (_0024FlashOn_0024708)
						{
							_0024Target_0024709.GetComponent<Renderer>().sharedMaterial = _0024self__0024710.BlockTutorialFlashMat;
						}
						else
						{
							_0024Target_0024709.GetComponent<Renderer>().sharedMaterial = _0024self__0024710.BlockTutorialRegularMat;
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024Target_0024711;

		internal Game _0024self__0024712;

		public _0024TutorialFlashBlock_0024706(GameObject Target, Game self_)
		{
			_0024Target_0024711 = Target;
			_0024self__0024712 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Target_0024711, _0024self__0024712);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InventoryFlashBarrel_0024713 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024714;

			internal bool _0024FlashOn_0024715;

			internal Game _0024self__0024716;

			public _0024(Game self_)
			{
				_0024self__0024716 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_00fd
				int result;
				switch (_state)
				{
				default:
					_0024self__0024716.StartCoroutine(_0024self__0024716.SwitchType(9));
					_0024Counter_0024714 = default(float);
					_0024FlashOn_0024715 = default(bool);
					goto case 2;
				case 2:
					_0024Counter_0024714 += Time.deltaTime;
					if (!(_0024Counter_0024714 <= 0.25f))
					{
						_0024Counter_0024714 = 0f;
						_0024FlashOn_0024715 = !_0024FlashOn_0024715;
						if (_0024FlashOn_0024715)
						{
							_0024self__0024716.InventoryItems[0].color = new Color(1f, 1f, 1f, 0.8f);
						}
						else
						{
							_0024self__0024716.InventoryItems[0].color = new Color(0.3f, 0.3f, 0.3f, 0.5f);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024717;

		public _0024InventoryFlashBarrel_0024713(Game self_)
		{
			_0024self__0024717 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024717);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SwitchType_0024718 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_0024719;

			internal float _0024_0024349_0024720;

			internal Color _0024_0024350_0024721;

			internal float _0024_0024351_0024722;

			internal Color _0024_0024352_0024723;

			internal int _0024Type_0024724;

			internal Game _0024self__0024725;

			public _0024(int Type, Game self_)
			{
				_0024Type_0024724 = Type;
				_0024self__0024725 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024Type_0024724 != 9 && RuntimeServices.EqualityOperator(_0024self__0024725.InventoryAmounts[_0024Type_0024724], null))
					{
						goto case 1;
					}
					_0024self__0024725.SelectedType = _0024Type_0024724;
					if (_0024Type_0024724 != 9)
					{
						_0024self__0024725.StopCoroutine("InventoryFlashBarrel");
					}
					_0024self__0024725.Audio.PlayOneShot(_0024self__0024725.Click);
					Menu.Get("InventoryX").GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					for (_0024i_0024719 = default(int); _0024i_0024719 < Extensions.get_length((System.Array)_0024self__0024725.InventoryItems); _0024i_0024719++)
					{
						if (_0024self__0024725.InventoryAmounts[_0024i_0024719] != 0)
						{
							_0024self__0024725.InventoryItems[_0024i_0024719].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
							float num = (_0024_0024349_0024720 = Menu.Colors[0].Col.a);
							Color color = (_0024_0024350_0024721 = _0024self__0024725.InventoryAmountsText[_0024i_0024719].material.color);
							float num2 = (_0024_0024350_0024721.a = _0024_0024349_0024720);
							Color color3 = (_0024self__0024725.InventoryAmountsText[_0024i_0024719].material.color = _0024_0024350_0024721);
						}
						else
						{
							_0024self__0024725.InventoryItems[_0024i_0024719].color = new Color(0.4f, 0.4f, 0.4f, 0.2f);
							float num3 = (_0024_0024351_0024722 = 0.4f);
							Color color4 = (_0024_0024352_0024723 = _0024self__0024725.InventoryAmountsText[_0024i_0024719].material.color);
							float num4 = (_0024_0024352_0024723.a = _0024_0024351_0024722);
							Color color6 = (_0024self__0024725.InventoryAmountsText[_0024i_0024719].material.color = _0024_0024352_0024723);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (_0024Type_0024724 != 9)
					{
						if (_0024self__0024725.InventoryAmounts[_0024self__0024725.SelectedType] != 0)
						{
							_0024self__0024725.InventoryItems[_0024Type_0024724].color = new Color(1f, 1f, 1f, 0.5f);
						}
					}
					else
					{
						Menu.Get("InventoryX").GetComponent<GUITexture>().color = new Color(0.57f, 0.09f, 0.09f, 0.5f);
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

		internal int _0024Type_0024726;

		internal Game _0024self__0024727;

		public _0024SwitchType_0024718(int Type, Game self_)
		{
			_0024Type_0024726 = Type;
			_0024self__0024727 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Type_0024726, _0024self__0024727);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FlashBuildText_0024728 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024PreviousAccuracy_0024729;

			internal float _0024PreviousReloadSpeed_0024730;

			internal float _0024PreviousRange_0024731;

			internal Game _0024self__0024732;

			public _0024(Game self_)
			{
				_0024self__0024732 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024PreviousAccuracy_0024729 = _0024self__0024732.BuildAccuracy;
					_0024PreviousReloadSpeed_0024730 = _0024self__0024732.BuildReloadSpeed;
					_0024PreviousRange_0024731 = _0024self__0024732.BuildRange;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (!(_0024self__0024732.BuildAccuracy <= _0024PreviousAccuracy_0024729))
					{
						_0024self__0024732.InventoryAccuracyValueText.material.color = Color.green;
					}
					else if (!(_0024self__0024732.BuildAccuracy >= _0024PreviousAccuracy_0024729))
					{
						_0024self__0024732.InventoryAccuracyValueText.material.color = Color.red;
					}
					if (!(_0024self__0024732.BuildReloadSpeed <= _0024PreviousReloadSpeed_0024730))
					{
						_0024self__0024732.InventoryReloadSpeedValueText.material.color = Color.green;
					}
					else if (!(_0024self__0024732.BuildReloadSpeed >= _0024PreviousReloadSpeed_0024730))
					{
						_0024self__0024732.InventoryReloadSpeedValueText.material.color = Color.red;
					}
					if (!(_0024self__0024732.BuildRange <= _0024PreviousRange_0024731))
					{
						_0024self__0024732.InventoryRangeValueText.material.color = Color.green;
					}
					else if (!(_0024self__0024732.BuildRange >= _0024PreviousRange_0024731))
					{
						_0024self__0024732.InventoryRangeValueText.material.color = Color.red;
					}
					goto case 3;
				case 3:
					if (_0024PreviousAccuracy_0024729 != _0024self__0024732.BuildAccuracy || _0024PreviousReloadSpeed_0024730 != _0024self__0024732.BuildReloadSpeed || _0024PreviousRange_0024731 != _0024self__0024732.BuildRange)
					{
						if (!(_0024PreviousAccuracy_0024729 >= _0024self__0024732.BuildAccuracy - 0.005f))
						{
							_0024PreviousAccuracy_0024729 += 0.01f;
						}
						else if (!(_0024PreviousAccuracy_0024729 <= _0024self__0024732.BuildAccuracy + 0.005f))
						{
							_0024PreviousAccuracy_0024729 -= 0.01f;
						}
						else
						{
							_0024PreviousAccuracy_0024729 = _0024self__0024732.BuildAccuracy;
							_0024self__0024732.InventoryAccuracyValueText.material.color = _0024self__0024732.BuildModeAccuracyValueText.material.color;
						}
						if (!(_0024PreviousReloadSpeed_0024730 >= _0024self__0024732.BuildReloadSpeed - 0.005f))
						{
							_0024PreviousReloadSpeed_0024730 += 0.01f;
						}
						else if (!(_0024PreviousReloadSpeed_0024730 <= _0024self__0024732.BuildReloadSpeed + 0.005f))
						{
							_0024PreviousReloadSpeed_0024730 -= 0.01f;
						}
						else
						{
							_0024PreviousReloadSpeed_0024730 = _0024self__0024732.BuildReloadSpeed;
							_0024self__0024732.InventoryReloadSpeedValueText.material.color = _0024self__0024732.BuildModeReloadSpeedValueText.material.color;
						}
						if (!(_0024PreviousRange_0024731 >= _0024self__0024732.BuildRange - 0.005f))
						{
							_0024PreviousRange_0024731 += 0.01f;
						}
						else if (!(_0024PreviousRange_0024731 <= _0024self__0024732.BuildRange + 0.005f))
						{
							_0024PreviousRange_0024731 -= 0.01f;
						}
						else
						{
							_0024PreviousRange_0024731 = _0024self__0024732.BuildRange;
							_0024self__0024732.InventoryRangeValueText.material.color = _0024self__0024732.BuildModeRangeValueText.material.color;
						}
						if (!(_0024PreviousAccuracy_0024729 >= 0f))
						{
							_0024self__0024732.InventoryAccuracyValueText.text = string.Empty;
						}
						else
						{
							_0024self__0024732.InventoryAccuracyValueText.text = "+";
						}
						if (!(_0024PreviousReloadSpeed_0024730 >= 0f))
						{
							_0024self__0024732.InventoryReloadSpeedValueText.text = string.Empty;
						}
						else
						{
							_0024self__0024732.InventoryReloadSpeedValueText.text = "+";
						}
						if (!(_0024PreviousRange_0024731 >= 0f))
						{
							_0024self__0024732.InventoryRangeValueText.text = string.Empty;
						}
						else
						{
							_0024self__0024732.InventoryRangeValueText.text = "+";
						}
						_0024self__0024732.InventoryAccuracyValueText.text = _0024self__0024732.InventoryAccuracyValueText.text + ((_0024PreviousAccuracy_0024729 * 100f).ToString("F0") + "%");
						_0024self__0024732.InventoryReloadSpeedValueText.text = _0024self__0024732.InventoryReloadSpeedValueText.text + ((_0024PreviousReloadSpeed_0024730 * 100f).ToString("F0") + "%");
						_0024self__0024732.InventoryRangeValueText.text = _0024self__0024732.InventoryRangeValueText.text + ((_0024PreviousRange_0024731 * 100f).ToString("F0") + "%");
						result = (Yield(3, new WaitForSeconds(0.025f)) ? 1 : 0);
					}
					else
					{
						result = (Yield(4, new WaitForSeconds(0.025f)) ? 1 : 0);
					}
					break;
				case 4:
					_0024self__0024732.InventoryAccuracyValueText.material.color = _0024self__0024732.BuildModeAccuracyValueText.material.color;
					_0024self__0024732.InventoryReloadSpeedValueText.material.color = _0024self__0024732.BuildModeReloadSpeedValueText.material.color;
					_0024self__0024732.InventoryRangeValueText.material.color = _0024self__0024732.BuildModeRangeValueText.material.color;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024733;

		public _0024FlashBuildText_0024728(Game self_)
		{
			_0024self__0024733 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024733);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SettingsSlider_0024734 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CustomTouch _0024Touch_0024735;

			internal int _0024_0024205_0024736;

			internal CustomTouch[] _0024_0024206_0024737;

			internal int _0024_0024207_0024738;

			internal float _0024_0024355_0024739;

			internal Rect _0024_0024356_0024740;

			internal Game _0024self__0024741;

			public _0024(Game self_)
			{
				_0024self__0024741 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_01b9
				int result;
				switch (_state)
				{
				default:
					if (!Gyro.UseGyro)
					{
						_0024_0024205_0024736 = 0;
						_0024_0024206_0024737 = Menus.Touches;
						for (_0024_0024207_0024738 = _0024_0024206_0024737.Length; _0024_0024205_0024736 < _0024_0024207_0024738; _0024_0024205_0024736++)
						{
							if ((Menu.Began(_0024_0024206_0024737[_0024_0024205_0024736]) || Menu.Moved(_0024_0024206_0024737[_0024_0024205_0024736])) && !(_0024_0024206_0024737[_0024_0024205_0024736].position.y <= (float)(Screen.height / 2) - 90f * Settings.DPI) && !(_0024_0024206_0024737[_0024_0024205_0024736].position.y >= (float)(Screen.height / 2 - 57)))
							{
								float num = (_0024_0024355_0024739 = Mathf.Clamp(_0024_0024206_0024737[_0024_0024205_0024736].position.x - (float)(Screen.width / 2) - 16.5f * Settings.Scale, -80f * Settings.Scale - 16.5f * Settings.Scale, 80f * Settings.Scale - 16.5f * Settings.Scale));
								Rect rect = (_0024_0024356_0024740 = _0024self__0024741.SettingsSensitivityButton.pixelInset);
								float num3 = (_0024_0024356_0024740.x = _0024_0024355_0024739);
								Rect rect3 = (_0024self__0024741.SettingsSensitivityButton.pixelInset = _0024_0024356_0024740);
							}
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024742;

		public _0024SettingsSlider_0024734(Game self_)
		{
			_0024self__0024742 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024742);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowSets_0024743 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_0024744;

			internal Color _0024BarColor_0024745;

			internal GameObject _0024SetsLockBadge_0024746;

			internal GUIText _0024SetsLockBadgeText_0024747;

			internal float _0024_0024357_0024748;

			internal Rect _0024_0024358_0024749;

			internal float _0024_0024359_0024750;

			internal Rect _0024_0024360_0024751;

			internal float _0024_0024361_0024752;

			internal Rect _0024_0024362_0024753;

			internal float _0024_0024363_0024754;

			internal Rect _0024_0024364_0024755;

			internal Game _0024self__0024756;

			public _0024(Game self_)
			{
				_0024self__0024756 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					Menu.HidRec("Sets");
					Menu.Sho("Sets");
					Menu.Get("SetsArrowLeft").GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menu.Get("SetsArrowRight").GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					for (_0024i_0024744 = default(int); _0024i_0024744 < 9; _0024i_0024744++)
					{
						Menu.Get("SetsItem" + _0024i_0024744.ToString()).GetComponent<GUITexture>().texture = _0024self__0024756.BlockSets[_0024self__0024756.SelectedSet].InventoryGUIs[_0024i_0024744];
					}
					_0024BarColor_0024745 = default(Color);
					if (_0024self__0024756.SelectedSet == 0)
					{
						Menu.Sho("SetsWood");
						_0024BarColor_0024745 = new Color(0.47f, 0.36f, 0.25f, 0.5f);
						Menu.Get("SetsArrowLeft").GetComponent<GUITexture>().color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
					}
					else if (_0024self__0024756.SelectedSet == 1)
					{
						Menu.Sho("SetsPlastic");
						_0024BarColor_0024745 = new Color(0.45f, 0.5f, 0.45f, 0.5f);
					}
					else if (_0024self__0024756.SelectedSet == 2)
					{
						Menu.Sho("SetsSteel");
						_0024BarColor_0024745 = new Color(0.43f, 0.4f, 0.36f, 0.5f);
					}
					else if (_0024self__0024756.SelectedSet == 3)
					{
						Menu.Sho("SetsGlass");
						_0024BarColor_0024745 = new Color(0.49f, 0.56f, 0.57f, 0.5f);
					}
					else if (_0024self__0024756.SelectedSet == 4)
					{
						Menu.Sho("SetsAluminum");
						_0024BarColor_0024745 = new Color(0.48f, 0.48f, 0.48f, 0.5f);
					}
					else if (_0024self__0024756.SelectedSet == 5)
					{
						Menu.Sho("SetsGold");
						_0024BarColor_0024745 = new Color(0.66f, 0.54f, 0.09f, 0.5f);
						Menu.Get("SetsArrowRight").GetComponent<GUITexture>().color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
					}
					float num = (_0024_0024357_0024748 = 270f * Settings.Scale * _0024self__0024756.VisibleAccuracies[_0024self__0024756.SelectedSet]);
					Rect rect = (_0024_0024358_0024749 = Menu.Get("SetsFill0").GetComponent<GUITexture>().pixelInset);
					float num3 = (_0024_0024358_0024749.width = _0024_0024357_0024748);
					Rect rect3 = (Menu.Get("SetsFill0").GetComponent<GUITexture>().pixelInset = _0024_0024358_0024749);
					float num4 = (_0024_0024359_0024750 = 270f * Settings.Scale * _0024self__0024756.VisibleReloadSpeeds[_0024self__0024756.SelectedSet]);
					Rect rect4 = (_0024_0024360_0024751 = Menu.Get("SetsFill1").GetComponent<GUITexture>().pixelInset);
					float num6 = (_0024_0024360_0024751.width = _0024_0024359_0024750);
					Rect rect6 = (Menu.Get("SetsFill1").GetComponent<GUITexture>().pixelInset = _0024_0024360_0024751);
					float num7 = (_0024_0024361_0024752 = 270f * Settings.Scale * _0024self__0024756.VisibleAccuracies[_0024self__0024756.SelectedSet]);
					Rect rect7 = (_0024_0024362_0024753 = Menu.Get("SetsFill2").GetComponent<GUITexture>().pixelInset);
					float num9 = (_0024_0024362_0024753.width = _0024_0024361_0024752);
					Rect rect9 = (Menu.Get("SetsFill2").GetComponent<GUITexture>().pixelInset = _0024_0024362_0024753);
					float num10 = (_0024_0024363_0024754 = 270f * Settings.Scale * _0024self__0024756.VisibleDamages[_0024self__0024756.SelectedSet]);
					Rect rect10 = (_0024_0024364_0024755 = Menu.Get("SetsFill3").GetComponent<GUITexture>().pixelInset);
					float num12 = (_0024_0024364_0024755.width = _0024_0024363_0024754);
					Rect rect12 = (Menu.Get("SetsFill3").GetComponent<GUITexture>().pixelInset = _0024_0024364_0024755);
					_0024SetsLockBadge_0024746 = Menu.Get("SetsLockBadge").gameObject;
					_0024SetsLockBadgeText_0024747 = Menu.Get("SetsLockBadgeText").GetComponent<GUIText>();
					if (_0024self__0024756.SelectedSet == 0 || Menus.Unlocked("Set" + _0024self__0024756.SelectedSet.ToString()))
					{
						_0024SetsLockBadge_0024746.SetActive(false);
						Menu.Get("SetsSelect").GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					}
					else
					{
						_0024SetsLockBadgeText_0024747.text = (-Menus.UnlockValue("Set" + _0024self__0024756.SelectedSet.ToString())).ToString();
						_0024SetsLockBadge_0024746.SetActive(true);
						Menu.Get("SetsSelect").GetComponent<GUITexture>().color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
					}
					Menu.Get("SetsFill0").GetComponent<GUITexture>().color = _0024BarColor_0024745;
					Menu.Get("SetsFill1").GetComponent<GUITexture>().color = _0024BarColor_0024745;
					Menu.Get("SetsFill2").GetComponent<GUITexture>().color = _0024BarColor_0024745;
					Menu.Get("SetsFill3").GetComponent<GUITexture>().color = _0024BarColor_0024745;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				}
				case 2:
					if (_0024self__0024756.SelectedSet == 0)
					{
						Menu.Get("SetsArrowLeft").GetComponent<GUITexture>().color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
					}
					else if (_0024self__0024756.SelectedSet == 5)
					{
						Menu.Get("SetsArrowRight").GetComponent<GUITexture>().color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
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

		internal Game _0024self__0024757;

		public _0024ShowSets_0024743(Game self_)
		{
			_0024self__0024757 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024757);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PrizeCounter_0024758 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024Minutes_0024759;

			internal int _0024Seconds_0024760;

			internal string _0024ExtraZero_0024761;

			internal Game _0024self__0024762;

			public _0024(Game self_)
			{
				_0024self__0024762 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_016e
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024762.TimeUntilNextPrize = (float)(Saver.GetDate("NextPrize") - DateTime.Now).TotalSeconds;
					if (!(_0024self__0024762.TimeUntilNextPrize > 0f))
					{
						_0024self__0024762.PrizeCounterText.material.color = Menu.Colors[18].Col;
						_0024self__0024762.PrizeCounterText.text = Loc.L("CLAIM");
					}
					else
					{
						_0024Minutes_0024759 = (int)Mathf.Floor(_0024self__0024762.TimeUntilNextPrize / 60f);
						_0024Seconds_0024760 = (int)(_0024self__0024762.TimeUntilNextPrize % 60f);
						_0024self__0024762.PrizeCounterText.material.color = Menu.Colors[4].Col;
						_0024ExtraZero_0024761 = string.Empty;
						if (_0024Seconds_0024760 < 10)
						{
							_0024ExtraZero_0024761 = "0";
						}
						_0024self__0024762.PrizeCounterText.text = _0024Minutes_0024759.ToString() + ":" + _0024ExtraZero_0024761 + _0024Seconds_0024760.ToString();
					}
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024763;

		public _0024PrizeCounter_0024758(Game self_)
		{
			_0024self__0024763 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024763);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MoveToRange_0024764 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024765;

			internal Game _0024self__0024766;

			public _0024(Game self_)
			{
				_0024self__0024766 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_01d4
				int result;
				switch (_state)
				{
				default:
					Menu.RestartMenus();
					Menu.FadeAudio(_0024self__0024766.MenuMusic, 0f, 0.2f);
					_0024self__0024766.CameraTargetDestination = new Vector3(-1f, 3.5f, 0f);
					_0024self__0024766.CameraTargetRotation = new Vector3(10f, -90f, 0f);
					goto case 2;
				case 2:
					if (Vector3.Distance(_0024self__0024766.transform.position, _0024self__0024766.CameraTargetDestination) > 1f)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__0024766.CameraTargetRotation = new Vector3(50f, -90f, 0f);
					_0024self__0024766.Audio.PlayOneShot(_0024self__0024766.Door);
					_0024Counter_0024765 = default(float);
					goto case 3;
				case 3:
					if (Vector3.Distance(_0024self__0024766.transform.position, _0024self__0024766.CameraTargetDestination) > 0.7f)
					{
						_0024self__0024766.DoorGun.transform.eulerAngles = new Vector3(0f, _0024Counter_0024765, 0f);
						_0024Counter_0024765 += Time.deltaTime * 30f;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__0024766.StartCoroutine(Menu.LoadGame(Menus.NextMode));
					goto case 4;
				case 4:
					_0024self__0024766.DoorGun.transform.eulerAngles = new Vector3(0f, _0024Counter_0024765, 0f);
					_0024Counter_0024765 += Time.deltaTime * 30f;
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024767;

		public _0024MoveToRange_0024764(Game self_)
		{
			_0024self__0024767 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024767);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MoveToShare_0024768 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal Game _0024self__0024769;

			public _0024(Game self_)
			{
				_0024self__0024769 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, Menu.StartCoroutine("Fade", 0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024769.BuildFromSave();
					Menu.StartCoroutine("Fade", 0);
					Menu.Sho("Share");
					if (Application.platform == RuntimePlatform.Android)
					{
						Menu.Get("ShareTake").gameObject.SetActive(false);
					}
					_0024self__0024769.CameraTargetDestination = new Vector3(-4.75f, 3.87f, -20f);
					_0024self__0024769.transform.position = _0024self__0024769.CameraTargetDestination;
					_0024self__0024769.CameraSwayFactor = 0.2f;
					_0024self__0024769.CameraMoveFactor = 2.5f;
					_0024self__0024769.DirectionalLight.transform.eulerAngles = new Vector3(40f, 13f, 263f);
					_0024self__0024769.GunHolder.transform.position = new Vector3(-4.75f, 3.87f, -16f);
					_0024self__0024769.GunHolder.transform.localScale = Vector3.one * 22f;
					_0024self__0024769.GunHolder.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					_0024self__0024769.StartCoroutine("ShareRoom");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024770;

		public _0024MoveToShare_0024768(Game self_)
		{
			_0024self__0024770 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__0024770);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShareRoom_0024771 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector2[] _0024TwoFingers_0024772;

			internal bool _0024Zoomed_0024773;

			internal CustomTouch _0024Touch_0024774;

			internal Vector3 _0024CurrentRotation_0024775;

			internal int _0024_0024209_0024776;

			internal CustomTouch[] _0024_0024210_0024777;

			internal int _0024_0024211_0024778;

			internal Game _0024self__0024779;

			public _0024(Game self_)
			{
				_0024self__0024779 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0560
				int result;
				switch (_state)
				{
				default:
					_0024TwoFingers_0024772 = new Vector2[2];
					_0024Zoomed_0024773 = default(bool);
					_0024_0024209_0024776 = 0;
					_0024_0024210_0024777 = Menus.Touches;
					for (_0024_0024211_0024778 = _0024_0024210_0024777.Length; _0024_0024209_0024776 < _0024_0024211_0024778; _0024_0024209_0024776++)
					{
						if (Input.touchCount > 1)
						{
							if (_0024TwoFingers_0024772[0] == Vector2.zero)
							{
								_0024TwoFingers_0024772[0] = _0024_0024210_0024777[_0024_0024209_0024776].position;
							}
							else
							{
								_0024TwoFingers_0024772[1] = _0024_0024210_0024777[_0024_0024209_0024776].position;
							}
						}
						if (Menu.Began(_0024_0024210_0024777[_0024_0024209_0024776]))
						{
							_0024self__0024779.SlidingFinger = _0024_0024210_0024777[_0024_0024209_0024776].fingerId;
							_0024self__0024779.TouchStart = _0024_0024210_0024777[_0024_0024209_0024776].position;
							_0024self__0024779.TouchLastFrame = _0024_0024210_0024777[_0024_0024209_0024776].position;
							if (Input.touchCount > 1)
							{
								_0024self__0024779.TwoFingersLastFrame[0] = _0024TwoFingers_0024772[0];
								_0024self__0024779.TwoFingersLastFrame[1] = _0024TwoFingers_0024772[1];
							}
						}
						else if (Menu.Moved(_0024_0024210_0024777[_0024_0024209_0024776]))
						{
							if (_0024_0024210_0024777[_0024_0024209_0024776].fingerId == _0024self__0024779.SlidingFinger)
							{
								_0024self__0024779.SlidThisFrame = true;
								_0024self__0024779.CamInertia.x = _0024self__0024779.CamInertia.x - (_0024_0024210_0024777[_0024_0024209_0024776].position.x - _0024self__0024779.TouchLastFrame.x) / Settings.DPI * 0.15f;
								_0024self__0024779.CamInertia.y = _0024self__0024779.CamInertia.y - (_0024_0024210_0024777[_0024_0024209_0024776].position.y - _0024self__0024779.TouchLastFrame.y) / Settings.DPI * 0.15f;
								_0024self__0024779.TouchLastFrame = _0024_0024210_0024777[_0024_0024209_0024776].position;
							}
						}
						else if (Menu.Stationary(_0024_0024210_0024777[_0024_0024209_0024776]) && _0024_0024210_0024777[_0024_0024209_0024776].fingerId == _0024self__0024779.SlidingFinger)
						{
							_0024self__0024779.CamInertia = Vector2.Lerp(_0024self__0024779.CamInertia, Vector2.zero, Time.deltaTime * 30f);
						}
					}
					if (Input.touchCount == 0)
					{
						_0024self__0024779.SlidThisFrame = false;
					}
					if (Input.touchCount > 1)
					{
						_0024self__0024779.CameraTargetDestination.z = _0024self__0024779.CameraTargetDestination.z + (Vector2.Distance(_0024TwoFingers_0024772[0], _0024TwoFingers_0024772[1]) - Vector2.Distance(_0024self__0024779.TwoFingersLastFrame[0], _0024self__0024779.TwoFingersLastFrame[1])) / Settings.DPI * 2f;
						_0024self__0024779.CameraTargetDestination.z = Mathf.Clamp(_0024self__0024779.CameraTargetDestination.z, -22f, -17f);
						_0024self__0024779.TwoFingersLastFrame[0] = _0024TwoFingers_0024772[0];
						_0024self__0024779.TwoFingersLastFrame[1] = _0024TwoFingers_0024772[1];
						_0024self__0024779.CamInertia = Vector2.zero;
					}
					_0024self__0024779.CamInertia = Vector2.Lerp(_0024self__0024779.CamInertia, Vector2.zero, Time.deltaTime * 8f);
					_0024self__0024779.GunHolder.transform.Rotate(new Vector3((0f - _0024self__0024779.CamInertia.y) * 150f, _0024self__0024779.CamInertia.x * 150f, 0f), Space.World);
					_0024CurrentRotation_0024775 = _0024self__0024779.transform.eulerAngles;
					_0024self__0024779.transform.LookAt(_0024self__0024779.GunHolder.transform);
					_0024self__0024779.CameraTargetRotation = _0024self__0024779.transform.eulerAngles;
					_0024self__0024779.transform.eulerAngles = _0024CurrentRotation_0024775;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024780;

		public _0024ShareRoom_0024771(Game self_)
		{
			_0024self__0024780 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024780);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MoveToChance_0024781 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal int _0024Type_0024782;

			internal Game _0024self__0024783;

			public _0024(int Type, Game self_)
			{
				_0024Type_0024782 = Type;
				_0024self__0024783 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024783.IsChance = true;
					_0024self__0024783.StopCoroutine("ChanceCoinPayout");
					_0024self__0024783.TickerText.text = Saver.GetInt("Currency").ToString();
					result = (Yield(2, Menu.StartCoroutine("Fade", 0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024783.ChanceType = _0024Type_0024782;
					_0024self__0024783.ChanceCube.GetComponent<Renderer>().sharedMaterial.mainTexture = _0024self__0024783.ChanceTextures[_0024Type_0024782];
					_0024self__0024783.StopCoroutine("ChanceZoomIn");
					_0024self__0024783.GetComponent<Camera>().fieldOfView = 60f;
					_0024self__0024783.BuildFromSave();
					_0024self__0024783.IsShooting = true;
					_0024self__0024783.StartCoroutine(((Guns)_0024self__0024783.GetComponent(typeof(Guns))).Reload());
					Menu.Sho("Guns");
					Menu.Sho("Ammo");
					Menu.Sho("Crosshair");
					Menu.Sho("Reload");
					Guns.AllowFireReload = true;
					_0024self__0024783.CameraSwayFactor = 0.2f;
					_0024self__0024783.StartCoroutine(((Gyro)_0024self__0024783.GetComponent(typeof(Gyro))).ReorientGyro());
					Menu.StartCoroutine("Fade", 0);
					Menu.Sho("Ticker");
					_0024self__0024783.ChanceCube.SetActive(true);
					_0024self__0024783.transform.position = new Vector3(-4.75f, 3.87f, -20f);
					_0024self__0024783.StartCoroutine("ChanceSpin", _0024Type_0024782);
					_0024self__0024783.ChanceCubeParticles.SetActive(true);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Type_0024784;

		internal Game _0024self__0024785;

		public _0024MoveToChance_0024781(int Type, Game self_)
		{
			_0024Type_0024784 = Type;
			_0024self__0024785 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024Type_0024784, _0024self__0024785);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChanceSpin_0024786 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Counter_0024787;

			internal float _0024SpeedModifier_0024788;

			internal int _0024SpinDirection_0024789;

			internal float _0024SpinSpeed_0024790;

			internal int _0024Type_0024791;

			internal Game _0024self__0024792;

			public _0024(int Type, Game self_)
			{
				_0024Type_0024791 = Type;
				_0024self__0024792 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0201
				int result;
				switch (_state)
				{
				default:
					_0024self__0024792.ChanceSpinAudio.Play();
					_0024self__0024792.ChanceCube.transform.eulerAngles = new Vector3(0f, UnityEngine.Random.Range(1, 359), 0f);
					_0024Counter_0024787 = default(float);
					_0024SpeedModifier_0024788 = default(float);
					if (_0024Type_0024791 == 0)
					{
						if (!Saver.GetBoolean("SpunChance0"))
						{
							_0024SpeedModifier_0024788 = -400f;
							Saver.Set("SpunChance0", true);
							Saver.Save();
						}
						else
						{
							_0024SpeedModifier_0024788 = 0f;
						}
					}
					else if (_0024Type_0024791 == 1)
					{
						if (!Saver.GetBoolean("SpunChance1"))
						{
							_0024SpeedModifier_0024788 = -300f;
							Saver.Set("SpunChance1", true);
							Saver.Save();
						}
						else
						{
							_0024SpeedModifier_0024788 = -50f;
						}
					}
					else if (_0024Type_0024791 == 2)
					{
						if (!Saver.GetBoolean("SpunChance2"))
						{
							_0024SpeedModifier_0024788 = 0f;
							Saver.Set("SpunChance2", true);
							Saver.Save();
						}
						else
						{
							_0024SpeedModifier_0024788 = 400f;
						}
					}
					_0024SpinDirection_0024789 = (int)Mathf.Sign(UnityEngine.Random.Range(-1f, 1f));
					_0024SpinSpeed_0024790 = (float)UnityEngine.Random.Range(800, 1000) + _0024SpeedModifier_0024788;
					goto case 2;
				case 2:
					_0024Counter_0024787 += Time.deltaTime;
					if (!(_0024Counter_0024787 <= 0.2f))
					{
						_0024Counter_0024787 = 0f;
						_0024SpinSpeed_0024790 = (float)UnityEngine.Random.Range(800, 1000) + _0024SpeedModifier_0024788;
					}
					_0024self__0024792.ChanceCube.transform.Rotate(0f, _0024SpinSpeed_0024790 * (float)_0024SpinDirection_0024789 * Time.deltaTime, 0f);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Type_0024793;

		internal Game _0024self__0024794;

		public _0024ChanceSpin_0024786(int Type, Game self_)
		{
			_0024Type_0024793 = Type;
			_0024self__0024794 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Type_0024793, _0024self__0024794);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChanceHitCube_0024795 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024CurrentRot_0024796;

			internal float _0024TargetRot_0024797;

			internal float _0024Counter_0024798;

			internal Game _0024self__0024799;

			public _0024(Game self_)
			{
				_0024self__0024799 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024799.StopCoroutine("ChanceSpin");
					Menu.Sho("Ticker");
					_0024self__0024799.ChanceSpinAudio.Stop();
					_0024self__0024799.Audio.PlayOneShot(_0024self__0024799.Ding);
					_0024self__0024799.Audio.PlayOneShot(_0024self__0024799.Gong);
					Menu.Hid("Guns");
					Guns.AllowFireReload = false;
					_0024self__0024799.StartCoroutine("ChanceZoomIn");
					_0024self__0024799.ChanceCubeParticles.SetActive(false);
					_0024CurrentRot_0024796 = _0024self__0024799.ChanceCube.transform.eulerAngles.y;
					_0024TargetRot_0024797 = default(float);
					if (_0024CurrentRot_0024796 > 315f || !(_0024CurrentRot_0024796 >= 45f))
					{
						_0024TargetRot_0024797 = 0f;
						if (_0024self__0024799.ChanceType == 0)
						{
							_0024self__0024799.StartCoroutine("ChanceCoinPayout", 2);
						}
						else if (_0024self__0024799.ChanceType != 1 && _0024self__0024799.ChanceType != 2)
						{
						}
					}
					else if (!(_0024CurrentRot_0024796 >= 135f))
					{
						_0024TargetRot_0024797 = 90f;
						if (_0024self__0024799.ChanceType == 0)
						{
							_0024self__0024799.StartCoroutine("ChanceCoinPayout", 3);
						}
						else if (_0024self__0024799.ChanceType == 1)
						{
							_0024self__0024799.StartCoroutine("ChanceCoinPayout", 10);
						}
						else if (_0024self__0024799.ChanceType == 2)
						{
							_0024self__0024799.ChanceAddSeeds(2);
						}
					}
					else if (!(_0024CurrentRot_0024796 >= 225f))
					{
						_0024TargetRot_0024797 = 180f;
						if (_0024self__0024799.ChanceType != 0 && _0024self__0024799.ChanceType != 1 && _0024self__0024799.ChanceType == 2)
						{
							_0024self__0024799.StartCoroutine("ChanceCoinPayout", 10);
						}
					}
					else
					{
						_0024TargetRot_0024797 = 270f;
						if (_0024self__0024799.ChanceType == 0)
						{
							_0024self__0024799.StartCoroutine("ChanceCoinPayout", 4);
						}
						else if (_0024self__0024799.ChanceType == 1)
						{
							_0024self__0024799.ChanceAddSeeds(1);
						}
						else if (_0024self__0024799.ChanceType == 2)
						{
							_0024self__0024799.StartCoroutine("ChanceCoinPayout", 50);
						}
					}
					_0024Counter_0024798 = default(float);
					goto case 2;
				case 2:
					if (_0024Counter_0024798 < 2f)
					{
						_0024CurrentRot_0024796 = Mathf.LerpAngle(_0024CurrentRot_0024796, _0024TargetRot_0024797, 5f * Time.deltaTime);
						_0024self__0024799.ChanceCube.transform.eulerAngles = new Vector3(0f, _0024CurrentRot_0024796, 0f);
						_0024Counter_0024798 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (Yield(3, Menu.StartCoroutine("Fade", 0.25f)) ? 1 : 0);
					}
					break;
				case 3:
					Menu.Sho("Chance");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024800;

		public _0024ChanceHitCube_0024795(Game self_)
		{
			_0024self__0024800 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__0024800);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChanceZoomIn_0024801 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Game _0024self__0024802;

			public _0024(Game self_)
			{
				_0024self__0024802 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_010f
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.3f)) ? 1 : 0);
					break;
				case 2:
					Guns.Unequip();
					goto case 3;
				case 3:
					_0024self__0024802.transform.rotation = Quaternion.Lerp(_0024self__0024802.transform.rotation, Quaternion.LookRotation(_0024self__0024802.ChanceCube.transform.position - _0024self__0024802.transform.position) * Quaternion.Euler(new Vector3(_0024self__0024802.CameraSwayUsable.x, _0024self__0024802.CameraSwayUsable.y, 0f)), Time.deltaTime * 1f);
					_0024self__0024802.GetComponent<Camera>().fieldOfView = Mathf.Lerp(_0024self__0024802.GetComponent<Camera>().fieldOfView, 24f, Time.deltaTime * 2.5f);
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024803;

		public _0024ChanceZoomIn_0024801(Game self_)
		{
			_0024self__0024803 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024803);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChanceCoinPayout_0024804 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024PreviousCoins_0024805;

			internal int _0024i_0024806;

			internal int _0024Amount_0024807;

			internal Game _0024self__0024808;

			public _0024(int Amount, Game self_)
			{
				_0024Amount_0024807 = Amount;
				_0024self__0024808 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024PreviousCoins_0024805 = Saver.GetInt("Currency");
					_0024self__0024808.AddCurrency(_0024Amount_0024807);
					_0024self__0024808.CoinAudio.volume = 0.6f;
					_0024self__0024808.TickerText.text = _0024PreviousCoins_0024805.ToString();
					_0024i_0024806 = default(int);
					if (_0024Amount_0024807 > 0)
					{
						goto IL_00e4;
					}
					goto IL_014a;
				case 2:
					_0024self__0024808.CoinAudio.Play();
					_0024self__0024808.TickerText.text = (_0024PreviousCoins_0024805 + _0024i_0024806 + 1).ToString();
					_0024i_0024806++;
					goto IL_00e4;
				case 3:
					_0024self__0024808.TickerText.text = (_0024PreviousCoins_0024805 + _0024i_0024806 - 1).ToString();
					_0024i_0024806--;
					goto IL_014a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00e4:
					if (_0024i_0024806 < _0024Amount_0024807)
					{
						result = (Yield(2, new WaitForSeconds(0.3f)) ? 1 : 0);
						break;
					}
					goto IL_015b;
					IL_014a:
					if (_0024i_0024806 > _0024Amount_0024807)
					{
						result = (Yield(3, new WaitForSeconds(0.3f)) ? 1 : 0);
						break;
					}
					goto IL_015b;
					IL_015b:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Amount_0024809;

		internal Game _0024self__0024810;

		public _0024ChanceCoinPayout_0024804(int Amount, Game self_)
		{
			_0024Amount_0024809 = Amount;
			_0024self__0024810 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024Amount_0024809, _0024self__0024810);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MoveToFarm_0024811 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal Game _0024self__0024812;

			public _0024(Game self_)
			{
				_0024self__0024812 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Menu.Hid("Ticker");
					result = (Yield(2, Menu.StartCoroutine("Fade", 0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024812.BuildFromSave();
					_0024self__0024812.IsShooting = true;
					_0024self__0024812.StartCoroutine(((Guns)_0024self__0024812.GetComponent(typeof(Guns))).Reload());
					Menu.Sho("Guns");
					Menu.Sho("Ammo");
					Menu.Sho("Crosshair");
					Menu.Sho("Reload");
					Guns.AllowFireReload = true;
					if (Saver.GetInt("Seeds") == 0)
					{
						_0024self__0024812.StartCoroutine(_0024self__0024812.FarmEquip(1));
					}
					else
					{
						_0024self__0024812.StartCoroutine(_0024self__0024812.FarmEquip(0));
					}
					_0024self__0024812.StartCoroutine("FarmGrowPlants");
					Menu.Sho("Farm");
					_0024self__0024812.FarmGroundParent.SetActive(true);
					_0024self__0024812.StartCoroutine("FarmHovering");
					_0024self__0024812.StartCoroutine(((Gyro)_0024self__0024812.GetComponent(typeof(Gyro))).ReorientGyro());
					Menu.StartCoroutine("Fade", 0);
					_0024self__0024812.GetComponent<Camera>().fieldOfView = 60f;
					_0024self__0024812.transform.position = new Vector3(29f, 3f, -24.5f);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024813;

		public _0024MoveToFarm_0024811(Game self_)
		{
			_0024self__0024813 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__0024813);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FarmEquip_0024814 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_0024815;

			internal int _0024Mode_0024816;

			internal Game _0024self__0024817;

			public _0024(int Mode, Game self_)
			{
				_0024Mode_0024816 = Mode;
				_0024self__0024817 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024817.StopCoroutine("FarmTouch");
					for (_0024i_0024815 = default(int); _0024i_0024815 < Extensions.get_length((System.Array)_0024self__0024817.FarmCubes); _0024i_0024815++)
					{
						_0024self__0024817.FarmCubes[_0024i_0024815].GetComponent<Renderer>().enabled = false;
					}
					_0024self__0024817.LastFarmCubeHit = null;
					_0024self__0024817.FarmSeedAmount.text = Saver.GetInt("Seeds").ToString();
					if (_0024Mode_0024816 == 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024Mode_0024816 == 1)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_025d;
				case 2:
					_0024self__0024817.FarmSeed.color = new Color(1f, 1f, 1f, 0.5f);
					_0024self__0024817.FarmGun.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					Menu.Hid("Guns");
					Guns.AllowFireReload = false;
					_0024self__0024817.CameraGuns.enabled = false;
					if (Saver.GetInt("Seeds") != 0)
					{
						_0024self__0024817.FarmCrosshairSeed.gameObject.SetActive(true);
					}
					_0024self__0024817.StartCoroutine("FarmTouch");
					goto IL_025d;
				case 3:
					_0024self__0024817.FarmGun.color = new Color(1f, 1f, 1f, 0.5f);
					if (Saver.GetInt("Seeds") == 0)
					{
						_0024self__0024817.FarmSeed.color = new Color(0.4f, 0.4f, 0.4f, 0.2f);
					}
					else
					{
						_0024self__0024817.FarmSeed.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					}
					Menu.Sho("Guns");
					Guns.AllowFireReload = true;
					_0024self__0024817.CameraGuns.enabled = true;
					_0024self__0024817.FarmCrosshairSeed.gameObject.SetActive(false);
					goto IL_025d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_025d:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024Mode_0024818;

		internal Game _0024self__0024819;

		public _0024FarmEquip_0024814(int Mode, Game self_)
		{
			_0024Mode_0024818 = Mode;
			_0024self__0024819 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Mode_0024818, _0024self__0024819);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FarmHovering_0024820 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Ray _0024ShootRay_0024821;

			internal RaycastHit _0024RayHit_0024822;

			internal GameObject _0024FarmCubeHit_0024823;

			internal bool _0024PlantHit_0024824;

			internal Vector2 _0024LocToCheck_0024825;

			internal float _0024TimeUntilFlower_0024826;

			internal Game _0024self__0024827;

			public _0024(Game self_)
			{
				_0024self__0024827 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_0345
				int result;
				switch (_state)
				{
				default:
					_0024ShootRay_0024821 = _0024self__0024827.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
					_0024RayHit_0024822 = default(RaycastHit);
					_0024FarmCubeHit_0024823 = null;
					_0024PlantHit_0024824 = default(bool);
					if (Physics.Raycast(_0024ShootRay_0024821, out _0024RayHit_0024822, 300f))
					{
						if (!_0024self__0024827.CameraGuns.enabled && _0024RayHit_0024822.collider.gameObject.layer == 15 && Saver.GetInt("Seeds") != 0)
						{
							_0024FarmCubeHit_0024823 = _0024RayHit_0024822.collider.gameObject;
						}
						if (_0024RayHit_0024822.collider.gameObject.layer == 17)
						{
							_0024LocToCheck_0024825 = new Vector2(Mathf.Round(_0024RayHit_0024822.collider.transform.localPosition.x), Mathf.Round(_0024RayHit_0024822.collider.transform.localPosition.z));
							if (_0024self__0024827.FarmDictionary.ContainsKey(_0024LocToCheck_0024825))
							{
								_0024PlantHit_0024824 = true;
								_0024self__0024827.PlantHoverText.GetComponent<Renderer>().enabled = true;
								_0024self__0024827.PlantHoverText.transform.position = new Vector3(_0024RayHit_0024822.collider.transform.position.x, _0024self__0024827.PlantHoverText.transform.position.y, _0024RayHit_0024822.collider.transform.position.z);
								_0024TimeUntilFlower_0024826 = Mathf.Round((float)(600.0 - DateTime.Now.Subtract(_0024self__0024827.FarmDictionary[_0024LocToCheck_0024825].Birthday).TotalSeconds));
								_0024TimeUntilFlower_0024826 = Mathf.Clamp(_0024TimeUntilFlower_0024826, 0f, 9999f);
								_0024self__0024827.PlantHoverText.text = _0024TimeUntilFlower_0024826.ToString();
							}
						}
					}
					if ((_0024FarmCubeHit_0024823 == null || _0024FarmCubeHit_0024823 != _0024self__0024827.LastFarmCubeHit) && _0024self__0024827.LastFarmCubeHit != null)
					{
						_0024self__0024827.LastFarmCubeHit.GetComponent<Renderer>().enabled = false;
					}
					if (_0024FarmCubeHit_0024823 != null)
					{
						_0024FarmCubeHit_0024823.GetComponent<Renderer>().enabled = true;
					}
					_0024self__0024827.LastFarmCubeHit = _0024FarmCubeHit_0024823;
					if (!_0024PlantHit_0024824)
					{
						_0024self__0024827.PlantHoverText.GetComponent<Renderer>().enabled = false;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024828;

		public _0024FarmHovering_0024820(Game self_)
		{
			_0024self__0024828 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024828);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FarmTouch_0024829 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CustomTouch _0024Touch_0024830;

			internal bool _0024AlreadyInArray_0024831;

			internal Vector2 _0024LocToCheck_0024832;

			internal int _0024_0024213_0024833;

			internal CustomTouch[] _0024_0024214_0024834;

			internal int _0024_0024215_0024835;

			internal Game _0024self__0024836;

			public _0024(Game self_)
			{
				_0024self__0024836 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_01f2
				int result;
				switch (_state)
				{
				default:
					_0024_0024213_0024833 = 0;
					_0024_0024214_0024834 = Menus.Touches;
					for (_0024_0024215_0024835 = _0024_0024214_0024834.Length; _0024_0024213_0024833 < _0024_0024215_0024835; _0024_0024213_0024833++)
					{
						if (!(_0024_0024214_0024834[_0024_0024213_0024833].position.x <= (float)(Screen.width / 2)) && !(_0024_0024214_0024834[_0024_0024213_0024833].position.y >= (float)Screen.height - 150f * Settings.Scale) && Menu.Began(_0024_0024214_0024834[_0024_0024213_0024833]) && Saver.GetInt("Seeds") > 0 && _0024self__0024836.LastFarmCubeHit != null)
						{
							_0024AlreadyInArray_0024831 = default(bool);
							_0024LocToCheck_0024832 = new Vector2(Mathf.Round(_0024self__0024836.LastFarmCubeHit.transform.localPosition.x), Mathf.Round(_0024self__0024836.LastFarmCubeHit.transform.localPosition.z));
							if (!_0024self__0024836.FarmDictionary.ContainsKey(_0024LocToCheck_0024832))
							{
								Saver.Set("Seeds", Saver.GetInt("Seeds") - 1);
								_0024self__0024836.FarmSeedAmount.text = Saver.GetInt("Seeds").ToString();
								_0024self__0024836.FarmPlant(_0024LocToCheck_0024832, DateTime.Now);
								if (Saver.GetInt("Seeds") == 0)
								{
									_0024self__0024836.FarmCrosshairSeed.gameObject.SetActive(false);
								}
							}
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024837;

		public _0024FarmTouch_0024829(Game self_)
		{
			_0024self__0024837 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024837);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FarmDestroyPlant_0024838 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024PreviousCoins_0024839;

			internal int _0024i_0024840;

			internal GameObject _0024HitObject_0024841;

			internal Game _0024self__0024842;

			public _0024(GameObject HitObject, Game self_)
			{
				_0024HitObject_0024841 = HitObject;
				_0024self__0024842 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024842.FarmDictionary.Remove(new Vector2(Mathf.Round(_0024HitObject_0024841.transform.localPosition.x), Mathf.Round(_0024HitObject_0024841.transform.localPosition.z)));
					UnityEngine.Object.Destroy(_0024HitObject_0024841);
					Menu.Sho("Ticker");
					_0024self__0024842.FarmUpdateSaveData();
					_0024self__0024842.Audio.PlayOneShot(_0024self__0024842.Ding);
					_0024PreviousCoins_0024839 = Saver.GetInt("Currency");
					if (Saver.GetBoolean("Doubler"))
					{
						_0024self__0024842.AddCurrency(40);
					}
					else
					{
						_0024self__0024842.AddCurrency(20);
					}
					_0024self__0024842.CoinAudio.volume = 0.6f;
					_0024self__0024842.TickerText.text = _0024PreviousCoins_0024839.ToString();
					_0024i_0024840 = default(int);
					goto IL_0181;
				case 2:
					_0024self__0024842.CoinAudio.Play();
					_0024self__0024842.TickerText.text = (_0024PreviousCoins_0024839 + _0024i_0024840 + 1).ToString();
					_0024i_0024840++;
					goto IL_0181;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0181:
					if (_0024i_0024840 < 20)
					{
						result = (Yield(2, new WaitForSeconds(0.3f)) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024HitObject_0024843;

		internal Game _0024self__0024844;

		public _0024FarmDestroyPlant_0024838(GameObject HitObject, Game self_)
		{
			_0024HitObject_0024843 = HitObject;
			_0024self__0024844 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024HitObject_0024843, _0024self__0024844);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FarmGrowPlants_0024845 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Dictionary<Vector2, Plant>.Enumerator _0024e_0024846;

			internal float _0024Age_0024847;

			internal int _0024_0024385_0024848;

			internal Vector3 _0024_0024386_0024849;

			internal int _0024_0024387_0024850;

			internal Vector3 _0024_0024388_0024851;

			internal int _0024_0024389_0024852;

			internal Vector3 _0024_0024390_0024853;

			internal Game _0024self__0024854;

			public _0024(Game self_)
			{
				_0024self__0024854 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_042e
				int result;
				switch (_state)
				{
				default:
					_0024e_0024846 = _0024self__0024854.FarmDictionary.GetEnumerator();
					while (_0024e_0024846.MoveNext())
					{
						_0024Age_0024847 = (float)DateTime.Now.Subtract(_0024e_0024846.Current.Value.Birthday).TotalSeconds;
						if (!(_0024Age_0024847 <= 600f))
						{
							if (_0024e_0024846.Current.Value.Filter.sharedMesh != _0024self__0024854.PlantPrefabMeshes[3])
							{
								_0024e_0024846.Current.Value.Filter.sharedMesh = _0024self__0024854.PlantPrefabMeshes[3];
								int num = (_0024_0024385_0024848 = 54);
								Vector3 vector = (_0024_0024386_0024849 = ((BoxCollider)_0024e_0024846.Current.Value.Obj.GetComponent(typeof(BoxCollider))).size);
								float num2 = (_0024_0024386_0024849.y = _0024_0024385_0024848);
								Vector3 vector3 = (((BoxCollider)_0024e_0024846.Current.Value.Obj.GetComponent(typeof(BoxCollider))).size = _0024_0024386_0024849);
								_0024e_0024846.Current.Value.Obj.layer = 16;
								_0024e_0024846.Current.Value.Obj.GetComponent<Collider>().enabled = true;
								_0024e_0024846.Current.Value.Obj.tag = "Glass";
							}
						}
						else if (!(_0024Age_0024847 <= 100f))
						{
							if (_0024e_0024846.Current.Value.Filter.sharedMesh != _0024self__0024854.PlantPrefabMeshes[2])
							{
								_0024e_0024846.Current.Value.Filter.sharedMesh = _0024self__0024854.PlantPrefabMeshes[2];
								int num3 = (_0024_0024387_0024850 = 30);
								Vector3 vector4 = (_0024_0024388_0024851 = ((BoxCollider)_0024e_0024846.Current.Value.Obj.GetComponent(typeof(BoxCollider))).size);
								float num4 = (_0024_0024388_0024851.y = _0024_0024387_0024850);
								Vector3 vector6 = (((BoxCollider)_0024e_0024846.Current.Value.Obj.GetComponent(typeof(BoxCollider))).size = _0024_0024388_0024851);
							}
						}
						else if (!(_0024Age_0024847 <= 5f) && _0024e_0024846.Current.Value.Filter.sharedMesh != _0024self__0024854.PlantPrefabMeshes[1])
						{
							_0024e_0024846.Current.Value.Filter.sharedMesh = _0024self__0024854.PlantPrefabMeshes[1];
							int num5 = (_0024_0024389_0024852 = 19);
							Vector3 vector7 = (_0024_0024390_0024853 = ((BoxCollider)_0024e_0024846.Current.Value.Obj.GetComponent(typeof(BoxCollider))).size);
							float num6 = (_0024_0024390_0024853.y = _0024_0024389_0024852);
							Vector3 vector9 = (((BoxCollider)_0024e_0024846.Current.Value.Obj.GetComponent(typeof(BoxCollider))).size = _0024_0024390_0024853);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024855;

		public _0024FarmGrowPlants_0024845(Game self_)
		{
			_0024self__0024855 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024855);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TakeScreen_0024856 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Texture2D _0024tex_0024857;

			internal byte[] _0024bytes_0024858;

			internal Game _0024self__0024859;

			public _0024(Game self_)
			{
				_0024self__0024859 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024859.ShareBack.enabled = false;
					_0024self__0024859.ShareTake.gameObject.SetActive(false);
					_0024self__0024859.ShareLogo.enabled = true;
					File.Delete(Application.persistentDataPath + "/Screen.png");
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (Application.isEditor)
					{
						ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/Screen.png");
					}
					else
					{
						ScreenCapture.CaptureScreenshot("/Screen.png");
					}
					_0024self__0024859.Audio.PlayOneShot(_0024self__0024859.CameraShutter);
					Time.timeScale = 0f;
					goto case 3;
				case 3:
					if (!File.Exists(Application.persistentDataPath + "/Screen.png"))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					Time.timeScale = 1f;
					_0024tex_0024857 = new Texture2D(Screen.width, Screen.height);
					_0024bytes_0024858 = File.ReadAllBytes(Application.persistentDataPath + "/Screen.png");
					_0024tex_0024857.LoadImage(_0024bytes_0024858);
					_0024self__0024859.Screenshot.pixelInset = new Rect(-Screen.width / 2, -Screen.height / 2, Screen.width, Screen.height);
					_0024self__0024859.Screenshot.texture = _0024tex_0024857;
					Menu.Sho("SaveShare");
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					Menu.Hid("Share");
					_0024self__0024859.ShareBack.enabled = true;
					_0024self__0024859.ShareTake.gameObject.SetActive(true);
					_0024self__0024859.ShareLogo.enabled = false;
					Menu.Sho("SaveShareCancel");
					Menu.Sho("SaveShareEmail");
					Menu.Sho("SaveSharePhotos");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Game _0024self__0024860;

		public _0024TakeScreen_0024856(Game self_)
		{
			_0024self__0024860 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024860);
		}
	}

	[NonSerialized]
	public static Menus Menu;

	public Light DirectionalLight;

	private Vector3 DirectionalLightStartingRotation;

	public AudioClip CameraShutter;

	public GUITexture Screenshot;

	public AudioSource MenuMusic;

	public TextMesh VersusName;

	private GameObject TargetSet;

	public GameObject[] TargetSets;

	public GameObject GunHolder;

	public Transform GridParent;

	public GameObject[] Grids;

	private GameObject Gun2;

	private GameObject Gun2Opponent;

	public AudioSource CoinAudio;

	public AudioSource ChanceSpinAudio;

	public Material TargetPresent;

	public Transform DoorGun;

	public GameObject[] Flair;

	public GUITexture CoinHUD;

	public GameObject PopupMenu;

	public GameObject Fragments;

	private GameObject FragmentsYou0;

	private GameObject FragmentsYou1;

	private int CurrentFragmentYou;

	private GameObject FragmentsOpp0;

	private GameObject FragmentsOpp1;

	private int CurrentFragmentOpp;

	private int BarrelsLeft;

	private int SightsLeft;

	private int TriggersLeft;

	private int BlocksLeft;

	private string SelectedName;

	private int SelectedType;

	private int SelectedSaveSlot;

	private int SelectedSet;

	private int SelectedGrid;

	private int SelectedMode;

	private int SlotToDelete;

	public BlockSet[] BlockSets;

	private GUITexture[] InventoryItems;

	private int[] InventoryAmounts;

	private GUIText[] InventoryAmountsText;

	private int[] InventoryBaseAmounts;

	private Vector2 TouchStart;

	private Vector2 TouchLastFrame;

	private Vector2 CamOffset;

	private Vector2 CamInertia;

	private int SlidingFinger;

	private bool SlidThisFrame;

	private int ZoomingFinger;

	private bool ZoomedThisFrame;

	private float Zoom;

	private Vector2 ZoomTouchLastFrame;

	private Vector2[] TwoFingersLastFrame;

	private Dictionary<Vector3, int> BlockDictionary;

	[NonSerialized]
	public static Dictionary<Vector3, GameObject> TargetDictionary;

	private Dictionary<Vector2, Plant> FarmDictionary;

	[NonSerialized]
	public static GameObject[] TargetArray;

	private int TargetsRemaining;

	private bool IsBuildMode;

	private bool IsShareMode;

	private bool IsBuilding;

	private bool IsShooting;

	public AudioClip FireSound;

	public AudioClip ReloadSound;

	public GameObject MuzzleFlash;

	public GUIText ScoreFontYou;

	public GUIText ScoreFontOpp;

	public GUITexture Ticker;

	public GUIText TickerText;

	public GUIText TimerFont;

	public GUIText NameFontYou;

	private Vector3 CameraTargetDestination;

	private Vector3 CameraTargetRotation;

	private int[] GridHeights;

	private int[] GridAmmos;

	private int[] ModeRequirements;

	private int[] ModePresents;

	private float[] Accuracies;

	private float[] VisibleAccuracies;

	private float[] ReloadSpeeds;

	private float[] VisibleReloadSpeeds;

	private float[] Damages;

	private float[] VisibleDamages;

	private Vector2 CameraSway;

	private Vector2 CameraSwayUsable;

	private float CameraSwayFactor;

	private float CameraMoveFactor;

	private Vector3 LastBlockPosition;

	private float LastFire;

	[NonSerialized]
	public static int Makes;

	[NonSerialized]
	public static int Misses;

	private int ScoreYou;

	private int ScoreOpp;

	public AudioClip Ding;

	public AudioSource Audio;

	public AudioClip BeepLow;

	public AudioClip BeepHigh;

	public AudioClip Door;

	public AudioClip Click;

	public AudioClip Gong;

	public GameObject BlockShadow;

	[NonSerialized]
	public static GameObject StaticBlockShadow;

	private bool MadeChangesThisSession;

	private int PrizesThisRound;

	public TargetMat PrizeMats;

	public TargetMat[] TargetMats;

	public GUITexture Logo;

	public GUITexture LogoPro;

	public GameObject LogoControl;

	public GUITexture MainUse;

	public GUIText MainUseText;

	public GUITexture MainBuild;

	public GUIText MainBuildText;

	public GUITexture MainTrophy;

	public GUIText MainTrophyText;

	public GUITexture MainShare;

	public GUIText MainShareText;

	public GUITexture MainSettings;

	public GUITexture MainMore;

	public GUITexture MainMoreBadge;

	private GUITexture[] SavesBoxes;

	private GUITexture[] SavesTypes;

	private GUIText[] SavesNames;

	private GUIText[] SavesDates;

	private GUITexture[] SavesDeletes;

	private GUIText[] SavesSlots;

	public GUIText PrizeCounterText;

	public GUITexture[] GridsBoxes;

	public GUITexture SetsSelect;

	public GUITexture SetsArrowLeft;

	public GUITexture SetsArrowRight;

	public GUITexture InventoryBack;

	public GUIText InventoryAccuracyValueText;

	public GUIText InventoryReloadSpeedValueText;

	public GUIText InventoryRangeValueText;

	public GUITexture InventoryExpertBox;

	public GUIText BuildModeButtonText;

	public GUIText BuildModeAccuracyText;

	public GUIText BuildModeReloadSpeedText;

	public GUIText BuildModeRangeText;

	public GUIText BuildModeAccuracyValueText;

	public GUIText BuildModeReloadSpeedValueText;

	public GUIText BuildModeRangeValueText;

	public GUITexture SaveOrTrashTrash;

	public GUITexture SaveOrTrashSave;

	public GUITexture SaveGunSubmit;

	public GUITexture StorePrize;

	public GUITexture StoreBack;

	public GUITexture StoreBackdrop;

	public GUITexture StoreBackdropPro;

	public GUIText[] StoreProPackTexts;

	public GUIText StoreRemoveAdsText;

	public GUITexture StoreAllLevels;

	public GUIText StoreAllLevelsText;

	public GUITexture StoreDoubler;

	public GUITexture StoreProPack;

	public GUIText StorePrice0;

	public GUIText StorePrice1;

	public GUIText StorePrice2;

	public GUIText StorePriceDoubler;

	public GUIText StorePriceAllLevels;

	public GUIText StorePriceProPack;

	public GUITexture ModesAllLevels;

	public GUIText ModesAllLevelsPrice;

	public GUITexture MatchQuick;

	public GUIText MatchQuickText;

	public GUITexture MatchInvite;

	public GUIText MatchInviteText;

	public GUITexture MatchPractice;

	public GUIText MatchPracticeText;

	public GUITexture SettingsGyroscope;

	public GUIText SettingsGyroscopeText;

	public GUITexture SettingsSensitivityButton;

	public GUITexture SettingsSensitivityBar;

	public GUIText SettingsSensitivityText;

	public GUITexture SettingsVibration;

	public GUIText SettingsVibrationText;

	public GUITexture ShareLogo;

	public GUITexture ShareBack;

	public GUITexture ShareTake;

	public GameObject VideoGoldMenu;

	public GUIText VideoGoldGoldBefore;

	public GUIText VideoGoldGoldAfter;

	public GUITexture FarmSeed;

	public GUITexture FarmGun;

	public GUIText FarmSeedAmount;

	public GUITexture FarmCrosshairSeed;

	public GameObject[] BlockTutorialFlashes;

	public Material BlockTutorialRegularMat;

	public Material BlockTutorialFlashMat;

	private int LimLeft;

	private int LimRight;

	private int LimUp;

	private int LimDown;

	private int OpponentSet;

	private bool WonLastGame;

	private float Difficulty;

	public Camera CameraGuns;

	public GameObject[] FarmCubes;

	private GameObject LastFarmCubeHit;

	public GameObject[] PlantPrefabs;

	private Mesh[] PlantPrefabMeshes;

	public GameObject FarmGroundParent;

	private int PlantMask;

	public TextMesh PlantHoverText;

	private bool IsChance;

	public GameObject ChanceCube;

	public GameObject ChanceCubeParticles;

	public Texture2D[] ChanceTextures;

	private int ChanceType;

	private int ChancePlays;

	private float BuildAccuracy;

	private float BuildReloadSpeed;

	private float BuildRange;

	private string SeenAppsVersion;

	[NonSerialized]
	public static float[] TargetLife = new float[14]
	{
		4f, 7f, 1f, 5f, 3f, 1f, 3f, 8f, 4f, 1f,
		2f, 1f, 2f, 1f
	};

	[NonSerialized]
	public static int[] TargetValue = new int[14]
	{
		4, 8, 1, 5, 6, 1, 2, 3, 3, 1,
		1, 1, 1, 1
	};

	private int CoinsEarned;

	private bool OfferVideoGold;

	private float TimeUntilNextPrize;

	public Game()
	{
		BarrelsLeft = 1;
		SightsLeft = 1;
		TriggersLeft = 1;
		BlocksLeft = 20;
		CameraTargetRotation = new Vector3(18f, 0f, 0f);
		PlantMask = 32768;
		SeenAppsVersion = "8";
	}

	public virtual void Start()
	{
		Menu = (Menus)GetComponent(typeof(Menus));
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		BlockDictionary = new Dictionary<Vector3, int>();
		TargetDictionary = new Dictionary<Vector3, GameObject>();
		FarmDictionary = new Dictionary<Vector2, Plant>();
		for (int i = default(int); i < Extensions.get_length((System.Array)BlockSets); i++)
		{
			BlockSets[i].InventoryGUIs = new Texture2D[9];
			for (int j = default(int); j < i + 4; j++)
			{
				BlockSets[i].InventoryGUIs[j] = (Texture2D)Resources.Load("Inventory" + BlockSets[i].Blocks[j].name + Settings.Suffix);
			}
		}
		SavesBoxes = new GUITexture[6];
		SavesTypes = new GUITexture[6];
		SavesNames = new GUIText[6];
		SavesDates = new GUIText[6];
		SavesDeletes = new GUITexture[6];
		SavesSlots = new GUIText[6];
		for (int k = default(int); k < 6; k++)
		{
			SavesBoxes[k] = Menu.Get("SavesBox" + k.ToString()).GetComponent<GUITexture>();
			SavesTypes[k] = Menu.Get("SavesType" + k.ToString()).GetComponent<GUITexture>();
			SavesNames[k] = Menu.Get("SavesName" + k.ToString()).GetComponent<GUIText>();
			SavesDates[k] = Menu.Get("SavesDate" + k.ToString()).GetComponent<GUIText>();
			SavesDeletes[k] = Menu.Get("SavesDelete" + k.ToString()).GetComponent<GUITexture>();
			SavesSlots[k] = Menu.Get("SavesSlot" + k.ToString()).GetComponent<GUIText>();
		}
		InventoryItems = new GUITexture[9];
		InventoryItems[0] = Menu.Get("InventoryItem0").GetComponent<GUITexture>();
		InventoryItems[1] = Menu.Get("InventoryItem1").GetComponent<GUITexture>();
		InventoryItems[2] = Menu.Get("InventoryItem2").GetComponent<GUITexture>();
		InventoryItems[3] = Menu.Get("InventoryItem3").GetComponent<GUITexture>();
		InventoryItems[4] = Menu.Get("InventoryItem4").GetComponent<GUITexture>();
		InventoryItems[5] = Menu.Get("InventoryItem5").GetComponent<GUITexture>();
		InventoryItems[6] = Menu.Get("InventoryItem6").GetComponent<GUITexture>();
		InventoryItems[7] = Menu.Get("InventoryItem7").GetComponent<GUITexture>();
		InventoryItems[8] = Menu.Get("InventoryItem8").GetComponent<GUITexture>();
		InventoryAmounts = new int[9];
		InventoryAmountsText = new GUIText[9];
		InventoryAmountsText[0] = Menu.Get("InventoryAmount0").GetComponent<GUIText>();
		InventoryAmountsText[1] = Menu.Get("InventoryAmount1").GetComponent<GUIText>();
		InventoryAmountsText[2] = Menu.Get("InventoryAmount2").GetComponent<GUIText>();
		InventoryAmountsText[3] = Menu.Get("InventoryAmount3").GetComponent<GUIText>();
		InventoryAmountsText[4] = Menu.Get("InventoryAmount4").GetComponent<GUIText>();
		InventoryAmountsText[5] = Menu.Get("InventoryAmount5").GetComponent<GUIText>();
		InventoryAmountsText[6] = Menu.Get("InventoryAmount6").GetComponent<GUIText>();
		InventoryAmountsText[7] = Menu.Get("InventoryAmount7").GetComponent<GUIText>();
		InventoryAmountsText[8] = Menu.Get("InventoryAmount8").GetComponent<GUIText>();
		InventoryBaseAmounts = new int[9];
		InventoryBaseAmounts[0] = 1;
		InventoryBaseAmounts[1] = 1;
		InventoryBaseAmounts[2] = 1;
		InventoryBaseAmounts[3] = 20;
		InventoryBaseAmounts[4] = 20;
		InventoryBaseAmounts[5] = 20;
		InventoryBaseAmounts[6] = 20;
		InventoryBaseAmounts[7] = 20;
		InventoryBaseAmounts[8] = 20;
		if (Saver.GetBoolean("ProPack"))
		{
			InventoryBaseAmounts[0] = 2;
		}
		GridHeights = new int[5];
		GridHeights[0] = 1;
		GridHeights[1] = 2;
		GridHeights[2] = 2;
		GridHeights[3] = 3;
		GridHeights[4] = 4;
		GridAmmos = new int[5];
		GridAmmos[0] = 8;
		GridAmmos[1] = 12;
		GridAmmos[2] = 16;
		GridAmmos[3] = 20;
		GridAmmos[4] = 30;
		ModeRequirements = new int[20];
		ModeRequirements[0] = 1;
		ModeRequirements[1] = 2;
		ModeRequirements[2] = 3;
		ModeRequirements[3] = 4;
		ModeRequirements[4] = 6;
		ModeRequirements[5] = 8;
		ModeRequirements[6] = 10;
		ModeRequirements[7] = 12;
		ModeRequirements[8] = 14;
		ModeRequirements[9] = 17;
		ModeRequirements[10] = 20;
		ModeRequirements[11] = 24;
		ModeRequirements[12] = 28;
		ModeRequirements[13] = 32;
		ModeRequirements[14] = 36;
		ModeRequirements[15] = 40;
		ModeRequirements[16] = 45;
		ModeRequirements[17] = 50;
		ModeRequirements[18] = 55;
		ModeRequirements[19] = 60;
		ModePresents = new int[20];
		ModePresents[0] = 1;
		ModePresents[1] = 2;
		ModePresents[2] = 2;
		ModePresents[3] = 3;
		ModePresents[4] = 3;
		ModePresents[5] = 4;
		ModePresents[6] = 4;
		ModePresents[7] = 4;
		ModePresents[8] = 5;
		ModePresents[9] = 5;
		ModePresents[10] = 5;
		ModePresents[11] = 5;
		ModePresents[12] = 6;
		ModePresents[13] = 6;
		ModePresents[14] = 6;
		ModePresents[15] = 7;
		ModePresents[16] = 7;
		ModePresents[17] = 7;
		ModePresents[18] = 7;
		ModePresents[19] = 7;
		Accuracies = new float[6];
		Accuracies[0] = 0.1f;
		Accuracies[1] = 0.2f;
		Accuracies[2] = 0.35f;
		Accuracies[3] = 0.5f;
		Accuracies[4] = 0.7f;
		Accuracies[5] = 1f;
		VisibleAccuracies = new float[6];
		VisibleAccuracies[0] = 0.008f;
		VisibleAccuracies[1] = 0.06f;
		VisibleAccuracies[2] = 0.3f;
		VisibleAccuracies[3] = 0.5f;
		VisibleAccuracies[4] = 0.72f;
		VisibleAccuracies[5] = 0.99f;
		ReloadSpeeds = new float[6];
		ReloadSpeeds[0] = 0.01f;
		ReloadSpeeds[1] = 0.2f;
		ReloadSpeeds[2] = 0.35f;
		ReloadSpeeds[3] = 0.5f;
		ReloadSpeeds[4] = 0.7f;
		ReloadSpeeds[5] = 1f;
		VisibleReloadSpeeds = new float[6];
		VisibleReloadSpeeds[0] = 0.01f;
		VisibleReloadSpeeds[1] = 0.08f;
		VisibleReloadSpeeds[2] = 0.34f;
		VisibleReloadSpeeds[3] = 0.46f;
		VisibleReloadSpeeds[4] = 0.7f;
		VisibleReloadSpeeds[5] = 0.98f;
		Damages = new float[6];
		Damages[0] = 0.5f;
		Damages[1] = 1f;
		Damages[2] = 1.2f;
		Damages[3] = 1.5f;
		Damages[4] = 2f;
		Damages[5] = 2.5f;
		VisibleDamages = new float[6];
		VisibleDamages[0] = 0.02f;
		VisibleDamages[1] = 0.1f;
		VisibleDamages[2] = 0.27f;
		VisibleDamages[3] = 0.52f;
		VisibleDamages[4] = 0.74f;
		VisibleDamages[5] = 0.995f;
		StaticBlockShadow = BlockShadow;
		FragmentsYou0 = UnityEngine.Object.Instantiate(Fragments, Vector3.zero, Quaternion.identity);
		FragmentsYou1 = UnityEngine.Object.Instantiate(Fragments, Vector3.zero, Quaternion.identity);
		FragmentsOpp0 = UnityEngine.Object.Instantiate(Fragments, Vector3.zero, Quaternion.identity);
		FragmentsOpp1 = UnityEngine.Object.Instantiate(Fragments, Vector3.zero, Quaternion.identity);
		float a = 0.8f;
		Color color = VersusName.GetComponent<Renderer>().material.color;
		float num = (color.a = a);
		Color color3 = (VersusName.GetComponent<Renderer>().material.color = color);
		TwoFingersLastFrame = new Vector2[2];
		DirectionalLightStartingRotation = DirectionalLight.transform.eulerAngles;
		FarmBuildFromPlantArray();
		Menu.Get("ModesAllLevelsText").GetComponent<GUIText>().text = Menu.Get("ModesAllLevelsText").GetComponent<GUIText>().text + "!";
		PlantPrefabMeshes = new Mesh[Extensions.get_length((System.Array)PlantPrefabs)];
		for (int l = default(int); l < Extensions.get_length((System.Array)PlantPrefabs); l++)
		{
			PlantPrefabMeshes[l] = ((MeshFilter)PlantPrefabs[l].GetComponent(typeof(MeshFilter))).sharedMesh;
		}
		if (Settings.Quality <= 3)
		{
			int m = 0;
			GameObject[] flair = Flair;
			for (int length = flair.Length; m < length; m++)
			{
				flair[m].SetActive(false);
			}
		}
		if (Debug.isDebugBuild)
		{
			Saver.Set("Currency", 8000);
			Saver.Set("Seeds", 2);
		}
		if (Settings.IsPro && Saver.Get("ExpertMode") == string.Empty)
		{
			BuildModeToggle(true);
		}
		AddCurrency(0);
		StartCoroutine(Menu.LoadGame(0));
	}

	public virtual void Update()
	{
		Menu.CheckButtons();
		if (Debug.isDebugBuild && Input.touchCount > 3 && Input.GetTouch(3).phase == TouchPhase.Began)
		{
			Menu.RunAd("Home Screen");
		}
		CameraSway.x += 1.2f * Time.deltaTime;
		CameraSway.y += 0.8f * Time.deltaTime;
		CameraSwayUsable = new Vector2(Mathf.Sin(CameraSway.x) * 3f, Mathf.Sin(CameraSway.y) * 3f) * CameraSwayFactor;
		if (IsBuilding)
		{
			int i = 0;
			CustomTouch[] touches = Menus.Touches;
			for (int length = touches.Length; i < length; i++)
			{
				if (Menu.Began(touches[i]))
				{
					SlidingFinger = touches[i].fingerId;
					TouchStart = touches[i].position;
					TouchLastFrame = touches[i].position;
				}
				else if (Menu.Moved(touches[i]))
				{
					if (touches[i].fingerId == SlidingFinger)
					{
						if (!(Vector2.Distance(touches[i].position, TouchStart) <= Settings.DPI * 2f / 80f))
						{
							SlidThisFrame = true;
						}
						CamOffset.x -= (touches[i].position.x - TouchLastFrame.x) / Settings.DPI;
						CamInertia.x -= (touches[i].position.x - TouchLastFrame.x) / Settings.DPI * 0.15f;
						CamOffset.y -= (touches[i].position.y - TouchLastFrame.y) / Settings.DPI;
						CamInertia.y -= (touches[i].position.y - TouchLastFrame.y) / Settings.DPI * 0.15f;
						TouchLastFrame = touches[i].position;
					}
				}
				else if (Menu.Stationary(touches[i]))
				{
					if (touches[i].fingerId == SlidingFinger)
					{
						CamInertia = Vector2.Lerp(CamInertia, Vector2.zero, Time.deltaTime * 30f);
					}
				}
				else
				{
					if (!Menu.Ended(touches[i]) || SlidThisFrame)
					{
						continue;
					}
					RaycastHit hitInfo = default(RaycastHit);
					Ray ray = Camera.main.ScreenPointToRay(touches[i].position);
					if (!Physics.Raycast(ray, out hitInfo, 300f))
					{
						continue;
					}
					Vector3 localPosition = hitInfo.collider.gameObject.transform.localPosition;
					Vector3 vector = hitInfo.collider.gameObject.transform.localPosition + hitInfo.normal;
					if (SelectedType == 9)
					{
						if (hitInfo.collider.gameObject.layer == 11)
						{
							MadeChangesThisSession = true;
							RemoveBlock(hitInfo.collider.gameObject, new Vector3(Mathf.Round(localPosition.x), Mathf.Round(localPosition.y), Mathf.Round(localPosition.z)));
						}
					}
					else if (hitInfo.collider.gameObject.layer == 8 || hitInfo.collider.gameObject.layer == 11)
					{
						MadeChangesThisSession = true;
						CreateBlock(SelectedType, new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z)), false);
					}
				}
			}
			if (Extensions.get_length((System.Array)Menus.Touches) == 0)
			{
				SlidThisFrame = false;
				CamOffset.x += CamInertia.x;
				CamOffset.y += CamInertia.y;
			}
			CamInertia = Vector2.Lerp(CamInertia, Vector2.zero, Time.deltaTime * 8f);
			CamOffset.y = Mathf.Clamp(CamOffset.y, -1.3f, 1.3f);
			float value = 0f - Mathf.Sqrt(Mathf.Abs(Mathf.Clamp(CamOffset.y, -999f, 0f)));
			float num = Mathf.Sin(CamOffset.x) * 1.5f * (float)(SelectedGrid + 4) / 8f - Mathf.Sin(CamOffset.x) * Mathf.Clamp(value, -999f, 0f) * 1f;
			float num2 = (0f - Mathf.Cos(CamOffset.x)) * 0.5f * (float)(SelectedGrid + 4) / 8f + Mathf.Cos(CamOffset.x) * Mathf.Clamp(value, -999f, 0f) * 1f;
			transform.position = Vector3.Lerp(transform.position, new Vector3(3.9f + num, 2.89f + CamOffset.y * 1f + (float)SelectedGrid / 12f, 3.5f + num2), Time.deltaTime * 6f);
			float y = 0.4f * Mathf.Abs(CamOffset.y) * (float)SelectedGrid / 5f;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(GridParent.position + LastBlockPosition / 30f - transform.position + new Vector3(0f, y, 0f)), Time.deltaTime * 8f);
		}
		else if (IsShooting)
		{
			((Guns)GetComponent(typeof(Guns))).UpdateGun();
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, CameraTargetDestination, Time.deltaTime * 1f * CameraMoveFactor);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CameraTargetRotation) * Quaternion.Euler(new Vector3(CameraSwayUsable.x, CameraSwayUsable.y, 0f)), Time.deltaTime * 2f);
		}
	}

	public virtual void GunsFired(Vector3 Destination)
	{
		if (Menus.MatchAction != string.Empty)
		{
			Menus.AppendMatchAction(",,");
		}
		string lhs = (Mathf.Round(Destination.x * 10f) / 10f).ToString("F1");
		string rhs = (Mathf.Round(Destination.y * 10f) / 10f).ToString("F1");
		string rhs2 = (Mathf.Round(Destination.z * 10f) / 10f).ToString("F1");
		if (Mathf.Round(Destination.x * 10f) / 10f == Mathf.Round(Destination.x))
		{
			lhs = Mathf.Round(Destination.x).ToString("F0");
		}
		if (Mathf.Round(Destination.y * 10f) / 10f == Mathf.Round(Destination.y))
		{
			rhs = Mathf.Round(Destination.y).ToString("F0");
		}
		if (Mathf.Round(Destination.z * 10f) / 10f == Mathf.Round(Destination.z))
		{
			rhs2 = Mathf.Round(Destination.z).ToString("F0");
		}
		string rhs3 = lhs + "," + rhs + "," + rhs2;
		string text = (Time.time - LastFire).ToString("F2");
		if (Mathf.Round((Time.time - LastFire) * 10f) / 10f == Mathf.Round((Time.time - LastFire) * 100f) / 100f)
		{
			text = (Time.time - LastFire).ToString("F1");
		}
		if (text.Substring(0, 1) == "0")
		{
			text = text.Substring(1, text.Length - 1);
		}
		Menus.AppendMatchAction(text + "," + rhs3);
		LastFire = Time.time;
	}

	public virtual IEnumerator SetColors(GameObject Block)
	{
		return new _0024SetColors_0024579(Block).GetEnumerator();
	}

	public virtual void GunsHit(BulletInfo Bullet)
	{
		if (Bullet.RayHit.collider != null)
		{
			GameObject gameObject = Bullet.RayHit.collider.gameObject;
			if (gameObject.layer == 10)
			{
				if (Bullet.WasYou)
				{
					Saver.Set("Makes", Saver.GetInt("Makes") + 1);
				}
				Target target = (Target)gameObject.GetComponent(typeof(Target));
				if (Bullet.WasYou)
				{
					target.Hit(Guns.AllGuns[Guns.CurrentGun].Damage);
				}
				else
				{
					target.Hit(Damages[OpponentSet]);
				}
				StartCoroutine(SetColors(gameObject));
				int value = (int)Mathf.Floor(target.DamageDealt / target.Life * 4f);
				value = Mathf.Clamp(value, 0, 3);
				if (target.IsPresent)
				{
					gameObject.GetComponent<Renderer>().sharedMaterial = PrizeMats.Materials[value];
				}
				else
				{
					gameObject.GetComponent<Renderer>().sharedMaterial = TargetMats[(int)target.Type].Materials[value];
				}
				if (!(target.DamageDealt < target.Life))
				{
					Audio.PlayOneShot(Ding);
					int value2 = (int)target.Value;
					value2 = Mathf.Clamp(value2, 0, 999);
					if (Bullet.WasYou)
					{
						if (target.IsPresent)
						{
							PrizesThisRound++;
							StartCoroutine(ShowCoin());
							CoinAudio.Play();
							Saver.Set("PrizesEarned", Saver.GetInt("PrizesEarned") + 1);
						}
						else
						{
							StartCoroutine(Guns.ShowPoints(value2));
							Saver.Set("BlocksDestroyed", Saver.GetInt("BlocksDestroyed") + 1);
						}
					}
					Score(Bullet.WasYou, value2);
					float num = (gameObject.transform.position.x - transform.position.x) / 2f;
					target.enabled = false;
					gameObject.GetComponent<Collider>().enabled = false;
					gameObject.SetActive(false);
					ShowFragments(Bullet.WasYou, gameObject.transform.position, (int)target.Type);
					TargetsRemaining--;
					if (TargetsRemaining == 0)
					{
						StopCoroutine("RunGame");
						GameOver();
					}
					Vector3 position = gameObject.transform.position;
					TargetDictionary.Remove(position);
					int i = 0;
					Vector3[] dir = Blocks.dir;
					for (int length = dir.Length; i < length; i++)
					{
						Blocks.SetLighting(position + dir[i]);
					}
				}
			}
			else if (gameObject.layer == 16)
			{
				ShowFragments(Bullet.WasYou, gameObject.transform.position + new Vector3(0f, 2f, 0f), 4);
				StopCoroutine("FarmDestroyPlant");
				StartCoroutine("FarmDestroyPlant", gameObject);
			}
			else if (gameObject.layer == 18)
			{
				StartCoroutine("ChanceHitCube");
			}
		}
		if (Bullet.WasYou)
		{
			Saver.Set("ShotsFired", Saver.GetInt("ShotsFired") + 1);
		}
	}

	public virtual void ShowFragments(bool WasYou, Vector3 Location, int Type)
	{
		GameObject gameObject = null;
		float num = default(float);
		if (WasYou)
		{
			if (CurrentFragmentYou == 0)
			{
				gameObject = FragmentsYou0;
				CurrentFragmentYou++;
			}
			else
			{
				gameObject = FragmentsYou1;
				CurrentFragmentYou = 0;
			}
			num = Location.x - this.transform.position.x;
		}
		else
		{
			if (CurrentFragmentOpp == 0)
			{
				gameObject = FragmentsOpp0;
				CurrentFragmentOpp++;
			}
			else
			{
				gameObject = FragmentsOpp1;
				CurrentFragmentOpp = 0;
			}
			num = Location.x - (-40f - this.transform.position.x);
		}
		gameObject.SetActive(true);
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(gameObject.transform);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			transform.GetComponent<Renderer>().sharedMaterial.mainTexture = TargetMats[Type].Materials[0].mainTexture;
			UnityRuntimeServices.Update(enumerator, transform);
			transform.transform.position = Location;
			UnityRuntimeServices.Update(enumerator, transform);
			transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(8, 14));
			UnityRuntimeServices.Update(enumerator, transform);
			transform.GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-10f + num, 10f + num), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(-10, 10));
			UnityRuntimeServices.Update(enumerator, transform);
		}
	}

	public virtual IEnumerator DestroyFragment(GameObject Fragment)
	{
		return new _0024DestroyFragment_0024587(Fragment).GetEnumerator();
	}

	public virtual IEnumerator BeginGame(int Mode)
	{
		return new _0024BeginGame_0024590(Mode, this).GetEnumerator();
	}

	public virtual IEnumerator SetupGame(int Mode)
	{
		return new _0024SetupGame_0024596(Mode, this).GetEnumerator();
	}

	public virtual IEnumerator RunGame()
	{
		return new _0024RunGame_0024616(this).GetEnumerator();
	}

	public virtual IEnumerator SimMatch()
	{
		return new _0024SimMatch_0024623(this).GetEnumerator();
	}

	public virtual IEnumerator SimPractice()
	{
		return new _0024SimPractice_0024637(this).GetEnumerator();
	}

	public virtual void MatchPrefixGenerate()
	{
		if (SelectedSaveSlot == -1)
		{
			for (int num = 5; num >= 0; num--)
			{
				if (UsingSaveSlot(num))
				{
					SelectedSaveSlot = num;
					break;
				}
			}
		}
		Menus.MatchPrefix = Saver.Get("SlotData" + SelectedSaveSlot.ToString()) + ",,," + Saver.Get("SlotSet" + SelectedSaveSlot.ToString());
	}

	public virtual void MatchPrefixOpponent(UnityScript.Lang.Array OpponentPrefix)
	{
		if (Menus.GameMode == 0)
		{
			string data = OpponentPrefix[0].ToString();
			object obj = OpponentPrefix[1];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			BuildOpponentGun(data, int.Parse((string)obj));
			VersusName.text = Menus.OpponentName;
			VersusName.gameObject.SetActive(true);
			Guns.OppGunSource.clip = FireSound;
		}
	}

	public virtual void Score(bool WasYou, int Points)
	{
		if (WasYou)
		{
			ScoreYou += Points;
			ScoreFontYou.text = ScoreYou.ToString();
		}
		else
		{
			ScoreOpp += Points;
			ScoreFontOpp.text = ScoreOpp.ToString();
		}
	}

	public virtual IEnumerator ShowCoin()
	{
		return new _0024ShowCoin_0024650(this).GetEnumerator();
	}

	public virtual void GainedLevel(int Level)
	{
		Menus.HighScore("level", Menu.Level());
		Menu.Achievement("level1", (float)Menu.Level() * 1f / 10f * 100f);
		Menu.Achievement("level2", (float)Menu.Level() * 1f / 30f * 100f);
	}

	public virtual void GameOver()
	{
		Menu.RestartMenus();
		Menu.Sho("GameOver");
		Menu.Sho("Ticker");
		CoinsEarned = 0;
		Menus.GameEnded = true;
		OfferVideoGold = false;
		StartCoroutine(Menu.ReportYourSimData());
		Menu.Get("GameOverRematch").GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		Menu.Get("GameOverRematchText").GetComponent<GUIText>().material.color = Menu.Colors[16].Col;
		Menu.Get("GameOverSpeech").GetComponent<GUIText>().text = "...";
		Menu.Get("GameOverNameYou").GetComponent<GUIText>().text = Menus.PlayerName;
		Menu.Get("GameOverNameOpp").GetComponent<GUIText>().text = Menus.OpponentName;
		Menu.Get("GameOverScoreYou").GetComponent<GUIText>().text = ScoreYou.ToString();
		Menu.Get("GameOverScoreOpp").GetComponent<GUIText>().text = ScoreOpp.ToString();
		StartCoroutine(Menu.Fade(0.25f));
		StopCoroutine("SimMatch");
		StopCoroutine("SimPractice");
		int value = Saver.GetInt("totalWins") + Saver.GetInt("totalLosses");
		float num = 0.25f / (float)Mathf.Clamp(value, 2, 4);
		if (ScoreYou > ScoreOpp)
		{
			Menus.Score("totalWins");
			Menu.Achievement("wins1", (float)Saver.GetInt("totalWins") * 1f / 100f * 100f);
			if (Menu.OfferVideo())
			{
				OfferVideoGold = true;
			}
			WonLastGame = true;
			if (!Menus.IsSim && Menus.IsFriendMatch)
			{
				Menus.Score("friendWins");
			}
			Difficulty += num;
		}
		else
		{
			Saver.Set("totalLosses", Saver.GetInt("totalLosses") + 1);
			WonLastGame = false;
			if (!(UnityEngine.Random.Range(0f, 1f) >= 0.5f))
			{
				Difficulty -= num;
			}
		}
		Saver.Set("Difficulty", Difficulty);
		if (Menus.GameMode < 0)
		{
			Saver.Set("totalPractices", Saver.GetInt("totalPractices") + 1);
		}
		if (ScoreYou > Saver.GetInt(App.Leaderboards[Mathf.Abs(Menus.GameMode) + 3].ID))
		{
			Menu.Sho("GameOverHighScore");
			Menus.HighScore(App.Leaderboards[Mathf.Abs(Menus.GameMode) + 3].ID, ScoreYou);
		}
		else
		{
			Menu.Hid("GameOverHighScore");
		}
		string text = null;
		int num2 = 0;
		if (ScoreYou > ScoreOpp)
		{
			text = Loc.L("Victory");
			if (!Settings.IsPro)
			{
				num2 = 5;
				Menu.AddExperience(100);
			}
			else
			{
				num2 = 10;
				Menu.AddExperience(200);
			}
		}
		else
		{
			text = Loc.L("Defeat");
			if (!Settings.IsPro)
			{
				num2 = 1;
				Menu.AddExperience(25);
			}
			else
			{
				num2 = 2;
				Menu.AddExperience(50);
			}
		}
		int num3 = 4;
		if (Settings.IsPro)
		{
			num3 = 8;
		}
		if (Saver.GetBoolean("Doubler"))
		{
			num2 *= 2;
			num3 *= 2;
		}
		Menu.Get("GameOverStatTitles").GetComponent<GUIText>().text = text + ":\n" + Loc.L("Prize") + "    :";
		Menu.Get("GameOverStatValues").GetComponent<GUIText>().text = "+ " + num2.ToString() + "\n+ " + (PrizesThisRound * num3).ToString();
		int num4 = Menu.Level();
		Menu.Get("GameOverLevelPrevious").GetComponent<GUIText>().text = num4.ToString();
		Menu.Get("GameOverLevelNext").GetComponent<GUIText>().text = (num4 + 1).ToString();
		float num5 = Menu.Progress() * 228.5f * Settings.Scale;
		Rect pixelInset = Menu.Get("GameOverFill").GetComponent<GUITexture>().pixelInset;
		float num7 = (pixelInset.width = num5);
		Rect rect2 = (Menu.Get("GameOverFill").GetComponent<GUITexture>().pixelInset = pixelInset);
		if (!Settings.IsPro)
		{
			Menu.AddExperience(150);
		}
		else
		{
			Menu.AddExperience(280);
		}
		CoinsEarned = num2 + PrizesThisRound * num3;
		StartCoroutine("GameOverXPBar");
		StartCoroutine("GameOverCoinCount", CoinsEarned);
		if (Menus.GameMode > 0)
		{
			StartCoroutine(Menu.RematchProcessBegan());
			Menu.Hid("GameOverTryAgain");
			Menu.Sho("GameOverRematch");
			Menu.Sho("GameOverSpeechBubble");
		}
		else
		{
			Menu.Sho("GameOverTryAgain");
			Menu.Hid("GameOverRematch");
			Menu.Hid("GameOverSpeechBubble");
		}
		Saver.Save();
	}

	public virtual IEnumerator GameOverCoinCount()
	{
		return new _0024GameOverCoinCount_0024663(this).GetEnumerator();
	}

	public virtual IEnumerator GameOverXPBar()
	{
		return new _0024GameOverXPBar_0024668().GetEnumerator();
	}

	public virtual void ShowVideoGold()
	{
		VideoGoldMenu.SetActive(true);
		Menu.Hid("GameOver");
		VideoGoldGoldBefore.text = CoinsEarned.ToString();
		VideoGoldGoldAfter.text = (CoinsEarned * 2).ToString();
	}

	public virtual void FinishedRewardedVideo(bool DidComplete)
	{
		if (DidComplete)
		{
			AddCurrency(CoinsEarned);
		}
		StartCoroutine(Menu.LoadGame(0));
	}

	public virtual IEnumerator ShowLogo()
	{
		return new _0024ShowLogo_0024673(this).GetEnumerator();
	}

	public virtual IEnumerator ShowLogoFast()
	{
		return new _0024ShowLogoFast_0024681(this).GetEnumerator();
	}

	public virtual void ReturnToMain()
	{
		Menu.RestartMenus();
		Menu.Sho("Main");
		Menu.Sho("Ticker");
		TickerText.text = Saver.GetInt("Currency").ToString();
		IsBuilding = false;
		IsShooting = false;
		IsChance = false;
		SelectedSaveSlot = -1;
		BlockDictionary.Clear();
		TargetDictionary.Clear();
		UnityEngine.Object.Destroy(Gun2);
		Grids[SelectedGrid].SetActive(false);
		if (UsingAnySaveSlot())
		{
			MainUse.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			MainUseText.material.color = Menu.Colors[8].Col;
			MainShare.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			MainShareText.material.color = Menu.Colors[20].Col;
		}
		else
		{
			MainUse.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
			MainUseText.material.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
			MainShare.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
			MainShareText.material.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
		}
		if (!Saver.GetBoolean("LaunchedBefore"))
		{
			Saver.Set("LaunchedBefore", true);
			Saver.Set("Seeds", 1);
			Saver.Save();
			StartCoroutine("Tutorial");
		}
	}

	public virtual IEnumerator FlashMoreAppsBadge()
	{
		return new _0024FlashMoreAppsBadge_0024689(this).GetEnumerator();
	}

	public virtual IEnumerator Tutorial()
	{
		return new _0024Tutorial_0024693(this).GetEnumerator();
	}

	public virtual IEnumerator TutorialFlash(GUITexture Target)
	{
		return new _0024TutorialFlash_0024696(Target).GetEnumerator();
	}

	public virtual IEnumerator TutorialFlashPrize(GUITexture Target)
	{
		return new _0024TutorialFlashPrize_0024701(Target).GetEnumerator();
	}

	public virtual IEnumerator TutorialFlashBlock(GameObject Target)
	{
		return new _0024TutorialFlashBlock_0024706(Target, this).GetEnumerator();
	}

	public virtual bool UsingAnySaveSlot()
	{
		int num = default(int);
		int result;
		while (true)
		{
			if (num < 6)
			{
				if (UsingSaveSlot(num))
				{
					result = 1;
					break;
				}
				num++;
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public virtual bool UsingSaveSlot(int Slot)
	{
		return (Saver.Get("SlotName" + Slot.ToString()) != string.Empty) ? true : false;
	}

	public virtual void SetupGrid()
	{
		for (int i = default(int); i < Extensions.get_length((System.Array)Grids); i++)
		{
			if (i == SelectedGrid)
			{
				Grids[i].SetActive(true);
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(Grids[i].transform);
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					if (!(Mathf.Round(transform.transform.localPosition.x) >= (float)LimLeft))
					{
						LimLeft = (int)Mathf.Round(transform.transform.localPosition.x);
						UnityRuntimeServices.Update(enumerator, transform);
					}
					if (!(Mathf.Round(transform.transform.localPosition.x) <= (float)LimRight))
					{
						LimRight = (int)Mathf.Round(transform.transform.localPosition.x);
						UnityRuntimeServices.Update(enumerator, transform);
					}
					if (!(Mathf.Round(transform.transform.localPosition.z) >= (float)LimDown))
					{
						LimDown = (int)Mathf.Round(transform.transform.localPosition.z);
						UnityRuntimeServices.Update(enumerator, transform);
					}
					if (!(Mathf.Round(transform.transform.localPosition.z) <= (float)LimUp))
					{
						LimUp = (int)Mathf.Round(transform.transform.localPosition.z);
						UnityRuntimeServices.Update(enumerator, transform);
					}
				}
			}
			else
			{
				Grids[i].SetActive(false);
			}
		}
	}

	public virtual void SetupInventory()
	{
		MadeChangesThisSession = false;
		for (int i = default(int); i < 9; i++)
		{
			InventoryItems[i].texture = BlockSets[SelectedSet].InventoryGUIs[i];
			if (i > SelectedSet + 3)
			{
				InventoryAmounts[i] = 0;
				InventoryAmountsText[i].text = string.Empty;
				continue;
			}
			InventoryAmounts[i] = InventoryBaseAmounts[i];
			InventoryAmountsText[i].text = InventoryBaseAmounts[i].ToString();
			float a = Menu.Colors[0].Col.a;
			Color color = InventoryAmountsText[i].material.color;
			float num = (color.a = a);
			Color color3 = (InventoryAmountsText[i].material.color = color);
		}
		StartCoroutine(SwitchType(9));
		SetupGun();
		IsBuilding = true;
		Menu.Hid("Ticker");
		Menu.Sho("Inventory");
	}

	public virtual void BuildFromSave()
	{
		SelectedSet = Saver.GetInt("SlotSet" + SelectedSaveSlot.ToString());
		SelectedGrid = Saver.GetInt("SlotGrid" + SelectedSaveSlot.ToString());
		Menus.Advantage = SelectedSet;
		if (IsBuildMode)
		{
			SetupGrid();
			SetupInventory();
		}
		else
		{
			Menu.Hid("Ticker");
			SetupGun();
			for (int i = default(int); i < 9; i++)
			{
				InventoryAmounts[i] = 999;
			}
		}
		string text = Saver.Get("SlotData" + SelectedSaveSlot.ToString());
		if (text != string.Empty)
		{
			UnityScript.Lang.Array array = Regex.Split(Saver.Get("SlotData" + SelectedSaveSlot.ToString()), ",,");
			for (int j = default(int); j < array.length; j++)
			{
				UnityScript.Lang.Array array2 = array[j].ToString().Split(","[0]);
				object obj = array2[3];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				int type = int.Parse((string)obj);
				object obj2 = array2[0];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				float x = int.Parse((string)obj2);
				object obj3 = array2[1];
				if (!(obj3 is string))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(string));
				}
				float y = int.Parse((string)obj3);
				object obj4 = array2[2];
				if (!(obj4 is string))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(string));
				}
				CreateBlock(type, new Vector3(x, y, int.Parse((string)obj4)), true);
			}
		}
		if (!IsBuildMode)
		{
			GunHolder = new GameObject("GunHolder");
			Gun2.transform.parent = GunHolder.transform;
			Gun2.transform.localPosition = new Vector3(0f, 0f, 0f);
			Gun2.transform.localEulerAngles = new Vector3(270f, 90f, 0f);
			Gun2.transform.localScale = Vector3.one * 0.0115f;
			int num = -10;
			int num2 = 10;
			int num3 = -10;
			int num4 = 10;
			int num5 = -10;
			int num6 = 10;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(Gun2.transform);
			while (enumerator.MoveNext())
			{
				object obj5 = enumerator.Current;
				if (!(obj5 is Transform))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
				}
				Transform transform = (Transform)obj5;
				if (!(transform.localPosition.x <= (float)num))
				{
					num = (int)transform.localPosition.x;
					UnityRuntimeServices.Update(enumerator, transform);
				}
				if (!(transform.localPosition.x >= (float)num2))
				{
					num2 = (int)transform.localPosition.x;
					UnityRuntimeServices.Update(enumerator, transform);
				}
				if (!(transform.localPosition.y <= (float)num3))
				{
					num3 = (int)transform.localPosition.y;
					UnityRuntimeServices.Update(enumerator, transform);
				}
				if (!(transform.localPosition.y >= (float)num4))
				{
					num4 = (int)transform.localPosition.y;
					UnityRuntimeServices.Update(enumerator, transform);
				}
				if (!(transform.localPosition.z <= (float)num5))
				{
					num5 = (int)transform.localPosition.z;
					UnityRuntimeServices.Update(enumerator, transform);
				}
				if (!(transform.localPosition.z >= (float)num6))
				{
					num6 = (int)transform.localPosition.z;
					UnityRuntimeServices.Update(enumerator, transform);
				}
			}
			IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(Gun2.transform);
			while (enumerator2.MoveNext())
			{
				object obj6 = enumerator2.Current;
				if (!(obj6 is Transform))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(Transform));
				}
				Transform transform2 = (Transform)obj6;
				transform2.gameObject.layer = 9;
				UnityRuntimeServices.Update(enumerator2, transform2);
				float x2 = transform2.localPosition.x - (float)(num + num2) / 2f;
				Vector3 localPosition = transform2.localPosition;
				float num7 = (localPosition.x = x2);
				Vector3 vector2 = (transform2.localPosition = localPosition);
				UnityRuntimeServices.Update(enumerator2, transform2);
				float y2 = transform2.localPosition.y - (float)(num3 + num4) / 2f;
				Vector3 localPosition2 = transform2.localPosition;
				float num8 = (localPosition2.y = y2);
				Vector3 vector4 = (transform2.localPosition = localPosition2);
				UnityRuntimeServices.Update(enumerator2, transform2);
				float z = transform2.localPosition.z - (float)(num5 + num6) / 2f;
				Vector3 localPosition3 = transform2.localPosition;
				float num9 = (localPosition3.z = z);
				Vector3 vector6 = (transform2.localPosition = localPosition3);
				UnityRuntimeServices.Update(enumerator2, transform2);
				if (transform2.name == "0")
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(MuzzleFlash, Vector3.zero, Quaternion.identity);
					gameObject.name = "MuzzleFlash";
					gameObject.transform.parent = transform2;
					UnityRuntimeServices.Update(enumerator2, transform2);
					gameObject.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
					gameObject.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
					gameObject.transform.parent = GunHolder.transform;
					gameObject.gameObject.layer = 9;
				}
			}
			if (!IsShareMode)
			{
				Guns.AllGuns = new Gun[1];
				float num10 = Accuracies[SelectedSet];
				float num11 = ReloadSpeeds[SelectedSet];
				if (Saver.GetBoolean("ExpertMode"))
				{
					num10 += num10 * (BuildAccuracy + BuildRange) / 2f;
					num11 += num11 * BuildReloadSpeed;
				}
				Guns.AllGuns[0] = new Gun("1", GunHolder, GridAmmos[SelectedGrid], Accuracies[SelectedSet], ReloadSpeeds[SelectedSet], Damages[SelectedSet], 0, FireSound, ReloadSound);
				Guns.Equip(0);
				UnityEngine.Object.Destroy(GunHolder);
			}
		}
		BuildModeToggle(Saver.GetBoolean("ExpertMode"));
	}

	public virtual void BuildOpponentGun(string Data, int OppSet)
	{
		OpponentSet = OppSet;
		Gun2Opponent = new GameObject("Gun2Opponent");
		Gun2Opponent.transform.localScale = Vector3.one;
		Gun2Opponent.transform.localPosition = Vector3.zero;
		UnityScript.Lang.Array array = Regex.Split(Data, ",,");
		for (int i = default(int); i < array.length; i++)
		{
			UnityScript.Lang.Array array2 = array[i].ToString().Split(","[0]);
			object obj = array2[3];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			int type = int.Parse((string)obj);
			object obj2 = array2[0];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			float x = int.Parse((string)obj2);
			object obj3 = array2[1];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			float y = int.Parse((string)obj3);
			object obj4 = array2[2];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			CreateBlockOpponent(type, new Vector3(x, y, int.Parse((string)obj4)));
		}
		Gun2Opponent.transform.position = new Vector3(4f, 3.44f, 4.2f);
		Gun2Opponent.transform.localScale = Vector3.one * 0.22f;
		Gun2Opponent.transform.eulerAngles = new Vector3(270f, 0f, 0f);
		int num = -10;
		int num2 = 10;
		int num3 = -10;
		int num4 = 10;
		int num5 = -10;
		int num6 = 10;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(Gun2Opponent.transform);
		while (enumerator.MoveNext())
		{
			object obj5 = enumerator.Current;
			if (!(obj5 is Transform))
			{
				obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
			}
			Transform transform = (Transform)obj5;
			if (!(transform.localPosition.x <= (float)num))
			{
				num = (int)transform.localPosition.x;
				UnityRuntimeServices.Update(enumerator, transform);
			}
			if (!(transform.localPosition.x >= (float)num2))
			{
				num2 = (int)transform.localPosition.x;
				UnityRuntimeServices.Update(enumerator, transform);
			}
			if (!(transform.localPosition.y <= (float)num3))
			{
				num3 = (int)transform.localPosition.y;
				UnityRuntimeServices.Update(enumerator, transform);
			}
			if (!(transform.localPosition.y >= (float)num4))
			{
				num4 = (int)transform.localPosition.y;
				UnityRuntimeServices.Update(enumerator, transform);
			}
			if (!(transform.localPosition.z <= (float)num5))
			{
				num5 = (int)transform.localPosition.z;
				UnityRuntimeServices.Update(enumerator, transform);
			}
			if (!(transform.localPosition.z >= (float)num6))
			{
				num6 = (int)transform.localPosition.z;
				UnityRuntimeServices.Update(enumerator, transform);
			}
		}
		IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(Gun2Opponent.transform);
		while (enumerator2.MoveNext())
		{
			object obj6 = enumerator2.Current;
			if (!(obj6 is Transform))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(Transform));
			}
			Transform transform2 = (Transform)obj6;
			float x2 = transform2.localPosition.x - (float)(num + num2) / 2f;
			Vector3 localPosition = transform2.localPosition;
			float num7 = (localPosition.x = x2);
			Vector3 vector2 = (transform2.localPosition = localPosition);
			UnityRuntimeServices.Update(enumerator2, transform2);
			float y2 = transform2.localPosition.y - (float)(num3 + num4) / 2f;
			Vector3 localPosition2 = transform2.localPosition;
			float num8 = (localPosition2.y = y2);
			Vector3 vector4 = (transform2.localPosition = localPosition2);
			UnityRuntimeServices.Update(enumerator2, transform2);
			float z = transform2.localPosition.z - (float)(num5 + num6) / 2f;
			Vector3 localPosition3 = transform2.localPosition;
			float num9 = (localPosition3.z = z);
			Vector3 vector6 = (transform2.localPosition = localPosition3);
			UnityRuntimeServices.Update(enumerator2, transform2);
		}
		float y3 = 3.85f + (float)num5 * 0.22f / 2f;
		Vector3 position = VersusName.transform.position;
		float num10 = (position.y = y3);
		Vector3 vector8 = (VersusName.transform.position = position);
	}

	public virtual void CreateBlock(int Type, Vector3 Pos, object BuildingFromSave)
	{
		if (InventoryAmounts[Type] <= 0)
		{
			return;
		}
		if (Menus.IsTutorial)
		{
			if ((Menus.TutorialState == 5 && Pos != new Vector3(-1f, 1f, 0f)) || (Menus.TutorialState == 7 && Pos != new Vector3(0f, 1f, 0f)) || (Menus.TutorialState == 8 && Pos != new Vector3(1f, 1f, 0f)) || (Menus.TutorialState == 9 && Pos != new Vector3(1f, 1f, -1f)) || (Menus.TutorialState == 10 && Pos != new Vector3(1f, 1f, -2f)) || Menus.TutorialState == 11 || (Menus.TutorialState == 12 && Pos != new Vector3(1f, 1f, 1f)) || (Menus.TutorialState == 14 && Pos != new Vector3(0f, 1f, -1f)))
			{
				return;
			}
			Menus.TutorialState++;
		}
		if (Pos.y <= (float)GridHeights[SelectedGrid] && (!IsBuilding || (!(Pos.x < (float)LimLeft) && !(Pos.x > (float)LimRight) && !(Pos.z < (float)LimDown) && Pos.z <= (float)LimUp)))
		{
			if (!RuntimeServices.ToBool(BuildingFromSave))
			{
				BlockSound();
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(BlockSets[SelectedSet].Blocks[Type], Vector3.zero, Quaternion.identity);
			gameObject.name = Type.ToString();
			gameObject.layer = 11;
			if (gameObject != null)
			{
				gameObject.transform.parent = Gun2.transform;
				gameObject.transform.localPosition = new Vector3(Pos.x, Pos.y, Pos.z);
				gameObject.transform.localScale = Vector3.one;
			}
			InventoryAmounts[Type]--;
			InventoryAmountsText[Type].text = InventoryAmounts[Type].ToString();
			if (InventoryAmounts[Type] == 0)
			{
				InventoryItems[Type].color = new Color(0.4f, 0.4f, 0.4f, 0.2f);
				InventoryAmountsText[Type].text = "0";
				float a = 0.4f;
				Color color = InventoryAmountsText[Type].material.color;
				float num = (color.a = a);
				Color color3 = (InventoryAmountsText[Type].material.color = color);
			}
			BlockDictionary[Pos] = Type;
			LastBlockPosition = gameObject.transform.localPosition;
			if (!RuntimeServices.ToBool(BuildingFromSave) && !string.IsNullOrEmpty(Saver.Get("ExpertMode")))
			{
				BuildModeCalculate(false);
			}
		}
	}

	public virtual void CreateBlockOpponent(int Type, Vector3 Pos)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(BlockSets[OpponentSet].Blocks[Type], Vector3.zero, Quaternion.identity);
		gameObject.name = Type.ToString();
		gameObject.layer = 11;
		if (gameObject != null)
		{
			gameObject.transform.parent = Gun2Opponent.transform;
			gameObject.transform.localPosition = new Vector3(Pos.x, Pos.y, Pos.z);
			gameObject.transform.localScale = Vector3.one;
		}
		BlockDictionary[Pos] = Type;
		LastBlockPosition = gameObject.transform.localPosition;
	}

	public virtual void RemoveBlock(GameObject TheBlock, Vector3 Pos)
	{
		BlockSound();
		int num = int.Parse(TheBlock.name);
		InventoryAmounts[num]++;
		InventoryAmountsText[num].text = InventoryAmounts[num].ToString();
		float a = Menu.Colors[0].Col.a;
		Color color = InventoryAmountsText[num].material.color;
		float num2 = (color.a = a);
		Color color3 = (InventoryAmountsText[num].material.color = color);
		InventoryItems[num].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		LastBlockPosition = TheBlock.transform.localPosition;
		UnityEngine.Object.Destroy(TheBlock);
		if (BlockDictionary.ContainsKey(Pos))
		{
			BlockDictionary.Remove(Pos);
		}
		BuildModeCalculate(false);
	}

	public virtual void BlockSound()
	{
		AudioClip[] sandSounds = ((Guns)GetComponent(typeof(Guns))).SandSounds;
		Audio.PlayOneShot(sandSounds[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)sandSounds))], 0.4f);
	}

	public virtual void SetupGun()
	{
		Gun2 = new GameObject("Gun2");
		Gun2.transform.parent = Grids[SelectedGrid].transform;
		Gun2.transform.localScale = Vector3.one;
		Gun2.transform.localPosition = Vector3.zero;
	}

	public virtual IEnumerator InventoryFlashBarrel()
	{
		return new _0024InventoryFlashBarrel_0024713(this).GetEnumerator();
	}

	public virtual IEnumerator SwitchType(int Type)
	{
		return new _0024SwitchType_0024718(Type, this).GetEnumerator();
	}

	public virtual void ShowBuildMode()
	{
		BuildModeToggle(Saver.GetBoolean("ExpertMode"));
		Menu.Sho("BuildMode");
	}

	public virtual void BuildModeToggle(bool IsExpertMode)
	{
		if (IsExpertMode)
		{
			if (!Settings.IsPro)
			{
				BuildModeButtonText.text = Loc.L("Expert");
			}
			else
			{
				BuildModeButtonText.text = "Pro";
			}
			Saver.Set("ExpertMode", true);
			InventoryAccuracyValueText.enabled = true;
			InventoryReloadSpeedValueText.enabled = true;
			InventoryRangeValueText.enabled = true;
			InventoryExpertBox.enabled = true;
			BuildModeCalculate(false);
		}
		else
		{
			BuildModeButtonText.text = Loc.L("Creative");
			Saver.Set("ExpertMode", false);
			InventoryAccuracyValueText.enabled = false;
			InventoryReloadSpeedValueText.enabled = false;
			InventoryRangeValueText.enabled = false;
			InventoryExpertBox.enabled = false;
			BuildModeCalculate(true);
		}
		Saver.Save();
	}

	public virtual void BuildModeCalculate(bool IsReset)
	{
		int num = default(int);
		Vector3 vector = default(Vector3);
		int num2 = default(int);
		Vector3 vector2 = default(Vector3);
		int num3 = default(int);
		Vector3 vector3 = default(Vector3);
		int num4 = default(int);
		StopCoroutine("FlashBuildText");
		StartCoroutine("FlashBuildText");
		BuildAccuracy = -1f;
		BuildReloadSpeed = -1f;
		BuildRange = -1f;
		float num5 = default(float);
		float num6 = default(float);
		Dictionary<Vector3, int>.Enumerator enumerator = BlockDictionary.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value == 0)
			{
				num++;
				vector = enumerator.Current.Key;
			}
			else if (enumerator.Current.Value == 1)
			{
				num2++;
				vector2 = enumerator.Current.Key;
			}
			else if (enumerator.Current.Value == 2)
			{
				num3++;
				vector3 = enumerator.Current.Key;
			}
			else if (enumerator.Current.Value == 3)
			{
				num4++;
			}
			num5 += enumerator.Current.Key.x;
			num6 += enumerator.Current.Key.z;
		}
		num5 /= (float)BlockDictionary.Count;
		num6 /= (float)BlockDictionary.Count;
		if (num != 0)
		{
			BuildAccuracy += 0.5f;
			BuildReloadSpeed += 0.5f;
			BuildRange += 0.5f;
			bool flag = default(bool);
			bool flag2 = default(bool);
			enumerator = BlockDictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value != 0)
				{
					if (!flag && enumerator.Current.Key.z == vector.z && enumerator.Current.Key.y == vector.y && !(enumerator.Current.Key.x >= vector.x))
					{
						BuildAccuracy -= 0.382f;
						BuildRange -= 0.467f;
						flag = true;
					}
					if (!flag2 && enumerator.Current.Key.z == vector.z && enumerator.Current.Key.y == vector.y && enumerator.Current.Key.x == vector.x + 1f)
					{
						flag2 = true;
					}
				}
			}
			if (!flag2)
			{
				BuildRange -= 0.131f;
			}
		}
		if (num2 != 0)
		{
			if (!Settings.IsPro)
			{
				BuildAccuracy += 0.244f;
				BuildRange += 0.172f;
			}
			else
			{
				BuildAccuracy += 0.31f;
				BuildRange += 0.272f;
			}
			enumerator = BlockDictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value != 1)
				{
					if (!(enumerator.Current.Key.z < vector2.z))
					{
						BuildAccuracy -= 0.061f;
						BuildRange -= 0.055f;
					}
					if (enumerator.Current.Key.x == vector2.x && enumerator.Current.Key.y == vector2.y && enumerator.Current.Key.z == vector2.z - 1f && enumerator.Current.Value != 0 && enumerator.Current.Value != 2)
					{
						BuildAccuracy += 0.023f;
					}
					if (enumerator.Current.Value == 0 && !(enumerator.Current.Key.z - vector2.z > 0f))
					{
						BuildAccuracy -= 0.028f;
					}
				}
			}
		}
		if (num3 != 0)
		{
			BuildAccuracy += 0.047f;
			BuildReloadSpeed += 0.274f;
			BuildRange += 0.111f;
			if (!(vector3.z <= num6))
			{
				BuildReloadSpeed -= 0.014f;
			}
			int num7 = default(int);
			enumerator = BlockDictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value == 2)
				{
					continue;
				}
				if (enumerator.Current.Key.x == vector3.x + 1f && enumerator.Current.Key.y == vector3.y && enumerator.Current.Key.z == vector3.z)
				{
					BuildReloadSpeed += 0.01f;
				}
				if (enumerator.Current.Key.x == vector3.x && enumerator.Current.Key.y == vector3.y && enumerator.Current.Key.z == vector3.z + 1f)
				{
					BuildReloadSpeed += 0.01f;
				}
				if (enumerator.Current.Value == 0)
				{
					if (enumerator.Current.Key.z - vector3.z == 1f || enumerator.Current.Key.z - vector3.z == 2f)
					{
						BuildReloadSpeed += 0.02f;
						BuildAccuracy += 0.01f;
					}
					if (!(enumerator.Current.Key.z - vector3.z > 0f))
					{
						BuildReloadSpeed -= 0.015f;
						BuildAccuracy -= 0.01f;
					}
				}
			}
		}
		if (!Settings.IsPro)
		{
			BuildAccuracy += 0.05f * (float)Mathf.Clamp(num4, 0, 5);
			BuildReloadSpeed += 0.05f * (float)Mathf.Clamp(num4, 0, 5);
			BuildRange += 0.05f * (float)Mathf.Clamp(num4, 0, 5);
		}
		else
		{
			BuildAccuracy += 0.031f * (float)Mathf.Clamp(num4, 0, 8);
			BuildReloadSpeed += 0.027f * (float)Mathf.Clamp(num4, 0, 8);
			BuildRange += 0.021f * (float)Mathf.Clamp(num4, 0, 8);
		}
		int num8 = default(int);
		enumerator = BlockDictionary.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!(enumerator.Current.Key.x <= num5))
			{
				num8++;
			}
			else if (!(enumerator.Current.Key.x >= num5))
			{
				num8--;
			}
		}
		num8 = (int)Mathf.Round(Mathf.Abs(num8));
		float num9 = 4f - Mathf.Round(Mathf.Abs(num8));
		if (num != 0)
		{
			BuildAccuracy += 0.005f * num9;
			BuildReloadSpeed += 0.01f * num9;
			BuildRange += 0.01f * num9;
		}
		if (IsReset)
		{
			BuildAccuracy = 0f;
			BuildReloadSpeed = 0f;
			BuildRange = 0f;
		}
		BuildAccuracy = Mathf.Clamp(BuildAccuracy, -1f, 0.2f);
		BuildReloadSpeed = Mathf.Clamp(BuildReloadSpeed, -1f, 0.2f);
		BuildRange = Mathf.Clamp(BuildRange, -1f, 0.2f);
		if (!(BuildAccuracy >= 0f))
		{
			BuildModeAccuracyValueText.text = string.Empty;
		}
		else
		{
			BuildModeAccuracyValueText.text = "+";
		}
		if (!(BuildReloadSpeed >= 0f))
		{
			BuildModeReloadSpeedValueText.text = string.Empty;
		}
		else
		{
			BuildModeReloadSpeedValueText.text = "+";
		}
		if (!(BuildRange >= 0f))
		{
			BuildModeRangeValueText.text = string.Empty;
		}
		else
		{
			BuildModeRangeValueText.text = "+";
		}
		BuildModeAccuracyValueText.material.color = new Color(1f - Mathf.Clamp(BuildAccuracy * 5f, 0f, 1f), 1f + Mathf.Clamp(BuildAccuracy * 5f, -1f, 0f), 0f, 0.95f);
		BuildModeReloadSpeedValueText.material.color = new Color(1f - Mathf.Clamp(BuildReloadSpeed * 5f, 0f, 1f), 1f + Mathf.Clamp(BuildReloadSpeed * 5f, -1f, 0f), 0f, 0.95f);
		BuildModeRangeValueText.material.color = new Color(1f - Mathf.Clamp(BuildRange * 5f, 0f, 1f), 1f + Mathf.Clamp(BuildRange * 5f, -1f, 0f), 0f, 0.95f);
		if (IsReset)
		{
			BuildModeAccuracyValueText.material.color = Color.white;
			BuildModeReloadSpeedValueText.material.color = Color.white;
			BuildModeRangeValueText.material.color = Color.white;
		}
		BuildModeAccuracyValueText.text += (BuildAccuracy * 100f).ToString("F0") + "%";
		BuildModeReloadSpeedValueText.text += (BuildReloadSpeed * 100f).ToString("F0") + "%";
		BuildModeRangeValueText.text += (BuildRange * 100f).ToString("F0") + "%";
	}

	public virtual IEnumerator FlashBuildText()
	{
		return new _0024FlashBuildText_0024728(this).GetEnumerator();
	}

	public virtual void ShowSettings()
	{
		Menu.Sho("Settings");
		StopCoroutine("SettingsSlider");
		if (!SystemInfo.supportsVibration)
		{
			SettingsVibration.gameObject.SetActive(false);
		}
		if (Gyro.UseGyro)
		{
			SettingsGyroscopeText.text = Loc.L("Gyroscope");
			SettingsSensitivityButton.gameObject.SetActive(false);
			SettingsSensitivityBar.gameObject.SetActive(false);
			SettingsSensitivityText.gameObject.SetActive(false);
		}
		else
		{
			SettingsGyroscopeText.text = Loc.L("NoGyroscope");
			SettingsSensitivityButton.gameObject.SetActive(true);
			SettingsSensitivityBar.gameObject.SetActive(true);
			SettingsSensitivityText.gameObject.SetActive(true);
		}
		if (Guns.UseVibration)
		{
			SettingsVibrationText.text = Loc.L("Vibration");
		}
		else
		{
			SettingsVibrationText.text = Loc.L("NoVibration");
		}
		float num = -16.5f * Settings.Scale + (Gyro.SwipeSensitivity - 1f) * 90f * Settings.Scale;
		Rect pixelInset = SettingsSensitivityButton.pixelInset;
		float num3 = (pixelInset.x = num);
		Rect rect2 = (SettingsSensitivityButton.pixelInset = pixelInset);
		StartCoroutine("SettingsSlider");
	}

	public virtual IEnumerator SettingsSlider()
	{
		return new _0024SettingsSlider_0024734(this).GetEnumerator();
	}

	public virtual void ShowSaves()
	{
		Menu.Sho("Saves");
		for (int i = default(int); i < 6; i++)
		{
			SavesBoxes[i].color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			SavesSlots[i].material.color = Menu.Colors[0].Col;
			SavesDeletes[i].gameObject.SetActive(false);
			if (i > 0)
			{
				GameObject gameObject = Menu.Get("SavesLockBadge" + i.ToString()).gameObject;
				if (!Settings.IsPro)
				{
					if (!IsBuildMode || Menus.Unlocked("SaveSlot" + i.ToString()))
					{
						gameObject.SetActive(false);
					}
					else
					{
						gameObject.SetActive(true);
						SavesBoxes[i].color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
						SavesSlots[i].material.color = new Color(0.2f, 0.2f, 0.2f);
					}
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
			if (!UsingSaveSlot(i))
			{
				SavesTypes[i].texture = null;
				SavesNames[i].text = string.Empty;
				SavesDates[i].text = string.Empty;
				SavesSlots[i].text = Loc.L("Gun") + " " + (i + 1).ToString();
				if (!IsBuildMode)
				{
					SavesBoxes[i].color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
					SavesSlots[i].material.color = new Color(0.2f, 0.2f, 0.2f);
				}
			}
			else
			{
				SavesTypes[i].texture = BlockSets[Saver.GetInt("SlotSet" + i.ToString())].InventoryGUIs[3];
				SavesNames[i].text = Saver.Get("SlotName" + i.ToString());
				DateTime date = Saver.GetDate("SlotDate" + i.ToString());
				SavesDates[i].text = date.ToString("MM/dd/yyyy");
				SavesSlots[i].text = string.Empty;
				if (IsBuildMode)
				{
					SavesDeletes[i].gameObject.SetActive(true);
				}
			}
		}
	}

	public virtual void ShowGrids()
	{
		Menu.Sho("Grids");
		for (int i = 1; i < 5; i++)
		{
			GameObject gameObject = Menu.Get("GridsLockBadge" + i.ToString()).gameObject;
			GUITexture component = Menu.Get("GridsBox" + i.ToString()).GetComponent<GUITexture>();
			if (Menus.Unlocked("Grid" + i.ToString()))
			{
				gameObject.SetActive(false);
				component.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			}
			else
			{
				gameObject.SetActive(true);
				component.color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
			}
		}
	}

	public virtual IEnumerator ShowSets()
	{
		return new _0024ShowSets_0024743(this).GetEnumerator();
	}

	public virtual void ShowModes()
	{
		Menu.Sho("Modes");
		string[] array = new string[5];
		int num = Menu.Level();
		bool boolean = Saver.GetBoolean("ProPack");
		Menu.Get("ModesLevelPrevious").GetComponent<GUIText>().text = num.ToString();
		Menu.Get("ModesLevelNext").GetComponent<GUIText>().text = (num + 1).ToString();
		float num2 = Menu.Progress() * 228.5f * Settings.Scale;
		Rect pixelInset = Menu.Get("ModesFill").GetComponent<GUITexture>().pixelInset;
		float num4 = (pixelInset.width = num2);
		Rect rect2 = (Menu.Get("ModesFill").GetComponent<GUITexture>().pixelInset = pixelInset);
		for (int i = default(int); i < Extensions.get_length((System.Array)ModeRequirements); i++)
		{
			if (num >= ModeRequirements[i] || boolean || Saver.GetBoolean("AllLevels"))
			{
				Menu.Get("Modes" + i.ToString()).GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
				array[i % 5] = array[i % 5] + "\n";
			}
			else
			{
				Menu.Get("Modes" + i.ToString()).GetComponent<GUITexture>().color = new Color(0.1f, 0.1f, 0.1f, 0.4f);
				array[i % 5] = array[i % 5] + (ModeRequirements[i].ToString() + "\n");
			}
		}
		for (int j = default(int); j < 5; j++)
		{
			Menu.Get("ModesRequirements" + j.ToString()).GetComponent<GUIText>().text = array[j];
		}
		if (!Settings.IsPro)
		{
			if (Saver.GetBoolean("AllLevels") || Saver.GetBoolean("ProPack") || num >= ModeRequirements[Extensions.get_length((System.Array)ModeRequirements) - 1])
			{
				ModesAllLevels.gameObject.SetActive(false);
				return;
			}
			ModesAllLevelsPrice.text = Menu.PurchasableItemCost("alllevels");
			ModesAllLevels.gameObject.SetActive(true);
		}
		else
		{
			ModesAllLevels.gameObject.SetActive(false);
		}
	}

	public virtual void ShowMatch()
	{
		Menu.Sho("Match");
		if (Menus.RealtimeMultiplayer())
		{
			MatchInvite.gameObject.SetActive(true);
			float num = -62.5f * Settings.Scale;
			Rect pixelInset = MatchQuick.pixelInset;
			float num3 = (pixelInset.x = num);
			Rect rect2 = (MatchQuick.pixelInset = pixelInset);
			float x = 2.5f * Settings.Scale;
			Vector2 pixelOffset = MatchQuickText.pixelOffset;
			float num4 = (pixelOffset.x = x);
			Vector2 vector2 = (MatchQuickText.pixelOffset = pixelOffset);
			float num5 = 90.5f * Settings.Scale;
			Rect pixelInset2 = MatchPractice.pixelInset;
			float num7 = (pixelInset2.x = num5);
			Rect rect4 = (MatchPractice.pixelInset = pixelInset2);
			float x2 = 144.5f * Settings.Scale;
			Vector2 pixelOffset2 = MatchPracticeText.pixelOffset;
			float num8 = (pixelOffset2.x = x2);
			Vector2 vector4 = (MatchPracticeText.pixelOffset = pixelOffset2);
		}
		else
		{
			MatchInvite.gameObject.SetActive(false);
			float num9 = -150f * Settings.Scale;
			Rect pixelInset3 = MatchQuick.pixelInset;
			float num11 = (pixelInset3.x = num9);
			Rect rect6 = (MatchQuick.pixelInset = pixelInset3);
			float x3 = -85f * Settings.Scale;
			Vector2 pixelOffset3 = MatchQuickText.pixelOffset;
			float num12 = (pixelOffset3.x = x3);
			Vector2 vector6 = (MatchQuickText.pixelOffset = pixelOffset3);
			float num13 = 25f * Settings.Scale;
			Rect pixelInset4 = MatchPractice.pixelInset;
			float num15 = (pixelInset4.x = num13);
			Rect rect8 = (MatchPractice.pixelInset = pixelInset4);
			float x4 = 79f * Settings.Scale;
			Vector2 pixelOffset4 = MatchPracticeText.pixelOffset;
			float num16 = (pixelOffset4.x = x4);
			Vector2 vector8 = (MatchPracticeText.pixelOffset = pixelOffset4);
		}
	}

	public virtual void ShowUser()
	{
		int num = Mathf.Clamp(Saver.GetInt("totalLosses"), 1, 99999999);
		int num2 = (int)((float)Saver.GetInt("totalWins") * 1f / (float)num * 100f);
		int num3 = Mathf.Clamp(Saver.GetInt("ShotsFired"), 1, 99999999);
		int num4 = (int)((float)Saver.GetInt("Makes") * 1f / (float)num3 * 100f);
		Menu.Sho("User");
		Menu.Get("UserStatValuesLeft").GetComponent<GUIText>().text = Saver.GetInt("totalWins").ToString() + "\n" + num2.ToString() + "\n" + Saver.GetInt("BlocksDestroyed").ToString();
		Menu.Get("UserStatValuesRight").GetComponent<GUIText>().text = Saver.GetInt("PrizesEarned").ToString() + "\n" + Saver.GetInt("friends").ToString() + "\n" + num4.ToString();
		int num5 = Menu.Level();
		Menu.Get("UserLevelPrevious").GetComponent<GUIText>().text = num5.ToString();
		Menu.Get("UserLevelNext").GetComponent<GUIText>().text = (num5 + 1).ToString();
		float num6 = Menu.Progress() * 228.5f * Settings.Scale;
		Rect pixelInset = Menu.Get("UserFill").GetComponent<GUITexture>().pixelInset;
		float num8 = (pixelInset.width = num6);
		Rect rect2 = (Menu.Get("UserFill").GetComponent<GUITexture>().pixelInset = pixelInset);
	}

	public virtual void PopularityRetrieved()
	{
		Menu.Achievement("friend1", (float)Saver.GetInt("NumberOfFriendsWhoEnteredYourCode") * 1f / 1f * 100f);
	}

	public virtual void SaveGunData(string TheName)
	{
		string text = string.Empty;
		Dictionary<Vector3, int>.Enumerator enumerator = BlockDictionary.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (text != string.Empty)
			{
				text += ",,";
			}
			text += enumerator.Current.Key.x.ToString() + ",";
			text += enumerator.Current.Key.y.ToString() + ",";
			text += enumerator.Current.Key.z.ToString() + ",";
			text += enumerator.Current.Value.ToString();
		}
		Saver.Set("SlotName" + SelectedSaveSlot.ToString(), TheName);
		Saver.Set("SlotDate" + SelectedSaveSlot.ToString(), DateTime.Now.ToString());
		Saver.Set("SlotData" + SelectedSaveSlot.ToString(), text);
		Saver.Set("SlotSet" + SelectedSaveSlot.ToString(), SelectedSet);
		Saver.Set("SlotGrid" + SelectedSaveSlot.ToString(), SelectedGrid);
		Saver.Save();
		Menu.Hid("SaveGun");
	}

	public virtual void EraseGunData(int Slot)
	{
		Saver.Set("SlotName" + Slot.ToString(), string.Empty);
		Saver.Set("SlotDate" + Slot.ToString(), string.Empty);
		Saver.Set("SlotData" + Slot.ToString(), string.Empty);
		Saver.Set("SlotSet" + Slot.ToString(), string.Empty);
		Saver.Set("SlotGrid" + Slot.ToString(), string.Empty);
		Saver.Save();
		ShowSaves();
	}

	public virtual void AddCurrency(int Change)
	{
		int @int = Saver.GetInt("Currency");
		@int += Change;
		Saver.Set("Currency", @int);
		TickerText.text = @int.ToString();
		Saver.Save();
	}

	public virtual IEnumerator PrizeCounter()
	{
		return new _0024PrizeCounter_0024758(this).GetEnumerator();
	}

	public virtual void UnlockCompleted(string Instance)
	{
		switch (Instance)
		{
		case "SaveSlot1":
		case "SaveSlot2":
		case "SaveSlot3":
		case "SaveSlot4":
		case "SaveSlot5":
			ShowSaves();
			break;
		case "Grid1":
		case "Grid2":
		case "Grid3":
		case "Grid4":
			ShowGrids();
			break;
		case "Set1":
		case "Set2":
		case "Set3":
		case "Set4":
		case "Set5":
			StartCoroutine(ShowSets());
			break;
		}
	}

	public virtual IEnumerator MoveToRange()
	{
		return new _0024MoveToRange_0024764(this).GetEnumerator();
	}

	public virtual IEnumerator MoveToShare()
	{
		return new _0024MoveToShare_0024768(this).GetEnumerator();
	}

	public virtual IEnumerator ShareRoom()
	{
		return new _0024ShareRoom_0024771(this).GetEnumerator();
	}

	public virtual IEnumerator MoveToChance(int Type)
	{
		return new _0024MoveToChance_0024781(Type, this).GetEnumerator();
	}

	public virtual IEnumerator ChanceSpin(int Type)
	{
		return new _0024ChanceSpin_0024786(Type, this).GetEnumerator();
	}

	public virtual IEnumerator ChanceHitCube()
	{
		return new _0024ChanceHitCube_0024795(this).GetEnumerator();
	}

	public virtual IEnumerator ChanceZoomIn()
	{
		return new _0024ChanceZoomIn_0024801(this).GetEnumerator();
	}

	public virtual void ChanceAddSeeds(int Amount)
	{
		Saver.Set("Seeds", Saver.GetInt("Seeds") + Amount);
		Saver.Save();
		CoinAudio.volume = 0.6f;
		CoinAudio.Play();
	}

	public virtual IEnumerator ChanceCoinPayout(int Amount)
	{
		return new _0024ChanceCoinPayout_0024804(Amount, this).GetEnumerator();
	}

	public virtual IEnumerator MoveToFarm()
	{
		return new _0024MoveToFarm_0024811(this).GetEnumerator();
	}

	public virtual IEnumerator FarmEquip(int Mode)
	{
		return new _0024FarmEquip_0024814(Mode, this).GetEnumerator();
	}

	public virtual IEnumerator FarmHovering()
	{
		return new _0024FarmHovering_0024820(this).GetEnumerator();
	}

	public virtual IEnumerator FarmTouch()
	{
		return new _0024FarmTouch_0024829(this).GetEnumerator();
	}

	public virtual void FarmBuildFromPlantArray()
	{
		if (!(Saver.Get("FarmData") != string.Empty))
		{
			return;
		}
		UnityScript.Lang.Array array = Saver.Get("FarmData").Split("~"[0]);
		for (int i = default(int); i < array.length; i++)
		{
			UnityScript.Lang.Array array2 = array[i].ToString().Split(","[0]);
			object obj = array2[0];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			int num = (int)Mathf.Round(float.Parse((string)obj));
			object obj2 = array2[1];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			int num2 = (int)Mathf.Round(float.Parse((string)obj2));
			Vector2 location = new Vector2(num, num2);
			object obj3 = array2[2];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			FarmPlant(location, DateTime.Parse((string)obj3));
		}
	}

	public virtual void FarmPlant(Vector2 Location, DateTime Birthday)
	{
		Plant plant = new Plant();
		plant.Birthday = Birthday;
		FarmDictionary[new Vector2(Location.x, Location.y)] = plant;
		GameObject gameObject = UnityEngine.Object.Instantiate(PlantPrefabs[0], Vector3.zero, Quaternion.identity);
		gameObject.transform.parent = FarmGroundParent.transform;
		gameObject.transform.localPosition = new Vector3(Location.x, 0.5f, Location.y);
		string text = Birthday.ToString("ss");
		if (text.Length == 2)
		{
			text = text.Substring(1, text.Length - 1);
		}
		gameObject.transform.localScale = Vector3.one * (0.15f - float.Parse(text) / 250f);
		plant.Obj = gameObject;
		plant.Filter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
		if (float.Parse(Birthday.ToString("ss")) % 2f == 0f)
		{
			gameObject.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}
		else
		{
			gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(gameObject.transform);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			transform.eulerAngles = new Vector3(0f, -5f, 0f);
			UnityRuntimeServices.Update(enumerator, transform);
		}
		FarmUpdateSaveData();
	}

	public virtual IEnumerator FarmDestroyPlant(GameObject HitObject)
	{
		return new _0024FarmDestroyPlant_0024838(HitObject, this).GetEnumerator();
	}

	public virtual void FarmUpdateSaveData()
	{
		string text = null;
		Dictionary<Vector2, Plant>.Enumerator enumerator = FarmDictionary.GetEnumerator();
		int num = default(int);
		while (enumerator.MoveNext())
		{
			if (num != 0)
			{
				text += "~";
			}
			text += enumerator.Current.Key.x.ToString("F0") + "," + enumerator.Current.Key.y.ToString("F0") + "," + enumerator.Current.Value.Birthday.ToString();
			num++;
		}
		Saver.Set("FarmData", text);
		Saver.Save();
	}

	public virtual IEnumerator FarmGrowPlants()
	{
		return new _0024FarmGrowPlants_0024845(this).GetEnumerator();
	}

	public virtual IEnumerator TakeScreen()
	{
		return new _0024TakeScreen_0024856(this).GetEnumerator();
	}

	public virtual void LoginSubmitted()
	{
		ShowMatch();
	}

	public virtual void CompletePurchase(string message)
	{
		if (!Settings.IsPro)
		{
			switch (message)
			{
			case "gold1":
			case "gold1managed":
				AddCurrency(200);
				break;
			case "gold2":
			case "gold2managed":
				AddCurrency(3000);
				break;
			case "gold3":
			case "gold3managed":
				AddCurrency(10000);
				break;
			case "alllevels":
				Saver.Set("AllLevels", true);
				ReturnToMain();
				Saver.Save();
				break;
			case "propack":
			case "propackmanaged":
				Saver.Set("UnlockedSaveSlot1", true);
				Saver.Set("UnlockedSaveSlot2", true);
				Saver.Set("UnlockedSaveSlot3", true);
				Saver.Set("UnlockedSaveSlot4", true);
				Saver.Set("UnlockedSaveSlot5", true);
				Saver.Set("UnlockedGrid1", true);
				Saver.Set("UnlockedGrid2", true);
				Saver.Set("UnlockedGrid3", true);
				Saver.Set("UnlockedGrid4", true);
				Saver.Set("UnlockedSet1", true);
				Saver.Set("UnlockedSet2", true);
				Saver.Set("UnlockedSet3", true);
				Saver.Set("UnlockedSet4", true);
				Saver.Set("UnlockedSet5", true);
				Saver.Set("ProPack", true);
				InventoryBaseAmounts[0] = 2;
				ReturnToMain();
				Saver.Save();
				break;
			}
		}
		else
		{
			switch (message)
			{
			case "gold1":
			case "gold1managed":
				AddCurrency(300);
				break;
			case "gold2":
			case "gold2managed":
				AddCurrency(1000);
				break;
			case "gold3":
			case "gold3managed":
				AddCurrency(7000);
				break;
			case "alllevels":
				Saver.Set("AllLevels", true);
				ReturnToMain();
				Saver.Save();
				break;
			}
		}
		if (message == "doubler")
		{
			Saver.Set("Doubler", true);
			ReturnToMain();
			Saver.Save();
		}
	}

	public virtual void ShowStore()
	{
		Menu.Sho("Store");
		if (!Settings.IsPro)
		{
			StoreBackdrop.gameObject.SetActive(true);
			StoreBackdropPro.gameObject.SetActive(false);
			for (int i = default(int); i < Extensions.get_length((System.Array)StoreProPackTexts); i++)
			{
				StoreProPackTexts[i].gameObject.SetActive(true);
			}
			StoreRemoveAdsText.gameObject.SetActive(true);
			StoreAllLevels.gameObject.SetActive(false);
			StoreAllLevelsText.gameObject.SetActive(false);
		}
		else
		{
			StoreBackdrop.gameObject.SetActive(false);
			StoreBackdropPro.gameObject.SetActive(true);
			for (int i = 0; i < Extensions.get_length((System.Array)StoreProPackTexts); i++)
			{
				StoreProPackTexts[i].gameObject.SetActive(false);
			}
			StoreRemoveAdsText.gameObject.SetActive(false);
			StoreAllLevels.gameObject.SetActive(true);
			StoreAllLevelsText.gameObject.SetActive(true);
		}
		if (Saver.GetBoolean("Doubler"))
		{
			float a = 0.2f;
			Color color = StoreDoubler.color;
			float num = (color.a = a);
			Color color3 = (StoreDoubler.color = color);
			StorePriceDoubler.enabled = false;
			StoreRemoveAdsText.gameObject.SetActive(false);
		}
		if (Menus.AndroidStorefront() == AndroidStorefronts.Google)
		{
			StorePrice0.text = Menu.PurchasableItemCost("gold1managed");
			StorePrice1.text = Menu.PurchasableItemCost("gold2managed");
			StorePrice2.text = Menu.PurchasableItemCost("gold3managed");
		}
		else
		{
			StorePrice0.text = Menu.PurchasableItemCost("gold1");
			StorePrice1.text = Menu.PurchasableItemCost("gold2");
			StorePrice2.text = Menu.PurchasableItemCost("gold3");
		}
		StorePriceDoubler.text = Menu.PurchasableItemCost("doubler");
		if (!Settings.IsPro)
		{
			if (Menus.AndroidStorefront() == AndroidStorefronts.Google)
			{
				StorePriceProPack.text = Menu.PurchasableItemCost("propackmanaged");
			}
			else
			{
				StorePriceProPack.text = Menu.PurchasableItemCost("propack");
			}
			StorePriceAllLevels.enabled = false;
			if (Saver.GetBoolean("ProPack"))
			{
				StoreProPack.enabled = true;
				StorePriceProPack.enabled = false;
				StoreRemoveAdsText.gameObject.SetActive(false);
			}
		}
		else
		{
			StorePriceAllLevels.text = Menu.PurchasableItemCost("alllevels");
			StorePriceProPack.enabled = false;
			if (Saver.GetBoolean("AllLevels"))
			{
				StoreProPack.enabled = true;
				StorePriceAllLevels.enabled = false;
				StoreRemoveAdsText.gameObject.SetActive(false);
			}
		}
	}

	public virtual void PrizeClaimed(bool FirstPrize)
	{
		if (FirstPrize)
		{
			if (!Settings.IsPro)
			{
				AddCurrency(25);
			}
			else
			{
				AddCurrency(40);
			}
		}
		else if (!Settings.IsPro)
		{
			if (Saver.GetBoolean("Doubler"))
			{
				AddCurrency(UnityEngine.Random.Range(20, 30));
			}
			else
			{
				AddCurrency(UnityEngine.Random.Range(10, 15));
			}
		}
		else if (Saver.GetBoolean("Doubler"))
		{
			AddCurrency(UnityEngine.Random.Range(30, 40));
		}
		else
		{
			AddCurrency(UnityEngine.Random.Range(15, 20));
		}
		CoinAudio.Play();
	}

	public virtual void FlurryStatsGenerate()
	{
		Menus.FlurryStats = "Currency," + Saver.GetInt("Currency").ToString() + ",Wins," + Saver.GetInt("totalWins").ToString() + ",Losses," + Saver.GetInt("totalLosses").ToString() + ",Practices," + Saver.GetInt("totalPractices").ToString();
	}

	public virtual void ButtonWasPressed(string Name)
	{
		if (Menu.Begins("Popup"))
		{
			if (Name == "PopupTwo1")
			{
				if (Menus.PopupInstance == "DeleteSlot")
				{
					EraseGunData(SlotToDelete);
				}
				else if (Menus.PopupInstance == "Paused")
				{
					StartCoroutine(Menu.LoadGame(0));
				}
				else if (Menus.PopupInstance == "ChanceNotEnough")
				{
					ShowStore();
				}
			}
			else if (!(Name == "PopupTwo2"))
			{
			}
			return;
		}
		if (Name == "TickerImage")
		{
			ShowStore();
			return;
		}
		if (Menu.Begins("Store"))
		{
			switch (Name)
			{
			case "StoreBack":
				Menu.Hid("Store");
				return;
			case "StorePrize":
				if (!(TimeUntilNextPrize > 0f))
				{
					StartCoroutine(Menu.ClaimPrizeHit(true));
				}
				return;
			case "StoreOverlay0":
				if (Menus.AndroidStorefront() == AndroidStorefronts.Google)
				{
					Menu.Purchase("gold1managed");
				}
				else
				{
					Menu.Purchase("gold1");
				}
				return;
			case "StoreOverlay1":
				if (Menus.AndroidStorefront() == AndroidStorefronts.Google)
				{
					Menu.Purchase("gold2managed");
				}
				else
				{
					Menu.Purchase("gold2");
				}
				return;
			case "StoreOverlay2":
				if (Menus.AndroidStorefront() == AndroidStorefronts.Google)
				{
					Menu.Purchase("gold3managed");
				}
				else
				{
					Menu.Purchase("gold3");
				}
				return;
			case "StoreDoubler":
				if (!Saver.GetBoolean("Doubler"))
				{
					Menu.Purchase("doubler");
					return;
				}
				break;
			}
			if (!Settings.IsPro && Name == "StoreProPack" && !Saver.GetBoolean("ProPack"))
			{
				if (Menus.AndroidStorefront() == AndroidStorefronts.Google)
				{
					Menu.Purchase("propackmanaged");
				}
				else
				{
					Menu.Purchase("propack");
				}
			}
			else if (Settings.IsPro && Name == "StoreProPack" && !Saver.GetBoolean("AllLevels"))
			{
				Menu.Purchase("alllevels");
			}
			else if (Name == "StoreRestore")
			{
				Menu.Restore();
			}
			return;
		}
		if (Menu.Begins("Logo"))
		{
			switch (Name)
			{
			case "LogoControl":
				LogoControl.SetActive(false);
				StopCoroutine("ShowLogo");
				StartCoroutine("ShowLogoFast");
				break;
			case "LogoImage":
			case "LogoImagePro":
				Menu.Hid("LogoImage");
				Menu.Hid("LogoImagePro");
				Menu.FirstAd();
				ReturnToMain();
				break;
			}
			return;
		}
		if (Menu.Begins("Main"))
		{
			switch (Name)
			{
			case "MainBuild":
				Menu.Hid("Main");
				IsBuildMode = true;
				IsShareMode = false;
				ShowSaves();
				break;
			case "MainUse":
				if (UsingAnySaveSlot())
				{
					Menu.Hid("Main");
					IsBuildMode = false;
					IsShareMode = false;
					ShowSaves();
				}
				break;
			case "MainTrophy":
				Menu.Hid("Main");
				ShowUser();
				break;
			case "MainShare":
				if (UsingAnySaveSlot())
				{
					Menu.Hid("Main");
					Menu.Hid("Ticker");
					IsBuildMode = false;
					IsShareMode = true;
					ShowSaves();
				}
				break;
			case "MainMore":
				Saver.Set("SeenApps" + SeenAppsVersion, true);
				StopCoroutine("FlashMoreAppsBadge");
				MainMoreBadge.enabled = false;
				Saver.Save();
				Menu.Hid("Main");
				Menu.Hid("Ticker");
				Menu.Sho("More");
				break;
			case "MainSettings":
				Menu.Hid("Main");
				ShowSettings();
				break;
			}
			return;
		}
		if (Menu.Begins("Saves"))
		{
			if (Name == "SavesBack")
			{
				ReturnToMain();
			}
			else if (Menu.Begins("SavesBox"))
			{
				int num = Menu.Trim();
				if (IsBuildMode)
				{
					if (num > 0 && !Settings.IsPro && !Menus.Unlocked("SaveSlot" + num.ToString()))
					{
						Menus.UnlockTry("SaveSlot" + num.ToString());
						return;
					}
					SelectedSaveSlot = num;
					Menu.Hid("Saves");
					if (!UsingSaveSlot(SelectedSaveSlot))
					{
						ShowGrids();
						BuildModeToggle(Saver.GetBoolean("ExpertMode"));
					}
					else
					{
						BuildFromSave();
					}
				}
				else if (IsShareMode)
				{
					if (UsingSaveSlot(num))
					{
						SelectedSaveSlot = num;
						Menu.Hid("Saves");
						StartCoroutine(MoveToShare());
					}
				}
				else if (UsingSaveSlot(num))
				{
					SelectedSaveSlot = num;
					Menu.Hid("Saves");
					Menu.Sho("Play");
				}
			}
			else if (Menu.Begins("SavesDelete"))
			{
				SlotToDelete = Menu.Trim();
				Menu.Popup2(string.Empty, Loc.L("UnlockSure"), "DeleteSlot");
			}
			return;
		}
		if (Menu.Begins("Play"))
		{
			switch (Name)
			{
			case "PlayPlay":
				ShowModes();
				break;
			case "PlayFarm":
				StartCoroutine(MoveToFarm());
				break;
			case "PlayChance":
				Menu.Sho("Chance");
				break;
			case "PlayBack":
				ShowSaves();
				break;
			}
			Menu.Hid("Play");
			return;
		}
		if (Menu.Begins("Farm"))
		{
			if (Name == "FarmSeed" && Saver.GetInt("Seeds") != 0)
			{
				StartCoroutine(FarmEquip(0));
			}
			if (Name == "FarmGun")
			{
				StartCoroutine(FarmEquip(1));
			}
			else if (Name == "FarmBack")
			{
				StopCoroutine("FarmTouch");
				StopCoroutine("FarmGrowPlants");
				StartCoroutine(Menu.LoadGame(0));
			}
			return;
		}
		if (Menu.Begins("Chance"))
		{
			switch (Name)
			{
			case "Chance0":
				if (Saver.GetInt("Currency") >= 2)
				{
					StartCoroutine(MoveToChance(0));
					AddCurrency(-2);
					Menu.Hid("Chance");
				}
				else
				{
					Menu.Popup2(Loc.L("NotEnough"), Loc.L("GetMoreNow"), "ChanceNotEnough");
				}
				break;
			case "Chance1":
				if (Saver.GetInt("Currency") >= 4)
				{
					StartCoroutine(MoveToChance(1));
					AddCurrency(-4);
					Menu.Hid("Chance");
				}
				else
				{
					Menu.Popup2(Loc.L("NotEnough"), Loc.L("GetMoreNow"), "ChanceNotEnough");
				}
				break;
			case "Chance2":
				if (Saver.GetInt("Currency") >= 30)
				{
					StartCoroutine(MoveToChance(2));
					AddCurrency(-30);
					Menu.Hid("Chance");
				}
				else
				{
					Menu.Popup2(Loc.L("NotEnough"), Loc.L("GetMoreNow"), "ChanceNotEnough");
				}
				break;
			}
			if (Name == "ChanceBack")
			{
				if (IsChance)
				{
					StopCoroutine("ChanceZoomIn");
					StartCoroutine(Menu.LoadGame(0));
					Menu.MenuReturnAd();
				}
				else
				{
					Menu.Sho("Play");
				}
				Menu.Hid("Chance");
			}
			return;
		}
		if (Menu.Begins("Modes"))
		{
			if (Name == "ModesBack")
			{
				Menu.Hid("Modes");
				Menu.Sho("Play");
			}
			else if (Name == "ModesAllLevels")
			{
				Menu.Purchase("alllevels");
			}
			else if (Menu.Level() >= ModeRequirements[Menu.Trim()] || Saver.GetBoolean("ProPack") || Saver.GetBoolean("AllLevels") || Debug.isDebugBuild)
			{
				SelectedMode = Menu.Trim() + 1;
				Menus.NextMode = SelectedMode;
				ShowMatch();
				Menu.Hid("Modes");
			}
			return;
		}
		if (Menu.Begins("Grids"))
		{
			if (Name == "GridsBack")
			{
				Menu.Hid("Grids");
				ShowSaves();
			}
			else if (Menu.Begins("GridsBox"))
			{
				SelectedGrid = Menu.Trim();
				if (SelectedGrid > 0 && !Menus.Unlocked("Grid" + SelectedGrid.ToString()))
				{
					Menus.UnlockTry("Grid" + SelectedGrid.ToString());
					return;
				}
				Menu.Hid("Grids");
				StartCoroutine(ShowSets());
			}
			return;
		}
		if (Menu.Begins("Sets"))
		{
			switch (Name)
			{
			case "SetsBack":
				Menu.Hid("Sets");
				ShowGrids();
				break;
			case "SetsArrowLeft":
				if (SelectedSet != 0)
				{
					SelectedSet--;
					StartCoroutine(ShowSets());
				}
				break;
			case "SetsArrowRight":
				if (SelectedSet != 5)
				{
					SelectedSet++;
					StartCoroutine(ShowSets());
				}
				break;
			case "SetsSelect":
				if (SelectedSet > 0 && !Menus.Unlocked("Set" + SelectedSet.ToString()))
				{
					Menus.UnlockTry("Set" + SelectedSet.ToString());
					break;
				}
				Menu.Hid("Sets");
				SetupInventory();
				SetupGrid();
				break;
			}
			return;
		}
		if (Menu.Begins("Match"))
		{
			if (Name == "MatchBack")
			{
				ShowModes();
				Menu.Hid("Match");
			}
			switch (Name)
			{
			case "MatchQuick":
				if (Menus.PlayerName != string.Empty)
				{
					StartCoroutine(Menu.FindMatch(SelectedMode));
				}
				else
				{
					Menu.Login();
				}
				break;
			case "MatchInvite":
				Menu.GameCenterInviteFriend(SelectedMode);
				break;
			case "MatchPractice":
				if (Menus.PlayerName != string.Empty)
				{
					Menu.Get("NameFontOpp").GetComponent<GUIText>().text = string.Empty;
					Menus.NextMode = -SelectedMode;
					StartCoroutine(MoveToRange());
				}
				else
				{
					Menu.Login();
				}
				break;
			}
			return;
		}
		if (Menu.Begins("Inventory"))
		{
			if (Menu.Begins("InventoryItem"))
			{
				StartCoroutine(SwitchType(Menu.Trim()));
				return;
			}
			switch (Name)
			{
			case "InventoryX":
				StartCoroutine(SwitchType(9));
				break;
			case "InventoryMode":
				ShowBuildMode();
				break;
			case "InventoryBack":
				if (MadeChangesThisSession)
				{
					Menu.Sho("SaveOrTrash");
					if (UsingSaveSlot(SelectedSaveSlot))
					{
						Menu.Sho("SaveOrTrashChanges");
					}
					else
					{
						Menu.Hid("SaveOrTrashChanges");
					}
				}
				else
				{
					ReturnToMain();
				}
				break;
			}
			return;
		}
		if (Menu.Begins("BuildMode"))
		{
			if (Name == "BuildModeBack")
			{
				Menu.Hid("BuildMode");
			}
			else if (Name == "BuildModeButton")
			{
				BuildModeToggle(!Saver.GetBoolean("ExpertMode"));
			}
			return;
		}
		if (Menu.Begins("User"))
		{
			switch (Name)
			{
			case "UserFriends":
				Menu.Hid("User");
				Menu.Sho("Friend");
				Menu.Get("FriendMyBoxCode").GetComponent<GUIText>().text = Saver.Get("code");
				break;
			case "UserLeaderboards":
				Menu.ShowLeaderboards();
				break;
			case "UserBack":
				ReturnToMain();
				break;
			}
			return;
		}
		if (Name == "FriendBack")
		{
			Menu.Hid("Friend");
			ShowUser();
			return;
		}
		if (Name == "LeaderboardsExit")
		{
			Menu.Sho("Ticker");
			ShowUser();
			return;
		}
		if (Menu.Begins("SaveGun"))
		{
			switch (Name)
			{
			case "SaveGunNameBox":
				if (Settings.Language != "English")
				{
					string text = Saver.Get("SlotName" + SelectedSaveSlot.ToString());
					if (text == string.Empty)
					{
						text = "Gun" + " " + (SelectedSaveSlot + 1).ToString();
					}
					Menu.Get("SaveGunName").GetComponent<GUIText>().text = text;
				}
				Menu.KeyboardEntry(Menu.Get("SaveGunName").GetComponent<GUIText>(), 16, Menu.KeyboardLetNumSpace);
				break;
			case "SaveGunSubmit":
			{
				GUIText component = Menu.Get("SaveGunName").GetComponent<GUIText>();
				if (Extensions.get_length(component.text) < 4)
				{
					Menu.Get("SaveGunError").GetComponent<GUIText>().text = Loc.L("LengthWarning_1") + " 4 " + Loc.L("LengthWarning_2");
					break;
				}
				SaveGunData(component.text);
				ReturnToMain();
				break;
			}
			case "SaveGunBack":
				Menu.Hid("SaveGun");
				break;
			}
			return;
		}
		if (Menu.Begins("SaveOrTrash"))
		{
			switch (Name)
			{
			case "SaveOrTrashSave":
			{
				Menu.Hid("SaveOrTrash");
				if (InventoryBaseAmounts[0] == InventoryAmounts[0])
				{
					StopCoroutine("InventoryFlashBarrel");
					StartCoroutine("InventoryFlashBarrel");
					break;
				}
				Menu.Sho("SaveGun");
				Menu.Get("SaveGunError").GetComponent<GUIText>().text = string.Empty;
				string text = Saver.Get("SlotName" + SelectedSaveSlot.ToString());
				if (text == string.Empty)
				{
					text = "Gun" + " " + (SelectedSaveSlot + 1).ToString();
				}
				Menu.Get("SaveGunName").GetComponent<GUIText>().text = text;
				break;
			}
			case "SaveOrTrashTrash":
				StopCoroutine("InventoryFlashBarrel");
				ReturnToMain();
				break;
			case "SaveOrTrashBack":
				Menu.Hid("SaveOrTrash");
				break;
			}
			return;
		}
		if (Menu.Begins("Share"))
		{
			if (Name == "ShareBack")
			{
				StartCoroutine(Menu.LoadGame(0));
			}
			else if (Name == "ShareTake")
			{
				StartCoroutine(TakeScreen());
			}
			return;
		}
		if (Menu.Begins("SaveShare"))
		{
			switch (Name)
			{
			case "SaveShareEmail":
			{
				string lhs = "My GunCrafter Photo";
				string lhs2 = Loc.L("FriendLast") + "\n";
				lhs2 += "iPhone, iPad, and iPodTouch: https://itunes.apple.com/app/id" + App.AppleID;
				PlayerPrefs.SetString("ShareEmail", lhs + "::" + lhs2 + "::" + Application.persistentDataPath + "/Screen.png");
				Menu.HidRec("SaveShare");
				Menu.Sho("Share");
				break;
			}
			case "SaveSharePhotos":
				PlayerPrefs.SetString("SavePic", Application.persistentDataPath + "/Screen.png");
				break;
			case "SaveShareCancel":
				Menu.HidRec("SaveShare");
				Menu.Sho("Share");
				break;
			}
			return;
		}
		if (Menu.Begins("Settings"))
		{
			if (!Gyro.UseGyro)
			{
				Gyro.AdjustSwipeSensitivity((SettingsSensitivityButton.pixelInset.x + 16.5f * Settings.Scale) / (90f * Settings.Scale) + 1f);
			}
			switch (Name)
			{
			case "SettingsGyroscope":
				if (SystemInfo.supportsGyroscope)
				{
					Gyro.ToggleGyro(!Gyro.UseGyro);
					ShowSettings();
				}
				break;
			case "SettingsVibration":
				Guns.ToggleVibration(!Guns.UseVibration);
				ShowSettings();
				break;
			case "SettingsBack":
				Menu.Hid("Settings");
				StopCoroutine("SettingsSlider");
				ReturnToMain();
				break;
			}
			return;
		}
		switch (Name)
		{
		case "MoreBack":
			Menu.Hid("More");
			ReturnToMain();
			return;
		case "GameOverTryAgain":
			Menu.Hid("GameOver");
			StartCoroutine(Menu.LoadGame(Menus.GameMode));
			return;
		case "GameOverQuit":
			if (OfferVideoGold)
			{
				ShowVideoGold();
			}
			else
			{
				StartCoroutine(Menu.LoadGame(0));
			}
			return;
		}
		if (Menu.Begins("VideoGold"))
		{
			if (Name == "VideoGoldButtonYes")
			{
				VideoGoldMenu.SetActive(false);
				Menus.FoundOpponent = false;
				Menu.RunVideo();
			}
			else if (Name == "VideoGoldButtonNo")
			{
				Menu.DeclinedVideo();
				StartCoroutine(Menu.LoadGame(0));
			}
		}
		else if (Name == "PauseButton")
		{
			Menu.Popup2(Loc.L("Paused"), Loc.L("PausedWaiting"), "Paused", Loc.L("Quit"), Loc.L("Resume"));
		}
	}

	public virtual void Main()
	{
	}
}
