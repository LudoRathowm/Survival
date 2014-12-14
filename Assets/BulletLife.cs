using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BulletLife : MonoBehaviour {


		Text text;
		int playerturn;
		float lifeleft;
	float life = 10;
		// Use this for initialization
		void Start () {
			text = GetComponent<Text>();
		lifeleft = life;
		}
		
		// Update is called once per frame
		void Update () {
		GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
		if (bullet){
			lifeleft -=Time.deltaTime;
			
			text.text = ("Bomb Lifetime: " + lifeleft +" seconds");}
		else if (!bullet){
			lifeleft = life;

			text.text = ("Bomb Lifetime: None Active");}
		}
	}
