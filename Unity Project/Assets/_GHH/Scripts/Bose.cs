using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bose : MonoBehaviour
{
    public GameObject bulletFactory;
    
    public GameObject target;
    public float fireTime = 1.0f;
    public float curTime = 0.0f;

    public float fireTime1 = 1.5f;
    float curTime1 = 0.0f;
    public int bulletMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        AutoFire1();
        AutoFire2();
    }

    private void AutoFire1()
    {
        if(target != null)
        {
            curTime += Time.deltaTime;
            if (curTime > fireTime)
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = transform.position;
                Vector3 dir = target.transform.position - transform.position; dir.Normalize();
                bullet.transform.up = dir;
                curTime = 0.0f;
            }
        }
    }

    private void AutoFire2()
    {
        if (target != null)
        {
            curTime1 += Time.deltaTime;
            if (curTime1 > fireTime1)
            {
                for (int i = 0; i < bulletMax; i++)
                {
                    GameObject bullet = Instantiate(bulletFactory);
                    bullet.transform.position = transform.position;

                    float angle = 360.0f / bulletMax;
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }
                curTime1 = 0.0f;
            }
        }
    }
}
