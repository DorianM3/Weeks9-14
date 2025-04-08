using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; 

public class EnemyShooting : MonoBehaviour
{
    //Sets up all required variables 
    public bool canShoot;
    public GameObject bullet;
    public UnityEvent shoot;
    public Shooting playerscript;

    //Allows me to call variables from a different script 
    public Shield enemy;

    //The start function calls the bullet interval coroutine as it will always need to run while the game is active, firing bullets periodically. 
    private void Start()
    { 
       StartCoroutine(EnemyBulletInterval());
    }
    void Update()
    {
        //Getting the component from the Shooting script, checks if the game is over, if it is then the enemy need not fire, making the code stop the coroutine
        if (playerscript.isGameOver)
        {
            StopCoroutine(EnemyBulletInterval());
            canShoot = false; 
        }

        //If can shoot is true, envokes the event that makes the enemy shoot, along with making the variable false, forcing the enemy to run through the coroutine again to fire again
        if (canShoot)
        {
            canShoot = false;
            shoot.Invoke(); 

        }
    }

    IEnumerator EnemyBulletInterval()
    {
        //This makes it run infinitely so the enemy is always preparing to fire a bullet
        while (true)
        {
            //Reset the time and timer at the beginning of each bullet waiting to spawn 
            float time = 0;
            //Makes a small random range for a bit of varience 
            float timer = Random.Range(6f, 8f);

            //So long as the time isn't met the timer keeps counting up
            while (time < timer)
            {
                time += Time.deltaTime;
                yield return null;
            }

            //Once the timer is met, allows the enemy to shoot and goes back to the start, looping the coroutine again 
            if (time >= timer)
            {
                canShoot = true;
            }
        }


    }

    //The event that is triggered when the enemy can shoot 
    public void EnemyBulletSpawn()
    {
        //Gets the component from the prefab script EnemeyBullet 
        GameObject redbullet = Instantiate(bullet);
        EnemyBullet getbullets = redbullet.GetComponent<EnemyBullet>(); 

        //Adds a listener to taking damage whenever a bullet is spawned, a listener that is automatically removed when the bullet destroys itself. 
        getbullets.collideCheck.AddListener(playerscript.TakeDamage);
        //Due to this being the script that spawns the bullets, it is required as a middle man for getting the shield script to a prefab like EnemyBullet 
        getbullets.enemy = enemy; 
        //Destroys the bullets after a set amount of time. Does not put them in a list due to only one ever being spawned at a time 
        Destroy(redbullet, 3.2f);
        
    }
}
