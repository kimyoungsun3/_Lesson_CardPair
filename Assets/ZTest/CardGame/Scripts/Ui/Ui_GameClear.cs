using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
	public class Ui_GameClear : MonoBehaviour
	{
		#region singletone
		public static Ui_GameClear ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion


		public Text txtBonus;
		public Text txtTimeBonus;
		public Text txtLevelBonus;
		public Text txtTotal;
		public GameObject goNext;


		public void Invoke_NextRound()
		{
			GameManager.ins.Branch_ToRound();
		}

		public void DisplayData()
		{
			StartCoroutine(Co_DiplayInfo());
		}

		IEnumerator Co_DiplayInfo()
		{
			WaitForSeconds _wait = new WaitForSeconds(0.5f);
			txtBonus.gameObject.SetActive(false);
			txtTimeBonus.gameObject.SetActive(false);
			txtLevelBonus.gameObject.SetActive(false);
			txtTotal.gameObject.SetActive(false);
			goNext.SetActive(false);

			txtBonus.gameObject.SetActive(true);
			txtBonus.text		= UserData.ins.clearScore.ToString();
			yield return _wait;


			txtTimeBonus.gameObject.SetActive(true);
			txtTimeBonus.text	= UserData.ins.timeScore.ToString();
			yield return _wait;

			txtLevelBonus.gameObject.SetActive(true);
			txtLevelBonus.text	= UserData.ins.levelScore.ToString();
			yield return _wait;

			txtTotal.gameObject.SetActive(true);
			txtTotal.text		= UserData.ins.totalScore.ToString();
			yield return _wait;

			goNext.SetActive(true);
		}
	}
}