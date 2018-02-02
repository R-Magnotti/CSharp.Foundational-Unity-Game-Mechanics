using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a class to hold data for increasing player experience
//----------------------------------------------------------------------------------------

public static class IncreaseExperience
{
	private static int xpToGive;
	//level up object needed to be instantiated to be called
	private static LevelUp levelUpScript = new LevelUp();

	//this needs to be a static function to be accessed from 
	//whatever script triggers experience gain
	public static void AddExperiencce()
	{
		xpToGive = GameInformation.PlayerLevel * 100;	
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfLeveledUp ();
		Debug.Log (xpToGive);
	}

	private static void CheckToSeeIfLeveledUp()
	{
		if (GameInformation.CurrentXP >= GameInformation.RequiredXP) 
		{
			//then player=leveled up (see level up script)
			levelUpScript.LevelUpCharacter();
		}
	}
}
