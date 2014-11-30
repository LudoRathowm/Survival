using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] PrefabsToRandomlySpawn;
	public int Size;
	int chosenitem;
	void Start () {
		chosenitem = Random.Range(0,Size);
		Spawn();

	}
	void Spawn (){
		Instantiate(PrefabsToRandomlySpawn[chosenitem],transform.position,Quaternion.identity);

	}

}
