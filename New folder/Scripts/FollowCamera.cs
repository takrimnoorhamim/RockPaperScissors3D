using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player object

    void Update()
    {
        // Set the camera position relative to the player
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
