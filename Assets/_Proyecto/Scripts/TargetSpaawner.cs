using System.Collections;
using UnityEngine;

public class TargetSpaawner : MonoBehaviour
{
    [Header("Spawn Setup")]
    [SerializeField] private Transform[] spawnPoints; // mínimo 10
    [SerializeField] private GameObject targetPrefab;

    [Header("Spawn Timing (Editable in Inspector)")]
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float maxSpawnInterval = 1.5f;

    [Header("Target Lifetime")]
    [SerializeField] private float minLifetime = 1.0f;
    [SerializeField] private float maxLifetime = 3.0f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float wait = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(wait);

            if (targetPrefab == null || spawnPoints == null || spawnPoints.Length == 0)
                continue;

            int index = Random.Range(0, spawnPoints.Length);
            Transform point = spawnPoints[index];

            GameObject targetInstance = Instantiate(targetPrefab, point.position, point.rotation);
            float life = Random.Range(minLifetime, maxLifetime);
            Destroy(targetInstance, life);
        }
    }
}
