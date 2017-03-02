#pragma strict

var skin : GUISkin;
 
function OnGUI () {
	if (skin != null) {
			GUI.skin = skin;
	}
	AudioListener.volume = GUI.HorizontalSlider (Rect (Screen.width*.35, Screen.height*.15, 546, 30), AudioListener.volume, 0, 1);
 
    
    if (GUI.Button(Rect(Screen.width*.4,Screen.height*.3,100,100),"Decrease")) {
			QualitySettings.DecreaseLevel();
		}
	if (GUI.Button(Rect(Screen.width*.5,Screen.height*.3,100,100),"Increase")) {
			QualitySettings.IncreaseLevel();
		}
		
		
		switch (QualitySettings.GetQualityLevel()) 
		{
		case 0:
			GUI.Label(Rect(Screen.width*.6,Screen.height*.33,200,200),"Fastest");
			break;
		case 1:
			GUI.Label(Rect(Screen.width*.6,Screen.height*.33,200,200),"Fast");
			break;
		case 2:
			GUI.Label(Rect(Screen.width*.6,Screen.height*.33,200,200),"Simple");
			break;
		case 3:
			GUI.Label(Rect(Screen.width*.6,Screen.height*.33,200,200),"Good");
			break;
		case 4:
			GUI.Label(Rect(Screen.width*.6,Screen.height*.33,200,200),"Beautiful");
			break;
		default:
			GUI.Label(Rect(Screen.width*.6,Screen.height*.33,200,200),"Fantastic");
			break;
		}
}