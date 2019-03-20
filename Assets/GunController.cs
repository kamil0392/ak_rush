using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    GameObject rotationArea;

    // Start is called before the first frame update
    void Start()
    {
        rotationArea = GameObject.Find("RotationArea");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider == rotationArea.GetComponent<BoxCollider2D>())
        {
            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = object_pos.x - mouse_pos.x;
            mouse_pos.y = object_pos.y - mouse_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
                       
    }
}
