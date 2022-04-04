using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHabilidades : MonoBehaviour
{
    public Image imagenNormal;
    private GameObject habilidadesHUD;
    public bool isCooldown = true;
    public GameObject auxCold;
    public List<GameObject> Habilidades = new List<GameObject>();
    public class HabilU
    {
        public GameObject SlotIU { get; set; }
        public GameObject habilidadIU { get; set; }

    }
    public List<HabilU> ListaHabi  = new List<HabilU>();

 
    // Start is called before the first frame update
    void Start()
    {
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
       
        if (Input.GetKeyDown("l")){
            UsoHabilidad(0);
        }
        if (Input.GetKeyDown("k"))
        {
            UsoHabilidad(1);
        }
    }
    public void Iniciar()
    {
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




