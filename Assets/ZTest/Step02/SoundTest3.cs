using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest3 : MonoBehaviour
{
	public static SoundTest3 ins;
	public AudioSource bgm;
	public int effectIndex = 0;
	public List<AudioSource> effect = new List<AudioSource>();

	private void Awake()
	{
		if(ins == null)
		{
			ins = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Application.LoadLevel(0);
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			PlayBGM();
		}
		if (Input.GetMouseButtonDown(0))
		{
			PlayEffect();
		}
	}

	public void PlayBGM()
	{
		if (bgm.isPlaying)
		{
			bgm.Stop();
		}
		else
		{
			bgm.loop = true;
			bgm.Play();
		}
	}

	public void PlayEffect()
	{
		effect[effectIndex].Play();
		effectIndex++;
		effectIndex = effectIndex % effect.Count;
		//effect.Play();
	}


	public static void FFF()
	{
		Debug.Log(111);
	}
}
