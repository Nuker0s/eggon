using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 5f;
    public float skyforce = 5f;
    public PlayerInput pinput;
    public InputAction move;
    public InputAction jump;
    public Transform orient;
    public float maxturnspeed;
    public float defaultdrag = 1f;
    public bool isonstickysurface;
    public PhysicMaterial stickymaterial;
    public List<string> matlist;
    public bool grounded;
    public float jumpforce;

    private void Awake()
    {
        move = pinput.actions.FindAction("move");
        jump = pinput.actions.FindAction("jump");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = move.ReadValue<Vector2>();
        if (jump.WasPressedThisFrame() & grounded)
        {
            rb.AddForce(0, jumpforce, 0);
            //rb.AddForce(new Vector3(0,jumpforce,0) + (orient.right * dir.x + orient.forward * dir.y) * skyforce);
        }
    }
    private void FixedUpdate()
    {
        Movement();
        speedcontroll();
    }
    private void OnCollisionExit(Collision collision)
    {
        collioncheck(collision);
        grounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
        collioncheck(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        collioncheck(collision);
        grounded = true;
        /*Debug.Log(collision.collider.tag);
        if (collision.collider.tag=="sticky")
        {
            isonstickysurface = true;
            Debug.Log(collision.collider.tag);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }*/

    }
    public void Movement()
    {
        Vector2 dir = move.ReadValue<Vector2>();
        if (grounded)
        {
            
            rb.AddTorque((orient.right * dir.y + orient.forward * -dir.x) * force * Time.deltaTime);
        }
        else 
        {
            rb.AddForce((orient.right * dir.x + orient.forward * dir.y) * skyforce * Time.deltaTime);
        }
        
    }
    public void speedcontroll()
    {
        Vector3 angvel = rb.angularVelocity;
        if (angvel.magnitude>maxturnspeed)
        {
            rb.angularVelocity = angvel.normalized * maxturnspeed;
        }
        /*if (isonstickysurface)
        {
            if (rb.velocity.y<=0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0.6f, rb.velocity.z);
            }
        }*/
    }
    public void collioncheck(Collision collision) 
    {
        if (collision.contactCount > 0)
        {
            rb.drag = defaultdrag;
        }
        else rb.drag = 0;
        /*Debug.Log(collision.collider.material);

        matlist.Clear();
        for (int i = 0; i < collision.contactCount; i++)
        {
            matlist.Add(collision.GetContact(i).thisCollider.material);
        }

        if (collision.collider.tag=="sticky")
        {
            
            isonstickysurface = true;
        }
        else isonstickysurface = false;
        */
    }
    
}