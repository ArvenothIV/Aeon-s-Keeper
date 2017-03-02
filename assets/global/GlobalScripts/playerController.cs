//IN ORDER TO ATTACH THIS TO DIFFERENT PLAYER CONTROLLER CHARACTER MODELS, THEY MUST FOLLOW THE NUMBERING AND ANIMATION SCHEME


using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	int lastMove = 33;//idle frame
	private Animator animator;//Grabs animator of whatever it's attached to.
	public float movementSpeed, forwardSpeed, sideSpeed;
	public Vector3 speedVec;
	public CharacterController cc;
	public bool canMove = false, allowedToMove = true;
	public float timeBetweenShots = 0.25f;
	private float timestamp;
	public GameObject Attack;
	public GameObject BowAttack;
	public GameObject StaffAttack;
	public AudioSource audio;
	public AudioClip slash;
	public GameObject inventory;
	private PlayerInventory playerInventory;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();//grabs animations in attached animator
		cc = GetComponent<CharacterController> ();
		Object.DontDestroyOnLoad(this);
		animator.SetInteger ("Direction", lastMove);
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventory = inventory.GetComponent<PlayerInventory>();
		
	}
	
	// Update is called once per frame
	void Update(){
		
		if (allowedToMove) {	
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) ||
			    Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
				canMove = true;
			} 
			else {
				canMove = false;
			}
			
			forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
			sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed * Time.deltaTime;
			
			if (Input.GetKey (KeyCode.W)) {
				animator.SetInteger ("Direction", 1);//Set animation to up
				lastMove = 11;//allows for idle frame, easily ditinguished by doubling the integer of original frame
			} 
			else if (Input.GetKey (KeyCode.A)) {
				animator.SetInteger ("Direction", 2);
				lastMove = 22;
			} 
			else if (Input.GetKey (KeyCode.D)) {
				animator.SetInteger ("Direction", 3);
				lastMove = 33;
			} 
			else if (Input.GetKey (KeyCode.S)) {
				animator.SetInteger ("Direction", 4);
				lastMove = 44;
			}
			else {
				animator.SetInteger ("Direction", lastMove);//I am a genius, when nothing is pressed it goes to the last animation's idle 
			}
			
			speedVec = new Vector3 (sideSpeed, forwardSpeed, 0);
			speedVec = speedVec.normalized * movementSpeed;
			
			if (canMove) {
				cc.Move (speedVec);
			}
		}
		if(Time.time >= timestamp && (Input.GetKey (KeyCode.Space)) && playerInventory.hasSword == true){ //add swordequip bool
			
			audio.PlayOneShot(slash);
			
			if(lastMove == 11){
				GameObject attackClone = (GameObject)Instantiate(Attack, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
				Destroy (attackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 22){
				GameObject attackClone = (GameObject)Instantiate(Attack, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (attackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 33){
				GameObject attackClone = (GameObject)Instantiate(Attack, transform.position + new Vector3(1, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (attackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 44){
				GameObject attackClone = (GameObject)Instantiate(Attack, transform.position + new Vector3(0, - 1, 0), Quaternion.Euler (new Vector3(180, 0, 0)));
				Destroy (attackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}

		}
		if(Time.time >= timestamp && (Input.GetKey (KeyCode.Space)) && playerInventory.hasBow == true){
			  audio.PlayOneShot(slash);
			
			if(lastMove == 11){
				GameObject bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (bowattackClone,0.1f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (bowattackClone,0.15f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, 3, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (bowattackClone,0.20f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (bowattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 22){
				GameObject bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (bowattackClone,0.1f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(-2, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (bowattackClone,0.15f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(-3, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (bowattackClone,0.20f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(-4, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (bowattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 33){
				GameObject bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(1, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (bowattackClone,0.10f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(2, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (bowattackClone,0.15f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(3, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (bowattackClone,0.20f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(4, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (bowattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 44){
				GameObject bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, - 1, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (bowattackClone,0.10f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, - 2, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (bowattackClone,0.15f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, - 3, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (bowattackClone,0.20f);
				bowattackClone = (GameObject)Instantiate(BowAttack, transform.position + new Vector3(0, - 4, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (bowattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
	 }
	 if(Time.time >= timestamp && (Input.GetKey (KeyCode.Space)) && playerInventory.hasStaff == true){
			  audio.PlayOneShot(slash);
			
			if(lastMove == 11){
				GameObject staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (staffattackClone,0.10f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (staffattackClone,0.15f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, 3, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (staffattackClone,0.20f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, 4, 0), Quaternion.Euler(new Vector3(0,0, 90)));
				Destroy (staffattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 22){
				GameObject staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (staffattackClone,0.10f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(-2, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (staffattackClone,0.15f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(-3, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (staffattackClone,0.20f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(-4, 0, 0), Quaternion.Euler (new Vector3(0, 0, 0)));
				Destroy (staffattackClone,0.25f);

				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 33){
				GameObject staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(1, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (staffattackClone,0.10f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(2, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (staffattackClone,0.15f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(3, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (staffattackClone,0.20f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(4, 0, 0), Quaternion.Euler (new Vector3(0, 180, 0)));
				Destroy (staffattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
			else if(lastMove == 44){
				GameObject staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, - 1, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (staffattackClone,0.10f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, - 2, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (staffattackClone,0.15f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, - 3, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (staffattackClone,0.20f);
				staffattackClone = (GameObject)Instantiate(StaffAttack, transform.position + new Vector3(0, - 4, 0), Quaternion.Euler (new Vector3(180, 0, 90)));
				Destroy (staffattackClone,0.25f);
				timestamp = Time.time + timeBetweenShots;
			}
   }
		
	}
}