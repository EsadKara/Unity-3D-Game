using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerdeMi : MonoBehaviour
{
    public bool yerdemi;
    
    void Update()
    {
        yerdemi = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            if (hit.transform.gameObject.name!=null)
            {
                yerdemi = true;
            }
        }
    }
}
