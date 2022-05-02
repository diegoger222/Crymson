using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = false;
    public bool isOneWayLeft = false;
    public bool isOneWayRight = false;
    
    private DialogueTrigger dialogueTrigger;
    private bool canInteract = false;
    private Vector3 direction;
    
    public Item key;
    public GameObject pickupDialogue;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Update()
    {
        if (canInteract && Input.GetButtonDown("CogerItem"))
        {
            if (isLocked && Inventory.instance.RemoveItem(key, 1))
            {
                if(Inventory.instance.RemoveItem(key, 1));
                    gameObject.SetActive(false);
            }
            else if(isOneWayRight && direction.x > 0)
            {
                gameObject.SetActive(false);
            }else
            {
                dialogueTrigger.TriggerDialogue();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            direction = transform.InverseTransformPoint(other.transform.position);
            canInteract = true;            
        }
        pickupDialogue.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        canInteract = false;
        pickupDialogue.SetActive(false);
    }
}
