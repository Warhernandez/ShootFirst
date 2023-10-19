using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UITween: MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject you want to animate
    public float scaleAmount = 1.2f; // Scale factor for the animation
    public float animationDuration = 0.2f; // Duration of the animation

    private Vector3 originalScale;

    private void Start()
    {
        if (targetObject != null)
        {
            originalScale = targetObject.transform.localScale;
        }
    }

    public void AnimateObject()
    {
        if (targetObject != null)
        {
            LeanTween.scale(targetObject, originalScale * scaleAmount, animationDuration)
                .setEase(LeanTweenType.easeOutBack) // Choose your desired ease type
                .setOnComplete(ResetObjectScale);
        }
    }

    private void ResetObjectScale()
    {
        if (targetObject != null)
        {
            LeanTween.scale(targetObject, originalScale, animationDuration)
                .setEase(LeanTweenType.easeOutBack); // Choose the same ease type as the first animation
        }
    }
}
