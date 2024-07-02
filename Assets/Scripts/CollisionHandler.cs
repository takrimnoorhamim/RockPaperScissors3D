using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionHandler : MonoBehaviour
{
    // Tag names for the child game objects
    private const string RockTag = "Rock";
    private const string PaperTag = "Paper";
    private const string ScissorsTag = "Scissors";
    public Text scoreText;

    private static int score;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!");
        Debug.Log($"Player active child: {GetActiveChild(gameObject)?.name}");
        Debug.Log($"Bot active child: {GetActiveChild(collision.gameObject)?.name}");


        // Check if the collision involves the player and a bot
        if (collision.gameObject.CompareTag("Bot"))
        {
            // Get the active child objects of the player and bot
            GameObject playerActiveChild = GetActiveChild(gameObject);
            GameObject botActiveChild = GetActiveChild(collision.gameObject);

            if (playerActiveChild != null && botActiveChild != null)
            {
                // Determine the winner based on rock-paper-scissors rules
                int result = DetermineWinner(playerActiveChild.tag, botActiveChild.tag);

                if (result == 1)
                {
                    // Player wins: Destroy the bot
                    Destroy(collision.gameObject);
                    score++;
                    scoreText.text = "Score: " + score.ToString();
                }
                else if (result == -1)
                {
                    // Bot wins: Game over (you can handle this as needed)
                    Debug.Log("Game over!");
                    Time.timeScale = 0f;

                }
                // If result is 0, it's a tie (same tags active), do nothing
            }
        }
    }

    private GameObject GetActiveChild(GameObject parent)
    {
        // Check direct children first
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeSelf)
            {
                // If this child has one of the target tags, return it
                if (child.CompareTag(RockTag) || child.CompareTag(PaperTag) || child.CompareTag(ScissorsTag))
                {
                    return child.gameObject;
                }
                // If not, check this child's children
                GameObject activeGrandchild = GetActiveChild(child.gameObject);
                if (activeGrandchild != null)
                {
                    return activeGrandchild;
                }
            }
        }
        return null;
    }

    private int DetermineWinner(string playerTag, string botTag)
    {
        // Rock-paper-scissors rules
        if (playerTag == RockTag)
        {
            if (botTag == ScissorsTag) return 1; // Player wins
            if (botTag == PaperTag) return -1; // Bot wins
        }
        else if (playerTag == PaperTag)
        {
            if (botTag == RockTag) return 1; // Player wins
            if (botTag == ScissorsTag) return -1; // Bot wins
        }
        else if (playerTag == ScissorsTag)
        {
            if (botTag == PaperTag) return 1; // Player wins
            if (botTag == RockTag) return -1; // Bot wins
        }

        // It's a tie (same tags active)
        return 0;
    }
}
