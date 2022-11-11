using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 5f;
    public PlayerInput pinput;
    public InputAction move;
    public Transform orient;
    public float maxturnspeed;
    public float defaultdrag = 1f;
    public bool isonstickysurface;
    public PhysicMaterial stickymaterial;
    public List<string> matlist;
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
    private void OnCollisionExit(Collision collision)
    {
        collioncheck(collision);
    }
    private void OnCollisionEnter(Collision collision)
    {
        collioncheck(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        collioncheck(collision);
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
        rb.AddTorque((this.orient.right * dir.y + this.orient.forward* -dir.x)*force* Time.deltaTime);
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