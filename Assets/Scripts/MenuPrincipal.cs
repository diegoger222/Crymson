using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuPrincipal : MonoBehaviour
{
    private bool hayMando = false;
    [SerializeField] private GameObject botonIniciar; //hay que enlazar el código con el botón de iniciar juego

    void Start() {
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
        if (hayMando) { //esto destaca el primer botón. Sólo hay que enlazar el código con el de la interfaz
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(botonIniciar, new BaseEventData(eventSystem));
        } else Debug.Log("No hay mando");
    }



    public void IniciarJuego() {
        //abrir juego
        Debug.Log("Se inicia el juego.");
        SceneManager.LoadScene("PruebaAlexey");
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
