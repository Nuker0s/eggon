using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class cam3d : MonoBehaviour
{
    public Transform target;
    public Transform horizontaldrive;
    public Transform verticaldrive;
    //public Transform caster;
    public PlayerInput pinput;
    public InputAction look;
    public InputAction esc;
    public float sense;
    public Vector2 minmaxXangle;
    public float cameradistance;
    public LayerMask WhatisGround;
    public Vector3 camerapos;
    public LayerMask layer;
    public Image cel;
    public float grapdist;
    public Color defaultcolor = Color.white;
    public Color nienienie = Color.black;
    private Mouse ms;
    public static bool pause=false;
    public GameObject menu;
    private void Awake()
    {
        //cameradistance = transform.localPosition.z;
        look = pinput.actions.FindAction("Look");
        ms = InputSystem.GetDevice<Mouse>();
        esc = pinput.actions.FindAction("Esc");
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(caster.position, -caster.forward);
    }
    // Update is called once per frame
    void Update()
    {
        if (esc.WasPressedThisFrame())
        {
            if (pause)
            {
                menu.SetActive(false);
                pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;

            }
            else 
            {
                menu.SetActive(true);
                pause = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
        horizontaldrive.position = target.position;
        /*RaycastHit wallcheck;
        Physics.Raycast(caster.position, -caster.forward,out wallcheck, cameradistance, WhatisGround);
        if (wallcheck.point!=null)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.x, wallcheck.distance);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.x, cameradistance);
        }*/
        if (!pause)
        {
            Vector2 camrot = ms.delta.ReadValue();
            horizontaldrive.Rotate(0, camrot.x * sense, 0);
            //Debug.Log(camrot.x * sense);
            float xrot = verticaldrive.eulerAngles.x + camrot.y * -sense;

            if (xrot < 200)
            {
                xrot = Mathf.Min(xrot, minmaxXangle.x);
            }
            else
            {
                xrot = Mathf.Max(xrot, minmaxXangle.y);
            }
            verticaldrive.eulerAngles = new Vector3(xrot, verticaldrive.eulerAngles.y, verticaldrive.eulerAngles.z);
            if (Physics.Raycast(transform.position, transform.forward, grapdist, layer))
            {
                cel.color = defaultcolor;
            }
            else cel.color = nienienie;
        }

        
    }
}
