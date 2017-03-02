using UnityEngine;
using System.Collections;
//Mercenary dialogue blocking the road in outsideHome3
public class Dialogue1 : MonoBehaviour {
	
	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("NPC_Mercenary").GetComponent<WorldButtonInteraction>();
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
					    Screen.height / 2.8f - messageHeight/2f, messageLength, messageHeight), "Yes")) {
						stage = 2;
					}
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
					    Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "No")) {
						stage = 3;
					}
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				         Screen.width, messageHeight),
				         "Pay 500 gold to cross.");
					break;
				case 2:
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
					   	Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
						stage = 4;
					}
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
					 		Screen.width, messageHeight),
				         	"You may cross.");
				    break;
				case 3:
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
						stage = 4;
					}
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				         Screen.width, messageHeight),
				         "You may not cross.");
					break;
			}
		}
		else stage = 0;	
	}
}
