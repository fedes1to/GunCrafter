using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Gyro : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReorientGyro_0024992 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Gyro _0024self__0024993;

			public _0024(Gyro self_)
			{
				_0024self__0024993 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!Menus.IsVR)
					{
						if (Menus.HoldAds)
						{
							goto case 1;
						}
						if (UseGyro)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						Rotation.y = _0024self__0024993.DefaultYRotation;
					}
					goto IL_00da;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024self__0024993.transform.rotation = Quaternion.Euler(90f, 90f, 0f) * gyro.attitude * RotFix;
					Rotation.y = _0024self__0024993.DefaultYRotation - _0024self__0024993.transform.eulerAngles.y;
					goto IL_00da;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00da:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Gyro _0024self__0024994;

		public _0024ReorientGyro_0024992(Gyro self_)
		{
			_0024self__0024994 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024994);
		}
	}

	[NonSerialized]
	public static Quaternion RotFix;

	[NonSerialized]
	public static Vector2 Rotation;

	[NonSerialized]
	public static Vector2 SwipeStart;

	[NonSerialized]
	public static Vector2 SwipePositionLastFrame;

	[NonSerialized]
	public static float Movement;

	[NonSerialized]
	public static Quaternion TargetRotation = Quaternion.identity;

	[NonSerialized]
	public static Transform TheTransform;

	[NonSerialized]
	public static bool UseGyro;

	[NonSerialized]
	public static Gyroscope gyro;

	[NonSerialized]
	public static float TiltOffset = 24f;

	[NonSerialized]
	public static float SwipeSensitivity = 1f;

	public float DefaultYRotation;

	public bool SwipeIsInverted;

	[NonSerialized]
	public static bool InvertSwipe;

	public bool CameraKickback;

	public bool AllowMovement;

	[NonSerialized]
	public static bool AllowingMovement;

	public bool AllowTurning;

	[NonSerialized]
	public static bool AllowingTurning;

	private bool TestAcc;

	private Menus Menu;

	[NonSerialized]
	public static Vector2 Sway;

	[NonSerialized]
	public static bool HoldReorientation;

	public Gyro()
	{
		CameraKickback = true;
	}

	public virtual void Awake()
	{
		Menu = (Menus)GetComponent(typeof(Menus));
		RotFix = new Quaternion(0f, 0f, 1f, 0f);
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;
		}
		if (PlayerPrefs.GetString("UseGyro") != "false" && PlayerPrefs.GetString("UseGyro") != "true")
		{
			if (SystemInfo.supportsGyroscope)
			{
				PlayerPrefs.SetString("UseGyro", "true");
			}
			else
			{
				PlayerPrefs.SetString("UseGyro", "false");
			}
		}
		UseGyro = bool.Parse(PlayerPrefs.GetString("UseGyro"));
		ToggleGyro(UseGyro);
		TheTransform = transform;
		InvertSwipe = SwipeIsInverted;
		AllowingMovement = AllowMovement;
		AllowingTurning = AllowTurning;
	}

	public virtual void Start()
	{
		if (Saver.Get("SwipeSensitivity") == string.Empty)
		{
			Saver.Set("SwipeSensitivity", 1f);
		}
		SwipeSensitivity = Saver.GetFloat("SwipeSensitivity");
	}

	public static void ToggleGyro(bool ShouldUse)
	{
		if (ShouldUse && SystemInfo.supportsGyroscope)
		{
			UseGyro = true;
			Guns.TiltedDown = true;
			PlayerPrefs.SetString("UseGyro", "true");
		}
		else
		{
			UseGyro = false;
			PlayerPrefs.SetString("UseGyro", "false");
		}
	}

	public static void AdjustSwipeSensitivity(float Value)
	{
		Value = Mathf.Clamp(Value, 0.1f, 1.9f);
		Saver.Set("SwipeSensitivity", Value);
		SwipeSensitivity = Value;
		Saver.Save();
	}

	public virtual void ResetVariables()
	{
		if (!UseGyro)
		{
			Rotation = Vector2.zero;
		}
		Movement = 0f;
		SwipePositionLastFrame = Input.mousePosition;
		TiltOffset = 24f;
		InvertSwipe = SwipeIsInverted;
		AllowingMovement = AllowMovement;
		AllowingTurning = AllowTurning;
		StartCoroutine(ReorientGyro());
	}

	public virtual void UpdateGyro()
	{
		int num = ((!InvertSwipe) ? 1 : (-1));
		bool flag = default(bool);
		if (!UseGyro)
		{
			Sway.x += 2.2f * Time.deltaTime;
			Sway.y += 1.6f * Time.deltaTime;
			int i = 0;
			CustomTouch[] touches = Menus.Touches;
			for (int length = touches.Length; i < length; i++)
			{
				if ((touches[i].fingerId != 999 || Application.isEditor) && !(touches[i].position.x >= (float)(Screen.width / 2)) && !flag)
				{
					flag = true;
					if (Menu.Began(touches[i]))
					{
						SwipePositionLastFrame = touches[i].position;
					}
					else if (Menu.Moved(touches[i]) || Menu.Stationary(touches[i]))
					{
						Rotation.x -= (touches[i].position.y - SwipePositionLastFrame.y) / (Settings.DPI / 163f) * (float)num * SwipeSensitivity;
						Rotation.y += (touches[i].position.x - SwipePositionLastFrame.x) / (Settings.DPI / 163f) * SwipeSensitivity;
						SwipePositionLastFrame = touches[i].position;
					}
				}
			}
		}
		else
		{
			int j = 0;
			CustomTouch[] touches2 = Menus.Touches;
			for (int length2 = touches2.Length; j < length2; j++)
			{
				if (touches2[j].position.x >= (float)(Screen.width / 2) || (!AllowingMovement && !AllowingTurning) || flag)
				{
					continue;
				}
				flag = true;
				if (Menu.Began(touches2[j]))
				{
					SwipeStart = touches2[j].position;
				}
				else if (Menu.Moved(touches2[j]) || Menu.Stationary(touches2[j]))
				{
					if (AllowingTurning)
					{
						Rotation.y += (touches2[j].position.x - SwipeStart.x) / Settings.DPI * 1000f * Time.deltaTime;
					}
					Movement = (touches2[j].position.y - SwipeStart.y) / Settings.DPI * 326f;
				}
			}
			if (!flag)
			{
				Movement = 0f;
			}
		}
		float gunShotBounce = default(float);
		if (CameraKickback)
		{
			gunShotBounce = Guns.GunShotBounce;
		}
		if (!UseGyro)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(Rotation.x + gunShotBounce * -45f, Rotation.y, 0f)), Time.deltaTime * 10f);
			return;
		}
		TargetRotation = Quaternion.Slerp(TargetRotation, gyro.attitude * RotFix, Time.deltaTime * 20f);
		transform.rotation = Quaternion.Euler(90f, 90f, 0f) * TargetRotation;
		if (AllowingMovement)
		{
			Vector3 vector = new Vector3(Mathf.Sin(transform.eulerAngles.y * ((float)Math.PI / 180f)), 0f, Mathf.Cos(transform.eulerAngles.y * ((float)Math.PI / 180f)));
			transform.Translate(vector * Movement * Time.deltaTime, Space.World);
		}
		transform.Rotate(new Vector3(0f, Rotation.y, 0f), Space.World);
		transform.Rotate(new Vector3(0f - TiltOffset + gunShotBounce * -45f, 0f, 0f));
	}

	public virtual void OnApplicationPause(bool pause)
	{
	}

	public virtual void OnApplicationFocus(bool GainedFocus)
	{
		if (GainedFocus)
		{
			StartCoroutine("ReorientGyro");
		}
	}

	public virtual IEnumerator ReorientGyro()
	{
		return new _0024ReorientGyro_0024992(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
