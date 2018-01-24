using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Swaps out a sprite for another. 
//For example: switches from "good doggo" to "angry doggo"

public class SpriteSwapper : MonoBehaviour
{
    public Sprite spriteToUse; //Sprite to be displayed
    public SpriteRenderer spriteRenderer; //Sprite renderer that the new sprite should use
    private Sprite originalSprite;   //original sprite, this var saves it 

    public void SwapSprite()
    {
        //If this sprite is different from the current sprite
        if(spriteToUse != spriteRenderer.sprite)
        {
            originalSprite = spriteRenderer.sprite; //Save current sprite
            spriteRenderer.sprite = spriteToUse;    //Make the SpriteRender use the new sprite
        }
    }

    public void ResetSprite()
    {
        //Check existance of previous sprite
        if(originalSprite != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }

}