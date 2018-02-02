using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: behavior script to control the commands of the enemy AI -- **not working yet/buggy needs tweaking**
//----------------------------------------------------------------------------------------

public class AiBattleState : MonoBehaviour
{
	Animator animator;
	GameObject player; //player gameobject for use
	CircleCollider2D playerCollider; //player gameobject collider for use
	GameObject enemy;
	CircleCollider2D enemyCollider; //enemy collider for use with player collider 
	BattleStateMachine StateMachine;

	//values for use with moving enemy
	private float walkSpeed = 1f; // player left/right walk speed
	private float step;

	//used to find position of player
	private Transform playerTransform;
	//private Vector3 playerPos;

	//random value between [0,1]
	private float randomValue; //no use for right now

	//animation state transitions - the values in the animator conditions
	//"const" meaning these values CANNOT be changed
	const int STATE_IDLE = 0; //default state
	const int STATE_MOVE = 1;
	const int STATE_ATTACK = 2;
	const int STATE_MAGIC = 3;
	const int STATE_GOT_HIT = 4; 

	//default state
	private int _currentAnimationState = STATE_IDLE;
	//value of last state
	private int _lastAnimationState;
	//to set default direction
	private string _currentDirection = "right";
	private bool _hasMoved = false;
	private bool _hasAttacked = false;
	private bool _hasCollided = false;
	public bool canMove;
	public float turnsTillSpecial;

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Start
	 *-----------------------------------------------------------------------------------------------------
	*/

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Enemy Start");

		//define the animator attached to the player
		animator = GetComponent<Animator>(); 

		StateMachine = new BattleStateMachine();

		//creating reference to player and enemy game objects
		player = GameObject.FindWithTag ("Player");
		playerCollider = player.GetComponent<CircleCollider2D> ();

		enemy = GameObject.FindWithTag ("Enemy");
		enemyCollider = enemy.GetComponent<CircleCollider2D> ();

		//playerTransform = GameObject.Find("Enemy").transform;

	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * UPDATE
	 *-----------------------------------------------------------------------------------------------------
	*/

	// Update is called once per frame
	void  FixedUpdate ()
	{
		//playerPos = playerTransform.position;

		if (canMove == true) 
		{
			Debug.Log ("Enemy Can Move");

			ChangeState (STATE_MOVE);

			//move enemy to player then do melee attack
			float step = walkSpeed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, playerPos, step);

			EnemyAttack (turnsTillSpecial);
		}
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Enemy Attack
	 *-----------------------------------------------------------------------------------------------------
	*/

	void EnemyAttack(float turnsLeft)
	{
		Debug.Log ("In Player Attack Mode");

		if (turnsLeft != 0) 
		{
			Debug.Log ("Melee Attack");

			ChangeState (STATE_ATTACK);

			_hasCollided = false;
			_hasMoved = false;
			_hasAttacked = true;

			ChangeState (STATE_IDLE);
			StateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOICE;
		}

		else
		{
			Debug.Log ("Magic Attack");

			ChangeState (STATE_MAGIC);

			_hasCollided = false;
			_hasMoved = false;
			_hasAttacked = true;

			ChangeState (STATE_IDLE);
			StateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOICE;
		}
	}

	//needs to be public to be accessed from other script...private by default
	public void EnemyFlag(bool canMove, float turnsTillSpecial)
	{
		this.canMove = canMove;
		this.turnsTillSpecial = turnsTillSpecial;
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Change Animation State
	 *-----------------------------------------------------------------------------------------------------
	*/

	// Change the players animation state
	void ChangeState(int state)
	{
		//getting last state before it switches
		_lastAnimationState = state;

		if (_currentAnimationState == state)
			return;

		switch (state)
		{
		case STATE_IDLE:
			animator.SetInteger ("state", STATE_IDLE);
			break;

		case STATE_MAGIC:
			animator.SetInteger ("state", STATE_MAGIC);
			break;

		case STATE_MOVE:
			animator.SetInteger ("state", STATE_MOVE);
			break;

		case STATE_ATTACK:
			animator.SetInteger ("state", STATE_ATTACK);
			break;
		}
		_currentAnimationState = state;
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Change Character Direction
	 *-----------------------------------------------------------------------------------------------------
	*/

	void ChangeDirection(string direction)
	{

		if (_currentDirection != direction) 
		{
			if (direction == "right") 
			{
				transform.Rotate (0, 180, 0);
				_currentDirection = "right";
			}

			else if (direction == "left") 
			{
				transform.Rotate (0, -180, 0);
				_currentDirection = "left";
			}
		}
	}
}
