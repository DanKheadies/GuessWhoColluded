// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  07/31/2018

using System.Collections;
using System.Collections.Generic;
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
