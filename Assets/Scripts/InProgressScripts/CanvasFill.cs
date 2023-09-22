using UnityEngine;
using UnityEngine.UI;

public class CanvasFill : MonoBehaviour
{
    public Image canvasImage;
    public float passingPercentage = 0.7f; // Adjust the passing percentage as needed.
    private bool gameEnded = false;

    private void Update()
    {
        if (!gameEnded && Input.GetMouseButtonDown(0))
        {
            FillCanvas();
        }
    }

    private void FillCanvas()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == canvasImage.gameObject)
        {
            // Calculate the filled percentage based on your desired logic.

            // For example, if you're adjusting the canvas image's alpha:
            Color canvasColor = canvasImage.color;
            canvasColor.a += 0.1f; // Adjust this value to control the fill rate.
            canvasImage.color = canvasColor;

            // Or if you're adjusting the fill amount:
            float fillAmount = canvasImage.fillAmount + 0.1f; // Adjust this value to control the fill rate.
            fillAmount = Mathf.Clamp01(fillAmount);
            canvasImage.fillAmount = fillAmount;

            // Calculate the score based on the filled percentage.
            float score = fillAmount * 100;

            // Display the score to the player.
            Debug.Log("Score: " + score);

            // Check if the player has passed based on the passing criteria.
            if (fillAmount >= passingPercentage)
            {
                EndGame(true); // Player passed.
            }
        }
    }

    private void EndGame(bool passed)
    {
        gameEnded = true;
        // Display the result to the player (e.g., in a results screen).
        if (passed)
        {
            Debug.Log("Passed!");
        }
        else
        {
            Debug.Log("Failed.");
        }
    }
}
