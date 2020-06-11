using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDamage : MonoBehaviour
{
    private const string bulletTag = "Bullet";

    private float hp = 50.0f;
    private float initHp = 50.0f;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0, 2.2f, 0);
    private Canvas UICanvas;
    private Image HpBarImage;

    // Start is called before the first frame update
    void Start()
    {
        SetHpBar();   
    }

    private void SetHpBar()
    {
        UICanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, UICanvas.transform);
        HpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<BossHpBar>();
        _hpBar.targetTr = this.gameObject.transform;
        _hpBar.offset = hpBarOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag==bulletTag)
        {
            
            collision.gameObject.SetActive(false);
            hp -= collision.gameObject.GetComponent<Bullet>().damage;
           
            HpBarImage.fillAmount = hp / initHp;

            if (hp<=0.0f)
            {
                
                Destroy(gameObject);
            }
        }
    }
    
}
