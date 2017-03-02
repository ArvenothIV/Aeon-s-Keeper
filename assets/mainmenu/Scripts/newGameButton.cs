using UnityEngine;
using System.Collections;

public class newGameButton : MonoBehaviour {
	
	
	void OnMouseDown () {
		if(Input.GetMouseButtonDown (0)){
			Application.LoadLevel("SelectionScreen");
		}
		
	}
}

