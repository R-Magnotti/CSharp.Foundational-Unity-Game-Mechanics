using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: behavior script to control character movement via mouse clicks controls (using 
//	screentoworldpoint and NOT raycasting) for 
//	WHEN NOT IN BATTLE MODE
//----------------------------------------------------------------------------------------

public class PlayerTouchController : MonoBehaviour
{
	private Vector3 target; // The point user picks for the character to follow
	private Vector3 mousePos;
	private bool facingRight = false; // Check where the character is facing
	private int move; // Movement direction
	private float maxSpeed = 5f; // Speed of character movement
	private Animator anim; // Reference to the animator
	private Rigidbody2D movement;
	public bool collision;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		move = 0;
		//need to set initial target position so player doesn't move to default target pos of (0,0,0)
		target = transform.position;
		collision = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Input.GetMouseButton(0))
		{
			// After user has clicked left mouse button recording mouse position
			mousePos = Input.mousePosition;

			// Converting mouse position into coordinate system connected to the camera.
			target = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 1f));

			// Set movement direction depending on target point
			if (target.x < transform.position.x) 
			{
				move = -1;
			} 

			else if (target.x > transform.position.x) 
			{
				move = 1;
				Debug.Log (move);
			}
		}

		// Flip the character if nessessary
		if (move == 1 && !facingRight) 
		{
			Flip ();
		}

		else if (move == -1 && facingRight) 
		{
			Flip ();
		}

		// check if arrived to target point
		if (Mathf.Abs (target.x - transform.position.x) < 0.2f)     
		{
			move = 0;
		}

		//if player reaches targer
		if (transform.position == target)
		{
			anim.SetInteger ("State", 2);
		}

		//if player hasn't reached target and also hasn't collided
		else if (transform.position != target && collision == false) 
		{
			anim.SetInteger ("State", 1); 
		}

		//if player has collided but user still holds click
		else if(Input.GetMouseButton(0) && collision == true)
		{
			anim.SetInteger ("State", 1); 
		}

		PlayerMove ();
	}
		

	//when player collider touches another collider, he stops running animation
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("Collision Enter!!");
		anim.SetInteger ("State", 2);
		collision = true;

		target = transform.position;
		PlayerMove ();

		if(coll.gameObject.tag == "Enemy")
		{
			Debug.Log ("Loading Level");
			SceneManager.LoadScene ("2.BattleScene(TurnBased)");
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		Debug.Log ("Collision Stay");
		collision = true;
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		Debug.Log ("Collision Exit!!");
	}

	private void PlayerMove()
	{
		// apply velocity to actually make character move
		transform.position = Vector3.MoveTowards(transform.position /*currentPos*/, target/*targetPos*/, .2f/*movement speed*/);
	}

	private void Flip()
	{
		Debug.Log ("In Flip");
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

