using UnityEngine;
using System.Collections;

public class KnifeScript : MonoBehaviour {
	float direction;
	public int playernumber;
	string item ;
	GameObject parent; 
	GameObject player;
	public bool FacingRight;
	public bool throwknife;
	public Rigidbody2D Throwingknife;
	float speed = 66;
	// Use this for initialization
	void Start () {
		parent = transform.parent.transform.gameObject;
		player = parent.transform.parent.transform.gameObject;
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag("Player")&& other.gameObject.name != "ShieldItem"){
		
	item= other.gameObject.GetComponent<Player>().Item;
			bool facingright = other.gameObject.GetComponent<Player>().facingRight;
			if (item == "Shield"){
				direction = parent.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x;
	
				if (direction > 0 && !facingright){			
										Debug.Log ("NEED SOME ANIMATION BUT THATS IT SHIELDED");
					}
				else if (direction < 0 && facingright){
						Debug.Log ("NEED SOME ANIMATION BUT THATS IT SHIELDED");
					}
				else if (direction < 0 && !facingright || direction > 0 && facingright){
					
					GameObject victorysign = GameObject.Find("Text");
					other.gameObject.GetComponent<Player>().muhblood.Play (true);

					int number = other.gameObject.GetComponent<Player>().PlayerNumber;
					if (number == 1)
						victorysign.GetComponent<GameMaster>().Winner = "Player 2";
					if (number == 2)
						victorysign.GetComponent<GameMaster>().Winner = "Player 1";
					Destroy(gameObject,0f);
				}
			}
			if (item != "Shield"){
				other.gameObject.GetComponent<Player>().muhblood.Play (true);
				GameObject victorysign = GameObject.Find("Text");
				int number = other.gameObject.GetComponent<Player>().PlayerNumber;
				if (number == 1)
					victorysign.GetComponent<GameMaster>().Winner = "Player 2";
				if (number == 2)
					victorysign.GetComponent<GameMaster>().Winner = "Player 1";
				}
		}
	}
	void Update (){
		if (throwknife){
	


				Rigidbody2D instantiateProjectile = Instantiate(Throwingknife,transform.position,transform.rotation) as Rigidbody2D;	
			if (FacingRight)
		        instantiateProjectile.velocity = transform.TransformDirection(new Vector3(speed,0,0));
			if (!FacingRight)
				instantiateProjectile.velocity = transform.TransformDirection(new Vector3(-speed,0,0));
			player.GetComponent<Player>().Item = "";
			throwknife = false;}
	
		}
	}


