using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;


public class SmartEnemy : MonoBehaviour
{
    private float brzina = 80f;
    //private int smjer = 1;
    //private Vector2 kretanje;
    //private bool mrtav = false;
    private Transform target;   //igrac postavljamo kao metu
    private float udaljenostCijelogPuta = 0.5f; //testirat
    private bool mrtav = false;



    public float ChaseRange = 2.4f;

    
    Path path;
    int TrenutniPut = 0;
    bool dosaoDoKrajaPuta = false;

    Seeker seeker;
    Rigidbody2D rbody;
    

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Igrac").GetComponent<Transform>();

        InvokeRepeating("UpdatePut", 0f, 0.5f);
        
        
    }

    private void UpdatePut()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rbody.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            TrenutniPut = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path == null) {
            return;
        }

        if (TrenutniPut >= path.vectorPath.Count)
        {
            dosaoDoKrajaPuta = true;
            return;
        }
        else
        {
            dosaoDoKrajaPuta = false;
        }

        Vector2 smjer = ((Vector2)path.vectorPath[TrenutniPut] - rbody.position).normalized * 1.5f; //trazimo smjer do igraca
        Vector2 force = smjer * brzina * Time.deltaTime;

        rbody.AddForce(force);
        float distance = Vector2.Distance(rbody.position, path.vectorPath[TrenutniPut]);

        if (distance < udaljenostCijelogPuta)
        {
            TrenutniPut++;
        }

        
        if (rbody.velocity.x >= 0.01f)
        {
           // Vector3 localScale = gameObject.transform.localScale;
            transform.localScale = new Vector3(1f, 1f, 1f);
            //transform.localScale = localScale;
        }
        else if (rbody.velocity.x <= -0.01f)
        {
            //Vector3 localScale = gameObject.transform.localScale;
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //transform.localScale = localScale;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var igrac = other.GetComponent<Character>();
        //unisti protivnika
        if (other.gameObject.name == "Igrac" && igrac.velocity < 0)
        {

            Destroy(gameObject);
            mrtav = true;

            igrac.odskok = true;
        }
    }

    void OnCollisionEnter2D(Collision2D sismisC)
    {
        //enemy ubije igraca
        if (sismisC.gameObject.tag == "Igrac" && !mrtav)
        {
            StartCoroutine(Coroutine.Cekaj2());

        }
    }



}
