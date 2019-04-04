using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{

    int currentMagzCount;
    ArrayList ammoList;
    Vector3 initialPos = new Vector3(-8.57f, 4.65f, 0);
    float offset = 0.5f;
    int maxAmmo = 20;


    public GameObject prefab;
    public Text magzText;



    void Start()
    {
        currentMagzCount = 5;
        ammoList = new ArrayList();
        addAmmo();
        

        magzText.text = "x" + currentMagzCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addAmmo()
    {
        if (getMag())
        {
            
            while (ammoList.Count < maxAmmo)
            {
                Vector3 spawnPos = new Vector3(initialPos.x + ammoList.Count * offset, initialPos.y, 0f);
                GameObject newlyCreated = Instantiate(prefab, spawnPos, Quaternion.identity);

                ammoList.Add(newlyCreated);
            }            
        }
    }

    public bool removeAmmo()
    {
        if (ammoList.Count > 0)
        {
            GameObject o = (GameObject) ammoList[ammoList.Count - 1];
            Destroy(o);
            ammoList.RemoveAt(ammoList.Count - 1);
            return true;
        }
        return false;
    }

    bool getMag()
    {
        if (currentMagzCount > 0 && ammoList.Count < maxAmmo)
        {
            currentMagzCount = currentMagzCount - 1;
            magzText.text = "x" + currentMagzCount.ToString();
            return true;
        }
        return false;
    }
}
