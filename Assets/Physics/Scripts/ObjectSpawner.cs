using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject enemy;
    public bool active;
    float xPos;
    float zPos;
    public float xLow, xHigh, zLow, zHigh, yPos;
    public int enemyCount;
    public int maxEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active && enemyCount < maxEnemyCount)
        {
            StartCoroutine(EnemySpawn());
        }
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < maxEnemyCount)
        {
            xPos = Random.Range(xLow, xHigh);
            zPos = Random.Range(zLow, zHigh);
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
