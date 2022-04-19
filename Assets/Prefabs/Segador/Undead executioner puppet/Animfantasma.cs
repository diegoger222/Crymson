using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animfantasma : MonoBehaviour
{
    [SerializeField] private float movi;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int numero;
    private GameObject Segador;
    private Vector2 targetUp;
    private Vector2 targetBot;
    private bool up = true;
    private float auxp;
    private float varx;
    private float vary;
    // Start is called before the first frame update
    void Start()
    {

        
        Segador = GameObject.FindGameObjectWithTag("Segador");
        if(numero == 0)
        {
            varx = -0.392f;
            vary = 1.273f;
        }
        if(numero == 1)
        {
            varx = 0.18f; //-0.18f
            vary = 1.5f; //0.435f
        }
        if (numero == 2)
        {
            varx = 1.163f;
            vary = 1.37f;
        }

        //targetUp = new Vector2(Segador.transform.position.x - 0.392f, Segador.transform.position.y + 0.273f + movi);
        //targetBot = new Vector2(Segador.transform.position.x - 0.392f, Segador.transform.position.y + 0.273f - movi);

    }

    // Update is called once per frame
    void Update()
    {

        targetUp = new Vector2(Segador.transform.position.x + varx, Segador.transform.position.y + vary + movi);
        targetBot = new Vector2(Segador.transform.position.x + varx, Segador.transform.position.y + vary - movi);

        if (up)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetUp, moveSpeed * Time.deltaTime);
          
            auxp = transform.position.y;

            if (transform.position.y >= targetUp.y)
            {
                transform.position = new Vector2(Segador.transform.position.x + varx, auxp);
                up = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetBot, moveSpeed * Time.deltaTime);
            auxp = transform.position.y;
            if (transform.position.y <= targetBot.y)
            {

                transform.position = new Vector2(Segador.transform.position.x + varx, auxp);
                up = true;
            }
        }   
    }
}
