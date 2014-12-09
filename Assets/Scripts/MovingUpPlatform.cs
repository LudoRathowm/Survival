using UnityEngine;
using System.Collections;

public class MovingUpPlatform : MonoBehaviour {
	public float maxheight;
	public float minheight;
	bool goup = true;
	float speed = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (goup && transform.position.y < maxheight)
			transform.Translate(0,speed*Time.deltaTime,0);
		if (goup && transform.position.y > maxheight)
			goup = false;
		if (!goup && transform.position.y > minheight)
			transform.Translate(0,-speed*Time.deltaTime,0);
		if (!goup && transform.position.y < minheight)
			goup = true;
	}
}
