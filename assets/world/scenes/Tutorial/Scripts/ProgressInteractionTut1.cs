using UnityEngine;
using System.Collections;

public class ProgressInteractionTut1 : MonoBehaviour {

	// Use this for initialization
	public WorldButtonInteraction chestScript;
	public FadeInAndOut fadeScript;
	public playerController player;
	public PlayerInventory inven;
	
	private float timer = 0f;
	private bool temp = true;

	void Start () {
		chestScript = GameObject.Find ("Chest").GetComponent<WorldButtonInteraction>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		inven = GameObject.Find ("Inventory").GetComponent<PlayerInventory>();
		player = GameObject.Find ("Player").GetComponent<playerController>();
		if (Progression.previousScene == "Home2") {
			player.cc.transform.position = new Vector3(-5.3f, 2f, -1f);
		}
		if(Progression.previousScene == "makePlayer"){
			player.cc.transform.position = new Vector3(1.744855f, 30f, -1f);
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}

	void OnGUI(){
		GUI.skin.button.fontSize = (int)(Screen.height / chestScript.fontSize);
		GUI.skin.box.fontSize = (int)(Screen.height / chestScript.fontSize);

		switch(Progression.progress){
			case 0://toggle quest bar
			QuestBar.barHeight = Screen.height / 11f;
				player.allowedToMove = false;
				if(QuestBar.toggled == false){
					player.allowedToMove = true;
					Progression.progress++;		
				}
				break;
			case 1://take sword from chest
				QuestBar.task = "Walk over to the chest by using W,A,S,D. Open the chest by clicking 'Open Chest'.";
				if (chestScript.clicked == true){
					if(GUI.Button (new Rect (Screen.width/2f - (chestScript.messageLength*2.2f)/2f,
					  	Screen.height/2.8f - 25, chestScript.messageLength*2.2f, chestScript.messageHeight), "Take The Blade of Absurdity")){
						chestScript.clicked = false;
						Progression.progress++;
					}
				}
				break;
			case 2:// fade
				if(temp){
					QuestBar.toggled = false;
					fadeScript.fade = true;
					fadeScript.fadingIn = true;
					fadeScript.bothFades = true;
					temp = false;
				}
				GUI.Box (new Rect (0,0,Screen.width, Screen.height/18f),
				         "As you grab hold of the sword, the floor beneath loosens and you fall through.");
				if(fadeScript.fadingIn == false){
					if(timer <= 10f){
						player.cc.transform.position = new Vector3(0f, 0f, -1f);
						fadeScript.fadingOut = true;
						fadeScript.bothFades = false;
					}
					if(timer <= 0f){
						timer = 600f;
					}
					timer--;
				}
				if(fadeScript.fade == false){
					QuestBar.toggled = true;
					Progression.progress++;
					temp = true;
					timer = 0f;
				}
				break;
			case 3://go to equipments tab
				QuestBar.task = "Now you need to equip your Blade of Absurdity. Open the Inventory by pressing 'M' and click on the 'Equipment' tab. ";
				if(inven.in_toolbar == 2){
					Progression.progress++;
				}
				break;
			case 4://equip sword
				QuestBar.task = "Now under 'Weapon', click 'Unequip' and select the 'Blade of Absurdity' to equip it.";
				if(inven.getA_equipBoolean()[0] == true){
					Progression.progress++;
				}
				break;
			case 5://waiting for combat to finish
				QuestBar.task = "In a flurry of delirious subconsciousness, a deft horde of blood-thirsty spiderlings engulf you! " + Progression.killCount + "/10 slain.";
				if(Progression.killCount == 10)
				{
					Progression.killCount = 0;
					Progression.progress++;
				}
				break;
			case 6: 
				QuestBar.task = "It's not until the last spiderlings death that you realize the basement is quickly flooding with water. Go upstairs!";
				Progression.progress = 7;
				break;
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
