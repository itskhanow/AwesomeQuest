using UnityEngine;
using System.Collections;

public class ChiggerAI : MonoBehaviour {

	public int attDamage;
	public int speed;
	public bool pursue;

	private Transform player;
	private Animator anim;

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		anim = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {

	}

	void FixedUpdate() {
		if(pursue) {
			transform.LookAt(player.position);
			rigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
			//animation.Play("Crawl_Chigger");
		} else {
			rigidbody.velocity = transform.TransformDirection(Vector3.forward * 0);
			//animation.Play("Idle_Chigger");
		}

		anim.SetFloat("Speed", rigidbody.velocity.magnitude);
	}
}
