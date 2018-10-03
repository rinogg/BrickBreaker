using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
	
	
	public Transform canvas;
	private bool paused;
	
	
	// Use this for initialization
	void Start () {
		paused = false;
		canvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)){
			
			if (paused == false){
				canvas.gameObject.SetActive(true);	
				paused = true;
				Debug.Log ("GAME PAUSED");
				Paddle.pausedPaddle = true;
				Time.timeScale = 0;
				
			}
//			else {
//				paused = false;
//				canvas.gameObject.SetActive(false);	
//				Paddle.pausedPaddle = false;
//				Debug.Log("UNPAUSED");
//				Time.timeScale = 1;
//			}
		}
	}
	public void ResumeGame(){
		paused = false;
		canvas.gameObject.SetActive(false);	
		Debug.Log("UNPAUSED");
		Time.timeScale = 1;
		Paddle.pausedPaddle = false;
	}
	
	
	
}




