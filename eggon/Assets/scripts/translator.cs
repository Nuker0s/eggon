using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translator : MonoBehaviour
{
    public Vector3 rotationspeed;
    public Transform[] points;
    public int currentpoint=0;
    public bool comeback;
    public int dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (dir==0)
        {
            dir = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Length>1)
        {
            if (points[currentpoint].position==transform.position)
            {
                
                if (points.Length <= currentpoint+dir || currentpoint+dir < 0)
                {
                    if (comeback)
                    {
                        dir *= -1;
                        currentpoint += dir;
                    }
                    else 
                    {
                        currentpoint = 0;
                    }
                    
                }
                else
                {
                    currentpoint += dir;
                }
            }
            else
            {
                MoveTowards(points[currentpoint], speed);
            }
        }
        transform.Rotate(rotationspeed * Time.deltaTime);

    }
    public void MoveTowards(Transform target,float speed)
    {
        if (Vector3.Distance(transform.position,target.position) >speed*Time.deltaTime)
        {
            transform.position += (target.position - transform.position).normalized * speed*Time.deltaTime;
        }
        else
        {
            transform.position = target.position;
        }
    }
}
