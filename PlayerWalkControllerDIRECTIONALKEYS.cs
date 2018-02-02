using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: behavior script to control player movement **WITH DIRECTIONAL KEYS** for
//	simplicity to bug test all other game mechanics
//----------------------------------------------------------------------------------------

public class PlayerControllerOverWorld : MonoBehaviour 
{
	Animator animator;

	//to specify what state to change to
	private float walkSpeed = 5f; // player left/right walk speed
	//some flags to check when certain animations are playing
	private Vector3 mousePosition;
	private Vector3 collLocation; //collider position
	private Vector3 screenPos;
	//camera is object of, and thus follows position of, player by inspector heirarchy in GUI
	private Vector3 camObj; //camera position (if needed)

	//animation state transitions - the values in the animator conditions
	//"const" meaning these values CANNOT be changed
	const int STATE_IDLE = 0; //default state
	const int STATE_MOVE_LEFT = 1;
	const int STATE_MOVE_RIGHT = 2;
	const int STATE_MOVE_UP = 3;
	const int STATE_MOVE_DOWN = 4;
	const int STATE_STOP_L = 5;
	const int STATE_STOP_R = 6;
	const int STATE_STOP_U = 7;
	const int STATE_STOP_D = 8;
	const int STATE_HIT1 = 9;
	const int STATE_HIT1_STOP = 10;
	const int STATE_HIT2 = 11;

	//default state
	private int _currentAnimationState;
	private bool canSpeak1;

	//flags to fix issue of simultaneous direction animation loop
	private bool canX;
	private bool canL;
	private bool _1hit;
	private bool _2hit;

	// Use this for initialization
	void Start ()
	{
		//define the animator attached to the player
		animator = GetComponent<Animator> (); 

		canSpeak1 = false;
		_currentAnimationState = STATE_IDLE;
		canX = true;
		canL = true;

		_1hit = false;
		_2hit = false;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Hit1");

			ChangeState (STATE_HIT1);

			transform.Translate(Vector2.left * 7.5f * Time.deltaTime);

			_1hit = true;
		}

		else if(Input.GetKeyDown(KeyCode.Space) && _1hit == true)
		{
			Debug.Log ("Hit2");

			ChangeState (STATE_HIT2);

			transform.Translate(Vector2.left * 7.5f * Time.deltaTime);

			_2hit = true;
		}

		else if(Input.GetKeyUp(KeyCode.Space))
		{
			Debug.Log ("Hit End");

			ChangeState (STATE_HIT1_STOP);
		}

		/*-----LEFT-------------------------------------------------*/
		//start moving left
		else if (Input.GetKey (KeyCode.LeftArrow) && canX == true && canL == true)
		{
			//Debug.Log ("Moved left");

			ChangeState (STATE_MOVE_LEFT);

			//don't need to specify sprite being transformed because this will affect the attached object by default
			transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
		}

		//stop moving left
		else if (Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			//Debug.Log ("Stopped Moving Left");

			ChangeState (STATE_STOP_L);
		}

		/*-----RIGHT-------------------------------------------------*/
		//start moving right
		else if (Input.GetKey (KeyCode.RightArrow) && canX == true) 
		{
			//Debug.Log ("Moved right");

			ChangeState (STATE_MOVE_RIGHT);

			transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

			canL = false;
		}

		//stop moving right
		else if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			//Debug.Log ("Stopped Moving Right");

			ChangeState (STATE_STOP_R);

			canL = true;
		}
		/*-----UP----------------------------------------------------*/
		//start moving up
		else if (Input.GetKey (KeyCode.UpArrow)) 
		{
			//Debug.Log ("Moved up");

			ChangeState (STATE_MOVE_UP);

			transform.Translate(Vector2.up * walkSpeed * Time.deltaTime);

			canX = false;
		}

		//stop moving up
		else if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			//Debug.Log ("Stopped Moving Up");

			ChangeState (STATE_STOP_U);

			canX = true;
		}

		/*-----DOWN--------------------------------------------------*/

		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			//Debug.Log ("Moved down");

			ChangeState (STATE_MOVE_DOWN);

			transform.Translate(Vector2.down * walkSpeed * Time.deltaTime);

			canX = false;
		}

		//stop moving down
		else if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			//Debug.Log ("Stopped Moving Down");
		
			ChangeState (STATE_STOP_D);

			canX = true;
		}

		//if collision, can speak with collidee
		else if(Input.GetKeyDown(KeyCode.Return) && canSpeak1 == true)
		{
			//Debug.Log("Can Speak to NPC in Update: " + canSpeak1);
		}

		//idle
		else
		{
			//Debug.Log ("Idle");

			ChangeState (STATE_IDLE);

			return;
   		}
	}

	//called every frame immediately after Update()
	void LateUpdate() 
	{}

	//accepts collision2D variable--NOT collider2D!!
	void OnTriggerEnter2D(Collider2D enemyColl)
	{
		if (enemyColl.gameObject.tag == "Enemy") 
		{
			Debug.Log ("Collision");

			canSpeak1 = true;

			Debug.Log ("Collision Detected " + canSpeak1); //should yield true
		}
	}

	void OnTriggerExit2D(Collider2D enemyColl)
	{
		if(enemyColl.gameObject.tag == "Enemy")
		{
			Debug.Log("Exit Collision");

			canSpeak1 = false;
		}	
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Change Animation State & Direction
	 *-----------------------------------------------------------------------------------------------------
	*/

	// Change the players animation state
	void ChangeState(int state)
	{
		if (_currentAnimationState == state)
			return;

		switch (state)
		{
		case STATE_IDLE:
			animator.SetInteger ("State", STATE_IDLE);
			break;

		case STATE_MOVE_LEFT:
			animator.SetInteger ("State",STATE_MOVE_LEFT);
			break;

		case STATE_STOP_L:
			animator.SetInteger ("State",STATE_STOP_L);
			break;

		case STATE_MOVE_RIGHT:
			animator.SetInteger ("State", STATE_MOVE_RIGHT);
			break;

		case STATE_STOP_R:
			animator.SetInteger ("State",STATE_STOP_R);
			break;

		case STATE_MOVE_UP:
			animator.SetInteger ("State", STATE_MOVE_UP);
			break;

		case STATE_STOP_U:
			animator.SetInteger ("State",STATE_STOP_U);
			break;

		case STATE_MOVE_DOWN:
			animator.SetInteger ("State", STATE_MOVE_DOWN);
			break;

		case STATE_STOP_D:
			animator.SetInteger ("State",STATE_STOP_D);
			break;

		case STATE_HIT1:
			animator.SetInteger ("State", STATE_HIT1);
			break;

		case STATE_HIT1_STOP:
			animator.SetInteger ("State", STATE_HIT1_STOP);
			break;
		}
		_currentAnimationState = state;
	}
}