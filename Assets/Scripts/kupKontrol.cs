using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kupKontrol : MonoBehaviour
{
    public GameObject[] kupler;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            for(int i = 0; i < kupler.Length; i++)
            {
                Destroy(kupler[i]);
            }
        }
    }
}
