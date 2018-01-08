using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinRudolph : MonoBehaviour {


	private AudioSource sound;

	// Use this for initialization
	void Start () {

		sound = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	//trigger doesn't bounce off
	{
		if (other.gameObject.CompareTag ("Player")) {

			AudioSource.PlayClipAtPoint (sound.clip, transform.position);
			rudolphScoreManager.score++;

			Destroy (gameObject);
		}

	}// end onTrigger


}
