using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    
    public void IniciarJuego() {
        //abrir juego
        Debug.Log("Se inicia el juego.");
        SceneManager.LoadScene("Game");
    }

    public void SalirJuego() {
        Application.Quit();
        Debug.Log("Ha salido del juego.");
    }
}
