using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D m_body2d;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
