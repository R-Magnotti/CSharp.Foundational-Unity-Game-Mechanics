using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create an character class
//----------------------------------------------------------------------------------------

public class BaseCharacterClass 
{
	//ALL variables should be private unless they absolutely need to be public
	private string characterClassName;
	private string charaterClassDescription;

	//stats
	private int hp;
	private int def;
	private int atk;
	private int chr;

	//not a method, but a "property setter"/"accessor" for String characterClassName
	public string CharacterClassName
	{
		get{ return characterClassName; }
		set{ characterClassName = value; } //"value" = variable input placeholder
	}

	public string CharacterClassDescription
	{
		get{ return charaterClassDescription; }
		set{ charaterClassDescription = value; }
	}

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
