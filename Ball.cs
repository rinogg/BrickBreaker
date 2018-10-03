using UnityEngine;
using System.Collections;


public class Ball : MonoBehaviour {
	
	public bool hasStarted;
	public CollisionDetectionMode collisionDetectionMode;
	public float boringLoopTime;
	public HelpScript HelpText;
	private Rigidbody2D rb;
	private Paddle paddle;
	private static Vector3 paddleToBall;

	
	

	void Start () {
		boringLoopTime = Time.deltaTime;
		float x = Mathf.Clamp(this.rigidbody2D.velocity.x, -8f, 8f);
		float y = Mathf.Clamp(this.rigidbody2D.velocity.y, -8f, 8f);
		this.rigidbody2D.velocity = new Vector2 (x, y);
		rb = GetComponent<Rigidbody2D>(); // this is for adding force to the ball when it is too slow v see below v
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBall = this.transform.position - paddle.transform.position;

	}
	

	void Update () {
//		Debug.Log (this.rigidbody2D.velocity);
		boringLoopTime += Time.deltaTime;
//		Debug.Log(boringLoopTime);
		if (!hasStarted){
			//Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBall;
			
			if (Input.GetMouseButtonUp(0)){
				//release the ball on input
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (-2f, 8f);
				try {
				
					Destroy(HelpText);
					Destroy(HelpText.GetComponent<SpriteRenderer>());	
				}
				catch  {
					Debug.Log("Already Destroyed");
				}
			}			
		}
		
		else if (this.rigidbody2D.velocity.x >= -6.5f &
		      this.rigidbody2D.velocity.x <= 6.5f & 
		      this.rigidbody2D.velocity.y >= -6.5f & 
		      this.rigidbody2D.velocity.y <= 6.5f)
		{
			rb.AddForce(this.rigidbody2D.velocity * 8); // this is for adding force to the ball when it is too slow
			Debug.Log ("ball slow, BOOSTED");
		}			

		 if (this.rigidbody2D.velocity.x < -8.5f & // DEBUG ONLY
	         this.rigidbody2D.velocity.x > 8.5f & 
	         this.rigidbody2D.velocity.y < -8.5f & 
	         this.rigidbody2D.velocity.y > 8.5f)
	         {Debug.Log("SPEED EXCEEDED");}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		
		// limit the speed of the ball by clamping 2 floats. limited so that it doesn't go through colliders. ideal speed seems to be 10f.
		
		float x = Mathf.Clamp(this.rigidbody2D.velocity.x, -8f, 8f);
		float y = Mathf.Clamp(this.rigidbody2D.velocity.y, -8f, 8f);
		this.rigidbody2D.velocity = new Vector2 (x, y);
		
		if (boringLoopTime >= 7){	
			Vector2 tweak = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)); // applying a random tweak to each bounce so that it doesn't get stuck in a bouncing loop.
			this.rigidbody2D.velocity += tweak;
			boringLoopTime = 1;
			Debug.Log ("BORING");
		}
		else {
			Vector2 tweak = new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f)); // applying a random tweak to each bounce so that it doesn't get stuck in a bouncing loop.
			this.rigidbody2D.velocity += tweak;
		}
	}
	
	public void Death(){
		Destroy(gameObject);
		
	}
}


















