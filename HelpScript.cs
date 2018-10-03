using UnityEngine;
using System.Collections;

public class HelpScript : MonoBehaviour {

	public Sprite[] sprites;
	private int spriteIndex;
	private float time;
	private bool releaseText;

	// Use this for initialization
	void Start () {
//		time += Time.deltaTime
		
		InvokeRepeating("LoadSprites", 0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)){
			releaseText = true;
		}
	}	
	void LoadSprites(){	
		
		this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
		spriteIndex += 1;
		
		if (releaseText == true){
			spriteIndex = 5;
			releaseText = false;
		}
		
		if (spriteIndex == 9){
			spriteIndex = 5;
		}
		

		if (spriteIndex == 4){
			spriteIndex = 0;
		}
		
		
		
		
		
	}	
}
