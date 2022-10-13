using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.Rotate(0,0,1);
	}

	void OnTriggerEnter2D (Collider2D trigger){	
		Destroy(gameObject);
		Dot.count = 0;
	}
}
