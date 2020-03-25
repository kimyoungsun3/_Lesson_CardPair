using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle4 : MonoBehaviour
{
	private void Awake()	{
		Debug.Log(this + " Awake3");
	}

	private void OnEnable()	{
		Debug.Log(this + " OnEnable3");
	}

	//---------------------------------------
	void Start()
	{
		Debug.Log(this + " Start3");
	}

	//---------------------------------------
	private void FixedUpdate()
	{
		Debug.Log(this + " FixedUpdate3 " + Time.deltaTime);
	}

	void Update()
	{
		Debug.Log(this + " Update3 " + Time.deltaTime);
	}

	void LateUpdate()
	{
		Debug.Log(this + " LateUpdate3 " + Time.deltaTime);
	}

	//---------------------------------------
	private void OnDisable()	{
		Debug.Log(this + " OnDisable3");
	}
}
