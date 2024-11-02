using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; // Karakterin Animator bileþeni
    private bool isGrounded = false; // Karakterin yerde olup olmadýðýný tutar
    private bool canAnimate = false; // 3 saniye dolmadan animasyon çalýþmasýn
    public string groundTag = "Floor"; // Yer objesinin tag ismi

    void Start()
    {
        // 3 saniye sonra animasyonlarý baþlatmak için Invoke kullanýyoruz
        Invoke("EnableAnimation", 3f);
    }

    void EnableAnimation()
    {
        canAnimate = true; // 3 saniye sonra animasyon devreye girsin
    }

    void Update()
    {
        // Eðer animasyon yapmaya izin varsa ve karakter yerdeyse, animatörü çalýþtýr
        if (canAnimate && isGrounded)
        {
            animator.SetBool("isWalking", true); // Yürüme animasyonunu baþlat
        }
        else
        {
            animator.SetBool("isWalking", false); // Yürüme animasyonunu durdur
        }
    }

    // Yere temas ettiðinde çalýþacak fonksiyon
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true; // Karakter yere temas ediyor
        }
    }

    // Yerden ayrýldýðýnda çalýþacak fonksiyon
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = false; // Karakter yerden ayrýldý
        }
    }
}
