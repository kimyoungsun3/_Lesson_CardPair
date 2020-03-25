using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace CardGame
{
	public static class CSVReader
	{
		static string SPLIT_RE		= @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
		static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
		static char[] TRIM_CHARS	= { '\"' };

		public static void ReadAndParse(Dictionary<int, StageTable> _dic, string file)
		{
			StageTable _stage;
			string _value;
			TextAsset _asset = Resources.Load(file) as TextAsset;

			string[] _lines = Regex.Split(_asset.text, LINE_SPLIT_RE);
			if (_lines.Length <= 1) return;

			//string[] _headers = Regex.Split(_lines[0], SPLIT_RE);
			for (int i = 1, imax = _lines.Length; i < imax; i++)
			{
				string[] _values = Regex.Split(_lines[i], SPLIT_RE);
				if (_values.Length == 0 || _values[0] == "") continue;

				_stage = new StageTable();
				for (int j = 0; j < _values.Length; j++)
				{
					_value = _values[j];
					_value = _value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
					//Debug.Log(i + ", " + j + ">>" + _value);
					switch (j)
					{
						case 0: _stage.stage	= int.Parse(_value); break;
						case 1: _stage.col		= int.Parse(_value); break;
						case 2: _stage.row		= int.Parse(_value); break;
						case 3: _stage.time		= int.Parse(_value); break;
						case 4: _stage.bonus	= int.Parse(_value); break;
						case 5: _stage.sizeX	= float.Parse(_value); break;
						case 6: _stage.sizeY	= float.Parse(_value); break;
					}
				}
				_dic.Add(_stage.stage, _stage);
			}
		}
	}
}
