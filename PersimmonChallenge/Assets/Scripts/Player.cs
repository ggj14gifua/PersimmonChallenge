using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	int life = 3;
	int returnInterval = 0;
	float acceleration = 0.02f;
	bool stateFlag = true;
	bool gameOverFlag = false;
	Vector3 startPosition = new Vector3( -2.8f, 1.4f, 2.7f );

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( Input.GetKey( KeyCode.LeftArrow ) )
		{
			float x = rigidbody.velocity.x + acceleration;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}
		
		if ( Input.GetKey( KeyCode.RightArrow ) )
		{
			float x = rigidbody.velocity.x - acceleration;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}

		if ( Input.GetKey( KeyCode.UpArrow ) )
		{
			float x = rigidbody.velocity.x;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z - acceleration;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}
		
		if ( Input.GetKey( KeyCode.DownArrow ) )
		{
			float x = rigidbody.velocity.x;
			float y = rigidbody.velocity.y;
			float z = rigidbody.velocity.z + acceleration;
			
			rigidbody.velocity = new Vector3(x, y, z);
		}

		if ( stateFlag == false )
		{
			++returnInterval;

			if ( returnInterval == 30 && gameOverFlag == false )
			{
				transform.position = startPosition;
				returnInterval = 0;
				stateFlag = true;
				renderer.enabled = true;
			}
		}
	}

	// ボーダーラインとの衝突判定
	void OnTriggerEnter( Collider other )
	{
		if ( other.name == "Borderline" )
		{
			// true：描画・false：描画しない
			renderer.enabled = false;

			// 残機を減らす
			life -= 1;

			if ( life == 0 )
			{
				Scene.canNextScene = true;
				gameOverFlag = true;
			}

			stateFlag = false;
		}
	}
}
