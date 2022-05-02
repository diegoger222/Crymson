using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour_Ranged : MonoBehaviour
{
    public float moveSpeed;
    public float attackDistance = 8;
    public bool uno = false;

    private Vector3 position;
    private GameObject target;
    private bool vivo = true;
    private Quaternion rotation;

    private Animator anim;
    private float moveDirection = 1;
    private bool facingLeft = false;

    [SerializeField] Transform player;
    [SerializeField] private Transform Arrow;
    [SerializeField] private float tiempoSiguienteAtaque = 0;
    [SerializeField] private float tiempoEntreAtaques = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            target = GameObject.FindGameObjectWithTag("Player");

            FlipTowardsPlayer();

            float dist = Vector2.Distance(target.transform.position, gameObject.transform.position);

            if (dist < attackDistance && tiempoSiguienteAtaque <= 0)
            {
                rangedAttack();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            if (tiempoSiguienteAtaque > 0)
            {
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
        }
    }

    void rangedAttack()
    {
        position = gameObject.transform.position;
        rotation = Quaternion.identity;
        /*LA ROTACIÓN DE LA FLECHA NO FUNCIONA
        if (target.transform.position.x > gameObject.transform.position.y)
        {
            rotation = Quaternion.LookRotation(Vector3.right);
        }*/
        anim.SetTrigger("Attack");

        Invoke("DelayArrow", 0.81f);
        Invoke("StopAttack", 0f);
    }

    private void StopAttack()
    {
        anim.SetTrigger("Idle");
    }

    private void DelayArrow()
    {
        Instantiate(Arrow, position, rotation);
    }

    public void Muerto()
    {
        vivo = false;
        anim.SetTrigger("Death");
    }

    void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition < 0 && !facingLeft)
        {
            Flip();
        }
        else if (playerPosition > 0 && facingLeft)
        {
            Flip();
        }
    }
    void Flip()
    {
        moveDirection *= -1;
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }
}
