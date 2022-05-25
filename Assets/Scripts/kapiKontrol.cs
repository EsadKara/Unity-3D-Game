using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapiKontrol : MonoBehaviour
{

    Animator anim;
    public AudioSource doorSes;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            KapiTrigger("Enter");
            doorSes.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            KapiTrigger("Exit");
            doorSes.Play();
        }
    }

    void KapiTrigger(string kontrol)
    {
        anim.SetTrigger(kontrol);
    }
}
