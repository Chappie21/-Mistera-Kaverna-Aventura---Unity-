using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataform_Ac : MonoBehaviour
{

    //referencias
    private PlatformEffector2D efecto;

    //variables utilitarias
    public float tiempo_comienzo;
    public float tiempo_espera;
    private bool colisiona;

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.transform.CompareTag("Player"))
        {
            colisiona = true;
        }
    }

    private void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.transform.CompareTag("Player"))
        {
            colisiona = false;
        }
    }

    void Start()
    {
        efecto = GetComponent<PlatformEffector2D>();
    }


    void Update()
    {
        if (colisiona)
        {
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            {
                if (tiempo_espera <= 0)
                {
                    efecto.rotationalOffset = 180f;
                    tiempo_espera = tiempo_comienzo;
                }
                else
                {
                    tiempo_espera -= Time.deltaTime;
                }
            }
            else
            {
                tiempo_espera = tiempo_comienzo;
            }
        }
        else
        {
            if (efecto.rotationalOffset == 180f)
            {
                if (tiempo_espera <= 0)
                {
                    efecto.rotationalOffset = 0;
                    tiempo_espera = tiempo_comienzo;
                }
                else
                {
                    tiempo_espera -= Time.deltaTime;
                }
            }
        }
    }
}
