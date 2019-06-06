using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private float brzina = 0.8f;
    private int smjer = 1;
    private Vector2 kretanje;


    void FixedUpdate()
    {
        kretanje.x = smjer * brzina * Time.deltaTime;
        transform.Translate(kretanje); //Move the enemy
    }

    void OnCollisionEnter2D(Collision2D sismisC)
    {
        if (sismisC.gameObject.tag != "Igrac")
        {
            Orjentacija();
        }

        //enemy ubije igraca
        if (sismisC.gameObject.tag == "Igrac")
        {
            SceneManager.LoadScene("Prototype_1");
        }

        void Orjentacija()
        {
            smjer *= -1;

            //okretanje spritea
            Vector3 enemyScale = transform.localScale;
            enemyScale.x *= -1;
            transform.localScale = enemyScale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //unisti protivnika
        if (other.gameObject.name == "Igrac")
        {
            Destroy(gameObject);

            var igrac = other.GetComponent<PlayerController>();
            
        }
    }
}

