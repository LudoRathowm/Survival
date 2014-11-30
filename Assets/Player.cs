using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public enum State {
		Normal,
		Dunno
	}
	public string Item = "none";
	public AudioClip clip;
	bool alreadyfed = false;
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
	bool facingRight = true;
	float hitraycast = 0.85f; // extra because muh balls
	float move;
	bool gotumbrella; //air control
	void Awake()
	{  mybody = rigidbody2D;
	//	anim = GetComponent<Animator>();
		halfdistanceheight = gameObject.collider2D.bounds.extents.y;	
		_state = State.Normal;
		StartCoroutine ("FSM");


	}
	
	void FixedUpdate(){
		Debug.DrawRay(transform.position,Vector3.down*(halfdistanceheight+hitraycast));
		if (Item != "Food"){
		if (Physics2D.Raycast(transform.position,Vector3.down, halfdistanceheight + hitraycast, whatIsGround)) //a bit more than the player collider height
			grounded = true;
			else grounded = false; }
		if (Item == "Food"){
			if (Physics2D.Raycast(transform.position,Vector3.down, (halfdistanceheight + hitraycast)*1.5f, whatIsGround)) //a bit more than the player collider height
				grounded = true;
			else grounded = false; 
		}
	}
	
	private IEnumerator FSM(){
		while (_alive){
			switch (_state) {
			case State.Normal:
				// GUNNING NIGGAS
				if (Item == "Gun"){
					GameObject gun = transform.Find("Gun").gameObject;
					gun.gameObject.SetActive(true);
					if ( facingRight)
						gun.gameObject.GetComponent<pewpewgun>().shootright = true;
					else if (!facingRight)
						gun.gameObject.GetComponent<pewpewgun>().shootright = false;
					if (Input.GetButtonDown("Action1") && PlayerNumber == 1)
						gun.gameObject.GetComponent<pewpewgun>().shoot = true;
					if (Input.GetButtonDown("Action2") && PlayerNumber == 2)
						gun.gameObject.GetComponent<pewpewgun>().shoot = true;
				}
				if (Item != "Gun"){
					GameObject gun = transform.Find("Gun").gameObject;
					gun.gameObject.SetActive(false);
				}
				if (Item == "Spring"){
					GameObject spring = transform.Find("SpringItem").gameObject;
					spring.gameObject.SetActive(true);
					jumpForce = 750;
					Jump ();

				}
				if (Item != "Spring"){
					GameObject spring = transform.Find("SpringItem").gameObject;
					spring.gameObject.SetActive(false);
					jumpForce = 750;}
					if (Item == "Umbrella"){
						GameObject umbrella = transform.Find ("UmbrellaItem").gameObject;
						umbrella.gameObject.SetActive(true);
						GetComponent<Rigidbody2D>().gravityScale = 0.8f;
						gotumbrella = true;
					}
					if (Item != "Umbrella"){
						GameObject umbrella = transform.Find ("UmbrellaItem").gameObject;
						umbrella.gameObject.SetActive(false);
						GetComponent<Rigidbody2D>().gravityScale = 3f;
						gotumbrella = false;
					}
				if (Item == "Food" && !alreadyfed){
					transform.localScale *= 1.5f;
					GetComponent<Rigidbody2D>().mass *= 3.37f;
					alreadyfed = true;
				}
				if (Item != "Food" && alreadyfed){
					alreadyfed = false;
					transform.localScale /=1.5f;
					GetComponent<Rigidbody2D>().mass /= 3.37f;
				}
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
				break;
			case State.Dunno:
				break;
			}
			yield return null;
		}

	}
	
	void Move () {
	//	anim.SetFloat("Speed", Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
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
		if (grounded){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));}
	}
	
	
	
	
	
	
	
	
	
}