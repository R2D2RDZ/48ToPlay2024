using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemigoBase;
    public GameObject enemigoFuerte;
    public GameObject enemigoHacker;
    public GameObject enemigoBoss;
    public Transform spawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnBase();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            SpawnFuerte();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            SpawnHacker();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            SpawnBoss();
        }
    }

    void SpawnBase(){
        Vector2 spawnPosition = (Vector2)spawnPoint.position;
        Instantiate(enemigoBase, spawnPosition, Quaternion.identity);
        Debug.Log("jisjiojf");
    }

    void SpawnFuerte(){
        Vector2 spawnPosition = (Vector2)spawnPoint.position;
        Instantiate(enemigoFuerte, spawnPosition, Quaternion.identity);
        Debug.Log("jisjiojf");
    }

    void SpawnHacker(){
        Vector2 spawnPosition = (Vector2)spawnPoint.position;
        Instantiate(enemigoHacker, spawnPosition, Quaternion.identity);
        Debug.Log("jisjiojf");
    }

    void SpawnBoss(){
        Vector2 spawnPosition = (Vector2)spawnPoint.position;
        Instantiate(enemigoBoss, spawnPosition, Quaternion.identity);
        Debug.Log("jisjiojf");
    }
}
