using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step03
{
	[System.Serializable]
	public class CardData
	{
		public int id;
		public Sprite sprite;
	}

	public class Card : MonoBehaviour
	{
		public CardData cardData;

		public void Init(CardData _cardData)
		{
			cardData = _cardData;
			GetComponent<SpriteRenderer>().sprite = cardData.sprite;
		}
	}
}
