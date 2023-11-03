using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    public string difficulty;
    public DifficultySettings difficultySettings; // Reference to the DifficultySettings script.

    private void Start()
    {
        // Get the DifficultySettings script.
        difficultySettings = GameObject.FindObjectOfType<DifficultySettings>();

        // Update the button states based on the selected difficulty.
        UpdateButtonState();
    }

    public void OnButtonClick()
    {
        // Set the selected difficulty.
        difficultySettings.SetDifficulty(difficulty);

        // Update the button states when a button is clicked.
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        // Get the currently selected difficulty.
        string selectedDifficulty = difficultySettings.GetDifficulty();
    }
}
