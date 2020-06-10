using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;

    public GameObject fxFactory;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject, 1.0f); //1초후에 오브젝트 삭제
        Destroy(gameObject);
        Destroy(collision.gameObject);

        ShowEffect();

        ScoreManager.Instance.AddScore();
    }

    private void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
    }
}
