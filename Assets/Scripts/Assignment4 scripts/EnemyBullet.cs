using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyBullet : MonoBehaviour
{
    //sets up all needed variables 
    public float speed;
    public UnityEvent collideCheck;
    public Vector2 bulletspeed;

    //Allows me to call variables from a different script 
    public Shield enemy; 


    void Start()
    {
        //Sets the speed at a consistent rate of 5 going in the left direction 
        speed = -5; 
    }

    void Update()
    {
        //Keeps the bullet going in a consistent direction and speed to the left towards the player
        Vector2 bulletspeed = transform.position;
        bulletspeed.x += speed * Time.deltaTime;
        transform.position = bulletspeed;

        //Checks if the bullet is within reach of the player using coordinates as the player is stationary
        if (transform.position.x >= -9.5f && transform.position.x <= -8.1f)
        {
            //Checks if the shield is up for the player, if it is then nothing happens
            if (enemy.isShieldUp)
            {
                
            }

            //If the player does not have their shield up the event for the game to end is triggered. 
            else
            {
                collideCheck.Invoke(); 
            }
            
        }
    }
}
