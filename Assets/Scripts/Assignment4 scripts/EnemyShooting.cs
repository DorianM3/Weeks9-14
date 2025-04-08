using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; 

public class EnemyShooting : MonoBehaviour
{
    public bool canShoot;
    public GameObject bullet;
    public UnityEvent shoot;
    public Shooting playerscript;

    public Shield enemy;

    private void Start()
    { 
       StartCoroutine(EnemyBulletInterval());
    }
    void Update()
    { 
        if (canShoot)
        {
            canShoot = false;
            shoot.Invoke(); 

        }
    }

    IEnumerator EnemyBulletInterval()
    {
        while (true)
        {
            float time = 0;
            float timer = Random.Range(10, 12);
            while (time < timer)
            {
                time += Time.deltaTime;
                yield return null;
            }

            if (time >= timer)
            {
                canShoot = true;
            }
        }


    }

    public void EnemyBulletSpawn()
    {
        GameObject redbullet = Instantiate(bullet);
        EnemyBullet getbullets = redbullet.GetComponent<EnemyBullet>(); 

        getbullets.collideCheck.AddListener(playerscript.TakeDamage);
        getbullets.enemy = enemy; 
        Destroy(redbullet, 3.2f);
        
    }
}
