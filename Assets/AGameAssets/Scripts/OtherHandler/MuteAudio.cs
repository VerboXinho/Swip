using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    // Mute UI button handler
    public void MuteHandler(bool mute)
    {
        if (mute) AudioListener.volume = 0;
        else AudioListener.volume = 1;
        Debug.Log(mute);
    }
}
