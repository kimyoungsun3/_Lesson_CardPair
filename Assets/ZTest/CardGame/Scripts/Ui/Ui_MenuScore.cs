using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CardGame
{
	public class Ui_MenuScore : MonoBehaviour
	{
		public static Ui_MenuScore ins;
		[SerializeField] Text textMenuScore;

		private void Awake()
		{
			ins = this;
		}


		public void SetScore(int _score)
		{
			textMenuScore.text = _score.ToString();
		}
	}
}
