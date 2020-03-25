using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
	public class BackGroundGaming : MonoBehaviour
	{
		[SerializeField] SpriteRenderer spriteRenderer;
		[SerializeField] List<Sprite> list = new List<Sprite>();

		// Use this for initialization
		void Start()
		{
			if(spriteRenderer == null)
				spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		}

		int index = 0;
		public void SetBackgroundSprite()
		{
			spriteRenderer.sprite = list[index];
			index++;
			index = index % list.Count;
		}
	}
}