using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translator : MonoBehaviour
{
    public Vector3 rotationspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationspeed * Time.deltaTime);

    }
}
