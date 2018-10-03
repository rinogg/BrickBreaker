using UnityEngine;
using System.Collections;

public class SpecialBrick : MonoBehaviour {
	
	public AudioClip unbreakableSound;
	public AudioClip shutSound;
	public Sprite[] hitSprites;
	public Color brickColour;
	public CollisionDetectionMode collisionDetectionMode;
	public float XSpeed;
	public float YSpeed;
	public float trapTime;
	
	private bool trapClosed;
	private int spriteIndex;

	
	
	
	// Use this for initialization
	void Start () {
		

		trapClosed = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		trapTime += Time.deltaTime;
		
		if (!trapClosed & trapTime >= 2.5f){
			CloseTrap();
			trapTime = 1;

		}
		if (trapClosed & trapTime >= 2.5f){
			OpenTrap();		
			trapTime = 1;

		}
		
		
	}
	

	
	void CloseTrap(){

		rigidbody2D.velocity = new Vector2(XSpeed, YSpeed);

		AudioSource.PlayClipAtPoint(shutSound, transform.position, 100f);
		trapClosed = true;	
	}			
	
	void OpenTrap(){
	
		rigidbody2D.velocity = new Vector2(-XSpeed, YSpeed);

//		AudioSource.PlayClipAtPoint(shutSound, transform.position, 100f);
		trapClosed = false;
	}
	
	void OnCollisionExit2D(Collision2D collision){
	
		AudioSource.PlayClipAtPoint(unbreakableSound, transform.position, 0.1f);	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		rigidbody2D.velocity = new Vector2(0f, 0f);
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);

		
	}
	
	

}
