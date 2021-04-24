using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_end_world : MonoBehaviour
{
    private Rigidbody2D rg;
    private PlayerController player;
    public float espera;
    private bool toca_mundo=true;
    private bool bandera = true;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        this.rg = GetComponent<Rigidbody2D>();
    }




    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("end_world") && bandera)
        {
            toca_mundo = false;
            bandera = false;
            if (!toca_mundo)
            {
                //Vector3 Scaler = this.transform.localScale;
                //if (rg.gravityScale < 0)
                //{
                //    rg.gravityScale = 2.5f;
                //    Scaler.y *= -1;
                //    this.transform.localScale = Scaler;
                //    player.saltoVelocidad *= -1;
                //}
                this.transform.position = player.posicion;
                player.damagePlayer(15);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("end_world"))
        {
            toca_mundo = true;
            bandera = true;
        }
    }

    IEnumerator esperando(float espera)
    {
        yield return new WaitForSeconds(espera);//pauso la ejecuancion
    }


}
