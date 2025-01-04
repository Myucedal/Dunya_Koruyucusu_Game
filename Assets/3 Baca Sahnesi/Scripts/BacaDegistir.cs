using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacaDegistir : MonoBehaviour
{
    public bool incollision = true;
    bool timetree = false;
    public ParticleSystem particlefix;
    public ParticleSystem particleconfeti;
    private float timer = 3f;
    public static BacaDegistir instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("baca"))
        {
            incollision = true;
            Debug.Log("bacada");
            CharMove.instance.upSpeed = 0;
            CharMove.instance.horizontalSpeed = 0;
            particlefix.transform.position = collision.transform.position;
            particleconfeti.transform.position = collision.transform.position;
            CharMove.instance.rb.position = collision.transform.position;
            CharMove.instance.rb.velocity = Vector2.zero;
            particlefix.Play();
        }

        if (collision.CompareTag("engel"))
        {

          GameManager3.instance.DiePlayer();
        }
        else
        {
            incollision = true;
            CharMove.instance.upSpeed = 0;
            CharMove.instance.horizontalSpeed = 0;
            CharMove.instance.rb.position = collision.transform.position;
            CharMove.instance.rb.velocity = Vector2.zero;
        }

    }
  
    private void Update()
    {

        if (incollision)
        {
            timer += Time.deltaTime;
        }
        if (timer > 3 &&  incollision == true && timetree == false)
        {
            Debug.Log("timer 3 oldu");
            particlefix.Stop();
            particleconfeti.Play();
            timetree = true;
        }


        if (timer > 5f)
        {
            if (Input.GetMouseButton(1) && incollision == true)// Sol t�k
            {
                FirstJump();
                incollision = false;
            }
            if (Input.GetMouseButton(0) && incollision == true)
            {
                FirstJump();
                incollision = false;
            }
            particleconfeti.Stop();
        }
    }

    
    public void FirstJump()
    {
        Vector2 jumpforce = new Vector2 (5,15);
        CharMove.instance.rb.AddForce(jumpforce,ForceMode2D.Impulse);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("bacadan cikti");

        CharMove.instance.upSpeed = 0.08f;
        CharMove.instance.horizontalSpeed = 0.03f;
        incollision = false;
        timetree = false;
        timer = 0f;
       
    }

    
}