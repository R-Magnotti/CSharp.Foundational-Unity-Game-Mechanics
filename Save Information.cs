using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create class to save information on player 
//----------------------------------------------------------------------------------------

public class SaveInformation
{
	//this function will save ALL infromation as a unit
	//Can create func's to save only snippets/at certain moments
	public static void SaveAllInformation()
	{
		PlayerPrefs.SetInt /*"set" is "keyword for "save"*/ (
			"PLAYERLEVEL"/*this is the "tag" saved under*/, 
			GameInformation.PlayerLevel/*this is the info we want to save*/);
		
		PlayerPrefs.SetString ("PLAYERNAME", 
			GameInformation.PlayerName /*remember this info can be accessed 
			easily because it's a static variable*/);
		
		PlayerPrefs.SetInt ("ATTACK"/*tag does NOT have to be caps*/, GameInformation.ATK);
		PlayerPrefs.SetInt ("DEFENSE", GameInformation.DEF);
		PlayerPrefs.SetInt ("HEALTH", GameInformation.HP);		
		PlayerPrefs.SetInt ("CHARISMA", GameInformation.CHR);
		PlayerPrefs.SetInt ("MONEY", GameInformation.Money);

		Debug.Log ("Saved all information");
	}

}
