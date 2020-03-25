using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
	public class Ui_GameOver : MonoBehaviour
	{
		#region singletone
		public static Ui_GameOver ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion


		public Text txtScore;


		public void DisplayData()
		{
			txtScore.text = UserData.ins.score.ToString();
		}

		public void Invoke_ToMenu()
		{
			GameManager.ins.Branch_ToMenu();
		}

		public void Invoke_ToRound()
		{
			GameManager.ins.Branch_ToRound();
		}
	}
}