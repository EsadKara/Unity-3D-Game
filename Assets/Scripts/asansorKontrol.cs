using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asansorKontrol : MonoBehaviour
{
    Animator anim;
    AudioSource ses;

    void Start()
    {
        anim = GetComponent<Animator>();
        ses = GetComponent<AudioSource>();
        anim.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            anim.enabled = true;
            ses.Play();
            Invoke("Duzelt", 6.7f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            ses.loop = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            anim.enabled = false;
        }
    }
    void Duzelt()
    {
        ses.enabled = false;
    }

}
