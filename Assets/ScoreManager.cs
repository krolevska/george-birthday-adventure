using UnityEngine;
using TMPro; // Include TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // The player's score.
    TextMeshProUGUI text; // Reference to the TextMeshProUGUI component.

    // Static singleton instance
    public static ScoreManager instance;

    void Awake()
    {
        // Make sure there's only one ScoreManager instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Set up the reference.
        text = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component

        // Reset the score.
        score = 0;

        // Set the initial text value.
        text.text = "Score: " + score;
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
    }
}
