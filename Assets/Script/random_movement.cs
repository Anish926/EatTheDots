using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_movement : MonoBehaviour {

	private float x;
	private float y;
	private float speed = 0.01f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
			this.transform.Rotate(0,1,0);
		}

	void translated(){
		speed = Random.Range(0.01f,0.001f);
		x = Random.Range(-1000f,1000f);
		y = Random.Range(-1000,1000f);
		transform.Translate (new Vector3 (x,y) * Time.deltaTime * speed);

	}
}
