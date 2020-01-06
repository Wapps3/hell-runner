using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 8;
    [SerializeField]
    private float acceleration = 30;
    [SerializeField]
    private float gravity = 20;

    [SerializeField]
    private float currentSpeed = 1.5f;
    [SerializeField]
    private float targetSpeed = 1.5f;

    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float life = 5.0f;
    [SerializeField]
    private float maxLife = 5.0f;

    float r;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerPhysics = GetComponent<PlayerPhysics>();

        StartCoroutine(RandomDirection());
    }

    private float IncrementTowards(float n, float target, float accel)
    {
        if (n == target)
            return n;
        else
        {
            float dir = Mathf.Sign(target - n);  //must n be increased or decrease to get closer to target
            n += accel * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    IEnumerator RandomDirection()
    {
        bool run = true;
        while(run == true)
        {
            r = Random.Range(-1.0f, 1.0f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerPhysics.movementStop)
        {
            targetSpeed = 0;
            currentSpeed = 0;
        }

        targetSpeed = r * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        if (playerPhysics.grounded)
        {
            amountToMove.y = 0;
        }

        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(0));

        if( Random.Range(0.0f,1.0f) > 0.8f)
            animator.SetTrigger("Attack");

        if (currentSpeed != 0)
            gameObject.transform.localScale = new Vector3( Mathf.Sign(currentSpeed),transform.localScale.y,transform.localScale.z );
        



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

        Debug.Log("vie du monstre = " + life);
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            c.GetComponent<Personnage>().Hit();
        }
    }

}
