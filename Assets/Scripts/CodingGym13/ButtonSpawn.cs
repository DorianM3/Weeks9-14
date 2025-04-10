using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ButtonSpawn : MonoBehaviour
{
    public GameObject prefab; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawner()
    {
        Vector3 spawn;
        spawn.x = Random.Range(-8f, 8f);
        spawn.y = Random.Range(-5f, 5f);
        spawn.z = 0; 
       GameObject storeprefab = Instantiate(prefab, spawn, transform.rotation);
    }
}
