using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static int reps;
	// Use this for initialization
	void Awake(){ //Awake nu ruleaza scriptu, doar incepe sa-l citeasca
				  // In cazu asta se distruge inainte sa-si dea Start
				  // Si ramane doar primu care si-a dat start
		
		reps ++;
		if (reps == 1){
			GameObject.DontDestroyOnLoad(gameObject);
																//gameObject cu g mic e objectu atasat scriptului (vezi bottom script)
		}														//asta (de ex Music Player din stanga sus aici)
		else {					
			GameObject.Destroy(gameObject);
			Debug.Log ("Destroying previous instance of Music Player" + GetInstanceID());	
		}
	}
	
	void Start () {
		
		Debug.Log ("Music Player in Start is " + GetInstanceID());
												       
		Debug.Log("reps are " + reps);
		Debug.Log(this);
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}

// Ben's UDEMY solution:
//
//	static MusicPlayer instance = null;
//	
//	void Start(){
//		if (instance != null){
//			Destroy(gameObject);
//			print ("Duplicate music player self-destructing");
//		}	
//		else {
//			instance = this;
//			GameObject.DontDestroyOnLoad(gameObject);
//		}
//		
//	} ExecutionOrder





//A GameObject has Components (like Transform, possibly a Camera, maybe a MonoBehaviour you write yourself).
//	Each MonoBehaviour is a component.
//		
//		If you're coding a MonoBehaviour:
//"this" means that MonoBehaviour. More accurately, that specific instance of it.
//".gameObject" is a reference to the GameObject that contains it.
//
//"this" (MonoBehaviour) and ".gameObject" (GameObject) will have many instance methods in common just for convenience, so you may not notice a difference.
//But some things are different. For example, only the GameObject has the .AddComponent and .SetActive methods.
