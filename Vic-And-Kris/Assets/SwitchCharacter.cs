using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject sideScrollingCharacter;
    public GameObject topDownCharacter;

    
    //Variable that contains which player is on
    private int whichPlayerIsOn = 1;
    
    //Get the Color of both sprite renderers.
    private Color ssColor;
    private Color tdColor;
    
   
    void Start()
    {
        //First, we set the color variables to what they currently are.
        ssColor = sideScrollingCharacter.GetComponent<SpriteRenderer>().color;
        tdColor = topDownCharacter.GetComponent<SpriteRenderer>().color;
            
        //Then, set the color to be opaque
        tdColor.a = 0.5f;
        ssColor.a = 1.0f;

        //And set the unused character to have the opaqueness
        topDownCharacter.GetComponent<SpriteRenderer>().color = tdColor;
        sideScrollingCharacter.GetComponent<SpriteRenderer>().color = ssColor;
        //sideScrollingCharacter.gameObject.SetActive(true);
        //topDownCharacter.gameObject.SetActive(false);

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeCharacter();
            Debug.Log("Changing");
        }
    }

    public void ChangeCharacter()
    {
        //Processing the whichPlayerIsOn variable
        //Never used switch before.....gulp!
        switch (whichPlayerIsOn)
        {
            //If the side scoller guy is on...
            case 1:
                //Then the top down player is on now
                whichPlayerIsOn = 2;
                
                //disable the sidescroller, enable the top down
                ssColor.a = 0.5f;
                tdColor.a = 1.0f;

                sideScrollingCharacter.GetComponent<SpriteRenderer>().color = ssColor;
                topDownCharacter.GetComponent<SpriteRenderer>().color = tdColor;
                break;
            
            //If the top down guy is on...
            case 2:
                
                //Then the side scroller guy is on now
                whichPlayerIsOn = 1;
                
                //Disable the top down guy, enable the sidescroller
                ssColor.a = 1.0f;
                tdColor.a = 0.5f;

                sideScrollingCharacter.GetComponent<SpriteRenderer>().color = ssColor;
                topDownCharacter.GetComponent<SpriteRenderer>().color = tdColor;
                break;
        }
    }
}
