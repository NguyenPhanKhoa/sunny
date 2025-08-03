using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        Hide();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void Again()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
}
