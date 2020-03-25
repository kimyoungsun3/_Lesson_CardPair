using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	public class Ui_Start : MonoBehaviour
	{
		public void Invoke_MenuToRound()
		{
			GameManager.ins.Branch_ToRound();
		}
	}
}
