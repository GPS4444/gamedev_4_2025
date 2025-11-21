using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRange;

    private Vector3 RandomPos()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(posX, 0, posZ);
        return spawnPos;
    }

    void Start()
    {
        Instantiate(enemyPrefab, RandomPos(), enemyPrefab.transform.rotation);
    }

    void Update()
    {
        
    }
}
