using UnityEngine;
using System.Collections;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti, HardlyBriefProgramming
//	V. 1.0
//	Purpose: basic script to create an item class
//----------------------------------------------------------------------------------------

public class BaseItem 
{
	private string itemName;
	private string itemDescription;
	private int itemID; //to keep track of items
	private ItemTypes itemType; //variable of type ItemType


	public enum ItemTypes //only options for item type
	{
		ARMOR,
		WEAPON,
		POTION,
		UTILITIES
	}

	//allows reading/writing of private values
	public string ItemName
	{
		get{ return itemName; }
		set{ itemName = value; }
	}
	public string ItemDescription {
		get{ return itemDescription; }
		set{ itemDescription = value; }
	}
	public int ItemID 
	{
		get{ return itemID; }
		set{ itemID = value; }
	}
	public ItemTypes ItemType
	{
		get{ return itemType; }
		set{ itemType = value; }
	}
}
