using UnityEngine;
using System.Collections;

public class Progression : MonoBehaviour {

	// Use this for initialization
	public static int progress = 0;
	public static string previousScene = "none";
	public static int playerClass = 1;
	public static int killCount = 0;

	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
