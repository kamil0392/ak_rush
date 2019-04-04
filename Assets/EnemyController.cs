using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    bool killingFlag = false;

    public float hurtRate;
    public float hurtValue;
    float nextHurtTime;
    GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

        gun = GameObject.Find("Gun").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (killingFlag)
        {
            if (hurtRate < Time.time)
            {
                gun.GetComponent<GunController>().hurt(hurtValue);
                hurtRate = Time.time + 1 / hurtRate;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyWall")
        {
            rb.velocity = new Vector2(0, 0);
            nextHurtTime = Time.time + 1 / hurtRate;
            killingFlag = true;
        }
    }
}
