using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	

	
	static public int lives = 3;
	public AudioClip deathSound;
	public GameObject newPaddle;
	public GameObject newBall;
	
	private Paddle paddle;
	private Ball ball;
	private LevelManager levelManager;
	
	
	void Start(){
//		Screen.showCursor = false;
		ball = GameObject.FindObjectOfType<Ball>();
		paddle = GameObject.FindObjectOfType<Paddle>();
	}
	void Update(){
		if (lives <= 0){
			Brick.breakableCount = 0;
			Screen.showCursor = true;
			lives = 3;
			levelManager.LoadLevel("Lose");
		}
	}
	
	void OnTriggerEnter2D(Collider2D trigger){
		
//		Debug.Log (trigger);
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		ball = GameObject.FindObjectOfType<Ball>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.340f);
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		Restart();
		ball.Death();
		paddle.Death();
//		Debug.Log (ball);
		lives --;
		Debug.Log ("Lives: " + lives);
		
		
	
		
		if (lives <= 0){
			Brick.breakableCount = 0;
			Screen.showCursor = true;
			lives = 3;
			levelManager.LoadLevel("Lose");
			
		}
	}
	
	public void Restart(){
		Vector3 spawnAt = new Vector3(8f, 2.8f, -2f); // 0.8 pc, 2.8 phone (bricks -2 for pc +2 for phone)
		Instantiate(newPaddle, spawnAt, Quaternion.identity);
		newPaddle.name = "Paddle";
//		Debug.Log (paddle.transform.position.x);
		Vector3 spawnAt2= new Vector3(7.61f, 3.34f, -2f); // 1.34 pc, 3.34 phone (bricks -2 for pc +2 for phone)
		Instantiate(newBall, spawnAt2, Quaternion.identity); 
		newBall.name = "0 Gravity Ball";
		
		
	}
	
}
