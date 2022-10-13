using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour {

	public static int count = 0;
	public GameObject Smoke;
	public AudioClip dead;
	private LevelManager levelmanager;


	// Use this for initialization
	void Start ()
	{
		print("Start");
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		if (this.tag == "dot") {
			count++;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (count == 0) {
			print ("you won");
			levelmanager.LoadLevel("Win");
		}

		this.transform.Rotate(0,0,1);
	}

	void OnTriggerEnter2D (Collider2D trigger){
		Destroy(gameObject);
		count--;	
		Instantiate (Smoke, transform.position, Quaternion.identity); 
		AudioSource.PlayClipAtPoint (dead, transform.position);
	}
}
