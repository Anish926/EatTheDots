using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour {

	public float speed ;
	public bool gamestart=false;
	public float Xaxis;
	public float Yaxis;
	public float timeRemain = 3000f;
	public int SpriteIndex;
	private Animator animator;
	public GameObject Smoke;
	public AudioClip dead;
	private LevelManager levelManager;
	private Text text;

	// Use this for initialization

	void Start (){
		text = GameObject.FindObjectOfType<Text>();
		animator = GetComponent<Animator>();
		levelManager = GameObject.FindObjectOfType <LevelManager>();
		}
	
	// Update is called once per frame
	void Update (){
		Xaxis = Input.GetAxis ("Horizontal");
		Yaxis = Input.GetAxis ("Vertical");
		Moment ();
		gameState ();
		spriteHandler();
		AnimatedMovement();
		Timer();
	}

	private void Timer ()
	{
		timeRemain = timeRemain - Time.deltaTime;
		text.text = "Time Remains " + timeRemain + "\n" + "Dots Remaining " + Dot.count;
		if (timeRemain <= 0) {
			LoadLevel();
		}
	}
	private void gameState () {
		if (Xaxis > 0 || Xaxis < 0 || Yaxis > 0 || Yaxis < 0) {
			gamestart = true;
		} else if (Xaxis ==0 || Yaxis == 0){
			gamestart = false;
		}
	}

	private void Moment (){
		if (gamestart) {
			transform.Translate (new Vector3 (Xaxis, Yaxis) * Time.deltaTime * speed);
			if (speed < 5) {
				speed++;
			}
		} else if (!gamestart && speed > 0) {
			speed --;
		}
	}


	public void AnimatedMovement (){
		animator.SetFloat("x",Xaxis);
		animator.SetFloat("y",Yaxis);
	}

	private void spriteHandler ()
	{
		if (Xaxis < 0) {
			SpriteIndex = 0;
		} else if (Xaxis > 0) {
			SpriteIndex = 1;
		} else if (Yaxis > 0) {
			SpriteIndex = 2;
		} else if (Yaxis < 0) {
			SpriteIndex = 3;
		}
	}


	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (dead, transform.position);
		Instantiate (Smoke, transform.position, Quaternion.identity); 
		LoadLevel();
		Destroy(gameObject);
	}

	void OnTriggerEnter2D (Collider2D trigger){
		transform.Rotate(0,0,10);
	}

	private void LoadLevel(){
		levelManager.LoadLevel("GameOver");
	}
}
