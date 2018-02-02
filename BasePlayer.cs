using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create a player class
//----------------------------------------------------------------------------------------

public class BasePlayer
{
	private string playerName;
	private int playerLevel;
	private BaseCharacterClass playerClass;
	//stats
	private int hp;
	private int def;
	private int atk;
	private int chr;
	private int currentXP;
	private int requiredXP;
	private int money;

	public string PlayerName { get; set; }
//	this is the same as style
//	public string CharacterClassName
//	{
//		get{ return characterClassName; }
//		set{ characterClassName = value; } //"value" = variable input placeholder
//	}

	public int PlayerLevel { get; set; }

	public BaseCharacterClass PlayerClass { get; set; }

	public int HP { get; set; }

	public int DEF { get; set; }

	public int ATK { get; set; }

	public int CHR { get; set; }

	public int CurrentXP{ get; set; }

	public int RequiredXP{ get; set; }

	public int Money{ get; set; }
}


