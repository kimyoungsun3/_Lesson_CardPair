using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
	public AudioSource bgm;
	public int effectIndex = 0;
	public List<AudioSource> effect = new List<AudioSource>();

	private void Awake()
	{
		
	}

	private void Update()
	{
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

}
