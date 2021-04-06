using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    //variables utilitarias
    public float velocidad = 0.5f;
    public float tiempo = 2;
    private float tiempo_espera;
    private int cont = 0;

    //referencias
    public Transform[] movimientos;

    void Start()
    {
        tiempo_espera = tiempo;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movimientos[cont].transform.position, velocidad * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, movimientos[cont].transform.position) < 0.1f)
        {
            if (tiempo_espera <= 0)
            {
                cont += (movimientos[cont] != movimientos[movimientos.Length-1]) ?  1: -cont;
                tiempo_espera = tiempo;
            }
            else
            {
                tiempo_espera -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        colision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D colision)
    {
        colision.collider.transform.SetParent(null);
    }
}
