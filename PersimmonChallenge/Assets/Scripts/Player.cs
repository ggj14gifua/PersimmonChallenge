using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float AccelScale;
    public GameObject MeshObject;

	int life = 3;
	int returnInterval = 0;
	float acceleration = 0.02f;
	bool stateFlag = true;
	bool gameOverFlag = false;
	Vector3 startPosition = Vector3.zero;
	Vector3 temporaryVelocity;
	Vector3 temporaryAngularVelocity;
	bool repositFlag = false;

	// Use this for initialization
	void Start ()
	{
		startPosition.y = 5.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( Pause.s_pauseFlag == false )
		{
			if ( repositFlag == true )
			{
				repositFlag = false;
				
				rigidbody.velocity = new Vector3( temporaryVelocity.x,
				                                 temporaryVelocity.y,
				                                 temporaryVelocity.z );
				
				rigidbody.angularVelocity = new Vector3( temporaryAngularVelocity.x,
				                                        temporaryAngularVelocity.y,
				                                        temporaryAngularVelocity.z );
				
				rigidbody.useGravity = true;
			}

			var dir = Vector3.zero;
			dir.z = -Input.acceleration.y;
			dir.x = -Input.acceleration.x;
			
			// clamp acceleration vector to unit sphere
			if (dir.sqrMagnitude > 1) {
				dir.Normalize();
			}
			Move (dir.x * AccelScale, dir.y * AccelScale, dir.z * AccelScale);
			
			if ( Input.GetKey( KeyCode.LeftArrow ) )
			{
				Move (acceleration,0,0);
			}
			
			if ( Input.GetKey( KeyCode.RightArrow ) )
			{
				Move (-acceleration,0,0);
			}
			
			if ( Input.GetKey( KeyCode.UpArrow ) )
			{
				Move (0,0,-acceleration);
			}
			
			if ( Input.GetKey( KeyCode.DownArrow ) )
			{
				Move (0,0,acceleration);
			}

			if ( stateFlag == false )
			{
				++returnInterval;

				if ( returnInterval == 30 && gameOverFlag == false )
				{
					transform.position = startPosition;
					returnInterval = 0;
					stateFlag = true;
	                MeshObject.SetActive(true);
					rigidbody.velocity = Vector3.zero;
					rigidbody.angularVelocity = Vector3.zero;
					//renderer.enabled = true;
				}
			}
		}
		else
		{
			if ( repositFlag == false )
			{
				temporaryVelocity.x = rigidbody.velocity.x;
				temporaryVelocity.y = rigidbody.velocity.y;
				temporaryVelocity.z = rigidbody.velocity.z;
				
				temporaryAngularVelocity.x = rigidbody.velocity.x;
				temporaryAngularVelocity.y = rigidbody.velocity.y;
				temporaryAngularVelocity.z = rigidbody.velocity.z;
				rigidbody.useGravity = false;
				
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				repositFlag = true;
			}
		}
	}

	private void Move (float x, float y, float z) {
		
		float _x = rigidbody.velocity.x + x;
		float _y = rigidbody.velocity.y + y;
		float _z = rigidbody.velocity.z + z;
		
		rigidbody.velocity = new Vector3(_x, _y, _z);
	}
	// ボーダーラインとの衝突判定
	void OnTriggerEnter( Collider other )
	{
		if ( other.name == "Borderline" )
		{
			// true：描画・false：描画しない
            MeshObject.SetActive(false);
			//renderer.enabled = false;

			// 残機を減らす
			life -= 1;

			if ( life == 0 )
			{
				Scene.NextScene = "Result";
				Scene.canNextScene = true;
				gameOverFlag = true;
			}

			stateFlag = false;
		}
	}
}
