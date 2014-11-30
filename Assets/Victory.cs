using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	public string Winner;
	public AudioClip clip;
	public AudioClip walao;
	float countdown = 3;
	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(walao, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		Winner = GetComponent<GameMaster>().Winner;
		if (Winner != ""){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			guiText.text = "The Winner is " + Winner;
			if (countdown > 0) 
				countdown -= Time.deltaTime;
			if (countdown < 0)
				countdown = 0;
			if (countdown == 0)
			Application.LoadLevel(Application.loadedLevelName);}

	}
}
