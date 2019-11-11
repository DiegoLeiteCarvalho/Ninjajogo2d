using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMonster : MonoBehaviour
{
    public float LimitFlipLeft;
    public float LimitFlipRigth;

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
        verifyCollider();
        
        if(collider)
        {
            flip();
        }
    }
    private void verifyCollider()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        var position = rigidbody.position;
        
        if(position.x <= LimitFlipLeft && collider == false || position.x >= LimitFlipRigth)
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
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        var rigidbody = GetComponent<Rigidbody2D>();

        if(move < 0)
        {
            rigidbody.position = new Vector3(LimitFlipLeft + 0.32f, rigidbody.position.y, 0.0f);
        }else
        {
            rigidbody.position = new Vector3(LimitFlipRigth - 0.32f, rigidbody.position.y, 0.0f);
        }
       
        move = move * -1;
    }

    
}
