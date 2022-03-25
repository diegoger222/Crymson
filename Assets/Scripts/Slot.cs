using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text count;
    public Item item;
    public GameObject player;


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
                //player.GetComponent<BarraDeVida>().RestarVida(-10);
                break;
            case 2:
                //player.GetComponent<Experiencia>().GanarExperiencia(10);
                break;
            default:
                break;
        }
    }
}
