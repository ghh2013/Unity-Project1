using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject bossFactory;
    public GameObject spawnPoint;
    float spawnTime = 5.0f;
    float curTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBoss();   
    }

    private void SpawnBoss()
    {
        curTime += Time.deltaTime;
        if(curTime>spawnTime)
        {
            curTime = 0.0f;
            GameObject boss = Instantiate(bossFactory);
            boss.transform.position = spawnPoint.transform.position;
        }
    }

    
}
