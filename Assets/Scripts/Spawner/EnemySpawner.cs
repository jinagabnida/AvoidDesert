using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public List<Transform> spawnPos;
    public float delayMin;
    public float delayMax;
    public List<GameObject> enemy = new List<GameObject>();
    

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
            float spawnDelay = Random.Range(delayMin, delayMax);
            int enemyType = Random.Range(0, enemy.Count);
            float randPos = Random.Range(67, 83);
            if (enemyType == beforeType)
            {
                while (enemyType == beforeType)
                {
                    enemyType = Random.Range(0, enemy.Count);
                }
            }
            Instantiate(enemy[enemyType], new Vector3(0,0,randPos), Quaternion.identity);

            beforeType = enemyType;
            yield return new WaitForSeconds(spawnDelay);
        }
        

        yield return null;
    }
}
