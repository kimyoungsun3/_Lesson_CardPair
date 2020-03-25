using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour
{
    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			Destroy(this);
		}
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			Destroy(gameObject);
		}


		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SingleTest.ins.Fun1();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SingleTest.ins.Fun2();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SingleTest.ins.Fun3();
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SoundTest3.FFF();
		}

	}
}
