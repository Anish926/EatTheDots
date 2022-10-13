using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public int spriteindex;
	public Sprite[] enemy_face;
	private character fast;
	private Transform target;
	private float enemySpeed;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		fast = GameObject.FindObjectOfType<character>();

	}

	// Update is called once per frame
	void Update ()
	{ 
		if (fast) {
			sprite_enemyHandler ();
			enemyspeed ();
			this.GetComponent<SpriteRenderer> ().sprite = enemy_face [spriteindex];
		}
	}




	private void sprite_enemyHandler () {
		spriteindex = fast.SpriteIndex;
		if (fast.transform.position.x < this.transform.position.x && (fast.SpriteIndex==0 || fast.SpriteIndex==1)) {
			spriteindex = 0;
		} else if (fast.transform.position.x > this.transform.position.x && (fast.SpriteIndex==0 || fast.SpriteIndex==1)) {
			spriteindex = 1;
		} else if (fast.transform.position.y > this.transform.position.y && (fast.SpriteIndex ==2 || fast.SpriteIndex==3)) {
			spriteindex = 2;
		} else if (fast.transform.position.y < this.transform.position.y && (fast.SpriteIndex ==2 || fast.SpriteIndex==3)) {
			spriteindex = 3;
		}
	}

	void enemyspeed ()
	{
		if (fast.speed > 0) {
			enemySpeed = fast.speed - 1;
		}
		transform.position = Vector2.MoveTowards (transform.position, target.position, enemySpeed * Time.deltaTime);
		}
	}