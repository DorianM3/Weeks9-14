using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem land;
    public float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 jump = transform.position;
        if (Input.GetMouseButtonDown(1))
        {
            while (t < 5)
            {
                t += 1 * Time.deltaTime; 
                jump.y += 1 * Time.deltaTime;
                transform.position = jump;
               
            }

            while(t > 0)
            {
                t -= 0.8f * Time.deltaTime;
                jump.y -= 1 * Time.deltaTime;
                transform.position = jump;
            }
            land.Emit(5); 
        }
        
    }
}
