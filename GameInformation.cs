using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, YouTuber: HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a class to hold information on the character
//----------------------------------------------------------------------------------------

public class GameInformation : MonoBehaviour {

	//starts before "start func"
	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject); //will load in every scene
	}

	//"static" meaning it can be accessed by reference in ANY script without instantiating
	//Like "Stuff.name" with no "Stuff stuff = new Stuff();"
	public static string PlayerName{ get; set; }
	public static int PlayerLevel{ get; set; }
	public static BaseCharacterClass PlayerClass{ get; set; }
	public static int ATK{ get; set; }
	public static int DEF{ get; set; }
	public static int HP{ get; set; }
	public static int CHR{ get; set; }
	public static int CurrentXP{ get; set; }
	public static int RequiredXP{ set; get; }
	public static int Money{ set; get; }
}

