using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

    public void GameOver()
    {
        PlayerPrefsManager.UpdateIntLocalScore(PlayerPrefsManager.HIGHSCORE, GetComponent<ScoreManager>().GetScore());
        PlayerPrefsManager.UpdateIntLocalScore(PlayerPrefsManager.LASTSCORE, GetComponent<ScoreManager>().GetScore());
        SceneManager.LoadScene("Game_Over");

        //Application.LoadLevel("Game_Over");
    }
	// Update is called once per frame
	void Update () {
	
	}
}

