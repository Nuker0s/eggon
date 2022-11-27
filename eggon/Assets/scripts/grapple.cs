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
    public Rigidbody connectedrb;
    public float maxdistancejoint;
    public float spring;
    public float dampter;
    public LineRenderer linerend;
    public AudioClip connectsound;
    public static GameObject grapplepoint;
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
            if (connectedrb!=null)
            {
                linerend.SetPosition(0, connectedrb.transform.position);
            }
            else
            {

                linerend.SetPosition(0, grapplepoint.transform.position);
                joint.connectedAnchor = grapplepoint.transform.position;
            }
            
            Debug.Log("grabb");
        }
        if (fire.WasPressedThisFrame() & !cam3d.pause)
        {
            if (!fired)
            {
                RaycastHit hit;
                
                Vector3 origin = cam.transform.position;
                Vector3 dir = cam.transform.forward;
                if (Physics.Raycast(origin,dir, out hit,maxraycastdistance, layers))
                {
                    Debug.Log("grabbbed");
                    onesound.playsound(hit.point, connectsound, globalvariables.sfxvolume);
                    hitpos = hit.point;
                    hookconnect(hitpos,hit.rigidbody,hit);
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
        if (joint!=null & connectedrb!=null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, joint.connectedAnchor+connectedrb.transform.position);
        }
    }

    public void hookconnect(Vector3 pos,Rigidbody rb,RaycastHit hit) 
    {
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = pos;
        joint.anchor= new Vector3(0,0,0);
        joint.maxDistance = Vector3.Distance(transform.position,pos);
        joint.spring = spring;
        joint.damper = dampter;
        if (rb!=null)
        {
            connectedrb = rb;
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedBody = rb;
            joint.connectedAnchor = pos-rb.transform.position;//new Vector3(0, 0, 0);
            joint.autoConfigureConnectedAnchor = false;
            
        }
        else
        {
            GameObject grap = new GameObject("grapplepoint");
            grap.transform.position = pos;
            grapplepoint = grap;
            grapplepoint.transform.SetParent(hit.transform);
        }
        //Debug.Log(Vector3.Distance(transform.position, pos));
        linerend.enabled = true;
        

    }
    public void hookdisconnect()
    {
        GameObject.Destroy(joint);
        GameObject.Destroy(grapplepoint);
        linerend.enabled = false;
    }
}
