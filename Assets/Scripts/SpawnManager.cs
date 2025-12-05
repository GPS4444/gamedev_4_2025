using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int enemyCount;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] float spawnRange;
    [SerializeField] int waveNum;


    private Vector3 RandomPos()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(posX, 0, posZ);
        return spawnPos;
    }

    void SpawnWave(int num, GameObject prefab)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(prefab, RandomPos(), prefab.transform.rotation);
        }
    }
    void Start()
    {
        SpawnWave(waveNum, enemyPrefab);
        SpawnWave(waveNum, powerupPrefab);
    }

    void Update()
    {
        //count enemies number
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount < 1)
        {

            waveNum++;
            SpawnWave(waveNum, enemyPrefab);
            SpawnWave(waveNum, powerupPrefab);
        }
    }
}
