// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  08/26/2018

using UnityEngine;
using UnityEngine.SceneManagement;

// Pause the game & bring up the menu
public class PauseGame : MonoBehaviour
{
    public MovePauseMenuArrow movePArw;
    public OptionsManager oMan;
    public PlayerMovement pMove;
    public Scene scene;
    public TouchControls touches;
    public Transform controlsMenu;
    public Transform pauseMenu;
    public Transform pauseTrans;
    public Transform soundMenu;

    public bool bPauseActive;

    void Start()
    {
        // Initializers
        movePArw = GameObject.Find("PauseMenu").GetComponent<MovePauseMenuArrow>();
        oMan = FindObjectOfType<OptionsManager>();
        pMove = FindObjectOfType<PlayerMovement>();
        pauseTrans = GameObject.Find("PauseScreen").GetComponent<Transform>();
        pauseMenu = GameObject.Find("PauseMenu").transform;
        soundMenu = GameObject.Find("SoundMenu").transform;
        controlsMenu = GameObject.Find("ControlsMenu").transform;
        touches = FindObjectOfType<TouchControls>();
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

            bPauseActive = true;
            pMove.bStopPlayerMovement = true;
        }
        else
        {
            oMan.bPauseOptions = true;
            pauseTrans.transform.localScale = new Vector3(0, 0, 0);
            Time.timeScale = 1;

            movePArw.ResetArrows();

            bPauseActive = false;
            pMove.bStopPlayerMovement = false;
            touches.bUIactive = false;
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
