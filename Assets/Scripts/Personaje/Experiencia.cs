using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Experiencia : MonoBehaviour
{
    // Start is called before the first frame update

    public Text text_nivel;
    public Text text_exp;
    public Image barra_exp;
    public Text textoValorBarraExperiencia;
    //public Image pot_exp;
    private int act_nivel;
    private int exp_nivel; // lo que te cuesta subir de nivel base
    private int var_nivel; // experiencia extra que cuesta por cada nivel 
    private int exp_guar; // experiencia guardada
    private int exp_acomul; //experiencia acomulada
    private int puntos_skills;
    private int exp_perdi; //experiencia perdida al morir

    private int experienciaNecesaria;
    void Start()
    {
        act_nivel = 1;
        exp_nivel = 125; 
        var_nivel = 35;
        exp_guar = 0;
        exp_acomul = 120;
        puntos_skills = 0; 
        experienciaNecesaria = 125;
    }

    // Update is called once per frame
    void Update()
    {
        text_exp.text = exp_acomul.ToString();
        text_nivel.text = act_nivel.ToString();
    }

    public void ExperienciaPermanente()
    {
       
        exp_guar = exp_acomul;
        
        experienciaNecesaria = exp_nivel + var_nivel * (act_nivel - 1); //experiencia de nivel necesaria;
        while(exp_guar> experienciaNecesaria)
        {
            int aux_exp = exp_guar - experienciaNecesaria;
            act_nivel += 1; //subir nivel
            puntos_skills += 1; // un punto mas 
            barra_exp.fillAmount = 
            exp_acomul = aux_exp;
            exp_guar = 0;
            barra_exp.fillAmount = exp_acomul / experienciaNecesaria;
            textoValorBarraExperiencia.text = "" + exp_acomul.ToString() + " / " + experienciaNecesaria.ToString() + " XP";

        }
    }
    
    public void GanarExperiencia(int cantidad)
    {
        exp_acomul += cantidad;
        //actualizamos la barra de experiencia y el texto con la cantidad de dicha
        barra_exp.fillAmount = exp_acomul / experienciaNecesaria;
        textoValorBarraExperiencia.text = "" + exp_acomul.ToString() + " / " + experienciaNecesaria.ToString() + " XP";
        
    }
    
    //futuro codigo que genere las potis de exp cuando mueres
    public void GenerarPotiExp()
    { 
        
    }
}
