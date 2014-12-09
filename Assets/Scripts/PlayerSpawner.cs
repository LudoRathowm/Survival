using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public GameObject[] PlayerPrefabs;	
	public int Size;
	int chosenplayer;
	void Start () {
		chosenplayer = Random.Range(0,Size);
		Spawn();
		
	}
	void Spawn (){
		Instantiate(PlayerPrefabs[chosenplayer],transform.position,Quaternion.identity);
		PlayerPrefabs[chosenplayer] = null;
	}
	
}
