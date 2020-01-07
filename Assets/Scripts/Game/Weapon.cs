using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float time;

    public GameObject prefab;

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
       firePoint = gameObject.transform.Find("FirePoint").transform;

        InvokeRepeating("Shoot",0.0f,time);
    }

    public void Shoot()
    {
        Instantiate(prefab,firePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
