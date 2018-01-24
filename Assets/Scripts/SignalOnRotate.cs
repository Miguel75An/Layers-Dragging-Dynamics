using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalOnRotate : MonoBehaviour
{

    private Quaternion execution_rotation = Quaternion.AngleAxis(180, Vector3.up);
    private bool check = true;
    public float rspeed = 2f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("EXEC");
        Debug.Log(execution_rotation);
        //Debug.Log(Quaternion.AngleAxis(-90, Vector3.up).y);
        //Debug.Log(transform.rotation.y);

        if(check && transform.rotation.y < Quaternion.AngleAxis(-90, Vector3.up).y) //We are checking the Y-componet of rotation 
        {
            //IMPORTANT: According to rspeed, if too fast, it will not activate the IF statement and will fail
            //to swap the sprite. A good value for rspeed is 1 and below since it runs throught most rotation values
            //but there are still instances where it fails. 

            //To fix this, we will add an additional check that checks if the sprite is the same or not after certain point
            //Ensuring this IF executes only once

            //When we have rotated to the point you can only see the edge of the card
            //then we swap the sprites
            SpriteSwapper myInstance = gameObject.GetComponent<SpriteSwapper>(); //Make instance of attached script

            myInstance.SwapSprite(); //Call function belonging to script
            Debug.Log("SWAPPED MADE ONCE ONLY");

            //Hmmm if we want this to happen only once, why dont we just destroy this script?
            //So that the if is not being checked everything during the update! HUH!
            //Destroy(this); //by "this" we mean ---> REMOVE THIS SCRIPT

            //Damn....now, the script gets removed before we complete the entire 180 rotation
            check = false; //this way we will never come back here again
            
        }

        //Debug.Log(transform.rotation);
        Debug.Log("outside");
        transform.rotation = Quaternion.Slerp(transform.rotation, execution_rotation, rspeed * Time.deltaTime); //Rotate a full circle (spin)
        Debug.Log(transform.rotation);
        if(transform.rotation.y == (-1 * execution_rotation.y))
        {
            Debug.Log("FIN");
            Destroy(this); //NOW REMOVE SCRIPT!
        }

    }
}
