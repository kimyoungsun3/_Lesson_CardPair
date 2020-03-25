using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step03 { 


	public class Array01 : MonoBehaviour
	{
		public List<GameObject> listCard = new List<GameObject>();
		public GameObject prefabCard;
			
		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				//생성후 넣기...
				CardData _card = new CardData();
				_card.id		= Random.Range(0, 13 * 4);
				_card.sprite	= Resources.Load<Sprite>("CardSets/" + _card.id);

				GameObject _go	= Instantiate(prefabCard, Random.onUnitSphere, Quaternion.identity);
				Card _scpCard	= _go.GetComponent<Card>();
				_scpCard.Init(_card);

				listCard.Add(_go);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if(listCard.Count > 0)
					listCard.RemoveAt(0);
			}
		}
	}
}