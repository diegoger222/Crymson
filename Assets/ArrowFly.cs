using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFly : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    public Rigidbody2D rb2d;
    public float max_arrow_time;

    private Vector3 aim_to;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        aim_to = target.transform.position;
        aim_to.y += 1;

        //POR ALGUNA RAZÓN NO FUNCIONA LA ROTACIÓN DEL OBJETO
        /*if (target.transform.position.x > gameObject.transform.position.y)
        {
            gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
        }*/

        rb2d.AddForce((aim_to - gameObject.transform.position) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (max_arrow_time <= 0)
        {
            Destroy(gameObject);
        }
        if(max_arrow_time > 0)
        {
            max_arrow_time -= Time.deltaTime;
        }
    }
}
