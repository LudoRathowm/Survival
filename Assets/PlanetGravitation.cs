using UnityEngine;
using System.Collections;

public class PlanetGravitation : MonoBehaviour {
	public float Radius;
	public float AvgDensity;
	float mindensity = 0.1f;
	float maxdensity = 10;
	float minray = 1000;
	float maxray = 20000;
	float earthRadius = 6371;
	float pi = 3.1416f;
	float PlanetVolume;
	Transform Bullet;
	Transform myTransform;
	Transform myMouth;
	float smileoffset = 1200f;
	float smilemultiplier;
	float BulletMass;
	float myMass;
	float distance;
	float Force;
	bool thereisabullet;
	Vector3 distanceRay;
	float Gconstant = 0.00000000006637f;
	// Use this for initialization
	void Start () {
		GeneratePlanet();
		myTransform = transform;
		myMouth = transform.Find("Smile");
		AdjustSize();
		AdjustMass();
	}
	
	// Update is called once per frame
	void Update () {
		TransformCheck();
		if (thereisabullet){
		DistanceCalculator();
		VectorCalculator();
		CalculateForce();
			ApplyForce();
			MoveMouth();}
	}
	
	void DistanceCalculator(){
		Vector3 offset = Bullet.position-myTransform.position;
		distance = (offset.sqrMagnitude)*1000;
	}
	void VectorCalculator(){
		distanceRay = myTransform.position-Bullet.position;
	}
	void CalculateForce(){
		Force = Gconstant*((BulletMass*myMass)/(distance*distance));
	}
	void ApplyForce(){
		Bullet.gameObject.rigidbody2D.AddForce(distanceRay*Force);
	}
	void MoveMouth(){
		smilemultiplier = Mathf.Lerp(myMouth.localScale.y,(1/distance*(distance-smileoffset*1000)),2);
		Vector3 smilescale = myMouth.localScale;
		smilescale.y = smilemultiplier;
		myMouth.localScale = smilescale;

	}
	void TransformCheck(){
		GameObject _bullet = GameObject.FindGameObjectWithTag("Bullet");


		if (_bullet){
			thereisabullet = true;
		Bullet = GameObject.FindGameObjectWithTag("Bullet").transform;
			BulletMass = Bullet.gameObject.GetComponent<Rigidbody2D>().mass;}
	
	else if (!_bullet){
		thereisabullet = false;
	}
	}
	void AdjustSize(){
		Vector3 planetscale = transform.localScale;
		planetscale.x *= (Radius/earthRadius);
		planetscale.y *= (Radius/earthRadius);
		transform.localScale = planetscale;
	}
	void AdjustMass(){
		float actualradius = 1000*Radius;
		 PlanetVolume = (4/3)*(actualradius*actualradius*actualradius)*pi;
		myMass = PlanetVolume*AvgDensity*1000;
	}
	void GeneratePlanet(){
		float density = Random.Range (mindensity,maxdensity);
		float ray = Random.Range (minray,maxray);
		AvgDensity = density;
		Radius = ray;
		float red = Random.Range(0.0f,1.0f);
		float blue = Random.Range(0.0f,1.0f);
		float green = Random.Range(0.0f,1.0f);
		Color colorplanet = Color.green;
		if (density < 1)
			colorplanet = Color.white;
		if (density > 1 && density < 2)
			colorplanet = Color.yellow;
		if (density > 2 && density < 3)
			colorplanet = Color.red;
		if (density > 4 && density < 5)
			colorplanet = Color.magenta;
		if (density>5 && density<6)
			colorplanet = Color.blue;
		if (density > 6 && density < 7)
			colorplanet = Color.cyan;
		if (density > 7 && density < 8)
			colorplanet = Color.green;
		if (density > 8 && density < 9)
			colorplanet = Color.gray;
		if (density > 9)
			colorplanet = Color.black;
	//	colorplanet = new Color (red,green,blue,1);
		GetComponent<SpriteRenderer>().color = colorplanet;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Planet"))
			Destroy(gameObject,0);
	}
}