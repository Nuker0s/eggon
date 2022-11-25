using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{
    public Slider mainvolume;
    public AudioClip testclip;
    public static float sense;
    private void Awake()
    {
        
        globalvariables.mainsoundvolume = initorloadplayerprefsvalves("mainvolume", globalvariables.mainsoundvolume);
        PlayerPrefs.Save();
    }

    public void changevalve() 
    {
        globalvariables.mainsoundvolume = mainvolume.value;
        PlayerPrefs.SetFloat("mainvolume", globalvariables.mainsoundvolume);

    }
    // Start is called before the first frame update
    private void Start()
    {
        mainvolume.value = globalvariables.mainsoundvolume;
        onesound.playsound(transform.position, testclip, 1);
    }
    public static float initorloadplayerprefsvalves(string name,float value) 
    {
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetFloat(name);
            
        }
        else
        {
            PlayerPrefs.SetFloat(name, value);
            return value;
        }
    }
}
