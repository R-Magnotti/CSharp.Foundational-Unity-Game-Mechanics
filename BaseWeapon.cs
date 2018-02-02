using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a weapon class to extend the base stat item class
//----------------------------------------------------------------------------------------

//BaseWeapon <- BaseStatItem <- BaseItem
public class BaseWeapon : BaseStatItem 
{
	private WeaponTypes weaponType;

	public enum WeaponTypes //only in caps for consitstency
	{
		SWORD,
		STAFF,
		DAGGER,
		HAMMER,
		AXE
	}

	public WeaponTypes WeaponType
	{
		get{ return weaponType; }
		set{ weaponType = value; }
	}
}
