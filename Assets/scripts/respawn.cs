using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public PlatformManager platformManager; // Reference to the PlatformManager

    void Update()
    {
        if (transform.position.y < threshold)
        {
            if (platformManager != null)
            {
                // Get the position of the latest platform
                Vector3 respawnPosition = platformManager.GetLatestPlatformPosition();
                // Set the respawn position to match the latest platform's position exactly
                transform.position = new Vector3(respawnPosition.x, respawnPosition.y, respawnPosition.z);
                
                // Decrease lives (assuming lives is handled elsewhere in your code)
                lives.life -= 1;
            }
            else
            {
                Debug.LogError("PlatformManager reference is not set in GameRespawn script.");
            }
        }
    }
}