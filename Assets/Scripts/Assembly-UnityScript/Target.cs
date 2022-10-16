using System;
using UnityEngine;

[Serializable]
public class Target : MonoBehaviour
{
	public TargetType Type;

	public float Life;

	public float Value;

	public float DamageDealt;

	public bool IsPresent;

	public virtual void Start()
	{
		if (Life == 0f)
		{
			Life = Game.TargetLife[(int)Type];
		}
		if (Value == 0f)
		{
			Value = Game.TargetValue[(int)Type];
		}
	}

	public virtual void Hit(float Damage)
	{
		DamageDealt += Damage;
	}

	public virtual void Main()
	{
	}
}
