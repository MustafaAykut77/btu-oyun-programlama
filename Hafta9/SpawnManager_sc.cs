using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject[] BonusPrefabs;

    [SerializeField]
    GameObject enemyContainer;

    bool stopSpawning = false;

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while(stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.4f, 9.4f), 7.4f, 0);
            GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    
    IEnumerator SpawnBonusRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while(stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.4f, 9.4f), 7.4f, 0);
            Instantiate(BonusPrefabs[Random.Range(0,3)], position, Quaternion.identity);
            yield return new WaitForSeconds(8.0f);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }

    public void StartSpawning()
    {  
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }
}
