using UnityEngine;
using System.Collections;

public class TiledMap : MonoBehaviour {
	
	public Sprite spriteToTile;
	public int width = 1, height = 1;
	private GameObject[,] tiles; 
	// Use this for initialization
	void Start () {
		tiles = new GameObject[width, height]; 
		for(int i = 0; i < tiles.GetLength(0); i++){
			for(int k = 0; k < tiles.GetLength(1); k++){
				tiles[i, k] = new GameObject("Land");
				tiles[i, k].AddComponent<SpriteRenderer>();
				tiles[i, k].GetComponent<SpriteRenderer>().sprite = spriteToTile;
				tiles[i, k].transform.position = new Vector3(i - width/2f, k - height/2f, 1f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
