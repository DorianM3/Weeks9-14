using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class DamageEvent : MonoBehaviour
{
    public Transform bullet;
    public SpriteRenderer player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bulletpos = bullet.position;
        if (player.bounds.Contains(bulletpos))
        {
            Debug.Log("meow"); 
        }
    }
}
