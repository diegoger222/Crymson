using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private bool hayMando = false;
    public static bool pausado = false;
    public GameObject menuPausaUI;
    [SerializeField] private GameObject botonContinuar;
    // Start is called before the first frame update
    void Start()
    {
        menuPausaUI.SetActive(false);
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

    }

    void Update() {
        if (Input.GetButtonDown("Pausar")) {
            if (pausado) { //si está pausado continúa
                continuar();
            } else { //si no está pausado se pausa y muestra el menú
                menuPausaUI.SetActive(true);
                Time.timeScale = 0f;
                pausado = true;
                if (hayMando) { //esto destaca el primer botón. Sólo hay que enlazar el código con el de la interfaz
                    var eventSystem = EventSystem.current;
                    eventSystem.SetSelectedGameObject(botonContinuar, new BaseEventData(eventSystem));
                } else Debug.Log("No hay mando");
            }
        }
    }

    public void continuar() {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    public void salirMP() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

}
