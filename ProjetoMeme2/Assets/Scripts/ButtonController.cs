using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	private string LevelToLoad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadScene(string Level){
		Application.LoadLevel (Level);
	}
	public void LevelOnClick(string Level){
		LevelToLoad = Level;
	}
	public void LoadIf(string Scene){
		if (PlayerPrefs.GetInt (Scene + "Unlocked") == 1) {
			Application.LoadLevel(LevelToLoad);
		}
	}
}
