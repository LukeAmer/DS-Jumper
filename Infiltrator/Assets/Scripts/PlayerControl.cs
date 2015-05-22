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
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 1.0f) * jumpPower * 100.0f);
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
			if(jumpPower < 5.0f)
				jumpPower += 2.0f * Time.deltaTime;
		}
		else
		{
			jumpPower = 0.0f;
		}

		Debug.Log(jumpPower.ToString());
	}
}
