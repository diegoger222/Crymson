using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHabilidades : MonoBehaviour
{
    public Image imagenNormal;
    private GameObject habilidadesHUD;
    public bool isCooldown = true;

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
        ListaHabi[0].SlotIU.transform.GetChild(3).GetComponent<Text>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown("l")){
            UsoHabilidad(0,50);
        }
    }
    public void Iniciar()
    {
        for(int a = 0; a < 6; a++)
        {
            //InterfazHabilidad prueba = new InterfazHabilidad(im)
            GameObject habi = habilidadesHUD.transform.GetChild(a).gameObject; // obtenemos la habilidad correspondiente al index actual (a) 
      // Debug.Log(habi);

          HabilU aux = new HabilU() { SlotIU = habi,habilidadIU =null };
            ListaHabi.Add(aux);
            

           // Image imAux = habi.transform.GetChild(0).GetComponent<Image>(); // obtenemos donde ira la imagen
           // Image enAux = habi.transform.GetChild(1).GetComponent<Image>(); // obtenemos la imagen enfriamiento
           // Text textAux = habi.transform.GetChild(3).GetComponent<Text>(); //obtenemos el texto del enfriamiento
          //  InterfazHabilidad habil = new InterfazHabilidad(null,null,null,null);
            
          
        }
       
    }



    public void UsoHabilidad(int nh,float cooldown)
    {
        ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>().enabled = true;
        ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>().text = "10"; //transform.GetChild(3).GetComponent<Text>() = 10;
      
        float auxFloat;
        //Image auxIma = ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>();
        //Text  auxText = ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>();
        //auxIma.enabled = true;
        auxFloat = 1 / cooldown * Time.deltaTime;

        while (isCooldown)
        {
            
           
            ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>().fillAmount -= auxFloat;
            ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>().text = ((int)(cooldown*auxFloat)).ToString();
            float a = ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>().fillAmount;
            Debug.Log(a);
            //poner una variable con Ienumerator para el coldown
            if (a<=0.0f)
            {
                ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>().fillAmount = 1;
                ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>().enabled = false;
                isCooldown = false;
            }
            /*
            if (ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>().fillAmount <= 0.0f) {
                ListaHabi[nh].SlotIU.transform.GetChild(1).GetComponent<Image>().fillAmount = 1;
                ListaHabi[nh].SlotIU.transform.GetChild(3).GetComponent<Text>().enabled = false;
                isCooldown = false;
            }*/
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


}
