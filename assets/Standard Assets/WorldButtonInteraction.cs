using UnityEngine;
using System.Collections;

public class WorldButtonInteraction : MonoBehaviour {

	public bool isTriggered = false;//has the player collided with the objects collider
	public bool clicked = false;//has the player clicked on the button to interact
	public int progressReq = 0;//needed progress to interact
	public int levelReq = 0;//need level to interact (not supported atm)
	public string message;//message in first button
	public float messageLength, messageHeight, fontSize;//dimensions of first button
	public string sceneToLoad = "none";//none if not a passage to another scene
	public FadeInAndOut fadeScript;
	private bool temp;

	// Use this for initialization
	void Start () {
		messageLength *= (Screen.width/100f);
		messageHeight *= (Screen.height/100f);
		
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		clicked = false;
		temp = true;
	}
	
	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.tag == "Player"){
			isTriggered = true;
		}
	}
	
	void OnTriggerExit (Collider collider){
		if (collider.gameObject.tag == "Player") {
			isTriggered = false;
			clicked = false;
		}
	}
	void OnGUI(){
		GUI.skin.box.fontSize = (int)(Screen.height/fontSize);
		GUI.skin.button.fontSize = (int)(Screen.height/fontSize);

		if (isTriggered && progressReq <= Progression.progress && !clicked) {
			if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				Screen.height / 2.8f - messageHeight/2f, messageLength, messageHeight), message)) {
				clicked = true;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(clicked == true && sceneToLoad != "none"){
			if(temp){
				fadeScript.fade = true;
				fadeScript.fadingIn = true;
				fadeScript.bothFades = true;
				temp = false;
			}
			if(fadeScript.fadingIn == false){
				Progression.previousScene = Application.loadedLevelName;
				Application.LoadLevel (sceneToLoad);
			}			
		}
	}
}
