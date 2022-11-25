using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelbutton : MonoBehaviour
{
    public scenevars scenetoload;
    // Start is called before the first frame update
    public void sceneload() 
    {
        SceneManager.LoadScene(scenetoload.scenename);
    }
}
