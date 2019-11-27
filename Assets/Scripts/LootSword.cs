using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSword : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            animator.SetBool("Take", true);

            c.GetComponent<Animator>().SetBool("Equip", true);
        }
    }
}
