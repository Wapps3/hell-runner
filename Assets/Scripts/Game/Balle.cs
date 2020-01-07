using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public float speed = 10.0f;

    private float lifeTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * speed ,0,0);

        lifeTime += Time.deltaTime;

        if (lifeTime > 5.0f)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            c.GetComponent<Personnage>().Hit();
        }

        Destroy(gameObject);
    }
}
