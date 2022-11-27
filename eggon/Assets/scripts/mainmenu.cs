using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {

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
