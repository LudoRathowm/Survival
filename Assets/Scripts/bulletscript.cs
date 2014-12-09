using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {
	bool activateit;
	float speed;
		float[] distances;
	float direction;
	float offset = 0.5f;
	bool shielding;
		public Rigidbody2D projectile; //me myself and I
		// Use this for initialization
		void Start () {
			Destroy (gameObject,3f);
			GameObject[] guns = GameObject.FindGameObjectsWithTag("Gun");
			foreach (GameObject gun in guns)
			speed = gun.GetComponent<pewpewgun>().speed; //fuck it only one speed per every gun
		}
		
		
		void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")&& other.gameObject.name != "ShieldItem"){
				string item = other.gameObject.GetComponent<Player>().Item;
				bool facingright = other.gameObject.GetComponent<Player>().facingRight;
				 shielding =  other.gameObject.GetComponent<Player>().imshieldingm8m8;
				if (item == "Shield"){
					direction = GetComponent<Rigidbody2D>().velocity.x;
				Debug.Log (direction);
				if (direction > 0 && !facingright){
					Debug.Log (shielding);
						if (shielding){
						Vector2 leftbounce = new Vector2 (transform.position.x-offset,transform.position.y);
							Rigidbody2D instantiateProjectile = Instantiate(projectile,leftbounce,transform.rotation) as Rigidbody2D;
							instantiateProjectile.velocity = transform.TransformDirection(new Vector3(-speed,0,0));
							Destroy(gameObject,0f);
						}
						else {
						Debug.Log ("NEED SOME ANIMATION BUT THATS IT SHIELDED");
							Destroy(gameObject,0f);}}
					else if (direction < 0 && facingright){
						if (shielding){
						Vector2 rightbounce = new Vector2 (transform.position.x+offset,transform.position.y);
						Rigidbody2D instantiateProjectile = Instantiate(projectile,rightbounce,transform.rotation) as Rigidbody2D;
						instantiateProjectile.velocity = transform.TransformDirection(new Vector3(-speed,0,0));
						Destroy(gameObject,0f);}
						else {
						Debug.Log ("NEED SOME ANIMATION BUT THATS IT SHIELDED");
							Destroy(gameObject,0f);}}
					else if (direction < 0 && !facingright || direction > 0 && facingright){
						
						GameObject victorysign = GameObject.Find("Text");
						int number = other.gameObject.GetComponent<Player>().PlayerNumber;
						if (number == 1)
							victorysign.GetComponent<GameMaster>().Winner = "Player 2";
						if (number == 2)
							victorysign.GetComponent<GameMaster>().Winner = "Player 1";
					other.gameObject.GetComponent<Player>().muhblood.Play (true);
						Destroy(gameObject,0f);

					}
				}
				if (item != "Shield"){
				GameObject victorysign = GameObject.Find("Text");
				int number = other.gameObject.GetComponent<Player>().PlayerNumber;
				if (number == 1)
					victorysign.GetComponent<GameMaster>().Winner = "Player 2";
				if (number == 2)
					victorysign.GetComponent<GameMaster>().Winner = "Player 1";
				other.gameObject.GetComponent<Player>().muhblood.Play (true);
					Destroy(gameObject,0f);}
			}
		}
	}