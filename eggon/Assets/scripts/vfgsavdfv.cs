using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfgsavdfv : MonoBehaviour
{
    public List<int> liczby= new List<int>();
    public bool przycisk;

    // Start is called before the first frame update

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        if (przycisk)
        {
            przycisk = false;
            liczby.Sort();
            Debug.Log(liczby);
            if (liczby[2] < liczby[1] + liczby[0]) Debug.Log("da sie");
            else Debug.Log("nie dasie");
            
        }
    }
}
