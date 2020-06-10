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

    AudioSource audio;

    int poolSize = 20;
    int fireIndex = 0;
    //1. 배열
    //GameObject[] bulletPool;
    //2. 리스트
    //public List<GameObject> bulletPool;
    //3. 큐
    public Queue<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        audio = GetComponent<AudioSource>();

        InitObjectPooling();
    }

    private void InitObjectPooling()
    {
        //1. 배열
        //bulletPool = new GameObject[poolSize];
        //for(int i = 0; i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool[i] = bullet;
        //}

        //2. 리스트
        //bulletPool = new List<GameObject>();
        //for(int i = 0;i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool.Add(bullet);
        //}

        //3. 큐
        bulletPool = new Queue<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        //FireRay();

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

    public void Fire()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            //1. 배열 오브젝트풀링으로 총알발사
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;
            //fireIndex++;
            //if (fireIndex >= poolSize) fireIndex = 0;

            //2. 리스트 오브젝트풀링으로 총알발사         
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;
            //fireIndex++;
            //if (fireIndex >= poolSize) fireIndex = 0;


            //3. 리스트 오브젝트풀링으로 총알발사 (진짜 오브젝트 풀링)
            //if(bulletPool.Count > 0)
            //{
            //    GameObject bullet = bulletPool[0];
            //    bullet.SetActive(true);
            //    bullet.transform.position = firePoint.transform.position;
            //    bullet.transform.up = firePoint.transform.up;
            //    //오브젝트 풀에서 빼준다
            //    bulletPool.Remove(bullet);
            //}
            //else//오브젝트 풀이 비어서 총알이 하나도 없으니 풀크기를 늘려준다
            //{
            //    GameObject bullet = Instantiate(bulletFactory);
            //    bullet.SetActive(false);
            //    //오브젝트 풀에 추가한다
            //    bulletPool.Add(bullet);
            //}

            //4. 큐 오브젝트풀링 사용하기
            if (bulletPool.Count > 0)
            {
                GameObject bullet = bulletPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePoint.transform.position;
                bullet.transform.up = firePoint.transform.up;
            }
            else
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
            //GameObject bullet = Instantiate(bulletFactory);

            //bullet.transform.position = transform.position;
            //bullet.transform.position = firePoint.transform.position;
        }
    }

    public void FireRay()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            audio.Play();

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

    public void OnFireButtonClick()
    {
        GameObject bullet = Instantiate(bulletFactory);
        //bullet.transform.position = transform.position;
        bullet.transform.position = firePoint.transform.position;

        SceneMgr.Instance.LoadScene("StartScene");
    }
}
