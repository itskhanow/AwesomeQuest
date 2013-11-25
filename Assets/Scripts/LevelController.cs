using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	
	private ArrayList levelObjects;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}
	
	void Awake() {
		levelObjects = new ArrayList ();
		spawnPlayer();
		spawnMobs();
		GameManager.Instance.state = GameManager.StateType.EXPLORE;
	}
	
	private void spawnPlayer() {
		GameObject.Instantiate(Resources.Load("Prefabs/BuddyController"),
		                       GameObject.FindGameObjectWithTag("Player").transform.position,
		                       GameObject.FindGameObjectWithTag("Player").transform.rotation);
		GameObject[] exitZones = GameObject.FindGameObjectsWithTag("ExitZone");
		foreach(GameObject exitZone in exitZones) {
			if(exitZone.GetComponent<ExitZone>().spawnID == GameManager.Instance.destID
				&& GameManager.Instance.changedLevel == true) {
				GameObject.FindGameObjectWithTag("Player").transform.position = exitZone.transform.position;
				GameObject.FindGameObjectWithTag("Buddy").transform.position = exitZone.transform.position + exitZone.transform.forward;
			}
		}

		//Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").collider, GameObject.FindGameObjectWithTag("Buddy").collider);
	}
	
	private void spawnMobs() {
		if(GameManager.Instance.getLevelVisited(Application.loadedLevel) == false) {
			GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
			foreach(GameObject spawn in spawnPoints) {
				levelObjects.Add(GameObject.Instantiate(spawn.GetComponent<Spawner>().mob, spawn.transform.position, spawn.transform.rotation));
			}
		} else {
			ArrayList toRemove = new ArrayList ();
			foreach(ObjectState mob in GameManager.Instance.getLevelObjects()) {
				if(mob.levelID == Application.loadedLevel) {
					if(mob.IsAlive) {
						levelObjects.Add(GameObject.Instantiate(Resources.Load("Prefabs/" + mob.mobName), mob.Position, Quaternion.identity));
					}
					toRemove.Add(mob);
				}
			}
			foreach(ObjectState mob in toRemove) {
				GameManager.Instance.removeObject(mob);
			}
		}
	}
	
	public void changeLevel(int loadID) {
		foreach(GameObject mob in levelObjects) {
			mob.GetComponent<ObjectState>().saveState();
			GameManager.Instance.addObject(mob.GetComponent<ObjectState>());
		}
		GameManager.Instance.setLevelVisited(Application.loadedLevel);
		GameManager.Instance.changedLevel = true;
		Application.LoadLevel(loadID);
	}
}
