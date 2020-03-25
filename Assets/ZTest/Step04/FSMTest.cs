using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMTest : MonoBehaviour
{
	public enum eGameState { None, Menu, Round, Gaming, Result};
	public eGameState beforestate;
	public eGameState gamestate;
	public eGameState nextstate;

	public GameObject goMenu, goRound, goGaming, goResult;

    void Start()
    {
		nextstate = eGameState.Menu;
		Init_Menu();        
    }

	#region //여기는 메뉴에 필요한것...
	void Init_Menu()
	{
		//상태 전이를 조정...
		//beforestate = gamestate;
		gamestate	= nextstate;
		nextstate	= eGameState.None;

		//작업할것...
		goMenu.SetActive(true);
		goRound.SetActive(false);
		goGaming.SetActive(false);
		goResult.SetActive(false);
	}

	void Modify_Menu()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			nextstate = eGameState.Round;
			Init_Round();
			return;
		}
		Debug.Log("Modify_Menu");
	}
	#endregion

	#region //Round 필요한것.
	void Init_Round()
	{
		//상태 전이를 조정...
		//beforestate = gamestate;
		gamestate = nextstate;
		nextstate = eGameState.None;

		//menu -> round
		goMenu.SetActive(false);
		goRound.SetActive(true);
	}

	void Modify_Round()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			nextstate = eGameState.Gaming;
			Init_Gaming();
			return;
		}
		Debug.Log("Modify_Round");
	}
	#endregion

	#region //Gaming 필요한것.
	void Init_Gaming()
	{
		//상태 전이를 조정...
		//beforestate = gamestate;
		gamestate = nextstate;
		nextstate = eGameState.None;

		goRound.SetActive(false);
		goGaming.SetActive(true);

	}

	void Modify_Gaming()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			nextstate = eGameState.Result;
			Init_Result();
			return;
		}
		Debug.Log("Modify_Gaming");

	}
	#endregion

	#region //Result 필요한것.
	void Init_Result()
	{
		//상태 전이를 조정...
		//beforestate = gamestate;
		gamestate = nextstate;
		nextstate = eGameState.Menu;

		goGaming.SetActive(false);
		goResult.SetActive(true);
	}

	void Modify_Result()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
			Init_Menu();
			return;
		}
		Debug.Log("Modify_Result");
	}
	#endregion


	// Update is called once per frame
	void Update()
    {
		switch (gamestate)
		{
			case eGameState.Menu: Modify_Menu(); break;
			case eGameState.Round: Modify_Round(); break;
			case eGameState.Gaming: Modify_Gaming(); break;
			case eGameState.Result: Modify_Result(); break;
		}
    }
}
