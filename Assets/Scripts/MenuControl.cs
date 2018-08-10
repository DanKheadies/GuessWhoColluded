// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 08/03/2018
// Last:  08/10/2018

using UnityEngine;
using UnityEngine.SceneManagement;

// For Buttons only: transition scene or quiting game
public class MenuControl : MonoBehaviour
{
    public GameObject endB;
    public GameObject startB;

    void Start()
    {
        // Initializers
        endB = GameObject.Find("End_Button");
        startB = GameObject.Find("Start_Button");
    }

    public void GoToScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("GuessWhoColluded");
    }

    public void NewGame()
    {
        startB.transform.localScale = Vector3.zero;
        endB.transform.localScale = Vector3.zero;
    }
}
