using UnityEngine;
using System.Collections;

public class BuddyCollider : MonoBehaviour {

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Player")) {
			transform.parent.GetComponent<Follow>().move = false;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag.Equals("Player")) {
			transform.parent.GetComponent<Follow>().move = true;
		}
	}
}
