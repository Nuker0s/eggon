using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cam3d : MonoBehaviour
{
    public Transform target;
    public Transform horizontaldrive;
    public Transform verticaldrive;
    //public Transform caster;
    public PlayerInput pinput;
    public InputAction look;
    public float sense;
    public Vector2 minmaxXangle;
    public float cameradistance;
    public LayerMask WhatisGround;
    public Vector3 camerapos;

    private void Awake()
    {
        //cameradistance = transform.localPosition.z;
        look = pinput.actions.FindAction("Look");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(caster.position, -caster.forward);
    }
    // Update is called once per frame
    void Update()
    {
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
        Vector2 camrot = look.ReadValue<Vector2>();
        horizontaldrive.Rotate(0, camrot.x * sense, 0);
        //Debug.Log(camrot.x * sense);
        float xrot = verticaldrive.eulerAngles.x + camrot.y * -sense;

        if (xrot<200)
        {
            xrot = Mathf.Min(xrot, minmaxXangle.x);
        }
        else
        {
            xrot = Mathf.Max(xrot, minmaxXangle.y);
        }
        verticaldrive.eulerAngles = new Vector3(xrot, verticaldrive.eulerAngles.y, verticaldrive.eulerAngles.z);
    }
}