using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

	public float playerX;
	public float playerY;
	public float playerZ;
	public GameObject pc;

	//So the object doesn't get destroyed on loading levels.
	void Awake(){
		DontDestroyOnLoad(this);
	}

//	// Use this for initialization
//	void Start () {
//
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//	}
	public void SaveCharData(){
		//PlayerPrefs.DeleteAll();            //Uncomment this and run the game every time you make changes to what is saved then comment back. <- precautionary device
		PlayerPrefs.SetString("currentLvl", Application.loadedLevelName);
		pc = GameObject.Find("Player");
		BaseCharacter pcClass = pc.GetComponent<BaseCharacter>();
		print (PlayerPrefs.GetString("currentLvl"));
		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString(), pcClass.GetPrimaryAttribute(cnt).BaseValue);
		}

		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++){
			PlayerPrefs.SetInt(((VitalName)cnt).ToString(), pcClass.GetVital(cnt).BaseValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString(), pcClass.GetVital(cnt).CurValue);
		}
		SavePlayerPosition(pc);
		PlayerPrefs.Save ();
	}

	public void LoadCharData(){
		if(PlayerPrefs.HasKey("currentLvl")){
			Application.LoadLevel(PlayerPrefs.GetString("currentLvl"));		//this is what I want it to do but have to figure out the correct way to do it.
		}
	}

	public static void SavePlayerPosition(GameObject pc){
		PlayerPrefs.SetFloat("PlayerPosX", pc.transform.position.x);
		print(pc.transform.position.x);
		PlayerPrefs.SetFloat("PlayerPosY", pc.transform.position.y);
		PlayerPrefs.SetFloat("PlayerPosZ", pc.transform.position.z);

	}

	public static int LoadCharacterPosition(){
		return 0;
	}
}
