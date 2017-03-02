using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject player;

	
	//public Transform target;//set target from inspector instead of looking in Update
	public float speed = 3f;
	public int health = 10;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//aPlayer = player.GetComponent<playerController>();
	}
	
	void Update(){
		
		//rotate to look at the player
		transform.LookAt(player.transform);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
		
		
		//move towards the player
		if (Vector3.Distance(transform.position,player.transform.position)>1f){//move if distance from target is greater than 1
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}
		if(health <-0){
			Destroy(this);
		}
		
	}
	
}