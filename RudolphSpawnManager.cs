using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudolphSpawnManager : MonoBehaviour {

	public int maxPlatforms = 20;
	public GameObject platform; // hold Ground
	public float horizontalMin = 7.5f; // the min distance from each other to right
	public float horizontalMax = 14f; // max distance from each other.  this is how far player can jump
	public float verticalMin = -6f; 
	public float verticalMax = 6;

	private Vector2 originPosition;

	// Use this for initialization
	void Start () {

		//hold the data of the orginPosition
		originPosition = transform.position;
		Spawn ();

	}


	void Spawn () {
		for (int i = 0; i < maxPlatforms; i++)
		{
			//create vector2 at random spot from orginPositoin within limits
			Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax));

			// create the platform
			Instantiate(platform, randomPosition, Quaternion.identity);
			// Quaterion is for rotation. this means no rotataion
			// reset orginPositon so the next platform spawns off it
			originPosition = randomPosition;
		}//end for
	}
}