using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.TransformDirection(new Vector2(speed, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag != "EnemyWall")
        {
            Destroy(gameObject);
        }        
    }
}
