using System;
using UnityEngine;

[Serializable]
public class Gun
{
	public string Name;

	public GameObject Held;

	public int MaxAmmo;

	public float Accuracy;

	public float ReloadSpeed;

	public float Damage;

	public int Requirement;

	public AudioClip Fire;

	public AudioClip Reload;

	public Gun(string N, GameObject H, int M, float A, float L, float D, int R, AudioClip F, AudioClip E)
	{
		ReloadSpeed = 0.1f;
		Damage = 1f;
		Name = N;
		Held = H;
		MaxAmmo = M;
		Accuracy = A;
		ReloadSpeed = L;
		Damage = D;
		Requirement = R;
		Fire = F;
		Reload = E;
	}
}
