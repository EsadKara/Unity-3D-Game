using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton2Kontrol : MonoBehaviour
{
    public GameObject[] tuzaklar;
    public AudioSource buttonSes;
    public GameObject tuzakAcik, tuzakKapali;

    private void Start()
    {
        tuzakAcik.SetActive(false);
        tuzakKapali.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        buttonSes.Play();
        tuzakKapali.SetActive(true);
        tuzakAcik.SetActive(false);
        Invoke("Duzelt2", 1.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        tuzakAcik.SetActive(false);
        for(int i = 0; i < tuzaklar.Length; i++)
        {
            tuzaklar[i].SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tuzakAcik.SetActive(true);
        tuzakKapali.SetActive(false);
        Invoke("Duzelt", 1.5f);
        for (int i = 0; i < tuzaklar.Length; i++)
        {
            tuzaklar[i].SetActive(true);
        }
    }
    void Duzelt()
    {
        tuzakAcik.SetActive(false);
    }
    void Duzelt2()
    {
        tuzakKapali.SetActive(false);
    }
}
