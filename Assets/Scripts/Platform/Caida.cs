using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{

    public float tiempo_espera = 0.45f;
    public float fuerza = 0.5f;
    //referencias
    private Rigidbody2D cuerpo;
    private Vector3 posicion;

    //variables auxiliares
    private bool momento=false;

    void Start()
    {
        cuerpo= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (momento)
        {
            Vector3 nueva_pos = posicion + Random.insideUnitSphere * Time.deltaTime * fuerza;
            nueva_pos.y = transform.position.y;
            nueva_pos.z = transform.position.z;

            transform.position = nueva_pos;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.transform.CompareTag("Player"))
        {
            StartCoroutine(esperando(tiempo_espera));
        }
    }

    IEnumerator esperando( float espera)
    {
        posicion = transform.position;
        yield return new WaitForSeconds(espera);//pauso la ejecuancion antes de indicar que la plataforma no resistira
        momento = true;
        yield return new WaitForSeconds(1.0f);//pauso el tiempo antes de hacer que caiga la plataforma
        cuerpo.bodyType = RigidbodyType2D.Dynamic;
    }
}
