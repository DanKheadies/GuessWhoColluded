// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 08/08/2018
// Last:  08/09/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Logic for each character tile on the GWC board
public class CharacterTile : MonoBehaviour
{
    private TouchControls touches;
    public Transform tileChar;
    public Transform tileFlag;
    public Transform tileIcon;
    public Transform tileName;

    public bool bAvoidUpdate;
    public bool bHasEntered;
    public bool bHasExited;
    public bool bHasFlipped;
    public bool bShowChar;
    public bool bShowFlag;
    public bool bShowIcon;
    public bool bShowName;

    void Start ()
    {
        // Initializers
        tileChar = gameObject.transform.GetChild(2);
        tileFlag = gameObject.transform.GetChild(3);
        tileIcon = gameObject.transform.GetChild(0);
        tileName = gameObject.transform.GetChild(1);
        touches = FindObjectOfType<TouchControls>();

        bShowChar = true;
        bShowFlag = true;
        bShowIcon = true;
        bShowName = true;
    }
    
    void Update ()
    {
        if ((bHasEntered && !bHasExited && Input.GetButtonUp("Action")) ||
            (bHasEntered && !bHasExited && touches.bAction))
        {
            if (bHasFlipped)
            {
                ShowFront();
            }
            else if (!bHasFlipped)
            {
                ShowBack();
            }
            //CheckAndFlip();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !bAvoidUpdate)
        {
            if (bShowIcon)
            {
                tileIcon.GetComponent<SpriteRenderer>().enabled = false;
                bShowIcon = false;
            }
            else if (bShowName)
            {
                tileName.GetComponent<SpriteRenderer>().enabled = false;
                bShowName = false;
            }
            else if (bShowChar)
            {
                tileChar.GetComponent<SpriteRenderer>().enabled = false;
                bShowChar = false;
            }
            else if (bShowFlag)
            {
                // Reset
                tileIcon.GetComponent<SpriteRenderer>().enabled = true;
                tileName.GetComponent<SpriteRenderer>().enabled = true;
                tileChar.GetComponent<SpriteRenderer>().enabled = true;

                bShowIcon = true;
                bShowName = true;
                bShowChar = true;
            }

            bAvoidUpdate = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            bAvoidUpdate = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bHasEntered = true;
            bHasExited = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bHasEntered = false;
            bHasExited = true;
        }
    }

    public void ShowBack()
    {
        tileChar.transform.localScale = Vector3.zero;
        tileFlag.transform.localScale = Vector3.zero;
        tileIcon.transform.localScale = Vector3.zero;
        tileName.transform.localScale = Vector3.zero;

        bHasFlipped = true;
    }

    public void ShowFront()
    {
        tileChar.transform.localScale = Vector3.one;
        tileFlag.transform.localScale = Vector3.one;
        tileIcon.transform.localScale = Vector3.one;
        tileName.transform.localScale = Vector3.one;

        bHasFlipped = false;
    }

    public void CheckAndFlip()
    {
        Debug.Log("testicle");
        if (bHasFlipped)
        {
            Debug.Log("showing front");
            ShowFront();
        }
        else if (!bHasFlipped)
        {
            Debug.Log("showing back");
            ShowBack();
        }
    }
}
