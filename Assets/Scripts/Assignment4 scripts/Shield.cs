using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    public UnityEvent shieldMe;
    public SpriteRenderer enemy;
    public GameObject shield;
    public Shooting shieldScore; 

    public bool cooldown;

    public bool isShieldUp;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 enemyclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (enemy.bounds.Contains(enemyclick))
            {
                shieldMe.Invoke();
            }
        }
    }
    GameObject shieldspawn;
    public void ShieldSpawn()
    {
        if (cooldown)
        {
            shieldScore.scoreUp.Invoke(); 
            shieldspawn = Instantiate(shield);
            cooldown = false;
            StartCoroutine(ShieldCooldownTimer());
            StartCoroutine(ShieldDestroyTimer());
        } 
    }

    IEnumerator ShieldCooldownTimer()
    {
        float time = 0f; 
        while (time < 5)
        {
          time += Time.deltaTime;
          yield return null;  
        }

        if(time >= 5)
        {
            cooldown = true;
        }
        
       
    }

    IEnumerator ShieldDestroyTimer()
    {
        float time = 0f;
        isShieldUp = true;
        while (time < 1f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if (time >= 1f)
        {
            Destroy(shieldspawn);
            isShieldUp = false;
        }

        


    }
}
