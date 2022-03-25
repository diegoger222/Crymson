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
    private int ax = 0;

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
        ax = n;
    }

    public void UseItem()
    {
        switch (item.id)
        {
            case 1:
                player.GetComponent<BarraDeVida>().RestarVida(-30);       
                Debug.Log(ax);
                if ((ax - 1) <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    SetCount(ax - 1);
                }
               
                break;
            case 2:
                player.GetComponent<Experiencia>().GanarExperiencia(30);
                if ((ax - 1) <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    SetCount(ax - 1);
                }
                break;
            default:
                break;
        }
    }
}
