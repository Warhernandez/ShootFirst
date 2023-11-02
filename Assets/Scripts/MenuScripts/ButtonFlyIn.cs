using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonFlyIn : MonoBehaviour
{
    public Vector2 startPos;  // The off-screen starting position
    public Vector2 endPos;    // The on-screen ending position
    public float duration = 1.0f;  // Animation duration

    private Button button;

    private void Start()
    {
        button = GetComponent <Button>();

        // Set the initial position of the button to be off-screen
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = startPos;

        // Call the FlyIn method to animate the button on start
        FlyIn();
    }

    public void FlyIn()
    {
        // Animate the button from the off-screen position to the on-screen position
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        LeanTween.move(rectTransform, endPos, duration).setEase(LeanTweenType.easeOutExpo);
    }
}
