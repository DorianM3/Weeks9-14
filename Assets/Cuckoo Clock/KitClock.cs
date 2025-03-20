using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform spawn;
    public GameObject pirate; 
   
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine clockIsRunning;
    IEnumerator doOneHour; 
    void Start()
    {

        clockIsRunning = StartCoroutine(MoveTheClock()); 
    }

    IEnumerator MoveTheClock()
    {
        while (true)
        {
            doOneHour = MoveTheClockHandsOneHour(); 
            yield return StartCoroutine(doOneHour);
        }
    }

    IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while(t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null; 
        }
        hour++;
        GameObject newthing = Instantiate(pirate, spawn);
        Destroy(newthing, 0.1f);
     
        if(hour == 13)
        {
            hour = 1;
        }

        OnTheHour.Invoke(hour);
       
    }

    public void StopTheClock()
    {
        StopCoroutine(clockIsRunning); 
        StopCoroutine(doOneHour);
    }
}
