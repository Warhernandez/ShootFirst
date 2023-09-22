using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public Transform spawnPoint;

    private int oddOneOutIndex; // Store the index of the odd one out target.

    private void Start()
    {
        // Randomly select an index for the odd one out target.
        oddOneOutIndex = Random.Range(0, 3);

        SpawnTargets();
    }

    private void SpawnTargets()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            GameObject targetPrefab = targetPrefabs[randomIndex];
            GameObject target = Instantiate(targetPrefab, spawnPoint.position + Vector3.right * i * 2f, Quaternion.identity);

            // Check if this target is the odd one out and apply unique properties.
            if (i == oddOneOutIndex)
            {
              
            }
        }
    }
}
