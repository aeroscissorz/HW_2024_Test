using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public static int scoreValue = -1; // Set initial score to -1

    public static int highScoreValue = 0;

    void Start()
    {
        // Load the high score from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreValue = PlayerPrefs.GetInt("HighScore");
        }

        // Display the initial high score
        highScoreText.text = "High Score: " + highScoreValue;
    }

    void Update()
    {
        // Update the high score if the current score exceeds it
        if (scoreValue > highScoreValue)
        {
            highScoreValue = scoreValue;
            PlayerPrefs.SetInt("HighScore", highScoreValue);

            // Update the high score display
            highScoreText.text = "High Score: " + highScoreValue;
        }

        // Display 0 if scoreValue is -1, otherwise display the actual scoreValue
        if (scoreValue == -1)
        {
            scoreText.text = "Score: 0";
        }
        else
        {
            scoreText.text = "Score: " + scoreValue;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "platform")
        {
            Debug.Log("Collided with platform");
            scoreValue += 1;
        }
    }
}
