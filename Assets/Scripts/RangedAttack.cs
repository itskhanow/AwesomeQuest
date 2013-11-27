using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {
	
	public int damage;
	public int speed;
	public float lifeTime;

	// Use this for initialization
	void Start() {
		lifeTime = 5.0f;
	}
	
	// Update is called once per frame
	void Update() {
		if(lifeTime > 0f) {
			lifeTime -= Time.deltaTime;
		} else {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Enemy")) {
			other.GetComponent<Enemy>().damaged(damage);
			GameObject.Instantiate(Resources.Load("Prefabs/Sparks"), transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
