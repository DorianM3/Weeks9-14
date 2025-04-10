using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoToMouse : MonoBehaviour
{
    [Range(0,1)]
    public float t;
    public float speed; 

    Vector2 start;
    Vector2 end; 
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0; 
        Vector2 direction = mousepos - transform.position;
        transform.up = direction;

        start = transform.position;
        end = mousepos; 
        
        transform.position = Vector2.Lerp(start, end, t);
        t += speed * Time.deltaTime; 
    }
}
