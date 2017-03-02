using UnityEngine;
using System.Collections;

public class returnButton : MonoBehaviour {

	void OnMouseDown () {
		if(Input.GetMouseButtonDown (0)){
			Application.LoadLevel("MainMenu");
		}
		
	}
}
