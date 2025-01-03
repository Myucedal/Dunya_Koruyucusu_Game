using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upSpeed = 2000;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch dokunma = Input.GetTouch(0);
        //    if (dokunma.phase == TouchPhase.Stationary || dokunma.phase == TouchPhase.Moved)
        //    {
        //        rb.AddForce(new Vector2(0, upSpeed * Time.deltaTime));
        //    }
        //}
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (rb != null)
            {
                rb.AddForce(new Vector2(0, upSpeed * Time.deltaTime));

            }
        }
#endif
    }
}
