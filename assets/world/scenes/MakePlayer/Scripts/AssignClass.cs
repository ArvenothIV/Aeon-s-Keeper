using UnityEngine;
using System.Collections;

public class AssignClass : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	public string levelToLoad;
	
	public Sprite c1Sprite;
	public RuntimeAnimatorController c1Controller;
	public Sprite c2Sprite;
	public RuntimeAnimatorController c2Controller;
	public Sprite c3Sprite;
	public RuntimeAnimatorController c3Controller;
	public Sprite c4Sprite;
	public RuntimeAnimatorController c4Controller;
	
	void Start () {
		player = GameObject.Find("Player");
		switch(Progression.playerClass){
			case 1:
				player.GetComponent<SpriteRenderer>().sprite = c1Sprite;
				player.GetComponent<Animator>().runtimeAnimatorController = c1Controller;
				break;
			case 2:
				player.GetComponent<SpriteRenderer>().sprite = c2Sprite;
				player.GetComponent<Animator>().runtimeAnimatorController = c2Controller;
				break;
			case 3:
				player.GetComponent<SpriteRenderer>().sprite = c3Sprite;
				player.GetComponent<Animator>().runtimeAnimatorController = c3Controller;
				break;
			case 4:
				player.GetComponent<SpriteRenderer>().sprite = c4Sprite;
				player.GetComponent<Animator>().runtimeAnimatorController = c4Controller;
				break;
		}
		
		Progression.previousScene = Application.loadedLevelName;
		Application.LoadLevel(levelToLoad);
	}
}
