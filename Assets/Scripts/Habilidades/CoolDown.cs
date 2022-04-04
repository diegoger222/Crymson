using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{

    public float coolDown;
    private float coolDownFill; //valor entre 0 y 1 de la imagen
    private float coolDownText;
    private bool iscoolDown;
    private Image fill;
    private Text textN;

    public List<GameObject> habilidades;
    private List<int> coolDowns = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<habilidades.Count; i++)
        {
            coolDowns.Add(habilidades[i].GetComponent<HabilidadMovimiento>().CoolDownTime());
        }
        coolDownText = coolDowns[0];
        coolDown = coolDowns[0];
        iscoolDown = false;
        coolDownFill = 1;
    }

    // Update is called once per frame
   void Update()
    {
        if (iscoolDown)
        {
            Debug.Log("hola");
          //  Debug.Log(fill.fillAmount);
          //  coolDownFill ;
            coolDownText -= Time.deltaTime;
            fill.fillAmount  -= 1 / coolDown * Time.deltaTime;
            textN.text = ((int)coolDownText).ToString();
            if(fill.fillAmount <= 0.0f)
            {
                fill.enabled = false;
                textN.enabled = false;
                ResetCoolDown();
            }
        }
    }

    public float  GetValorFill()
    {
        return coolDownFill;
    }

    public float GetValorText()
    {
        return coolDownText;
    }

    public bool ISCoolDown()
    {
        return iscoolDown;
    }
    public void StartTime(Image a,Text b)
    {
        fill = a;
        textN = b;
        Debug.Log(fill);
        textN.text = "P";
       
        iscoolDown = true;
       
    }

    public void ResetCoolDown()
    {
        iscoolDown = false;
        coolDownFill = 1;
        coolDownText = coolDown;
    }
}
