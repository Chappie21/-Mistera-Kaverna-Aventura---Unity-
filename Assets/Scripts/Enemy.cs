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
    public Animator animator;
    public AIPath path;

    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        enemyObj = GetComponentInParent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        
    }
    
    void Update() {

        this.Direction(); // Cambiar direccion del
        this.animator.SetFloat("Velocity", Mathf.Abs(this.path.desiredVelocity.x));

    }

    public void RecibirAtaque(int damage)
    {
        vidaActual -= damage;
        Debug.Log($"Vida enemigo = {vidaActual}");
        PlayerController.concentracion++;
        BarraConcentracion.contadorConcentracion=0;
        if (vidaActual <= 0)
        {
            Die();
        }
    }

    // Activar flipX del enemigo en base a su deplazamiento horizontal (persecucion)
    private void Direction(){

        if(this.path.velocity.x >= 0.1){
           this.sprite.flipX = false;
        }else if(this.path.velocity.x <= -0.1){
            this.sprite.flipX = true;
        }

    }

    void Die()
    {
        Instantiate(deadParticulas, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
