using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public int maxHealth = 100;
	public int moveSpeed = 10;
	public Transform buddy;
	public PlayerDirection playerDirection;
	private int curHealth;
	private PlayerState curState;
	private int curCharacter;
	private Vector2 moveDirection;
	private float moveMagnitude;
	private Vector2 lookVector;
	private Animator joshAnimator;
	private Animator khanAnimator;

	// Use this for initialization
	void Start() {
		buddy = GameObject.FindGameObjectWithTag("Buddy").transform;
		if(GameManager.Instance.getCurChar() == 2) {
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetChild(1).gameObject.SetActive(true);
			buddy.GetChild(1).gameObject.SetActive(true);
			buddy.GetChild(2).gameObject.SetActive(false);
		} else {
			transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(1).gameObject.SetActive(false);
			buddy.GetChild(1).gameObject.SetActive(false);
			buddy.GetChild(2).gameObject.SetActive(true);
		}
		//temporary, check for persistence values from gamemanager
		curHealth = maxHealth;

		joshAnimator = transform.GetChild(0).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetButtonDown("Switch")) {
			switchCharacter();
		}
		if(Input.GetButtonDown("Attack")) {
			shoot();
		}

		animate();

		if(curHealth <= 0) {
			death();
		}
	}

	void FixedUpdate() {
		move();
	}

	void animate() {
		joshAnimator.SetFloat("Velocity", rigidbody2D.velocity.magnitude);
		switch(playerDirection) {
		case PlayerDirection.UP:
			joshAnimator.SetInteger("Direction", 0);
			break;
		case PlayerDirection.RIGHT:
			joshAnimator.SetInteger("Direction", 1);
			break;
		case PlayerDirection.DOWN:
			joshAnimator.SetInteger("Direction", 2);
			break;
		case PlayerDirection.LEFT:
			joshAnimator.SetInteger("Direction", 3);
			break;
		}
	}
	
	void shoot() {
		GameObject bullet;
		bullet = GameObject.Instantiate(Resources.Load("Prefabs/RangedAttack"), transform.position, transform.rotation) as GameObject;
		if(lookVector.magnitude > 0f) {
			bullet.rigidbody2D.velocity = lookVector.normalized * 20;
		}
	}
	
	void switchCharacter() {
		buddy = GameObject.FindGameObjectWithTag("Buddy").transform;
		if(GameManager.Instance.getCurChar() == 1) {
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetChild(1).gameObject.SetActive(true);
			buddy.GetChild(1).gameObject.SetActive(true);
			buddy.GetChild(2).gameObject.SetActive(false);
			GameManager.Instance.setCurChar(2);
		} else if(GameManager.Instance.getCurChar() == 2) {
			transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(1).gameObject.SetActive(false);
			buddy.GetChild(1).gameObject.SetActive(false);
			buddy.GetChild(2).gameObject.SetActive(true);
			GameManager.Instance.setCurChar(1);
		}
	}

	void move() {
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		if(Mathf.Abs(h) > Mathf.Abs(v)) {
			if(h > 0) {
				playerDirection = PlayerDirection.RIGHT;
			} else if(h < 0) {
				playerDirection = PlayerDirection.LEFT;
			}
		} else if(Mathf.Abs(h) < Mathf.Abs(v)) {
			if(v > 0) {
				playerDirection = PlayerDirection.UP;
			} else if(v < 0) {
				playerDirection = PlayerDirection.DOWN;
			}
		}

		moveDirection = (Vector2.up * v) + (Vector2.right * h);

		if(moveDirection.magnitude < 1f) {
			moveMagnitude = moveDirection.magnitude;
		} else {
			moveMagnitude = 1f;
		}

		if(moveDirection.magnitude > 0.3f) {
			lookVector = moveDirection.normalized;
		}

		moveDirection.Normalize();
		rigidbody2D.velocity = moveDirection * moveMagnitude * moveSpeed;

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

	public enum PlayerDirection {
		UP,
		DOWN,
		LEFT,
		RIGHT
	}
}
