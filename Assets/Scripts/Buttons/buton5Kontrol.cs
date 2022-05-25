using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton5Kontrol : MonoBehaviour
{
    public GameObject[] gecisler;
    public AudioSource buttonSes, basamakSes;
    public int butonaBasmaSayisi = 0;
    public GameObject karakter;
    void Start()
    {
        for(int i = 0; i < gecisler.Length; i++)
        {
            gecisler[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (karakter.transform.position.y <= -2)
        {
            for (int i = 0; i < gecisler.Length; i++)
            {
                gecisler[i].SetActive(false);
            }
            butonaBasmaSayisi = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            butonaBasmaSayisi++;
            if (butonaBasmaSayisi == 1)
            {
                buttonSes.Play();
                StartCoroutine(GecisAc());
            }
        }
    }

    IEnumerator GecisAc()
    {
        for(int i = 0; i < gecisler.Length; i++)
        {
            yield return new WaitForSeconds(1.0f);
            gecisler[i].SetActive(true);
            basamakSes.Play();
        }
    }
}
