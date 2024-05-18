using UnityEngine;
using UnityEngine.SceneManagement;

public class d��mantemas�l�er : MonoBehaviour
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
