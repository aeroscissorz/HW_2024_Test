using UnityEngine;

public class lives : MonoBehaviour
{
    public GameObject gameOver, heart1, heart2, heart3,RestartButton;
    public static int life;

    void Start()
    {
        // Ensure life is reset at the start
        life = 3;
        Time.timeScale = 1; // Ensure the game runs at normal speed

        // Activate all hearts and hide the game over screen
        if (heart1 != null) heart1.SetActive(true);
        if (heart2 != null) heart2.SetActive(true);
        if (heart3 != null) heart3.SetActive(true);
        if (gameOver != null) gameOver.SetActive(false);
        if (RestartButton != null) RestartButton.SetActive(false);
    }

    void Update()
    {
        switch (life)
        {
            case 3:
                if (heart1 != null) heart1.SetActive(true);
                if (heart2 != null) heart2.SetActive(true);
                if (heart3 != null) heart3.SetActive(true);
                break;
            case 2:
                if (heart1 != null) heart1.SetActive(true);
                if (heart2 != null) heart2.SetActive(true);
                if (heart3 != null) heart3.SetActive(false);
                break;
            case 1:
                if (heart1 != null) heart1.SetActive(true);
                if (heart2 != null) heart2.SetActive(false);
                if (heart3 != null) heart3.SetActive(false);
                break;
            case 0:
                if (heart1 != null) heart1.SetActive(false);
                if (heart2 != null) heart2.SetActive(false);
                if (heart3 != null) heart3.SetActive(false);
                if (gameOver != null) gameOver.SetActive(true);
                if (RestartButton != null) RestartButton.SetActive(true);
                Time.timeScale = 0; // Pause the game

                break;
            default:
                if (heart1 != null) heart1.SetActive(false);
                if (heart2 != null) heart2.SetActive(false);
                if (heart3 != null) heart3.SetActive(false);
                if (gameOver != null) gameOver.SetActive(true);
                if (RestartButton != null) RestartButton.SetActive(true);
                Time.timeScale = 0; // Pause the game
                break;
        }
    }
}
