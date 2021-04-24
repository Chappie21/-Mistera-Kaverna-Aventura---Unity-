using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int damage = 20;
    public int vidaMaxima = 100;
    private int vidaActual;
    public GameObject deadParticulas;
    private Rigidbody2D enemyObj;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        enemyObj = GetComponentInParent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();

    }

    public void RecibirAtaque(int damage)
    {
        vidaActual -= damage;
        Debug.Log($"Vida enemigo = {vidaActual}");
        if (vidaActual <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deadParticulas, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
