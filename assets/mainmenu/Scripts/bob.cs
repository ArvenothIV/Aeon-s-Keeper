using UnityEngine;
using System.Collections;

public class bob : MonoBehaviour {

	float maxUpAndDown = 0.55f;
	float speed = 30;
	float angle = -90;
	float toDegrees = Mathf.PI / 180;
	float startHeight;


	void Start(){
		Vector3 temp = transform.localPosition;
		startHeight = temp.y;
		}

	void FixedUpdate(){
		angle += speed * Time.deltaTime;
		if (angle > 270) angle -= 360;
		//Debug.Log(maxUpAndDown * Mathf.Sin(angle * toDegrees));

		Vector3 temp = transform.localPosition;
		temp.y = startHeight + maxUpAndDown * (1 + Mathf.Sin(angle * toDegrees)) / 2;

		transform.localPosition = temp;
		}
}
