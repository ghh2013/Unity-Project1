using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public float damage = 1.0f;
    public float speed = 10.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}
