using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
	private void Awake()	{
		Debug.Log(this + " Awake");
	}

	private void OnEnable()	{
		Debug.Log(this + " OnEnable");
	}

	//---------------------------------------
	void Start()
	{
		Debug.Log(this + " Start");
	}

	////---------------------------------------
	//private void FixedUpdate()	{
	//	Debug.Log(this + " FixedUpdate");
	//}

	//void Update()	{
	//	Debug.Log(this + " Update");
	//}

	//void LateUpdate()	{
	//	Debug.Log(this + " LateUpdate");
	//}

	//---------------------------------------
	private void OnDisable()	{
		Debug.Log(this + " OnDisable");
	}
}
