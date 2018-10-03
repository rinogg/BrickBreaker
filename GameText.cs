using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameText : MonoBehaviour {

	public Text livesText;
//	private LoseCollider loseCollider;
	
	// Use this for initialization
	void Start () {
		livesText.text = "x " + LoseCollider.lives;
//		loseCollider = GameObject.FindObjectOfType<LoseCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		livesText.text = "x " + LoseCollider.lives;
	}
}
