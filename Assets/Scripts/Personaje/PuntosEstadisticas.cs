using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosEstadisticas : MonoBehaviour
{


    private int puntosEnVida;
    private int puntosEnStamina;
    private int puntosEnDefensa;
    private int puntosEnDano;

    private int puntosDisponibles;
    private int puntosMaxDisponibles;
    private int puntosUsados;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubirPuntos() //esta funcion es llamada desde Experiencia cuando se sube de nivel para añadir puntos;
    {
        puntosDisponibles++;
        puntosMaxDisponibles++;
    }
    public void ResetPuntos()
    {
        puntosDisponibles = puntosMaxDisponibles;
        puntosUsados = 0;
        if (puntosEnVida > 0)
        {
            this.GetComponent<BarraDeVida>().SumarPuntosVida(-puntosEnVida);
            puntosEnVida = 0;
        }
        if(puntosEnStamina > 0)
        {
            this.GetComponent<Stamina>().SumarPuntosStamina(-puntosEnStamina);
            puntosEnStamina = 0;
        }
        if(puntosEnDefensa > 0)
        {
            this.GetComponent<BarraDeVida>().SumarPuntosDefensa(-puntosEnDefensa);
            puntosEnDefensa = 0;
        }
    }





    public void PuntoMasVida()
    {
        puntosEnVida++;
        puntosUsados++;
        puntosDisponibles--;
        this.GetComponent<BarraDeVida>().SumarPuntosVida(1);
    }

    public void PuntoMenosVida()
    {
        puntosEnVida--;
        puntosUsados--;
        puntosDisponibles++;
        this.GetComponent<BarraDeVida>().SumarPuntosVida(-1);
    }

    public void PuntoMasStamina()
    {
        puntosEnStamina++;
        puntosUsados++;
        puntosDisponibles--;
        this.GetComponent<BarraDeVida>().SumarPuntosVida(1);
    }

    public void PuntoMenosStamina()
    {
        puntosEnStamina--;
        puntosUsados--;
        puntosDisponibles++;
        this.GetComponent<BarraDeVida>().SumarPuntosVida(-1);
    }

    public void PuntoMasDefensa()
    {
        puntosEnDefensa++;
        puntosUsados++;
        puntosDisponibles--;
        this.GetComponent<BarraDeVida>().SumarPuntosDefensa(1);
    }

    public void PuntoMenosDefensa()
    {
        puntosEnDefensa--;
        puntosUsados--;
        puntosDisponibles++;
        this.GetComponent<BarraDeVida>().SumarPuntosDefensa(-1);
    }
    

    
}
