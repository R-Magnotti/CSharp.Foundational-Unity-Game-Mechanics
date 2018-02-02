using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: example of a a class called "hero class" extending the character class 
//----------------------------------------------------------------------------------------

//example class 
public class BaseHeroClass : BaseCharacterClass
{
	//constructor
	public BaseHeroClass()
	{
		CharacterClassName = "Miki";
		CharacterClassDescription = "A charismatic, ambitious nobody.";

		ATK = 12;
		DEF = 10;
		HP = 13;
		CHR = 15;
	}
}
