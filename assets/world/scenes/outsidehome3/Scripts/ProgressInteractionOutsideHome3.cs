using UnityEngine;
using System.Collections;

public class ProgressInteractionOutsideHome3 : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	private bool temp = true;
	private bool clicked = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		if (Progression.previousScene == "Home2") {
			player.cc.transform.position = new Vector3(-3f, -8.5f, -1f);
		}
		if (Progression.previousScene == "Cave4") {
			player.cc.transform.position = new Vector3(42f, -77f, -1f);
		}
		if (Progression.previousScene == "House5") {
			player.cc.transform.position = new Vector3(33.7f, -4f, -1f);
		}
		if (Progression.previousScene == "Town") {
			player.cc.transform.position = new Vector3(56f, 6f, -1f);
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	
	// Update is called once per frame
	void OnGUI () {
		switch(Progression.progress){
			case 8:
				QuestBar.barHeight = Screen.height/6f;
				QuestBar.task = "From your home on the hill, you gaze out at the dawn-lit ocean that was once your beloved town.\n The moon catches your eye. It's been split asunder. In an Earth-shattering splash, a hurling chunk of flaming moonstone\n strikes you from the sky. You awake from the frigthening dream glad it was only a nightmare.";
				if (GUI.Button (new Rect (Screen.width/2f - (9 *(Screen.width / 100f)/2f), Screen.height/2.8f - (8 *(Screen.height / 100f)/2f),
			                          9 *(Screen.width / 100f), 8 *(Screen.height / 100f)), "Next")){
			        clicked = true;			
				}
				if(clicked)
				{
					if(temp){
						fadeScript.fade = true;
						fadeScript.fadingIn = true;
						fadeScript.bothFades = true;
						temp = false;
					}
					if(fadeScript.fadingIn == false){
						clicked = false;
						Progression.progress++;
						Application.LoadLevel ("Home2");
					}
				}
				break;
		}
	}
}
