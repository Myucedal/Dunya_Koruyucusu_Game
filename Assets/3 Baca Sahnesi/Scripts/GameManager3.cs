using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;
    public GameObject paneldead;
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
   
    public void RestartGame()
    {
        Debug.Log("restart calisti");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
    