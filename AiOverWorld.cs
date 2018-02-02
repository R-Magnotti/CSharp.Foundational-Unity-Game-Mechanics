using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: behavior script to control the enemy AI when in overworld mode
//----------------------------------------------------------------------------------------

public class AiOverWorld : MonoBehaviour 
{
	
	Animator animator;
	private int _currentAnimationState;

	const int STATE_IDLE = 0;
	const int STATE_STILL = 1;

	private bool speaking;

	// Use this for initialization
	void Start () 
	{
		//define the animator attached to the player
		animator = GetComponent<Animator>(); 

		_currentAnimationState = STATE_IDLE;

		speaking = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(speaking==true /*&& Input.GetKeyDown(KeyCode.Return)*/)
		{
			ChangeState(STATE_STILL);
		}

		else
		{
			ChangeState(STATE_IDLE);
		}
	}

	//accepts collision2D variable--NOT collider2D!!
	void OnTriggerEnter2D(Collider2D playerColl)
	{
		if (playerColl.gameObject.tag == "Player") 
		{
			Debug.Log ("Collision (enemy-side)");
			Debug.Log("Load Combat Scene");

			//SceneManager.LoadScene("Test1",  LoadSceneMode.Additive);

			//speaking = true;

		}
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

		case STATE_STILL:
			animator.SetInteger ("State", STATE_STILL);
			break;
		}
		_currentAnimationState = state;
	}
}