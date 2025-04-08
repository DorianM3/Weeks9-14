using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = -5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bulletspeed = transform.position;
        bulletspeed.x += speed * Time.deltaTime;
        transform.position = bulletspeed;

        if (bulletspeed.x >= -9.5f && bulletspeed.x <= -8.1f)
        {
            Debug.Log("meow"); 
        }
    }
}
