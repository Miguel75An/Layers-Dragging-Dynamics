using UnityEngine;
using System.Collections;
using System;

public class DestroyWhenCollide : MonoBehaviour
{

    public float spacing = 5f;
    public float mspeed = 10f;          //Move speed
    private Vector3 original_position;
   

    void Start()
    {
        original_position = transform.position;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            MoveCard();
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


}