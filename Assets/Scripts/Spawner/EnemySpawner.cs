using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPos;
    public float spawnDelay;
    public float delayMin;
    public float delayMax;
    public List<GameObject> enemy = new List<GameObject>();
    private int enemyType;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnemySpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {
        int beforeType=-1;
        while (P_Manager.health > 0) {
            spawnDelay = Random.Range(delayMin, delayMax);
            enemyType = Random.Range(0, enemy.Count);
            if (enemyType == beforeType)
            {
                while (enemyType == beforeType)
                {
                    enemyType = Random.Range(0, enemy.Count);
                }
            }
            Instantiate(enemy[enemyType], spawnPos.position, Quaternion.identity);

            beforeType = enemyType;
            yield return new WaitForSeconds(spawnDelay);
        }
        

        yield return null;
    }
}
