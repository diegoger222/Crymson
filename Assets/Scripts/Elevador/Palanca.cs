using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Palanca : MonoBehaviour
{
    private bool aux = true;
    public GameObject Elevador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag== "Arma")
        {
            Elevador.GetComponent<Elevador>().Palanca();
            if (aux) {
               Elevador.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }

}
