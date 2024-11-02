using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "engel")
        {

            manager.GameOver("G�rev Ba�ar�s�z! :(");

        }
        else if (other.gameObject.tag == "puan")
        {
            manager.IncreaseScore();
            Destroy(other.gameObject);
        }
    }

}
