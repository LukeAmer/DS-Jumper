using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	// Public Variables
	public GameObject playerTarget;
	public float maxPlayerSpeed = 5.0f;


	// Private Variables
	private bool moveTarget = true;
	private float playerMovementSpeed = 1.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void FixedUpdate()
	{

		if(Input.GetMouseButton(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider.gameObject.tag == "Floor" || hit.collider.gameObject.tag == "Box")
			{
				//Debug.Log ("Target Position: " + hit.point.ToString());
				playerTarget.transform.position = new Vector3(hit.point.x, hit.point.y, 0.0f);
				
				if(playerMovementSpeed < maxPlayerSpeed)
				{
					playerMovementSpeed += 3.0f * Time.deltaTime;
				}
				else
					playerMovementSpeed = maxPlayerSpeed;
				
				moveTarget = true;
			}
			
			if(hit.collider.gameObject.tag == "Player")
			{
				moveTarget = false;
			}
		}
		else
		{
			moveTarget = false;
		}

		// Movement
		float playerStep = playerMovementSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, playerStep);

		// Rotation
		Vector3 lookPos = playerTarget.transform.position - gameObject.transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	
		if(!moveTarget)
		{
			if(playerMovementSpeed > 0.0f)
			{
				playerMovementSpeed -= 10.0f * Time.deltaTime;
			}
			else
				playerMovementSpeed = 0.0f;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Wall")
		{
			playerMovementSpeed = 0.0f;
		}
	}
	

}
