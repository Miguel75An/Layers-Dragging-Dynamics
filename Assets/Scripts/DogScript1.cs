using UnityEngine;
using System.Collections;
using System;

public class DogScript1 : MonoBehaviour
{

    public Transform center;
    public float spacing = 5f;
    public float mspeed = 10f;          //Move speed
    public float rspeed = 2f;         //Rotate speed
    public float smooth_factor = 2;
    private bool should_return = false;
    private Vector3 original_position;
    private Quaternion original_rotation;

    void Start()
    {
        original_position = transform.position;
        original_rotation = transform.rotation;
    }

    void Update()
    {
        if(Input.anyKey)
        {
            MoveCard();
        }
        else
        {
            ReturnCard();
        }
       
    }

    void MoveCard()
    {
        Vector3 pos = transform.position;   //Get pos to be a Vector3 var holding all x,y,z components

        if (Input.GetKey(KeyCode.W))
            pos.y += spacing;
        if (Input.GetKey(KeyCode.S))
            pos.y -= spacing;
        if (Input.GetKey(KeyCode.A))
            pos.x -= spacing;
        if (Input.GetKey(KeyCode.D))
            pos.x += spacing;

        transform.position = Vector3.MoveTowards(transform.position, pos, mspeed * Time.deltaTime); 
    }

    void ReturnCard()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ||
            should_return) //Activate this if, any wasd key is lifted or should_return is true
        {
            should_return = true; //we keep this true so every frame we "MoveTowards" and "Rotate" a little to the original positon

            transform.position = Vector3.MoveTowards(transform.position, original_position, mspeed * Time.deltaTime); //Move to default

            transform.rotation = Quaternion.Slerp(transform.rotation, original_rotation, rspeed * Time.deltaTime);    //Rotate to default

            if (transform.position == original_position && transform.rotation == original_rotation)
            {
                should_return = false; //At this point we have reached the original position, so "turn off" any movement
            }


        }
    }

}