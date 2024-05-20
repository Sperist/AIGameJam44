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
        // Level 1 sahnesine geçiþ 
        SceneManager.LoadScene("Level-1");
    }
}
