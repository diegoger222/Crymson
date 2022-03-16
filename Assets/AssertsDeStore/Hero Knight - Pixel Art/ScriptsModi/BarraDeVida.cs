using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    // Start is called before the first frame update
    public Image barraVida;
    private Animator m_animator;
    public float vidaActual = 80;
    public GameObject pantallaMuerte;
    public float vidaMaxima = 100;
    public bool invencible = false;
    private float damage;
    [SerializeField] bool m_noBlood = false;

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vidaActual / vidaMaxima;

        if (Input.GetKeyDown("1"))
        {

            RestarVida(10);
        }
        if (Input.GetKeyDown("2"))
        {

            RestarVida(-10);
        }

    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void RestarVida(float cantidad)
    {
        //damage = cantidad;
        if (!invencible && vidaActual > 0)
        {
     

            vidaActual -= cantidad;
            // StartCoroutine(FrenarNasus());
            m_animator.SetTrigger("Hurt");
            if (vidaActual  <= 0)
            {
                //sonidoJugador.StopPlayAllSounds();
                m_animator.SetBool("noBlood", m_noBlood);
                m_animator.SetTrigger("Death");
                Time.timeScale = 0;
              
                Debug.Log("Has muerto");
              


            }
            if (vidaActual > 100)
            {
                vidaActual = 100;
            }
        }
    }


    IEnumerator FrenarNasus() {
        invencible = true;
        yield return new WaitForSeconds(0.75f);   
        invencible = false;
    }
}