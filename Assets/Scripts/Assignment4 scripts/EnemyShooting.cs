using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; 

public class EnemyShooting : MonoBehaviour
{
    public float time;
    public bool canShoot;
    public GameObject bullet;
    public float timer;
    public float bulletSpeed; 

    public UnityEvent shoot;

    private void Start()
    {
        bulletSpeed = 2; 
    }
    void Update()
    {
        StartCoroutine(EnemyBulletInterval());

        if (canShoot)
        {
            canShoot = false;
            time = 0; 
            shoot.Invoke(); 

        }
    }

    IEnumerator EnemyBulletInterval()
    {
        timer = 2000; 
        while (time < timer)
        {
            time += bulletSpeed * Time.deltaTime / 5;
            yield return null;
        }

        if (time >= timer)
        {
            canShoot = true;
            StopCoroutine(EnemyBulletInterval());
        }


    }

    public void EnemyBulletSpawn()
    {
        GameObject enemyBullet = Instantiate(bullet);
        Destroy(enemyBullet, 3.2f);
    }
}
