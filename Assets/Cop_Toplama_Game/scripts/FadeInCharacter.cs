using System.Collections;
using UnityEngine;

public class FadeInCharacter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeIn(1.5f)); // 1.5 saniyede opakl��� artt�r
    }

    IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0;
        Color color = spriteRenderer.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, elapsedTime / duration); // 0'dan 1'e (opaktan �effafa)
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = 1;
        spriteRenderer.color = color;
    }
}
