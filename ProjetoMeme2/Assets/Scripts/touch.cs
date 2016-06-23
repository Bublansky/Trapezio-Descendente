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
    public float AddVaiEVemSpeed;
    private Color InitialColor;
    public Color ClickColor;
    private Color ClickColor2;
    private float aux;
    //private bool 


    public void Start()
    {
        InitialColor = RegiaoAlvo.GetComponent<SpriteRenderer>().color;
        ClickColor2 = new Color(ClickColor.r, ClickColor.g, ClickColor.b);
        //Debug.Log(ClickColor.r + "," + ClickColor.g + "," + ClickColor.b);
    }
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

                    //feedback de acerto
                    
                    //RegiaoAlvo.GetComponent<SpriteRenderer>().color = new Color(25, 45, 27);
                    RegiaoAlvo.GetComponent<SpriteRenderer>().color = ClickColor2;
                    Invoke("ChangeColor", 0.2f);

                    GetComponent<ScoreManager>().AddScore(1);
                    BamBamObject.GetComponent<Animator>().SetBool("WantMore", true);
                }
            }
            else
            {
                Handheld.Vibrate();
                GetComponent<LifeBarManager>().ReduceLife(1);
                AlreadyTouched = false;
            }
        }
        //*/
    }
    private void ChangeColor()
    {
        RegiaoAlvo.GetComponent<SpriteRenderer>().color = InitialColor;
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
        // power up ativou aqui!!1
        if(EnergyBar.value == 1)
        {
            //Debug.Log("hello");
            //ativa o power up
            BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", true);

            //aumenta a velocidade do vai e vem
            aux = VaiEVem.GetComponent<Animator>().GetFloat("AnimationSpeed");
            VaiEVem.GetComponent<Animator>().SetFloat("AnimationSpeed", aux + AddVaiEVemSpeed);
            //VaiEVem.GetComponent<Animator>().SetInteger("AnimationSpeed2", 10);

            //controla o tempo de atraso do power up
            DelayPowerUp = true;

            //controla o toque durante o power up
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