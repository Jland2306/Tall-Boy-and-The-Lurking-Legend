using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPlacer2D : MonoBehaviour
{
    [Header("Prefab to Spawn")]
    public GameObject objectToSpawn;

    [Header("Number of Objects")]
    public int numberOfObjects = 10;

    [Header("Spawn Area Size (Width x Height)")]
    public Vector2 areaSize = new Vector2(10f, 5f);

    [Header("Z Position Offset (relative to this object)")]
    public float zOffset = 0f;

    [Header("Parenting")]
    public bool parentToThisObject = true;

    [Header("Prefab Scale Multiplier")]
    [Tooltip("Adjust this to scale all spawned objects relative to the prefab size.")]
    public Vector3 prefabScale = Vector3.one;

    void Start()
    {
        if (objectToSpawn == null)
        {
            Debug.LogWarning("No object assigned to spawn!");
            return;
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            SpawnRandomObject2D();
        }
    }

    void SpawnRandomObject2D()
    {
        // Random position inside 2D area
        Vector2 randomPos = new Vector2(
            Random.Range(-areaSize.x / 2f, areaSize.x / 2f),
            Random.Range(-areaSize.y / 2f, areaSize.y / 2f)
        );

        // Maintain Z position and add offset
        Vector3 spawnPos = new Vector3(
            transform.position.x + randomPos.x,
            transform.position.y + randomPos.y,
            transform.position.z + zOffset
        );

        // Instantiate the object with optional parenting
        Transform parentTransform = parentToThisObject ? transform : null;
        GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

        // Apply prefab scale multiplier
        obj.transform.localScale = prefabScale;
    }

    // Optional: visualize spawn area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, areaSize.y, 0));
    }
}
