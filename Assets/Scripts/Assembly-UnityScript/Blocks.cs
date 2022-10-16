using System;
using UnityEngine;

[Serializable]
public class Blocks : MonoBehaviour
{
	[NonSerialized]
	public static Vector3 Pos;

	[NonSerialized]
	public static int[] BlockAtDir = new int[26];

	[NonSerialized]
	public static float BLeft = 1f;

	[NonSerialized]
	public static float BRight = 1f;

	[NonSerialized]
	public static float TLeft = 1f;

	[NonSerialized]
	public static float TRight = 1f;

	[NonSerialized]
	public static float ShadowStrength = 0.18f;

	[NonSerialized]
	public static float InitialLightness = 1f;

	[NonSerialized]
	public static Vector3[] dir = new Vector3[26]
	{
		new Vector3(-1f, 0f, 0f),
		new Vector3(1f, 0f, 0f),
		new Vector3(0f, 1f, 0f),
		new Vector3(0f, -1f, 0f),
		new Vector3(0f, 0f, -1f),
		new Vector3(0f, 0f, 1f),
		new Vector3(-1f, 1f, -1f),
		new Vector3(1f, -1f, 1f),
		new Vector3(-1f, -1f, -1f),
		new Vector3(1f, 1f, 1f),
		new Vector3(-1f, 1f, 1f),
		new Vector3(1f, -1f, -1f),
		new Vector3(-1f, -1f, 1f),
		new Vector3(1f, 1f, -1f),
		new Vector3(-1f, 0f, -1f),
		new Vector3(1f, 0f, 1f),
		new Vector3(-1f, 0f, 1f),
		new Vector3(1f, 0f, -1f),
		new Vector3(-1f, 1f, 0f),
		new Vector3(1f, -1f, 0f),
		new Vector3(-1f, -1f, 0f),
		new Vector3(1f, 1f, 0f),
		new Vector3(0f, 1f, -1f),
		new Vector3(0f, -1f, 1f),
		new Vector3(0f, 1f, 1f),
		new Vector3(0f, -1f, -1f)
	};

