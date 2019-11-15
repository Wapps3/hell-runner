using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    [SerializeField]
    private float speed = 6;
    [SerializeField]
    private float sprint = 1.5f;
    [SerializeField]
    private float jumpForce = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0,0);

        //Déplacement Gauche
        if (Input.GetKey(KeyCode.D) == true)
        {
            movement += new Vector2(1,0);
        }
        
        //Déplacement Droite
        if (Input.GetKey(KeyCode.Q) == true)
        {
            movement += new Vector2(-1,0);
        }

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            movement = movement * sprint;
        }

        movement = movement * speed;

        //Saut
        if (Input.GetKey(KeyCode.Space) == true)
        {
            movement += new Vector2(0,jumpForce);
        }

        //Temps
        movement = movement * Time.deltaTime;
        gameObject.transform.position += new Vector3(movement.x,movement.y,0);
        //gameObject.transform.Rotate(new Vector3(0, 0, 10 )); 
    }
}
