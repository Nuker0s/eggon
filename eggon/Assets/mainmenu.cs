using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{
    public Slider mainvolume;
    public AudioClip testclip;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("mainvolume"))
        {
            globalvariables.mainsoundvolume = PlayerPrefs.GetFloat("mainvolume");
            mainvolume.value = globalvariables.mainsoundvolume;
        }
        else
        {
            PlayerPrefs.SetFloat("mainvolume", globalvariables.mainsoundvolume);
        }
        PlayerPrefs.Save();
    }
    // Start is called before the first frame update
    public void changevalve() 
    {
        globalvariables.mainsoundvolume = mainvolume.value;
        PlayerPrefs.SetFloat("mainvolume", globalvariables.mainsoundvolume);

    }
    private void Start()
    {
        onesound.playsound(transform.position, testclip, 1);
    }
}
