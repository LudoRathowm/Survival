using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AdjustFuel : MonoBehaviour {
	Text text;
	int playerturn;
	float fuelleft;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gamemaster = GameObject.Find("Game Master");
		playerturn = gamemaster.GetComponent<GravitationGameMaster>().currentspaceship;
		if (playerturn == 0){
			GameObject player = GameObject.Find("SpaceShip1");
			if (player)
			fuelleft = player.GetComponent<SpaceshipScript>().Fuel;
		}
		if (playerturn == 1){
			GameObject player = GameObject.Find("SpaceShip2");
			if (player)
			fuelleft = player.GetComponent<SpaceshipScript>().Fuel;
		}
		text.text = ("Fuel Left: ")+ fuelleft + (" Units") ;
	}
}
