using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float time;

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
       firePoint = gameObject.transform.Find("FirePoint").transform;
    }

    public void Shoot()
    {

    }

    IEnumerator TimeBetweenShoot()
    {
        Shoot();
        yield return new WaitForSeconds(time);
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TimeBetweenShoot());
    }
}
