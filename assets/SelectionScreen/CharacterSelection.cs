using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {
	public GameObject Character1;
	public GameObject Character2;
	public GameObject Character3;
	public GameObject Character4;
	float location = -1.0f;
	void OnMouseEnter () {

		Vector3 temp = this.gameObject.transform.position; 
		temp.y = 0.0f; 
		transform.position = temp;
	}

	void OnMouseExit () {
		Vector3 temp = this.gameObject.transform.position; 
		temp.y = location; 
		transform.position = temp;
	}
	void OnMouseDown () {
		Vector3 temp = this.gameObject.transform.position; 
		temp.y = 0.0f; 
		location = 0.0f;
		transform.position = temp;
		renderer.material.color = Color.gray;

		if( this.gameObject == Character1){
			Progression.playerClass = 1;
		}
		if( this.gameObject == Character2){
			Progression.playerClass = 2;
		}
		if( this.gameObject == Character3){
			Progression.playerClass = 3;
		}
		if( this.gameObject == Character4){
			Progression.playerClass = 4;
		}
		Application.LoadLevel ("makePlayer");
	}
}

