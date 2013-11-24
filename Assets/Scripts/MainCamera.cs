using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public int smooth = 3;
	public Transform target;

	private Transform player;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2.Lerp(transform.position, player.position, smooth * Time.deltaTime);
	}
}
