using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	Transform player1;
	bool alreadyawinner=false;
	Transform player2;
	public float deathheight; //ie when did you fall down and rip'd?
	public string Winner;
	Transform puppy;
	// Use this for initialization
	void Start () {
		GameObject Player1 = GameObject.Find("Player 1");
		GameObject Player2 = GameObject.Find("Player 2");
		player1 = Player1.transform;
		player2 = Player2.transform;
		GameObject Puppy = GameObject.Find ("puppy");
		puppy = Puppy.transform;


	}
	
	// Update is called once per frame
	void LateUpdate () {
		deathheight += 0.5f*Time.deltaTime;
		puppy.Translate (new Vector3 (0,0.5f*Time.deltaTime,0));


		if (player1.position.y < deathheight && Winner == "" && !alreadyawinner){
			Winner = "Player 2";
			Debug.Log ("YES");
			alreadyawinner = true;}

		if (player2.position.y < deathheight && Winner == "" && !alreadyawinner){
			Winner = "Player 1";
			Debug.Log ("NO");
			alreadyawinner = true;}
	}
}
