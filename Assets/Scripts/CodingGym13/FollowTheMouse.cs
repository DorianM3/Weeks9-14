using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheMouse : MonoBehaviour
{
    public SpriteRenderer sr; 
    void Update()
    {
        Vector2 mousepos;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousepos; 

        if(Input.GetKeyDown("space") == true)
        {
            sr.color = Random.ColorHSV();
        }
    }
}
