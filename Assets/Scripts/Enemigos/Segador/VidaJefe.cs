using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJefe : MonoBehaviour
{

    [SerializeField] private float vida_Max;
    public Image vidaImagen;
    public Text vidaText;
    public GameObject generalVida;
    private float vidaActual;

    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vida_Max;
        vidaText.text = vidaActual.ToString() + "/" + vida_Max.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        vidaImagen.fillAmount = vidaActual / vida_Max;

    }

    public void RecibirDano(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            Invoke("DesactivarHudVida", 3);
            this.GetComponent<Combate>().Muerto();
            vidaText.text = "0" + "/" + vida_Max.ToString();
            deathSound.Play();
        }
        else
        {
            vidaText.text = vidaActual.ToString() + "/" + vida_Max.ToString();
        }
    }
    public void ActivarHudVida()
    {
        generalVida.SetActive(true);
    }

    public void DesactivarHudVida()
    {
        generalVida.SetActive(false);
    }



}
