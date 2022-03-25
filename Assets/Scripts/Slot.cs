using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text count;
    public Item item;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }

    public void DisableCounter()
    {
        count.enabled = false;
    }

    public void SetCount(int n)
    {
        count.text = n.ToString();
    }

    public void UseItem()
    {
        switch (item.id)
        {
            case 1:
                player.GetComponent<BarraDeVida>().RestarVida(-30);
                Destroy(gameObject);
                break;
            case 2:
                player.GetComponent<Experiencia>().GanarExperiencia(30);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
