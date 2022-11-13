using UnityEngine;
using UnityEngine.InputSystem;
public class grapple : MonoBehaviour
{
    public PlayerInput pinput;
    public InputAction fire;
    public Camera cam;
    public bool fired = false;
    public bool catched = false;
    public float maxraycastdistance;
    public LayerMask layers;
    public Vector3 hitpos;
    public SpringJoint joint;
    public float maxdistancejoint;
    public float spring;
    public float dampter;
    public LineRenderer linerend;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        fire = pinput.actions.FindAction("Fire");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (fired)
        {
            linerend.SetPosition(1, transform.position);
            linerend.SetPosition(0, joint.connectedAnchor);
            Debug.Log("grabb");
        }
        if (fire.WasPressedThisFrame())
        {
            if (!fired)
            {
                RaycastHit hit;
                
                Vector3 origin = cam.transform.position;
                Vector3 dir = cam.transform.forward;
                if (Physics.Raycast(origin,dir, out hit,maxraycastdistance, layers))
                {
                    Debug.Log("grabbbed");
                    hitpos = hit.point;
                    hookconnect(hitpos);
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
                hookdisconnect();
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

    public void hookconnect(Vector3 pos) 
    {
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = pos;
        joint.anchor= new Vector3(0,0,0);
        joint.maxDistance = Vector3.Distance(transform.position,pos);
        joint.spring = spring;
        joint.damper = dampter;
        Debug.Log(Vector3.Distance(transform.position, pos));
        linerend.enabled = true;
        

    }
    public void hookdisconnect()
    {
        GameObject.Destroy(joint);
        linerend.enabled = false;
    }
}
