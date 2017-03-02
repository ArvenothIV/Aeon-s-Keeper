using UnityEngine;
using System.Collections;

public class Staff : MonoBehaviour {
	//import player level
	public GameObject inventory;
	private PlayerInventory playerInventory;
	public int playerlevel;
	//import player luck
	public int luck;
	public int str;
	public int intel;
	public int agil;
	public int luc;
	public string itemName;
	private string[] list1 = new string[]{"Protective ", "Polite ", "Undesirable ", "Useful ", "Rich ", "Honorable ", 
		"Magical ", "Nondescript ", "Hot ", "Acidic ", "Hilarious ", "Deafening ", "Inexpensive ", "Aquatic ", 
		"Future ", "Overwrought ", "Whimsical ", "Dashing " };
	private string[] list2 ={"Dominion", "Gold", "Silver", "Heart", "Creed","Master","Ballad", "Fate", "Keeper", "Sentry","Guard",
		"Protector", "Salve", "Splinter", "Saint", "Stand", "Fall", "Breath"};
	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventory = inventory.GetComponent<PlayerInventory>();
		playerlevel = playerInventory.currentLV;
		luck = playerInventory.currentLUC;

		System.Random rnd = new System.Random();
		int goodluck = rnd.Next(1,50);
		if(goodluck*(playerlevel + luck)/2 >= 33){
			//set quality to uncommon
			str = rnd.Next(1,playerlevel/2 + 2);
			intel = rnd.Next(1,playerlevel);
			agil = rnd.Next(1,playerlevel/2 + 2);
			luck = rnd.Next(0,2);
			
		}
		else if(goodluck*(playerlevel + luck)/2 >= 67){
			//set quality to rare
			str = rnd.Next(5,playerlevel +6);
			intel = rnd.Next(10,playerlevel/2 +10);
			agil = rnd.Next(5,playerlevel/2 + 6);
			luck = rnd.Next(0,2);
		}
		else if(goodluck*(playerlevel + luck)/2 >= 100){
			//set quality to legendary
			str = rnd.Next(20,playerlevel + 21);
			intel = rnd.Next(40,playerlevel/2 + 40);
			agil = rnd.Next(20,playerlevel/2 + 21);
			luck = rnd.Next(0,10);
		}
		else{
			str = rnd.Next (1, 2);
			intel = rnd.Next (1,2);
			agil = rnd.Next (1,2);
			luck = 0;
		}

		//for debugging
		itemName = list1[rnd.Next (0,17)] + list2[rnd.Next (0,17)];
		Debug.Log(itemName);
		//for debugging
		Debug.Log(str);
		Debug.Log(intel);
		Debug.Log(agil);
		Debug.Log(luck);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
