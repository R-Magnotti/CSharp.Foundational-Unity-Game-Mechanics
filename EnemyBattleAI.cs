using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: basic script to create a script to control enemy NPC movement
//----------------------------------------------------------------------------------------

public class EnemyBattleAI : MonoBehaviour
{
	private Animator animator; // Reference to the animator
	private Vector3 playerPos; //Get the player/target

	private float moveWait;
	private float nextMovement;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		moveWait = Random.Range (0.5f, 3f); //return a random number for wait time between movements
		nextMovement = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//make enemy AI attack/do attack animation
		//attach this to your player game object
		playerPos = GameObject.Find("Player").transform.position;
	
	}

	private void MovePWR1()
	{
		
	}

	private void MovePWR2()
	{
		
	}
}

