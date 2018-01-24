using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Swaps out a sprite for another. 
//For example: switches from "good doggo" to "angry doggo"

public class ObjectDestroyer : MonoBehaviour
{
    public void DestroyDoggo()
    {
        Destroy(gameObject);
    }

}