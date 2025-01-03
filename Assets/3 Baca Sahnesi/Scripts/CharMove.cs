using UnityEngine;

public class CharMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upSpeed = 0.08f;
    public float horizontalSpeed = 0.03f;
    public static CharMove instance;
    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        bool leftSideTouched = false;
        bool rightSideTouched = false;

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector3 touchPosition = touch.position;
                float screenWidth = Screen.width;

                if (touchPosition.x <= screenWidth / 2)
                {
                    leftSideTouched = true;
                }
                else
                {
                    rightSideTouched = true;
                }
            }
        }

        // Mouse Kontrolü
        if (Input.GetMouseButton(0)) // Sol týk
        {
            if (Input.mousePosition.x <= Screen.width / 2)
            {
                Debug.Log("sol týk");
                leftSideTouched = true;
            }
        }
        if (Input.GetMouseButton(1)) // Sað týk
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                Debug.Log("sag týk");
                rightSideTouched = true;
            }
        }

        if (rb.velocity.y > 0)
        {
            animator.SetBool("isRising", true);
            animator.SetBool("isFalling", false);
        }
        else if (rb.velocity.y < 0)
        {
            animator.SetBool("isRising", false);
            animator.SetBool("isFalling", true);
        }
        else
        {   
            animator.SetBool("isRising", false);
            animator.SetBool("isFalling", false);
        }

        // Kuvvet Uygulama
        if (leftSideTouched)
        {
            rb.AddForce(new Vector2(horizontalSpeed, upSpeed), ForceMode2D.Impulse);
        }
        if (rightSideTouched)
        {
            rb.AddForce(new Vector2(-horizontalSpeed, upSpeed), ForceMode2D.Impulse);
        }
    }
}
