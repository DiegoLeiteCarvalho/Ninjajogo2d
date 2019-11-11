using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaRings : MonoBehaviour
{
    public GameObject rotaRings;
    public GameObject doorNextLevel;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Player"))
        {
            var diamont = GameObject.Find("diamondRed");
            Destroy(diamont);
            rotaRings.SetActive(true);
            doorNextLevel.GetComponent<BoxCollider2D>().offset = new Vector2(0,0);
        }
    }
}
