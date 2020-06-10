using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 margin;

    public VariableJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.08f, 0.05f);
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

        if(h==0&&v==0)
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
        }

        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 dir = new Vector3(h, v, 0);
        //dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);

        //P = P0 + vt;
        //transform.position = transform.position + (dir * speed * Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;
        MoveInScreen();
    }

    private void MoveInScreen()
    {
        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        //transform.position = position;

        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        //position.x = Mathf.Clamp(position.x, 0.0f, 1.0f);
        //position.y = Mathf.Clamp(position.y, 0.0f, 1.0f);
        position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f + margin.y, 1.0f - margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);
    }
}
