using UnityEngine;
using System.Collections;

public class animalAI : MonoBehaviour
{	

	float rnd;
	float startTime;
	int temp;
	public float speed;//Movement of character
	private Animator animator;//Grabs animator of whatever it's attached to.
	Vector2 v;
	
	// Use this for initialization
	void Start()
	{
		rnd = Random.Range(1,5);
		temp = (int)rnd;
		startTime = 0;
		animator = this.GetComponent<Animator>();//grabs animations in attached animator
	}

	// Update is called once per frame
	void Update(){

		if (startTime > Random.Range(1,3)) 
		{
			temp = (int)Random.Range(1,5);
			startTime = 0;
		}
		
		switch (temp) 
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
		startTime += Time.deltaTime;
	}
}