using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the UI Text element for displaying the timer.
    public TMP_Text bulletText; //Reference to the UI Text element for displaying bullets left "∞"

    //public AudioClip shootingSound; // Reference to the shooting sound.
    //private AudioSource audioSource; // Reference to the AudioSource component.
    //minigame stats and stuff, time and bullet count

    public float timeLimit; // Time limit for the game in seconds. Varies from game to game!
    private float currentTime; // Current time left in the game.
    public int maxBullets = -1; // Set to -1 for unlimited bullets. unlimited by default.
    private int currentBullets; 
    private int score = 0; // Player's score.
    public int quota; //score needed to pass

    private bool isGameOver = false; // Flag to check if the game is over.

    public GameObject resultsScreen;
    private void Start()
    {
        //audioSource = GameObject.Find("PlayerAudio").GetComponent<AudioSource>();
        if (maxBullets != -1)
        {
            currentBullets = maxBullets;
        }
        currentTime = timeLimit;
        UpdateUI(); // Update the score and timer UI elements.
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // Check for player input to shoot targets.
            if (Input.GetMouseButtonDown(0))
            {
                //audioSource.PlayOneShot(shootingSound);
                if (HasBullets()) // Check if the player has bullets.
                {

                    // Create a ray from the mouse position.
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                    
                    if (hit.collider != null)
                    {
                        // Check if the ray hit a target.
                        Target target = hit.collider.GetComponent<Target>();
                        if (target != null)
                        {
                            // The ray hit a target yaaaaay!!!
                            target.HitTarget(); // Handle the target hit.

                            // Increase the player's score (Will pretty much always be 1, but juuust to be safe...)
                            IncreaseScore(target.scoreValue);
                        }
                    }
                    ConsumeBullet();
                }
            }
        }

        // Update the timer.
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
        }
        else if (!isGameOver)
        {
            // Game over logic (e.g., show results screen).
            isGameOver = true;
            timerText.text = "";
            bulletText.text = "";
            ShowResults();
        }
    }

    private bool HasBullets()
    {
        if (maxBullets == -1)
        {
            return true; // Unlimited bullets.
        }
        return currentBullets > 0; // Check if there are remaining bullets.
    }

    private void ConsumeBullet()
    {
        if (maxBullets != -1)
        {
            currentBullets--;
        }
    }
    // Call this method when a target is hit to increase the score.
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateUI();
    }

    // Update the score and timer UI elements.
    private void UpdateUI()
    {
        timerText.text = "Time: " + currentTime.ToString("F1"); // Format the time to one decimal place.
        if (maxBullets == -1)
            {
            bulletText.text = "∞";
        }
        else
        {
            bulletText.text = "Ammo: " + currentBullets.ToString();
        }
    }


    private void ShowResults()
    {
        // Deactivate or remove all remaining target objects.
        Target[] targets = FindObjectsOfType<Target>();
        foreach (Target target in targets)
        {
            target.gameObject.SetActive(false); 
        }

        // Show the results screen.
        resultsScreen.SetActive(true);

        // Display the player's score on the results screen.
        TextMeshProUGUI resultsText = resultsScreen.GetComponentInChildren<TextMeshProUGUI>();
        if (resultsText != null & score >= quota)
        {
            resultsText.text = "Score: " + score.ToString() + "\nPass!";

        }
        else
        {
            resultsText.text = "Score: " + score.ToString() + "\nFail...!";
        }
    }
}
