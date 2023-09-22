using UnityEngine;

public class HitMarkerController : MonoBehaviour
{
    public GameObject hitMarker; // Reference to the Hit Marker UI Image.
    public float displayTime = 0.5f; // Adjust the time as needed.

    // Call this function to show the hit marker.
    public void ShowHitMarker()
    {
        hitMarker.SetActive(true);
        Invoke("HideHitMarker", displayTime);
    }

    // Call this function to hide the hit marker.
    private void HideHitMarker()
    {
        hitMarker.SetActive(false);
    }

    // Set the hit marker position in screen space and convert it to world space.
    public void SetHitMarkerPosition(Vector2 screenPosition)
    {

        // Convert screen position to world space.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, -Camera.main.transform.position.z));
        // Set the hit marker position.
        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }

}
