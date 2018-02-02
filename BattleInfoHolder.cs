using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a behaviour script to hold battle information
//----------------------------------------------------------------------------------------

//use this as a temp variable holder each time a battle starts
public class BattleInfoHolder : MonoBehaviour 
{
	public int maxAttack;

	// Use this for initialization
	void Start () 
	{
		maxAttack = 10;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Attacks Left = " + maxAttack);
	}

	//must be public for other scripts to access
	public int GetMaxAttack()
	{
		return maxAttack;
	}

	public void SetMaxAttack(int maxAttack)
	{
		this.maxAttack = maxAttack;
	}
}
