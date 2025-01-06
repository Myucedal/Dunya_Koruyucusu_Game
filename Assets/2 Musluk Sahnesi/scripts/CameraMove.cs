using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character; // Karakterin Transform'u
    public float moveDuration = 4f; // Kameranýn aþaðýya kayma süresi
    public float yOffset = 2f; // Kamera ile karakter arasýndaki dikey mesafe (opsiyonel)

    private bool isFollowing = false; // Kamera takip modunda mý?
    private Vector3 initialPosition; // Kameranýn baþlangýçtaki pozisyonu
    private Vector3 targetPosition; // Kameranýn hedef pozisyonu
    private float elapsedTime = 0f; // Geçen süreyi takip etmek için

    void Start()
    {
        // Kameranýn baþlangýç pozisyonunu al
        initialPosition = transform.position;

        // Hedef pozisyon karakterin bulunduðu yer
        targetPosition.x = transform.position.x;
        targetPosition.y = character.position.y  + 6;
        targetPosition.z = transform.position.z;

        // Takip modu baþlangýçta kapalý
        isFollowing = false;
    }

    void Update()
    {
        // Eðer kamera henüz takip modunda deðilse
        if (!isFollowing)
        {
            // Kaydýrma iþlemini gerçekleþtir
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration); // Lerp için oran

            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            // Kamera hedef pozisyona ulaþtýðýnda takip moduna geç
            if (t >= 1f)
            {
                isFollowing = true;
            }
        }
        else
        {
            // Kamera y ekseninde karakteri takip eder
            transform.position = new Vector3(initialPosition.x, character.position.y + 6, initialPosition.z);
        }
    }
}
