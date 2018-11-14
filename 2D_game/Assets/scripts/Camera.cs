using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public CharacterControl player;
	public bool isFollowing;

	public float xOffset;
	public float yOffset;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<CharacterControl>();
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing) {
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z-1 );
		}
	}
}
