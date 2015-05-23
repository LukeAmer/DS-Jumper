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


	// Use this for initialization
	void Start () 
	{
		fadeWhite.color = new Color(fadeWhite.color.r, fadeWhite.color.g, fadeWhite.color.b, 1.0f); 
	}
	
	// Update is called once per frame
	void Update () 
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
}
