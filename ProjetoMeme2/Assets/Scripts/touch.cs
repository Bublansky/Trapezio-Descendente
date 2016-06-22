using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject VaiEVem, RegiaoAlvo, BamBamObject;
    public Slider EnergyBar;
	public float CountToPowerUp;
    private float newY;
    private Vector3 newScale;
    public int maxEnergy = 4;
    private bool CanStop = true;
    private bool AlreadyTouched = false;
    public float ScaleSpeed = 0.2f;
    public float ReferencePosition = 0.5f;
    private float lerpTime = 3f;
    private float currentLerpTime = 0f;
    private float perc;

	public void Stop(){
        ///*
        if (CanStop)
        {
            if (VaiEVem.transform.position.x >= -ReferencePosition && VaiEVem.transform.position.x <= ReferencePosition)
            {
                if (!AlreadyTouched)
                {
                    AlreadyTouched = true;
                    // x = x+0.5f;
                    //Debug.Log("Yay");
                    //Barrinha2.transform.localScale += new Vector3(0,x,0);
                    EnergyBar.value += 1 / CountToPowerUp;
                    GetComponent<ScoreManager>().AddScore(1);
                }
            }
            else
            {
                AlreadyTouched = false;
            }
        }
        //*/
    }
    public void PowerUpTouch()
    {
        if (!CanStop)
        {
            GetComponent<ScoreManager>().AddScore(1);
        }
    }

    public void Update()
    {
        //<!-- consume energy
        if(EnergyBar.value == 1)
        {
            //Debug.Log("hello");
            BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", true);
            CanStop = false;
        }
        if(!CanStop)
        {
            //Debug.Log("hello2");
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            perc = currentLerpTime / lerpTime;
            EnergyBar.value = Mathf.Lerp(1, 0, perc);
            if(EnergyBar.value == 0)
            {
                CanStop = true;
                currentLerpTime = 0;
                BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", false);
            }
        }
        // -->
    } 
}