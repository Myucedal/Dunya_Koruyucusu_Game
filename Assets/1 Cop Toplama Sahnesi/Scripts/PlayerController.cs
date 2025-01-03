using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; // Karakterin Animator bile�eni
    private bool isGrounded = false; // Karakterin yerde olup olmad���n� tutar
    private bool canAnimate = false; // 3 saniye dolmadan animasyon �al��mas�n
    public string groundTag = "Floor"; // Yer objesinin tag ismi

    void Start()
    {
        // 3 saniye sonra animasyonlar� ba�latmak i�in Invoke kullan�yoruz
        Invoke("EnableAnimation", 3f);
    }

    void EnableAnimation()
    {
        canAnimate = true; // 3 saniye sonra animasyon devreye girsin
    }

    void Update()
    {
        // E�er animasyon yapmaya izin varsa ve karakter yerdeyse, animat�r� �al��t�r
        if (canAnimate && isGrounded)
        {
            animator.SetBool("isWalking", true); // Y�r�me animasyonunu ba�lat
        }
        else
        {
            animator.SetBool("isWalking", false); // Y�r�me animasyonunu durdur
        }
    }

    // Yere temas etti�inde �al��acak fonksiyon
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true; // Karakter yere temas ediyor
        }
    }

    // Yerden ayr�ld���nda �al��acak fonksiyon
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = false; // Karakter yerden ayr�ld�
        }
    }
}
