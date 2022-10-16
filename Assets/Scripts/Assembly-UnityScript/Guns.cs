using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Guns : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OpponentFire_0024861 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024AllData_0024862;

			internal Vector3 _0024RayDestination_0024863;

			internal GameObject _0024NewBullet_0024864;

			internal string _0024RayDestinationString_0024865;

			internal Guns _0024self__0024866;

			public _0024(string RayDestinationString, Guns self_)
			{
				_0024RayDestinationString_0024865 = RayDestinationString;
				_0024self__0024866 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (!AllowOpponentFire)
					{
						result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
						break;
					}
					_0024AllData_0024862 = _0024RayDestinationString_0024865.Split(","[0]);
					object obj = _0024AllData_0024862[0];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					float x = float.Parse((string)obj);
					object obj2 = _0024AllData_0024862[1];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					float y = float.Parse((string)obj2);
					object obj3 = _0024AllData_0024862[2];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					_0024RayDestination_0024863 = new Vector3(x, y, float.Parse((string)obj3));
					if (!(Time.time - LastOpponentFire <= 0.15f))
					{
						OppGunSource.Play();
					}
					if (!RuntimeServices.EqualityOperator(OpponentMuzzleFlash, null) && Extensions.get_length((System.Array)OpponentMuzzleFlash) > 0 && OpponentMuzzleFlash[0] != null)
					{
						_0024self__0024866.StopCoroutine("OpponentMuzzleFlashAction");
						_0024self__0024866.StartCoroutine("OpponentMuzzleFlashAction");
					}
					LastOpponentFire = Time.time;
					_0024NewBullet_0024864 = UnityEngine.Object.Instantiate(_0024self__0024866.Bullet, OpponentBulletPosition, Quaternion.identity);
					_0024self__0024866.ShootRay = new Ray(_0024NewBullet_0024864.transform.position, _0024RayDestination_0024863 - _0024NewBullet_0024864.transform.position);
					if (!Physics.Raycast(_0024self__0024866.ShootRay, out _0024self__0024866.RayHit, 1000f))
					{
						_0024self__0024866.RayHit.point = _0024self__0024866.ShootRay.GetPoint(_0024self__0024866.NoColliderTravelDist);
					}
					_0024self__0024866.StartCoroutine(_0024self__0024866.MoveBullet(_0024NewBullet_0024864, _0024self__0024866.RayHit, false));
					YieldDefault(1);
					goto case 1;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024RayDestinationString_0024867;

		internal Guns _0024self__0024868;

		public _0024OpponentFire_0024861(string RayDestinationString, Guns self_)
		{
			_0024RayDestinationString_0024867 = RayDestinationString;
			_0024self__0024868 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024RayDestinationString_0024867, _0024self__0024868);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MuzzleFlashAction_0024869 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Color _0024OriginalColor_0024870;

			internal int _0024FrameCount_0024871;

			internal Transform _0024Flash_0024872;

			internal Transform _0024Flash_0024873;

			internal Transform _0024Flash_0024874;

			internal int _0024_0024225_0024875;

			internal Transform[] _0024_0024226_0024876;

			internal int _0024_0024227_0024877;

			internal int _0024_0024229_0024878;

			internal Transform[] _0024_0024230_0024879;

			internal int _0024_0024231_0024880;

			internal int _0024_0024233_0024881;

			internal Transform[] _0024_0024234_0024882;

			internal int _0024_0024235_0024883;

			internal Guns _0024self__0024884;

			public _0024(Guns self_)
			{
				_0024self__0024884 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024884.GunLight != null)
					{
						_0024self__0024884.GunLight.intensity = _0024self__0024884.GunLightIntensity + _0024self__0024884.GunLightFlashAmount;
					}
					else
					{
						_0024OriginalColor_0024870 = GunObject.GetComponent<Renderer>().sharedMaterial.color;
						GunObject.GetComponent<Renderer>().sharedMaterial.color = Color.white;
					}
					_0024FrameCount_0024871 = 0;
					_0024_0024225_0024875 = 0;
					_0024_0024226_0024876 = MuzzleFlash;
					for (_0024_0024227_0024877 = _0024_0024226_0024876.Length; _0024_0024225_0024875 < _0024_0024227_0024877; _0024_0024225_0024875++)
					{
						_0024_0024226_0024876[_0024_0024225_0024875].gameObject.GetComponent<Renderer>().enabled = true;
						_0024_0024226_0024876[_0024_0024225_0024875].Rotate(0f, 0f, UnityEngine.Random.Range(0, 360));
						_0024_0024226_0024876[_0024_0024225_0024875].localScale = new Vector3(1f, 1f, 1f) * UnityEngine.Random.Range(1f, 2f) * 20f * (AllGuns[CurrentGun].Accuracy / 2f + 0.5f) * _0024self__0024884.SizeScale;
					}
					goto case 2;
				case 2:
					if (_0024FrameCount_0024871 < 3)
					{
						_0024FrameCount_0024871++;
						_0024_0024229_0024878 = 0;
						_0024_0024230_0024879 = MuzzleFlash;
						for (_0024_0024231_0024880 = _0024_0024230_0024879.Length; _0024_0024229_0024878 < _0024_0024231_0024880; _0024_0024229_0024878++)
						{
							_0024_0024230_0024879[_0024_0024229_0024878].Rotate(0f, 0f, Time.deltaTime * 100f);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__0024884.GunLight != null)
					{
						_0024self__0024884.GunLight.intensity = _0024self__0024884.GunLightIntensity;
					}
					else
					{
						GunObject.GetComponent<Renderer>().sharedMaterial.color = _0024OriginalColor_0024870;
					}
					_0024_0024233_0024881 = 0;
					_0024_0024234_0024882 = MuzzleFlash;
					for (_0024_0024235_0024883 = _0024_0024234_0024882.Length; _0024_0024233_0024881 < _0024_0024235_0024883; _0024_0024233_0024881++)
					{
						_0024_0024234_0024882[_0024_0024233_0024881].gameObject.GetComponent<Renderer>().enabled = false;
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

		internal Guns _0024self__0024885;

		public _0024MuzzleFlashAction_0024869(Guns self_)
		{
			_0024self__0024885 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024885);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OpponentMuzzleFlashAction_0024886 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024FrameCount_0024887;

			internal Transform _0024Flash_0024888;

			internal Transform _0024Flash_0024889;

			internal Transform _0024Flash_0024890;

			internal int _0024_0024237_0024891;

			internal Transform[] _0024_0024238_0024892;

			internal int _0024_0024239_0024893;

			internal int _0024_0024241_0024894;

			internal Transform[] _0024_0024242_0024895;

			internal int _0024_0024243_0024896;

			internal int _0024_0024245_0024897;

			internal Transform[] _0024_0024246_0024898;

			internal int _0024_0024247_0024899;

			internal Guns _0024self__0024900;

			public _0024(Guns self_)
			{
				_0024self__0024900 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024FrameCount_0024887 = 0;
					_0024_0024237_0024891 = 0;
					_0024_0024238_0024892 = OpponentMuzzleFlash;
					for (_0024_0024239_0024893 = _0024_0024238_0024892.Length; _0024_0024237_0024891 < _0024_0024239_0024893; _0024_0024237_0024891++)
					{
						_0024_0024238_0024892[_0024_0024237_0024891].gameObject.GetComponent<Renderer>().enabled = true;
						_0024_0024238_0024892[_0024_0024237_0024891].Rotate(0f, 0f, UnityEngine.Random.Range(0, 360));
						_0024_0024238_0024892[_0024_0024237_0024891].localScale = new Vector3(1f, 1f, 1f) * UnityEngine.Random.Range(1f, 2f) * 25f * _0024self__0024900.SizeScale;
					}
					goto case 2;
				case 2:
					if (_0024FrameCount_0024887 < 3)
					{
						_0024FrameCount_0024887++;
						_0024_0024241_0024894 = 0;
						_0024_0024242_0024895 = OpponentMuzzleFlash;
						for (_0024_0024243_0024896 = _0024_0024242_0024895.Length; _0024_0024241_0024894 < _0024_0024243_0024896; _0024_0024241_0024894++)
						{
							_0024_0024242_0024895[_0024_0024241_0024894].Rotate(0f, 0f, Time.deltaTime * 100f);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024245_0024897 = 0;
					_0024_0024246_0024898 = OpponentMuzzleFlash;
					for (_0024_0024247_0024899 = _0024_0024246_0024898.Length; _0024_0024245_0024897 < _0024_0024247_0024899; _0024_0024245_0024897++)
					{
						_0024_0024246_0024898[_0024_0024245_0024897].gameObject.GetComponent<Renderer>().enabled = false;
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

		internal Guns _0024self__0024901;

		public _0024OpponentMuzzleFlashAction_0024886(Guns self_)
		{
			_0024self__0024901 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024901);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MoveBullet_0024902 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 _0024Destination_0024903;

			internal Vector3 _0024StartingPoint_0024904;

			internal float _0024TheDistance_0024905;

			internal int _0024ModifiedBullet_0024906;

			internal GameObject _0024HitCollider_0024907;

			internal string _0024Tag_0024908;

			internal int _0024Layer_0024909;

			internal int _0024Check1_0024910;

			internal int _0024Check2_0024911;

			internal float _0024i_0024912;

			internal int _0024Check3_0024913;

			internal GameObject _0024Bullet_0024914;

			internal RaycastHit _0024RayInfo_0024915;

			internal bool _0024WasYou_0024916;

			internal Guns _0024self__0024917;

			public _0024(GameObject Bullet, RaycastHit RayInfo, bool WasYou, Guns self_)
			{
				_0024Bullet_0024914 = Bullet;
				_0024RayInfo_0024915 = RayInfo;
				_0024WasYou_0024916 = WasYou;
				_0024self__0024917 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024Destination_0024903 = _0024RayInfo_0024915.point;
					_0024StartingPoint_0024904 = _0024Bullet_0024914.transform.position;
					_0024TheDistance_0024905 = Vector3.Distance(_0024StartingPoint_0024904, _0024Destination_0024903);
					_0024ModifiedBullet_0024906 = default(int);
					BulletDecalArray[_0024self__0024917.CurrentBulletDecal].transform.parent = null;
					BulletDecalArray[_0024self__0024917.CurrentBulletDecal].transform.position = _0024Destination_0024903 + _0024RayInfo_0024915.normal * 0.01f;
					BulletDecalArray[_0024self__0024917.CurrentBulletDecal].transform.rotation = Quaternion.FromToRotation(Vector3.up, _0024RayInfo_0024915.normal);
					if (_0024RayInfo_0024915.collider == null)
					{
						BulletDecalArray[_0024self__0024917.CurrentBulletDecal].transform.LookAt(_0024self__0024917.transform.position);
					}
					if (_0024RayInfo_0024915.collider != null)
					{
						_0024HitCollider_0024907 = _0024RayInfo_0024915.collider.gameObject;
						_0024Tag_0024908 = _0024HitCollider_0024907.tag;
						_0024Layer_0024909 = _0024HitCollider_0024907.layer;
						for (_0024Check1_0024910 = default(int); _0024Check1_0024910 < _0024self__0024917.LayersToDestroyCollider.Length; _0024Check1_0024910++)
						{
							if (_0024Layer_0024909 == _0024self__0024917.LayersToDestroyCollider[_0024Check1_0024910])
							{
								_0024HitCollider_0024907.GetComponent<Collider>().enabled = false;
								break;
							}
						}
						for (_0024Check2_0024911 = default(int); _0024Check2_0024911 < _0024self__0024917.LayersToAttachDecal.Length; _0024Check2_0024911++)
						{
							if (_0024Layer_0024909 == _0024self__0024917.LayersToAttachDecal[_0024Check2_0024911])
							{
								BulletDecalArray[_0024self__0024917.CurrentBulletDecal].transform.parent = _0024RayInfo_0024915.collider.gameObject.transform;
								break;
							}
						}
					}
					_0024ModifiedBullet_0024906 = _0024self__0024917.CurrentBulletDecal;
					if (_0024self__0024917.CurrentBulletDecal == _0024self__0024917.BulletDecalArrayLength - 1)
					{
						_0024self__0024917.CurrentBulletDecal = 0;
					}
					else
					{
						_0024self__0024917.CurrentBulletDecal++;
					}
					_0024i_0024912 = 0f;
					goto IL_032c;
				case 2:
					_0024i_0024912 += _0024self__0024917.BulletSpeed * Time.deltaTime / _0024TheDistance_0024905;
					goto IL_032c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_032c:
					if (_0024i_0024912 < 1f)
					{
						_0024Bullet_0024914.transform.position = Vector3.Lerp(_0024StartingPoint_0024904, _0024Destination_0024903, _0024i_0024912);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024Bullet_0024914);
					BulletDecalArray[_0024ModifiedBullet_0024906].SetActive(true);
					for (_0024Check3_0024913 = default(int); _0024Check3_0024913 < _0024self__0024917.LayersToHideDecal.Length; _0024Check3_0024913++)
					{
						if (_0024Layer_0024909 == _0024self__0024917.LayersToHideDecal[_0024Check3_0024913])
						{
							BulletDecalArray[_0024ModifiedBullet_0024906].SetActive(false);
							break;
						}
					}
					if (_0024WasYou_0024916 && Settings.Quality >= _0024self__0024917.MinQualityForSpark)
					{
						_0024self__0024917.Sparks[_0024self__0024917.CurrentSpark].SetActive(false);
						_0024self__0024917.Sparks[_0024self__0024917.CurrentSpark].transform.position = _0024Destination_0024903 + _0024RayInfo_0024915.normal * 0.01f;
						_0024self__0024917.Sparks[_0024self__0024917.CurrentSpark].transform.rotation = Quaternion.LookRotation(_0024RayInfo_0024915.normal);
						_0024self__0024917.Sparks[_0024self__0024917.CurrentSpark].SetActive(true);
						_0024self__0024917.CurrentSpark++;
						if (_0024self__0024917.CurrentSpark > Extensions.get_length((System.Array)_0024self__0024917.Sparks) - 1)
						{
							_0024self__0024917.CurrentSpark = 0;
						}
					}
					if (_0024Tag_0024908 == "Glass")
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.GlassSounds[UnityEngine.Random.Range(0, _0024self__0024917.GlassSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 60f);
					}
					else if (_0024Tag_0024908 == "Wood")
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.WoodSounds[UnityEngine.Random.Range(0, _0024self__0024917.WoodSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 20f);
					}
					else if (_0024Tag_0024908 == "Metal")
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.MetalSounds[UnityEngine.Random.Range(0, _0024self__0024917.MetalSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 40f);
					}
					else if (_0024Tag_0024908 == "Body")
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.HitSounds[UnityEngine.Random.Range(0, _0024self__0024917.HitSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 80f);
					}
					else if (_0024Tag_0024908 == "Splat")
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.SplatSounds[UnityEngine.Random.Range(0, _0024self__0024917.SplatSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 40f);
					}
					else if (_0024Tag_0024908 == "Sand")
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.SandSounds[UnityEngine.Random.Range(0, _0024self__0024917.SandSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 80f);
					}
					else
					{
						AudioSource.PlayClipAtPoint(_0024self__0024917.WallSounds[UnityEngine.Random.Range(0, _0024self__0024917.WallSounds.Length)], _0024self__0024917.transform.position + (_0024self__0024917.transform.position - _0024Destination_0024903) / 40f);
					}
					if (_0024RayInfo_0024915.collider != null)
					{
						BulletDecalArray[_0024ModifiedBullet_0024906].transform.Rotate(new Vector3(-90f, 0f, 0f));
						BulletDecalArray[_0024ModifiedBullet_0024906].transform.Rotate(new Vector3(0f, 0f, UnityEngine.Random.Range(0, 360)));
					}
					else if (_0024self__0024917.FadeDecalOnNull)
					{
						_0024self__0024917.StartCoroutine("FadeDecal", BulletDecalArray[_0024ModifiedBullet_0024906]);
					}
					_0024self__0024917.SendMessage("GunsHit", new BulletInfo(_0024WasYou_0024916, _0024RayInfo_0024915));
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024Bullet_0024918;

		internal RaycastHit _0024RayInfo_0024919;

		internal bool _0024WasYou_0024920;

		internal Guns _0024self__0024921;

		public _0024MoveBullet_0024902(GameObject Bullet, RaycastHit RayInfo, bool WasYou, Guns self_)
		{
			_0024Bullet_0024918 = Bullet;
			_0024RayInfo_0024919 = RayInfo;
			_0024WasYou_0024920 = WasYou;
			_0024self__0024921 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Bullet_0024918, _0024RayInfo_0024919, _0024WasYou_0024920, _0024self__0024921);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeDecal_0024922 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024Trans_0024923;

			internal float _0024_0024413_0024924;

			internal Color _0024_0024414_0024925;

			internal GameObject _0024TheDecal_0024926;

			internal Guns _0024self__0024927;

			public _0024(GameObject TheDecal, Guns self_)
			{
				_0024TheDecal_0024926 = TheDecal;
				_0024self__0024927 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024Trans_0024923 = 1f;
					goto case 2;
				case 2:
					if (_0024Trans_0024923 > 0f)
					{
						_0024Trans_0024923 -= 2f * Time.deltaTime;
						float num = (_0024_0024413_0024924 = _0024Trans_0024923);
						Color color = (_0024_0024414_0024925 = _0024TheDecal_0024926.GetComponent<Renderer>().material.color);
						float num2 = (_0024_0024414_0024925.a = _0024_0024413_0024924);
						Color color3 = (_0024TheDecal_0024926.GetComponent<Renderer>().material.color = _0024_0024414_0024925);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024TheDecal_0024926.GetComponent<Renderer>().material);
					_0024TheDecal_0024926.GetComponent<Renderer>().material = ((Guns)_0024self__0024927.GetComponent(typeof(Guns))).OriginalDecalMat;
					_0024TheDecal_0024926.SetActive(false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024TheDecal_0024928;

		internal Guns _0024self__0024929;

		public _0024FadeDecal_0024922(GameObject TheDecal, Guns self_)
		{
			_0024TheDecal_0024928 = TheDecal;
			_0024self__0024929 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024TheDecal_0024928, _0024self__0024929);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GunBounce_0024930 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Guns _0024self__0024931;

			public _0024(Guns self_)
			{
				_0024self__0024931 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024931.CrosshairDrift += (1f - AllGuns[CurrentGun].Accuracy) * 15f;
					goto case 2;
				case 2:
					if (GunShotBounce < 0.09f)
					{
						GunShotBounce += (0.19f - GunShotBounce) / 2f * Time.deltaTime * 15f;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (GunShotBounce > 0.02f)
					{
						GunShotBounce += (0f - GunShotBounce) / 2f;
						result = (YieldDefault(3) ? 1 : 0);
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

		internal Guns _0024self__0024932;

		public _0024GunBounce_0024930(Guns self_)
		{
			_0024self__0024932 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024932);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Reload_0024933 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024_0024415_0024934;

			internal Color _0024_0024416_0024935;

			internal Guns _0024self__0024936;

			public _0024(Guns self_)
			{
				_0024self__0024936 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (AmmoRemaining < AllGuns[CurrentGun].MaxAmmo)
					{
						YourGunSource.PlayOneShot(AllGuns[CurrentGun].Reload, _0024self__0024936.GunVolume);
						_0024self__0024936.IsReloading = true;
						_0024self__0024936.StopCoroutine("ShowReloadHelp");
						_0024self__0024936.ReloadHelp.gameObject.SetActive(false);
						_0024self__0024936.ReloadTilt.gameObject.SetActive(false);
						float num = (_0024_0024415_0024934 = 0.2f);
						Color color = (_0024_0024416_0024935 = _0024self__0024936.ReloadButton.color);
						float num2 = (_0024_0024416_0024935.a = _0024_0024415_0024934);
						Color color3 = (_0024self__0024936.ReloadButton.color = _0024_0024416_0024935);
						_0024self__0024936.StopCoroutine("ReturnReloadButton");
						result = (Yield(2, _0024self__0024936.StartCoroutine("ReturnReloadButton")) ? 1 : 0);
						break;
					}
					YourGunSource.PlayOneShot(_0024self__0024936.NoAmmo, 0.9f);
					goto IL_017b;
				case 2:
					AmmoRemaining = AllGuns[CurrentGun].MaxAmmo;
					_0024self__0024936.AmmoFont.text = AllGuns[CurrentGun].MaxAmmo.ToString();
					goto IL_017b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_017b:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Guns _0024self__0024937;

		public _0024Reload_0024933(Guns self_)
		{
			_0024self__0024937 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__0024937);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReturnReloadButton_0024938 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024ReturnSpeed_0024939;

			internal int _0024_0024417_0024940;

			internal Rect _0024_0024418_0024941;

			internal Guns _0024self__0024942;

			public _0024(Guns self_)
			{
				_0024self__0024942 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024ReturnSpeed_0024939 = 500;
					if (_0024self__0024942.IsReloading)
					{
						_0024ReturnSpeed_0024939 = (int)(80f + AllGuns[CurrentGun].ReloadSpeed * 300f);
					}
					_0024self__0024942.ReloadButtonPosition = (int)_0024self__0024942.ReloadButton.pixelInset.y;
					goto case 2;
				case 2:
					if (_0024self__0024942.ReloadButtonPosition < _0024self__0024942.ReloadButtonReturnPosition)
					{
						_0024self__0024942.ReloadButtonPosition = (int)((float)_0024self__0024942.ReloadButtonPosition + (float)_0024ReturnSpeed_0024939 * Time.deltaTime * Settings.Scale);
						_0024self__0024942.ReloadButtonPosition = Mathf.Clamp(_0024self__0024942.ReloadButtonPosition, -999, _0024self__0024942.ReloadButtonReturnPosition);
						if (!_0024self__0024942.IsReloading)
						{
							_0024self__0024942.WeaponReloadOffset = (float)(_0024self__0024942.ReloadButtonPosition - _0024self__0024942.ReloadButtonReturnPosition) / Settings.Scale;
						}
						int num = (_0024_0024417_0024940 = _0024self__0024942.ReloadButtonPosition);
						Rect rect = (_0024_0024418_0024941 = _0024self__0024942.ReloadButton.pixelInset);
						float num3 = (_0024_0024418_0024941.y = _0024_0024417_0024940);
						Rect rect3 = (_0024self__0024942.ReloadButton.pixelInset = _0024_0024418_0024941);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__0024942.IsReloading)
					{
						_0024self__0024942.IsReloading = false;
						goto case 3;
					}
					goto IL_020d;
				case 3:
					if (_0024self__0024942.WeaponReloadOffset < -0.01f)
					{
						_0024self__0024942.WeaponReloadOffset = Mathf.Clamp(_0024self__0024942.WeaponReloadOffset + 100f * Time.deltaTime * Settings.Scale, -100f, 0f);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_020d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_020d:
					_0024self__0024942.Menu.Sho("Crosshair");
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Guns _0024self__0024943;

		public _0024ReturnReloadButton_0024938(Guns self_)
		{
			_0024self__0024943 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024943);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FadeReloadHUD_0024944 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024CurrentColor_0024945;

			internal float _0024_0024419_0024946;

			internal Color _0024_0024420_0024947;

			internal float _0024Target_0024948;

			internal Guns _0024self__0024949;

			public _0024(float Target, Guns self_)
			{
				_0024Target_0024948 = Target;
				_0024self__0024949 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024CurrentColor_0024945 = _0024self__0024949.ReloadButton.color.a;
					goto case 2;
				case 2:
					if (Mathf.Abs(_0024CurrentColor_0024945 - _0024Target_0024948) > 0.001f)
					{
						_0024CurrentColor_0024945 = Mathf.Lerp(_0024CurrentColor_0024945, _0024Target_0024948, Time.deltaTime * 12f);
						float num = (_0024_0024419_0024946 = _0024CurrentColor_0024945);
						Color color = (_0024_0024420_0024947 = _0024self__0024949.ReloadButton.color);
						float num2 = (_0024_0024420_0024947.a = _0024_0024419_0024946);
						Color color3 = (_0024self__0024949.ReloadButton.color = _0024_0024420_0024947);
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

		internal float _0024Target_0024950;

		internal Guns _0024self__0024951;

		public _0024FadeReloadHUD_0024944(float Target, Guns self_)
		{
			_0024Target_0024950 = Target;
			_0024self__0024951 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Target_0024950, _0024self__0024951);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowReloadHelp_0024952 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024_0024421_0024953;

			internal Rect _0024_0024422_0024954;

			internal float _0024_0024423_0024955;

			internal Color _0024_0024424_0024956;

			internal float _0024_0024425_0024957;

			internal Color _0024_0024426_0024958;

			internal int _0024_0024427_0024959;

			internal Rect _0024_0024428_0024960;

			internal float _0024_0024429_0024961;

			internal Color _0024_0024430_0024962;

			internal float _0024_0024431_0024963;

			internal Color _0024_0024432_0024964;

			internal float _0024_0024433_0024965;

			internal Rect _0024_0024434_0024966;

			internal float _0024_0024435_0024967;

			internal Color _0024_0024436_0024968;

			internal float _0024_0024437_0024969;

			internal Color _0024_0024438_0024970;

			internal Guns _0024self__0024971;

			public _0024(Guns self_)
			{
				_0024self__0024971 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
				{
					int num = (_0024_0024421_0024953 = _0024self__0024971.ReloadHelpReturnPosition);
					Rect rect = (_0024_0024422_0024954 = _0024self__0024971.ReloadHelp.pixelInset);
					float num3 = (_0024_0024422_0024954.y = _0024_0024421_0024953);
					Rect rect3 = (_0024self__0024971.ReloadHelp.pixelInset = _0024_0024422_0024954);
					goto case 5;
				}
				case 3:
					if (!(_0024self__0024971.ReloadTilt.color.a <= 0f) && !TiltedDown)
					{
						float num6 = (_0024_0024425_0024957 = _0024self__0024971.ReloadTilt.color.a - Time.deltaTime * 0.3f);
						Color color4 = (_0024_0024426_0024958 = _0024self__0024971.ReloadTilt.color);
						float num7 = (_0024_0024426_0024958.a = _0024_0024425_0024957);
						Color color6 = (_0024self__0024971.ReloadTilt.color = _0024_0024426_0024958);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_01f3;
				case 4:
					if (!(_0024self__0024971.ReloadHelp.color.a <= 0f) && TiltedDown)
					{
						float num8 = (_0024_0024433_0024965 = _0024self__0024971.ReloadHelp.pixelInset.y - 70f * Time.deltaTime * Settings.Scale);
						Rect rect4 = (_0024_0024434_0024966 = _0024self__0024971.ReloadHelp.pixelInset);
						float num10 = (_0024_0024434_0024966.y = _0024_0024433_0024965);
						Rect rect6 = (_0024self__0024971.ReloadHelp.pixelInset = _0024_0024434_0024966);
						float num11 = (_0024_0024435_0024967 = _0024self__0024971.ReloadHelp.color.a - Time.deltaTime * 0.5f);
						Color color7 = (_0024_0024436_0024968 = _0024self__0024971.ReloadHelp.color);
						float num12 = (_0024_0024436_0024968.a = _0024_0024435_0024967);
						Color color9 = (_0024self__0024971.ReloadHelp.color = _0024_0024436_0024968);
						if (!_0024self__0024971.ReloadTouch)
						{
							float num13 = (_0024_0024437_0024969 = _0024self__0024971.ReloadButton.color.a - Time.deltaTime * 0.3f);
							Color color10 = (_0024_0024438_0024970 = _0024self__0024971.ReloadButton.color);
							float num14 = (_0024_0024438_0024970.a = _0024_0024437_0024969);
							Color color12 = (_0024self__0024971.ReloadButton.color = _0024_0024438_0024970);
						}
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__0024971.ReloadHelp.gameObject.SetActive(false);
					goto IL_0551;
				case 5:
					if (AmmoRemaining == 0)
					{
						if (Gyro.UseGyro && !TiltedDown && _0024self__0024971.UseTilt)
						{
							_0024self__0024971.ReloadTilt.gameObject.SetActive(true);
							float num4 = (_0024_0024423_0024955 = 0.5f);
							Color color = (_0024_0024424_0024956 = _0024self__0024971.ReloadTilt.color);
							float num5 = (_0024_0024424_0024956.a = _0024_0024423_0024955);
							Color color3 = (_0024self__0024971.ReloadTilt.color = _0024_0024424_0024956);
							goto case 3;
						}
						goto IL_01f3;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0551:
					_0024self__0024971.ReloadHelp.gameObject.SetActive(false);
					result = (Yield(5, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
					IL_01f3:
					_0024self__0024971.ReloadTilt.gameObject.SetActive(false);
					if (!Gyro.UseGyro || TiltedDown)
					{
						_0024self__0024971.StopCoroutine("FadeReloadHUD");
						_0024self__0024971.ReloadHelp.gameObject.SetActive(true);
						int num15 = (_0024_0024427_0024959 = _0024self__0024971.ReloadHelpReturnPosition);
						Rect rect7 = (_0024_0024428_0024960 = _0024self__0024971.ReloadHelp.pixelInset);
						float num17 = (_0024_0024428_0024960.y = _0024_0024427_0024959);
						Rect rect9 = (_0024self__0024971.ReloadHelp.pixelInset = _0024_0024428_0024960);
						float num18 = (_0024_0024429_0024961 = 0.5f);
						Color color13 = (_0024_0024430_0024962 = _0024self__0024971.ReloadHelp.color);
						float num19 = (_0024_0024430_0024962.a = _0024_0024429_0024961);
						Color color15 = (_0024self__0024971.ReloadHelp.color = _0024_0024430_0024962);
						float num20 = (_0024_0024431_0024963 = 0.5f);
						Color color16 = (_0024_0024432_0024964 = _0024self__0024971.ReloadButton.color);
						float num21 = (_0024_0024432_0024964.a = _0024_0024431_0024963);
						Color color18 = (_0024self__0024971.ReloadButton.color = _0024_0024432_0024964);
						goto case 4;
					}
					goto IL_0551;
				}
				return (byte)result != 0;
			}
		}

		internal Guns _0024self__0024972;

		public _0024ShowReloadHelp_0024952(Guns self_)
		{
			_0024self__0024972 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024972);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowPoints_0024973 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GUIText _0024PointFont_0024974;

			internal GUIText _0024PointFontShadow_0024975;

			internal int _0024StartingPoint_0024976;

			internal float _0024Counter_0024977;

			internal float _0024_0024439_0024978;

			internal Color _0024_0024440_0024979;

			internal float _0024_0024441_0024980;

			internal Color _0024_0024442_0024981;

			internal float _0024_0024443_0024982;

			internal Vector2 _0024_0024444_0024983;

			internal float _0024_0024445_0024984;

			internal Vector2 _0024_0024446_0024985;

			internal float _0024_0024447_0024986;

			internal Color _0024_0024448_0024987;

			internal float _0024_0024449_0024988;

			internal Color _0024_0024450_0024989;

			internal int _0024Points_0024990;

			public _0024(int Points)
			{
				_0024Points_0024990 = Points;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024PointFont_0024974 = null;
					_0024PointFontShadow_0024975 = null;
					PointFontTracker = !PointFontTracker;
					if (!PointFontTracker)
					{
						_0024PointFont_0024974 = PointFont1;
						_0024PointFontShadow_0024975 = PointFontShadow1;
					}
					else
					{
						_0024PointFont_0024974 = PointFont2;
						_0024PointFontShadow_0024975 = PointFontShadow2;
					}
					_0024PointFont_0024974.enabled = true;
					_0024PointFontShadow_0024975.enabled = true;
					float num = (_0024_0024439_0024978 = 1f);
					Color color = (_0024_0024440_0024979 = _0024PointFont_0024974.material.color);
					float num2 = (_0024_0024440_0024979.a = _0024_0024439_0024978);
					Color color3 = (_0024PointFont_0024974.material.color = _0024_0024440_0024979);
					float num3 = (_0024_0024441_0024980 = 1f);
					Color color4 = (_0024_0024442_0024981 = _0024PointFontShadow_0024975.material.color);
					float num4 = (_0024_0024442_0024981.a = _0024_0024441_0024980);
					Color color6 = (_0024PointFontShadow_0024975.material.color = _0024_0024442_0024981);
					_0024PointFont_0024974.text = _0024Points_0024990.ToString();
					_0024PointFontShadow_0024975.text = _0024Points_0024990.ToString();
					_0024StartingPoint_0024976 = (int)(50f * Settings.Scale);
					_0024Counter_0024977 = 0f;
					goto case 2;
				}
				case 2:
					if (_0024Counter_0024977 < 50f)
					{
						_0024Counter_0024977 += 100f * Time.deltaTime;
						float num5 = (_0024_0024443_0024982 = (float)_0024StartingPoint_0024976 + _0024Counter_0024977 * Settings.DPI / 150f);
						Vector2 vector = (_0024_0024444_0024983 = _0024PointFont_0024974.pixelOffset);
						float num6 = (_0024_0024444_0024983.y = _0024_0024443_0024982);
						Vector2 vector3 = (_0024PointFont_0024974.pixelOffset = _0024_0024444_0024983);
						float num7 = (_0024_0024445_0024984 = _0024PointFont_0024974.pixelOffset.y - 1f * Settings.Scale);
						Vector2 vector4 = (_0024_0024446_0024985 = _0024PointFontShadow_0024975.pixelOffset);
						float num8 = (_0024_0024446_0024985.y = _0024_0024445_0024984);
						Vector2 vector6 = (_0024PointFontShadow_0024975.pixelOffset = _0024_0024446_0024985);
						float num9 = (_0024_0024447_0024986 = 1f - _0024Counter_0024977 / 50f);
						Color color7 = (_0024_0024448_0024987 = _0024PointFont_0024974.material.color);
						float num10 = (_0024_0024448_0024987.a = _0024_0024447_0024986);
						Color color9 = (_0024PointFont_0024974.material.color = _0024_0024448_0024987);
						float num11 = (_0024_0024449_0024988 = _0024PointFont_0024974.material.color.a);
						Color color10 = (_0024_0024450_0024989 = _0024PointFontShadow_0024975.material.color);
						float num12 = (_0024_0024450_0024989.a = _0024_0024449_0024988);
						Color color12 = (_0024PointFontShadow_0024975.material.color = _0024_0024450_0024989);
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

		internal int _0024Points_0024991;

		public _0024ShowPoints_0024973(int Points)
		{
			_0024Points_0024991 = Points;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024Points_0024991);
		}
	}

	public float GunVolume;

	public bool FadeDecals;

	public int MinQualityForSpark;

	public float BulletDecalSize;

	public Light GunLight;

	public float GunLightFlashAmount;

	private float GunLightIntensity;

	public float BulletSpeed;

	public int NoColliderTravelDist;

	public bool FadeDecalOnNull;

	public int[] LayersToDestroyCollider;

	public int[] LayersToAttachDecal;

	public int[] LayersToHideDecal;

	public GameObject Bullet;

	public GameObject Spark;

	[NonSerialized]
	public static AudioSource YourGunSource;

	[NonSerialized]
	public static AudioSource OppGunSource;

	public AudioClip NoAmmo;

	public AudioClip[] GlassSounds;

	public AudioClip[] HitSounds;

	public AudioClip[] MetalSounds;

	public AudioClip[] WoodSounds;

	public AudioClip[] WallSounds;

	public AudioClip[] SplatSounds;

	public AudioClip[] SandSounds;

	[NonSerialized]
	public static Transform BulletDecalParent;

	public GameObject BulletDecal;

	[NonSerialized]
	public static GameObject[] BulletDecalArray;

	private int BulletDecalArrayLength;

	private int CurrentBulletDecal;

	private Material OriginalDecalMat;

	private GameObject[] Sparks;

	private int CurrentSpark;

	private GUITexture ReloadButton;

	private GUIText AmmoFont;

	private GUITexture ReloadHelp;

	private GUITexture ReloadTilt;

	private GUITexture CrosshairH1;

	private GUITexture CrosshairH2;

	private GUITexture CrosshairV1;

	private GUITexture CrosshairV2;

	[NonSerialized]
	public static GUIText PointFont1;

	[NonSerialized]
	public static GUIText PointFontShadow1;

	[NonSerialized]
	public static GUIText PointFont2;

	[NonSerialized]
	public static GUIText PointFontShadow2;

	[NonSerialized]
	public static bool PointFontTracker;

	public float MovementScale;

	public float SizeScale;

	public Vector3 GunChildOffset;

	public Gun[] Weapons;

	[NonSerialized]
	public static Gun[] AllGuns;

	[NonSerialized]
	public static GameObject Weapon;

	[NonSerialized]
	public static Transform[] MuzzleFlash;

	[NonSerialized]
	public static GameObject OpponentGun;

	[NonSerialized]
	public static Transform[] OpponentMuzzleFlash;

	[NonSerialized]
	public static GameObject GunObject;

	[NonSerialized]
	public static int AmmoRemaining;

	private float WeaponReloadOffset;

	private bool IsReloading;

	[NonSerialized]
	public static int CurrentGun = -1;

	[NonSerialized]
	public static float GunShotBounce = 0.01f;

	[NonSerialized]
	public static bool TiltedDown;

	public bool UseTilt;

	[NonSerialized]
	public static bool UseVibration = true;

	private float CrosshairDrift;

	[NonSerialized]
	public static bool AllowFireReload;

	[NonSerialized]
	public static bool AllowOpponentFire;

	[NonSerialized]
	public static float LastOpponentFire;

	private float GunLag;

	private float ScaleGunLag;

	[NonSerialized]
	public static Vector3 OpponentBulletPosition;

	[NonSerialized]
	public static Vector2 WeaponSway;

	private bool ReloadButtonActive;

	private bool ReloadTouch;

	private int ReloadPositionLastFrame;

	private int ReloadButtonReturnPosition;

	private int ReloadButtonPosition;

	private int ReloadHelpReturnPosition;

	private Ray ShootRay;

	private RaycastHit RayHit;

	private Menus Menu;

	[NonSerialized]
	public static Guns This;

	public Guns()
	{
		GunVolume = 0.9f;
		MinQualityForSpark = 4;
		BulletDecalSize = 1f;
		GunLightFlashAmount = 1.25f;
		BulletSpeed = 170f;
		NoColliderTravelDist = 500;
		BulletDecalArrayLength = 30;
		MovementScale = 1f;
		SizeScale = 1f;
		GunChildOffset = new Vector3(-0.15f, 0.02f, 1f);
		UseTilt = true;
		GunLag = 1f;
		ScaleGunLag = 1f;
	}

	public virtual void Awake()
	{
		Menu = (Menus)GetComponent(typeof(Menus));
		This = this;
		AllGuns = Weapons;
		YourGunSource = gameObject.AddComponent<AudioSource>();
		OppGunSource = gameObject.AddComponent<AudioSource>();
		OppGunSource.volume = 0.9f;
		if (PlayerPrefs.GetString("UseVibration") == string.Empty)
		{
			if (SystemInfo.supportsVibration)
			{
				PlayerPrefs.SetString("UseVibration", "true");
			}
			else
			{
				PlayerPrefs.SetString("UseVibration", "false");
			}
		}
		UseVibration = bool.Parse(PlayerPrefs.GetString("UseVibration"));
		ToggleVibration(UseVibration);
	}

	public static void ToggleVibration(bool ShouldUse)
	{
		if (ShouldUse)
		{
			UseVibration = true;
			PlayerPrefs.SetString("UseVibration", "true");
		}
		else
		{
			UseVibration = false;
			PlayerPrefs.SetString("UseVibration", "false");
		}
	}

	public virtual void Start()
	{
		ReloadButton = (GUITexture)Menu.Get("ReloadButton");
		AmmoFont = (GUIText)Menu.Get("AmmoFont");
		ReloadHelp = (GUITexture)Menu.Get("ReloadHelp");
		ReloadTilt = (GUITexture)Menu.Get("ReloadTilt");
		CrosshairH1 = (GUITexture)Menu.Get("CrosshairH1");
		CrosshairH2 = (GUITexture)Menu.Get("CrosshairH2");
		CrosshairV1 = (GUITexture)Menu.Get("CrosshairV1");
		CrosshairV2 = (GUITexture)Menu.Get("CrosshairV2");
		PointFont1 = (GUIText)Menu.Get("PointFont1");
		PointFontShadow1 = (GUIText)Menu.Get("PointFontShadow1");
		PointFont2 = (GUIText)Menu.Get("PointFont2");
		PointFontShadow2 = (GUIText)Menu.Get("PointFontShadow2");
		ReloadButtonReturnPosition = (int)ReloadButton.pixelInset.y;
		ReloadHelpReturnPosition = (int)ReloadHelp.pixelInset.y;
		ReloadButtonPosition = ReloadButtonReturnPosition;
		OriginalDecalMat = BulletDecal.GetComponent<Renderer>().sharedMaterial;
		BulletDecalParent = new GameObject("Decals").transform;
		BulletDecalArray = new GameObject[BulletDecalArrayLength];
		for (int i = 0; i < BulletDecalArrayLength; i++)
		{
			BulletDecalArray[i] = UnityEngine.Object.Instantiate(BulletDecal, new Vector3(0f, -500f, 0f), Quaternion.identity);
			BulletDecalArray[i].transform.parent = BulletDecalParent;
			float num = UnityEngine.Random.Range(0.06f, 0.12f) * 7f * BulletDecalSize;
			float x = BulletDecalArray[i].transform.localScale.x * num;
			Vector3 localScale = BulletDecalArray[i].transform.localScale;
			float num2 = (localScale.x = x);
			Vector3 vector2 = (BulletDecalArray[i].transform.localScale = localScale);
			float y = BulletDecalArray[i].transform.localScale.y * num;
			Vector3 localScale2 = BulletDecalArray[i].transform.localScale;
			float num3 = (localScale2.y = y);
			Vector3 vector4 = (BulletDecalArray[i].transform.localScale = localScale2);
			float z = BulletDecalArray[i].transform.localScale.z * num;
			Vector3 localScale3 = BulletDecalArray[i].transform.localScale;
			float num4 = (localScale3.z = z);
			Vector3 vector6 = (BulletDecalArray[i].transform.localScale = localScale3);
			BulletDecalArray[i].gameObject.SetActive(false);
			if (BulletDecalArray[i].GetComponent<Renderer>().material != OriginalDecalMat)
			{
				UnityEngine.Object.Destroy(BulletDecalArray[i].GetComponent<Renderer>().material);
				BulletDecalArray[i].GetComponent<Renderer>().material = OriginalDecalMat;
			}
		}
		Sparks = new GameObject[6];
		for (int j = default(int); j < Extensions.get_length((System.Array)Sparks); j++)
		{
			Sparks[j] = UnityEngine.Object.Instantiate(Spark, Vector3.zero, Quaternion.identity);
		}
	}

	public virtual void LateUpdate()
	{
		if (Weapon != null)
		{
			Weapon.transform.rotation = transform.rotation * Quaternion.Euler((0f - WeaponReloadOffset) / 1f + GunShotBounce * -40f, GunLag - transform.eulerAngles.y, 0f);
			Weapon.transform.localPosition = transform.position + new Vector3(Mathf.Sin(WeaponSway.y) * 0.015f * MovementScale + GunShotBounce * -0.5f * Mathf.Sin(transform.eulerAngles.y * ((float)Math.PI / 180f)) * MovementScale, Mathf.Sin(WeaponSway.x) * 0.015f * MovementScale, GunShotBounce * -1f * Mathf.Cos(transform.eulerAngles.y * ((float)Math.PI / 180f)) * MovementScale);
		}
	}

	public virtual void UpdateGun()
	{
		if (Weapon == null)
		{
			return;
		}
		WeaponSway.x += 1.2f * Time.deltaTime;
		WeaponSway.y += 0.8f * Time.deltaTime;
		GunLag = Mathf.LerpAngle(GunLag, transform.eulerAngles.y, 12f * Time.deltaTime / ScaleGunLag);
		Quaternion localRotation = transform.localRotation;
		ReloadTouch = false;
		bool flag = default(bool);
		int i = 0;
		CustomTouch[] touches = Menus.Touches;
		for (int length = touches.Length; i < length; i++)
		{
			if (!(touches[i].position.x <= (float)(Screen.width / 2)) && !(touches[i].position.y >= (float)Screen.height - 150f * Settings.Scale) && !ReloadButtonActive && !flag && !IsReloading && AllowFireReload && Menu.Began(touches[i]))
			{
				flag = true;
				Fire();
			}
			else
			{
				if (ReloadTouch || touches[i].position.x <= (float)Screen.width - 100f * Settings.Scale || (!TiltedDown && UseTilt) || IsReloading || !AllowFireReload)
				{
					continue;
				}
				ReloadTouch = true;
				if (!(touches[i].position.y <= (float)Screen.height - 120f * Settings.Scale) && Menu.Began(touches[i]))
				{
					ReloadButtonActive = true;
					StopCoroutine("FadeReloadHUD");
					Menu.Hid("Crosshair");
					float a = 0.4f;
					Color color = ReloadButton.color;
					float num = (color.a = a);
					Color color3 = (ReloadButton.color = color);
					ReloadPositionLastFrame = (int)touches[i].position.y;
					ReloadButtonPosition = (int)ReloadButton.pixelInset.y;
				}
				if (ReloadButtonActive)
				{
					ReloadButtonPosition = (int)((float)ReloadButtonPosition + (touches[i].position.y - (float)ReloadPositionLastFrame));
					ReloadPositionLastFrame = (int)touches[i].position.y;
					ReloadButtonPosition = (int)Mathf.Clamp(ReloadButtonPosition, (float)ReloadButtonReturnPosition - 45f * Settings.Scale, ReloadButtonReturnPosition);
					int reloadButtonPosition = ReloadButtonPosition;
					Rect pixelInset = ReloadButton.pixelInset;
					float num3 = (pixelInset.y = reloadButtonPosition);
					Rect rect2 = (ReloadButton.pixelInset = pixelInset);
					if (!((float)(ReloadButtonReturnPosition - ReloadButtonPosition) <= 44f * Settings.Scale))
					{
						StartCoroutine(Reload());
						ReloadTouch = false;
					}
					WeaponReloadOffset = Mathf.Lerp(WeaponReloadOffset, (float)(ReloadButtonPosition - ReloadButtonReturnPosition) / Settings.Scale, Time.deltaTime * 20f);
				}
			}
		}
		if (!ReloadTouch && ReloadButtonActive)
		{
			if (!IsReloading)
			{
				StopCoroutine("ReturnReloadButton");
				StartCoroutine("ReturnReloadButton");
			}
			ReloadButtonActive = false;
			float a2 = 0.2f;
			Color color4 = ReloadButton.color;
			float num4 = (color4.a = a2);
			Color color6 = (ReloadButton.color = color4);
		}
		((Gyro)GetComponent(typeof(Gyro))).UpdateGyro();
		if (!(transform.eulerAngles.x <= 40f) && !(transform.eulerAngles.x > 90f))
		{
			if (Gyro.UseGyro && !TiltedDown && UseTilt)
			{
				TiltedDown = true;
				StopCoroutine("FadeReloadHUD");
				StartCoroutine("FadeReloadHUD", 0.2f);
			}
			ScaleGunLag = Mathf.Abs((90f - transform.eulerAngles.x) / 40f) + 0.001f;
		}
		else
		{
			if (Gyro.UseGyro && TiltedDown && UseTilt)
			{
				TiltedDown = false;
				StopCoroutine("FadeReloadHUD");
				StartCoroutine("FadeReloadHUD", 0f);
			}
			ScaleGunLag = 1f;
		}
		CrosshairDrift = Mathf.Lerp(CrosshairDrift, Quaternion.Angle(localRotation, transform.localRotation) * 3f, Time.deltaTime * 5f);
		float num5 = -6f * Settings.Scale - CrosshairDrift * Settings.Scale - (1f - AllGuns[CurrentGun].Accuracy) * Settings.Scale * 25f;
		Rect pixelInset2 = CrosshairH1.pixelInset;
		float num7 = (pixelInset2.x = num5);
		Rect rect4 = (CrosshairH1.pixelInset = pixelInset2);
		float num8 = 1f * Settings.Scale + CrosshairDrift * Settings.Scale + (1f - AllGuns[CurrentGun].Accuracy) * Settings.Scale * 25f;
		Rect pixelInset3 = CrosshairH2.pixelInset;
		float num10 = (pixelInset3.x = num8);
		Rect rect6 = (CrosshairH2.pixelInset = pixelInset3);
		float num11 = 1f * Settings.Scale + CrosshairDrift * Settings.Scale + (1f - AllGuns[CurrentGun].Accuracy) * Settings.Scale * 25f;
		Rect pixelInset4 = CrosshairV1.pixelInset;
		float num13 = (pixelInset4.y = num11);
		Rect rect8 = (CrosshairV1.pixelInset = pixelInset4);
		float num14 = -6f * Settings.Scale - CrosshairDrift * Settings.Scale - (1f - AllGuns[CurrentGun].Accuracy) * Settings.Scale * 25f;
		Rect pixelInset5 = CrosshairV2.pixelInset;
		float num16 = (pixelInset5.y = num14);
		Rect rect10 = (CrosshairV2.pixelInset = pixelInset5);
	}

	public static void Equip(int GunNumber)
	{
		CurrentGun = GunNumber;
		PlayerPrefs.SetString("CurrentGun", CurrentGun.ToString());
		Weapon = UnityEngine.Object.Instantiate(AllGuns[CurrentGun].Held, This.transform.position, Quaternion.identity);
		Weapon.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
		int num = default(int);
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(Weapon.transform);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (transform.gameObject.name == "MuzzleFlash")
			{
				transform.transform.localPosition = transform.transform.localPosition + This.GunChildOffset;
				UnityRuntimeServices.Update(enumerator, transform);
				num++;
			}
			else
			{
				GunObject = transform.gameObject;
				UnityRuntimeServices.Update(enumerator, transform);
				transform.transform.localPosition = transform.transform.localPosition + This.GunChildOffset;
				UnityRuntimeServices.Update(enumerator, transform);
			}
		}
		MuzzleFlash = new Transform[num];
		num = 0;
		IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(Weapon.transform);
		while (enumerator2.MoveNext())
		{
			object obj2 = enumerator2.Current;
			if (!(obj2 is Transform))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
			}
			Transform transform2 = (Transform)obj2;
			if (transform2.gameObject.name == "MuzzleFlash")
			{
				MuzzleFlash[num] = transform2;
				UnityRuntimeServices.Update(enumerator2, transform2);
				num++;
			}
		}
	}

	public static void EquipOpponent(int Index)
	{
		OppGunSource.clip = AllGuns[Index].Fire;
	}

	public static void EquipOpponent(int Index, GameObject TheGun)
	{
		OppGunSource.clip = AllGuns[Index].Fire;
		OpponentGun = TheGun;
		int num = default(int);
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(OpponentGun.transform);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (transform.gameObject.name == "MuzzleFlash")
			{
				num++;
			}
		}
		OpponentMuzzleFlash = new Transform[num];
		num = 0;
		IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(OpponentGun.transform);
		while (enumerator2.MoveNext())
		{
			object obj2 = enumerator2.Current;
			if (!(obj2 is Transform))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
			}
			Transform transform2 = (Transform)obj2;
			if (transform2.gameObject.name == "MuzzleFlash")
			{
				OpponentMuzzleFlash[num] = transform2;
				UnityRuntimeServices.Update(enumerator2, transform2);
				num++;
			}
		}
	}

	public static void Unequip()
	{
		if (Weapon != null)
		{
			UnityEngine.Object.Destroy(Weapon);
		}
		CurrentGun = -1;
	}

	public virtual void Fire()
	{
		if (AmmoRemaining > 0)
		{
			StopCoroutine("GunBounce");
			StartCoroutine("GunBounce");
			AmmoRemaining--;
			AmmoFont.text = AmmoRemaining.ToString();
			if (UseVibration)
			{
				Handheld.Vibrate();
			}
			YourGunSource.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
			YourGunSource.PlayOneShot(AllGuns[CurrentGun].Fire, GunVolume);
			StopCoroutine("MuzzleFlashAction");
			StartCoroutine("MuzzleFlashAction");
			int i = 0;
			Transform[] muzzleFlash = MuzzleFlash;
			for (int length = muzzleFlash.Length; i < length; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Bullet, muzzleFlash[i].position + new Vector3(0.1f, -0.1f, 0f), Quaternion.identity);
				TrailRenderer trailRenderer = (TrailRenderer)gameObject.GetComponent(typeof(TrailRenderer));
				trailRenderer.startWidth *= Mathf.Sqrt(SizeScale);
				trailRenderer.endWidth *= Mathf.Sqrt(SizeScale);
				Vector3 vector = default(Vector3);
				float num = (1f - AllGuns[CurrentGun].Accuracy) * Settings.Scale / 4f * 80f;
				ShootRay = GetComponent<Camera>().ScreenPointToRay(new Vector3((float)(Screen.width / 2) + UnityEngine.Random.Range(0f - num, num), (float)(Screen.height / 2) + UnityEngine.Random.Range(0f - num, num), 0f));
				if (!Physics.Raycast(ShootRay, out RayHit, 300f))
				{
					RayHit.point = ShootRay.GetPoint(NoColliderTravelDist);
				}
				StartCoroutine(MoveBullet(gameObject, RayHit, true));
				SendMessage("GunsFired", RayHit.point);
				if (!Menus.IsSim)
				{
					Menus.GameCenterSend("Camera", "OpponentFire", RayHit.point.x.ToString() + "," + RayHit.point.y.ToString() + "," + RayHit.point.z.ToString(), true);
				}
			}
			if (AmmoRemaining == 0)
			{
				StartCoroutine("ShowReloadHelp");
			}
		}
		else
		{
			YourGunSource.PlayOneShot(NoAmmo, 0.9f);
		}
	}

	public virtual IEnumerator OpponentFire(string RayDestinationString)
	{
		return new _0024OpponentFire_0024861(RayDestinationString, this).GetEnumerator();
	}

	public virtual IEnumerator MuzzleFlashAction()
	{
		return new _0024MuzzleFlashAction_0024869(this).GetEnumerator();
	}

	public virtual IEnumerator OpponentMuzzleFlashAction()
	{
		return new _0024OpponentMuzzleFlashAction_0024886(this).GetEnumerator();
	}

	public virtual IEnumerator MoveBullet(GameObject Bullet, RaycastHit RayInfo, bool WasYou)
	{
		return new _0024MoveBullet_0024902(Bullet, RayInfo, WasYou, this).GetEnumerator();
	}

	public virtual IEnumerator FadeDecal(GameObject TheDecal)
	{
		return new _0024FadeDecal_0024922(TheDecal, this).GetEnumerator();
	}

	public virtual IEnumerator GunBounce()
	{
		return new _0024GunBounce_0024930(this).GetEnumerator();
	}

	public virtual IEnumerator Reload()
	{
		return new _0024Reload_0024933(this).GetEnumerator();
	}

	public virtual IEnumerator ReturnReloadButton()
	{
		return new _0024ReturnReloadButton_0024938(this).GetEnumerator();
	}

	public virtual IEnumerator FadeReloadHUD(float Target)
	{
		return new _0024FadeReloadHUD_0024944(Target, this).GetEnumerator();
	}

	public virtual IEnumerator ShowReloadHelp()
	{
		return new _0024ShowReloadHelp_0024952(this).GetEnumerator();
	}

	public static IEnumerator ShowPoints(int Points)
	{
		return new _0024ShowPoints_0024973(Points).GetEnumerator();
	}

	public virtual void ResetVariables()
	{
		if (CurrentGun >= 0)
		{
			AmmoRemaining = AllGuns[CurrentGun].MaxAmmo;
			AmmoFont.text = AllGuns[CurrentGun].MaxAmmo.ToString();
		}
		if (!Gyro.UseGyro || !UseTilt)
		{
			TiltedDown = true;
		}
		else
		{
			int num = 0;
			Color color = ReloadButton.color;
			float num2 = (color.a = num);
			Color color3 = (ReloadButton.color = color);
		}
		for (int i = 0; i < BulletDecalArrayLength; i++)
		{
			BulletDecalArray[i].transform.parent = BulletDecalParent;
			BulletDecalArray[i].transform.position = new Vector3(0f, -500f, 0f);
			BulletDecalArray[i].gameObject.SetActive(false);
			if (BulletDecalArray[i].GetComponent<Renderer>().material != OriginalDecalMat)
			{
				UnityEngine.Object.Destroy(BulletDecalArray[i].GetComponent<Renderer>().material);
				BulletDecalArray[i].GetComponent<Renderer>().material = OriginalDecalMat;
			}
		}
		if (GunLight != null)
		{
			GunLightIntensity = GunLight.intensity;
		}
		GunLag = 0f;
		WeaponReloadOffset = 0f;
		GunShotBounce = 0.01f;
		IsReloading = false;
		ReloadButtonActive = false;
		ReloadTouch = false;
		ReloadPositionLastFrame = 0;
		ReloadButtonPosition = (int)ReloadButton.pixelInset.y;
		CrosshairDrift = 0f;
		AllowFireReload = false;
		AllowOpponentFire = false;
		StartCoroutine("ShowReloadHelp");
	}

	public virtual void Main()
	{
	}
}
