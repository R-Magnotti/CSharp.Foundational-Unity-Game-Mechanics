 using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: behavior script to control the player in battle mode by mouse clicks
//----------------------------------------------------------------------------------------

public class PlayerControllerBattle : MonoBehaviour
{
	Animator animator;
	GameObject player; //player gameobject for use
	CircleCollider2D playerCollider; //player gameobject collider for use
	GameObject enemy;
	CircleCollider2D enemyCollider; //enemy collider for use with player collider 
	BattleStateMachine StateMachine;


//	//to specify what state to change to
//	BattleStateMachine.currentState stateMachineState;

	private float walkSpeed = 1f; // player left/right walk speed
	//some flags to check when certain animations are playing
	private Vector3 mousePosition;
	private Vector3 collLocation; //collider position
	private Vector3 screenPos;

	//animation state transitions - the values in the animator conditions
	//"const" meaning these values CANNOT be changed
	const int STATE_IDLE = 0; //default state
	const int STATE_MAGIC = 1;
	const int STATE_GOT_HIT = 2; 
	const int STATE_TAPPED_MOVE = 3;
	const int STATE_ATTACK = 4;

	//default state
	private int _currentAnimationState = STATE_IDLE;
	//value of last state
	private int _lastAnimationState;
	//to set default direction
	private string _currentDirection = "right";
	private bool _hasMoved = false;
	private bool _hasAttacked = false;
	private bool _hasCollided = false;

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Start
	 *-----------------------------------------------------------------------------------------------------
	*/

	// Use this for initialization
	void Start () 
	{
		//define the animator attached to the player
		animator = GetComponent<Animator>(); 

		StateMachine = new BattleStateMachine();

		//creating reference to player and enemy game objects
		player = GameObject.FindWithTag ("Player");
		playerCollider = player.GetComponent<CircleCollider2D> ();

		enemy = GameObject.FindWithTag ("Enemy");
		enemyCollider = enemy.GetComponent<CircleCollider2D> ();
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * UPDATE
	 *-----------------------------------------------------------------------------------------------------
	*/
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Debug.Log (StateMachine.currentState);
		//gets location  of mouse and saves as variable
		screenPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//casts a ray to var screenPos to see if any colliders are hit
		RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);

		/*if player.choice == true*/

		//if mouse clicks on player (tag) collider, do action
		if (Input.GetMouseButton (0) && hit.collider.CompareTag("Player") && hit.collider != null) 
		{
			MousePress ();
		}

		//**.Istouching REQUIRES RIGIDBODY COMPONENT ON SPRITES TO WORK
		//if player has moved and let go of mouse click, now they attack
		//moves player back once colliders touch to then attack
		else if (playerCollider.IsTouching(enemyCollider) && !Input.GetMouseButton(0))
		{
			Debug.Log ("Collision");

			transform.Translate(-0.05f, 0.0f, 0.0f); //(x,y,z)

			_hasCollided = true;
		}

		else if (!playerCollider.IsTouching(enemyCollider) && _hasCollided == true)
		{
			Debug.Log ("Can Attack");

			PlayerAttack ();

			Debug.Log ("Done with player Attack");
		}

		else if (!Input.GetMouseButton (0) && _hasMoved == true)
		{
			StateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE; //accessing public enum from battle state script
		}

		//else statement for when nothing is being pressed:
		//will revert back to idle state
		else
		{
			Debug.Log ("Default Idle");

			ChangeState(STATE_IDLE);
		}
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * On Mouse Press
	 *-----------------------------------------------------------------------------------------------------
	*/

	//called when mouse button pressed
	void MousePress()
	{
		if (Input.GetAxis ("Mouse X") < 0) 
		{
			Debug.Log ("Mouse moved left");

			ChangeDirection ("left");

			ChangeState (STATE_TAPPED_MOVE);

			_hasMoved = true;
		} 

		else if (Input.GetAxis ("Mouse X") > 0) 
		{
			Debug.Log ("Mouse moved right");

			ChangeDirection ("right");

			ChangeState (STATE_TAPPED_MOVE);

			_hasMoved = true;
		}

		else
		{
			Debug.Log ("Clicked default Idle Right");

			ChangeState (STATE_IDLE);
		}
	
		//wallking Player object will follow mouse when click held down
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, walkSpeed);
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Player Attack
	 *-----------------------------------------------------------------------------------------------------
	*/

	void PlayerAttack()
	{
		Debug.Log ("In Player Attack Mode");

		if (Input.GetKey ("up")) 
		{
			Debug.Log ("Magic Attack");

			ChangeState (STATE_MAGIC);

			_hasCollided = false;
			_hasMoved = false;
			_hasAttacked = true;

			StateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE; //accessing public enum from battle state script

		}

		else if (Input.GetKey("right"))
		{
			Debug.Log ("Melee Attack");

			ChangeState (STATE_ATTACK);

			Debug.Log("Has_Attacked");

			_hasCollided = false;
			_hasMoved = false;
			_hasAttacked = true;

			Debug.Log ("1");
			StateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE; //accessing public enum from battle state script
			Debug.Log ("2");

		}

		Debug.Log ("Leaving Player Attack");
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

			case STATE_TAPPED_MOVE:
				animator.SetInteger ("state", STATE_TAPPED_MOVE);
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