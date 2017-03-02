using UnityEngine;
using System.Collections;

public class playerGold : MonoBehaviour {
	public GameObject inventory;
	private PlayerInventory playerInventory;
	private GUIStyle currentStyle = null;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventory = inventory.GetComponent<PlayerInventory>();
	}
	void OnGUI(){
		currentStyle = new GUIStyle( GUI.skin.box );
		currentStyle.fontSize = 15;
		GUI.color = Color.yellow;
		GUI.Box(new Rect(10, Screen.height - 50, 250, 40), 
		        "Gold:" + playerInventory.currentGold);
	}

}
