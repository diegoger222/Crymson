using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{

    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float danoGolpe;

    [SerializeField] private float tiempoEntreAtaques;

    [SerializeField] private float tiempoSiguienteAtaque;

    private Animator animator;

    private float distanciaJugador;
    private float distanciaDeteccion = 30;
    private bool vivo = true;
    private GameObject target;
    private int m_facingDirection = -1;
    private float attackDistance = 3;
    public float moveSpeed;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        if (vivo)
        {
            target = GameObject.FindGameObjectWithTag("Player");

            // hit =  Physics2D.Raycast(raycast.position, Vector2.left, raycastLength, raycastMask);
            // RaycastDebugger();

            distanciaJugador = Vector2.Distance(transform.position, target.transform.position);

            if (distanciaJugador < distanciaDeteccion) {
                if (distanciaJugador > attackDistance)
                {

                    Move();
                  
                    this.GetComponent<VidaJefe>().ActivarHudVida();


                }
                else if (attackDistance >= distanciaJugador && tiempoSiguienteAtaque <= 0)
                {
                    Golpe();
                    tiempoSiguienteAtaque = tiempoEntreAtaques;
                }
            }

            if (tiempoSiguienteAtaque > 0)
            {
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
           





            float inputX = transform.position.x - target.transform.position.x;

            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
            {
               // Debug.Log("HOLA");
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
             //   GetComponent<SpriteRenderer>().flipX = false;
                m_facingDirection = 1;
            }

            else if (inputX < 0)
            {
               // Debug.Log("HOLA");
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
              //  GetComponent<SpriteRenderer>().flipX = true;
                m_facingDirection = -1;
            }

        }
        
    }
    private void Golpe()
    {
        animator.SetTrigger("Atk1");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<BarraDeVida>().RestarVida(10);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
    public void Muerto()
    {
        vivo = false;
        animator.SetTrigger("Muerte");
        Invoke("AnimMuerte", 4);
    }

    void Move()
    {
       // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsTag("nor"));
       // anim.SetBool("canWalk", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("nor"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void AnimMuerte()
    {
        this.gameObject.SetActive(false);
    }
}
