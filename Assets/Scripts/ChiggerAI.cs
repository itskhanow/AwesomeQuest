using UnityEngine;
using System.Collections;

public class ChiggerAI : MonoBehaviour {

	public int attDamage;
	public int speed;
	public bool pursue;

	private Transform player;
	private Vector2 moveDirection;

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update() {

	}

	void FixedUpdate() {
		if(pursue) {
			//transform.LookAt(player.position);
			moveDirection = player.position - transform.position;
			rigidbody2D.velocity = moveDirection.normalized * speed;
			//animation.Play("Crawl_Chigger");
		} else {
			rigidbody2D.velocity = new Vector2();
			//animation.Play("Idle_Chigger");
		}

		//anim.SetFloat("Speed", rigidbody.velocity.magnitude);
	}
}
