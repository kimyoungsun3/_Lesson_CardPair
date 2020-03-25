using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
	[System.Serializable]
	public class UserData : MonoBehaviour
	{
		public static UserData ins;

		public int stage = 1;

		private int score_;
		public int score {
			get { return score_; }
			set	{ score_ = value; }
		}

		public int bestScore;
		public int totalScore, clearScore, timeScore, levelScore;

		public void Awake()
		{
			ins = this;
		}

		public void ReadData()
		{
			string _data = PlayerPrefs.GetString("data", "");
			string[] _d = _data.Split('@');
			if (_d.Length <= 0)
			{
				stage		= 1;
				bestScore	= 0;
			}
			else
			{
				Vector2Int _kv;
				for(int i = 0; i < _d.Length; i++)
				{
					_kv = GetData(_d[i]);
					switch (_kv.x)
					{
						case 1: stage		= _kv.y; break;
						case 2: bestScore	= _kv.y; break;
					}
				}
				if (stage < 1) stage = 1;
			}

			//Debug.Log(" >> Data Read stage:" + stage + " bestScore:" + bestScore);
		}

		public Vector2Int GetData(string _data)
		{
			string[] _split = _data.Split(':');
			if (_split.Length != 2) return Vector2Int.zero;

			int _kind	= int.Parse(_split[0]);
			int _value	= int.Parse(_split[1]);
			return new Vector2Int(_kind, _value);
		}

		public void CalculateData()
		{
			//다음 스테이지 정보 확인하기..
			//1 -> 2 -> .... max  이면 더이상 안간다...
			stage++;
			if (!GameData.ValidateStageTable(stage))
			{
				stage--;
			}

			//스코어 정보 ...
			clearScore	= CardManager.ins.stageTable.bonus;
			timeScore	= CardManager.ins.stageTable.bonus * CardManager.ins.GetRemainTime();
			levelScore	= CardManager.ins.stageTable.bonus * CardManager.ins.stageTable.stage;
			totalScore += score + clearScore + timeScore + levelScore;
			if (totalScore > bestScore)
			{
				bestScore = totalScore;
			}

			//데이타 세이브 하기..
			SaveData();
		}

		//1 : stage
		//2 : bestScore
		public void SaveData()
		{
			if (stage < 1) stage = 1;

			string _data = "@1:" + stage;
			_data		+= "@2:" + bestScore;
			Debug.Log(" >> Data Save:" + _data);

			PlayerPrefs.SetString("data", _data);
			PlayerPrefs.Save();
		}
	}

}