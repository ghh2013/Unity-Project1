using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailFire : MonoBehaviour
{
    public GameObject tailBulletFactory;
    public GameObject tailFirePoint;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MiniFire();
    }

    private void MiniFire()
    {
        GameObject bullet = Instantiate(tailBulletFactory);

        bullet.transform.position = tailFirePoint.transform.position;
    }
}
