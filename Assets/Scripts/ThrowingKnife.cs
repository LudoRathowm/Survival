using UnityEngine;
using System.Collections;

public class ThrowingKnife : MonoBehaviour {
	float direction;
	string item ;
	bool goingright = true;
	public GameObject KnifePickUp;
	public GameObject KnifeStuck;
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag("Ground")){

			Instantiate(KnifeStuck,transform.position,Quaternion.identity);

		

				KnifeStuck.transform.localScale *=-1;

			Destroy(gameObject,0f);
		}
		if (other.gameObject.CompareTag("Player")&& other.gameObject.name != "ShieldItem"){
			item= other.gameObject.GetComponent<Player>().Item;
			bool facingright = other.gameObject.GetComponent<Player>().facingRight;
			if (item == "Shield"){
				direction = GetComponent<Rigidbody2D>().velocity.x;
				
				if (direction > 0 && !facingright){			
					Debug.Log ("NEED SOME ANIMATION BUT THATS IT SHIELDED");
					Instantiate(KnifePickUp,transform.position,Quaternion.identity);
					Destroy(gameObject,0f);}
				else if (direction < 0 && facingright){
					Debug.Log ("NEED SOME ANIMATION BUT THATS IT SHIELDED");
					Instantiate(KnifePickUp,transform.position,Quaternion.identity);
					Destroy(gameObject,0f);}
				else if (direction < 0 && !facingright || direction > 0 && facingright){
					other.gameObject.GetComponent<Player>().muhblood.Play (true);
					GameObject victorysign = GameObject.Find("Text");
					int number = other.gameObject.GetComponent<Player>().PlayerNumber;
					if (number == 1)
						victorysign.GetComponent<GameMaster>().Winner = "Player 2";
					if (number == 2)
						victorysign.GetComponent<GameMaster>().Winner = "Player 1";
					rigidbody2D.velocity = new Vector2 (0,0);
					transform.parent = other.gameObject.transform;
				}
			}
			if (item != "Shield"){
				GameObject victorysign = GameObject.Find("Text");
				other.gameObject.GetComponent<Player>().muhblood.Play (true);

				int number = other.gameObject.GetComponent<Player>().PlayerNumber;
				if (number == 1)
					victorysign.GetComponent<GameMaster>().Winner = "Player 2";
				if (number == 2)
					victorysign.GetComponent<GameMaster>().Winner = "Player 1";
				rigidbody2D.velocity = new Vector2 (0,0);
				transform.parent = other.gameObject.transform;
			}
		}
	}
	void LateUpdate () {
		direction = GetComponent<Rigidbody2D>().velocity.x;
		if (direction > 0 && !goingright){
			goingright = true;
			Flip ();}
		if (direction < 0 && goingright){
			goingright = false;
			Flip();
		}
	}
	void Flip ()
	{
;
		Vector3 muhscale = transform.localScale;
		muhscale.x *= -1;
		transform.localScale = muhscale;
	}
}