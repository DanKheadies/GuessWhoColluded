// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  08/10/2018

using UnityEngine;

// Control the music / sound volume
public class VolumeController : MonoBehaviour
{
    public AudioSource theAudio;

    private float audioLevel;
    public float defaultAudio;

    void Start()
    {
        // Initializers
        theAudio = GetComponent<AudioSource>();

        defaultAudio = 1.0f;
    }

    public void SetAudioLevel(float volume)
    {
        if (theAudio == null)
        {
            theAudio = GetComponent<AudioSource>();
        }

        audioLevel = defaultAudio * volume;
        theAudio.volume = audioLevel;
    }
}
