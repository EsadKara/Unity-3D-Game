using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunuBitir : MonoBehaviour
{
    public GameObject bitisPanel;
    void Start()
    {
        bitisPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            bitisPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
