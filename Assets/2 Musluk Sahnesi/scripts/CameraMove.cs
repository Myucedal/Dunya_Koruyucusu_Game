using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character; // Karakterin Transform'u
    public float moveDuration = 4f; // Kameran�n a�a��ya kayma s�resi
    public float yOffset = 2f; // Kamera ile karakter aras�ndaki dikey mesafe (opsiyonel)

    private bool isFollowing = false; // Kamera takip modunda m�?
    private Vector3 initialPosition; // Kameran�n ba�lang��taki pozisyonu
    private Vector3 targetPosition; // Kameran�n hedef pozisyonu
    private float elapsedTime = 0f; // Ge�en s�reyi takip etmek i�in

    void Start()
    {
        // Kameran�n ba�lang�� pozisyonunu al
        initialPosition = transform.position;

        // Hedef pozisyon karakterin bulundu�u yer
        targetPosition.x = transform.position.x;
        targetPosition.y = character.position.y  + 6;
        targetPosition.z = transform.position.z;

        // Takip modu ba�lang��ta kapal�
        isFollowing = false;
    }

    void Update()
    {
        // E�er kamera hen�z takip modunda de�ilse
        if (!isFollowing)
        {
            // Kayd�rma i�lemini ger�ekle�tir
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration); // Lerp i�in oran

            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            // Kamera hedef pozisyona ula�t���nda takip moduna ge�
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
