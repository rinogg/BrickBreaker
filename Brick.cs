using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip destroySound;
	public AudioClip crackSound;
	public AudioClip unbreakableSound;
	public Sprite[] hitSprites;
	public static int breakableCount = 0; //this will count how many breakable bricks are there.
	public GameObject debris;
	public GameObject powerUpCube;
	public Color brickColour;
	public CollisionDetectionMode collisionDetectionMode;
	

	
	private bool isBreakable; 
	private int timesHit;
	private int spriteIndex;
	private LevelManager levelManager;
	
	
	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		brickColour = gameObject.GetComponent<SpriteRenderer>().color;
		
		if (isBreakable){
			
			breakableCount++;
//				
		}
//		Debug.Log ("Breakable bricks: " +breakableCount);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnCollisionExit2D(Collision2D collision){
		
		// win condition needs tag otherwise it will search for every Brick type 
		// inlcuding the unbreakable one
		
		if (isBreakable){
			HandleHits();
			
//			Debug.Log (breakableCount);
		}
		else{
			AudioSource.PlayClipAtPoint(unbreakableSound, transform.position, 0.1f);
		}
		
		
	}
	
	
	void HandleHits(){
		int maxHits;
		int chance;
		maxHits = hitSprites.Length + 1;
		timesHit ++;
		chance = Random.Range(0,9);
		
		
		if (timesHit >= maxHits) {
			AudioSource.PlayClipAtPoint(destroySound, transform.position, 0.1f);
			breakableCount--;
			levelManager.BrickDestroyed();
			if (chance == 4){
				PowerUpSpawn();
			}
			DebrisSpawn();
			
			Destroy(gameObject);
//			Debug.Log ("Brick destroyed! Left: "+breakableCount);
//			
		}
		else{
			AudioSource.PlayClipAtPoint(crackSound, transform.position, 0.02f);
			LoadSprites();
		}
	}
	
	
	void DebrisSpawn(){
		Vector3 spawnAt = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		GameObject debrisPuff = Instantiate(debris, spawnAt, Quaternion.identity) as GameObject; //"as GameObject" changes the Object type 																									
		debrisPuff.particleSystem.startColor = brickColour;    												   //that this return into GameObject type
		
	}
	
	void PowerUpSpawn(){
		Vector3 spawnAt = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z -1);
		Instantiate(powerUpCube, spawnAt, Quaternion.identity);
	}
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}	
	
	void LoadSprites(){
		spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
			Debug.LogError("Failed to load sprites for brick!");
		
		
	}
}
