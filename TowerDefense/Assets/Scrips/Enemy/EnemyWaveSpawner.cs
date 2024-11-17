using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public float spawnDelay = 0.5f;

    public bool waveStart = false;
    public bool started = false;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) {
            if (waveStart)
            {
                started = true;
                
            }
        }
    }

    private IEnumerator SpawnEnemiesFromFile(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (!File.Exists(filePath))
        {
            Debug.Log("El archivo de oleada no existe we D:");
            yield break;
        }

        string fileContents = File.ReadAllText(filePath);

        string[] spawnNumbers = fileContents.Split(new char[] { ' ', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string number in spawnNumbers)
        {
            if(int.TryParse(number, out int enemyType))
            {
                if (enemyType == 0)
                {
                    yield return new WaitForSeconds(spawnDelay);
                    continue;
                }

                if (enemyType>0 && enemyType <= enemyPrefabs.Length)
                {
                    Instantiate(enemyPrefabs[enemyType - 1], spawnPoint.position, Quaternion.identity);
                }
                else
                {
                    Debug.Log("enemigo invalido");
                }
            }
            else
            {
                Debug.Log("Numero invalido en archivo");
            }
            yield return new WaitForSeconds(spawnDelay);

        }
    }
    public void StartWaves()
    {
        StartCoroutine(SpawnEnemiesFromFile("EnemySpawnData.txt"));
    }

}
