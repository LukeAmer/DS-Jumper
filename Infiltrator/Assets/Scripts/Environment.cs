using UnityEngine;
using System.Collections;

public class Environment : MonoBehaviour 
{
	// Public Variables
	public GameObject leftLine;
	public GameObject rightLine;

	// Private Variables
	float height = 0.0f;
	float width = 0.0f;

	// Use this for initialization
	void Start () 
	{
		height = 2f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

		rightLine.transform.position = new Vector2 (width/2.0f, 0.0f);
		leftLine.transform.position = new Vector2 (-width/2.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
