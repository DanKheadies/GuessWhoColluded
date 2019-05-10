// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  05/10/2019

using UnityEngine;
using UnityEngine.SceneManagement;

// Save the game and then pull the saved info
public class SaveGame : MonoBehaviour
{
    public Camera savedCamera;
    public CameraFollow camFollow;
    public GameObject savedPlayer;
    public Scene scene;
    public TouchControls touches;
    public UIManager uMan;
    public VolumeManager savedVol;

    void Start()
    {
        // Initializers
        scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            savedVol = FindObjectOfType<VolumeManager>();
        }
        else
        {
            camFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
            savedCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            savedPlayer = GameObject.FindGameObjectWithTag("Player");
            savedVol = FindObjectOfType<VolumeManager>();
            touches = FindObjectOfType<TouchControls>();
            uMan = FindObjectOfType<UIManager>();
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            DeleteAllPrefs();
        }


        if (Input.GetKeyUp(KeyCode.C))
        {
            CheckSavedData();
        }
    }

    public void RerunStart()
    {
        Start();
    }

    // Test to check saved values
    public void CheckSavedData()
    {
        Debug.Log("Vol: " + PlayerPrefs.GetFloat("Volume"));
        Debug.Log("Con: " + PlayerPrefs.GetInt("ControlsActive"));
        Debug.Log("COp: " + PlayerPrefs.GetFloat("ControlsOpac"));
        Debug.Log("CDP: " + PlayerPrefs.GetString("ControlsDPad"));
        Debug.Log("CVi: " + PlayerPrefs.GetString("ControlsVibrate"));
    }

    // Saves UI Volume data
    public void SavingVolume()
    {
        PlayerPrefs.SetFloat("Volume", savedVol.currentVolumeLevel); // Called in VolumeManager
    }

    // Saves UI controls' opacity and  data
    public void SavingUIControls()
    {
        PlayerPrefs.SetFloat("ControlsOpac", uMan.currentContOpac); // Called in UIManager
        PlayerPrefs.SetFloat("ControlsOpac", uMan.currentContOpac); // Also called in UIManager
        PlayerPrefs.SetInt("ControlsVibrate", touches.currentContVibe); // Called in TouchControls

        if (uMan.bControlsActive)
        {
            PlayerPrefs.SetInt("ControlsActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ControlsActive", 0);
        }
    }

    // Testing -- Delete all values
    public void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
