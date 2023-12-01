using UnityEngine;

public class AntiJitter : MonoBehaviour
{
    public float deadZoneThreshold = 0.1f;

    void Update()
    {
        // Get raw input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Apply dead zone
        float clampedHorizontalInput = ApplyDeadZone(horizontalInput);
        float clampedVerticalInput = ApplyDeadZone(verticalInput);

        // Use clamped input for your game logic
        // Example: transform.Translate(new Vector3(clampedHorizontalInput, 0, clampedVerticalInput) * Time.deltaTime * speed);
    }

    float ApplyDeadZone(float inputValue)
    {
        // Check if the absolute value of the input is below the dead zone threshold
        if (Mathf.Abs(inputValue) < deadZoneThreshold)
        {
            // If it is, treat it as zero
            return 0f;
        }
        else
        {
            // Otherwise, return the original input value
            return inputValue;
        }
    }
}
