using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    public GameObject clone;
    public GameObject bulletFactory;
    public float fireTime = 3.0f;
    float curTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateClone();
        AutoFire();
    }

    private void CreateClone()
    {
        if(Input.GetKeyDown (KeyCode.Space))
        {
            clone.SetActive(true);
        }
    }

    private void AutoFire()
    {
        if(clone.activeSelf == true)
        {
            curTime += Time.deltaTime;
            if(curTime > fireTime)
            {
                curTime = 0.0f;

                //GameObject bullet1 = Instantiate(bulletFactory);
                //bullet1.transform.position = GameObject.Find("Sub1").transform.position;
                //bullet1.transform.position = clone.transform.Find("Sub1").position;
                //bullet1.transform.position = clone.transform.GetChild(0).position;

                //GameObject[] bullet = new GameObject[2];
                GameObject[] bullet = new GameObject[clone.transform.childCount];
                for(int i = 0; i < clone.transform.childCount; i++)
                {
                    bullet[i] = Instantiate(bulletFactory);
                    bullet[i].transform.position = clone.transform.GetChild(i).position;
                }
            }
        }
    }
}
