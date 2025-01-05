using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
