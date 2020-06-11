using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    private const string bulletTag = "Bullet";
    private const string bossTag = "Boss";

    private float initHp = 50.0f;
    public float currHp;

    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        currHp = initHp;   
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == bulletTag)
        {
            Destroy(coll.gameObject);

            currHp -= 1.0f;
            Debug.Log("Boss HP=" + currHp.ToString());

            if(currHp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
