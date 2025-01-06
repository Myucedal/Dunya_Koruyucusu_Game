using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMove_G2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Button jumpButton;
    public Button RightButton;
    public Button LeftButton;
    public float jumpForce = 300f;
    public int jumpCount = 0;
    public float moveSpeed = 5f;
    public Color newColor = Color.blue;
    private Color originalColor;
    private Image buttonImage;
    [SerializeField] private LayerMask hitlayer;

    private bool rightPressed = false;
    private bool leftPressed = false;

    private bool isGrounded;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        buttonImage = jumpButton.GetComponent<Image>();
        originalColor = jumpButton.GetComponent<Image>().color;

        jumpButton.onClick.AddListener(Jump);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, hitlayer);

        if (hit.collider != null)
        {
            jumpButton.interactable = true;
            Debug.DrawRay(transform.position, Vector2.down * 1.30f, Color.red);
            isGrounded = true;
            buttonImage.color = originalColor;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * 1.30f, Color.blue);
            isGrounded = false;
            buttonImage.color = newColor;
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        } 
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (rightPressed)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (leftPressed)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            jumpCount = 0;
        }
        if (jumpCount == 0)
        {
            jumpCount++;
            rb.AddForce(new Vector2(0, jumpForce));
        }
        else if (jumpCount == 1)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
            audioSource.PlayOneShot(jumpSound, 1f);
            jumpCount++;
            jumpButton.interactable = false;
        }
    }

    public void RightDown()
    {
        rightPressed = true;
    }
    public void RightUp()
    {
        rightPressed = false;
    }

    public void LeftDown()
    {
        leftPressed = true;
    }
    public void LeftUp()
    {
        leftPressed = false;
    }

}
