using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
        Time.timeScale = 1;
        lives.life = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score.scoreValue = -1; // Assuming Score is the correct class name
    }
}