using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePoint;

    LineRenderer lr;

    public float rayTime = 0.3f;
        float timer = 0.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        FireRay();

        if (lr.enabled) ShowRay();
    }

    private void ShowRay()
    {
        timer += Time.deltaTime;
        if(timer > rayTime)
        {
            lr.enabled = false;
            timer = 0.0f;
        }
    }

    private void Fire()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);

            //bullet.transform.position = transform.position;
            bullet.transform.position = firePoint.transform.position;
        }
    }

    private void FireRay()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
           

            lr.enabled = true;
            
            lr.SetPosition(0, transform.position);
            //lr.SetPosition(1, transform.position + Vector3.up * 10);

            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo;
            if(Physics.Raycast (ray, out hitInfo))
            {
                lr.SetPosition(1, hitInfo.point);
                //Destroy(hitInfo.collider.gameObject);

                if (hitInfo.collider.name != "Top")
                {
                    Destroy(hitInfo.collider.gameObject);
                }

                //if (hitInfo.collider .name .Contains  ("Enemy"))
                //{
                //    Destroy(hitInfo.collider.gameObject);
                //}
            }
            else
            {
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }
        }
    }
}
