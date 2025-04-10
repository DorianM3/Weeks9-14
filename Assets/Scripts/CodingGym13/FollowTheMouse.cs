using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheMouse : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject prefab; 
    void Update()
    {
        Vector2 mousepos;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousepos; 

        if(Input.GetKeyDown("space") == true)
        {
            sr.color = Random.ColorHSV();
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject storeprefab = Instantiate(prefab, transform.position, transform.rotation);
            
        }
    }
}
