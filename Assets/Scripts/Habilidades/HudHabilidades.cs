using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class HudHabilidades : MonoBehaviour
{
    public Image imagenNormal;
    private GameObject habilidadesHUD;
    public bool isCooldown = true;
    public GameObject auxCold;
    public List<GameObject> Habilidades = new List<GameObject>();
    private bool Mana;
    public int costeMana = 30;
    private bool hayMando = false;
    [SerializeField] private GameObject botonHabilidad1; //hay que enlazar el código con el botón
    public class HabilU
    {
        public GameObject SlotIU { get; set; }
        public GameObject habilidadIU { get; set; }

    }
    public List<HabilU> ListaHabi  = new List<HabilU>();

 
    // Start is called before the first frame update
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

        habilidadesHUD = GameObject.FindGameObjectWithTag("HudHabilidades"); //Obtenes el game object donde estan los marcos de habilidades
        Iniciar();
        for(int i = 0; i < ListaHabi.Count; i++)
        {
            ListaHabi[i].SlotIU.transform.GetChild(3).GetComponent<Text>().enabled = false;
            ListaHabi[i].SlotIU.transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
      
        auxCold.GetComponent<CoolDown>().SetHabilidadesIU(ListaHabi);
        
    }


    // Update is called once per frame
    void Update()
    {
        float GatilloIzquierdo = Input.GetAxis("GatilloI");
        /* if (GatilloIzquierdo > 0.5f) Debug.Log("Gatillo izquierdo apretado"); */ //¡¡Funciona!!
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            //Mando
            if (GatilloIzquierdo > 0.5f) { //para lanzar la habilidad con los botones A, X, Y y B
                if (Input.GetKeyDown("joystick button 0")) {
                    UsoHabilidad(0);
                }
                if (Input.GetKeyDown("joystick button 1")) {
                    UsoHabilidad(1);
                }
                if (Input.GetKeyDown("joystick button 2")) {
                    UsoHabilidad(2);
                }
                if (Input.GetKeyDown("joystick button 3")) {
                    UsoHabilidad(3);
                }
            }

            if (Input.GetKeyDown("1"))
            {
                
                UsoHabilidad(0);
               
            }
            if (Input.GetKeyDown("2"))
            {
                
                UsoHabilidad(1);
            }
            if (Input.GetKeyDown("3"))
            {
               
                UsoHabilidad(2);
            }
            if (Input.GetKeyDown("4"))
            {
                
                UsoHabilidad(3);
            }
            if (Input.GetKeyDown("5"))
            {
            
                UsoHabilidad(4);
            }
            if (Input.GetKeyDown("6"))
            {
              
                UsoHabilidad(5);
            }
        }
    }

    public void Habilidad1()
    {
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            UsoHabilidad(0);
        }
    }
    public void Habilidad2()
    {
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            UsoHabilidad(1);
        }
    }
    public void Habilidad3()
    {
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            UsoHabilidad(2);
        }
    }
    public void Habilidad4()
    {
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            UsoHabilidad(3);
        }
    }
    public void Habilidad5()
    {
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            UsoHabilidad(4);
        }
    }
    public void Habilidad6()
    {
        if (this.GetComponent<Mana>().ReturnMana() > costeMana)
        {
            UsoHabilidad(5);
        }
    }
    public void Iniciar()
    {
        if (hayMando) { //esto destaca el primer botón. Sólo hay que enlazar el código con el de la interfaz
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(botonHabilidad1, new BaseEventData(eventSystem));
        } else Debug.Log("No hay mando");

        for(int a = 0; a < 6; a++)
        {
            //InterfazHabilidad prueba = new InterfazHabilidad(im)
            GameObject habi = habilidadesHUD.transform.GetChild(a).gameObject; // obtenemos la habilidad correspondiente al index actual (a) 
      // Debug.Log(habi);

          HabilU aux = new HabilU() { SlotIU = habi,habilidadIU =Habilidades[a] };
            ListaHabi.Add(aux);
            

           // Image imAux = habi.transform.GetChild(0).GetComponent<Image>(); // obtenemos donde ira la imagen
           // Image enAux = habi.transform.GetChild(1).GetComponent<Image>(); // obtenemos la imagen enfriamiento
           // Text textAux = habi.transform.GetChild(3).GetComponent<Text>(); //obtenemos el texto del enfriamiento
          //  InterfazHabilidad habil = new InterfazHabilidad(null,null,null,null);
            
          
        }
       
    }
    



    public void UsoHabilidad(int nh)
    {

        if (!auxCold.GetComponent<CoolDown>().EnUso(nh))
        {
            ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>().enabled = true;
            ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>().enabled = true;
            this.GetComponent<Mana>().UsarMana(costeMana);
            if (nh == 0)
            {
                GameObject aux = ListaHabi[nh].habilidadIU;
                GameObject.Instantiate(aux, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
            }
            else
            {
                GameObject.Instantiate(ListaHabi[nh].habilidadIU, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
            }

            auxCold.GetComponent<CoolDown>().UsoHabilidad(nh);

        }
    }
        

    }

    /*
     public void UsarStamina(float cantidad)
    {
        if(currentStamina- cantidad >= 0)
        {
            currentStamina -= cantidad;

            if(regen != null) {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }


    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2f);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            yield return regenTick;
        }
    }
    */




