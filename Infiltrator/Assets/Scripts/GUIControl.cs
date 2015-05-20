using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIControl : MonoBehaviour 
{
	// Public Variables
	public Text fpsText;

	// Private Variables


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		fpsText.text =  (1.0/Time.deltaTime).ToString();
	}
}
