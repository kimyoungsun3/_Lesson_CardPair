using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleTest : MonoBehaviour
{
	public static SingleTest ins;

	private void Awake()
	{
		Debug.Log(this);
		
		if (ins != null)
		{
			Destroy(gameObject);
			return;
		}
		ins = this;
		DontDestroyOnLoad(gameObject);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void Fun1()
	{

		Debug.Log("Fun1" + this);
	}
	public void Fun2()
	{
		Debug.Log("Fun2" + this);
	}
	public void Fun3()
	{
		Debug.Log("Fun3" + this);
	}

}
