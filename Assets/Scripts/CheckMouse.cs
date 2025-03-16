using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

public class CheckMouse : MonoBehaviour
{
    // Creates two sprites for when the mouse is on top of the image and when it stops hovering the image 
    public Sprite hover;
    public Sprite leave;

    //Creates a sprite renderer so that what happens to the image can effect sprites other than the ones the script is attatched to 
    public SpriteRenderer sr; 

    //Creates a public gameobject to get a prefab to instantiate 
    public GameObject inst; 

    //All 3 of the below functions do what they should when the mouse is interacting with the image in a specific way, either changing the sprite of something or instantiating something 
    public void MouseIsHovering()
    { 
        sr.sprite = hover; 
    }

    public void MouseIsLeaving()
    {
        sr.sprite = leave;
    }
    
    public void MouseIsClicking()
    {
        Instantiate(inst); 
    }
}
