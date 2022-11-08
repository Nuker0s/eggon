using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public PlayerInput pinput;
    public InputAction move;
    public Transform orient;
    public float maxturn;
    private void Awake()
    {
        move = pinput.actions.FindAction("move");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Movement();
        speedcontroll();
    }
    
    public void Movement()
    {
        Vector2 dir = move.ReadValue<Vector2>();
        rb.AddTorque((this.orient.right * dir.y + this.orient.forward* -dir.x)*speed* Time.deltaTime);
    }
    public void speedcontroll()
    {
        Vector3 angvel = rb.angularVelocity;
        if (angvel.magnitude>maxturn)
        {
            rb.angularVelocity = angvel.normalized * maxturn;
        }
    }
}