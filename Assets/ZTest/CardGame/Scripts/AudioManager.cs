using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager ins;

		[SerializeField] AudioSource bgm;
		[SerializeField] AudioSource click;
		[HideInInspector] public bool bSound;

		private void Awake()
		{
			ins = this;
		}

		public void PlayBGM()
		{
			if (bSound)
			{
				bgm.loop = true;
				bgm.Play();
			}
		}

		public void PlayClick()
		{
			if (bSound)
			{
				click.Play();
			}
		}
	}
}