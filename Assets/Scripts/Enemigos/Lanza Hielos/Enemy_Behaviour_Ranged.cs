using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour_Ranged : MonoBehaviour
{
    public float moveSpeed;
    public float attackDistance = 8;
    public bool uno = false;

    private GameObject target;
    private bool vivo = true;

    [SerializeField] private Transform Arrow;
    [SerializeField] private float tiempoSiguienteAtaque = 0;
    [SerializeField] private float tiempoEntreAtaques = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            float dist = Vector2.Distance(target.transform.position, gameObject.transform.position);

            if (dist < attackDistance && tiempoSiguienteAtaque <= 0)
            {
                rangedAttack();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            if (tiempoSiguienteAtaque > 0)
            {
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
        }
    }

    void rangedAttack()
    {
        Vector3 position = gameObject.transform.position;
        position.y += 1;
        Instantiate(Arrow, position, Quaternion.identity);
    }
}
