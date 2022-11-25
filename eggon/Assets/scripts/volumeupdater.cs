using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class volumeupdater : MonoBehaviour
{
    public AudioSource source;
    public float voicemult;

    void Update()
    {
        source.volume = voicemult * globalvariables.mainsoundvolume;
    }
}
