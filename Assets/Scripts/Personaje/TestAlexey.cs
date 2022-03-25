using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlexey : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickable"))
        {
            Item item = other.gameObject.GetComponent<ItemController>().item;
            if(item)
            {
                Debug.Log("I found: " + item.itemName);
                Inventory.instance.AddItem(item);

                other.gameObject.SetActive(false);
            }
        }
    }
}
