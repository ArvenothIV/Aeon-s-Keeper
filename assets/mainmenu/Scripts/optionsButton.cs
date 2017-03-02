using UnityEngine;
using System.Collections;

public class optionsButton : MonoBehaviour {

	void OnMouseDown () {
		if(Input.GetMouseButtonDown (0)){
			Application.LoadLevel("OptionsMenu");
		}
		
	}
}
