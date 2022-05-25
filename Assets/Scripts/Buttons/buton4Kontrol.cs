using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton4Kontrol : MonoBehaviour
{
    int butonBasmaSayisi = 0;
    public Animator kapiAnim;
    public AudioSource buttonSes, doorSes;
    void Start()
    {
        kapiAnim.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            buttonSes.Play();
            kapiAnim.enabled = true;
            butonBasmaSayisi++;
            ButonaBas(butonBasmaSayisi);
        }
    }
    void ButonaBas(int sayi)
    {
        if(sayi == 1)
        {
            doorSes.Play();
        }
    }
}
