using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public ParticleSystem leftJetPackEffect, rightJetPackEffect;
    public float forceAmount = 10f;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private bool isLeftJetpackActive = false;
    private bool isRightJetpackActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        HandleJetpack();
    }
    public void ActivateLeftJetpack()
    {
        isLeftJetpackActive = true;
    }
    public void DeactivateLeftJetpack()
    {
        isLeftJetpackActive = false;
    }
    public void ActivateRightJetpack()
    {
        isRightJetpackActive = true;
    }
    public void DeactivateRightJetpack()
    {
        isRightJetpackActive = false;
    }
    private void HandleJetpack()
    {
        Vector3 force = Vector3.zero;

        if (isLeftJetpackActive)
        {
            PlayJetpackEffects(leftJetPackEffect);
            force += new Vector3(1, 1, 0); 
        }
        else
        {
            StopJetpackEffects(leftJetPackEffect);
        }

        if (isRightJetpackActive)
        {
            PlayJetpackEffects(rightJetPackEffect);
            force += new Vector3(-1, 1, 0); 
        }
        else
        {
            StopJetpackEffects(rightJetPackEffect);
        }

        if (force != Vector3.zero)
        {
            rb.AddForce(force.normalized * forceAmount, ForceMode2D.Force);
        }

        if (isLeftJetpackActive || isRightJetpackActive)
        {
            PlayJetpackAudio();
        }
        else
        {
            StopJetpackAudio();
        }
    }
    private void PlayJetpackEffects(ParticleSystem effect)
    {
        if (!effect.isPlaying)
        {
            effect.Play();
        }
    }
    private void StopJetpackEffects(ParticleSystem effect)
    {
        if (effect.isPlaying)
        {
            effect.Stop();
        }
    }
    private void PlayJetpackAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    private void StopJetpackAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
