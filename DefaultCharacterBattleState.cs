using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: basic script to create a default character battle state class
//----------------------------------------------------------------------------------------

//can use as abstract later...unity doesn't seem to like it right now
public abstract class DefaultCharacterBattleState : MonoBehaviour 
{

	Animator animator;

	private float walkSpeed = 1f; // player left/right walk speed
	//some flags to check when certain animations are playing
	private Vector3 mousePosition;
	private Vector3 collLocation; //collider position
	private Vector3 screenPos;

	//default state
	private int _currentAnimationState;
	//last state 
	private int _lastAnimationState;
	//to set default direction
	string _currentDirection;

	// Use this for initialization
	void Start () 
	{
		//define the animator attached to the player
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//gets location  of mouse and saves as variable
		screenPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//casts a ray to var screenPos to see if any colliders are hit
		RaycastHit2D hit;
	}

	//called when mouse button pressed
	void OnMouseDown()
	{
		//wallking Player object will follow mouse when click held down
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, walkSpeed);
	}

	// Change the players animation state
	void changeState(int state)
	{
		//getting last state before it switches
		_lastAnimationState = state;

		if (_currentAnimationState == state)
			return;

		switch (state)
		{
		}
		_currentAnimationState = state;
	}

	void changeDirection(string direction)
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