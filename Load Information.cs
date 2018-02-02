using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefGaming
//	V. 1.0
//	Purpose: basic script to create a class to load the player's information
//----------------------------------------------------------------------------------------

public class LoadInformation
{
	public static void LoadAllInformation()
	{
		//here we only have to reference the  saved info by TAG!!
		GameInformation.PlayerName = PlayerPrefs.GetString ("PLAYERNAME"); 
		GameInformation.PlayerLevel = PlayerPrefs.GetInt ("PLAYERLEVEL"); 
		GameInformation.ATK = PlayerPrefs.GetInt ("ATTACK"); 
		GameInformation.DEF = PlayerPrefs.GetInt ("DEFENSE"); 
		GameInformation.HP = PlayerPrefs.GetInt ("HEALTH"); 
		GameInformation.CHR = PlayerPrefs.GetInt ("CHARISMA"); 
		GameInformation.Money = PlayerPrefs.GetInt ("MONEY"); 
	}
}
