using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerTurn : MonoBehaviour {
	Text text;
	GameObject gamemaster;
	// Use this for initialization
	void Start () {
		gamemaster = GameObject.Find("Game Master");
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		int turn = gamemaster.GetComponent<GravitationGameMaster>().currentspaceship;
		if (turn == 1){
			text.color = Color.green;
			text.text = "Player 2 Turn";}
		if (turn == 0){
			text.color = Color.magenta;
			text.text = "Player 1 Turn";}
	}
}
