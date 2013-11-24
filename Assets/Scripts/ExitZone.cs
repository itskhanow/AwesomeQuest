using UnityEngine;
using System.Collections;

public class ExitZone : MonoBehaviour {
	
	public int spawnID;
	public int toLevel;
	public int destID;
	
	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player") && GameManager.Instance.changedLevel == false) {
			GameManager.Instance.destID = this.destID;
			GameObject.Find("LevelController").GetComponent<LevelController>().changeLevel(toLevel);
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag.Equals("Player")) {
			GameManager.Instance.changedLevel = false;
		}
	}

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}
}
