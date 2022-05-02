using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{

    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float danoGolpe;

    [SerializeField] private float tiempoEntreAtaques;

    [SerializeField] private float tiempoSiguienteAtaque;

    private Animator animator;
    public GameObject trampa;

    private float distanciaJugador;
    private float distanciaDeteccion = 5;
    private bool act = true;
    private GameObject target;
    private float attackDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        animator = trampa.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Player");
        distanciaJugador = Vector2.Distance(transform.position, target.transform.position);
        if (distanciaJugador < distanciaDeteccion)
        {
            if (distanciaJugador > attackDistance)
            {

                trampa.SetActive(true);

               


            }
            else if (attackDistance >= distanciaJugador && tiempoSiguienteAtaque <= 0)
            {
                Golpe();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
        }
        else
        {

        }
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    private void Golpe()
    {
        animator.SetTrigger("Atacar");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                
                colisionador.transform.GetComponent<BarraDeVida>().RestarVida(10);
            }
        }
    }

}
