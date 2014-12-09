using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {
	float movement;
	float maxangle = 0.6f;
	public float sensibility = 100;
	public int PlayerNumber;

	
	
	// Update is called once per frame
	void Update () {
		Quaternion rotation = Quaternion.identity;


		transform.Rotate (0,0,movement*sensibility*Time.deltaTime);
		if (PlayerNumber == 1){
		if (transform.rotation.z > -maxangle && transform.rotation.z < maxangle)
			movement = Input.GetAxis("Vertical1");

		if (transform.rotation.z<-maxangle)
			if (Input.GetAxis("Vertical1")>0)
				movement = Input.GetAxis("Vertical1");
		else if (Input.GetAxis("Vertical1")<0)
			movement = 0;
		if (transform.rotation.z > maxangle)
			if (Input.GetAxis("Vertical1")<0)
				movement = Input.GetAxis("Vertical1");
		else if (Input.GetAxis("Vertical1")>0)
			movement = 0;
		}
		if (PlayerNumber == 2){
			if (transform.rotation.z > -maxangle && transform.rotation.z < maxangle)
				movement = Input.GetAxis("Vertical2");
			
			if (transform.rotation.z<-maxangle)
				if (Input.GetAxis("Vertical2")>0)
					movement = Input.GetAxis("Vertical2");
			else if (Input.GetAxis("Vertical2")<0)
				movement = 0;
			if (transform.rotation.z > maxangle)
				if (Input.GetAxis("Vertical2")<0)
					movement = Input.GetAxis("Vertical2");
			else if (Input.GetAxis("Vertical2")>0)
				movement = 0;
		}

	}
}
