using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyAttacker : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed;

    private float moveDirection = 1;
    private bool grounded = true;

    private bool facingRight = true;
    private Rigidbody2D enemyRB;

    [Header("Jump Attacking")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;
    private Animator anim;

    private bool vivo = true;

    public float timer;
    private float intTimer;

    private bool inRange = false;

    private float distance;
    void Awake()
    {
        intTimer = -1;
        anim = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (vivo)
        {
            isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
            FlipTowardsPlayer();

            if (inRange)
            {
                if (intTimer <= 0)
                {
                    JumpAttack();
                }
                intTimer -= Time.deltaTime;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {

        Debug.Log(distance);
        if (trig.gameObject.tag == "Player")
        {
            inRange = true;
        }

        Debug.Log(inRange);
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if (trig.gameObject.tag == "Player" && distance > 3)
        {
            inRange = false;
        }
    }
    void JumpAttack()
    {
        if (isGrounded)
        {
            float playerPosition = player.position.x - transform.position.x;
            anim.SetTrigger("jump");
            Invoke("StopJumpAttack", 1f); ///alknflñsadhnf jñkashfd ñahsdñlfahdñlfhasdlñkfhjjañokjfjh añlkjhj
            intTimer = timer;
            if (playerPosition > 0)
            {
                enemyRB.AddForce(new Vector2(distance, jumpHeight), ForceMode2D.Impulse);
            }
            else{
                enemyRB.AddForce(new Vector2(-distance, jumpHeight), ForceMode2D.Impulse);
            }

        }
    }

    void StopJumpAttack()
    {
        anim.SetTrigger("idle");
    }
    void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition < 0 && !facingRight)
        {
            Flip();
        }
        else if (playerPosition > 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
    }

    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void Muerto()
    {
        vivo = false;
    }
}
