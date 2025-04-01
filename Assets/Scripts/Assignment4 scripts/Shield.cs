using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    public UnityEvent onClick;
    public SpriteRenderer enemy;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (enemy.bounds.Contains(enemyclick))
            {
                onClick.Invoke();
            }
        }
    }

    public void ShieldSpawn()
    {
       GameObject shieldspawn = Instantiate(shield);
       Destroy(shieldspawn, 0.5f); 
    }
}
