using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //NEED in order to load scene from script 

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: basic script to create a class to create a new character
//----------------------------------------------------------------------------------------

public class CreateNewCharacter : MonoBehaviour 
{
	private BasePlayer newPlayer; //declaring our new player
	private bool isReady; 
	private bool isNotReady; 
	private string playerName = "Enter Name";


	// Use this for initialization
	void Start () 
	{
		newPlayer = new BasePlayer();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnGUI()
	{
		GUILayout.Label("Are you ready to begin the adventure?");	
		isReady = GUILayout.Toggle(isReady, "YES");	
		isNotReady = GUILayout.Toggle(isNotReady, "NO");

		playerName = GUILayout.TextArea (playerName);

		CreateNewPlayer(); //sets player info to be stored
		StoreNewPlayerInfo (); //stores player info - temp.

		if(GUILayout.Button("Create"))
		{
			SaveInformation.SaveAllInformation (); //passes player info to permanent
		}

		if (GUILayout.Button("Load"))
			{
				SceneManager.LoadScene("Test1"); //to load a scene
			}
	}
		
	private void StoreNewPlayerInfo()
	{
		GameInformation.PlayerName = newPlayer.PlayerName;
		GameInformation.PlayerLevel = 1;
		GameInformation.ATK = newPlayer.PlayerClass.ATK;
		GameInformation.HP = newPlayer.PlayerClass.HP;
		GameInformation.DEF = newPlayer.PlayerClass.DEF;
		GameInformation.CHR = newPlayer.PlayerClass.CHR;
		GameInformation.Money = newPlayer.Money;

	}

	private  void CreateNewPlayer()
	{
		newPlayer.PlayerClass = new BaseHeroClass();

		newPlayer.PlayerLevel = 1;
		newPlayer.ATK = newPlayer.PlayerClass.ATK;
		newPlayer.HP = newPlayer.PlayerClass.HP;
		newPlayer.DEF = newPlayer.PlayerClass.DEF;
		newPlayer.CHR = newPlayer.PlayerClass.CHR;
		newPlayer.PlayerName = playerName;
		newPlayer.Money = 100;

	}
}
