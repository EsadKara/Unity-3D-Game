using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterKontrol : MonoBehaviour
{
    float xHareket, zHareket, xMouse, yMouse, maxMin;
    Vector3 hareketVektoru;
    public bool forward, back, right, left;
    bool fpsAcikmi;
    public float hiz, ziplamaHizi, hassasiyet, minDeger, maxDeger;
    public yerdeMi yerde_Mi;
    public Camera cam;
    public GameObject cam1, cam2, cH, bitis;
    Animator anim;
    public Animator kapi1Anim, kapi2Anim;
    Rigidbody fizik;
    levelKontrol levelKont;
    public AudioSource elmasSes, buttonSes, doorSes;
    int button1BasmaSayisi = 0;
    bool cursorLock;



    void Start()
    {
        cursorLock = true;
        anim = GetComponent<Animator>();
        fizik = GetComponent<Rigidbody>();
        levelKont = GetComponent<levelKontrol>();
        fpsAcikmi = false;
    }

   
    void Update()
    {
      
        hiz = 1.8f;
        Animasyonlar();
        CamBakisi();
        
        xHareket = Input.GetAxis("Horizontal");
        zHareket = Input.GetAxis("Vertical");
       

        if (zHareket > 0.5f || zHareket < -0.5f) 
        {
            xHareket = 0;
        }
        else if (xHareket > 0.5f || xHareket < -0.5f)
        {
            zHareket = 0;
        }
        Vector3 xVektoru = transform.right * xHareket;
        Vector3 zVektoru = transform.forward * zHareket;

        hareketVektoru = (xVektoru + zVektoru) * hiz;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (yerde_Mi.yerdemi)
            {
                fizik.AddForce(Vector3.up * ziplamaHizi);     
            }
        }
        if (fpsAcikmi)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        else
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            fpsAcikmi = !fpsAcikmi;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = !cursorLock;
        }
        if (cursorLock)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void FixedUpdate()
    {
        transform.position += hareketVektoru * Time.deltaTime;
    }

    void Animasyonlar()
    {
        forward = false; back = false; right = false; left = false;
        anim.SetBool("forward", forward);
        anim.SetBool("left", left);
        anim.SetBool("right", right);
        anim.SetBool("back", back);

        if (Input.GetKey(KeyCode.W))
        {
            hiz = 2.5f;
            forward = true;
            anim.SetBool("forward", forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            back = true;
            anim.SetBool("back", back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                forward = true;
                anim.SetBool("forward", forward);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                back = true;
                anim.SetBool("back", back);
            }
            else
            {
                left = true;
                anim.SetBool("left", left);
            }
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                forward = true;
                anim.SetBool("forward", forward);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                back = true;
                anim.SetBool("back", back);
            }
            else
            {
                right = true;
                anim.SetBool("right", right);
            }
           
        }
 
    }

    void CamBakisi()
    {
        xMouse = Input.GetAxis("Mouse X") * hassasiyet;
        yMouse = Input.GetAxis("Mouse Y") * hassasiyet;
        transform.Rotate(new Vector3(0, xMouse, 0));
        if (fpsAcikmi)
        {
            cam2.transform.Rotate(new Vector3(yMouse * (-1), 0, 0)); 
            maxMin -= yMouse;
            maxMin = Mathf.Clamp(maxMin, minDeger, maxDeger);
            cam2.transform.localEulerAngles = new Vector3(maxMin, 0, 0);
        }

    }

    void ElmasTopla()
    {
        levelKont.elmasSayisi++;
        elmasSes.Play();
    }
    void ButonaBas(int sayi)
    {
        if (sayi == 1)
        {
            doorSes.Play();
        }
    }

    private void OnTriggerEnter(Collider nesne)
    {
        if (nesne.transform.tag == "Elmas")
        {
            Destroy(nesne.gameObject);
            ElmasTopla();
        }
        if (nesne.transform.tag == "Button1")
        {
            kapi1Anim.enabled = true;
            kapi2Anim.enabled = true;
            buttonSes.Play();
            button1BasmaSayisi++;
            ButonaBas(button1BasmaSayisi);
        }
        if (nesne.transform.tag == "Tuzak")
        {
            transform.position = cH.transform.position;
        }
    }
}


