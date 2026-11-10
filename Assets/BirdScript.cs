using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapstrength;  //для швидкості
    public LogicScript logic;
    public bool birdIsAlive = true;
    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
                    
        gameObject.name = "Vasya";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)==true && birdIsAlive==true)
        {
            myRigidbody.velocity = Vector2.up * flapstrength;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        audioManager.PlaySFX(audioManager.death);
    }
}
