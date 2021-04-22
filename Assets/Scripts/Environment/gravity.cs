using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    private Rigidbody2D cuerpo;
    public int gravedad;
    private PlayerController jugador;

   


    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.transform.CompareTag("Player"))
        {
            cuerpo= colision.transform.GetComponent<Rigidbody2D>();
            cuerpo.gravityScale = gravedad;
            Vector3 Scaler = colision.transform.localScale;
            Scaler.y *= -1;
            colision.transform.localScale = Scaler;
            jugador= colision.transform.GetComponent<PlayerController>();
            jugador.saltoVelocidad *= -1;
        }
    }


}
