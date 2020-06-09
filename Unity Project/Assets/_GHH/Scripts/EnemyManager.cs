//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory;
    //public GameObject spawnPoint;
    public GameObject [] spawnPoints;
    float spawnTime=1.0f;
    float curTime=0.0f;

    

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();   
    }

    private void SpawnEnemy()
    {
        curTime += Time.deltaTime;
        if(curTime>spawnTime )
        {
            curTime = 0.0f;

            spawnTime = Random.Range(0.5f, 2.0f);

            GameObject enemy = Instantiate(enemyFactory);
            //enemy.transform.position = spawnPoint.transform.position;
            int index = Random.Range(0, spawnPoints.Length);
            enemy.transform.position = spawnPoints[index].transform.position;
            //enemy.transform.position = transform.GetChild(index).position;
        }
    }
}
