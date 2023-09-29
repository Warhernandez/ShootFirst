using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySettings : MonoBehaviour
{
    public TMP_Text difficultyText;// Text UI element to display the current difficulty.

    public void SetDifficulty(string difficulty)
    {
        //I've never used playerprefs before so if i mess this up.......... oops!
        // Save the selected difficulty to PlayerPrefs.
        PlayerPrefs.SetString("Difficulty", difficulty);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately.

        // Update the displayed difficulty text.
        difficultyText.text = "Difficulty: " + difficulty;
    }

    public string GetDifficulty()
    {
        // Retrieve the selected difficulty from PlayerPrefs. If not set, default to "Normal."
        return PlayerPrefs.GetString("Difficulty", "Normal");
    }
}
