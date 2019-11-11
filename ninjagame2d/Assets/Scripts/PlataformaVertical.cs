using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public float LimitTop;
    public float LimitBottom;

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
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, move);
        verifyCollider();
        
        if(collider)
        {
            //Debug.Log($"Colidiu antes{move}");
            flip();

            
        }
    }
    private void verifyCollider()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        var position = rigidbody.position;
        
        // if(position.y <= LimitTop && collider == false || position.y >= LimitBottom)
        // {
        //     collider = true;
        // }
        // else
        // {
        //     collider = false;
        // }
        if(position.y <= LimitBottom && collider == false ||  position.y >= LimitTop)
        {
            
            collider = true;
        }
        else
        {
            
            collider = false;
        }
    }

    private void flip()
    {
        collider = false;
        var rigidbody = GetComponent<Rigidbody2D>();

        if(move < 0)
        {
            Debug.Log($"true depois{move}");
            rigidbody.position = new Vector3(rigidbody.position.x, LimitBottom + 0.12f, 0.0f);
        }else
        {
            Debug.Log($"false depois{move}");
            rigidbody.position = new Vector3(rigidbody.position.x, LimitTop - 0.12f, 0.0f);
        }
       
        move = move * -1;
    }
}
