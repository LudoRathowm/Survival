using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {
	Transform player1;
	Transform player2;
	Transform myTransform;
	float Xdistance;
	float Ydistance;
	float myX;
	float myY;
	float supermaxX = 50;
	float maxX = 20;
	float maxY = 20;
	float smallsize = 10;
	float largesize = 20;
	float largestsize = 30;
	float currentsize;
	Camera thecamera;
	public int zoomdistance; // 1= closer 2 = more distant
	// Use this for initialization
	void Start () {
		GameObject Player1 = GameObject.Find ("Player 1");
		player1 = Player1.transform;
		GameObject Player2 = GameObject.Find ("Player 2");
		player2 = Player2.transform;
		myTransform = transform;
		GameObject cameraobject = GameObject.Find ("Main Camera");
		thecamera = cameraobject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
			myX = (player1.position.x + player2.position.x)/2;
		    myY = (player2.position.y + player1.position.y)/2;
		myTransform.position = new Vector3 (myX,myY,myTransform.position.z);
		Xdistance = (player1.position.x - player2.position.x);
		Ydistance = (player1.position.y - player2.position.y);

		if (Xdistance < maxX && Xdistance > -maxX && Ydistance < maxY && Ydistance > -maxY){
			currentsize = thecamera.orthographicSize;
			thecamera.orthographicSize = Mathf.Lerp (currentsize, smallsize, Time.deltaTime);
			}
		if (Xdistance > maxX || Xdistance < -maxX || Ydistance > maxY || Ydistance < -maxY){
			currentsize = thecamera.orthographicSize;
			thecamera.orthographicSize = Mathf.Lerp (currentsize, largesize, Time.deltaTime);
			}
		if (Xdistance > supermaxX || Xdistance < - supermaxX){
			currentsize = thecamera.orthographicSize;
			thecamera.orthographicSize = Mathf.Lerp (currentsize, largestsize, Time.deltaTime);
		}
	}
}
