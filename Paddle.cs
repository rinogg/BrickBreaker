using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	public bool autoPlay = false;
	public bool floating = false;
	static public bool pausedPaddle = false;
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		floating = false;

	}
	
	// Update is called once per frame
	void Update (){ 

		if (autoPlay == false & pausedPaddle == false){
			MoveWithMouse();
//			MoveWithPhone();
		}
		else{
//			AutomatedPaddle();
//			Debug.Log ("game should be paused");
		}
	}
		
		
	
															
	
	
	void OnCollisionEnter2D(Collision2D collision){
	
		if (ball.hasStarted){	
			audio.Play();		
			HandleAngle(collision);
			
		}

	}
	
	void HandleAngle(Collision2D collision){
	
		ContactPoint2D paddleHit = collision.contacts[0];
		Vector2 hitPoint = paddleHit.point;
		float angleDifference = 5.5f * (hitPoint.x - this.transform.position.x);
//		print ("angleDifference is " +angleDifference);
//		print ("hitPoint.x is " +hitPoint.x);
//		print ("paddle.x is " +this.transform.position.x);
		ball.transform.rigidbody2D.velocity = new Vector2(angleDifference, 10f);
		
		if (hitPoint.y < 1.01f){
			ball.transform.rigidbody2D.velocity = new Vector2(angleDifference, -10f);
		}
	}
	
	
	void MoveWithMouse(){
	
		
		if (floating){
			Vector3 paddlePos = new Vector3(8f, this.transform.position.y + 2f, -2f);
			
			float mousePosInBlocks;
			float mousePosInBlocksVert;
			
			mousePosInBlocksVert = (Input.mousePosition.y / Screen.height * 12 + 2);
			mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
			paddlePos.y = Mathf.Clamp(mousePosInBlocksVert, 1f, 11f);
			paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
			this.transform.position = paddlePos;
		}
		
		else{
			Vector3 paddlePos = new Vector3(8f, this.transform.position.y, -2f); // values are X Y Z (Z fucks up with the camera if not set right) you need to put f next to the numbers
			// in order to make them float, otherwise it will default to double type
			// we could put 0.8f for the Y valuea but instead
			// we put this.transform.position (this gets the Y value form the transformer)
			// so that everytime we change the Transform inspector it changes the script too.
			float mousePosInBlocks;
			mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16); //asta se updateaza mereu //intai luam 0-800 width
			paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);		// ca sa nu iasa din ecran    // apoi impartim la acel width (800) ca sa aveam intre 0 si 1
			this.transform.position = paddlePos; 		
			// apoi inmultim cu 16 (cate game units avem noi pe ecran)
			
			//ATENTIE: Mathf.Clamp nu schimba obiectu cu nimic, el e doar o functie matematica care returneaza un rezultat.
			//Reuzltatul ala pe urma trebuie folosit sa reprezinte X (sau ce valoare vrei tu)
		}
	}
	
	void MoveWithPhone(){
		Vector3 paddlePos = new Vector3(8f, this.transform.position.y, -2f);
		
//		float x;
//		float amplifiedAcc;						// THIS SOLUTION USES TRANSFORM DIRECTLY
												// NOT PREFFERED BECAUSE OF SHAKYness
//		float result;
//		amplifiedAcc = Input.acceleration.x * 2;
//		x = Mathf.Clamp (amplifiedAcc, -1f, 1f);
//		result = x + 1;
//		this.transform.position = new Vector3(result * 8, this.transform.position.y, -2f);
		paddlePos.x = Mathf.Clamp (transform.position.x, 1f, 15f);
		transform.position = paddlePos; 
		float speed;
		float clampedSpeed;
		speed = Input.acceleration.x * 250; // incearca sa-l maresti 
		clampedSpeed = Mathf.Clamp (speed, -30f, 30f);
		this.rigidbody2D.velocity = new Vector2(clampedSpeed, 0f);
		
	}
	
	void MoveRight(){
		this.rigidbody2D.velocity = new Vector2(15f, 0f);
	}
	void MoveLeft(){
		this.rigidbody2D.velocity = new Vector2(-15f, 0f);
	}
	
	void AutomatedPaddle(){
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, -2f);
		paddlePos.x = Mathf.Clamp(paddlePos.x, 1f, 15f);
		Vector3 randomizer = new Vector3 (Random.Range(-0.5f,0.5f), 0f, -2f); //wobbly paddle
		this.transform.position = paddlePos + randomizer;
		
	}
	public void Death(){
		Destroy(gameObject);
		
	}		
}
