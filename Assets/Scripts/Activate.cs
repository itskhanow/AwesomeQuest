using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {
	
	public string dialog;
	public bool cutscene;
	public float dialogTime = 5f;
	Rect messageBox;
	float timeRemaining;
	bool colliding;
	bool showDialog;

	// Use this for initialization
	void Start() {
		showDialog = false;
		int dialogX = (int)(Screen.width * 0.25f);
		int dialogY = (int)(Screen.height * 0.25f);
		int dialogWidth = (int)(Screen.width * 0.5f);
		int dialogHeight = (int)(Screen.height * 0.25f);
		messageBox = new Rect (dialogX, dialogY, dialogWidth, dialogHeight);
	}
	
	// Update is called once per frame
	void Update() {
		if(showDialog && timeRemaining >= 0f) {
			timeRemaining -= Time.deltaTime;
		}
		
		if(timeRemaining < 0f) {
			if(cutscene == true) {
				GameManager.Instance.state = GameManager.StateType.EXPLORE;
			}
			showDialog = false;
		}
		
		if(Input.GetButtonDown("Activate") && showDialog == true && colliding == false) {
			showDialog = false;
			if(cutscene == true) {
				GameManager.Instance.state = GameManager.StateType.EXPLORE;
			}
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other.tag.Equals("Player")) {
			if(Input.GetButtonDown("Activate")) {
				if(showDialog == false) {
					showDialog = true;
					timeRemaining = dialogTime;
					if(cutscene == true) {
						GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RPGCamera>().cutsceneCam = transform.GetChild(0).transform;
						GameManager.Instance.state = GameManager.StateType.CUTSCENE;
					}
				} else {
					showDialog = false;
					if(cutscene == true) {
						GameManager.Instance.state = GameManager.StateType.EXPLORE;
					}
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			colliding = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag.Equals("Player")) {
			colliding = false;
		}
	}
	
	void OnGUI() {
		if(showDialog) {
			GUI.Box(messageBox, dialog);
		}
	}
}
