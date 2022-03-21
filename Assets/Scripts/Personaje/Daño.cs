using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public int damage = 30;
    public float stunSec = 1.5f;


    // Update is called once per frame



    private void OnTriggerEnter2D(Collider2D other)
    {/*
        if(other.tag == "Player")
        {
            other.GetComponent<BarraDeVida>().RestarVida(damage);
        }
        */
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<Vida>().RecibirDaño(30);
        }
     

    }
}
