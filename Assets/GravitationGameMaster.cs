using UnityEngine;
using System.Collections;

public class GravitationGameMaster : MonoBehaviour {
	GameObject SpaceShip1;
	GameObject SpaceShip2;
	GameObject Missile;
	public bool player1present;
	public bool player2present;
	public int winnernumber;
public	int currentspaceship = 0;
	public float player1fuel;
	public float player2fuel;
	public int player1missiles;
	public int player2missiles;
	float hugecamera = 1500;
	float normalcamera = 900;
	float maxdistanceb4camera = 800000;
	bool alreadyshot;
	float distance;
	Camera thecamera;
	// Use this for initialization
	void Start () {
		SpaceShip1 = GameObject.Find("SpaceShip1");
		SpaceShip2 = GameObject.Find("SpaceShip2");
		GameObject cameraobject = GameObject.Find ("Main Camera");
		thecamera = cameraobject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart"))
			Application.LoadLevel(Application.loadedLevelName);
	GameObject	player1 = GameObject.Find("SpaceShip1");
	GameObject player2 = GameObject.Find("SpaceShip2");
		if (!player1){
			player2missiles = player2.GetComponent<SpaceshipScript>().numberofmissiles;
			player2fuel = player2.GetComponent<SpaceshipScript>().Fuel;
			winnernumber = 2;
		}
		if (!player2){
			player1missiles = player1.GetComponent<SpaceshipScript>().numberofmissiles;
			player1fuel = player1.GetComponent<SpaceshipScript>().Fuel;
			winnernumber = 1;
		}
		else if (player1 && player2)
			winnernumber = 0;

		float currentsize = thecamera.orthographicSize;
		Missile = GameObject.FindGameObjectWithTag("Bullet");
		if (Missile){
			Vector3 vdistance = Missile.transform.position-transform.position;
			 distance = vdistance.sqrMagnitude;
			if (distance > maxdistanceb4camera*2)
				Destroy (Missile,0);
			if (distance > maxdistanceb4camera)
				thecamera.orthographicSize = Mathf.Lerp (currentsize, hugecamera, Time.deltaTime);
			else if (distance < maxdistanceb4camera)
				thecamera.orthographicSize = Mathf.Lerp (currentsize, normalcamera, Time.deltaTime);
		}
		if (!Missile)
			thecamera.orthographicSize = Mathf.Lerp (currentsize, normalcamera, Time.deltaTime);


		if (SpaceShip1 && SpaceShip2){
		if (currentspaceship == 0){
			SpaceShip1.GetComponent<SpaceshipScript>().itsmyturn = true;
			Transform arrow = SpaceShip1.transform.Find("arrow");
			arrow.gameObject.SetActive(true);
			alreadyshot = SpaceShip1.GetComponent<SpaceshipScript>().alreadyshot;
				bool immoving = SpaceShip1.GetComponent<SpaceshipScript>().immoving;
				if (immoving)
					arrow.gameObject.SetActive(false);
			if (alreadyshot && !immoving){
				GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
				if (!bullet){
					SpaceShip1.GetComponent<SpaceshipScript>().alreadyshot = false;
					currentspaceship = 1;
					arrow.gameObject.SetActive(false);
					SpaceShip1.GetComponent<SpaceshipScript>().itsmyturn = false;

				}
			}

		}
		if (currentspaceship == 1){
			SpaceShip2.GetComponent<SpaceshipScript>().itsmyturn = true;	
			Transform arrow = SpaceShip2.transform.Find("arrow");
			arrow.gameObject.SetActive(true);
			alreadyshot = SpaceShip2.GetComponent<SpaceshipScript>().alreadyshot;
				bool immoving = SpaceShip1.GetComponent<SpaceshipScript>().immoving;
				if (immoving)
					arrow.gameObject.SetActive(false);
			if (alreadyshot && !immoving){
				GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
				if (!bullet){
					SpaceShip2.GetComponent<SpaceshipScript>().alreadyshot = false;
					currentspaceship = 0;
					arrow.gameObject.SetActive(false);
					SpaceShip2.GetComponent<SpaceshipScript>().itsmyturn = false;
				}
				
				}}}}
}
