using UnityEngine;
using System.Collections;

public class quitButton : MonoBehaviour {


	void OnMouseDown () {
		if(Input.GetMouseButtonDown (0)){
			Application.Quit ();
		}
	
	}
}
