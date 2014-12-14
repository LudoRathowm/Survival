using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreOrbital : MonoBehaviour {
	public static float Player1Score = 0;
	public static float Player2Score = 0;
	int playerscoremax = 30000;
	GameObject gamemaster;
	float timermax = 3;
	float timer = 3;
	bool alreadyawinner = false;
	float winbonus = 3000;
	float missilenegative = 5;
	float fuelpositive = 50;
	Text text;
	int winner;
	public int FinalWinner = 0; 
	public int playerscorenumber;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		gamemaster = GameObject.Find("Game Master");
	}
	
	// Update is called once per frame
	void Update () {
		winner = gamemaster.GetComponent<GravitationGameMaster>().winnernumber;
					CalculateScore();
		if (timer>0 && alreadyawinner)
			timer-=Time.deltaTime;
		if (timer < 0 && alreadyawinner)
			timer = 0;
		if (timer == 0 && alreadyawinner)
			Application.LoadLevel(Application.loadedLevelName);
		if (Player1Score >= playerscoremax){
			Player1Score = 0;
			Player2Score = 0;
			FinalWinner = 1;
			alreadyawinner = true;
		}
		if (Player2Score >= playerscoremax){
			Player1Score = 0;
			Player2Score = 0;
			alreadyawinner = true;
			FinalWinner = 2;
		}


	}
	void CalculateScore(){
		if (winner == 1 && !alreadyawinner){
			int numberofmissiles = gamemaster.GetComponent<GravitationGameMaster>().player1missiles;
			float fuel = gamemaster.GetComponent<GravitationGameMaster>().player1fuel;
			int realfuel = Mathf.FloorToInt(fuel);
			Player1Score += winbonus - missilenegative*numberofmissiles+realfuel*fuelpositive;
			alreadyawinner = true;
			}
		if (winner == 2 && !alreadyawinner){
			int numberofmissiles = gamemaster.GetComponent<GravitationGameMaster>().player2missiles;
			float fuel =gamemaster.GetComponent<GravitationGameMaster>().player2fuel;
			int realfuel = Mathf.FloorToInt(fuel);

			Player2Score += winbonus - missilenegative*numberofmissiles+realfuel*fuelpositive;
			alreadyawinner = true;
		}
		if (playerscorenumber == 1)
			text.text = "Player 1 Score: " + Player1Score;
		if (playerscorenumber == 2)
			text.text = "Player 2 Score: " + Player2Score;

	}
}
