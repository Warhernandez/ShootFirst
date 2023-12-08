using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab1;
    public GameObject spritePrefab2;
    public GameObject specialSpritePrefab;

    public int numberOfSprites = 10;
    public float spawnRadius = 5f;
    public Vector2 specialSpriteSpawnPoint = new Vector2(0f, 0f);

    void Start()
    {
        SpawnSprites(spritePrefab1, numberOfSprites);
        SpawnSprites(spritePrefab2, numberOfSprites);

        // Spawn a special sprite at a specific point
        SpawnSpecialSprite(specialSpritePrefab, specialSpriteSpawnPoint);
    }

    void SpawnSprites(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }

    void SpawnSpecialSprite(GameObject prefab, Vector2 spawnPoint)
    {
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
}
