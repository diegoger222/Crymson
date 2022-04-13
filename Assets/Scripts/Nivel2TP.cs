using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel2TP : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nivel2;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {/*
        if(other.tag == "Player")
        {
            other.GetComponent<BarraDeVida>().RestarVida(damage);
        }
        */
        if (other.CompareTag("Player"))
        {
            other.transform.position = nivel2.transform.position;
        }


    }
}
