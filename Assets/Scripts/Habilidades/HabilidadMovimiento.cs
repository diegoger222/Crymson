using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HabilidadMovimiento : MonoBehaviour
{
 
            
        public Vector2 direction = new Vector2(1f, 0f);
        public float speed;
        public bool auxrot;
          public int cooldown;
        private Rigidbody2D rb2d;
        void Start()
        {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<HeroKnight_Modi>().Direccion())
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
        void Update()
        {
            rb2d.velocity = direction * speed;
        }

        public int CoolDownTime()
        {
        return cooldown;
     }
    private void OnTriggerEnter2D(Collider2D other)
    {/*
        if(other.tag == "Player")
        {
            other.GetComponent<BarraDeVida>().RestarVida(damage);
        }
        */
        if (other.CompareTag("Enemy"))
        {

            other.GetComponent<Vida>().RecibirDano(50);

            Destroy(gameObject);
        }
        if (other.CompareTag("Segador"))
        {
            other.GetComponent<VidaJefe>().RecibirDano(50);
            Destroy(gameObject);
        }


    }

}
