using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	[System.Serializable]
	public class CardData
	{
		public int id;
		public Sprite sprite;
	}

	public class CardManager : MonoBehaviour
	{
		public static CardManager ins;

		public StageTable stageTable;

		[SerializeField] Transform gamingCenter;
		[SerializeField] Card prefabCard;
		[SerializeField] CardData[] listCardData;

		[SerializeField] List<Card> listCurrentCard = new List<Card>();
		int cardCount;  //전체 카드 수량...
		int machSuccessCount;  //맞추기 성공한 카드수량...
		Card cardFirst, cardSecond;

		private void Awake()
		{
			ins = this;
		}

		public void ReadResource()
		{
			// 1부터 52까지 숫자 읽기...
			listCardData = new CardData[Constant.CARD_MAX];
			for (int i = 0; i < listCardData.Length; i++)
			{
				listCardData[i] = new CardData();
				listCardData[i].id = i;
				listCardData[i].sprite = Resources.Load<Sprite>("CardSets/" + i);
			}
		}

		#region Gaming....
		public void ReadyBoard()
		{
			//1. shuffle
			Shuffle();

			//2. 유저 스테이지 정보 참조해서 카드보드 만들기...
			int _stage = UserData.ins.stage;
			stageTable = GameData.GetStageTable(_stage);
			//Debug.Log("@@@@ Board만들기 >> " + stageTable.ToString());

			//카드 스폰하기...
			SpawnCard();
		}

		//eye shuffle
		void Shuffle()
		{
			int _count = listCardData.Length;
			int _idx;
			CardData _cardData;
			for (int i = 0; i < _count - 1; i++)
			{
				_idx = Random.Range(i + 1, _count);

				_cardData			= listCardData[i];
				listCardData[i]		= listCardData[_idx];
				listCardData[_idx]	= _cardData;
			}
		}

		void SpawnCard()
		{
			//카드의 홀더 자리를 잡자..
			//있으면 제거하고 없으면 생성해준다....
			Transform _holder = gamingCenter.Find("Holder");
			if (_holder)
			{
				Destroy(_holder.gameObject);
			}
			GameObject _go = new GameObject("Holder");
			_go.transform.SetParent(gamingCenter);
			_holder = _go.transform;

			//카드를 배치한다...
			Vector3 _startPos = _holder.position;
			Vector3 _endPos = Vector3.zero;
			Quaternion _rot = Quaternion.identity;
			Card _card;
			listCurrentCard.Clear();
			for (int i = 0, _idx = 0; i < stageTable.col; i++)
			{
				for (int j = 0; j < stageTable.row; j++, _idx++)
				{
					//카드를 생성해서 리스트에 넣어주기...
					_card = Instantiate(prefabCard, _startPos, _rot) as Card;
					listCurrentCard.Add(_card);

					_card.transform.SetParent(_holder);
					_card.SetCardData(listCardData[_idx / 2]);

					float _posX = (stageTable.sizeX * i) + _startPos.x;
					float _posY = (stageTable.sizeY * j) + _startPos.y;
					_endPos = new Vector3(_posX, _posY, _startPos.z);
					_card.transform.position = _endPos;
				}
			}

			//카드를 센터의 자리에 위치하기..
			_holder.position = (_startPos - _endPos) / 2f;
			cardCount = listCurrentCard.Count;
			machSuccessCount = 0;

			//카드 자리섞기...
			Vector3 _backPos;
			int _randIdx;
			for (int i = 1; i < cardCount; i++)
			{
				_randIdx = Random.Range(i, cardCount);

				_backPos = listCurrentCard[i - 1].transform.position;
				listCurrentCard[i - 1].transform.position = listCurrentCard[_randIdx].transform.position;
				listCurrentCard[_randIdx].transform.position = _backPos;
			}

			//섞인 카드를 임의의 자리에 넣어주기...
			//for(int i = 0; i < cardCount; i+=2)
			//{
			//	CardData _cardData = listCardData[i / 2];
			//	listCurrentCard[i + 0].SetCardData(_cardData);
			//	listCurrentCard[i + 1].SetCardData(_cardData);
			//	//Debug.Log(i + " >> " + _cardData.id);
			//}

			////배치된것을 썩어주기...
			//int _idx;
			//for (int i = 0; i < cardCount; i++) {
			//	_idx = Random.Range(0, cardCount);
			//	_card = listCurrentCard[_idx];
			//	listCurrentCard.RemoveAt(_idx);
			//	listCurrentCard.Add(_card);
			//}
		}

		public void BoardStripAndWear(bool _onoff)
		{
			for (int i = 0; i < listCurrentCard.Count; i++)
			{
				listCurrentCard[i].Reveal(_onoff);
			}
		}
		#endregion


		#region 카드매칭테스트...
		public int stage	{get { return stageTable.stage; }}

		float endTime;
		public void StartTime()
		{
			endTime = Time.time + stageTable.time;
		}
		public bool isTimeOver
		{
			get { return Time.time > endTime; }
		}

		public string remainTime
		{
			get
			{
				float _rt = endTime - Time.time;
				if (_rt <= 0f) _rt = 0f;
				//return _rt.ToString("##.##");
				return Mathf.Ceil(_rt).ToString();
			}
		}
		public int GetRemainTime()
		{
			return (int) (endTime - Time.time);
		}

		public bool isClear
		{
			get { return cardCount == machSuccessCount; }
		}

		public bool isReveal
		{
			get { return cardSecond == null; }
		}

		public void CheckCard(Card _card)
		{
			if (cardFirst == null)
			{
				cardFirst = _card;
			}
			else
			{
				cardSecond = _card;
				StartCoroutine(CheckMatch());
			}
		}

		private IEnumerator CheckMatch()
		{
			if (cardFirst.cardData.id == cardSecond.cardData.id)
			{
				UserData.ins.score	+= 10;
				machSuccessCount	+= 2;
				Ui_GamingMenu.ins.DisplayScore(UserData.ins.score);
			}
			else
			{
				yield return new WaitForSeconds(0.5f);
				cardFirst.Unreveal();
				cardSecond.Unreveal();
			}

			cardFirst = null;
			cardSecond = null;
		}
		#endregion

	}

}