using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FinalWinner : MonoBehaviour {
	int winner = 0;
	Text text;
	GameObject wininfograph;
	// Use this for initialization
	void Start () {
		wininfograph = GameObject.Find("Player 1 Score");
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		winner = wininfograph.gameObject.GetComponent<ScoreOrbital>().FinalWinner;
	
		if (winner != 0)
			text.text = "The Final Winner is Player "+ winner;


	}
}
