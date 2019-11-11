using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private bool collider = false;
    private float move = -2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(move, rigidbody.velocity.y);
        // Debug.Log($"Colidiu velocidade{rigidbody.velocity}");
        if(collider)
        {
            flip();
        }
    }

    private void flip()
    {
        move *= -1;
        collider = false;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Plataforma"))
        {
            collider = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Plataforma"))
        {
            collider = false;
        }
    }
}
