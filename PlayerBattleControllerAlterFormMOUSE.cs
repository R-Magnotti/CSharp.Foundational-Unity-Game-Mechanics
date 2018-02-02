using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: script to enable touch screen battle controls after using the alter 
//	function in battle which switches outfits and control scheme
//----------------------------------------------------------------------------------------

public class PlayerTouchBattleAlter : MonoBehaviour
{
	private Animator animator; // Reference to the animator
	private Vector3 enemyPos; //Get the player/target

	private int getMaxAttack;
	private int currMaxAttack;

	//for melee combo
	private float attackWait;
	private float nextAttack;

	//for UI
	private bool clickUI;
	private int alteredCount;
	private int alteredMax;
	private int attackCount;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		attackWait = 1.0F;
		nextAttack = 0.0F;
		alteredCount = 0;
		alteredMax = 10;
		attackCount = 0; //not quite right...want to make sure hits go in order...

		currMaxAttack = GetComponent<BattleInfoHolder> ().GetMaxAttack();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//this must be defined in Updat because the clicked location will change p/ frame
		clickUI = EventSystem.current.IsPointerOverGameObject ();

		enemyPos = GameObject.Find("EnemyFat").transform.position; //enemy's position

		if(!clickUI)
		{
			if (Input.GetMouseButtonDown (0) && Time.time > nextAttack) 
			{
				Debug.Log ("Attack1 complete");

				//to prevent player from clicking multiple times in one instance
				nextAttack = Time.time + attackWait;

				PlayAttack1 ();
				transform.position = new Vector3 (enemyPos.x + 1.5f, enemyPos.y, enemyPos.z);

				attackCount++;
				alteredCount++;
	
				Debug.Log ("AttackCount " + attackCount);
			}

			else if (Input.GetMouseButtonDown(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Altered.Attack1"))
			{
				PlayAttack2 ();
				transform.position = new Vector3(enemyPos.x+1.5f, enemyPos.y, enemyPos.z);	

				alteredCount++;
				attackCount++;
				nextAttack ++;

				Debug.Log ("AttackCount " + attackCount);
			}

			else if (Input.GetMouseButtonDown(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Altered.Attack2"))
			{
				PlayAttack3 ();
				transform.position = new Vector3(enemyPos.x+1.5f, enemyPos.y, enemyPos.z);	

				alteredCount++;
				attackCount = 0;
				nextAttack ++;

				Debug.Log ("AttackCount " + attackCount);
			}

			else 
			{
				attackCount = 0;
			}

		}

		if(alteredCount == alteredMax)
		{
			Normal ();
		}
	}

	//caled after Update() once per frame
	void LateUpdate()
	{
		//if attack animation is complete move player back (for both normal and altered state
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Altered.Default"))
		{
			transform.position = new Vector3(enemyPos.x+2.5f, enemyPos.y, enemyPos.z);
		}
	}

	private void PlayAttack1()
	{
		animator.SetTrigger ("Attack1");

		//decrease Var to send back to state machine
		currMaxAttack--;
		GetComponent<BattleInfoHolder> ().SetMaxAttack (currMaxAttack);
	}

	private void PlayAttack2()
	{
		animator.SetTrigger ("Attack2");

		//decrease Var to send back to state machine
		currMaxAttack--;
		GetComponent<BattleInfoHolder> ().SetMaxAttack (currMaxAttack);
	}

	private void PlayAttack3()
	{
		animator.SetTrigger ("Attack3");

		//decrease Var to send back to state machine
		currMaxAttack--;
		GetComponent<BattleInfoHolder> ().SetMaxAttack (currMaxAttack);
	}

	//controlled via canvas inspector
	public void PlayMagic1()
	{
		animator.SetTrigger ("Magic1");
	}

	public void Normal()
	{
		Debug.Log ("Normal Method Reached");
		animator.SetInteger ("State", 2);

		alteredCount = 0;
	}
}
