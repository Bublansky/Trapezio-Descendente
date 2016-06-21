using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject Barrinha,Barrinha2;
	public float x;

	public void Stop(){

		if(Barrinha.transform.position.x >= -0.46 && Barrinha.transform.position.x <= 0.46){
			x = x+0.5f;
			Debug.Log ("Yay");
			Barrinha2.transform.localScale += new Vector3(0,x,0);
			Debug.Log (x);
		}
	}
}