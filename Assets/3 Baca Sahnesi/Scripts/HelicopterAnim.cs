using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAnim : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    public float timeY = 2f; 
    public float timeZ = .5f; 
    private float yAmplitude = 1f;
    private float zAmplitude = 5f;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.PingPong(Time.time / timeY * 2f, yAmplitude * 2f) - yAmplitude;

        float newZRotation = Mathf.PingPong(Time.time / timeZ * 2f, zAmplitude * 2f) - zAmplitude;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        transform.rotation = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y, newZRotation);
    }
}
