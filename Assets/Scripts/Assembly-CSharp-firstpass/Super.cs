using UnityEngine;

public struct Super
{
	public float Base;

	public int Tens;

	public Super(float Base, int Tens)
	{
		while (Mathf.Abs(Base) >= 10f)
		{
			Base *= 0.1f;
			Tens++;
		}
		while (Mathf.Abs(Base) < 1f && Mathf.Abs(Base) != 0f && Tens >= 0)
		{
			Base *= 10f;
			Tens--;
		}
		this.Base = Base;
		this.Tens = Tens;
	}

	public Super(float AFloat)
	{
		if (AFloat == float.PositiveInfinity)
		{
			Base = 1f;
			Tens = int.MaxValue;
		}
		else
		{
			Super super = new Super(AFloat, 0);
			Base = super.Base;
			Tens = super.Tens;
		}
	}

	public static Super operator -(Super c1)
	{
		return new Super(c1.Base * -1f, c1.Tens);
	}

	public static Super operator +(Super c1, Super c2)
	{
		float num = 0f;
		int tens;
		if (c1.Tens > c2.Tens)
		{
			tens = c1.Tens;
			num = c1.Base;
		}
		else
		{
			tens = c2.Tens;
			num = c2.Base;
		}
		if (Mathf.Abs(c1.Tens - c2.Tens) <= 8)
		{
			num = c1.Base / Mathf.Pow(10f, tens - c1.Tens) + c2.Base / Mathf.Pow(10f, tens - c2.Tens);
		}
		return new Super(num, tens);
	}

	public static Super operator +(Super c1, float f2)
	{
		Super super = new Super(f2);
		return c1 + super;
	}

	public static Super operator +(float f1, Super c2)
	{
		Super super = new Super(f1);
		return super + c2;
	}

	public static Super operator -(Super c1, Super c2)
	{
		float num = 0f;
		int tens;
		if (c1.Tens > c2.Tens)
		{
			tens = c1.Tens;
			num = c1.Base;
		}
		else
		{
			tens = c2.Tens;
			num = 0f - c2.Base;
		}
		if (Mathf.Abs(c1.Tens - c2.Tens) <= 8)
		{
			num = c1.Base / Mathf.Pow(10f, tens - c1.Tens) - c2.Base / Mathf.Pow(10f, tens - c2.Tens);
		}
		return new Super(num, tens);
	}

	public static Super operator -(float f1, Super c2)
	{
		Super super = new Super(f1);
		return super - c2;
	}

	public static Super operator -(Super c1, float f2)
	{
		Super super = new Super(f2);
		return c1 - super;
	}

	public static Super operator *(Super c1, Super c2)
	{
		float @base = c1.Base * c2.Base;
		int tens = c1.Tens + c2.Tens;
		return new Super(@base, tens);
	}

	public static Super operator *(Super c1, float f2)
	{
		Super super = new Super(f2);
		return c1 * super;
	}

	public static Super operator *(float f1, Super c2)
	{
		Super super = new Super(f1);
		return super * c2;
	}

	public static Super operator /(Super c1, Super c2)
	{
		float @base = c1.Base / c2.Base;
		int tens = c1.Tens - c2.Tens;
		return new Super(@base, tens);
	}

	public static Super operator /(Super c1, float f2)
	{
		Super super = new Super(f2);
		return c1 / super;
	}

	public static Super operator /(float f1, Super c2)
	{
		Super super = new Super(f1);
		return super / c2;
	}

	public static bool operator ==(Super c1, Super c2)
	{
		if (c1.Base == c2.Base && c1.Tens == c2.Tens)
		{
			return true;
		}
		return false;
	}

	public static bool operator ==(Super c1, float f2)
	{
		Super super = new Super(f2);
		if (c1 == super)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Super c1, Super c2)
	{
		if (c1.Base != c2.Base || c1.Tens != c2.Tens)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Super c1, float f2)
	{
		Super super = new Super(f2);
		if (c1 != super)
		{
			return true;
		}
		return false;
	}

	public static bool operator <(Super c1, Super c2)
	{
		if (c1 == c2)
		{
			return false;
		}
		if ((c1.Base < 0f && c2.Base >= 0f) || (c1.Base <= 0f && c2.Base > 0f))
		{
			return true;
		}
		if ((c1.Base > 0f && c2.Base <= 0f) || (c1.Base >= 0f && c2.Base < 0f))
		{
			return false;
		}
		if (c1.Tens == c2.Tens)
		{
			return c1.Base < c2.Base;
		}
		if (c1.Base < 0f && c2.Base < 0f)
		{
			if (c1.Tens > c2.Tens)
			{
				return true;
			}
			return false;
		}
		if (c1.Tens < c2.Tens)
		{
			return true;
		}
		return false;
	}

	public static bool operator <(Super c1, float f2)
	{
		Super super = new Super(f2);
		if (c1 < super)
		{
			return true;
		}
		return false;
	}

	public static bool operator <(float f1, Super c2)
	{
		Super super = new Super(f1);
		if (super < c2)
		{
			return true;
		}
		return false;
	}

	public static bool operator >(Super c1, Super c2)
	{
		if (c1 == c2 || c1 < c2)
		{
			return false;
		}
		return true;
	}

