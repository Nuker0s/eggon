using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class grapple : MonoBehaviour
{
    public PlayerInput pinput;
    public InputAction fire;
    public bool fired = false;
    public bool catched = false;
    public Vector3 hitpos;
    // Start is called before the first frame update
    void Start()
    {
        fire = pinput.actions.FindAction("Fire");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (fire.WasPressedThisFrame())
        {
            if (!fired)
            {
                if (Random.Range(0, 10) >= 5)
                {
                    Debug.Log("grabbbed");
                    fired = true;
                }
                else
                {
                    Debug.Log("did'thit");
                }
            }
            else
            {
                Debug.Log("break");
                fired = false;
                hitpos = new Vector3(0,0,0);
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        if (hitpos!= new Vector3(0, 0, 0))
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(hitpos, 0.3f);
        }
    }
}
