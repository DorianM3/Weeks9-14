using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float t;
    public float maxgrow; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrowUp()); 
    }

    IEnumerator GrowUp()
    {
        while (t < maxgrow)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
            yield return null; 
        }
    }
}
