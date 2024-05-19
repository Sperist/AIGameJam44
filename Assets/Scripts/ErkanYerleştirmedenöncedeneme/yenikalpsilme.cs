
using UnityEngine;
using UnityEngine.SceneManagement;

public class yenikalp : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    private void Start()
    {
        life = hearts.Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (life > 0)
            {
                life--;
                Destroy(hearts[life]);
            }
            if (life == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
