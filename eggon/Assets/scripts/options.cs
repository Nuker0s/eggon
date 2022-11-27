using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    public Slider sense;
    public TextMesh sensewyraz;
    public Slider mainvolume;
    public AudioClip testclip;
    
    private void Awake()
    {

        globalvariables.mainsoundvolume = mainmenu.initorloadplayerprefsvalves("mainvolume", globalvariables.mainsoundvolume);
        globalvariables.sense = mainmenu.initorloadplayerprefsvalves("sense", globalvariables.sense);
        PlayerPrefs.Save();
    }

    public void changemainvolume()
    {
        globalvariables.mainsoundvolume = mainvolume.value;
        PlayerPrefs.SetFloat("mainvolume", globalvariables.mainsoundvolume);
        PlayerPrefs.Save();
    }
    public void changesense()
    {
        globalvariables.sense = sense.value;
        PlayerPrefs.SetFloat("sense", globalvariables.sense);
        PlayerPrefs.Save();
    }

    void Start()
    {
        //mainvolume
        mainvolume.value = globalvariables.mainsoundvolume;
        onesound.playsound(transform.position, testclip, 1);
        //sense
        sense.value = globalvariables.sense;

    }

}
