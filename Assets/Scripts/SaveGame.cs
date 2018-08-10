// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  08/10/2018

using UnityEngine;
using UnityEngine.SceneManagement;

// Save the game and then pull the saved info
public class SaveGame : MonoBehaviour
{
    public Camera savedCamera;
    public CameraFollow camFollow;
    public GameObject savedPlayer;
    public Scene scene;
    public UIManager uiMan;
    public VolumeManager savedVol;

    private string savedItem;

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
            uiMan = FindObjectOfType<UIManager>();
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

    // Saves *majority* of user data
    public void SavingGame()
    {
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.SetString("Chapter", scene.name);
        PlayerPrefs.SetFloat("Cam_x", savedCamera.transform.position.x);
        PlayerPrefs.SetFloat("Cam_y", savedCamera.transform.position.y);
        PlayerPrefs.SetFloat("P_x", savedPlayer.transform.position.x);
        PlayerPrefs.SetFloat("P_y", savedPlayer.transform.position.y);
    }

    // Test to check saved values
    public void CheckSavedData()
    {
        Debug.Log("Sav: " + PlayerPrefs.GetInt("Saved"));
        Debug.Log("Sce: " + PlayerPrefs.GetString("Chapter"));
        Debug.Log("Cam: (" + PlayerPrefs.GetFloat("Cam_x") + "," + PlayerPrefs.GetFloat("Cam_y") + ")");
        Debug.Log("Dan: (" + PlayerPrefs.GetFloat("P_x") + "," + PlayerPrefs.GetFloat("P_y") + ")");
        
        Debug.Log("Vol: " + PlayerPrefs.GetFloat("Volume"));
        Debug.Log("Con: " + PlayerPrefs.GetInt("ControlsActive"));
        Debug.Log("COp: " + PlayerPrefs.GetFloat("ControlsOpac"));

        Debug.Log("Tran: " + PlayerPrefs.GetInt("Transferring"));
        Debug.Log("TSce: " + PlayerPrefs.GetInt("TransferScene"));
        Debug.Log("TCam: (" + PlayerPrefs.GetFloat("TransferCam_x") + "," + PlayerPrefs.GetFloat("TransferCam_y") + ")");
        Debug.Log("TDan: (" + PlayerPrefs.GetFloat("TransferP_x") + "," + PlayerPrefs.GetFloat("TransferP_y") + ")");
    }

    // Saves UI Volume data
    public void SavingVolume()
    {
        PlayerPrefs.SetFloat("Volume", savedVol.currentVolumeLevel); // Called in VolumeManager
    }

    // Saves UI controls' opacity and  data
    public void SavingUIControls()
    {
        PlayerPrefs.SetFloat("ControlsOpac", uiMan.currentContOpac); // Called in UIManager

        if (uiMan.bControlsActive)
        {
            PlayerPrefs.SetInt("ControlsActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ControlsActive", 0);
        }
    }

    // Temp save position when leaving and returning to main world
    public void SavePositionTransfer()
    {
        PlayerPrefs.SetFloat("TransferCam_x", savedCamera.transform.position.x);
        PlayerPrefs.SetFloat("TransferCam_y", savedCamera.transform.position.y);
        PlayerPrefs.SetFloat("TransferP_x", savedPlayer.transform.position.x);
        PlayerPrefs.SetFloat("TransferP_y", savedPlayer.transform.position.y);
    }

    // Loads *all* user data at the start
    public void GetSavedGame()
    {
        savedPlayer.transform.position = new Vector2(
            PlayerPrefs.GetFloat("P_x"),
            PlayerPrefs.GetFloat("P_y"));

        savedCamera.transform.position = new Vector2(PlayerPrefs.GetFloat("Cam_x"), PlayerPrefs.GetFloat("Cam_y"));
        float posX = Mathf.SmoothDamp(savedCamera.transform.position.x, savedPlayer.transform.position.x, ref camFollow.smoothVelocity.x, camFollow.smoothTime);
        float posY = Mathf.SmoothDamp(savedCamera.transform.position.y, savedPlayer.transform.position.y, ref camFollow.smoothVelocity.y, camFollow.smoothTime);
        savedCamera.transform.position = new Vector3(posX, posY, -10);
    }

    // Loads *all* user data at the start
    public void GetTransferData()
    {
        savedPlayer.transform.position = new Vector2(
            PlayerPrefs.GetFloat("TransferP_x"),
            PlayerPrefs.GetFloat("TransferP_y"));

        savedCamera.transform.position = new Vector2(PlayerPrefs.GetFloat("TransferCam_x"), PlayerPrefs.GetFloat("TransferCam_y"));
        float posX = Mathf.SmoothDamp(savedCamera.transform.position.x, savedPlayer.transform.position.x, ref camFollow.smoothVelocity.x, camFollow.smoothTime);
        float posY = Mathf.SmoothDamp(savedCamera.transform.position.y, savedPlayer.transform.position.y, ref camFollow.smoothVelocity.y, camFollow.smoothTime);
        savedCamera.transform.position = new Vector3(posX, posY, -10);
    }

    // Testing -- Delete all values
    public void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
