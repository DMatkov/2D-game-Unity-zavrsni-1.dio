using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float brzinaLika = 2.2f;
    private bool gledaDesno = true;
    public int jacinaSkoka = 180;
    public float hodajX;
    private bool naPodu = true;
    private bool mozeSkocitPonovo = true;
    private float pocetnaX = -1.538f;
    private float pocetnaY = -0.54f;

    public bool odskok;
    public float jacinaOdskoka;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KretanjeLika();
        //smrt padom
        if (gameObject.GetComponent<Rigidbody2D>().position.y < -2.0143f)
        {
            Smrt();
        }
    }

    void KretanjeLika()
    {
        
        hodajX = Input.GetAxis("Horizontal");

        //okretanje
        if(hodajX < 0 && gledaDesno)
        {
            gledaDesno = false;
            Orjentacija();
            //Vector2 pozicija = gameObject.transform.position;
            //pozicija.x += 0.4f;
            //transform.position = pozicija;
        }
        else if(hodajX > 0 && !gledaDesno)
        {
            gledaDesno = true;
            Orjentacija();
            //Vector2 pozicija = gameObject.transform.position;
            //pozicija.x -= 0.4f;
            //transform.position = pozicija;
        }
        
        //animacija
        if (hodajX != 0.0f)
        {
            GetComponent<Animator>().SetBool("Hoda", true);
            
        }
        else {
            GetComponent<Animator>().SetBool("Hoda", false);
        }


        //skakanje
        bool pressed = Input.GetButtonDown("Jump");
        naPodu = true;
        if (pressed) {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
            {
                naPodu = false;
            }
            if (naPodu)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                Skok();
                mozeSkocitPonovo = true;                                              
            } else {
                if (mozeSkocitPonovo)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                    Skok2();
                    mozeSkocitPonovo = false;
                }
            }
        }

        //hodanje
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(hodajX * brzinaLika, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //ogranicenja kretanja   
        Vector3 pozicija = gameObject.transform.position;
        pozicija.x = Mathf.Clamp(transform.position.x, -1.57f, 20);
        gameObject.transform.position = pozicija;

        
        //odskok od neprijatelja
        if(odskok)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jacinaOdskoka);
            odskok = false;
        }
    }

    //facing lika
    void Orjentacija()
    {
         Vector2 localScale = gameObject.transform.localScale;
         localScale.x  *= -1;
         transform.localScale = localScale;
                   
    }

    void Skok()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jacinaSkoka));
    }

    void Skok2()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jacinaSkoka-50));
    }


    void Smrt()
    {
        gameObject.GetComponent<Rigidbody2D>().position = new Vector2(pocetnaX, pocetnaY);
    }
}
