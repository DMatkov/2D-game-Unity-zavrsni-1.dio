using UnityEngine;
using System.Collections;



public class Sismis : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Vector2 moveAmount;
    private float moveDirection = 1.0f;


    void FixedUpdate()
    {
        moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount); //Move the enemy
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag != "Igrac")

{
            Flip();
        }



        if (other.gameObject.tag == "ground")
{
            Flip();
        }

    }

    public void Flip()
    {
        moveDirection *= -1;



        // Flip the sprite by multiplying the x component of localScale by -1.

        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}