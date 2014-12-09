using UnityEngine;
using System.Collections;

public class Shoespickup : MonoBehaviour {
	int playernumber;
	bool pickup;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			playernumber = other.gameObject.GetComponent<Player>().PlayerNumber;
			if (pickup){
				other.gameObject.GetComponent<Player>().Item = "Gun";
				Destroy (this.gameObject,0);}
		}
	}
	
	void Update (){
		if (Input.GetButtonDown("Item2") && playernumber == 2){
			GameObject Player2 = GameObject.Find ("Player 2");
			Player2.GetComponent<Player>().Item = "Gun";
			Destroy (this.gameObject,0);
		}
		
		if (Input.GetButtonDown("Item1") && playernumber == 1){
			GameObject Player1 = GameObject.Find ("Player 1");
			Player1.GetComponent<Player>().Item = "Gun";
			Destroy (this.gameObject,0);
		}
		
		
		
	}}

