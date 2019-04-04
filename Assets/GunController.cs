using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    float currentHealth = 0.876f;

    GameObject rotationArea;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        rotationArea = GameObject.Find("RotationArea");
        healthText.text = ((int)(currentHealth * 100)).ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        Touch[] myTouches = Input.touches;

        for(int i=0;i<Input.touchCount;i++)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(myTouches[i].position);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider == rotationArea.GetComponent<BoxCollider2D>())
            {
                mouse_pos = myTouches[i].position;
                object_pos = Camera.main.WorldToScreenPoint(transform.position);
                mouse_pos.x = object_pos.x - mouse_pos.x;
                mouse_pos.y = object_pos.y - mouse_pos.y;
                angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }                               
    }

    public void hurt(float hurtValue)
    {
        currentHealth -= hurtValue;
        if (currentHealth < 0)
        {
            SceneManager.LoadScene("YouLose", LoadSceneMode.Single);
        }
        healthText.text = ((int)(currentHealth * 100)).ToString() + "%";
    }
}
