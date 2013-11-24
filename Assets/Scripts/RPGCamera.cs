using UnityEngine;
using System.Collections;

public class RPGCamera : MonoBehaviour {
	
	public float smooth = 3f;
	public float yDist = 10f;
	public Transform cutsceneCam;
	private Transform player;
	private Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;
	private Vector3 relPlayerPos;
	private Quaternion lookAtRotation;
	private Vector3 stdPos;
	private Vector3 abvPos;
	private Vector3[] checkPoints;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		relCameraPos = new Vector3 (0f, yDist, -5f);
		relCameraPosMag = relCameraPos.magnitude - 0.5f;
		checkPoints = new Vector3[5];
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(GameManager.Instance.state == GameManager.StateType.EXPLORE) {
			standardCamera();
		} else if(GameManager.Instance.state == GameManager.StateType.CUTSCENE) {
			cutsceneCamera();
		}
	}
	
	void cutsceneCamera() {
		transform.position = Vector3.Lerp(transform.position, cutsceneCam.position, smooth * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, cutsceneCam.rotation, smooth * Time.deltaTime);
	}
	
	void standardCamera() {
		stdPos = player.position + relCameraPos;
		abvPos = player.position + Vector3.up * relCameraPosMag;
		
		checkPoints [0] = stdPos;
		checkPoints [1] = Vector3.Lerp(stdPos, abvPos, 0.25f);
		checkPoints [2] = Vector3.Lerp(stdPos, abvPos, 0.5f);
		checkPoints [3] = Vector3.Lerp(stdPos, abvPos, 0.75f);
		checkPoints [4] = abvPos;
		
		for(int i = 0; i < checkPoints.Length; i++) {
			if(viewPosCheck(checkPoints [i])) {
				break;
			}
		}

		newPos += new Vector3(0f, player.rigidbody.velocity.magnitude, 0f);
		
		transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
		
		relPlayerPos = player.position - transform.position;
		lookAtRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}
	
	bool viewPosCheck(Vector3 checkPos) {
		RaycastHit hit;
		
		if(Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag)) {
			if(hit.transform != player) {
				return false;
			}
		}
		
		newPos = checkPos;
		return true;
	}
}
