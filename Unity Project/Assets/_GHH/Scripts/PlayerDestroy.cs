using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject fxFactory;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 1.0f);

        ShowEffect();
    }

    private void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
    }
}
