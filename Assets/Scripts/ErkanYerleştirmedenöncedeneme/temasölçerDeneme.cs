using UnityEngine;
using UnityEngine.SceneManagement;

public class düþmantemasölçer : MonoBehaviour
{
    private int contactCounter = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contactCounter++;

            if (contactCounter >= 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
