using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelKontrol : MonoBehaviour
{
    int levelSayisi, elmasHedef;
    public int elmasSayisi;
    public GameObject gecis1, gecis2, gecis3, gecis4, elmasPanel, duraklamaPanel, bitisPanel;
    public bool level1, level2, level3, level4;
    public Text elmasTxt;
    public Transform ch1, ch2, ch3, ch4;
    void Start()
    {
        Time.timeScale = 1;
        levelSayisi = 1;
        gecis1.SetActive(false);
        gecis2.SetActive(false);
        gecis3.SetActive(true);
        gecis4.SetActive(false);
        elmasPanel.SetActive(true);
        duraklamaPanel.SetActive(false);
        bitisPanel.SetActive(false);
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
    }

    
    void Update()
    {
        elmasTxt.text = elmasSayisi.ToString() + " / " + elmasHedef.ToString();
        if (levelSayisi == 1)
        {
            Level1();
        }
        else if (levelSayisi == 2)
        {
            Level2();
        }
        else if (levelSayisi == 3)
        {
            Level3();
        }
        else if (levelSayisi == 4)
        {
            Level4();
        }
        else if (levelSayisi >= 5)
        {
            elmasPanel.SetActive(false);
        }

        if (transform.position.y <= -2)
        {
            if (level1)
            {
                transform.position = ch1.position;
            }
            else if (level2)
            {
                transform.position = ch2.position;
            }
            else if (level3)
            {
                transform.position = ch3.position;
            }
            else if (level4)
            {
                transform.position = ch4.position;
            }
        }
    }

    void LevelAtla()
    {
        elmasSayisi = 0;
        levelSayisi++;
    }

    void Level1()
    {
        elmasHedef = 5;
        if (elmasSayisi == elmasHedef)
        {
            gecis1.SetActive(true);
            LevelAtla();
        }
    }
    void Level2()
    {
        elmasHedef = 6;
        if (elmasSayisi == elmasHedef)
        {
            gecis2.SetActive(true);
            LevelAtla();
        }
    }

    void Level3()
    {
        elmasHedef = 7;
        if (elmasSayisi == elmasHedef)
        {
            gecis3.SetActive(false);
            LevelAtla();
        }
    }
    void Level4()
    {
        elmasHedef = 8;
        if (elmasSayisi == elmasHedef)
        {
            gecis4.SetActive(true);
            LevelAtla();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Level1")
        {
            level1 = true;
        }
        if (collision.transform.tag == "Level2")
        {
            level1 = false;
            level2 = true;
        }
        if (collision.transform.tag == "Level3")
        {
            level1 = false;
            level2 = false;
            level3 = true;
        }
        if (collision.transform.tag == "Level4")
        {
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = true;
        }
    }

    public void Duraklat()
    {
        Time.timeScale = 0;
        duraklamaPanel.SetActive(true);
    }
    public void DevamEt()
    {
        Time.timeScale = 1;
        duraklamaPanel.SetActive(false);
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
