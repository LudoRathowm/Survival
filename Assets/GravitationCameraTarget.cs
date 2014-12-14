using UnityEngine;
using System.Collections;

public class GravitationCameraTarget : MonoBehaviour {
	Transform Player1;
	Transform Player2;
	Transform Missile;
	GameObject _Missile;
	float newpositionX;
	float newpositionY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetReferences();
		CalculatePosition();
		AdjustPosition();
	}

	void GetReferences(){
		Player1 = GameObject.Find("SpaceShip1").transform;
		Player2 = GameObject.Find("SpaceShip2").transform;
		_Missile = GameObject.FindGameObjectWithTag("Bullet");

		if (_Missile){
	
			Missile = _Missile.transform;}
	}
	void CalculatePosition(){
		if (Missile){
		newpositionX = (Player1.position.x+Player2.position.x+Missile.position.x)/3;
		newpositionY= (Player1.position.y+Player2.position.y+Missile.position.y)/3;
		}}
	void AdjustPosition(){
		if (Missile)
			transform.position = new Vector3 (newpositionX,newpositionY,transform.position.z);
	}
}
