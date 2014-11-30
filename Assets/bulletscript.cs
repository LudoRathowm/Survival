using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject,3f);
	}
	
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")){
			GameObject victorysign = GameObject.Find("Text");
			int number = other.gameObject.GetComponent<Player>().PlayerNumber;
			if (number == 1)
				victorysign.GetComponent<GameMaster>().Winner = "Player 2";
			if (number == 2)
				victorysign.GetComponent<GameMaster>().Winner = "Player 1";
			Destroy(gameObject,0f);
		}
	}}