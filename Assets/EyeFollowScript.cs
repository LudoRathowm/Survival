using UnityEngine;
using System.Collections;

public class EyeFollowScript : MonoBehaviour {
	Transform target;
	float speed = 666;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
		if (bullet){
			target = bullet.transform;
	
			Vector3 vectorToTarget = target.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);}
	}
}
