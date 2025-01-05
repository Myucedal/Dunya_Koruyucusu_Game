using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;
    public GameObject DeathPanel;
    public GameObject FinishPanel;
    public GameObject player;
    public GameObject rightButton, leftButton;
    public GameObject tutorialHands;
    public Transform Maincam;
    public ParticleSystem particldead;
    public int score;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Destroy(tutorialHands, 3);
    }
    public void KillPlayer()
    {
        Instantiate(particldead, player.transform.position, player.transform.rotation);
        Destroy(player);
        rightButton.SetActive(false);
        leftButton.SetActive(false);
        StartCoroutine(WaitDeathPanel());
    }
    public IEnumerator WaitDeathPanel()
    {
        yield return new WaitForSeconds(2f);
        DeathPanel.SetActive(true);
    }
    public IEnumerator WaitoverPanel()
    {
        yield return new WaitForSeconds(1.9f);
        FinishPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("0_AnaMenu");
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void FinishGame()
    {
        StartCoroutine(WaitoverPanel());
    }
}
