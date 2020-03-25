using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame
{
	public enum eGameState { None, Menu, Round, Gaming, Result};
	public enum eResultType { Fail, Success };
	public class GameManager : MonoBehaviour
	{
		public static GameManager ins;
		public eGameState beforestate;
		[HideInInspector] public eGameState gameState;
		[HideInInspector] public eGameState nextState;
		eResultType resultType;

		[Header("Menu Score")]
		public GameObject goMenuRoot;
		public GameObject goMenuCanvas;

		[Header("Game Score")]
		public GameObject goGameRoot;
		public GameObject goGameCanvas;
		[SerializeField] BackGroundGaming backGroundGaming;

		[Header("Game Score")]
		float gamingTime;
		[SerializeField] GameObject goClear, goOver;

		void Awake()
		{
			ins = this;
		}

		private void Start()
		{
			//gameObject
			//transform

			beforestate = eGameState.None;
			gameState	= eGameState.None;
			nextState	= eGameState.Menu;
			Init_Menu();
		}

		//게임을 종료할떄 강제로 저장한다...
		public void OnApplicationQuit()
		{
			UserData.ins.SaveData();
		}


		#region Menu...
		private void Init_Menu()
		{
			//상태 전이...
			beforestate		= gameState;
			gameState		= nextState;
			nextState		= eGameState.None;

			//메뉴상태 준비하기, 게임중인 메뉴는 자동으로 꺼지게 해주라..
			goMenuRoot.SetActive(true);
			goMenuCanvas.SetActive(true);

			goGameRoot.SetActive(false);
			goGameCanvas.SetActive(false);
			goClear.SetActive(false);
			goOver.SetActive(false);

			//Sound Player...
			AudioManager.ins.bSound = true;
			AudioManager.ins.PlayBGM();

			if (beforestate == eGameState.None)
			{
				//Stage Data Read...
				GameData.ReadStageTable();

				//Read user data
				UserData.ins.ReadData();

				//CardData Read
				CardManager.ins.ReadResource();
			}
			Ui_MenuScore.ins.SetScore(UserData.ins.bestScore);
		}

		public void Branch_ToMenu()
		{
			nextState = eGameState.Menu;
		}

		void Modify_Menu()
		{
			//1. 키이벤트받기.
			//2. 조건
			if (nextState != eGameState.None)
			{
				switch (nextState)
				{
					case eGameState.Round:
						UserData.ins.totalScore = 0;
						Init_Round();
						break;
				}				
				return;
			}

			//3. 연산 

			//4. 출력
		}
		#endregion //Menu...

		#region Round...
		float roundTime;
		private void Init_Round()
		{
			//상태 전이...
			beforestate = gameState;
			gameState	= nextState;
			nextState	= eGameState.None;

			//Menu -> 모든 오브젝트 비활성화
			goMenuRoot.SetActive(false);
			goMenuCanvas.SetActive(false);

			goGameRoot.SetActive(true);
			goGameCanvas.SetActive(true);
			backGroundGaming.SetBackgroundSprite();

			//현재 스테이지 정보에 따른 카드 구성하기...
			CardManager.ins.ReadyBoard();
			CardManager.ins.BoardStripAndWear(false);
			Ui_GamingMenu.ins.DisplayStage(CardManager.ins.stage);
			UserData.ins.score = 0;
			Ui_GamingMenu.ins.DisplayScore(UserData.ins.score);

			//2~3초 정도 인지하게 한다...
			roundTime = Time.time + 2f;
		}

		public void Branch_ToRound()
		{
			nextState = eGameState.Round;
		}

		void Modify_Round()
		{
			//1. 키이벤트받기.

			//2. 조건
			if ( Time.time > roundTime)
			{
				nextState = eGameState.Gaming;
				Init_Gaming();
				return;
			}
			else if (nextState != eGameState.None)
			{
				switch (nextState)
				{
					case eGameState.Menu: Init_Menu(); break;
				}
				return;
			}

			//3. 연산 

			//4. 출력
		}
		#endregion //Round...


		#region Gaming...
		private void Init_Gaming()
		{
			//상태 전이...
			beforestate = gameState;
			gameState	= nextState;
			nextState	= eGameState.None;

			CardManager.ins.BoardStripAndWear(true);
			CardManager.ins.StartTime();

		}



		void Modify_Gaming()
		{
			//1. 키이벤트받기.
			Ui_GamingMenu.ins.DisplayTime(CardManager.ins.remainTime);
			
			//2. 조건
			if (CardManager.ins.isTimeOver)
			{
				nextState	= eGameState.Result;
				resultType	= eResultType.Fail;
				Init_Result();
				return;
			}
			else if (CardManager.ins.isClear)
			{
				nextState	= eGameState.Result;
				resultType	= eResultType.Success;
				Init_Result();
				return;
			}
			else if (nextState != eGameState.None)
			{
				switch (nextState)
				{
					case eGameState.Menu: Init_Menu(); break;
				}
				return;
			}


			//3. 연산 

			//4. 출력

		}
		#endregion //Gaming...

		#region Result...
		private void Init_Result()
		{
			//상태 전이...
			beforestate	= gameState;
			gameState	= nextState;
			nextState	= eGameState.None;

			//Debug.Log(resultType);
			if (resultType == eResultType.Success)
			{
				goClear.SetActive(true);
				goOver.SetActive(false);

				UserData.ins.CalculateData();
				Ui_GameClear.ins.DisplayData();
			}
			else
			{
				goClear.SetActive(false);
				goOver.SetActive(true);

				Ui_GameOver.ins.DisplayData();
			}
		}

		void Modify_Result()
		{
			//1. 키이벤트받기.

			//2. 조건
			if (nextState != eGameState.None)
			{
				goClear.SetActive(false);
				goOver.SetActive(false);
				switch (nextState)
				{
					case eGameState.Menu:	Init_Menu(); break;
					case eGameState.Round:	Init_Round(); break;
				}
				return;
			}

			//3. 연산 

			//4. 출력
		}
		#endregion //Result...

		void Update()
		{
			//Debug.Log(gameState);
			switch (gameState)
			{
				case eGameState.Menu:
					Modify_Menu();
					break;
				case eGameState.Round:
					Modify_Round();
					break;
				case eGameState.Gaming:
					Modify_Gaming();
					break;
				case eGameState.Result:
					Modify_Result();
					break;
			}
		}
	}
}
