using UnityEngine;
using System.Collections;

public class ObjectState : MonoBehaviour {
	
	public string mobName;
	public int levelID;
	private Vector2 position;
	private bool isAlive;
	
	public int LevelID {
		get {
			return levelID;
		}
		
		set {
			levelID = value;
		}
	}
	
	public Vector3 Position {
		get {
			return position;
		}
		
		set {
			
		}
	}

	public bool IsAlive {
		get {
			return isAlive;
		}

		set {

		}
	}
	
	public void saveState() {
		position = transform.position;
		isAlive = gameObject.activeSelf;
	}

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}
}
