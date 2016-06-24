using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    public static string HIGHSCORE = "HIGHSCORE";
    public static string LASTSCORE = "LASTSCORE";

    // Use this for initialization
    void Start () {
	
	}
	
    public static void UpdateIntLocalValue(string param, int value)
    {
        PlayerPrefs.SetInt(param, value);
        
    }

    public static int GetIntLocalValue(string param)
    {
        return PlayerPrefs.GetInt(param);
    }
    

	// Update is called once per frame
	void Update () {
	
	}
}
