using UnityEngine;
using System.Collections;

public class PowerUP : MonoBehaviour {

	public Sprite[] powerUps;
//	private CameraScript camera;
	private int powertype;
	private Paddle paddle;
	private BoxCollider2D paddleCollider;
	private Sprite paddleSprite;
	private Ball ball;

	
	
	// Use this for initialization
	void Start () {
		
		paddle = GameObject.FindObjectOfType<Paddle>();
		powertype = Random.Range(0, 6);
		rigidbody2D.velocity = new Vector2(0f, -5f);
		this.GetComponent<SpriteRenderer>().sprite = powerUps[powertype];
//		camera = GameObject.FindObjectOfType<CameraScript>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
	
		
	
		if (collider.gameObject.name == "Paddle" || collider.gameObject.name == "Paddle(Clone)"){
			Debug.Log ("am cules powerupu");
			
			if (powertype == 1){ // make paddle bigger
				paddle = GameObject.FindObjectOfType<Paddle>();
				float paddleScale;
				paddleScale = Mathf.Clamp(paddle.transform.localScale.x, 0.5f, 2f);			
				paddle.transform.localScale = new Vector3(paddleScale * 1.5f, 1f, 1f);
			}
			if (powertype == 0){ //make paddle smaller
				paddle = GameObject.FindObjectOfType<Paddle>();
				float paddleScale;
				paddleScale = Mathf.Clamp(paddle.transform.localScale.x, 0.5f, 2f);
				paddle.transform.localScale = new Vector3(paddleScale / 1.5f, 1f, 1f);
			}
			if (powertype == 2){ //extra life
				paddle = GameObject.FindObjectOfType<Paddle>();
				LoseCollider.lives ++;
			}
			if (powertype == 3){ //minus life
				paddle = GameObject.FindObjectOfType<Paddle>();
				LoseCollider.lives -= 1;

			}
			if (powertype == 4){ // floating paddle
				paddle = GameObject.FindObjectOfType<Paddle>(); 
				paddle.floating = true;
			}
			if (powertype == 5){ // wacky camera
				
				paddle = GameObject.FindObjectOfType<Paddle>(); 
//				camera = GameObject.FindObjectOfType<CameraScript>();
				CameraScript.camFlipped = true;
			}
			GameObject.Destroy(gameObject);
		
	
	
		}
	}
}
