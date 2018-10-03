using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
//	private int loadedLevel = 1;
	

	
	public void LoadLevel(string name){
	// only loads the LOSE scene, Win scene is loaded by the LoadNextLevel()
		LoseCollider.lives = 3;
		Brick.breakableCount = 0;
		Debug.Log("Level load requested for: "+name);
		Application.LoadLevel(name);
		
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Screen.showCursor = true;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest(){
		Application.Quit();
		Debug.Log("Quit Requested");
	}
	
	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0){
			LoadNextLevel();
		}; 								//if method or var is STATIC 
										//we can access the Brick class with just capital letter
										//of the class name as such Class.var
		
	
	}
}
