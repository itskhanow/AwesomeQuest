using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	public int damage;
	public int damageType;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!transform.animation.IsPlaying("Sword_Swing")) {
			Destroy(transform.parent.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Enemy")) {
			other.GetComponent<Enemy>().damaged(damage, damageType);
		}
	}
}
