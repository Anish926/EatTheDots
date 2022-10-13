using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name)
	{
		Application.LoadLevel (name);
		if(name=="Menu") Dot.count = 0;


	}
	public void QuitLevel(){
		Application.Quit();
	}
}
