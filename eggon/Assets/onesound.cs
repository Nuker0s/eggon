using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onesound : MonoBehaviour
{

    // Start is called before the first frame update
    public static void playsound(Vector3 pos, AudioClip clip, float audiomultipler)
    {
        GameObject obj = new GameObject("oneshot");
        AudioSource source= obj.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = globalvariables.mainsoundvolume*audiomultipler;
        volumeupdater vup = obj.AddComponent<volumeupdater>();
        vup.voicemult = audiomultipler;
        vup.source = source;
        source.Play();
        Destroy(obj, clip.length + 0.2f);
    }

}
