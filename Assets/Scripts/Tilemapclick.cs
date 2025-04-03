using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tilemapclick : MonoBehaviour
{
    public Tilemap map;

    public Tile grass;
    public Tile stone; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int grid = map.WorldToCell(mousepos); 
        if (Input.GetMouseButtonDown(0))
        {
            if(map.GetTile(grid) == stone)
            {
                transform.position = mousepos; 
            }

            else if(map.GetTile(grid) == grass)
            {
                Debug.Log("Stay off the grass!"); 
            }
        }
    }
}
