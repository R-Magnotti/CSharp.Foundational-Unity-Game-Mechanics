using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a base stat item class that extends the base item class
//----------------------------------------------------------------------------------------

public class BaseStatItem : BaseItem
{
	private int atk;
	private int def;
	private int hp;
	private int chr;

	public int HP
	{
		get{ return hp; }
		set{ hp = value; }
	}

	public int DEF
	{
		get{ return def; }
		set{ def = value; }
	}

	public int ATK
	{
		get{ return atk; }
		set{ atk = value; }
	}

	public int CHR
	{
		get{ return chr; }
		set{ chr = value; }
	}
}
