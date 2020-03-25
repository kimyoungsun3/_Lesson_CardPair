using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
	public class BackGroundMenu : MonoBehaviour
	{
		public float ScrollSpeed = 0.1f;
		Renderer milkRender = null;

		// Use this for initialization
		void Start()
		{
			milkRender = GetComponent<MeshRenderer>();
		}

		// Update is called once per frame
		void Update()
		{
			milkRender.material.SetTextureOffset("_MainTex", new Vector2(Time.time * ScrollSpeed, 0.0f));
		}
	}
}