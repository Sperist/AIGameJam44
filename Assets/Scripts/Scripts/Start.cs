using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    void Start()
    {
        
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Level 1 sahnesine ge�i� 
        SceneManager.LoadScene("Level-1");
    }
}
