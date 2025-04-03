using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tilemapclick : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float speed = 2;
    public bool canRun = true;

    public Tilemap map;

    public Tile grass;
    public Tile stone;

    Vector2 currentpos;
    Vector2 direction;

    float leftOrRight;
    float upOrDown; 
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int grid = map.WorldToCell(mousepos); 
        if (Input.GetMouseButtonDown(0))
        {
            direction = mousepos;
            currentpos = transform.position;

            if(direction.x - currentpos.x > 0)
            {
                leftOrRight = 1; 
            }

            else
            {
                leftOrRight = -1;
            }

            if(direction.y - currentpos.y > 0)
            {
                upOrDown = 1;
            }

            else
            {
                upOrDown = -1;
            }

            if (map.GetTile(grid) == stone)
            {
                
            }

            else if(map.GetTile(grid) == grass)
            {
                Debug.Log("Stay off the grass!"); 
            }
        }

        sr.flipX = (direction.x < currentpos.x);

        animator.SetFloat("movement", Mathf.Abs(direction.x));

        if (currentpos.x < direction.x && leftOrRight == 1)
        {
            currentpos.x += speed * Time.deltaTime;
            transform.position = currentpos;
        }

        else if(currentpos.x > direction.x && leftOrRight == -1)
        {
            currentpos.x -= speed * Time.deltaTime;
            transform.position = currentpos;
        }

        if(currentpos.y < direction.y && upOrDown == 1)
        {
            currentpos.y += speed * Time.deltaTime;
            transform.position = currentpos; 
        }

        else if (currentpos.y > direction.y && upOrDown == -1)
        {
            currentpos.y -= speed * Time.deltaTime;
            transform.position = currentpos;
        }



    }
}
