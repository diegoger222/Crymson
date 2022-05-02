using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCulling : MonoBehaviour
{
    public Camera cam;
    public LayerMask inMask;
    public LayerMask outMask;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.cullingMask = inMask;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.cullingMask = outMask;
        }
    }

}
