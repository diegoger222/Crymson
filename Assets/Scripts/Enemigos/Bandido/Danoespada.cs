using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danoespada : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame


    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Pego al jugador");
            other.GetComponent<BarraDeVida>().RestarVida(0);
        }


    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {

    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("Pego al jugador");
    //         other.GetComponent<BarraDeVida>().RestarVida(0);
    //     }

    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {

    //     Debug.Log("salgo");

    // }
}
