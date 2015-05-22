using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	// Declare Public variables below
	
	
	// Declare Private variables below
	float jumpPower = 0.0f;
	bool touch = false;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			touch = true;
		}

		if(Input.GetMouseButtonUp(0))
		{
			touch = false;
		}

		if(!touch && jumpPower > 0.0f)
		{
			//test
		}

		if(touch)
		{
			JumpPowerChange("Increase");
		}
		else
		{
			JumpPowerChange("Decrease");
		}
	
	}

	void JumpPowerChange(string power)
	{
		if(power == "Increase")
		{
			jumpPower += 1.0f * Time.deltaTime;
		}
		else
		{
			jumpPower = 0.0f;
		}

		Debug.Log(jumpPower.ToString());
	}
}
