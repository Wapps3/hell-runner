using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float time;

    public float life;
    public float lifeMax;

    public GameObject prefab;

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
       firePoint = gameObject.transform.Find("FirePoint").transform;

        InvokeRepeating("Shoot",0.0f,time);
    }

    IEnumerator GetHit()
    {

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(0.05f);

        gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

    public void Hit()
    {
        life--;
        StartCoroutine(GetHit());

        gameObject.transform.Find("Life").transform.GetChild(0).GetComponent<Image>().fillAmount = life / lifeMax;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
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
