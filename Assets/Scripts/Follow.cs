using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public float moveSpeed = 10f;
	public float spinSpeed = 15f;
	public bool move;
	private float currentSpeed;
	private Vector3 relPlayerPos;
	private Quaternion lookRotation;
	private Transform player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		move = true;
	}
	
	void FixedUpdate() {
		relPlayerPos = player.position - transform.position;
		lookRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * spinSpeed);
		transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

		if(move) {
			currentSpeed = moveSpeed;
		} else {
			if(currentSpeed > 0f) {
				currentSpeed -= Time.deltaTime * 50f;
			} else {
				currentSpeed = 0f;
			}
		}
	}
}
