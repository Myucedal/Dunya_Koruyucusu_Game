using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameManager : MonoBehaviour
{ 
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.GameOver("Görev Baþarýlý! :)");
    }
}
