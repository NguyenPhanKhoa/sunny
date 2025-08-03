using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        // Load the tutorial scene
        SceneManager.LoadScene(2);
    }

}
