using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float time = 0.0f;
    public float timer;
    private bool fireMin = true;
    private BoxCollider2D boxCol;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= timer)
        {
            GetComponent<Animator>().SetBool("MaxFire", fireMin);
            time = 0.0f;
            fireMin = !fireMin;
        }

        if(fireMin)
        {
            boxCol = GetComponent<BoxCollider2D>();
            boxCol.offset = new Vector2(-0.046f, -2.397f);
            boxCol.size = new Vector2(0.439f,0.596f);
        }
        else
        {
            boxCol = GetComponent<BoxCollider2D>();
             boxCol.offset = new Vector2(-0.092f, -0.161f);
            boxCol.size = new Vector2(2.74f,5.43f);
        }
    }
}
