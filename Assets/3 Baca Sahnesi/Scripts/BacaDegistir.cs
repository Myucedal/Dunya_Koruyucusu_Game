using UnityEngine;
using UnityEngine.UI;

public class BacaDegistir : MonoBehaviour
{
    public ParticleSystem fixParticleEffect;
    public AudioSource fixingSound;
    float fillDuration = 1.5f;
    float fillTimer = 0f;
    bool isTouchingBaca = false;
    Image fillImage;
    ParticleSystem bacaDumaniParticle;

    void Start()
    {
        fillImage = null;
        bacaDumaniParticle = null;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "baca")
        {
            // 1. child = dolma barý | 2. child = duman particle
            Transform firstChild = other.transform.GetChild(0).GetChild(0);
            Transform secondChild = other.transform.GetChild(1);

            fillImage = firstChild.GetComponent<Image>();
            fillImage.fillAmount = 0f;
 
            bacaDumaniParticle = secondChild.GetComponent<ParticleSystem>();
            if (!bacaDumaniParticle.isPlaying)
            {
                return; 
            }

            isTouchingBaca = true;
            fillTimer = 0f;
        }
        else if(other.gameObject.tag == "engel")
        {
            GameManager3.instance.KillPlayer();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (isTouchingBaca && other.gameObject.tag == "baca")
        {
            fillTimer += Time.deltaTime;
            fillImage.fillAmount = Mathf.Clamp01(fillTimer / fillDuration); 
                                                                         
            if (fillTimer >= fillDuration)
            {
                fixingSound.Play();
                fillImage.gameObject.SetActive(false);
                Instantiate(fixParticleEffect, transform.position, Quaternion.identity);
                bacaDumaniParticle.Stop();
                GameManager3.instance.UpdateScore();
                isTouchingBaca = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (isTouchingBaca && other.gameObject.tag == "baca")
        {
            fillImage.fillAmount = 0f;
            fillImage.gameObject.SetActive(true);
            isTouchingBaca = false;
        }
    }
}
