using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	[System.Serializable]
	public class StageTable
	{
		public int stage;
		public int col, row;
		public int time;
		public int bonus;
		public float sizeX, sizeY;

		public int count {
			get { return col * row; }
		}
		
		public string ToString()
		{
			return
				"stage:" + stage
				+ " col:" + col
				+ " row:" + row
				+ " time:" + time
				+ " bonus:" + bonus
				+ " sizeX:" + sizeX
				+ " sizeY:" + sizeY
				;
		}
	}
}
