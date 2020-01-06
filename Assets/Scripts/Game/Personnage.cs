using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerPhysics))]
public class Personnage : MonoBehaviour
{
    [SerializeField]
    private float speed = 8;
    [SerializeField]
    private float acceleration = 30;
    [SerializeField]
    private float jumpHeight = 12;
    [SerializeField]
    private float gravity = 20;

    [SerializeField]
    private float life = 3.0f;
    [SerializeField]
    private float maxLife = 3.0f;

    private Image lifebar;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Image lifeBar;

    [SerializeField]
    private float currentSpeed = 1.5f;
    [SerializeField]
    private float targetSpeed = 1.5f;

    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerPhysics = GetComponent<PlayerPhysics>();
        
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

    IEnumerator GetHit()
    {
        
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(0.05f);

            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
    }
    public void Hit()
    {
        life --;

        StartCoroutine(GetHit());

        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
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

        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = IncrementTowards(currentSpeed,targetSpeed,acceleration);

        if(playerPhysics.grounded)
        {
            amountToMove.y = 0;
            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                amountToMove.y = jumpHeight;

            }
        }

        

        if (Input.GetMouseButtonDown(0))
        {
            if(animator.GetBool("Equip"))
                animator.SetTrigger("Attack");
        }

        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime) ;
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));    

        if(currentSpeed != 0)
           gameObject.transform.localScale = new Vector3(  Mathf.Sign(currentSpeed), transform.localScale.y, transform.localScale.z);


        lifeBar.fillAmount = (life / maxLife);

    }


}
