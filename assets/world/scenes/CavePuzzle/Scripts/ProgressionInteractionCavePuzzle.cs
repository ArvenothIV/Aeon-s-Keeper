using UnityEngine;
using System.Collections;

public class ProgressionInteractionCavePuzzle : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		if (Progression.previousScene == "Outsidehome3") {
			player.cc.transform.position = new Vector3(0f, 0f, -1f);
		}
		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
