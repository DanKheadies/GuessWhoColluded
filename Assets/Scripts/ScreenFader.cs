// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/29/2018
// Last:  07/29/2018

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Stops player movement while fading in / out
public class ScreenFader : MonoBehaviour
{
    private Animator anim;
    private Animator playerAnim;
    private PlayerMovement playerMovement;
    private Scene scene;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public IEnumerator FadeToClear()
    {
        playerMovement.bStopPlayerMovement = true;
        anim.SetTrigger("FadeIn");
        while (playerMovement.bStopPlayerMovement)
        {
            playerAnim.SetBool("bIsWalking", false);
            yield return null;
        }
    }

    public IEnumerator FadeToBlack()
    {
        playerMovement.bStopPlayerMovement = true;
        anim.SetTrigger("FadeOut");
        while (playerMovement.bStopPlayerMovement)
        {
            playerAnim.SetBool("bIsWalking", false);
            yield return null;
        }
    }
}
