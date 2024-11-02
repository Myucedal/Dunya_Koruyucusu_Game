using System.Collections;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public ParticleSystem particleSystem;

    void Start()
    {
        StartCoroutine(StartAndStopParticleSystem(1.2f)); // 2 saniyede duracak
    }

    IEnumerator StartAndStopParticleSystem(float duration)
    {
        particleSystem.Play();
        yield return new WaitForSeconds(duration);
        particleSystem.Stop();
    }
}
