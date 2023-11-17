using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    private ButtonFlyIn flyIn;
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

        StartCoroutine(AnimateAndChangeScene());
    }

    private IEnumerator AnimateAndChangeScene()
    {
        flyIn = GetComponent<ButtonFlyIn>();
        foreach (Button button in FindObjectsOfType<Button>())
        {
             flyIn.FlyOut();
        }
            

        yield return new WaitForSeconds(1.0f); // Adjust the time based on your animation duration.

        // Change scene after the animation completes.
        ChangeScene();
    }

    private void ChangeScene()
    {
        // Change the scene to your desired scene.
        SceneManager.LoadScene(1);
    }

    private void UpdateButtonState()
    {
        // Get the currently selected difficulty.
        string selectedDifficulty = difficultySettings.GetDifficulty();
    }
}
