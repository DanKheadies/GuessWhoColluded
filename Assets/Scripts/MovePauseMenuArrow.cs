// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 08/02/2018
// Last:  08/26/2018

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// To "move" and execute the arrows on the Pause Menu
public class MovePauseMenuArrow : MonoBehaviour
{
    private Button ControlsBtn;
    private Button GoOnBtn;
    private Button KREAMBtn;
    private Button QuitBtn;
    private Button SoundBtn;

    private GameObject ControlsArw;
    private GameObject GoOnArw;
    private GameObject KREAMArw;
    private GameObject QuitArw;
    private GameObject SoundArw;

    private Scene scene;

    private TouchControls touches;

    private Transform pauseMenu;


    public enum ArrowPos : int
    {
        GoOn = 167,
        KREAMinac = 120,
        Sound = -70,
        Controls = -118,
        Quit = -165
    }

    public ArrowPos currentPosition;

    void Start()
    {
        // Initializers
        ControlsBtn = GameObject.Find("Controls").GetComponent<Button>();
        GoOnBtn = GameObject.Find("GoOn").GetComponent<Button>();
        KREAMBtn = GameObject.Find("KREAMinac").GetComponent<Button>();
        QuitBtn = GameObject.Find("Quit").GetComponent<Button>();
        SoundBtn = GameObject.Find("Sound").GetComponent<Button>();

        ControlsArw = GameObject.Find("ControlsArw");
        GoOnArw = GameObject.Find("GoOnArw");
        KREAMArw = GameObject.Find("KREAMinacArw");
        SoundArw = GameObject.Find("SoundArw");
        QuitArw = GameObject.Find("QuitArw");

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
            if (Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.DownArrow)) //||
              //touches.bDown) DC TODO -- Fix touches w/ arrow movement (also, see OptionsMenu)
            {
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
                        currentPosition = ArrowPos.KREAMinac;
                        ClearAllArrows();
                        KREAMArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.KREAMinac)
                    {
                        currentPosition = ArrowPos.Sound;
                        ClearAllArrows();
                        SoundArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.W) ||
                     Input.GetKeyDown(KeyCode.UpArrow)) //||
                   //touches.bUp) DC TODO -- Fix touches w/ arrow movement (also, see OptionsMenu)
            {
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
                        currentPosition = ArrowPos.KREAMinac;
                        ClearAllArrows();
                        KREAMArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (currentPosition == ArrowPos.KREAMinac)
                    {
                        currentPosition = ArrowPos.GoOn;
                        ClearAllArrows();
                        GoOnArw.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            // Input.GetButtonDown("Action") DC TODO -- replace
            else if (Input.GetKeyDown(KeyCode.Space) ||
                     Input.GetKeyDown(KeyCode.Return) ||
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
                    if (currentPosition == ArrowPos.KREAMinac)
                    {
                        KREAMBtn.onClick.Invoke();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResetArrows();
            }
        }
    }

    public void ClearAllArrows()
    {
        if (pauseMenu.localScale == Vector3.one)
        {
            ControlsArw.transform.localScale = new Vector3(0, 0, 0);
            GoOnArw.transform.localScale = new Vector3(0, 0, 0);
            KREAMArw.transform.localScale = new Vector3(0, 0, 0);
            QuitArw.transform.localScale = new Vector3(0, 0, 0);
            SoundArw.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void ResetArrows()
    {
        ControlsArw.transform.localScale = Vector3.zero;
        GoOnArw.transform.localScale = Vector3.zero;
        KREAMArw.transform.localScale = Vector3.zero;
        QuitArw.transform.localScale = Vector3.zero;
        SoundArw.transform.localScale = Vector3.zero;

        GoOnArw.transform.localScale = Vector3.one;
        currentPosition = ArrowPos.GoOn;
    }
}
