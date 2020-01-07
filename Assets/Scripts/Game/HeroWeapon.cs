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
        }

        if (c.tag == "MonsterFire")
        {
            c.GetComponent<Weapon>().Hit();
        }
    }

}
