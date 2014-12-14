using UnityEngine;
using System.Collections;

public class GravitationProcGen : MonoBehaviour {
public	Rigidbody2D Planet;
	public AudioClip[] musics;


	Vector3 position;

	int minX = -1000;
	int maxX = 1000;
	int minY = -1000;
	int maxY = 1000;
	int minnumberofplanets = 15;
	int maxnumberofplanets = 55;
	int numberofplanets;
	int counter = 0;
	// Use this for initialization
	void Start () {
		numberofplanets = Random.Range(minnumberofplanets,maxnumberofplanets);
		for (int i = 0; i < numberofplanets; i++)
			InstantiatePlanet();
		int randommusic = Random.Range (0,5);
		AudioSource.PlayClipAtPoint(musics[randommusic], transform.position);

		}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InstantiatePlanet(){
		float positionX = Random.Range(minX,maxX);
		float positionY = Random.Range(minY,maxY);
	
		position = new Vector3 (positionX,positionY,0);
		Rigidbody2D planet = Instantiate(Planet,position,transform.rotation) as Rigidbody2D;
	}

}
