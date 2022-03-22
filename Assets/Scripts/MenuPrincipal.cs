using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJuego() {
        //abrir juego
        Debug.Log("Se inicia el juego.");
    }

    public void SalirJuego() {
        Application.Quit();
        Debug.Log("Ha salido del juego.");
    }
}
