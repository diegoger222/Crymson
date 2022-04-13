using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlexey : MonoBehaviour
{
    private bool canPickUp = false;
    private Collider2D pickUpCollider;
    private Item pickUpItem;
    public GameObject dialog;

    private void Update()
    {
        if (canPickUp && Input.GetKeyDown("f"))
        {
            Inventory.instance.AddItem(pickUpItem);
            pickUpCollider.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickable")) { 
            Item item = other.gameObject.GetComponent<ItemController>().item;
            if(item)
            {
                canPickUp = true;
                pickUpCollider = other;
                pickUpItem = item;
            }
            dialog.SetActive(true);
        }

        if (other.CompareTag("Tutorial"))
        {
            DialogueTrigger trigger = other.gameObject.GetComponent<DialogueTrigger>();
            other.gameObject.SetActive(false);
            trigger.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickable"))
        {
            canPickUp = false;
            dialog.SetActive(false);
        }
    }
    
}
