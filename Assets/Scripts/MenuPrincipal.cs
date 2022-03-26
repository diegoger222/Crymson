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
        StartCoroutine(espera());
    }
    IEnumerator espera() {
        yield return new WaitForSecondsRealtime(3.5f); //se espera 3.5 segundos
        Application.Quit();
        Debug.Log("Ha salido del juego.");
    }
}
