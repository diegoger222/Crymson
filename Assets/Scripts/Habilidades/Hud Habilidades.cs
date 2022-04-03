using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHabilidades : MonoBehaviour
{
    public Image imagenNormal;
    private GameObject habilidadesHUD;


    public class HabilU
    {
        public GameObject SlotIU { get; set; }
        public GameObject habilidadIU { get; set; }

    }
    public List<HabilU> ListaHabi;

 
    // Start is called before the first frame update
    void Start()
    {
        habilidadesHUD = GameObject.FindGameObjectWithTag("HudHabilidades"); //Obtenes el game object donde estan los marcos de habilidades
    }


    // Update is called once per frame
    void Update()
    {
        Iniciar();
        if (Input.GetKeyDown("l")){
            UsoHabilidad();
        }
    }
    public void Iniciar()
    {
        for(int a = 0; a < 6; a++)
        {
            //InterfazHabilidad prueba = new InterfazHabilidad(im)
            GameObject habi = habilidadesHUD.transform.GetChild(a).gameObject; // obtenemos la habilidad correspondiente al index actual (a) 
            ListaHabi.Add(new HabilU() { SlotIU = habi, habilidadIU = null });
            

           // Image imAux = habi.transform.GetChild(0).GetComponent<Image>(); // obtenemos donde ira la imagen
           // Image enAux = habi.transform.GetChild(1).GetComponent<Image>(); // obtenemos la imagen enfriamiento
           // Text textAux = habi.transform.GetChild(3).GetComponent<Text>(); //obtenemos el texto del enfriamiento
          //  InterfazHabilidad habil = new InterfazHabilidad(null,null,null,null);
            
          
        }
       
    }



    public void UsoHabilidad()
    {
        ListaHabi[0].SlotIU.transform.GetChild(3).GetComponent<Text>().text = "10"; //transform.GetChild(3).GetComponent<Text>() = 10;



    }

}