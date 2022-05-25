using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elmas : MonoBehaviour
{
  
    
    void Update()
    {
        transform.Rotate(Vector3.down * 90 * Time.deltaTime);
    }
}
