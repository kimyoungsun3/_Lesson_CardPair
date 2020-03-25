using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle2 : MonoBehaviour
{
	private void Awake()	{
		Debug.Log(this + " Awake2");
	}

	private void OnEnable()	{
		Debug.Log(this + " OnEnable2");
	}

	//---------------------------------------
	void Start()
	{
		Debug.Log(this + " Start2");
	}

	////---------------------------------------
	//private void FixedUpdate()	{
	//	Debug.Log(this + " FixedUpdate2");
	//}

	//void Update()	{
	//	Debug.Log(this + " Update2");
	//}

	//void LateUpdate()	{
	//	Debug.Log(this + " LateUpdate2");
	//}

	//---------------------------------------
	private void OnDisable()	{
		Debug.Log(this + " OnDisable2");
	}
}
