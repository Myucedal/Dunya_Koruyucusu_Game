using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack_Input : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upSpeed = 2000;
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (rb != null)
            {
                rb.AddForce(new Vector2(0, upSpeed * Time.deltaTime));

            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
#endif
        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);
            if (dokunma.phase == TouchPhase.Stationary || dokunma.phase == TouchPhase.Moved)
            {
                rb.AddForce(new Vector2(0, upSpeed * Time.deltaTime));

            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
