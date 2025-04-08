using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public UnityEvent collideCheck;
    public bool check;
    public Vector2 bulletspeed;
    public Shield enemy; 


    // Start is called before the first frame update
    void Start()
    {
        speed = -5;
        check = false; 
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 bulletspeed = transform.position;
        bulletspeed.x += speed * Time.deltaTime;
        transform.position = bulletspeed;

        if (transform.position.x >= -9.5f && transform.position.x <= -8.1f)
        {
            if (enemy.isShieldUp)
            {
                Debug.Log("hi"); 
            }

            else
            {
                collideCheck.Invoke(); 
            }
            
        }
    }
}
