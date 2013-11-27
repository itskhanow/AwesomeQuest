using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public float smooth = 3f;
	public float camZ = -100f;
	public Transform target;
	private Transform player;
	private float toSize;
	private Vector2 lerping;

	// Use this for initialization
	void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		lerping = Vector2.Lerp(transform.position, target.position, smooth * Time.deltaTime);
		transform.position = new Vector3(lerping.x, lerping.y, camZ);
		//transform.position.x = Mathf.Lerp(transform.position.x, target.position.x, smooth * Time.deltaTime);
		//transform.position.y = Mathf.Lerp(transform.position.y, target.position.y, smooth * Time.deltaTime);
		toSize = 5f + (player.rigidbody2D.velocity.magnitude / 2);
		camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, toSize, smooth * Time.deltaTime);
	}
}
