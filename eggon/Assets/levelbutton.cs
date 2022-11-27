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
        Time.timeScale = 1;
        cam3d.pause = false;
        SceneManager.LoadScene(scenetoload.scenename);
        
    }
    public void resetlevel() 
    {
        Time.timeScale = 1;
        cam3d.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
