﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSwitcher : MonoBehaviour
{

    //This enables you to see and set the field from inspector but 
    //it is hidden from other scripts and objects. 
    //charChoice represents which named object to move
    [SerializeField]
    private int charChoice;

    private int npcCount = 10;

    public GameObject npcObj;
    public GameObject area;   //quad
    private int areaX, areaY; //get the size of the quad

    // Use this for initialization
    void Start()
    {
        //Initially disable all but the chosen one
        disableOthers();

        areaX  = ((int)area.transform.localScale.x) / 2;
        areaY = ((int)area.transform.localScale.y) / 2;

        for (int i = 0; i < npcCount; i++) //create and instantiate the npcs (we can make it more complicated later)
        {
            int ranX = Random.Range(-areaX, areaX);
            int ranY = Random.Range(-areaY, areaY);
            Vector3 pos = new Vector3(ranX, ranY, -1);
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            Instantiate(npcObj, pos, rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Poll for key press
        switchCharacter();
    }

    public int getChar()
    {
        return charChoice;
    }
    //Function to handle character switching when 'E' is pressed
    private void switchCharacter()
    {
        ////Looking for 'E' to be pressed
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    //Cycle through choices on key press
        //    if (charChoice < 3)
        //    {
        //        charChoice++;
        //    }
        //    else
        //    {
        //        charChoice = 0;
        //    }
        charChoice = CheckClick.currentChoice;

        //Activate the object chosen and disable all the others
        GameObject choice = findGO(charChoice);
        Enable(choice);
        disableOthers();
        

    }

    //This function loops through all the other ones not chosen 
    //and disables their movement script
    private void disableOthers()
    {
        for (int i = 0; i < 4; i++)
        {
            if (charChoice != i)
            {
                GameObject B = findGO(i);
                Disable(B);
            }
        }
    }

    //Helper function for finding game objects
    private GameObject findGO(int i)
    {
        string choice = "bush" + i.ToString();
        GameObject someB = GameObject.Find(choice);
        return someB;
    }

    //Enables a game object's script
    private void Enable(GameObject B)
    {
        B.GetComponent<Movement>().enabled = true;
    }

    //Disables a game object's script
    private void Disable(GameObject B)
    {
        B.GetComponent<Movement>().enabled = false;
    }

    
}
