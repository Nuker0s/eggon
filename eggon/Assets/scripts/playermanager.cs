using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermanager : MonoBehaviour
{
    public GameObject eggprefab;
    public GameObject yolkprefab;
    public float explosionforce;
    public GameObject thatwhitestuffprefab;
    public Transform shellparent;
    public GameObject egg;
    public GameObject cam;
    public cam3d camscript;
    public PlayerInput pinput;
    public InputAction restart;
    public List<checkpoint> checkpoints;
    public checkpoint currentcheckpoint;
    public bool dead;
    public bool drawcheckpoints;
    public Color checkpointscolor;
    private void Awake()
    {
        currentcheckpoint = checkpoints[0];
        restart = pinput.actions.FindAction("restart");
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnplayer();
    }

    // Update is called once per frame
    void Update()
    {

        checkpointchecker();

        if (restart.WasPressedThisFrame())
        {
            if (!dead)
            {
                death(new Vector3(0,0,0));
                dead = true;
            }
            else
            {
                respawn();
                dead = false;
            }
        }


    }
    public void death(Vector3 deathpos)
    {
        Vector3 deathpoint = egg.transform.position;
        if (deathpos==new Vector3(0,0,0))
        {
            deathpoint = egg.transform.position;
        }
        shellparent.parent = null;
        shellparent.gameObject.SetActive(true);
        for (int i = 0; i < shellparent.childCount; i++)
        {
            Rigidbody rb = shellparent.GetChild(i).GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
        dead = true;
        camscript.target = Instantiate(yolkprefab, deathpos, new Quaternion(0, 0, 0, 0)).transform;
        Instantiate(thatwhitestuffprefab, deathpos, Quaternion.Euler(-90,0,0));
        Destroy(egg);
    }
    public void respawn()
    {

        spawnplayer();
        
    }
    public void spawnplayer() 
    {
        egg = Instantiate(eggprefab, currentcheckpoint.transform.position+currentcheckpoint.position, new Quaternion(0, 0, 0, 0));
        shellparent = egg.transform.GetChild(0);
        egg.GetComponent<playermovement>().orient = cam.transform;
        egg.GetComponent<egghealth>().pman = this;
        camscript.target = egg.transform;
    }
    public void checkpointchecker()
    {
        if (egg != null)
        {
            foreach (checkpoint cp in checkpoints)
            {
                if (new Bounds(cp.transform.position, cp.transform.localScale).Contains(egg.transform.position))
                {
                    currentcheckpoint = cp;
                }
            }
        }
    }
    public void OnDrawGizmos()
    {
        if (drawcheckpoints)
        {
            foreach (checkpoint cp in checkpoints)
            {
                Gizmos.color = checkpointscolor;
                Gizmos.DrawCube(cp.transform.position, cp.transform.localScale);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(cp.transform.position + cp.position, 0.3f);
            }
        }
    }
}
