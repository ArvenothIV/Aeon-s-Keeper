//ATTACH THIS ITEM TO THE CAMERA


using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

	private int toolbarInt = 0;
	private string[]  toolbarstrings =  {"Audio","Graphics","Stats","System"};
	private float savedTimeScale;
	public GUISkin skin;

	private bool showfps;
	public Color lowFPSColor = Color.red;
	public Color highFPSColor = Color.green;
	public int lowFPS = 30;
	public int highFPS = 50;
	private float fps;
	public enum Page {
		None,Main,Options,Credits,Quit
	}

	private Page currentPage;

	public string[] credits= {
		"A Group Production",
		"Programming by Important People",
		"Aeon's Keeper: The Final Journey",
		"Copyright (c) 2014 IP, LLC"} ;
	private float startTime = 0.1f;
	public GameObject start;

	void Start() {
		Time.timeScale = 1;
	}

	void OnGUI () {
		if (skin != null) {
			GUI.skin = skin;
		}
		ShowStatNums();
		if (IsGamePaused()) {
			GUI.color = Color.white;
			switch (currentPage) {
			case Page.Main: MainPauseMenu(); break;
			case Page.Options: ShowToolbar(); break;
			case Page.Credits: ShowCredits(); break;
			}
		}   
	}

	void LateUpdate () {
		if (showfps) {
			FPSUpdate();
		}
		
		if (Input.GetKeyDown("escape")) 
		{
			switch (currentPage) 
			{
			case Page.None: 
				PauseGame(); 
				break;
				
			case Page.Main: 
				if (!IsBeginning()) 
					UnPauseGame(); 
				break;
				
			default: 
				currentPage = Page.Main;
				break;
			}
		}
	}

	void MainPauseMenu() {
		BeginPage(350,400);
		if (GUILayout.Button (IsBeginning() ? "Play" : "Continue")) {
			UnPauseGame();
			
		}
		if (GUILayout.Button ("Save Game")) {

			GameObject gs = GameObject.Find("_GameSettings");
			GameSettings gsScript = gs.GetComponent<GameSettings>();
			gsScript.SaveCharData();

			UnPauseGame();//UNPUASE GAME BEFORE GOING TO A DIFFERENT SCREEN!!!
	//		Application.LoadLevel("MainMenu");
		}
		if (GUILayout.Button ("Options")) {
			currentPage = Page.Options;
		}
		if (GUILayout.Button ("Credits")) {
			currentPage = Page.Credits;
		}
		if (GUILayout.Button ("Quit")) {
			UnPauseGame();
			Destroy (GameObject.Find ("Player"));
			Destroy (GameObject.Find ("Inventory"));
			Destroy (GameObject.Find ("ScriptEmptyDontDestroy"));
			Application.LoadLevel("MainMenu");
		}
		EndPage();
	}

	void ShowToolbar() {
		BeginPage(350,400);
		toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarstrings);
		switch (toolbarInt) {
		case 0: VolumeControl(); break;
		case 3: ShowDevice(); break;
		case 1: Qualities(); QualityControl(); break;
		case 2: StatControl(); break;
		}
		EndPage();
	}

	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}

	void ShowBackButton() {
		if (GUI.Button(new Rect(20, Screen.height - 50, 50, 20),"Back")) {
			currentPage = Page.Main;
		}
	}

	void ShowCredits() {
		BeginPage(300,300);
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		EndPage();
	}

	void VolumeControl() {
		GUILayout.Label("Volume");
		AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0, 1);
	}

	void ShowDevice() {
		GUILayout.Label("Unity player version "+Application.unityVersion);
		GUILayout.Label("Graphics: "+SystemInfo.graphicsDeviceName+" "+
		                SystemInfo.graphicsMemorySize+"MB\n"+
		                SystemInfo.graphicsDeviceVersion+"\n"+
		                SystemInfo.graphicsDeviceVendor);
	}

	void QualityControl() {
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Decrease")) {
			QualitySettings.DecreaseLevel();
		}
		if (GUILayout.Button("Increase")) {
			QualitySettings.IncreaseLevel();
		}
		GUILayout.EndHorizontal();
	}

	void Qualities() {
		switch (QualitySettings.GetQualityLevel()) 
		{
		case 0:
			GUILayout.Label("Fastest");
			break;
		case 1:
			GUILayout.Label("Fast");
			break;
		case 2:
			GUILayout.Label("Simple");
			break;
		case 3:
			GUILayout.Label("Good");
			break;
		case 4:
			GUILayout.Label("Beautiful");
			break;
		default:
			GUILayout.Label("Fantastic");
			break;
		}
	}

	void StatControl() {
		GUILayout.BeginHorizontal();
		showfps = GUILayout.Toggle(showfps, "FPS");
		GUILayout.TextArea ("FPS", GUILayout.Height(50), GUILayout.Width(65));
		GUILayout.EndHorizontal();
	}

	void ShowStatNums() {
		GUILayout.BeginArea( new Rect(Screen.width - 100, 10, 100, 200));
		if (showfps) {
			string fpsstring= fps.ToString ("#,##0 fps");
			GUI.color = Color.Lerp(lowFPSColor, highFPSColor,(fps-lowFPS)/(highFPS-lowFPS));

			GUILayout.Label (fpsstring);
		}

		GUILayout.EndArea();
	}

	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}

	void PauseGame() {
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		//AudioListener.pause = true;
		currentPage = Page.Main;
	}

	void UnPauseGame() {
		Time.timeScale = savedTimeScale;
		//AudioListener.pause = false;
		
		currentPage = Page.None;
		
		if (IsBeginning() && start != null) {
			gameObject.SetActive(true);
		}
	}

	bool IsBeginning() {
		return (Time.time < startTime);
	}




	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}

	void FPSUpdate() {
		float delta = Time.smoothDeltaTime;
		if (!IsGamePaused() && delta !=0.0) {
			fps = 1 / delta;
		}
	}

}
