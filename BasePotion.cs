using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create potion class that extends the stat item class
//----------------------------------------------------------------------------------------

public class BasePotion : BaseStatItem 
{
	public enum PotionTypes
	{
		HEALTH,
		ANTIDOTE,
		REVIVE,
		STATUS
	}

	private PotionTypes potionType;

	public PotionTypes PotionType 
	{
		get{return potionType;}
		set{potionType = value;}
	}
}
