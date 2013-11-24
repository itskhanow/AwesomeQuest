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

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			transform.parent.GetComponent<ChiggerAI>().pursue = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag.Equals("Player")) {
			transform.parent.GetComponent<ChiggerAI>().pursue = false;
		}
	}
}
