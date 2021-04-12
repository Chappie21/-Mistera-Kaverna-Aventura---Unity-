using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraConcentracion : MonoBehaviour
{

    public Slider slider;
    
    //ESTE CONTADOR AUMENTARA CADA SEGUNDO HASTA LLEGAR A 5, LLEGADO A 5 SE DECREMENTARA LA CONCENTRACION
    public static int contadorConcentracion = 0;

    // Start is called before the first frame update

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

    }

}