	public static bool CheckKey(Dir Direction)
	{
		int result;
		if (BlockAtDir[(int)Direction] != -1)
		{
			result = ((BlockAtDir[(int)Direction] != 0) ? 1 : 0);
		}
		else
		{
			Vector3 key = new Vector3(Pos.x + dir[(int)Direction].x, Pos.y + dir[(int)Direction].y, Pos.z + dir[(int)Direction].z);
			if (Game.TargetDictionary.ContainsKey(key))
			{
				BlockAtDir[(int)Direction] = 1;
				result = 1;
			}
			else
			{
				BlockAtDir[(int)Direction] = 0;
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	public static void ResetColors()
	{
		BLeft = 1f;
		BRight = 1f;
		TLeft = 1f;
		TRight = 1f;
	}

	public static void FinalLighting(float SideDarkness)
	{
		BLeft = (InitialLightness - SideDarkness) * (InitialLightness - SideDarkness * 0.5f) * BLeft;
		TRight = (InitialLightness - SideDarkness) * (InitialLightness - SideDarkness * 0.5f) * TRight;
		BRight = (InitialLightness - SideDarkness) * (InitialLightness - SideDarkness * 0.5f) * BRight;
		TLeft = (InitialLightness - SideDarkness) * (InitialLightness - SideDarkness * 0.5f) * TLeft;
	}

	public static void SetLighting(Vector3 Position)
	{
		Pos = Position;
		int i = 0;
		int[] blockAtDir = BlockAtDir;
		for (int length = blockAtDir.Length; i < length; i++)
		{
			blockAtDir[i] = -1;
		}
		if (!Game.TargetDictionary.ContainsKey(Pos))
		{
			return;
		}
		GameObject gameObject = Game.TargetDictionary[Pos];
		Mesh mesh = ((MeshFilter)gameObject.GetComponent(typeof(MeshFilter))).mesh;
		Vector3[] vertices = mesh.vertices;
		Color[] array = new Color[vertices.Length];
		ResetColors();
		if (!CheckKey(Dir.Backward))
		{
			if (CheckKey(Dir.TopLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Top))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.TopRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Right))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Bot))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Left))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			FinalLighting(0.5f);
			array[0] = Color.white * BRight;
			array[1] = Color.white * BLeft;
			array[2] = Color.white * TRight;
			array[3] = Color.white * TLeft;
		}
		if (!CheckKey(Dir.Top))
		{
			ResetColors();
			if (CheckKey(Dir.FrontTopLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTop))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTopRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.TopRight))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackTopRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackTop))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackTopLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.TopLeft))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Forward))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Right))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Backward))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Left))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			FinalLighting(0.1f);
			array[4] = Color.white * TRight;
			array[5] = Color.white * TLeft;
			array[8] = Color.white * BRight;
			array[9] = Color.white * BLeft;
		}
		if (!CheckKey(Dir.Forward))
		{
			ResetColors();
			if (CheckKey(Dir.FrontTopLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTop))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTopRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontRight))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBotRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBot))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBotLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontLeft))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.TopLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Top))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.TopRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Right))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Bot))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Left))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			FinalLighting(0.1f);
			array[6] = Color.white * BRight;
			array[7] = Color.white * BLeft;
			array[10] = Color.white * TRight;
			array[11] = Color.white * TLeft;
		}
		if (!CheckKey(Dir.Bot))
		{
			ResetColors();
			if (CheckKey(Dir.FrontBotLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBot))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBotRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotRight))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBotRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBot))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBotLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.BotLeft))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Forward))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Right))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Backward))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Left))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			FinalLighting(0.7f);
			array[12] = Color.white * TRight;
			array[13] = Color.white * BLeft;
			array[14] = Color.white * TLeft;
			array[15] = Color.white * BRight;
		}
		if (!CheckKey(Dir.Right))
		{
			ResetColors();
			if (CheckKey(Dir.BackTopRight))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.TopRight))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTopRight))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontRight))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBotRight))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotRight))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBotRight))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.BackRight))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.BackTop))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Top))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTop))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Forward))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBot))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Bot))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBot))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Backward))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			FinalLighting(0.3f);
			array[20] = Color.white * BRight;
			array[21] = Color.white * TLeft;
			array[22] = Color.white * BLeft;
			array[23] = Color.white * TRight;
		}
		if (!CheckKey(Dir.Left))
		{
			ResetColors();
			if (CheckKey(Dir.BackTopLeft))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.TopLeft))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTopLeft))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontLeft))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBotLeft))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BotLeft))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBotLeft))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.BackLeft))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.BackTop))
			{
				TLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Top))
			{
				TLeft -= ShadowStrength;
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontTop))
			{
				TRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Forward))
			{
				TRight -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.FrontBot))
			{
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.Bot))
			{
				BLeft -= ShadowStrength;
				BRight -= ShadowStrength;
			}
			if (CheckKey(Dir.BackBot))
			{
				BLeft -= ShadowStrength;
			}
			if (CheckKey(Dir.Backward))
			{
				TLeft -= ShadowStrength;
				BLeft -= ShadowStrength;
			}
			FinalLighting(0.25f);
			array[16] = Color.white * BLeft;
			array[17] = Color.white * TRight;
			array[18] = Color.white * BRight;
			array[19] = Color.white * TLeft;
		}
		mesh.colors = array;
		if (BlockAtDir[0] == 0 || BlockAtDir[1] == 0 || BlockAtDir[2] == 0 || (BlockAtDir[3] == 0 && Pos.y != 0f) || BlockAtDir[4] == 0 || BlockAtDir[5] == 0)
		{
			gameObject.GetComponent<Collider>().enabled = true;
			gameObject.GetComponent<Renderer>().enabled = true;
			if (Pos.y == 0f && BlockAtDir[4] == 0 && gameObject.transform.childCount == 0)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(Game.StaticBlockShadow, Vector3.zero, Quaternion.identity);
				gameObject2.layer = 10;
				gameObject2.transform.parent = gameObject.transform;
				gameObject2.transform.localPosition = new Vector3(0f, -0.48f, -0.5f);
			}
		}
	}

	public virtual void Main()
	{
	}
}
