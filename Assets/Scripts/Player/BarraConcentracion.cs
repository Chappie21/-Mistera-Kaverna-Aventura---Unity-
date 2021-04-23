using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraConcentracion : MonoBehaviour
{

    public Slider slider;
    public GameObject avisoConcentracion;
    public AudioSource audioBarraConcentracionLlena;
    public AudioSource audioBarraConcentracionUsada;
    
    //ESTE CONTADOR AUMENTARA CADA SEGUNDO HASTA LLEGAR A 5, LLEGADO A 5 SE DECREMENTARA LA CONCENTRACION
    public static int contadorConcentracion = 0;
    private bool audioReproducido = false;

    // Start is called before the first frame update

    void Start(){
        avisoConcentracion.SetActive(false);
    }

    float proximoConteo = 0.0f;
    void Update(){
        while(PlayerController.concentracion>10){
            PlayerController.concentracion--;
        }
        slider.value = PlayerController.concentracion;

        if(Time.time > proximoConteo){
            proximoConteo = Time.time + 1.0f;
            if(contadorConcentracion<5){
                contadorConcentracion++;
            }

            if(contadorConcentracion==5){
                if(PlayerController.concentracion>0){
                    PlayerController.concentracion--;
                }
            }
        }
        if(PlayerController.concentracion==10){
            avisoConcentracion.SetActive(true);
            reproducirAudio();
        }
        else if(PlayerController.concentracion!=10){
            audioReproducido = false;
            avisoConcentracion.SetActive(false);
        }

        if(PlayerController.concentracion==10 && Input.GetKeyDown(KeyCode.V)){
            audioBarraConcentracionUsada.Play();
            PlayerController.vidaActual=PlayerController.vidaActual+20;
            if(PlayerController.vidaActual>=100){
                PlayerController.vidaActual=100;
            }
            PlayerController.concentracion=0;
        }

    }

    void reproducirAudio(){
        if (!audioReproducido) {
            audioReproducido = true;
            audioBarraConcentracionLlena.Play();
        }
    }

}
