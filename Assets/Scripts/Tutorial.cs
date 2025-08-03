using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Back()
    {
        // Load the game scene
        SceneManager.LoadScene(0);
    }
}
