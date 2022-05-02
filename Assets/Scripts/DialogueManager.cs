using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;
    private bool hayMando = false;
    [SerializeField] private GameObject botonContinuar; //hay que enlazar el código con el botón de continuar

    private void Start()
    {
        Debug.Log("Comprueba si hay mandos");
        string[] listaMandos = Input.GetJoystickNames();
        string mandos = "";
        for (int i = listaMandos.Length - 1; i >= 0; i--) {
            mandos += listaMandos[i];
            if (mandos.Length >= 10) {
                hayMando = true;
                Debug.Log("Hay mando");
                break;
            }
        }

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (hayMando) { //esto destaca el primer botón. Sólo hay que enlazar el código con el de la interfaz
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(botonContinuar, new BaseEventData(eventSystem));
        } else Debug.Log("No hay mando");

        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue, int first, int last)
    {
        if (hayMando)
        { //esto destaca el primer botón. Sólo hay que enlazar el código con el de la interfaz
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(botonContinuar, new BaseEventData(eventSystem));
        }
        else Debug.Log("No hay mando");

        dialogueBox.SetActive(true);
        sentences.Clear();

        for(int i = first; i <= last; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
