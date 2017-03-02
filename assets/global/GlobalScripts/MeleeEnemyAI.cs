//
//
// TAG ENEMIES AS: Enemy
// TAG PLAYERS AS: Player
//


using UnityEngine;
using System.Collections;

public class MeleeEnemyAI : MonoBehaviour {

	//private Time startTime = Time.time;
	//private int rnd;
	public bool RAAAAGEE;
	public GameObject Sword;
	public GameObject Armor;
	public GameObject Helm;
	public GameObject Bow;
	public GameObject Staff;
	public GameObject Potion;
	
	public bool willRespawn;
	public float spawnTime;//Time to respawn
	private float spawnTimer;
	private bool dead = false;
	private bool firstPassofDead = true;
	// Use this for initialization
	float rnd;
	float startTime;
	int temp;
	public float speed;//Movement of character
	public int health;
	private int startingHealth;
	public int damage;
	public GameObject inventory;
	private PlayerInventory playerInventoryPrivate;
	private Animator animator;//Grabs animator of whatever it's attached to.
	
	private Vector3 startLoc;//Where the enemy should respawn
	Vector2 v;
	
	// Use this for initialization
	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventoryPrivate = inventory.GetComponent<PlayerInventory>();
		Debug.Log (inventory);
		//playerInventoryPrivate = playerInventory.GetComponent<PlayerInventory>();
		rnd = Random.Range(1,5);
		temp = (int)rnd;
		startTime = 0;
		animator = this.GetComponent<Animator>();//grabs animations in attached animator
		
		spawnTimer = spawnTime;
		startLoc = this.gameObject.transform.position;
		startingHealth = health;
	}
	
	// Update is called once per frame
	void Update(){
		if(health <= 0 && dead == false){ dead = true;}
		if (dead && firstPassofDead)
		{
			firstPassofDead = false;
			//GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>.CurrentEXP += 10;
			playerInventoryPrivate.currentEXP += 10;
			playerInventoryPrivate.currentNEXT -= 10;
			playerInventoryPrivate.currentGold += 50;
			if(!willRespawn)
			{
				Destroy(this.gameObject);
			}
			System.Random rngesus = new System.Random();
			int roll = rngesus.Next(1,7);
			if(roll == 1){
				GameObject swordClone = (GameObject)Instantiate(Sword, transform.position, Quaternion.identity);
			}
			if(roll == 2){
				GameObject armorClone = (GameObject)Instantiate(Armor, transform.position, Quaternion.identity);
			}
			if(roll == 3){
				GameObject helmClone = (GameObject)Instantiate(Helm, transform.position, Quaternion.identity);
			}
			if(roll == 4){
				GameObject bowClone = (GameObject)Instantiate(Bow, transform.position, Quaternion.identity);
			}
			if(roll == 5){
				GameObject staffClone = (GameObject)Instantiate(Staff, transform.position, Quaternion.identity);
			}
			if(roll == 6 || roll == 7){
				GameObject potionClone = (GameObject)Instantiate(Potion, transform.position, Quaternion.identity);
			}
			
			if(willRespawn)
			{
				this.gameObject.transform.position = new Vector3(0f, 0f, 10f);//hide the enemy in the back
			}
			
			Progression.killCount++;
		}
		if (startTime > Random.Range (1, 3))
		{
			temp = (int)Random.Range (1, 5);
			startTime = 0;
		}
		if (startTime > 20)
		{
			RAAAAGEE = false;
		}
		if (!RAAAAGEE) 
		{
			moveMonsters (temp);
		} 
		else 
		{
			rageMove ();
		}

		startTime += Time.deltaTime;
		if(dead)
		{
			spawnTimer -= Time.deltaTime;
			if(spawnTimer <= 0)
			{
				respawn();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (!RAAAAGEE) 
		{
			if(other.tag == "Player")
			{
				RAAAAGEE = true;

				//Debug.Log("hit");
			}
			else
			{
				moveAwayFromWall (other);
			}
		} 
		else 
		{
			if(RAAAAGEE)
			{
				if(other.tag == "Player"){
				playerInventoryPrivate.currentHP -= damage;
					Debug.Log ("Hit!");
					if(playerInventoryPrivate.currentHP <=0){
						Destroy(GameObject.FindGameObjectWithTag("Player"));
					}
				}
				else{
					Debug.Log (other.ToString());
					moveAroundWall(other);
				}	
			}

		}
	}

	void moveAwayFromWall(Collider other)
	{
		rnd = (int)Random.Range (1, 5);
		if (other.transform.position.y > this.gameObject.transform.position.y && (int)rnd != 1) 
		{
			moveMonsters ((int)rnd);
		} 
		else if (other.transform.position.x < this.gameObject.transform.position.x && (int)rnd != 2) 
		{
			moveMonsters ((int)rnd);
		} 
		else if (other.transform.position.x > this.gameObject.transform.position.x && (int)rnd != 3) 
		{
			moveMonsters ((int)rnd);
		}
		else if (other.transform.position.y < this.gameObject.transform.position.y && (int)rnd != 4) 
		{
			moveMonsters ((int)rnd);
		}
		else
		{
			moveAwayFromWall(other);
		}

	}

	void moveAroundWall (Collider other)
	{
		if(other.transform.position.y > this.gameObject.transform.position.y)
		{
			moveMonsters (2);
		}
		else if(other.transform.position.x < this.gameObject.transform.position.x)
		{
			moveMonsters(4);
		}
		else if(other.transform.position.x > this.gameObject.transform.position.x)
		{
			moveMonsters(1);
		}
		else if(other.transform.position.y < this.gameObject.transform.position.y)
		{
			moveMonsters(3);
		}
	}

	void moveMonsters(int direction)
	{
		Vector2 v;
		switch (direction) 
		{
			case 1:
			{
				v = new Vector2(0.0f,speed);
				//animator.SetInteger ("Direction", 1);//Set animation to up
				animator.Play("walkUp");
				this.gameObject.transform.Translate(v);
				break;
			}
			case 2:
			{
				v = new Vector2(-speed,0.0f);
				//animator.SetInteger ("Direction", 2);//Set animation to left
				animator.Play("walkLeft");
				this.gameObject.transform.Translate(v);
				break;
			}
			case 3:
			{
				v = new Vector2(speed,0.0f);
				//animator.SetInteger ("Direction", 3);//Set animation to right
				animator.Play("walkRight");
				this.gameObject.transform.Translate(v);
				break;
			}
			case 4:
			{
				v = new Vector2(0.0f,-speed);
				//animator.SetInteger ("Direction", 4);//Set animation to down
				animator.Play("walkDown");
				this.gameObject.transform.Translate(v);
				break;
			}
		}
	}
	
	void rageMove()
	{
		Vector2 toTarget = GameObject.FindGameObjectWithTag("Player").transform.position - this.gameObject.transform.position;
		toTarget.Normalize();
		
		this.gameObject.transform.Translate(toTarget*speed);
	}
	
	void respawn()
	{
		dead = false;
		firstPassofDead = true;
		this.gameObject.transform.position = startLoc;
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
		health = startingHealth;
		spawnTimer = spawnTime;
	}
}
