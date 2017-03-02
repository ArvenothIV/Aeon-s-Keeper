using UnityEngine;
using System.Collections;


public class Attack : MonoBehaviour {
	
	public GameObject enemy;
	private MeleeEnemyAI aEnemy;
	
	private float redHitTime = 0.2f;
	private float redHitTimer;
	private bool red = false;

	// Use this for initialization
	void Start(){

		//enemy = GameObject.FindGameObjectWithTag("Enemy");
		//aEnemy = enemy.GetComponent<MeleeEnemyAI>();
	}
	
	// Update is called once per frame
	void Update () {
		if(red && redHitTimer > 0)
		{
			redHitTimer -= Time.deltaTime;
		}
		else if(red && redHitTimer <= 0 && aEnemy != null)
		{
			aEnemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			red = false;
		}	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy" && this.tag != "Enemy")
		{
			aEnemy = col.GetComponent<MeleeEnemyAI>();
			//do damage to enemy
			aEnemy.health--;
			//color the enemy red on hit
			aEnemy.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f);
			redHitTimer = redHitTime;
			red = true;
		}
		else{
			Debug.Log ("not an enemy");
		}
	}
}
