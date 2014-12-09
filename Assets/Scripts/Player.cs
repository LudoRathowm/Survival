using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public enum State {
		Normal,
		Shield,
		Spring,
		Umbrella,
		Food,
		Drink,
		Gun,
		Knife,
		Gravity
	}
	public Rigidbody2D throwingknife;
	Vector3 gravity;
	Transform newrotation; // to rotate around when gravity changes;
	int gravitydirection = 0;
	float gravityamount = 9.8f;
	float gravityinputwindowset = 1;
	float gravityinputwindow =  1;
	bool gravityinput = false; //just stuff to set up a timer for gravity input
	GameObject gun;
	GameObject spring;
	GameObject shield;
	GameObject umbrella;
	GameObject knife;
	GameObject Rotation;
	GameObject GravityRing;
	public ParticleSystem muhblood;
	bool particledirection = true; //rotating particle emitter
	public string Item = "none";
	public AudioClip clip;
	float knifeoffeset = 1;
	bool throwknife = false;
	float throwspeed = 100;
	float shieldtiming = 3f; //to deflect projectiles
	float restoftheshieldcooldown = 2; // to give a cd to shielding;
	public bool imshieldingm8m8;
	bool shieldcd;
	float shieldtimer;
	bool alreadybig = false; // for food 
	bool alreadysmall = false; //for drink
