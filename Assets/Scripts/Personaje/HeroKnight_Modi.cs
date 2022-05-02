using UnityEngine;
using System.Collections;

public class HeroKnight_Modi : MonoBehaviour
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;
    [SerializeField] float m_rollForce = 6.0f;
    [SerializeField] bool m_noBlood = false;
    [SerializeField] GameObject m_slideDust;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private BoxCollider2D       m_collider;
    private Sensor_HeroKnight_Modi   m_groundSensor;
    private Sensor_HeroKnight_Modi   m_wallSensorR1;
    private Sensor_HeroKnight_Modi   m_wallSensorR2;
    private Sensor_HeroKnight_Modi   m_wallSensorL1;
    private Sensor_HeroKnight_Modi   m_wallSensorL2;
    private bool                m_isWallSliding = false;
    private bool                m_grounded = false;
    private bool                m_rolling = false;
    private bool                m_attacking = false;
    private int                 m_facingDirection = 1;
    private int                 m_currentAttack = 0;
    private float               m_timeSinceAttack = 0.0f;
    private float               m_delayToIdle = 0.0f;
    private float               m_rollDuration = 8.0f / 14.0f;

    private float               m_rollCurrentTime = 0f;
    private bool                hayMando = false;
    public GameObject menu;
    private BoxCollider2D hitboxespada;
    public GameObject espada;
    private bool invencible = false;
    private bool vivoPlayer = true;
    [SerializeField] private GameObject hud1;
    [SerializeField] private GameObject hud2;
    [SerializeField] private GameObject hud3;
    private bool hudAc = false;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Comprueba si hay mandos");
        string[] listaMandos = Input.GetJoystickNames();
        string mandos = "";
        for (int i = listaMandos.Length - 1; i >= 0; i--) {
            mandos += listaMandos[i];
            if (mandos.Length >= 10) {
                hayMando = true;
                Debug.Log("Hay mando");
                break;
            }
        }

        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight_Modi>();
        m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight_Modi>();
        m_wallSensorR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight_Modi>();
        m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight_Modi>();
        m_wallSensorL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight_Modi>();
        hitboxespada = espada.GetComponent<BoxCollider2D>();
        hitboxespada.enabled = false;

    }

    // (1 < this.GetComponent<Stamina>().ReturnStamina())  comprobar si hay stamina
    //this.GetComponent<Stamina>().UsarStamina(0.40f);   restar stamina
    // Update se llama una vez por frame
    void Update()
    {
        float GatilloIzquierdo = Input.GetAxis("GatilloI");
        if (vivoPlayer && !menu.activeSelf)
        {
            GetHudV();
            // Increase timer that controls attack combo
            m_timeSinceAttack += Time.deltaTime;

            // Increase timer that checks roll duration
            if (m_rolling)
                m_rollCurrentTime += Time.deltaTime;

            // Disable rolling if timer extends duration
            if (m_rollCurrentTime > m_rollDuration)
                m_rolling = false;

            //Check if character just landed on the ground
            if (!m_grounded && m_groundSensor.State())
            {
                m_grounded = true;
                m_animator.SetBool("Grounded", m_grounded);
            }

            //Check if character just started falling
            if (m_grounded && !m_groundSensor.State())
            {
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
            }

            // -- Handle input and movement --
            float inputX = Input.GetAxis("Horizontal");

            // Swap direction of sprite depending on walk direction
            if (!m_rolling && inputX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                espada.transform.rotation = Quaternion.Euler(0, 0, 0);
                m_facingDirection = 1;
            }

            else if (!m_rolling && inputX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                espada.transform.rotation = Quaternion.Euler(0, -180, 0);
                m_facingDirection = -1;
            }

            // Move (mando)
            if (!m_rolling && !m_animator.GetBool("IdleBlock"))
                m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

            //Set AirSpeed in animator
            m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

            // -- Handle Animations --
            //Wall Slide
            m_isWallSliding = (m_wallSensorR1.State() && m_wallSensorR2.State()) || (m_wallSensorL1.State() && m_wallSensorL2.State());
            m_animator.SetBool("WallSlide", m_isWallSliding);

            //Death
            if (Input.GetKeyDown("e") && !m_rolling)
            {
                m_animator.SetBool("noBlood", m_noBlood);
                m_animator.SetTrigger("Death");
            }

            //Hurt
            else if (Input.GetKeyDown("q") && !m_rolling)
                m_animator.SetTrigger("Hurt");

            //Attack (mando)
            else if (!(GatilloIzquierdo > 0.5f) && Input.GetButtonDown("Atacar") && m_timeSinceAttack > 0.20f && !m_rolling && (20 < this.GetComponent<Stamina>().ReturnStamina()) && !hudAc)
            {
                m_attacking = true;
                m_currentAttack++;
                hitboxespada.enabled = true;
                Invoke("DesactivarAtaque", 0.7f);
                this.GetComponent<Stamina>().UsarStamina(20f);
                // Loop back to one after third attack
                if (m_currentAttack > 3)
                    m_currentAttack = 1;

                // Reset Attack combo if time since last attack is too large
                if (m_timeSinceAttack > 1.0f)
                    m_currentAttack = 1;

                // Call one of three attack animations "Attack1", "Attack2", "Attack3"
                m_animator.SetTrigger("Attack" + m_currentAttack);

                // Reset timer
                m_timeSinceAttack = 0.0f;
            }

            // Block (mando)
            else if (!(GatilloIzquierdo > 0.5f) && Input.GetButtonDown("Bloquear") && !m_rolling)
            {
                m_animator.SetTrigger("Block");
                m_animator.SetBool("IdleBlock", true);
                this.GetComponent<BarraDeVida>().ActivarInmune();
            }

            else if (Input.GetButtonUp("Bloquear"))
            {
                m_animator.SetBool("IdleBlock", false);
                this.GetComponent<BarraDeVida>().DesactivarInmune();
            }
            // Roll (mando)
            else if (!(GatilloIzquierdo > 0.5f) && m_grounded && Input.GetButtonDown("Rodar") && !m_rolling && !m_isWallSliding && (5 < this.GetComponent<Stamina>().ReturnStamina()))
            {
                this.GetComponent<Stamina>().UsarStamina(30f);
                m_rolling = true;
                m_animator.SetTrigger("Roll");
                m_body2d.velocity = new Vector2(m_facingDirection * m_rollForce, m_body2d.velocity.y);
            }


            //Jump (mando)
            else if (!(GatilloIzquierdo > 0.5f) && Input.GetButtonDown("Saltar") && m_grounded && !m_rolling && (10 < this.GetComponent<Stamina>().ReturnStamina()))
            {
                this.GetComponent<Stamina>().UsarStamina(10f);
                m_animator.SetTrigger("Jump");
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                m_groundSensor.Disable(0.2f);
            }

            //Run
            else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            {
                // Reset timer
                m_delayToIdle = 0.05f;
                m_animator.SetInteger("AnimState", 1);
            }

            //Idle
            else
            {
                // Prevents flickering transitions to idle
                m_delayToIdle -= Time.deltaTime;
                if (m_delayToIdle < 0)
                    m_animator.SetInteger("AnimState", 0);
            }
            //Checks if the animation is attacking and prevents the character to move
            if (m_grounded)
            {
                if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
                {
                    m_body2d.velocity = Vector3.zero;
                }
            }
            //If it's rolling it has to be able to dash through enemies NO FUNCIONA DEL TODO. LA PRIMERA VEZ SÍ QUE ROLLEA, PERO EL RESTO NO
            if (m_rolling)
            {
                Debug.Log(m_collider.enabled);
                m_body2d.constraints = RigidbodyConstraints2D.FreezePositionY;
                m_collider.enabled = false;
            }
            else
            {
                m_body2d.constraints = RigidbodyConstraints2D.None;
                m_body2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                m_collider.enabled = true;
            }
        }
    }
    
    

    void FixedUpdate()
    {


    }
    // Animation Events
    // Called in slide animation.
    void AE_SlideDust()
    {
        Vector3 spawnPosition;

        if (m_facingDirection == 1)
            spawnPosition = m_wallSensorR2.transform.position;
        else
            spawnPosition = m_wallSensorL2.transform.position;

        if (m_slideDust != null)
        {
            // Set correct arrow spawn position
            GameObject dust = Instantiate(m_slideDust, spawnPosition, gameObject.transform.localRotation) as GameObject;
            // Turn arrow in correct direction
            dust.transform.localScale = new Vector3(m_facingDirection, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poti"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("SubidaNivel"))
        {
            this.GetComponent<Experiencia>().ExperienciaPermanente();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Projectile"))
        {
            if (!invencible)
            {
                gameObject.GetComponent<BarraDeVida>().RestarVida(15);
            }
            Destroy(other.gameObject);
        }
        if (!invencible)
        {

            StartCoroutine(FrenarNasus());
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Me choco contra el enemigo");
                this.GetComponent<BarraDeVida>().RestarVida(15);
            }


        }
        // if (other.CompareTag("enemySword"))
        // {
        //     Debug.Log("Me pega la espada");
        //     this.GetComponent<BarraDeVida>().RestarVida(200);
        // }
    }
    private void DesactivarAtaque()
    {
        hitboxespada.enabled = false;
    }

    public bool Direccion()
    {
        if (m_facingDirection == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MuerteP(bool a)
    {
        vivoPlayer = a;
    }

    IEnumerator FrenarNasus()
    {
        invencible = true;
        yield return new WaitForSeconds(1f);
        invencible = false;
    }

    public void GetHudV()
    {
        if (hud1.activeSelf || hud2.activeSelf || hud3.activeSelf)
        {
            hudAc = true;
        }
        else
        {
            hudAc = false;
        }


    }
}
