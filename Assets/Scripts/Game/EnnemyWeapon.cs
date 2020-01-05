using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeapon : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            c.GetComponent<Personnage>().Hit();
        }
    }
}
