using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadlyobj : MonoBehaviour
{
    public playermanager pman;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            pman.death(collision.GetContact(0).point);
        }
    }
}
