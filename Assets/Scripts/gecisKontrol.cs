using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gecisKontrol : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            Invoke("Kapat", 0.5f);
        }
    }

    void Kapat()
    {
        gameObject.SetActive(false);
    }
}
