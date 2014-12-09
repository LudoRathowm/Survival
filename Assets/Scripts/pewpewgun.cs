using UnityEngine;
using System.Collections;

public class pewpewgun : MonoBehaviour {
	public bool shoot = false;
	public Rigidbody2D projectile;
	public bool shootright;
	public float speed = 66777;
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

		AudioSource.PlayClipAtPoint(clip, transform.position);
		if (shootright){
			Rigidbody2D instantiateProjectile = Instantiate(projectile,transform.position,transform.parent.transform.rotation) as Rigidbody2D;
			instantiateProjectile.velocity = transform.TransformDirection(new Vector3(speed,0,0));}

		else if (!shootright){


			Rigidbody2D instantiateProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody2D;
			instantiateProjectile.velocity = transform.TransformDirection(new Vector3(-speed,0,0));
	//	instantiateProjectile.velocity = transform.forward * speed;
		}
		}
		//	instantiateProjectile.velocity = new Vector3(speed*Mathf.Cos(transform.parent.transform.rotation.z+transform.parent.transform.rotation.w),speed*Mathf.Sin(transform.parent.transform.rotation.z+transform.parent.transform.rotation.w),0);}
		//	instantiateProjectile.velocity = instantiateProjectile.transform.forward * speed;}

	
	
}

