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
    private float xPosition;
    private bool DelayPowerUp = false;
    public float DelayPowerUpTime = 1.5f;
    //private bool 

	public void Stop(){
        ///*
        if (DelayPowerUp)
        {
            return;
        }
        else if (CanStop)
        {
            xPosition = VaiEVem.transform.position.x;
            //Debug.Log(xPosition);
            if (xPosition >= -0.5 && xPosition <= 0.5)
            {
                AlreadyTouched = false;
                if (!AlreadyTouched)
                {
                    
                    AlreadyTouched = true;
                    // x = x+0.5f;
                    //Debug.Log("Yay");
                    //Barrinha2.transform.localScale += new Vector3(0,x,0);
                    //Debug.Log(xPosition);
                    //Debug.Log("hello dear");
                    EnergyBar.value += 1 / CountToPowerUp;
                    GetComponent<ScoreManager>().AddScore(1);
                    BamBamObject.GetComponent<Animator>().SetBool("WantMore", true);
                }
            }
            else
            {
                GetComponent<LifeBarManager>().ReduceLife(1);
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
        /*
        if(Input.GetMouseButtonDown(0))
        {
            Stop();
        }
        */
        //<!-- consume energy
        if(EnergyBar.value == 1)
        {
            //Debug.Log("hello");
            //ativa o power up
            BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", true);
            DelayPowerUp = true;
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
                
                Invoke("SetDelayPowerUpFalse", DelayPowerUpTime);
            }
        }
        // -->
    } 
    private void SetDelayPowerUpFalse()
    {
        DelayPowerUp = false;
    }
}