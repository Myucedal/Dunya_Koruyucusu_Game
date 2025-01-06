using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    public Text scoreText, gorevDurumu;
    public GameObject endgamePanel;
    public int score = 0;
    private AudioSource audioSource;
    public AudioClip collectSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
    }
    public void GameOver(string _gorevDurumu)
    {
        if(_gorevDurumu== "Görev Baþarýsýz! :(")
        {
            audioSource.PlayOneShot(loseSound, 0.5f);
        }
        else
        {
            audioSource.PlayOneShot(winSound, 0.5f);
        }
        Time.timeScale = 0;
        endgamePanel.SetActive(true);
        gorevDurumu.text = _gorevDurumu;
        //oyun sonu resetlemeleri , oyun sonu ekraný
    }

    public void IncreaseScore()
    {
        audioSource.PlayOneShot(collectSound, 0.5f);
        score++;
        scoreText.text = $"Puan : {score}";
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
