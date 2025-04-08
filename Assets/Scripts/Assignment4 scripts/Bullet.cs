using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Sets up the speed variable needed to configure the pace at which the bullet travels 
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Sets it to a consistent speed to the right of the screen 
        speed = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the position of the bullet to make it gradually move to the right
        Vector2 bulletspeed = transform.position;
        bulletspeed.x += speed * Time.deltaTime;
        transform.position = bulletspeed;
    }
}
