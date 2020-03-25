using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	public class EnumTest : MonoBehaviour
	{
		//public enum eGameState2 { Menu, Round, Gaming, Result };
		//public eGameState2 gamestate;
		//public eGameState gamestate22;
		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				SaveData();
			}else if (Input.GetKeyDown(KeyCode.R))
			{
				ReadData();
			}

			//switch (gamestate)
			//{
			//	case eGameState2.Menu: Debug.Log("Menu"); break;
			//	case eGameState2.Round: Debug.Log(gamestate); break;
			//	case eGameState2.Gaming: Debug.Log((int)gamestate); break;
			//}
		}

		public int x, y, z,tt;
		public string ss;
		public float k = 0.5f;
		void SaveData()
		{
			string _data = "@1:" + x
				+ "@2:" + y
				+ "@3:" + z
				+ "@4:" + tt
				+ "@11:" + ss
				+ "@22:" + k;
			Debug.Log(_data);
			PlayerPrefs.SetString("ttt", _data);
			PlayerPrefs.Save();
		}

		public int x2, y2, z2, tt2;
		public string ss2;
		public float k2;
		void ReadData()
		{
			string _data = PlayerPrefs.GetString("ttt", "");
			string[] _arr = _data.Split('@');
			Debug.Log(_data);
			for(int i = 0; i < _arr.Length; i++)
			{
				if (string.IsNullOrEmpty(_arr[i])) continue;
				//Debug.Log(_arr[i]);
				string[] _arr2 = _arr[i].Split(':');
				int _lvnum = int.Parse(_arr2[0]);
				switch (_lvnum)
				{
					case 1: x2 = int.Parse(_arr2[1]); break;
					case 2: y2 = int.Parse(_arr2[1]); break;
					case 3: z2 = int.Parse(_arr2[1]); break;
					case 4: tt2 = int.Parse(_arr2[1]); break;
					case 11: ss = _arr2[1]; break;
					case 22: k2 = float.Parse(_arr2[1]); break;
				}
				//Debug.Log(i + " >> " + _arr[i]);
			}
		}
	}
}
