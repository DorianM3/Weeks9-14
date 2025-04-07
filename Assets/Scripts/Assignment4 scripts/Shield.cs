using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    public UnityEvent shieldMe;
    public SpriteRenderer enemy;
    public GameObject shield;
    public bool cooldown;
    public float time;
    public float cooldownSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        cooldown = true;
        cooldownSpeed = 2;  
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown == false)
        {
            StartCoroutine(ShieldCooldownTimer());
        }

        Vector2 enemyclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (enemy.bounds.Contains(enemyclick))
            {
                shieldMe.Invoke();
            }
        }
    }

    public void ShieldSpawn()
    {
        if (cooldown)
        {
            GameObject shieldspawn = Instantiate(shield);
            Destroy(shieldspawn, 0.5f);
            cooldown = false;
            time = 1; 
        }

        
    }

    IEnumerator ShieldCooldownTimer()
    {
        while (time < 1000)
        {
          time += cooldownSpeed * Time.deltaTime;
          yield return null;  
        }

        if(time >= 1000)
        {
            cooldown = true;
            StopCoroutine(ShieldCooldownTimer()); 
        }
        
       
    }
}
