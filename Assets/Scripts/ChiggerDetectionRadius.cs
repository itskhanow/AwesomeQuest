using UnityEngine;
using System.Collections;

public class ChiggerDetectionRadius : MonoBehaviour {

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void FixedUpdate() {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Player")) {
			transform.parent.GetComponent<ChiggerAI>().pursue = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag.Equals("Player")) {
			transform.parent.GetComponent<ChiggerAI>().pursue = false;
		}
	}
}
