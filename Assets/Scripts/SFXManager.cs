// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  08/10/2018

using UnityEngine;

// Manage audio sound effects
public class SFXManager : MonoBehaviour
{
    public AudioSource[] sounds;

    private static bool bSFXManExists;

    void Start()
    {
        if (!bSFXManExists)
        {
            bSFXManExists = true;
        }
    }
}
