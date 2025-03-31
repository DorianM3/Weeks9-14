using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class Shooting : MonoBehaviour
{
    public UnityEvent onClick;
    public SpriteRenderer player;
    public GameObject bullet; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 characterclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (player.bounds.Contains(characterclick))
            {
                onClick.Invoke(); 
            }
        }
    }

    public void BulletSpawn()
    {
        Instantiate(bullet); 
    }
}
