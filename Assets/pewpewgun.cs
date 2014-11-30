using UnityEngine;
using System.Collections;

public class pewpewgun : MonoBehaviour {
	public bool shoot = false;
	public Rigidbody2D projectile;
	public bool shootright;
	float speed = 66;
	float shootimer;
	static float shootdelay = 2;
	public AudioClip clip;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if (shootimer > 0)
			shoot = false;
				shootimer -=Time.deltaTime;
			if (shootimer<0)
			shootimer = 0;
		if (shootimer == 0){
			if (shoot){
				shoot = false;
				Shoot();
				shootimer = shootdelay;
			}

		}
			
		}

	void Shoot (){
		Rigidbody2D instantiateProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody2D;
		AudioSource.PlayClipAtPoint(clip, transform.position);
		if (shootright)
		instantiateProjectile.velocity = transform.TransformDirection(new Vector3(speed,0,0));
		if (!shootright)
		instantiateProjectile.velocity = transform.TransformDirection(new Vector3(-speed,0,0));
	}
}
