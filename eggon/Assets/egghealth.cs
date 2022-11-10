using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class egghealth : MonoBehaviour
{
    public GameObject eggprefab;
    public GameObject yolkprefab;
    public GameObject thatwhitestuffprefab;
    public GameObject shellparentobj;
    public Transform shellparent;
    public PlayerInput pinput;
    public InputAction restart;
    public cam3d cam;
    public Vector3 checkpoint;
    public bool dead = false;
    // Start is called before the first frame update
    private void Awake()
    {
        shellparent.gameObject.SetActive(false);
        dead = false;
        restart = pinput.actions.FindAction("restart");
    }
    void Start()
    {
        
    }

    public void death()
    {
        shellparentobj.SetActive(true);
        for (int i = 0; i < shellparent.childCount; i++)
        {
            Rigidbody rb = shellparent.GetChild(i).GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
        dead = true;
        shellparent.parent = null;
        cam.target = Instantiate(yolkprefab, transform.position, new Quaternion(0, 0, 0, 0)).transform;
        Instantiate(thatwhitestuffprefab, transform.position, new Quaternion(0, 0, 0, 0));
    }
    public void respawn() 
    {
        cam.target = Instantiate(eggprefab, checkpoint, new Quaternion(0, 0, 0, 0)).transform;
        cam.pinput = cam.target.gameObject.GetComponent<PlayerInput>();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (restart.WasPressedThisFrame() & dead)
        {
            respawn();
        }
        if (restart.WasPressedThisFrame() & !dead)
        {
            death();
        }

    }
}
