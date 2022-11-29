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
    public float pushforce;
    public LayerMask playermask;
    public LayerMask ground;
    public Vector3 playerslowestpoint;
    public Vector3 groundcheckhitbox;
    public Vector3 jajoextents;
    public MeshCollider meszkolider;
    public Vector2 sizecol;
    public Vector3 jajocenter;

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
        makegroundchekvars();        
        groundcheck();
        Vector2 dir = move.ReadValue<Vector2>();
        if (jump.WasPressedThisFrame() & grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
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
        //collioncheck(collision);
        //grounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //grounded = true;
        //collioncheck(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        //collioncheck(collision);
        //grounded = true;
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
            //rb.AddForce((orient.right * dir.x + orient.forward * dir.y) * pushforce * Time.deltaTime);
        }
        else 
        {
            rb.AddForce((orient.right * dir.x + orient.forward * dir.y) * skyforce * Time.deltaTime);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(playerslowestpoint, 0.2f);
        Gizmos.color = Color.red - new Color(0,0,0,0.5f);
        Gizmos.DrawRay(transform.position - new Vector3(0, 2, 0), Vector3.up);
        Gizmos.DrawCube(jajocenter,jajoextents);
    }
    public void groundcheck() 
    {
        
        Collider[] cols = Physics.OverlapBox(jajocenter,jajoextents/2,new Quaternion(0,0,0,0),ground);
        if (cols.Length > 0)
        {
            grounded = true;
            rb.drag = defaultdrag;
            transform.SetParent(null);
        }
        else 
        {

            rb.drag = 0;
            transform.SetParent(null);
            grounded = false;
        }
        foreach (Collider col in cols)
        {
            if (col.tag=="moving")
            {
                transform.SetParent(col.transform);
            }
        }
    }
    public void makegroundchekvars()
    {
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position - new Vector3(0,2,0), Vector3.up, out hit, 30, playermask))
        {
            playerslowestpoint = hit.point;
            //Debug.Log(hit.point);
        }
        jajoextents = (meszkolider.bounds.extents * sizecol.x);
        jajoextents.y = sizecol.y;
        jajocenter = meszkolider.bounds.center;
        jajocenter.y = playerslowestpoint.y;

    }
    public void speedcontroll()
    {
        /*Vector3 angvel = rb.velocity;
        if (angvel.magnitude > maxturnspeed)
        {
            rb.velocity = angvel.normalized * maxturnspeed;


            if (isonstickysurface)
            {
                if (rb.velocity.y<=0)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0.6f, rb.velocity.z);
                }
            }
        }*/
        Vector3 angvel = rb.angularVelocity;
        if (angvel.magnitude > maxturnspeed)
        {
            rb.angularVelocity = angvel.normalized * maxturnspeed;
        }
    }

        public void collioncheck(Collision collision)
        {
        Debug.Log(collision.collider.material);

        if (collision.collider.tag=="sticky")
        {
            
            isonstickysurface = true;
        }
        else isonstickysurface = false;
       
    }
    
}