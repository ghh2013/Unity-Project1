using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 margin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        //Vector3 dir = new Vector3(h, v, 0);
        //transform.Translate(dir * speed * Time.deltaTime);

        //P = P0 + vt;
        //transform.position = transform.position = (dir * speed * Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;
        MoveInScreen();
    }

    private void MoveInScreen()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        transform.position = position;

        Vector3 posooon = Camera.main.WorldToViewportPoint(transform.position);
    }
}
