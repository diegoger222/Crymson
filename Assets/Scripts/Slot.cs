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
    private GameObject a;
    private int ax = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
        a = GameObject.FindGameObjectWithTag("InvPru");
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

    public void UseItem()  //D.R.M 23/03/22
    {
        switch (item.id)
        {
            case 1:
                player.GetComponent<BarraDeVida>().RestarVida(-30);       
              //  Debug.Log(ax);
                if ((ax - 1) <= 0)
                {

                   

                    a.GetComponent<Inventory>().RemoveItem(item, 1);
                    Destroy(gameObject);
                }
                else
                {
                    a.GetComponent<Inventory>().RemoveItem(item, 1);
                  // SetCount(ax - 1);
                }
               
                break;
            case 2:
                player.GetComponent<Experiencia>().GanarExperiencia(30);
                if ((ax - 1) <= 0)
                {
                    a.GetComponent<Inventory>().RemoveItem(item, 1);
                    Destroy(gameObject);
                }
                else
                {

                    a.GetComponent<Inventory>().RemoveItem(item, 1);
                  //  SetCount(ax - 1);
                }
                break;
            default:
                break;
        }
    }
}
