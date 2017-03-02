using UnityEngine;
using System.Collections;
//Woman dialogue for alternate route to town in outsideHome3
public class Dialogue2 : MonoBehaviour {
	
	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("Woman").GetComponent<WorldButtonInteraction>();
		stage = 0;
		
		messageLength *= (Screen.width/100f);
		messageHeight *= (Screen.height/100f);
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin.button.fontSize = (int)(Screen.height / fontSize);
		GUI.skin.box.fontSize = (int)(Screen.height / fontSize);
		
		if(npcScript.clicked == true && stage == 0) {
			stage = 1;
		}
		
		if(npcScript.isTriggered == true){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 2;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Hello there neighbor. I assume you'd like to cross to get to town.");
				break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 3;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "I had this gate put in place once that mercenary started blocking the road.");
				break;
			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 4;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "So many people heard about an easier way around and started pestering me and ruining my crops. I had no choice. The gate had to be built.");
				break;
			case 4:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 5;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Since we're neighbors, I'd happyily let you pass. The problem is that hidding the keys in the chicken feed wasn't the best idea.");
				break;
			case 5:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 6;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Sadly, some of my chickens were eaten by the goblins just south of here. And who knows what eats the goblins!");
				break;
			case 6:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength, messageHeight), "Yes")) {
					stage = 7;
				}
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "No")) {
					stage = 8;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Will you help me get the keys back? There are three of them in total.");
				break;
			case 7:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 10;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Oh thank you! I knew you'd help. Bring the keys to me once you've found all three of them.");
				break;
			case 8:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 10;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "I don't know how either of us will get into town now. Come back if you change your mind though.");
				break;
			}
		}
		else stage = 0;	
	}
}