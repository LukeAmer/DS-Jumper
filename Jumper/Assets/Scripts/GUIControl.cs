using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIControl : MonoBehaviour 
{
	// Declare Public variables below
	public Image fadeWhite;
	public bool fadeIn = true;
	public bool fadeOut = false;
	
	// Declare Private variables below
	GameControl gameControl;
	PlayerControl playerControl;
	Text levelNumber;
	Text levelDetails;
	Text jumpsNumber;
	Text fps;

	// Use this for initialization
	void Start () 
	{
		gameControl = GameObject.Find("Game Control").GetComponent<GameControl>();
		playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
		levelNumber = GameObject.Find("Level Number").GetComponent<Text>();
		levelDetails = GameObject.Find("Level Details").GetComponent<Text>();
		jumpsNumber = GameObject.Find("Jumps Number").GetComponent<Text>();
		fps = GameObject.Find("FPS").GetComponent<Text>();

		fadeWhite.color = new Color(fadeWhite.color.r, fadeWhite.color.g, fadeWhite.color.b, 1.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		ScreenFade();

		TextFade(levelNumber, "Out", 0.2f);
		TextFade(levelDetails, "Out", 0.2f);

		if(gameControl.GameState == GameControl.states.Play && gameControl.cameraFollow)
		{
			TextFade(jumpsNumber, "In", 0.2f);
		}

		if(fadeOut)
			TextFade(jumpsNumber, "Out", 1.0f);

		jumpsNumber.text = gameControl.jumpNumber.ToString();
		fps.text = "FPS: " + Mathf.Round(1.0f/Time.deltaTime).ToString();
	}

	void TextFade(Text text, string fadeInorOut, float rate)
	{
		if(fadeInorOut == "Out")
		{
			if(text.color.a > 0.0f)
				text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - rate * Time.deltaTime);
		}
		else
		{
			if(text.color.a < 1.0f)
				text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + rate * Time.deltaTime);
		}
	}


	void ScreenFade()
	{
		if(fadeIn)
		{
			fadeOut = false;
			if(fadeWhite.color.a > 0.0f)
			{
				fadeWhite.color = new Color(fadeWhite.color.r, fadeWhite.color.g, fadeWhite.color.b, fadeWhite.color.a - 1.0f * Time.deltaTime); 
			}
			else
				fadeIn = false;
		}
		
		if(fadeOut)
		{
			if(fadeWhite.color.a < 1.0f)
			{
				fadeWhite.color = new Color(fadeWhite.color.r, fadeWhite.color.g, fadeWhite.color.b, fadeWhite.color.a + 1.0f * Time.deltaTime); 
			}
			else
			{
				fadeOut = false;
				Application.LoadLevel(0);
			}
		}
	}

	void JumpTouch()
	{
		playerControl.touch = true;
	}

	void JumpRelease()
	{
		playerControl.touch = false;
	}

	void LeftArrowDown()
	{
		playerControl.leftArrow = true;
	}

	void LeftArrowUp()
	{
		playerControl.leftArrow = false;
	}

	void RightArrowDown()
	{
		playerControl.rightArrow = true;
	}

	void RightArrowUp()
	{
		playerControl.rightArrow = false;
	}
}
