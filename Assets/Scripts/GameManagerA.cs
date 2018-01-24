using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerA : MonoBehaviour
{
    public GameObject cardPrefab; //The prefab to instantiate when we need a new card
    public GameObject startPoint; //Starting position for card



	// Use this for initialization
	void Start ()
    {
        //Here we would instance the first card
        CreateNewCard();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CreateNewCard()
    {
        GameObject newCard = (GameObject)Instantiate(cardPrefab,startPoint.transform.position,startPoint.transform.rotation); //Arguments of Instantiate(prefab,position,rotation)...I guess

    }
}
