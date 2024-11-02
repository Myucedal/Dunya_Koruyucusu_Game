using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText, gorevDurumu;
    public GameObject endgamePanel;
    public int score = 0;

    public void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void GameOver(string _gorevDurumu)
    {
        Time.timeScale = 0;
        endgamePanel.SetActive(true);
        gorevDurumu.text = _gorevDurumu;
        //oyun sonu resetlemeleri , oyun sonu ekraný
    }

    public void IncreaseScore()
    {
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
