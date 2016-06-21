using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject Barrinha,Barrinha2;
    public Slider EnergyBar;
	public float x;
    private float newY;
    private Vector3 newScale;
    private int Energy = 0;
    public int maxEnergy = 4;
    private bool CanStop = true;
    public float ScaleSpeed = 0.2f;
    public float ReferencePosition = 0.5f;


    private float lerpTime = 3f;
    private float currentLerpTime = 0f;
    private float perc;

	public void Stop(){
        ///*
        if (CanStop)
        {
            if (Barrinha.transform.position.x >= -ReferencePosition && Barrinha.transform.position.x <= ReferencePosition)
            {
                // x = x+0.5f;
                //Debug.Log("Yay");
                //Barrinha2.transform.localScale += new Vector3(0,x,0);
                EnergyBar.value += x;
            }
        }
        //*/
    }

    public void Update()
    {
        //<!-- consume energy
        if(EnergyBar.value == 1)
        {
            CanStop = false;
        }
        if(!CanStop)
        {
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
            }
        }
        // -->
    }

    
}