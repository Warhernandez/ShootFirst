using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    public string difficulty; // Set this in the Inspector (e.g., "Easy", "Medium", "Hard").
    public DifficultySettings difficultySettings; // Reference to the DifficultySettings script.

    private void Start()
    {
        // Get the DifficultySettings script.
        difficultySettings = GameObject.FindObjectOfType<DifficultySettings>();

        // Set the button's text to display the difficulty.
        //GetComponentInChildren<Text>().text = difficulty;

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

        // Highlight the button if it matches the selected difficulty, or unhighlight it if it doesn't.
       // GetComponent<Button>().interactable = (difficulty != selectedDifficulty);
    }
}
