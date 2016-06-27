using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MuteSound : MonoBehaviour {
	//public string SoundButtonTAG;
	public Sprite ButtonON, ButtonOFF;
	private bool muted =false;
	public  GameObject SoundButton;
	//private Animator SounderAni;
	// Use this for initialization
	void Start () {
		//SoundButton= GameObject.FindGameObjectWithTag (SoundButtonTAG);
		//SounderAni = SoundButton.GetComponent<Animator> ();
		if (AudioListener.volume == 0.0f) {
			muted= true;
			SoundButton.GetComponent<Image>().sprite=ButtonOFF;

		} else {
			muted = false;
			SoundButton.GetComponent<Image>().sprite=ButtonON;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Mute(){
		if (!muted)
		{
			AudioListener.volume = 0.0f;
			muted = true;
			SoundButton.GetComponent<Image>().sprite=ButtonOFF;
		}
		else
		{
			AudioListener.volume = 1.0f;
			muted = false;
			SoundButton.GetComponent<Image>().sprite=ButtonON;
		}
	}
}