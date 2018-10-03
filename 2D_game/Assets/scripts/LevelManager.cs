using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public GameObject CurrentCheckPoint;
	private Rigidbody2D PC;

	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	public float RespawnDelay;

	public int PointPenaltyOnDeath;

	private float GravityScore;

	void start () {
		PC = FindObjectOfType<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer () {
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo () {
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
		//hide pc
		// pc.enabled  =  false;

		PC.GetComponent<Renderer>().enabled = false;
		//gravity reset
		GravityScore = PC.GetComponent<Rigidbody2D>().gravityScale;
		PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
		PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug.log ("PC Respawn");

		yield return new WaitForSeconds (RespawnDelay);

		PC.GetComponent<Rigidbody2D>().gravityScale = GravityScore;
		PC.transform.position = CurrentCheckPoint.transform.position;

		PC.GetComponent<Renderer>().enabled = true;

		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
