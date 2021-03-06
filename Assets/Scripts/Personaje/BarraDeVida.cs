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
    public float vidaActual = 50;
    public GameObject pantallaMuerte;
    public float vidaMaxima = 100;
    public bool invencible = false;
    public GameObject puntorevivir;
    private float damage;
    public Text text_poti;
    private int n_poti; //Potis actuales
    private int m_poti; //maximo potis
    private int ndefensa;
    public Image im_poti;
    [SerializeField] bool m_noBlood = false;
    //imagenfull poti a menos llena
    public Sprite b1;
    public Sprite b2;
    public Sprite b3;
    public Sprite b4;
    public Sprite b5;
    private float auxt;
   // [SerializeField] private float tiempoInmune;
  //  private float tiempoInmuneaux;
    private bool escudo = false;

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vidaActual / vidaMaxima;
        
        if (Input.GetKeyDown("g"))
        {
            
            RestarVida(10);
            
        }
        /*
        if (Input.GetKeyDown("2"))
        {

            MorePotis(1);

        }
        */
        //Curarse "frasco estus" (mando)
        if (Input.GetButtonDown("Curarse"))
        {
            if (n_poti > 0)
            {
                RestarVida(-10);
                n_poti -= 1;
                text_poti.text = n_poti.ToString();
                ActualizarImagenPoti();
            }
        }
        /*
        if (tiempoInmuneaux > 0)
        {
            tiempoInmuneaux -= Time.deltaTime;
        }
        else
        {
            escudo = false;
        }
        */
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        n_poti = 4;
        m_poti = 4;
        ndefensa = 0;
        text_poti.text = n_poti.ToString();
        ActualizarImagenPoti();
    }

    public void RestarVida(float cantidad)
    {
        //damage = cantidad;
        if (!invencible && vidaActual > 0 && !escudo)
        {
     

            vidaActual -= cantidad;
            // StartCoroutine(FrenarNasus());
            m_animator.SetTrigger("Hurt");
            if (vidaActual  <= 0)
            {
                //sonidoJugador.StopPlayAllSounds();
                m_animator.SetBool("noBlood", m_noBlood);
                m_animator.SetTrigger("Death");
                this.GetComponent<HeroKnight_Modi>().MuerteP(false);
                Invoke("Muerte", 2f);
                
              
                Debug.Log("Has muerto");
              


            }
            if (vidaActual > vidaMaxima)
            {
                vidaActual = vidaMaxima;
            }
        }
    }
    //parte de las potis

    public void ActivarInmune()
    {
       // tiempoInmuneaux = tiempoInmune;
        escudo = true;
    }

    public void DesactivarInmune()
    {
        escudo = false;
    }
    public void MorePotis(int numero)
    {
        n_poti += numero;
        m_poti += numero;
        text_poti.text = n_poti.ToString();
        ActualizarImagenPoti();
    }
    public void RecuperarPotis()
    {
        n_poti = m_poti;
        ActualizarImagenPoti();
    }

    public void ActualizarImagenPoti()
    {
        float a_n = n_poti;
        float a_m = m_poti;
        float a = a_n / a_m;
        if(a == 1f)
        {
            im_poti.sprite = b1;
        }else if (a >= 0.75f)
        {
            im_poti.sprite = b2;
        }else if(a>= 0.5f)
        {
            im_poti.sprite = b3;
        }else if (a > 0f)
        {
            im_poti.sprite = b4;
        }else if (a==0f)
        {
            im_poti.sprite = b5;
        }
    }


    
    private void Muerte()
    {
        auxt = Time.timeScale;
       // Time.timeScale = 0;
        Invoke("Teletrans", 2f);
    }

    private void Teletrans()
    {
        Time.timeScale = auxt;
        this.gameObject.transform.position = puntorevivir.transform.position;
        this.GetComponent<HeroKnight_Modi>().MuerteP(true);
        vidaActual = 100;
        m_animator.SetTrigger("Hurt");
    }

    public void SumarPuntosVida(int puntos)
    {
        float a = puntos;
        vidaMaxima += a;
    }

    public void SumarPuntosDefensa(int puntos)
    {
        ndefensa += puntos;
    }


    IEnumerator FrenarNasus() {
        invencible = true;
        yield return new WaitForSeconds(0.75f);   
        invencible = false;
    }

   


   
}
