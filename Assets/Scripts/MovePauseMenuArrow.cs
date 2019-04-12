// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 08/02/2018
// Last:  01/13/2019

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// To "move" and execute the arrows on the Pause Menu
public class MovePauseMenuArrow : MonoBehaviour
{
    private Button CollumBtn;
    private Button ControlsBtn;
    private Button GoOnBtn;
    private Button IconsBtn;
    private Button MyCardBtn;
    private Button QuitBtn;
    private Button ResetBtn;
    private Button SoundBtn;

    private GameObject CollumArw;
    private GameObject ControlsArw;
    private GameObject GoOnArw;
    private GameObject IconsArw;
    private GameObject MyCardArw;
    private GameObject QuitArw;
    private GameObject ResetArw;
    private GameObject SoundArw;

    private Scene scene;

    private TouchControls touches;

    private Transform pauseMenu;

    public bool bControllerDown;
    public bool bControllerUp;
    public bool bFreezeControllerInput;


    public enum ArrowPos : int
    {
        GoOn = 167,
        Colluminac = 120,
        Icons = 75,
        MyCard = 25,
        Reset = -23,
        Sound = -70,
        Controls = -118,
        Quit = -165
    }

    public ArrowPos currentPosition;

    void Start()
    {
        // Initializers
        CollumBtn = GameObject.Find("Colluminac").GetComponent<Button>();
        ControlsBtn = GameObject.Find("Controls").GetComponent<Button>();
        GoOnBtn = GameObject.Find("GoOn").GetComponent<Button>();
        IconsBtn = GameObject.Find("Icons").GetComponent<Button>();
        MyCardBtn = GameObject.Find("MyCard").GetComponent<Button>();
        QuitBtn = GameObject.Find("Quit").GetComponent<Button>();
        ResetBtn = GameObject.Find("Reset").GetComponent<Button>();
        SoundBtn = GameObject.Find("Sound").GetComponent<Button>();

        CollumArw = GameObject.Find("ColluminacArw");
        ControlsArw = GameObject.Find("ControlsArw");
        GoOnArw = GameObject.Find("GoOnArw");
        IconsArw = GameObject.Find("IconsArw");
        MyCardArw = GameObject.Find("MyCardArw");
        QuitArw = GameObject.Find("QuitArw");
        ResetArw = GameObject.Find("ResetArw");
        SoundArw = GameObject.Find("SoundArw");

        pauseMenu = GameObject.Find("PauseScreen").transform;
        scene = SceneManager.GetActiveScene();
        touches = FindObjectOfType<TouchControls>();

        currentPosition = ArrowPos.GoOn;
    }

