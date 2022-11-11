using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public bool drawbounds;
    public float opacity;
    public Vector3 position = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        if (drawbounds)
        {
            Gizmos.color = Color.green + new Color(0, 0, 0, -0.5f);
            Gizmos.DrawCube(transform.position, transform.localScale);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + position, 0.3f);
        }
    }
}
