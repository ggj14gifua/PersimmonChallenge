using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	float acceleration = 0.01f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( Input.GetKey( KeyCode.LeftArrow ) )
		{
			float x = rigidbody.velocity.x - acceleration;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}
		
		if ( Input.GetKey( KeyCode.RightArrow ) )
		{
			float x = rigidbody.velocity.x + acceleration;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}

		if ( Input.GetKey( KeyCode.UpArrow ) )
		{
			float x = rigidbody.velocity.x;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z + acceleration;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}
		
		if ( Input.GetKey( KeyCode.DownArrow ) )
		{
			float x = rigidbody.velocity.x;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z - acceleration;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}
	}
}
