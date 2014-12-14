using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceshipScript : MonoBehaviour {
public	bool itsmyturn ;
	public int playernumber;
	GameObject Fire;
	Transform shootingpoint;
	float rotation;
	public bool immoving;
	public float Fuel = 10;
	public int numberofmissiles = 0;
	float sensibility ;
	float lowsensibility = 100;
	float highsensibility = 50;
public	Rigidbody2D bullet;
	public Rigidbody2D explosion;
	Transform shootarrow;
	public bool alreadyshot = false;
	float shootspeed =2;
	float shootchange;
	float shootmodifier = 75;
	Transform myTransform;
	// Use this for initialization
	void Start () {


		myTransform = transform;
		shootarrow = transform.Find("arrow");
		shootingpoint =  transform.Find("ShootingPoint");
		Fire = transform.Find("fire").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (itsmyturn){
			Rotate();
			Moving();
			ChargeShoot();
			Shoot();
		
		}
	
	}


	void Rotate(){
		rotation = Input.GetAxis("Horizontal1");
		if (Input.GetButton("Action2")){
		
			sensibility = highsensibility;}
		else sensibility = lowsensibility;
		transform.Rotate (0,0,-rotation*sensibility*Time.deltaTime);
	}

	void ChargeShoot(){
		if (shootspeed > 7)
			shootarrow.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		if (shootspeed <1)
			shootarrow.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
		if (shootspeed > 1 && shootspeed < 5)
			shootarrow.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		if (shootspeed > 5 && shootspeed < 7)
			shootarrow.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
		if (shootspeed < 7 && shootspeed > 1){
		shootchange = Input.GetAxis("Vertical1");
		shootspeed += shootchange*Time.deltaTime;
		Vector3 newscale = shootarrow.localScale;
		newscale.x = shootspeed;
			shootarrow.localScale = newscale;}
		if (shootspeed > 7){
			shootchange = Input.GetAxis("Vertical1");
			if (shootchange<0)
				shootspeed +=  shootchange*Time.deltaTime;
			}
		if (shootspeed<1){
			shootchange = Input.GetAxis("Vertical1");
			if (shootchange>0)
				shootspeed +=  shootchange*Time.deltaTime;
		}
		
	}
	void Moving(){

		if (!alreadyshot){
			if (Input.GetButton("Action1") && Fuel>0){
			Vector3 distance = shootingpoint.position-transform.position;
			rigidbody2D.AddForce(distance*10);
			Fire.SetActive(true);
				immoving = true;
			Fuel -=Time.deltaTime;
				if (Fuel<0)
					Fuel = 0;

					
		}
			else {
				Fire.SetActive(false);
			if (immoving){
					immoving = false;
					alreadyshot = true;}
			}
		}}
	void Shoot(){
		if (!alreadyshot && Input.GetButtonDown("Jump2") && !immoving){
			Vector3 _shootingpoint =shootingpoint.position;
		Rigidbody2D instantiateProjectile = Instantiate(bullet,_shootingpoint,transform.rotation) as Rigidbody2D;
			numberofmissiles++;
		instantiateProjectile.velocity = transform.TransformDirection(new Vector3(shootspeed*shootmodifier,0,0));
			alreadyshot = true;
		}
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Planet")){
			Rigidbody2D explode = Instantiate (explosion,transform.position,transform.rotation) as Rigidbody2D;

			Destroy(gameObject,0);}
	}

	}
