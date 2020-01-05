using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeapon : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Monster")
        {
            c.GetComponent<Ennemy>().Hit();
            Debug.Log("Alo ?");
        }
    }

}
