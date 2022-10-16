using System;
using UnityEngine;

[Serializable]
public class FadeAudioParams
{
	public AudioSource Source;

	public float Volume;

	public float Speed;

	public bool DestroyAfterFade;

	public FadeAudioParams(AudioSource A, float V, float S, bool D)
	{
		Source = A;
		Volume = V;
		Speed = S;
		DestroyAfterFade = D;
	}
}
