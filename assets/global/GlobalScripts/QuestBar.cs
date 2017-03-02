using UnityEngine;
using System.Collections;

public class QuestBar : MonoBehaviour {

	public static string title = "Dream:";
	public static string task = "This in the quest bar. It will guide you throughout your journey. Press 'Q' twice to untoggle and toggle it.";
	public static bool toggled = true;
	public static float barHeight = Screen.height / 11f;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}

	void OnGUI()
	{
		GUI.skin.box.fontSize = (int)(Screen.height/30);
		if (toggled) {
			GUI.Box (new Rect (0f, 0f, Screen.width,
				barHeight), title + "\n" + task);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			toggled = !toggled;
		}
	}
}
