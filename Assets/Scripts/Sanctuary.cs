using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanctuary : MonoBehaviour
{
    private bool canInteract;

    public GameObject pickupDialogue;
    public GameObject checkDialogue;
    public GameObject statsDialogue;
    public Item poti;
    public Item fragment;

    void Start()
    {
        
    }


    void Update()
    {
        if (canInteract && Input.GetButtonDown("CogerItem"))
        {
            checkDialogue.SetActive(true);
            pickupDialogue.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
        pickupDialogue.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        pickupDialogue.SetActive(false);
    }

    public void ExitDialogue()
    {
        checkDialogue.SetActive(false);
    }

    public void Rest()
    {
        checkDialogue.SetActive(false);
        
        while (Inventory.instance.AddItem(poti));
    }

    public void Mejorar()
    {
        checkDialogue.SetActive(false);
        if(Inventory.instance.RemoveItem(fragment, 1))
        {
            Inventory.instance.IncreaseMaxPot();
        }else
        {
            GetComponent<DialogueTrigger>().TriggerDialogue(0, 0);
        }
    }

    public void Subir()
    {
        checkDialogue.SetActive(false);
        if (true)
        {
            statsDialogue.SetActive(true);
        }else
        {
            GetComponent<DialogueTrigger>().TriggerDialogue(1, 1);
        }
    }

}
