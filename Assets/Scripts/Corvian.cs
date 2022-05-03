using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corvian : MonoBehaviour
{
    public int questState;
    private bool canInteract;
    private DialogueTrigger dialogueTrigger;

    public GameObject pickupDialogue;
    public Item[] rewards;
    public Item keyItem;
    private int reward;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    
    void Update()
    {
        if(canInteract && Input.GetButtonDown("CogerItem"))
        {
            switch(questState)
            {
                case 0:
                    dialogueTrigger.TriggerDialogue(0, 3);
                    Inventory.instance.AddItem(rewards[reward++]);
                    questState++;
                    break;
                case 1:
                    if(Inventory.instance.RemoveItem(keyItem, 1))
                    {
                        dialogueTrigger.TriggerDialogue(5, 5);
                        Inventory.instance.AddItem(rewards[reward]);
                        Debug.Log("A");
                        questState++;
                        break;
                    } else
                    {
                        dialogueTrigger.TriggerDialogue(4, 4);
                        break;
                    }
                case 2:
                    dialogueTrigger.TriggerDialogue(6, 6);
                    break;
                default:
                    break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        canInteract = true;
        pickupDialogue.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        canInteract = false;
        pickupDialogue.SetActive(false);
    }

}
