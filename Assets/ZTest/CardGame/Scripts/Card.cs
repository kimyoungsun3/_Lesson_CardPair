using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CardGame
{

	public class Card : MonoBehaviour
	{
		[SerializeField] private GameObject goBackground;
		public CardData cardData;

		public void OnMouseDown()
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}

			if (goBackground.activeSelf && CardManager.ins.isReveal)
			{
				//클릭 소리가 난후에 카드 뒤집어서 비교하기...
				AudioManager.ins.PlayClick();

				goBackground.SetActive(false);
				CardManager.ins.CheckCard(this);
			}
		}

		public void SetCardData(CardData _cardData)
		{
			cardData = _cardData;
			GetComponent<SpriteRenderer>().sprite = cardData.sprite;
		}

		public void Unreveal()
		{
			goBackground.SetActive(true);
		}

		public void Reveal(bool _b)
		{
			goBackground.SetActive(_b);
		}
	}

}