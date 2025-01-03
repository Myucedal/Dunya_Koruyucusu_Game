using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "engel")
        {

            manager.GameOver("Görev Baþarýsýz! :(");

        }
        else if (other.gameObject.tag == "puan")
        {
            manager.IncreaseScore();
            Destroy(other.gameObject);
        }
    }

}
