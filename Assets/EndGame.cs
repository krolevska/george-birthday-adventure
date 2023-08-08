using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject birthdayPanel; // Reference to the panel

    public void ShowBirthdayMessage()
    {
        Invoke("DisplayMessage", 3f); // Wait for 3 seconds before executing DisplayMessage
    }

    private void DisplayMessage()
    {
        birthdayPanel.SetActive(true); // Show the panel
    }
}