using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public float minPulpitDestroyTime;
    public float maxPulpitDestroyTime;
    public float pulpitSpawnTime;

    private GameObject currentPlatform;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        // Start by spawning the first platform at the origin
        SpawnPlatform(Vector3.zero);
    }

    void SpawnPlatform(Vector3 spawnPosition)
    {
        // Instantiate the new platform at the specified position
        currentPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        platforms.Add(currentPlatform);

        // Start the coroutine to manage this platform's lifetime
        StartCoroutine(ManagePlatform(currentPlatform));
    }

    IEnumerator ManagePlatform(GameObject platform)
    {
        // Randomize the platform's lifetime
        float lifetime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);

        // Wait for a fraction of the lifetime before allowing the next platform to spawn
        yield return new WaitForSeconds(lifetime - pulpitSpawnTime);

        // Determine the new spawn position at one of the ends of the current platform
        Vector3 newPosition = GetNewPlatformPosition(platform.transform.position, platform.transform.localScale);

        // Spawn the next platform
        SpawnPlatform(newPosition);

        // If there are more than two platforms, destroy the oldest one
        if (platforms.Count > 2)
        {
            Destroy(platforms[0]);
            platforms.RemoveAt(0);
        }

        // Wait for the remaining lifetime before destroying the platform
        yield return new WaitForSeconds(pulpitSpawnTime);

        // Destroy the platform
        Destroy(platform);
    }

    public Vector3 GetLatestPlatformPosition()
    {
        if (platforms.Count > 0)
        {
            return platforms[platforms.Count - 1].transform.position;
        }
        else
        {
            return Vector3.zero; // Default position if no platforms exist
        }
    }

    Vector3 GetNewPlatformPosition(Vector3 currentPosition, Vector3 platformScale)
    {
        // Randomly choose a direction: 0 = left, 1 = right, 2 = front, 3 = back
        int direction = Random.Range(0, 4);

        switch (direction)
        {
            case 0: // left
                return new Vector3(currentPosition.x - platformScale.x, currentPosition.y, currentPosition.z);
            case 1: // right
                return new Vector3(currentPosition.x + platformScale.x, currentPosition.y, currentPosition.z);
            case 2: // front
                return new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + platformScale.z);
            case 3: // back
                return new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - platformScale.z);
            default:
                return currentPosition;
        }
    }
}
