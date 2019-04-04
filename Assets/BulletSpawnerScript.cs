using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour
{

    public GameObject prefab;
    AmmoController ammoController;
    // Start is called before the first frame update
    void Start()
    {
        ammoController = transform.parent.Find("AmmoController").gameObject.GetComponent<AmmoController>();
    }

    // Update is called once per frame
    public void Fire()
    {
        if (ammoController.removeAmmo())
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
        
    }
}
