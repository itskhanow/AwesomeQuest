using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public float moveSpeed = 10f;
	public bool move;
	private Vector2 moveDirection;
	private Transform player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate() {
		if(move) {
			moveDirection = player.position - transform.position;
			rigidbody2D.velocity = moveDirection.normalized * moveSpeed;
		} else {
			rigidbody2D.velocity = new Vector2(0f, 0f);
		}
	}
}
