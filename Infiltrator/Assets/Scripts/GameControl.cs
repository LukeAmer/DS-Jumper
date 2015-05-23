using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour 
{
	// Declare Public variables below
	public enum states{Intro, Play, Pause, GameOver};
	public states GameState;
	public bool cameraFollow = false;
	public int jumpNumber = 0;
	
	// Declare Private variables below
	GameObject player;
	GUIControl guiControl;
	CameraControl cameraControl;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		GameState = states.Intro;
		guiControl = gameObject.GetComponent<GUIControl>();
		cameraControl = GameObject.Find("Main Camera").GetComponent<CameraControl>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(cameraControl.introCamera)
			{
				cameraControl.introCamera = false;
				player.GetComponent<Rigidbody2D>().isKinematic = false;
				cameraFollow = true;
			}
		}

		if(GameState == states.Intro)
		{
			if(!cameraControl.introCamera)
				GameState = states.Play;
		}

		if(GameState == states.GameOver)
		{
			guiControl.fadeOut = true;
		}
	}
}
