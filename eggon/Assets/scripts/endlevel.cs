using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{
    public string scenetoload;
    // Start is called before the first frame update
    public static void sceneloadstring(string scene)
    {
        Time.timeScale = 1;
        cam3d.pause = false;
        SceneManager.LoadScene(scene);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            sceneloadstring(scenetoload);
        }
    }
}
