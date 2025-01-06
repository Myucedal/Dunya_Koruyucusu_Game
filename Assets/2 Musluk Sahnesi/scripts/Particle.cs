using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Particle : MonoBehaviour
{
    
    private void Start()
    {
        gameObject.AddComponent<ParticleSystem>();
    }
    void OnTriggerStay2D()
    {
        print("fonksiyon");
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E");
            gameObject.SetActive(false);
            GameManagerScript.instance.WaterControl();
        }
    }
    //private void OnTriggerStay2D()
    //{
        
    //}
}
