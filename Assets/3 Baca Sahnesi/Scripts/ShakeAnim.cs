using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAnim : MonoBehaviour
{
    private Vector3 startPosition;
    public float timeY = 1.5f;
    public float yAmplitude = .5f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.PingPong(Time.time / timeY * 2f, yAmplitude * 2f) - yAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
