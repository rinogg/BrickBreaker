using UnityEngine;
using System.Collections;

public class ColliderSounds : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D collision){
		audio.Play();
	}	
}
