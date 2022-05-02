using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public Vector2 direction = new Vector2(1f, 0f);
    public GameObject player;
    public float speed;
    public bool auxrot;
    public int cooldown;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        if (!(GameObject.FindGameObjectWithTag("Elfo").GetComponent<AqueroElfo>().Direccion()))
        {
            direction = new Vector2(1f, 0f);
            if (auxrot)
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
        else
        {
            direction = new Vector2(-1f, 0f);
            if (!auxrot)
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }


        rb2d = GetComponent<Rigidbody2D>();
    }
        //  player = GameObject.FindGameObjectWithTag("Player");
       // Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
       // this.transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
       // this.GetComponent<Rigidbody2D>().AddForce(targetPosition);
    

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {/*
        if(other.tag == "Player")
        {
            other.GetComponent<BarraDeVida>().RestarVida(damage);
        }
        */
        if (other.CompareTag("Player"))
        {

            other.GetComponent<BarraDeVida>().RestarVida(10);

            Destroy(gameObject);
        }
      

    }

    }
