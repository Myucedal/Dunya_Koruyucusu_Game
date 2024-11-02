using UnityEngine;

public class Oto_Movement : MonoBehaviour
{
    bool shouldMove = false;
    public float speed = 5f;
    void Start()
    {
        Invoke("StartMoving", 3f);
    }

    void StartMoving()
    {
        shouldMove = true;
    }
    void Update()
    {
        if (shouldMove)
        {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
