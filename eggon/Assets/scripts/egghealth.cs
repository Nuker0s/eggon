using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class egghealth : MonoBehaviour
{
    public float hp = 100f;
    public float tollerance=7;
    public float dmgoffset=6;
    public float dmgpower=4.5f;
    public playermanager pman;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        float impulse = collision.impulse.magnitude;
        Debug.Log(impulse);
        if(impulse>tollerance)
        {
            float damage = Mathf.Pow((impulse - dmgoffset), dmgpower);
            if ((hp - damage) <= 0)
            {
                
                Debug.Log("death");
                pman.death(collision.GetContact(0).point);
            }
            else hp -= damage;
            
        }
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
