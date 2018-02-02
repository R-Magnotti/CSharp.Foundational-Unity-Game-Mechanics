using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a class to hold info for leveling up the player
//----------------------------------------------------------------------------------------

public class LevelUp
{
	public int maxPlayerLevel = 100;
	
	//called as soon as player levels up
	public void LevelUpCharacter() //public because must be accessed from other scripts
	{
		//check if current xp > required xp
		//use xp as currency (think bloodborne)
		if (GameInformation.CurrentXP > GameInformation.RequiredXP) 
		{
			GameInformation.CurrentXP -= GameInformation.RequiredXP;
		} 
		else 
		{
			GameInformation.CurrentXP = 0;
		}


		if (GameInformation.PlayerLevel < maxPlayerLevel) {
			GameInformation.PlayerLevel += 1;
		} 
		else
		{
			GameInformation.PlayerLevel = maxPlayerLevel;
		}

		NextXPReqired ();
	}

	//give player option to spend xp to boost chosen stat
	private void xpOnStat() //private because only used by this script
	{

	}

	//give option to spend xp on ability
	private void xpOnAbility()
	{

	}

	//give player option to spend xp on items
	private void xpOnItem()
	{

	}

	//determine required xp for next level
	private void NextXPReqired()
	{
		//could make custom 
		int reqXP = GameInformation.PlayerLevel*100;
		GameInformation.RequiredXP = reqXP;
	}
}
