using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int vida;
    public float forcaPulo;
    public float velocidadeMaxima;
    public int rings;

    public Text TextRings;
    private bool isGrounded;
    public bool canFly;
    private bool dead = false;

    public Sprite heart;
    public Sprite heartBroken;

    private  GameObject  heart1;
    private  GameObject  heart2;
    private  GameObject  heart3;

    private GameObject door1;
    private GameObject door2;
    private GameObject door3;
    private GameObject door4;

    // Start is called before the first frame update
    void Start()
    {
        vida = 6;
        TextRings.text = rings.ToString();
        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");

        door1 = GameObject.Find("Door1");
        door2 = GameObject.Find("Door2");
        door3 = GameObject.Find("Door3");
        door4 = GameObject.Find("Door4");
    }

    // Update is called once per frame
    void Update()
    {
        var movimento = Input.GetAxis("Horizontal");
        var rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(movimento*velocidadeMaxima, rigidbody.velocity.y);

        //girar
        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }else if(movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //pular
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                rigidbody.AddForce(new Vector2(0,forcaPulo));
                GetComponent<AudioSource>().Play();
                
            }else
            {
                canFly = true;
            }
        }

        if(canFly && Input.GetKey(KeyCode.Space))
        {
            // Debug.Log($"Colidiu canFly{canFly}");
            GetComponent<Animator>().SetBool("Flying", true);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -0.15f);
        }
        else
        {
            GetComponent<Animator>().SetBool("Flying", false);
        }

        if(isGrounded)
        {
            GetComponent<Animator>().SetBool("Jumping", false);
        }else
        {
            GetComponent<Animator>().SetBool("Jumping", true);
        }

        //andar
        if (movimento == 0)
        {
            GetComponent<Animator>().SetBool("walking", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", true);
        }

        //morrer
        if(dead)
        {
            GetComponent<Animator>().SetBool("Dead", true);
        }else
        {
            GetComponent<Animator>().SetBool("Dead", false);
        }
    }


    void OnCollisionExit2D(Collision2D collision2D)
    {
        //Debug.Log(collision2D.gameObject.tag);
        

        if(collision2D.gameObject.CompareTag("Plataforma"))
        {
            //Debug.Log("saiu da Plataforma");
            // isGrounded = true;
            // canFly = true;
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Plataforma"))
        {
            isGrounded = true;
            canFly = false;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Door"))
        {
            // Debug.Log("porta 2");
            door2.GetComponent<BoxCollider2D>().isTrigger = true;
            door1.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Ring"))
        {
            Destroy(collision2D.gameObject);
            rings++;
            TextRings.text = rings.ToString();
        }
        if(collision2D.gameObject.CompareTag("Monstro") || collision2D.gameObject.CompareTag("Armadilha"))
        {
            //Debug.Log("vida");
            vida--;
            RemoveLife(vida);
        }

        if(collision2D.gameObject.CompareTag("Door"))
        {
            if(collision2D.gameObject.name == door1.name)
            {
                transform.position = new Vector2(12.4f, -8.97f);
                door2.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else if(collision2D.gameObject.name == door2.name)
            {
                transform.position = new Vector2(67.57f, -8.3f);
                door1.GetComponent<BoxCollider2D>().isTrigger = false;
            }else if (collision2D.gameObject.name == door3.name)
            {
                transform.position = new Vector2(-14.69f, 29.02f);
                //door1.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }

    private void RemoveLife(int vidas)
    {
        //verificar quantas vidas tem para redesenhar imagens 
        switch (vidas)
        {
            case 5:
            //trocar terceiro coração por meio
            updateHeart(heart3, heartBroken);
            break;
            case 4:
            //apagar terceiro coração
            updateHeart(heart3);
            break;
            case 3:
            //trocar segundo coração por meio
            updateHeart(heart2, heartBroken);
            break;
            case 2:
            //apagar segundo coração
            updateHeart(heart2);
            break;
            case 1:
            //trocar primeiro coração por meio
            updateHeart(heart1, heartBroken);
            break;
            case 0:
            updateHeart(heart1);
            dead = true;
            break;
        }
    }

    void updateHeart(GameObject heartGameObject, Sprite heart)
    {
        Image theImage = heartGameObject.GetComponent<Image>();
        theImage.sprite = heart;
    }

    void updateHeart(GameObject heartGameObject)
    {
        heartGameObject.SetActive(false);
    }

}
