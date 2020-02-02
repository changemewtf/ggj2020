using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbModel : MonoBehaviour
{
    public GameObject TheBird;

    private BarController heartBar;
    public float recoverPerSecond;
    public float heartRatePerFlap;
    public float heartRateToFood;
    private float heartRate;
    private float heartRateVelocity;
    private float heartRateAcceleration;

    private BarController tummyBar;
    private ShakeBehavior tummyShake;
    private float foodTotal;
    public float foodCapacity;
    public float startingFood;
    public float hungerWarningPercent;
    public float overfullWarningPercent;

    private BarController colonBar;
    private ShakeBehavior pooShake;
    private float pooTotal;
    public float pooCapacity;
    public float pooWarningPercent;
    
    public float baseFoodPerSec;
    public float foodToPooRate;
    public float foodPerMeal;

    public Button eatButton;
    public Button pooButton;
    public Button resetButton;

    public AudioSource PoopFalling;

    public Animator RainbowAnimation;

    private bool alive;
    private bool exploded;
    // public float heartRate;
    // Start is called before the first frame update
    private PoopGenerator poog;

    void Start()
    {
        poog = TheBird.GetComponent<PoopGenerator>();

        heartBar = GameObject.Find("HeartBar").GetComponent<BarController>();
        tummyBar = GameObject.Find("TummyBar").GetComponent<BarController>();
        tummyShake = GameObject.Find("TummyBar").GetComponent<ShakeBehavior>();
        colonBar = GameObject.Find("ColonBar").GetComponent<BarController>();
        pooShake = GameObject.Find("ColonBar").GetComponent<ShakeBehavior>();
       
        Reset();

        //eatButton.onClick.AddListener(Eat);
        //pooButton.onClick.AddListener(Poo);
        //resetButton.onClick.AddListener(Reset);
        
    }
    void Reset()
    {
        heartRate = 0.0f;
        heartRateVelocity = 0.0f;
        heartRateAcceleration = 0.0f;
        pooTotal = 0f;
        foodTotal = foodCapacity*startingFood;
        alive = true;
        exploded =false;

    }
    public void Eat()
    {
        //print("EAT!");
        foodTotal +=foodPerMeal;
    }

    void Poo()
    {
        //print("Poo!");
        pooTotal = 0;
        PoopFalling.Play();
        poog.MakePoop();
    }

    void Die()
    {
        alive=false;
        heartRate =0;
        heartBar.SetSize(heartRate);
        tummyBar.ResetColor();
        tummyShake.StopShake();
        colonBar.ResetColor();
        pooShake.StopShake();
        if(foodTotal<=0f && pooTotal >= pooCapacity)
        {
            print("You died full of poop");
        } 
        else if(foodTotal >=foodCapacity && pooTotal >= pooCapacity)
        {
            exploded=true;
            print("You exploded!");
        }
        else if(foodTotal<=0f )
        {
            print("You starved!");
        }
        else if(foodTotal >=foodCapacity)
        {
            print("You overate!");
        }
        else
        {
            print("Why did you die?");
        }

    }

    void UpdateHeartRate()
    {
        if(heartRate > 0f)
        {
            heartRateAcceleration= -recoverPerSecond;
        }
        else 
        {
            heartRateAcceleration = 0f;
        }
        float elapsedSeconds = Time.deltaTime;
        float prevHeartRateVelocity = heartRateVelocity;
        heartRateVelocity+=heartRateAcceleration*elapsedSeconds;
        heartRate+=((prevHeartRateVelocity+heartRateVelocity)/2)*elapsedSeconds;
        heartRate = Mathf.Clamp(heartRate,0.0f,1.0f);
        

        heartBar.SetSize(heartRate);
        if(heartRate <=0.0f)
        {
            heartRateAcceleration = 0f;
            heartRateVelocity = 0f;
        }
        if(heartRate>=1.0f)
        {
            heartRateVelocity =0f;
        }
    }

    void UpdateDigestion()
    {
        float actualFoodPerSec = baseFoodPerSec+heartRate*heartRateToFood;
        
        //You can't eat more food than you have (however if you do eat to much... you're nearing death!)
        float foodEaten = Mathf.Min(foodTotal,actualFoodPerSec);

        // foodEaten = Mathf.Clamp(foodTotal-actualFoodPerSec,0.0f,actualFoodPerSec)
        foodTotal = Mathf.Clamp(foodTotal-foodEaten,0.0f,foodCapacity);
        pooTotal = Mathf.Clamp(pooTotal+(foodEaten*foodToPooRate),0.0f,pooCapacity);
        tummyBar.SetSize(foodTotal/foodCapacity);
        colonBar.SetSize(pooTotal/pooCapacity);

        if(foodTotal<=0f || foodTotal >=foodCapacity)
        {
            Die();
        }
        else if(foodTotal < hungerWarningPercent*foodCapacity || foodTotal >overfullWarningPercent*foodCapacity)
        {
            tummyShake.TriggerShake();
            tummyBar.WarnColor();
            
        }
         
        else
        {
            tummyBar.ResetColor();
            tummyShake.StopShake();
        }
        
        if(pooTotal >= pooCapacity)
        {
           
            Poo();
        }
        else if(pooTotal > pooWarningPercent*pooCapacity)
        {
            pooShake.TriggerShake();
            colonBar.WarnColor();
        }
        else
        {
            colonBar.ResetColor();
            pooShake.StopShake();
        }
        
    }

    void Update()
    {   
        if(alive)
        {
            if (Input.GetKeyDown("space"))
            {
                heartRateVelocity+=heartRatePerFlap;
                // RainbowAnimation.Play("Flap");
                RainbowAnimation.SetTrigger("Flap");
            }
            
            UpdateHeartRate();
            UpdateDigestion();
        }
    }
}
