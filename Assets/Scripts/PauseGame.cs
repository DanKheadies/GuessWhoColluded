// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  07/31/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Pause the game & bring up the menu
public class PauseGame : MonoBehaviour
{
    public OptionsManager oMan;
    public Scene scene;
    public Transform controlsMenu;
    public Transform pauseMenu;
    public Transform pauseTrans;
    public Transform soundMenu;


    void Start()
    {
        // Initializers
        oMan = GameObject.FindObjectOfType<OptionsManager>();
        pauseTrans = GameObject.Find("PauseScreen").GetComponent<Transform>();
        pauseMenu = GameObject.Find("PauseMenu").transform;
        soundMenu = GameObject.Find("SoundMenu").transform;
        controlsMenu = GameObject.Find("ControlsMenu").transform;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (pauseTrans.localScale != Vector3.one)
        {
            pauseMenu.transform.localScale = new Vector3(1, 1, 1);
            soundMenu.transform.localScale = new Vector3(0, 0, 0);
            controlsMenu.transform.localScale = new Vector3(0, 0, 0);

            pauseTrans.transform.localScale = new Vector3(1, 1, 1);
            Time.timeScale = 0;
        }
        else
        {
            oMan.bPauseOptions = true;
            pauseTrans.transform.localScale = new Vector3(0, 0, 0);
            Time.timeScale = 1;
        }
    }

    public void Sound(bool bOpen)
    {
        if (bOpen)
        {
            soundMenu.transform.localScale = new Vector3(1, 1, 1);
            pauseMenu.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            soundMenu.transform.localScale = new Vector3(0, 0, 0);
            pauseMenu.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Controls(bool bOpen)
    {
        if (bOpen)
        {
            controlsMenu.transform.localScale = new Vector3(1, 1, 1);
            pauseMenu.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            controlsMenu.transform.localScale = new Vector3(0, 0, 0);
            pauseMenu.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
