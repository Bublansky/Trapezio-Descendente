using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

    public void GameOver()
    {
        SceneManager.LoadScene("Game_Over");
        //Application.LoadLevel("Game_Over");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
