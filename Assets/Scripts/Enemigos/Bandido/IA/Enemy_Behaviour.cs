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
    #endregion

    #region Private variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling ;
    private float intTimer;
    #endregion

    void Awake(){
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange){
            hit =  Physics2D.Raycast(raycast.position, Vector2.left, raycastLength, raycastMask);
            RaycastDebugger();
        }

        if(hit.collider !=null){
            EnemyLogic();
        }
        else if(hit.collider == null){
            inRange = false;
        }

        if(inRange == false){
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }


    void EnemyLogic(){
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance){
            Move();
            StopAttack();
        }
        else if( attackDistance >= distance ){
            Attack();
        }
        // && cooling == false
        if(cooling){
            anim.SetBool("Attack2", false);
        }
    }

    void Move(){
        anim.SetBool("canWalk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Heavy Bandit_Attack")){
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack(){
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack2", true);
    }

    void StopAttack(){
        cooling = false; 
        attackMode = false;
        anim.SetBool("Attack2", false);
    }
    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.tag =="Player"){
            target = trig.gameObject;
            inRange = true;
        }
    }

    void RaycastDebugger(){
        if(distance > attackDistance){
            Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.red);
        }
        else if( attackDistance > distance){
            Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.green);
        }
    }
}