    void Update()
    {
        //Debug.Log((float)currentPosition);
        //var newfloat = (float)currentPosition;
        //Debug.Log(newfloat);
        //PauseArrow.transform.position = new Vector2(
        //    PauseArrow.transform.position.x,
        //    (int)currentPosition
        //    );
        //Debug.Log(newfloat);
        //Debug.Log((int)currentPosition);

        if (pauseMenu.localScale == Vector3.one)
        {
            // Controller Support 
            // DC TODO 01/10/2019 -- temp bug where sub-pause menus not closing as expected
            if (Input.GetAxis("Controller DPad Vertical") == 0 &&
               (!touches.bDown &&
                !touches.bUp))
            {
                bFreezeControllerInput = false;
            }
            else if (!bFreezeControllerInput &&
                    (Input.GetAxis("Controller DPad Vertical") > 0 ||
                    touches.bDown))
            {
                bControllerDown = true;
                bFreezeControllerInput = true;
            }
            else if (!bFreezeControllerInput &&
                    (Input.GetAxis("Controller DPad Vertical") < 0 ||
                    touches.bUp))
            {
                bControllerUp = true;
                bFreezeControllerInput = true;
            }

            if (Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.DownArrow) ||
                bControllerDown)
            {
                bControllerDown = false;

                // For core
                if (currentPosition == ArrowPos.GoOn)
                {
                    currentPosition = ArrowPos.Sound;
                    ClearAllArrows();
                    SoundArw.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (currentPosition == ArrowPos.Sound)
                {
                    currentPosition = ArrowPos.Controls;
                    ClearAllArrows();
                    ControlsArw.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (currentPosition == ArrowPos.Controls)
                {
                    currentPosition = ArrowPos.Quit;
                    ClearAllArrows();
                    QuitArw.transform.localScale = new Vector3(1, 1, 1);
                }

                // For Guess Who Colluded
                if (scene.name == "GuessWhoColluded")
                {
                    // Goes back "up" to correct option
                    if (currentPosition == ArrowPos.Sound)
                    {
                        currentPosition = ArrowPos.Colluminac;
                        ClearAllArrows();
                        CollumArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.Colluminac)
                    {
                        currentPosition = ArrowPos.Icons;
                        ClearAllArrows();
                        IconsArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.Icons)
                    {
                        currentPosition = ArrowPos.MyCard;
                        ClearAllArrows();
                        MyCardArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.MyCard)
                    {
                        currentPosition = ArrowPos.Reset;
                        ClearAllArrows();
                        ResetArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.Reset)
                    {
                        currentPosition = ArrowPos.Sound;
                        ClearAllArrows();
                        SoundArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.W) ||
                     Input.GetKeyDown(KeyCode.UpArrow) ||
                     bControllerUp)
            {
                bControllerUp = false;

                // For core
                if (currentPosition == ArrowPos.Quit)
                {
                    currentPosition = ArrowPos.Controls;
                    ClearAllArrows();
                    ControlsArw.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (currentPosition == ArrowPos.Controls)
                {
                    currentPosition = ArrowPos.Sound;
                    ClearAllArrows();
                    SoundArw.transform.localScale = new Vector3(1, 1, 1);

                }
                else if (currentPosition == ArrowPos.Sound)
                {
                    currentPosition = ArrowPos.GoOn;
                    ClearAllArrows();
                    GoOnArw.transform.localScale = new Vector3(1, 1, 1);
                }

                // For Guess Who Colluded
                if (scene.name == "GuessWhoColluded")
                {
                    if (currentPosition == ArrowPos.GoOn)
                    {
                        currentPosition = ArrowPos.Reset;
                        ClearAllArrows();
                        ResetArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.Reset)
                    {
                        currentPosition = ArrowPos.MyCard;
                        ClearAllArrows();
                        MyCardArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.MyCard)
                    {
                        currentPosition = ArrowPos.Icons;
                        ClearAllArrows();
                        IconsArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.Icons)
                    {
                        currentPosition = ArrowPos.Colluminac;
                        ClearAllArrows();
                        CollumArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.Colluminac)
                    {
                        currentPosition = ArrowPos.GoOn;
                        ClearAllArrows();
                        GoOnArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            else if (Input.GetButtonDown("Action") ||
                     Input.GetKeyDown(KeyCode.JoystickButton0) ||
                     touches.bAaction)
            {
                // For core
                if (currentPosition == ArrowPos.GoOn)
                {
                    GoOnBtn.onClick.Invoke();
                }
                else if (currentPosition == ArrowPos.Sound)
                {
                    SoundBtn.onClick.Invoke();
                }
                else if (currentPosition == ArrowPos.Controls)
                {
                    ControlsBtn.onClick.Invoke();
                }
                else if (currentPosition == ArrowPos.Quit)
                {
                    QuitBtn.onClick.Invoke();
                }

                // Guess Who Colluded
                if (scene.name == "GuessWhoColluded")
                {
                    if (currentPosition == ArrowPos.Colluminac)
                    {
                        CollumBtn.onClick.Invoke();
                    }
                    else if (currentPosition == ArrowPos.Icons)
                    {
                        IconsBtn.onClick.Invoke();
                    }
                    else if (currentPosition == ArrowPos.MyCard)
                    {
                        MyCardBtn.onClick.Invoke();
                    }
                    else if (currentPosition == ArrowPos.Reset)
                    {
                        ResetBtn.onClick.Invoke();
                    }
                }

                touches.bAaction = false;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) ||
                     Input.GetKeyUp(KeyCode.JoystickButton7) ||
                     Input.GetButton("BAction") ||
                     touches.bBaction)
            {
                ResetArrows();

                touches.bBaction = false;
            }
        }
    }

    public void ClearAllArrows()
    {
        if (pauseMenu.localScale == Vector3.one)
        {
            CollumArw.transform.localScale = Vector3.zero;
            ControlsArw.transform.localScale = Vector3.zero;
            GoOnArw.transform.localScale = Vector3.zero;
            IconsArw.transform.localScale = Vector3.zero;
            MyCardArw.transform.localScale = Vector3.zero;
            QuitArw.transform.localScale = Vector3.zero;
            ResetArw.transform.localScale = Vector3.zero;
            SoundArw.transform.localScale = Vector3.zero;
        }
    }

    public void ResetArrows()
    {
        CollumArw.transform.localScale = Vector3.zero;
        ControlsArw.transform.localScale = Vector3.zero;
        GoOnArw.transform.localScale = Vector3.zero;
        IconsArw.transform.localScale = Vector3.zero;
        MyCardArw.transform.localScale = Vector3.zero;
        QuitArw.transform.localScale = Vector3.zero;
        ResetArw.transform.localScale = Vector3.zero;
        SoundArw.transform.localScale = Vector3.zero;

        GoOnArw.transform.localScale = Vector3.one;
        currentPosition = ArrowPos.GoOn;
    }
}
