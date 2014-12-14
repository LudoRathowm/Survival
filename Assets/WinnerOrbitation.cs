using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WinnerOrbitation : MonoBehaviour {
	GameObject player1;
	GameObject player2;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		player1 = GameObject.Find("SpaceShip1");
		player2 = GameObject.Find("SpaceShip2");
		if (!player1)
			text.text = "Player 2 Wins";
		if (!player2)
			text.text = "Player 1 Wins";
	}
}
