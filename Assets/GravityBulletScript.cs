using UnityEngine;
using System.Collections;

public class GravityBulletScript : MonoBehaviour {
	public Rigidbody2D dot;
	public Rigidbody2D explosion;
	float dottimer;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,10);
	}
	
	// Update is called once per frame
	void Update () {
	if (dottimer > 0)
			dottimer -= Time.deltaTime;
	if (dottimer<0)
			dottimer=0;
	if (dottimer == 0){
			Rigidbody2D placedot = Instantiate(dot,transform.position,transform.rotation) as Rigidbody2D;
			dottimer = 0.2f;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Planet")){

			Rigidbody2D explode = Instantiate(explosion,transform.position,transform.rotation) as Rigidbody2D;
			Destroy (gameObject,0);
		}
		if (other.gameObject.CompareTag("Spaceship")){
			Debug.Log ("SHADDASHADDA");
			Rigidbody2D explode = Instantiate(explosion,transform.position,transform.rotation) as Rigidbody2D;
			Destroy(other.gameObject,0);
			Destroy (gameObject,0);
		}
	}
}
