using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corvian : MonoBehaviour
{
    private int questState;
    private bool canInteract;
    private DialogueTrigger dialogueTrigger;

    public GameObject pickupDialogue;
    public Item[] rewards;
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
                    Inventory.instance.AddItem(rewards[reward]);
                    questState++;
                    break;
                case 1:
                    dialogueTrigger.TriggerDialogue(4, 4);
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
