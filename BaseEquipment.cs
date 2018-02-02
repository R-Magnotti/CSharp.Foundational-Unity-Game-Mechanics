using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create an equipment class
//----------------------------------------------------------------------------------------

public class BaseEquipment : BaseStatItem 
{
	public enum EquipmentTypes
	{
		HEAD,
		TORSO,
		LEGS,
		GLOVES
	}

	private EquipmentTypes equipmentType;

	public EquipmentTypes EquipmentType 
	{
		get{return equipmentType;}
		set{equipmentType = value;}
	}
}
