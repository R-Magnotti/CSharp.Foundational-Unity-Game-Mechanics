using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//----------------------------------------------------------------------------------------
//	Author: Richard Magnotti
//	V. 1.0
//	Purpose: basic script to create a class to hold information on the health bar for the 
//	-player character
//----------------------------------------------------------------------------------------

public class HealthBar : MonoBehaviour
{
	[SerializeField] //to make fillAmt visible int he inspector
	private float fillAmount = 1;

	[SerializeField]
	private Image healthFill;

	public float maxVal{ get; set;}

	public float Value
	{
		set
		{
			fillAmount = HealthMap(100, 0, maxVal, 0, 1);
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(fillAmount != healthFill.fillAmount)
		{
			AdjustHealthBar ();
		}
	}

	private void AdjustHealthBar()
	{
		healthFill.fillAmount = this.fillAmount;
	}

	//params: current health, minimum health (e.g. 0), max health, minimum/max of health (fill amounts - limited to 1 and 0)
	private float HealthMap(float totHealth, float inMin, float inMax, float outMin, float outMax)
	{
		return (((totHealth - inMin) * (outMax - outMin)) / (inMax - inMin) + outMin);
	}
}

