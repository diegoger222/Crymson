using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AqueroElfo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float danoGolpe;

    [SerializeField] private float tiempoEntreAtaques;

    [SerializeField] private float tiempoSiguienteAtaque;

    public bool mover = false;

    public GameObject flecha;
    public GameObject spawnPoint;
    private Animator animator;

    private float distanciaJugador;
    private float distanciaDeteccion = 20;
    private bool vivo = true;
    private GameObject target;
    private int m_facingDirection = -1;
    private float attackDistance = 10;
    public float moveSpeed;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Andar", false);
    }
    private void Update()
    {

        if (vivo)
        {
            target = GameObject.FindGameObjectWithTag("Player");

            // hit =  Physics2D.Raycast(raycast.position, Vector2.left, raycastLength, raycastMask);
            // RaycastDebugger();

            distanciaJugador = Vector2.Distance(transform.position, target.transform.position);

            if (distanciaJugador < distanciaDeteccion)
            {
                if (distanciaJugador > attackDistance)
                {

                    if (mover)
                    {
                        Move();
                    }
                  


                }
                else if (attackDistance >= distanciaJugador)
                {
                    animator.SetBool("Andar", false);
                    if (tiempoSiguienteAtaque <= 0)
                    {


                       
                        Golpe();
                        tiempoSiguienteAtaque = tiempoEntreAtaques;
                    }
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
        GameObject flecha1;
        animator.SetTrigger("Ataque");

      //  flecha1 = Instantiate(flecha, spawnPoint.transform);
        GameObject.Instantiate(flecha, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
    }

  
   
    public void Muerto()
    {
        vivo = false;
        animator.SetTrigger("Muerte");
        Invoke("AnimMuerte", 4);
    }

    void Move()
    {
        animator.SetBool("Andar", true);
        // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsTag("nor"));
        // anim.SetBool("canWalk", true);
        
            Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
    }

    void AnimMuerte()
    {
        this.gameObject.SetActive(false);
    }
    public bool Direccion()
    {
        if(m_facingDirection == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
