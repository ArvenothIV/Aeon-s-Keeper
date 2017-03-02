using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	private GameObject inventory;  
	//private var playerInventory : PlayerInventory;      // Reference to the player's inventory.
	public PlayerInventory playerInventory;
	private GameObject clicky;
	public WorldButtonInteraction wasclick;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Setting up the references.
		//get the game object
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		//get script attached to game object
		playerInventory = inventory.GetComponent<PlayerInventory>();
		clicky = this.gameObject;
		wasclick = clicky.GetComponent<WorldButtonInteraction>();
		
		if (wasclick.clicked){
			if(this.gameObject.name == "Chest"){
				playerInventory.hasSword = true;
				playerInventory.itemlistSwordName = "Blade of Absurdity";   
				playerInventory.itemlistSwordStrength = playerInventory.baseWeaponATK + 1;
				playerInventory.itemlistSwordAgil = playerInventory.baseWeaponAGI +  1;
				playerInventory.itemlistSwordIntel = playerInventory.baseWeaponINT + 1;
				playerInventory.itemlistSwordLuck = playerInventory.baseWeaponLUC + 0;
			}
			else if(clicky.tag == "Sword"){
				
				playerInventory.getSword();
				Debug.Log(clicky.GetComponent<Sword>().itemName);
				playerInventory.itemlistSwordName = clicky.GetComponent<Sword>().itemName;   
				playerInventory.itemlistSwordStrength = playerInventory.baseWeaponATK + clicky.GetComponent<Sword>().str;
				playerInventory.itemlistSwordAgil = playerInventory.baseWeaponAGI + clicky.GetComponent<Sword>().agil;
				playerInventory.itemlistSwordIntel = playerInventory.baseWeaponINT + clicky.GetComponent<Sword>().intel;
				playerInventory.itemlistSwordLuck = playerInventory.baseWeaponLUC + clicky.GetComponent<Sword>().luc;
				//set other stats to 0
				playerInventory.itemlistBowStrength = 0;
				playerInventory.itemlistBowAgil = 0;
				playerInventory.itemlistBowIntel = 0;
				playerInventory.itemlistBowLuck = 0;
				playerInventory.itemlistStaffStrength = 0;
				playerInventory.itemlistStaffAgil = 0;
				playerInventory.itemlistStaffIntel = 0;
				playerInventory.itemlistStaffLuck = 0;
				
				Destroy(this.gameObject);
			}
			else if(clicky.tag == "Armor"){
				playerInventory.getArmor();
				Debug.Log(clicky.GetComponent<Armor>().itemName);
				playerInventory.itemlistArmorName = clicky.GetComponent<Armor>().itemName;   
				playerInventory.itemlistArmorStrength = playerInventory.baseArmorATK + clicky.GetComponent<Armor>().str;
				playerInventory.itemlistArmorAgil = playerInventory.baseArmorAGI + clicky.GetComponent<Armor>().agil;
				playerInventory.itemlistArmorIntel = playerInventory.baseArmorINT + clicky.GetComponent<Armor>().intel;
				playerInventory.itemlistArmorLuck = playerInventory.baseArmorLUC + clicky.GetComponent<Armor>().luc;
				Destroy(this.gameObject);
			}
			else if(clicky.tag == "Helm"){
				playerInventory.getHelm();
				Debug.Log(clicky.GetComponent<Helm>().itemName); 
				playerInventory.itemlistHelmName = clicky.GetComponent<Helm>().itemName;   
				playerInventory.itemlistHelmStrength = playerInventory.baseHelmATK + clicky.GetComponent<Helm>().str;
				playerInventory.itemlistHelmAgil = playerInventory.baseHelmAGI + clicky.GetComponent<Helm>().agil;
				playerInventory.itemlistHelmIntel = playerInventory.baseHelmINT + clicky.GetComponent<Helm>().intel;
				playerInventory.itemlistHelmLuck = playerInventory.baseHelmLUC + clicky.GetComponent<Helm>().luc;
				Destroy(this.gameObject);
			}
			else if(clicky.tag == "Bow"){
				playerInventory.getBow();
				Debug.Log(clicky.GetComponent<Bow>().itemName); 
				playerInventory.itemlistBowName = clicky.GetComponent<Bow>().itemName;   
				playerInventory.itemlistBowStrength = playerInventory.baseWeaponATK + clicky.GetComponent<Bow>().str;
				playerInventory.itemlistBowAgil = playerInventory.baseWeaponAGI + clicky.GetComponent<Bow>().agil;
				playerInventory.itemlistBowIntel = playerInventory.baseWeaponINT + clicky.GetComponent<Bow>().intel;
				playerInventory.itemlistBowLuck = playerInventory.baseWeaponLUC + clicky.GetComponent<Bow>().luc;
				//set other stats to 0
				playerInventory.itemlistStaffStrength = 0;
				playerInventory.itemlistStaffAgil = 0;
				playerInventory.itemlistStaffIntel = 0;
				playerInventory.itemlistStaffLuck = 0;
				playerInventory.itemlistSwordStrength = 0;
				playerInventory.itemlistSwordAgil = 0;
				playerInventory.itemlistSwordIntel = 0;
				playerInventory.itemlistSwordLuck = 0;
				
				
				Destroy(this.gameObject);
			}
			else if(clicky.tag == "Staff"){
				playerInventory.getStaff();
				Debug.Log(clicky.GetComponent<Staff>().itemName); 
				playerInventory.itemlistStaffName = clicky.GetComponent<Staff>().itemName;   
				playerInventory.itemlistStaffStrength = playerInventory.baseWeaponATK + clicky.GetComponent<Staff>().str;
				playerInventory.itemlistStaffAgil = playerInventory.baseWeaponAGI + clicky.GetComponent<Staff>().agil;
				playerInventory.itemlistStaffIntel = playerInventory.baseWeaponINT + clicky.GetComponent<Staff>().intel;
				playerInventory.itemlistStaffLuck = playerInventory.baseWeaponLUC + clicky.GetComponent<Staff>().luc;
				//set other items to 0 stats  
				playerInventory.itemlistBowStrength = 0;
				playerInventory.itemlistBowAgil = 0;
				playerInventory.itemlistBowIntel = 0;
				playerInventory.itemlistBowLuck = 0;
				playerInventory.itemlistSwordStrength = 0;
				playerInventory.itemlistSwordAgil = 0;
				playerInventory.itemlistSwordIntel = 0;
				playerInventory.itemlistSwordLuck = 0;
				
				Destroy(this.gameObject);
			}
			else if(clicky.tag == "Potion"){
				Destroy(this.gameObject);
				playerInventory.currentHP = playerInventory.fullHP;
			}
			else{
				Debug.Log("tag not found");
			}
		}
		playerInventory.currentATK = playerInventory.itemlistBowStrength + playerInventory.itemlistSwordStrength
			+ playerInventory.itemlistStaffStrength + playerInventory.itemlistArmorStrength + playerInventory.itemlistHelmStrength;
		playerInventory.currentAGI = playerInventory.itemlistStaffAgil + playerInventory.itemlistBowAgil
			+ playerInventory.itemlistSwordAgil + playerInventory.itemlistArmorAgil + playerInventory.itemlistHelmAgil;
		playerInventory.currentINT = playerInventory.itemlistStaffIntel + playerInventory.itemlistBowIntel
			+ playerInventory.itemlistSwordIntel + playerInventory.itemlistArmorIntel + playerInventory.itemlistHelmIntel;
		playerInventory.currentLUC = playerInventory.itemlistStaffLuck + playerInventory.itemlistBowLuck
			+ playerInventory.itemlistSwordLuck + playerInventory.itemlistArmorLuck + playerInventory.itemlistHelmLuck;
	}
}
