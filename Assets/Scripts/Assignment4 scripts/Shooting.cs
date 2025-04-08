using System.Collections;
using System.Collections.Generic;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; 

public class Shooting : MonoBehaviour
{
    //Sets up all required variables for the code 
    public UnityEvent shoot;
    public UnityEvent scoreUp; 

    public SpriteRenderer player;
    public GameObject bullet;

    public int scorecount; 
    public TextMeshProUGUI score;

    public bool isGameOver;

    void Start()
    {
        isGameOver = false; 
    }

    void Update()
    {
        //All of update is surrounded by a check so controls can be turned off in the case the gameover condition is met 
        if (isGameOver == false)
        {
            //Checks if the player is clicking on the player sprite 
            Vector2 characterclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                //If the player does click on the player sprite, makes the score go up by 1 and invokes the shoot event to send a bullet 
                if (player.bounds.Contains(characterclick))
                {
                    scoreUp.Invoke();
                    shoot.Invoke();
                }
            }
        }
    }

    //What shoot.Invoke activates, allows for a bullet to be instantiated and destroyed when it comes into contact with the enemy
    public void BulletSpawn()
    { 
        GameObject newbullet = Instantiate(bullet);
        Destroy(newbullet, 3.2f);
        
    }

    //Takedamage event which if occuring results in every script effectively turning off to signal to the player that they should restart 
    public void TakeDamage()
    {
        isGameOver = true;
    }

    //What scoreUp.Invoke activates, increasing the score seen on screen to keep track of how many shots and shield uses you've had 
    public void ScoreTrack()
    {
        scorecount += 1;
        score.text = scorecount.ToString(); 
    }
}
