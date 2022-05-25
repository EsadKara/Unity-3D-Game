using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basamakKontrol : MonoBehaviour
{
    Animator anim;
    bool trigger;
    AudioSource ses;
    void Start()
    {
        anim = GetComponent<Animator>();
        ses = GetComponent<AudioSource>();
        trigger = false;
        anim.SetBool("Trigger", trigger);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            trigger = true;
            anim.SetBool("Trigger", trigger);
            ses.Play();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            trigger = false;
            anim.SetBool("Trigger", trigger);
            ses.Play();
        }
    }
}
