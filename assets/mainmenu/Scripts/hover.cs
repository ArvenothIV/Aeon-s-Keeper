using UnityEngine;
using System.Collections;

public class hover : MonoBehaviour {

	// Use this for initialization
	void OnMouseEnter () {
		renderer.material.color = Color.gray;
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		renderer.material.color = Color.white;
	}
}
