using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton3Kontrol : MonoBehaviour
{
    public GameObject basamak1, basamak2;
    public AudioSource buttonSes;
    void Start()
    {
        basamak1.SetActive(false);
        basamak2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        buttonSes.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        basamak1.SetActive(true);
        basamak2.SetActive(true);
        
    }
    private void OnTriggerExit(Collider other)
    {
        basamak1.SetActive(false);
        basamak2.SetActive(false);
    }
}
