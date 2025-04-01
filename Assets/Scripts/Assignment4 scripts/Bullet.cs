using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bulletspeed = transform.position;
        bulletspeed.x += speed * Time.deltaTime;
        transform.position = bulletspeed; 
    }
}
