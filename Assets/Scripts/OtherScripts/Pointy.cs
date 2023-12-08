using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pointy : MonoBehaviour
{
    // Reference to the button text
    public TMP_Text buttonText;
    //animator component
    Animator animator;
    public Sprite clickedSprite;
    // Set of strings for dialogue
    public string[] dialogueOptions;
    private bool isClicked = false;

    private void Start()
    {

        animator = GetComponent<Animator>();
        // Make sure the button text reference is set
        if (buttonText == null)
        {
            Debug.LogError("Button Text reference not set on " + gameObject.name);
            return;

        }
    
    }

    private void Update()
    {
        // more or less copied from the schhoting script lol
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            // Cast a ray from the screen to detect if pointy
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Check if the character is clicked
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                animator.SetBool("IsClicked", true);
                ChangeSprite();
                // Change the button text to a random dialogue option
                UpdateButtonText();
                //animator.SetTrigger("pointyShot");
            }
        }
    }

    private void UpdateButtonText()
    {
        // Ensure there are dialogue options
        if (dialogueOptions.Length > 0)
        {
            // Get a random index for the dialogueOptions array
            int randomIndex = Random.Range(0, dialogueOptions.Length);

            // Set the button text to the randomly chosen dialogue
            buttonText.text = dialogueOptions[randomIndex];
        }
        else
        {
            Debug.LogWarning("No dialogue options set for " + gameObject.name);
        }
    }

    private void ChangeSprite()
    {
        // Check if a new sprite is assigned
        if (clickedSprite != null)
        {
            // Get the SpriteRenderer component
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Change the sprite
            spriteRenderer.sprite = clickedSprite;
        }
        else
        {
            Debug.LogWarning("Clicked sprite not assigned in " + gameObject.name);
        }
    }

}

