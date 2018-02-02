using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: basic script to create a state machine for a battle system 
//----------------------------------------------------------------------------------------

public class BattleStateMachine : MonoBehaviour 
{
	public BattleStates currentState; //called to check current state
	//create an array with i slots equal to amount of enemies in battle (to use for combat)

	GameObject player;
	GameObject enemy;

	private int maxAttack;

	private bool _hasBeenPressed = false;
	private bool _hasAddedXP = false;
	private bool _canMovePlayer = false;

	//turns remaining until enemy will perform special
	public float turnsTillSpecial = 3;
	public bool _canMoveEnemy = false;

	public enum BattleStates
	{
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN
	}

	// Use this for initialization
	void Start () 
	{
		enemy = GameObject.FindWithTag ("Enemy");
		player = GameObject.Find ("Palyer"); 

		//disable player movement while not their turn
		player.GetComponent<PlayerTouchBattle>().enabled = false;
		player.GetComponent<PlayerTouchBattleAlter> ().enabled = false;
	
		//_hasAddedXP = false;

		currentState = BattleStates.START;	
	}
	
	void Update () 
	{	
		Debug.Log (currentState);

		//this needs to be in Update to function 
		maxAttack = player.GetComponent<BattleInfoHolder> ().GetMaxAttack();

		switch (currentState) 
		{
		case (BattleStates.START):
			//start = true;
			//setup battle (enemy, HUD)
			//if parameter rec'd = "battleState" == done, move to next state

			break;

		case (BattleStates.PLAYERCHOICE):
			//re-enable player collider so player can move again
			player.GetComponent<PlayerTouchBattle> ().enabled = true;
			player.GetComponent<PlayerTouchBattleAlter> ().enabled = true;

			if (maxAttack == 0) 
			{
				player.GetComponent<PlayerTouchBattle> ().enabled = false;
				player.GetComponent<PlayerTouchBattleAlter> ().enabled = false;

				currentState = BattleStates.ENEMYCHOICE;
				Debug.Log ("Moving to Enemy Choice");
			}

			break;

		case (BattleStates.ENEMYCHOICE): //we get to here successfully!!!!! :D
			_canMovePlayer = false;

			//resetting max amount of player attacks
			player.GetComponent<BattleInfoHolder> ().SetMaxAttack(10);

			Debug.Log ("Now it's Enemy Turn");

			//enable enemy script

			break;

		case (BattleStates.LOSE):
			break;

		case (BattleStates.WIN):
			if (!_hasAddedXP) //to add xp only if it hasn't already been added 
			{
				IncreaseExperience.AddExperiencce ();

				_hasAddedXP = true;
			}
			break;
		}
}

	public void RecieveFlag(bool _canMoveEnemy)
	{
		this._canMoveEnemy = _canMoveEnemy;

		currentState = BattleStates.PLAYERCHOICE;

	}

	void OnGUI()
	{
		//no need to call OnGUI. Unity will call when following conditions met
		if (currentState == BattleStates.START) 
		{
			if (!_hasBeenPressed) 
			{
				if (GUI.Button (new Rect (Screen.width / 2 /* x */, Screen.height / 2 /* y */, 500 /* w */, 300 /* h */), "Click to Start!")) 
				{
					Debug.Log ("In Start State");

					currentState = BattleStates.PLAYERCHOICE;

					_hasBeenPressed = true;
				}
			}

			_hasBeenPressed = false;
		}

		else if (currentState == BattleStates.ENEMYCHOICE)
		{
			GUILayout.Label ("Enemy Choice");
		}
		else if (currentState == BattleStates.LOSE)
		{
			GUILayout.Label ("You Lost :(");
		}

		else if (currentState == BattleStates.WIN)
		{
			GUILayout.Label ("YOU WON! :D");
		}
	}
}
