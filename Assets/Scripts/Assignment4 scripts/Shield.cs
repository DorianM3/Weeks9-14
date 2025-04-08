using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    //Sets up all variables 
    public UnityEvent shieldMe;
    public SpriteRenderer enemy;
    public GameObject shield;
    public Shooting shieldScore; 

    public bool cooldown;

    public bool isShieldUp; 
  
    void Start()
    {
        //Makes the cooldown true to start as when the game starts, the player can use their shield right away 
        cooldown = true;
    }

    
    void Update()
    {
        //Everything only runs if the game is not over
        if (shieldScore.isGameOver == false)
        {
            //If the player clicks on the enemy they can invoke the shield event and defend themselves 
            Vector2 enemyclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (enemy.bounds.Contains(enemyclick))
                {
                    shieldMe.Invoke();
                }
            }
        }

        //If the game is in fact over though, stops all coroutines as they have no need to run 
        else
        {
            StopAllCoroutines();
        }
    }
    //Sets the gameobject outside of the public void so it can be used in the event 
    GameObject shieldspawn;
    public void ShieldSpawn()
    {
        //If the cooldown is true and you can use the shield, this if statement passes
        if (cooldown)
        {
            //The score is increased, activating the event in the Shooting class 
            shieldScore.scoreUp.Invoke(); 
            //A shield is instantiated to protect the player
            shieldspawn = Instantiate(shield);
            //Cooldown is false so the coroutines can begin making them true
            cooldown = false;
            //Runs two timers for both the cooldown and to destroy the shield 
            StartCoroutine(ShieldCooldownTimer());
            StartCoroutine(ShieldDestroyTimer());
        } 
    }

    IEnumerator ShieldCooldownTimer()
    {
        //The whole coroutine is to let enough time pass before the player is allowed to use their shield again
        float time = 0f; 
        while (time < 5)
        {
          time += Time.deltaTime;
          yield return null;  
        }

        //Once the timer has surpassed 5 seconds turns cooldown true and lets the player block 
        if(time >= 5)
        {
            cooldown = true;
        }
        
       
    }

    IEnumerator ShieldDestroyTimer()
    {
        //This coroutine is created rather than a destroy to make it easy to track in other scripts when the shield is up and when it is not 
        float time = 0f;
        isShieldUp = true;
        //For one second the shield stays up and the timer ticks
        while (time < 0.7f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        //Once the timer surpasses 1 the game notes down you are now vulnarable and destroys your shield
        if (time >= 0.7f)
        {
            Destroy(shieldspawn);
            isShieldUp = false;
        }

        


    }
}