Transform[] ItemTransforms;
	public int PlayerNumber;
	float halfdistanceheight; //raycasting for groundcheck
	[SerializeField] LayerMask whatIsGround;	
	public bool grounded;
	float jumpForce = 750f;
	bool jump;
	Rigidbody2D mybody;
	bool _alive = true;
	//Animator anim;
	State _state;
	float maxSpeed = 15;
	public bool facingRight = true;
	float hitraycast = 0.85f; // extra because muh balls
	float move;
	bool gotumbrella; //air control
	void Awake()
	{  mybody = rigidbody2D;
	//	anim = GetComponent<Animator>();
		halfdistanceheight = gameObject.collider2D.bounds.extents.y;	
		_state = State.Normal;
		muhblood = transform.Find("Particle System").gameObject.particleSystem;
		StartCoroutine ("FSM");
		Rotation = transform.Find("Rotation").gameObject;
		Rotation.gameObject.GetComponent<RotateTest>().PlayerNumber = PlayerNumber;
		newrotation = transform;


	}
	
	void FixedUpdate(){
		Debug.DrawRay(transform.position,Vector3.down*(halfdistanceheight+hitraycast)*0.25f);
		if (Item == "Gravity"){
			if (gravitydirection == 1){
				if (Physics2D.Raycast(transform.position,Vector3.right, halfdistanceheight + hitraycast, whatIsGround)) //a bit more than the player collider height
					grounded = true;
				else grounded = false; 
			}
			if (gravitydirection == 2){
				if (Physics2D.Raycast(transform.position,Vector3.up, halfdistanceheight + hitraycast, whatIsGround)) //a bit more than the player collider height
				grounded = true;
				else grounded = false; 
			}
			if (gravitydirection == 3){
				Debug.DrawRay(transform.position,Vector3.left*(halfdistanceheight+hitraycast));
				if (Physics2D.Raycast(transform.position,Vector3.left, halfdistanceheight + hitraycast, whatIsGround)) //a bit more than the player collider height
				{Debug.Log ("WW");
				grounded = true;}

				else grounded = false; }
			if (gravitydirection == 0){
				if (Physics2D.Raycast(transform.position,Vector3.down, halfdistanceheight + hitraycast, whatIsGround)) //a bit more than the player collider height
					grounded = true;
				else grounded = false; }


		}
		if (Item != "Food" && Item != "Drink" && Item != "Gravity"){
		if (Physics2D.Raycast(transform.position,Vector3.down, halfdistanceheight + hitraycast, whatIsGround)) //a bit more than the player collider height
			grounded = true;
			else grounded = false; }
		if (Item == "Food"){
			if (Physics2D.Raycast(transform.position,Vector3.down, (halfdistanceheight + hitraycast)*1.5f, whatIsGround)) //a bit more than the player collider height
				grounded = true;
			else grounded = false; 
		}
		if (Item == "Drink"){
			if (Physics2D.Raycast(transform.position,Vector3.down, (halfdistanceheight + hitraycast)*0.33f, whatIsGround)) //a bit more than the player collider height
				grounded = true;
			else grounded = false; 
		}
		if (grounded)
			GetComponent<Rigidbody2D>().drag = 10;
		else if (!grounded)
			GetComponent<Rigidbody2D>().drag = 0;
		if (facingRight)
			muhblood.transform.rotation = Quaternion.Euler (0,90,0);
		if (!facingRight)
			muhblood.transform.rotation = Quaternion.Euler (0,-90,0);
	}
	
	private IEnumerator FSM(){
		while (_alive){
			switch (_state) {
			case State.Normal:
				Normal ();
				break;
			case State.Shield:
				MovementInputs();
				if (Item != "Shield"){

					shield.gameObject.SetActive(false);
					_state = State.Normal;
				}
				if (Input.GetButtonDown("Action1") && PlayerNumber == 1 && !imshieldingm8m8 && !shieldcd) {
					imshieldingm8m8 = true;
					shieldtimer = shieldtiming;

				}
				if (Input.GetButtonDown("Action2") && PlayerNumber == 2 && !imshieldingm8m8 && !shieldcd) {
					imshieldingm8m8 = true;
					shieldtimer = shieldtiming;

				}
				if (shieldtimer > 0){
					shieldtimer -= Time.deltaTime;
				}
				if (shieldtimer < 0)
					shieldtimer = 0;
				if (shieldtimer == 0){
					if (!shieldcd && imshieldingm8m8){
					imshieldingm8m8 = false;
					shieldcd = true;
						shieldtimer = restoftheshieldcooldown;}
					else if (shieldcd)
						shieldcd = false;
				}	
				break;
			case State.Gun:
				MovementInputs();
				if (Item != "Gun"){
					gun.gameObject.SetActive(false);
					_state = State.Normal;
				}
				if ( facingRight)
					gun.gameObject.GetComponent<pewpewgun>().shootright = true;
				else if (!facingRight)
					gun.gameObject.GetComponent<pewpewgun>().shootright = false;
				if (Input.GetButtonDown("Action1") && PlayerNumber == 1)
					gun.gameObject.GetComponent<pewpewgun>().shoot = true;
				if (Input.GetButtonDown("Action2") && PlayerNumber == 2)
					gun.gameObject.GetComponent<pewpewgun>().shoot = true;
				break;
			case State.Spring:
				MovementInputs();
				jumpForce = 750;
				Jump ();
				if (Item != "Spring"){

					spring.gameObject.SetActive(false);
					jumpForce = 750;
					_state = State.Normal;}
				break;
			case State.Umbrella:
				MovementInputs();				
				GetComponent<Rigidbody2D>().gravityScale = 0.8f;
				gotumbrella = true;
				if (Item != "Umbrella"){
					umbrella.gameObject.SetActive(false);
					GetComponent<Rigidbody2D>().gravityScale = 3f;
					gotumbrella = false;
					_state = State.Normal;
				}
				break;
			case State.Food:
				MovementInputs();
				if (Item != "Food" && alreadybig){
					alreadybig = false;
					transform.localScale /=1.5f;
					GetComponent<Rigidbody2D>().mass /= 3.37f;
					_state = State.Normal;
				}
				break;
			case State.Drink:
				MovementInputs();				
				if (Item != "Drink" && alreadysmall){
					alreadysmall = false;
					transform.localScale /=0.5f;
					GetComponent<Rigidbody2D>().mass *= 3.37f;
					_state = State.Normal;
				}
				break;
			case State.Knife:
				MovementInputs();
	
				Vector2 throwpositionR = new Vector2 (transform.position.x+knifeoffeset,transform.position.y);
				Vector2 throwpositionL = new Vector2 (transform.position.x-knifeoffeset,transform.position.y);
				if (throwknife){

					throwknife = false;
					knife.gameObject.GetComponent<KnifeScript>().FacingRight = facingRight;
					knife.gameObject.GetComponent<KnifeScript>().throwknife = true;


				}
				if (Item != "Knife"){
					knife.gameObject.SetActive(false);
			
					_state = State.Normal;
				}
				if (Input.GetButtonDown("Action1") && PlayerNumber == 1) {
					throwknife = true;
					
				}
				if (Input.GetButtonDown("Action2") && PlayerNumber == 2){
					throwknife = true;
					
				}
			
				break;
			case State.Gravity:
				MovementInputs();
				GravityInput();
				GravityDirection();
				Physics2D.gravity = gravity;
				AdjustDirection();
				GravityDebugger();
				break;
			}
			yield return null;
		}

	}
	
	void Move () {
	//	anim.SetFloat("Speed", Mathf.Abs(move));
		if (gravitydirection == 0)
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		if (gravitydirection == 1)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, move*maxSpeed);
		if (gravitydirection == 2)
			rigidbody2D.velocity = new Vector2 (-move*maxSpeed, rigidbody2D.velocity.y);
		if (gravitydirection == 3)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -move*maxSpeed);

		if (jump) {
			jump = false;
			Jump();
		}
		
	}
	
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 muhscale = transform.localScale;
		muhscale.x *= -1;
		transform.localScale = muhscale;
	}
	void Jump (){
		if (grounded && Item != "Food" && Item != "Drink" && Item != "Gravity"){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));}
		
		if (grounded && Item == "Food" && Item != "Drink"){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			rigidbody2D.AddForce(new Vector2(0f, jumpForce*6));}
		if (grounded && Item != "Food" && Item == "Drink"){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			rigidbody2D.AddForce(new Vector2(0f, jumpForce/4));}
		if (Item == "Gravity"){
			if (gravitydirection == 0)
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		if (gravitydirection == 1)
			rigidbody2D.AddForce(new Vector2(-jumpForce,0f));
		if (gravitydirection == 2)
			rigidbody2D.AddForce(new Vector2(0,-jumpForce));
		if (gravitydirection == 3)
			rigidbody2D.AddForce(new Vector2(jumpForce, 0f));}
	}
	void Normal (){
		MovementInputs();


		if (Item == "Shield"){

		shield = transform.Find ("ShieldItem").gameObject;
			shield.gameObject.SetActive(true);
			_state = State.Shield;}
		


		if (Item == "Gun"){
			gun = Rotation.gameObject.transform.Find("Gun").gameObject;
			gun.gameObject.SetActive(true);
			_state = State.Gun;
		}
	
		if (Item == "Spring"){
			spring = transform.Find("SpringItem").gameObject;
			spring.gameObject.SetActive(true);
			_state = State.Spring;
			
		}
	
		if (Item == "Umbrella"){
			umbrella = transform.Find ("UmbrellaItem").gameObject;
			umbrella.gameObject.SetActive(true);
			_state = State.Umbrella;
		}

		if (Item == "Food" && !alreadybig){
			transform.localScale *= 1.5f;
			GetComponent<Rigidbody2D>().mass *= 3.37f;
			alreadybig = true;
			_state = State.Food;
		}
		if (Item == "Drink" && !alreadysmall){
			
			transform.localScale = new Vector3 (0.5f,0.5f,0);
			GetComponent<Rigidbody2D>().mass /= 3.37f;
			alreadysmall = true;
			_state = State.Drink;
		}
		if (Item == "Knife"){
			knife = Rotation.gameObject.transform.Find ("KnifeItem").gameObject;
			knife.gameObject.SetActive (true);
			knife.GetComponent<KnifeScript>().playernumber = PlayerNumber;
			_state = State.Knife;
		}
		if (Item == "Gravity"){
			GravityRing = transform.Find ("GravityItem").gameObject;
			GravityRing.gameObject.SetActive(true);

			_state = State.Gravity;
		}



	}

	void MovementInputs (){
		if (move != 0 || jump)
			Move ();
		if(move > 0 && !facingRight )
			Flip();
		else if(move < 0 && facingRight)
			Flip();
		
		if (Input.GetButtonDown("Jump1") && PlayerNumber == 1) 
			jump = true;
		if (Input.GetButtonDown("Jump2") && PlayerNumber == 2) 
			jump = true;
		if (grounded && PlayerNumber == 1 || gotumbrella && PlayerNumber == 1 )
			move = Input.GetAxis("Horizontal1");
		if (grounded && PlayerNumber == 2 || gotumbrella && PlayerNumber == 2 )
			move = Input.GetAxis("Horizontal2");

	}

	void GravityDirection ()
	{
		if(gravitydirection == 1)
	{
		gravity.x = gravityamount;
		gravity.y = 0;
		gravity.z = 0;
		
	}
	if(gravitydirection == 2)
	{
		gravity.x = 0;
		gravity.y = gravityamount;
		gravity.z = 0;
	
	}
	if (gravitydirection == 3){
		gravity.x = -gravityamount;
		gravity.y = 0;
		gravity.z = 0;
	
	}
	if (gravitydirection == 0){
		gravity.x = 0;
		gravity.y = -gravityamount;
		gravity.z = 0;
	
	}
	if (gravitydirection > 3)
		gravitydirection = 0;
	if (gravitydirection < 0)
		gravitydirection = 3;

	}

	void GravityInput(){
		if (PlayerNumber == 1 && Input.GetButtonDown("Action1"))
			gravityinput = true;
		
		if (PlayerNumber == 2 && Input.GetButtonDown("Action2"))
			gravityinput = true;


	   if (gravityinputwindow > 0 && gravityinput){
			gravityinputwindow -= Time.deltaTime;
		if (PlayerNumber == 1 && Input.GetAxis("Vertical1")>0){
				gravitydirection++;
				gravityinput = false;
				gravityinputwindow = gravityinputwindowset;
			}
		if (PlayerNumber == 1 && Input.GetAxis("Vertical1")<0){
				gravityinput = false;
				gravitydirection-=1;
				gravityinputwindow = gravityinputwindowset;
		}
		if (PlayerNumber == 2 && Input.GetAxis("Vertical2")<0){
				gravitydirection-=1;
				gravityinput = false;
				gravityinputwindow = gravityinputwindowset;
			}
		if (PlayerNumber == 2 && Input.GetAxis("Vertical2")>0){
				gravitydirection++;
				gravityinput = false;	
				gravityinputwindow = gravityinputwindowset;;
			}
		}
		if (gravityinputwindow<0 && gravityinput)
			gravityinputwindow = 0;
		if (gravityinputwindow == 0 && gravityinput){
			gravityinput = false;

			gravityinputwindow = gravityinputwindowset;
		}
	}
	void AdjustDirection (){

		if (gravitydirection == 1){
			if (transform.rotation != Quaternion.Euler ( 0, 0,90))
				newrotation.rotation = Quaternion.Euler ( 0, 0,90);
		}
		if (gravitydirection == 2){
			if (transform.rotation != Quaternion.Euler ( 0, 0,180))
				newrotation.rotation = Quaternion.Euler ( 0, 0,180);
		}
		if (gravitydirection == 3){
			if (transform.rotation != Quaternion.Euler ( 0, 0,-90))
				newrotation.rotation = Quaternion.Euler ( 0, 0,-90);
		}
		if (gravitydirection == 0){
			if (transform.rotation != Quaternion.Euler ( 0, 0,0))
				newrotation.rotation = Quaternion.Euler ( 0, 0,0);
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, newrotation.rotation,5f);
	}

	void GravityDebugger(){
		GameObject text = GameObject.Find("Text");
		string winrar = text.gameObject.GetComponent<Victory>().Winner;
		if (winrar != "" && gravitydirection != 0)
			gravitydirection =0;
	}
	
	
	
	
	
}