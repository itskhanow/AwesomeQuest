using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public StateType state;
	public static GameManager instance = null;
	public bool changedLevel;
	public int destID;
	private int curChar;
	private ArrayList levelObjects;
	private bool[] levelVisited;
	
	public static GameManager Instance {
		get {
			if(instance == null) {
				instance = new GameObject ("GameManager").AddComponent<GameManager>();
			}
			return instance;
		}
	}
	
	public void OnApplicationQuit() {
		instance = null;
	}

	public int getCurChar() {
		return curChar;
	}

	public void setCurChar(int curChar) {
		this.curChar = curChar;
	}
	
	public bool getLevelVisited(int levelID) {
		if(levelVisited == null) {
			levelVisited = new bool[Application.levelCount];
		}
		return levelVisited [levelID];
	}
	
	public void setLevelVisited(int levelID) {
		if(levelVisited == null) {
			levelVisited = new bool[Application.levelCount];
		}
		levelVisited [levelID] = true;
	}
	
	public void addObject(ObjectState thing) {
		if(levelObjects == null) {
			levelObjects = new ArrayList ();
		}
		levelObjects.Add(thing);
	}
	
	public void removeObject(ObjectState thing) {
		levelObjects.Remove(thing);
	}
	
	public ArrayList getLevelObjects() {
		return levelObjects;
	}
	
	void Awake() {
		
	}
	
	// Use this for initialization
	void Start() {
		DontDestroyOnLoad(GameManager.Instance);
		curChar = 1;
	}
	
	// Update is called once per frame
	void Update() {
	
	}
	
	public enum StateType {
		DEFAULT,
		MENU,
		OPTIONS,
		CLASS_SWITCH,
		EXPLORE,
		CUTSCENE,
		BATTLE
	}
	;
}