	public static bool operator >(Super c1, float f2)
	{
		Super super = new Super(f2);
		if (c1 > super)
		{
			return true;
		}
		return false;
	}

	public static bool operator >(float f1, Super c2)
	{
		Super super = new Super(f1);
		if (super > c2)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(Super v1, Super v2)
	{
		if (v1 < v2 || v1 == v2)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(Super v1, float v2)
	{
		if (v1 < v2 || v1 == v2)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(float v1, Super v2)
	{
		Super super = new Super(v1);
		if (v1 < v2 || super == v2)
		{
			return true;
		}
		return false;
	}

	public static bool operator >=(Super v1, Super v2)
	{
		if (v1 > v2 || v1 == v2)
		{
			return true;
		}
		return false;
	}

	public static bool operator >=(Super v1, float v2)
	{
		if (v1 > v2 || v1 == v2)
		{
			return true;
		}
		return false;
	}

	public static bool operator >=(float v1, Super v2)
	{
		Super super = new Super(v1);
		if (v1 > v2 || super == v2)
		{
			return true;
		}
		return false;
	}

	public static Super Pow(float A, int B)
	{
		float num = 1f;
		int num2 = 0;
		for (int i = 0; i < B; i++)
		{
			for (num *= A; num > 1000f; num *= 0.001f)
			{
				num2 += 3;
			}
		}
		num = Mathf.Round(num * 100f) * 0.01f;
		return new Super(num, num2);
	}

	public static Super Abs(Super A)
	{
		return new Super(Mathf.Abs(A.Base), A.Tens);
	}

	public static Super Clamp(Super A, Super B, Super C)
	{
		if (A < B)
		{
			return B;
		}
		if (A > C)
		{
			return C;
		}
		return A;
	}

	public static Super Clamp(Super A, Super B, float C)
	{
		return Clamp(A, B, new Super(C));
	}

	public static Super Clamp(Super A, float B, Super C)
	{
		return Clamp(A, new Super(B), C);
	}

	public static Super Clamp(Super A, float B, float C)
	{
		return Clamp(A, new Super(B), new Super(C));
	}

	public static Super Lerp(Super A, Super B, float C)
	{
		return A + (B - A) * C;
	}

	public static float ToFloat(Super A)
	{
		if (A < 1E+09f)
		{
			return A.Base * Mathf.Pow(10f, A.Tens);
		}
		return 1E+09f;
	}

	public static Super Round(Super A)
	{
		if (A.Tens < 3)
		{
			A.Base = Mathf.Round(A.Base * Mathf.Pow(10f, A.Tens)) / Mathf.Pow(10f, A.Tens);
		}
		return A;
	}

	public static Super Floor(Super A)
	{
		if (A.Tens < 3)
		{
			A.Base = Mathf.Floor(A.Base * Mathf.Pow(10f, A.Tens)) / Mathf.Pow(10f, A.Tens);
		}
		return A;
	}

	public static Super Even(Super A)
	{
		A.Base = Mathf.Round(A.Base * Mathf.Pow(10f, A.Tens % 3)) / Mathf.Pow(10f, A.Tens % 3);
		return A;
	}

	public static string SuperString(Super A)
	{
		string[] array = new string[56]
		{
			"E", "K", "M", "B", "T", "q", "Q", "s", "S", "o",
			"N", "d", "U", "D", "x", "y", "z", "*", "&", "^",
			"#", "@", "!", "w", "e", "r", "i", "p", "a", "f",
			"g", "h", "c", "v", "W", "E", "R", "P", "A", "F",
			"G", "H", "C", "V", "~", "`", ";", "k", "m", "b",
			"t", "n", "u", "X", "Y", "Z"
		};
		if (A.Tens > 2)
		{
			int num = A.Tens / 3;
			int num2 = (int)Mathf.Floor(num / array.Length);
			int num3 = num - num2 * array.Length;
			string text = array[num3];
			for (int i = 0; i < num2; i++)
			{
				text += text;
			}
			return (Mathf.Round(A.Base * Mathf.Pow(10f, A.Tens % 3) * 100f) / 100f).ToString("F0") + text;
		}
		return Mathf.Round(A.Base * Mathf.Pow(10f, A.Tens)).ToString("F0");
	}

	public override string ToString()
	{
		string[] array = new string[56]
		{
			"E", "K", "M", "B", "T", "q", "Q", "s", "S", "o",
			"N", "d", "U", "D", "x", "y", "z", "*", "&", "^",
			"#", "@", "!", "w", "e", "r", "i", "p", "a", "f",
			"g", "h", "c", "v", "W", "E", "R", "P", "A", "F",
			"G", "H", "C", "V", "~", "`", ";", "k", "m", "b",
			"t", "n", "u", "X", "Y", "Z"
		};
		if (Tens > 2)
		{
			int num = Tens / 3;
			int num2 = (int)Mathf.Floor(num / array.Length);
			int num3 = num - num2 * array.Length;
			string text = array[num3];
			for (int i = 0; i < num2; i++)
			{
				text += text;
			}
			return (Mathf.Round(Base * Mathf.Pow(10f, Tens % 3) * 100f) / 100f).ToString("F2") + text;
		}
		return Mathf.Round(Base * Mathf.Pow(10f, Tens)).ToString();
	}

	public static string Raw(Super c1)
	{
		return c1.Base + "," + c1.Tens;
	}
}
