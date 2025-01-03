using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void CopToplaScene()
    {
        SceneManager.LoadScene(1);
    }
    public void MuslukScene()
    {
        SceneManager.LoadScene(2);
    }
    public void BacaScene()
    {
        SceneManager.LoadScene(3);
    }
}
