using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;
    public GameObject paneldead;
    public GameObject Gameoverpanel;
    public Transform Maincam;
    public ParticleSystem particldead;

    private void Awake()
    {
        instance = this;
    }

    

    public void DiePlayer()
    {
        Maincam.SetParent(null);
        particldead.transform.position = CharMove.instance.rb.transform.position;
        particldead.Play();
        Destroy(CharMove.instance.rb.gameObject);
        StartCoroutine(WaitDeadPanel());
       

    }
    public IEnumerator WaitDeadPanel()
    {
        yield return new WaitForSeconds(2f);
        paneldead.SetActive(true);
    }
    public IEnumerator WaitoverPanel()
    {
        yield return new WaitForSeconds(1.9f);
        Gameoverpanel.SetActive(true);
        Time.timeScale = 0;
    }
   
    public void RestartGame()
    {
        Debug.Log("restart calisti");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("0_AnaMenu");

    }

    public void Gameover()
    {
        if (BacaDegistir.instance.score == 5)
        {
            StartCoroutine(WaitoverPanel());
        }
    }
}
    