using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Invoes a UnityEvent when the Plauer collides with this object
[RequireComponent(typeof(Collider2D))]
public class SignalOnTouch : MonoBehaviour
{
    public UnityEvent onTouch;      //UnityEvent to run when we collide
    public bool playAudioonTouch = true; //Use this for audio in the future

    //When we enter a trigger area ---> call SendSignal

    void OnTriggerEnter2D(Collider2D collider)
    {
        SendSignal(collider.gameObject);
    }

    //When we collide with this object ---> call SendSignal
    void OnCollisionEnter2D(Collision2D collision)
    {
        SendSignal(collision.gameObject);
    }

    //Checks to see if this object was tagged as Player,
    //and invokes the UnityEvent if it was
    void SendSignal(GameObject objectThatHit)
    {
        if(objectThatHit.CompareTag("Player")) //Check "Player" tag
        {
            //Invoke the Event
            onTouch.Invoke();
        }
    }



}
