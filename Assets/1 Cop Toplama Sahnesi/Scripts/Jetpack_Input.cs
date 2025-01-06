using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack_Input : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upSpeed = 2000f;
    private AudioSource audioSource;
    public ParticleSystem jetpackEffect;
    private bool isPlaying = false;

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
            ActivateJetpack();
        }
        else
        {
            DeactivateJetpack();
        }
#endif

        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);
            if (dokunma.phase == TouchPhase.Stationary || dokunma.phase == TouchPhase.Moved)
            {
                ActivateJetpack();
            }
        }
        else
        {
            DeactivateJetpack();
        }
    }

    void ActivateJetpack()
    {
        if (rb != null)
        {
            rb.AddForce(new Vector2(0, upSpeed * Time.deltaTime));
        }

        if (!isPlaying)
        {
            isPlaying = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            if (!jetpackEffect.isPlaying)
            {
                jetpackEffect.Play();
            }
        }
    }

    void DeactivateJetpack()
    {
        if (isPlaying)
        {
            isPlaying = false;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            if (jetpackEffect.isPlaying)
            {
                jetpackEffect.Stop();
            }
        }
    }
}
