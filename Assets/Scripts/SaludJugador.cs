using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaludJugador : MonoBehaviour
{

    public Image RellenoCorazon;

    float cantidadLlenado;
    void Update()
    {
        cantidadLlenado = (PlayerController.vidaActual + 0.0f) / (PlayerController.vidaMaxima + 0.0f);
        RellenoCorazon.fillAmount = cantidadLlenado;
    }
}
