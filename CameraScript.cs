using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	static public bool camFlipped = false;
	private float rand;
	private float timepUP = 1;
	
	public float width = 4f;
	public float height = 3f;
	
	void Awake ()
	{
		Camera.main.aspect = width / height;
	}

	void Start () {

		rand = Random.Range (155, 195);
	}
	
	
	void Update () {
		if (camFlipped == true){
//			timepUP = 1;
			transform.rotation = Quaternion.Euler(0f, 0f, rand);
			timepUP += Time.deltaTime;
//			Debug.Log (timepUP);
			
			if (timepUP >= 3){
				timepUP = 1;
				camFlipped = false;
			}
		}
		
		else{
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			rand = Random.Range (150, 200);

		}

			

		
	}
}

