using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	// Declare Public variables below

	
	// Declare Private variables below
	GameControl gameControl;
	float jumpPower = 1.0f;
	bool touch = false;
	bool rightArrow = false;
	bool leftArrow = false;
	bool jumping = false;
	float rightRotateSpeed = 0.0f;
	float leftRotateSpeed = 0.0f;


	// Use this for initialization
	void Start () 
	{
		gameControl = GameObject.Find("Game Control").GetComponent<GameControl>();
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

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			rightArrow = true;
		}

		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			rightArrow = false;
		}
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			leftArrow = true;
		}

		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			leftArrow = false;
		}
		
		if(!touch && jumpPower > 1.0f && !jumping)
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 1.0f) * jumpPower * 100.0f);
			jumping = true;
		}

		if(touch && !jumping)
		{
			JumpPowerChange("Increase");
		}
		else
		{
			JumpPowerChange("Decrease");
		}

		if(rightArrow && jumping)
		{
			if(leftRotateSpeed > 0.0f)
				leftRotateSpeed -= 5.0f * Time.deltaTime;
			else if(rightRotateSpeed < 5.0f)
			{
				rightRotateSpeed += 5.0f * Time.deltaTime;
				leftRotateSpeed = 0.0f;
			}
		}

		if(leftArrow && jumping)
		{
			if(rightRotateSpeed > 0.0f)
				rightRotateSpeed -= 5.0f * Time.deltaTime;
			else if(leftRotateSpeed < 5.0f)
			{
				leftRotateSpeed += 5.0f * Time.deltaTime;
				rightRotateSpeed = 0.0f;
			}
		}

		if(jumping)
		{
			if(leftRotateSpeed > 0.0f)
			{
				gameObject.transform.Rotate(new Vector3(0,0,1) * leftRotateSpeed * 100.0f * Time.deltaTime);
				leftRotateSpeed -= 2.0f * Time.deltaTime;
			}
			else if(rightRotateSpeed > 0.0f)
			{
				gameObject.transform.Rotate(new Vector3(0,0,-1) * rightRotateSpeed * 100.0f * Time.deltaTime);
				rightRotateSpeed -= 2.0f * Time.deltaTime;
			}
		}
		else
		{
			leftRotateSpeed = 0.0f;
			rightRotateSpeed = 0.0f;
		}

		if(gameObject.transform.position.y < -7.0f)
		{
			gameControl.GameState = GameControl.states.GameOver;
		}
	
	}

	void FixedUpdate()
	{

	}

	void JumpPowerChange(string power)
	{
		if(power == "Increase")
		{
			if(jumpPower < 5.0f)
				jumpPower += 3.0f * Time.deltaTime;
		}
		else
		{
			jumpPower = 1.0f;
		}

		Debug.Log(jumpPower.ToString());
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			gameControl.cameraFollow = true;
			jumping = false;
		}
	}
}
