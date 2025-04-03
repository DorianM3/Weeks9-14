using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;
using UnityEngine.U2D;


public class Footsteps : MonoBehaviour
{
    //a public audio source to take in the footsteps audio 
    public AudioSource audio;
    public CinemachineImpulseSource cinema; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Public function that is triggered by animation events
    public void foot()
    {
        audio.Play();
        cinema.GenerateImpulse(); 

    }
}
