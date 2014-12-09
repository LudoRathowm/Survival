using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	static int player1score = 0;
	static int player2score = 0;
	public string Winner;
	public AudioClip clip;
	public AudioClip walao;
	GUIText _player1;
	GUIText _player2;
	GUIText _commentator;
	float countdown = 3;
	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(walao, transform.position);
		GameObject player1 = transform.Find("Player 1 Score").gameObject;
		GameObject player2 = transform.Find("Player 2 Score").gameObject;
		GameObject commentator = transform.Find("Commentator").gameObject;
		_player1 = player1.GetComponent<GUIText>();
		_player2 = player2.GetComponent<GUIText>();
		_commentator= commentator.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		Winner = GetComponent<GameMaster>().Winner;
		_player1.text = "Player 1 score: " + player1score;
		_player2.text = "Player 2 score: " + player2score;
		if (player1score > player2score + 5)
			_commentator.text = "Player 2 is bad";
		if (player2score > player1score + 5)
			_commentator.text = "Player 1 is bad";


		if (Winner != ""){
			Vector3 gravity;
			gravity.x = 0;
			gravity.y = -9.8f;
			gravity.z = 0;
			Physics2D.gravity = gravity;
			AudioSource.PlayClipAtPoint(clip, transform.position);
			guiText.text = "The Winner is " + Winner;
		
			if (countdown > 0) 
				countdown -= Time.deltaTime;
			if (countdown < 0)
				countdown = 0;
			if (countdown == 0){
				if (Winner == "Player 1")
					player1score++;
				if (Winner == "Player 2")
					player2score++;

				Application.LoadLevel(Application.loadedLevelName);}}

	}
}
