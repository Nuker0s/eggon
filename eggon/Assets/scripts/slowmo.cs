using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class slowmo : MonoBehaviour
{
    public float slowspeed;
    public PlayerInput pinput;
    public InputAction slow;

    private void Awake()
    {
        slow = pinput.actions.FindAction("slowmo");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cam3d.pause)
        {
            if (slow.IsPressed())
            {
                Time.timeScale = slowspeed;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
            else
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }

    }
}
