using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	void Start (){
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Ground"))
		{
			Destroy(gameObject,0);}
		if (other.gameObject.CompareTag("Player")){
					GameObject victorysign = GameObject.Find("Text");
					other.gameObject.GetComponent<Player>().muhblood.Play (true);
			Vector3 gravity;
			gravity.x = 0;
			gravity.y = -9.8f;
			gravity.z = 0;
			Physics2D.gravity = gravity;
					int number = other.gameObject.GetComponent<Player>().PlayerNumber;
			          string alreadyawinner = victorysign.GetComponent<GameMaster>().Winner;
			if (alreadyawinner == ""){
					if (number == 1)
						victorysign.GetComponent<GameMaster>().Winner = "Player 2";
					if (number == 2)
						victorysign.GetComponent<GameMaster>().Winner = "Player 1";
			}

		}}}