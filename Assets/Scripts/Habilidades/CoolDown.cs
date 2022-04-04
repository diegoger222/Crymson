using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{

    public float coolDown;
    private float coolDownFill; //valor entre 0 y 1 de la imagen
    private float coolDownText;
    private bool iscoolDown = false;
    private Image fill;
    private Text textN;

    public List<GameObject> habilidades;
    public List<float> coolDownVar = new List<float>();
    private List<float> coolDowns = new List<float>();
    private List<bool> isCoolDowns = new List<bool>();
    private List<Image> coolDownfills = new List<Image>();
    private List<Text> coolDowntexts = new List<Text>();
    public List<HudHabilidades.HabilU> ListaHabi = new List<HudHabilidades.HabilU>();
    //private List<GameObject> habilidadesIU = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        for(int i =0;i<habilidades.Count; i++)
        {
            coolDowns.Add(habilidades[i].GetComponent<HabilidadMovimiento>().CoolDownTime());
            isCoolDowns.Add(false);
        }
        coolDownText = coolDowns[0];
       // coolDown = coolDowns[0];
        //iscoolDown = false;
        coolDownFill = 1;
        */
    }

    // Update is called once per frame
   void Update()
    {

      //  if (iscoolDown)
        //{
          //  Debug.Log("hola");
          //  Debug.Log(fill.fillAmount);
          //  coolDownFill ;
          for(int z = 0;z< coolDowns.Count; z++)
            {
            Debug.Log(z);
                if (isCoolDowns[z])
                {
                
                    coolDownVar[z] -= Time.deltaTime;
                    coolDownfills[z].fillAmount -= 1 / coolDowns[z] * Time.deltaTime;
                    coolDowntexts[z].text = ((int)coolDownVar[z]).ToString();
                    if(coolDownfills[z].fillAmount <= 0.0f)
                    {
                        coolDownfills[z].enabled = false;
                        coolDowntexts[z].enabled= false;
                       ResetCoolDown(z);
                    }
                    // coolDowns[z] -= Time.deltaTime;


                }

            }
          /*
            coolDownText -= Time.deltaTime;
            fill.fillAmount  -= 1 / coolDown * Time.deltaTime;
            textN.text = ((int)coolDownText).ToString();
            if(fill.fillAmount <= 0.0f)
            {
                fill.enabled = false;
                textN.enabled = false;
                ResetCoolDown();
            }
          */
        //}
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

    public void ResetCoolDown(int z)
    {
        isCoolDowns[z] = false;
        //iscoolDown = false;
        coolDownfills[z].fillAmount = 1;
        // coolDownFill = 1;
        coolDownVar[z] = coolDowns[z];
       // coolDownText = coolDown;
    }
    public void SetHabilidadesIU(List<HudHabilidades.HabilU> ha)
    {
        ListaHabi = ha;
        for (int i = 0; i < ha.Count; i++)
        {
            coolDowns.Add(ha[i].habilidadIU.GetComponent<HabilidadMovimiento>().CoolDownTime());
            coolDownfills.Add(ha[i].SlotIU.transform.GetChild(1).GetComponent<Image>());
            coolDowntexts.Add(ha[i].SlotIU.transform.GetChild(3).GetComponent<Text>());
            coolDownVar.Add(coolDowns[i]);
           // coolDownFills
            isCoolDowns.Add(false);
        }
    }

    public void UsoHabilidad(int a)
    {
        isCoolDowns[a] = true;
    }
}
