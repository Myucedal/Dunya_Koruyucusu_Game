using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    
    private void Start()
    {
        gameObject.AddComponent<ParticleSystem>();
    }
    void OnTriggerStay2D()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            Debug.Log("E çalýþtý");
        }
    }
}
