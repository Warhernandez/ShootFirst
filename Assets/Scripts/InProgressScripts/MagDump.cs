using UnityEngine;
using TMPro;

public class MagDump: MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text bulletText;
    public GameObject approachingObjectPrefab; // Reference to the approaching object prefab.
    public int shotsRequired = 5; // Number of shots required to destroy the object.
    private int shotsTaken = 0; // Counter for shots taken.
    public float timeLimit; // Time limit for the game in seconds. Varies from game to game!
    private float currentTime; // Current time left in the game.
    public int maxBullets = -1; // Set to -1 for unlimited bullets. unlimited by default.
    private int currentBullets;
    private int score = 0; // Player's score.
    public int quota; //score needed to pass
    private bool isGameOver = false; // Flag to check if the game is over.

    private void Start()
    {
        // Other initialization...

        // Spawn the approaching object.
        SpawnApproachingObject();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // Check for player input to shoot targets.
            if (Input.GetMouseButtonDown(0))
            {
                //audioSource.PlayOneShot(shootingSound);
   

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


                        }
                    }

                
            }
        }
    }

    private void SpawnApproachingObject()
    {
        // Spawn the approaching object at a spawn point on the screen.
        // You can set the spawn position and other properties as needed.
        Vector2 spawnPosition = new Vector3(0f, 0f); // Adjust the position.
        GameObject approachingObject = Instantiate(approachingObjectPrefab, spawnPosition, Quaternion.identity);
    }

    public void OnObjectShot()
    {
        // This method should be called when the object is shot.
        shotsTaken++;

        // Check if the required number of shots has been taken to destroy the object.
        if (shotsTaken >= shotsRequired)
        {
            DestroyApproachingObject(); // Implement this method to destroy the object.
           
        }
    }

    private void DestroyApproachingObject()
    {
        //Destroy(approachingObject);
    }
}
