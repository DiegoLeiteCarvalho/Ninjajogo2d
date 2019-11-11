using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject painelCompleto;
    public Button btnPause;
    public Sprite PAUSE;
    public Sprite PLAY;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        if(isPaused == false)
        {
            painelCompleto.SetActive(true);

            Image theImage = btnPause.GetComponent<Image>();
            theImage.sprite = PLAY;
            isPaused = true;
        }else
        {
            Resume();
        }
    }

    public void Resume()
    {
        painelCompleto.SetActive(false);
        Image theImage = GameObject.Find("BtnPause").GetComponent<Image>();
        theImage.sprite = PAUSE;
        isPaused = false;
    }
}
