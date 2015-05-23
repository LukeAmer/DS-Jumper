using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	// Declare Public variables below
	public float dampTime = 0.15f;
	public Transform target;
	public GameObject endHole;
	public bool introCamera = true;
	
	// Declare Private variables below
	GameControl gameControl;
	GameObject cameraTarget;
	GameObject player;
	Vector3 velocity = Vector3.zero;



	// Use this for initialization
	void Start () 
	{
		gameControl = GameObject.Find("Game Control").GetComponent<GameControl>();
		cameraTarget = GameObject.Find("Camera Target");
		player = GameObject.Find("Player");

		cameraTarget.transform.position = new Vector2(endHole.transform.position.x, endHole.transform.position.y + 5.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(gameControl.cameraFollow || introCamera)
		{
			Vector3 point = gameObject.GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

		if(introCamera)
		{
			cameraTarget.transform.position = Vector2.MoveTowards(cameraTarget.transform.position, new Vector2(player.transform.position.x, player.transform.position.y - 5.0f), 5.0f * Time.deltaTime);

			if(cameraTarget.transform.position.x <= player.transform.position.x + 5.0f)
			{
				introCamera = false;
				player.GetComponent<Rigidbody2D>().isKinematic = false;
				gameControl.cameraFollow = true;
			}
		}
		else
		{
			if(player.transform.position.y < 2.0f && player.transform.position.y > -2.0f)
			{
				cameraTarget.transform.position = new Vector3(player.transform.position.x + 5.0f, player.transform.position.y);
			}
			else
				cameraTarget.transform.position = new Vector3(player.transform.position.x + 5.0f, cameraTarget.transform.position.y);
		}
	}
}
