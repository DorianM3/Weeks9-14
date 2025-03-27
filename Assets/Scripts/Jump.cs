using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public AnimationCurve anim; 
    public float t = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (Input.GetMouseButtonDown(1))
        {
            t += Time.deltaTime;
            while(t < 1)
            {
                transform.localPosition = Vector2.one * anim.Evaluate(t);
            }

        }
    }
}
