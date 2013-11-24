using UnityEngine;
using System.Collections;

public class BasicMove : MonoBehaviour {
	
	public float moveSpeed = 10f;
	public float spinSpeed = 15f;
	Vector3 targetDirection;
	Vector3 moveDirection;
	float moveMagnitude;
	Quaternion targetRotation;
	Quaternion newRotation;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(GameManager.Instance.state == GameManager.StateType.EXPLORE) {
			move();
		}
	}
	
	void move() {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		if(v != 0f || h != 0f) {
			moveDirection = (Vector3.forward * v) + (Vector3.right * h);
			if(moveDirection.magnitude < 1f) {
				moveMagnitude = moveDirection.magnitude;
			} else {
				moveMagnitude = 1f;
			}
			moveDirection.Normalize();
			rigidbody.velocity = moveDirection * moveMagnitude * moveSpeed;
			//transform.Translate(Vector3.right * Mathf.Cos(transform.rotation.y) * moveSpeed * Time.deltaTime, Space.World);
			
			targetDirection = new Vector3 (h, 0f, v);
			targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
			newRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * spinSpeed);
		
			//rigidbody.MoveRotation(newRotation);
			transform.rotation = newRotation;
			
			//transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
	}

	void dumbmove() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"));
		transform.TransformDirection(moveDirection);
		targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
		newRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * spinSpeed);
		transform.rotation = newRotation;

		if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) {

		}
	}
}
