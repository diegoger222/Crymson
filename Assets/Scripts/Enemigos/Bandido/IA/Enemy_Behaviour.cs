using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region Public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    private BoxCollider2D hitboxespada;
    public GameObject espada;
    public GameObject heroKnight;
    #endregion

    #region Private variables
    private int m_facingDirection = -1;
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private bool vivo = true;
    #endregion

    void Awake()
    {
        intTimer = -1;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        hitboxespada = espada.GetComponent<BoxCollider2D>();
        hitboxespada.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (vivo)
        {
            target = GameObject.FindGameObjectWithTag("Player");

            if (inRange)
            {

                distance = Vector2.Distance(transform.position, target.transform.position);

                if (distance > attackDistance)
                {
                    Move();
                    // StopAttack(); /7aqui

                }
                else if (attackDistance >= distance)
                {

                    if ( intTimer <= 0)
                    {
                        Attack();
                    }
                    intTimer -= Time.deltaTime;
                }
            }

            if (inRange == false)
            {
                anim.SetBool("canWalk", false);
                // StopAttack();
            }

            float inputX = transform.position.x - target.transform.position.x;

            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                m_facingDirection = 1;
            }

            else if (inputX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                m_facingDirection = -1;
            }
        }
    }


    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LightBandit_Run"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void Muerto()
    {
        vivo = false;
    }
    void Attack()
    {
        anim.SetBool("Attack2", true);
        hitboxespada.enabled = true;
        // yield return new WaitForSeconds(0.1f);
        Debug.Log("Daño al enemigo");
        heroKnight.GetComponent<BarraDeVida>().RestarVida(15);
        Invoke("StopAttack", 0.8f); ///alknflñsadhnf jñkashfd ñahsdñlfahdñlfhasdlñkfhjjañokjfjh añlkjhj
        intTimer = timer;
        attackMode = true;

    }


    void StopAttack()
    {
        hitboxespada.enabled = false;
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack2", false);
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
            Move();
        }
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player" && distance > 1.5)
        {
            target = trig.gameObject;
            anim.SetBool("canWalk", false);
            inRange = false;
        }
    }

    // void RaycastDebugger()
    // {
    //     if (distance > attackDistance)
    //     {
    //         Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.red);
    //     }
    //     else if (attackDistance > distance)
    //     {
    //         Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.green);
    //     }
    // }
}
