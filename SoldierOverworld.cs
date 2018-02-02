using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: script to create NPC moving around in overworld (buggy/doesn't work quite right)
//----------------------------------------------------------------------------------------

public class SoldierOverworld : MonoBehaviour 
{

	Animator animator;
	private int _currentAnimationState;

	const int STATE_IDLE = 0;
	const int STATE_MOVE_L = 1;
	const int STATE_STOP_L = 2;
	const int STATE_MOVE_R = 3;
	const int STATE_STOP_R = 4;

	private IEnumerator coroutine;

	private int rand;

	private bool speaking;

	// Use this for initialization
	void Start () 
	{
		//define the animator attached to the player
		animator = GetComponent<Animator>(); 

		_currentAnimationState = STATE_IDLE;

		InvokeRepeating ("Move", 2f, 4.0f);

		coroutine = AnimChecker ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
	}

	private  IEnumerator AnimChecker()
	{
		Debug.Log ("Coroutine in progress");
		while(animator.GetCurrentAnimatorStateInfo(0).IsName("Soldier_L"))
		{
			Debug.Log ("Animation in progress");
			yield return null;
		}

		Debug.Log ("Coroutine + Animation Finished");
		ChangeState (STATE_STOP_L);
		Debug.Log (animator.GetCurrentAnimatorStateInfo(0).IsName("Soldier_L"));
	}

	private void Move()
	{
		Debug.Log ("Move was called");
		//random number
		//rand = Random.Range(0,5);

		//if random number x then move left
		ChangeState (STATE_MOVE_L);

		Debug.Log ("animation is happening " + animator.GetCurrentAnimatorStateInfo (0).IsName ("Soldier_L"));

		StartCoroutine (coroutine);

		//if random number y then move right
	}

	/*
	 *-----------------------------------------------------------------------------------------------------
	 * Change Animation State
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

		case STATE_MOVE_L:
			animator.SetInteger ("State", STATE_MOVE_L);
			break;

		case STATE_STOP_L:
			animator.SetInteger ("State", STATE_STOP_L);
			break;

		case STATE_MOVE_R:
			animator.SetInteger ("State", STATE_MOVE_L);
			break;
		}
		_currentAnimationState = state;
	}
}