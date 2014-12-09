using UnityEngine;
using System.Collections;

public class GenericPickUpScript : MonoBehaviour {
		int playernumber;
	public AudioClip clip;
	public GameObject[] ListOfItems;
		bool pickup;
	string CurrentItem; //so you can drop it like it's hot
	public string ItemName;
		void OnTriggerStay2D(Collider2D other) {
			if (other.gameObject.CompareTag("Player") && other.gameObject.name != "ShieldItem") {
				playernumber = other.gameObject.GetComponent<Player>().PlayerNumber;
			if (playernumber == 2){

				GameObject Player2 = GameObject.Find ("Player 2");
				CurrentItem = Player2.GetComponent<Player>().Item;
			}
			
			if (playernumber == 1){

				GameObject Player1 = GameObject.Find ("Player 1");
				CurrentItem = Player1.GetComponent<Player>().Item;
			}
			if (Input.GetButtonDown("Item2") && playernumber == 2){
				GameObject Player2 = GameObject.Find ("Player 2");
				AudioSource.PlayClipAtPoint(clip, transform.position);
				Player2.GetComponent<Player>().Item = ItemName;
				Destroy (this.gameObject,0);
			}
			
			if (Input.GetButtonDown("Item1") && playernumber == 1){
				AudioSource.PlayClipAtPoint(clip, transform.position);
				GameObject Player1 = GameObject.Find ("Player 1");
				CurrentItem = Player1.GetComponent<Player>().Item;
				Player1.GetComponent<Player>().Item = ItemName;
				Destroy (this.gameObject,0);
			}
			if (CurrentItem == "Spring" && Input.GetButtonDown("Item1") && playernumber == 1 )
				Instantiate(ListOfItems[0],transform.position,Quaternion.identity);
			if (CurrentItem == "Umbrella" && Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[1],transform.position,Quaternion.identity);
			if (CurrentItem == "Gun"&& Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[2],transform.position,Quaternion.identity);
			if (CurrentItem == "Food"&& Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[3],transform.position,Quaternion.identity);			
			if (CurrentItem == "Drink"&& Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[4],transform.position,Quaternion.identity);
			if (CurrentItem == "Shield"&& Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[5],transform.position,Quaternion.identity);
			if (CurrentItem == "Knife"&& Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[6],transform.position,Quaternion.identity);
			if (CurrentItem == "Gravity"&& Input.GetButtonDown("Item1") && playernumber == 1)
				Instantiate(ListOfItems[7],transform.position,Quaternion.identity);
			if (CurrentItem == "Spring" && Input.GetButtonDown("Item2") && playernumber == 2 )
				Instantiate(ListOfItems[0],transform.position,Quaternion.identity);
			if (CurrentItem == "Umbrella" && Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[1],transform.position,Quaternion.identity);
			if (CurrentItem == "Gun"&& Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[2],transform.position,Quaternion.identity);
			if (CurrentItem == "Food"&& Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[3],transform.position,Quaternion.identity);
			if (CurrentItem == "Drink"&& Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[4],transform.position,Quaternion.identity);
			if (CurrentItem == "Shield"&& Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[5],transform.position,Quaternion.identity);
			if (CurrentItem == "Knife"&& Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[6],transform.position,Quaternion.identity);
			if (CurrentItem == "Gravity"&& Input.GetButtonDown("Item2") && playernumber == 2)
				Instantiate(ListOfItems[7],transform.position,Quaternion.identity);

		}
	}}
