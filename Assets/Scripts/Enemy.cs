using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int maxHealth;

	private int curHealth;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth <= 0) {
			//Destroy(gameObject);
			GameObject.Instantiate(Resources.Load("Prefabs/DestructionParticles"), transform.position, transform.rotation);
			gameObject.SetActive(false);
		}
	}

	public void damaged(int damage) {
		curHealth -= damage;
	}
}
