// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 08/10/2018
// Last:  08/10/2018

using UnityEngine;
using System.Collections;

public class PlatformDefines : MonoBehaviour
{
    void Start()
    {

    #if UNITY_EDITOR
            Debug.Log("Unity Editor");
    #endif

    #if UNITY_IOS
          Debug.Log("Iphone");
    #endif

    #if UNITY_STANDALONE_OSX
        Debug.Log("Stand Alone OSX");
    #endif

    #if UNITY_STANDALONE_WIN
          Debug.Log("Stand Alone Windows");
    #endif

    }
}