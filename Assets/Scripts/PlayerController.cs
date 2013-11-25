using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public int maxHealth = 100;
	public int moveSpeed = 10;
	public Transform buddy;
	private int curHealth;
	private PlayerState curState;
	private int curCharacter;
	private Vector2 moveDirection;
	private float moveMagnitude;

	// Use this for initialization
	void Start() {
		buddy = GameObject.FindGameObjectWithTag("Buddy").transform;
		if(GameManager.Instance.getCurChar() == 2) {
			transform.GetChild(0).renderer.enabled = false;
			transform.GetChild(1).renderer.enabled = true;
			buddy.GetChild(1).renderer.enabled = true;
			buddy.GetChild(2).renderer.enabled = false;
		} else {
			transform.GetChild(0).renderer.enabled = true;
			transform.GetChild(1).renderer.enabled = false;
			buddy.GetChild(1).renderer.enabled = false;
			buddy.GetChild(2).renderer.enabled = true;
		}
		//temporary, check for persistence values from gamemanager
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetButtonDown("Switch")) {
			switchCharacter();
		}
		if(Input.GetButtonDown("Attack")) {
			shoot();
		}
		if(curHealth <= 0) {
			death();
		}
	}

	void FixedUpdate() {
		move();
	}
	
	void shoot() {
		GameObject bullet;
		bullet = GameObject.Instantiate(Resources.Load("Prefabs/RangedAttack"), transform.position, transform.rotation) as GameObject;
		Physics.IgnoreCollision(bullet.collider, collider);
		bullet.rigidbody.velocity = transform.TransformDirection(Vector3.forward * 20);
	}
	
	void switchCharacter() {
		buddy = GameObject.FindGameObjectWithTag("Buddy").transform;
		if(GameManager.Instance.getCurChar() == 1) {
			transform.GetChild(0).renderer.enabled = false;
			transform.GetChild(1).renderer.enabled = true;
			buddy.GetChild(1).renderer.enabled = true;
			buddy.GetChild(2).renderer.enabled = false;
			GameManager.Instance.setCurChar(2);
		} else if(GameManager.Instance.getCurChar() == 2) {
			transform.GetChild(0).renderer.enabled = true;
			transform.GetChild(1).renderer.enabled = false;
			buddy.GetChild(1).renderer.enabled = false;
			buddy.GetChild(2).renderer.enabled = true;
			GameManager.Instance.setCurChar(1);
		}
	}

	void move() {
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		moveDirection = (Vector2.up * v) + (Vector2.right * h);

		if(moveDirection.magnitude < 1f) {
			moveMagnitude = moveDirection.magnitude;
		} else {
			moveMagnitude = 1f;
		}

		rigidbody2D.velocity = moveDirection.normalized * moveMagnitude * moveSpeed;

	}

	void death() {

	}
	
	public enum PlayerState {
		DEFAULT,
		SPAWNING,
		IDLE,
		WALKING,
		RUNNING,
		ATTACKING,
		INVINCIBLE,
	}
}
