using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class ScoreSystem : MonoBehaviour
{
    // Variables
    public int score = 0; // Player's score
    public Text scoreText; // Reference to the UI Text element

    void Start()
    {
        // Initialize the score display
        //UpdateScoreText();
    }

    // Method to increase the score for a correct placement
    public void AddScoreForCorrectPlacement(int points)
    {
        score += points; // Increase the score by the given points
       // UpdateScoreText(); // Update the UI
    }

    // Method to handle incorrect placement (optional)
    public void HandleIncorrectPlacement()
    {
        // feedback here
        Debug.Log("Incorrect placement - no points awarded.");
    }

    // Method to reset the score
    public void ResetScore()
    {
        score = 0; // Reset score to 0
       // UpdateScoreText(); // Update the UI
    }

    // Method to update the score text in the UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
           //d scoreText.text = "Score: " + score.ToString(); // Update the text component
        }
        else
        {
            Debug.LogWarning("Score Text UI element is not assigned.");
        }
    }
}