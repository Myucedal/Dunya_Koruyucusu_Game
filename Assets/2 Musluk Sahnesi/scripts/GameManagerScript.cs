using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class GameManagerScript : MonoBehaviour
{
    public GameObject[] waters;
    int waterCount = 0;
    public static GameManagerScript instance;
    public GameObject rightBtn;
    public GameObject leftBtn;
    public GameObject jumpBtn;
    public GameObject panel;

    private AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip faucetSound;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (var water in waters)
            {
                if (water.activeSelf)
                {
                    water.SetActive(false);
                }
            }
            WaterControl();
        }
    }
    public void WaterControl()
    {
        audioSource.PlayOneShot(faucetSound, 1f);
        waterCount = 0;
        foreach (var water in waters)
        {
            if (!water.activeSelf)
            {
                waterCount++;
            }
        }
        if (waterCount == 5)
        {
            Invoke(nameof(gameWin), 1f);
        }
    }

    private void gameWin()
    {
        audioSource.PlayOneShot(winSound, 1f);
        jumpBtn.SetActive(false);
        leftBtn.SetActive(false);
        rightBtn.SetActive(false);
        panel.SetActive(true);
    }
}
