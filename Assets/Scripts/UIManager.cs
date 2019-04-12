// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/29/2018
// Last:  04/10/2019

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Manage UI Display
public class UIManager : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas HUD;
    public Canvas dHUD;
    public CanvasGroup contOpacCan;
    public CanvasGroup hudCanvas;
    public DialogueManager dMan;
    public OptionsManager oMan;
    public RectTransform controlsMenu;
    public RectTransform iconsMenu;
    public RectTransform pauseMenu;
    public RectTransform soundMenu;
    public Scene currScene;
    public Slider contOpacSlider;
    public Toggle conTog;
    public TouchControls touches;

    public bool bControlsActive;

    public float currentContOpac;

    void Start ()
    {
        // Initializers
        contOpacCan = GameObject.Find("GUIControls").GetComponent<CanvasGroup>();
        contOpacSlider = GameObject.Find("ShowButtonsSlider").GetComponent<Slider>();
        conTog = GameObject.Find("ShowButtonsToggle").GetComponent<Toggle>();
        currScene = SceneManager.GetActiveScene();
        dHUD = GameObject.Find("Dialogue_HUD").GetComponent<Canvas>();
        dMan = FindObjectOfType<DialogueManager>();
        HUD = GetComponent<Canvas>();
        hudCanvas = GetComponent<CanvasGroup>();
        mainCamera = FindObjectOfType<Camera>().GetComponent<Camera>();
        oMan = FindObjectOfType<OptionsManager>();
        touches = FindObjectOfType<TouchControls>();

        controlsMenu = GameObject.Find("ControlsMenu").GetComponent<RectTransform>();
        pauseMenu = GameObject.Find("PauseMenu").GetComponent<RectTransform>();
        soundMenu = GameObject.Find("SoundMenu").GetComponent<RectTransform>();
        iconsMenu = GameObject.Find("IconsMenu").GetComponent<RectTransform>();

        // Sets initial activation off saved data
        if (!PlayerPrefs.HasKey("ControlsActive"))
        {
            // GWC default is no GUI
        }
        else
        {
            if (PlayerPrefs.GetInt("ControlsActive") == 1)
            {
                bControlsActive = true;
                conTog.isOn = true;
                DisplayControls();
            }
            else
            {
                bControlsActive = false;
                conTog.isOn = false;
                HideControls();
            }
        }

        // Sets initial opacity based off saved data
        if (!PlayerPrefs.HasKey("ControlsOpac"))
        {
            currentContOpac = 1.0f;
            contOpacSlider.value = 1.0f;
            contOpacCan.alpha = 1.0f;
        }
        else
        {
            currentContOpac = PlayerPrefs.GetFloat("ControlsOpac");
            contOpacSlider.value = currentContOpac;
            contOpacCan.alpha = currentContOpac;
        }

        // Sets menu position based off scene
        CheckAndSetMenus();
    }

    void Update()
    {
        if (!bControlsActive)
        {
            HideControls();
        }
    }

    public void DisplayControls()
    {
        touches.transform.localScale = Vector3.one;
    }

    public void HideControls()
    {
        touches.transform.localScale = Vector3.zero;
    }

    // Adjust the opacity of the UI controls
    public void ContOpacSliderChange()
    {
        currentContOpac = contOpacSlider.value;
        contOpacCan.alpha = currentContOpac;
    }

    // Toggles the UI controls
    public void ToggleControls()
    {
        if (bControlsActive)
        {
            HideControls();
            bControlsActive = false;
        }
        else if (!bControlsActive)
        {
            DisplayControls();
            bControlsActive = true;
        }
    }

    // Adjusts the volume slider based off keyboard input
    // DC 07/29/2018 -- TODO: Adjusts the volume slider based off keyboard input


    public void CheckAndSetMenus()
    {
        // Width > height = center in the screen
        if (Screen.width >= Screen.height)
        {
            controlsMenu.anchorMin = new Vector2(0.5f, 0.5f);
            controlsMenu.anchorMax = new Vector2(0.5f, 0.5f);
            controlsMenu.anchoredPosition = new Vector2(0, 0);

            pauseMenu.anchorMin = new Vector2(0.5f, 0.5f);
            pauseMenu.anchorMax = new Vector2(0.5f, 0.5f);
            pauseMenu.anchoredPosition = new Vector2(-140f, 0);

            soundMenu.anchorMin = new Vector2(0.5f, 0.5f);
            soundMenu.anchorMax = new Vector2(0.5f, 0.5f);
            soundMenu.anchoredPosition = new Vector2(0, 0);

            iconsMenu.anchorMin = new Vector2(0.5f, 0.5f);
            iconsMenu.anchorMax = new Vector2(0.5f, 0.5f);
            iconsMenu.anchoredPosition = new Vector2(0, 0);
        }
        // Height > width = stick to the top but below brio and menu button
        else
        {
            controlsMenu.anchorMin = new Vector2(0.5f, 1f);
            controlsMenu.anchorMax = new Vector2(0.5f, 1f);
            controlsMenu.anchoredPosition = new Vector2(0, -275f);

            pauseMenu.anchorMin = new Vector2(0.5f, 1f);
            pauseMenu.anchorMax = new Vector2(0.5f, 1f);
            pauseMenu.anchoredPosition = new Vector2(-140f, -275f);

            soundMenu.anchorMin = new Vector2(0.5f, 1f);
            soundMenu.anchorMax = new Vector2(0.5f, 1f);
            soundMenu.anchoredPosition = new Vector2(0, -275f);

            iconsMenu.anchorMin = new Vector2(0.5f, 1f);
            iconsMenu.anchorMax = new Vector2(0.5f, 1f);
            iconsMenu.anchoredPosition = new Vector2(0, -275f);
        }
    }
}
