using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create utility class that extends the stat item class
//----------------------------------------------------------------------------------------

public class BaseUtility : BaseStatItem 
{
	public enum UtilityTypes
	{
		ACCESS, //like door keys
		LIGHT,
		TRANSPORTATION,
		KEY_ITEMS
	}

	private UtilityTypes utilityType;

	public UtilityTypes UtilityType 
	{
		get{return utilityType;}
		set{utilityType = value;}
	}
}