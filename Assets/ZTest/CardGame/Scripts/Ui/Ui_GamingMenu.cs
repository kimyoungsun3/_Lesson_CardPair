using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
	public class Ui_GamingMenu : MonoBehaviour
	{
		#region sigletone
		public static Ui_GamingMenu ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion

		[SerializeField] Text txtStage;
		[SerializeField] Text txtTime;
		[SerializeField] Text txtScore;


		public void DisplayStage(int _stage)
		{
			txtStage.text = _stage.ToString();
		}

		public void DisplayTime(float _remain){ txtTime.text = _remain.ToString(); }
		public void DisplayTime(int _remain){	txtTime.text = _remain.ToString();}
		public void DisplayTime(string _remain) { txtTime.text = _remain; }

		public void DisplayScore(int _score)
		{
			txtScore.text = _score.ToString();
		}

	}
}