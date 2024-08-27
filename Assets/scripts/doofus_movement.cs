using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float speed = 3.0f;
}

public class doofus_movement : MonoBehaviour
{
    public PlayerData playerData = new PlayerData();

    void FixedUpdate()
    {
        float xdirection = Input.GetAxis("Horizontal");
        float zdirection = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xdirection, 0.0f, zdirection);
        transform.position += movement * Time.deltaTime * playerData.speed;
    }
}