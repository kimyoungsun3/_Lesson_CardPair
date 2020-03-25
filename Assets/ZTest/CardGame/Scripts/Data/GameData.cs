using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	public static class GameData
	{
		public static Dictionary<int, StageTable> dic_StageTable = new Dictionary<int, StageTable>();


		public static void ReadStageTable()
		{
			if (dic_StageTable.Count > 0)
				return;
			CSVReader.ReadAndParse(dic_StageTable, "StageTablevNew");

			//foreach (KeyValuePair<int, StageTable> _data in dic_StageTable)
			//{
			//	Debug.Log(_data.Key + ":" + _data.Value.ToString());
			//}
		}

		public static StageTable GetStageTable(int _stage)
		{
			StageTable _stageTable = null;
			if (dic_StageTable.ContainsKey(_stage))
			{
				_stageTable = dic_StageTable[_stage];
			}
			return _stageTable;
		}

		public static bool ValidateStageTable(int _stage)
		{
			return dic_StageTable.ContainsKey(_stage);
		}
	}
}