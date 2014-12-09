using UnityEngine;
using System.Collections;

public class MovingSidePlatform : MonoBehaviour {
	public float maxX;
	public float minX;
	bool goright = true;
	float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (goright && transform.position.x < maxX)
			transform.Translate(speed*Time.deltaTime,0,0);
		if (goright && transform.position.x > maxX)
			goright = false;
		if (!goright && transform.position.x > minX)
			transform.Translate(-speed*Time.deltaTime,0,0);
		if (!goright && transform.position.x < minX)
			goright = true;
	}
}
