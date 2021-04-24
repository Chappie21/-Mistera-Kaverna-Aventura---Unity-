using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rg;
    private PlayerController player;
    private int damageP;
    private Color color;
    private Renderer render;
    public float PushX, PushY;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        this.rg = GetComponent<Rigidbody2D>();
        this.render = GetComponent<Renderer>();
        this.color = this.render.material.color;

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 && !this.player.Dashing)
        {
            damageP = col.gameObject.GetComponent<Enemy>().damage;
            player.damagePlayer(damageP);

            this.player.TempCollision(0.7f); // Tiempo de collision en el cual el jugador no puedo moverse
            PushPlayer(col.collider.GetComponent<SpriteRenderer>().flipX); // ! empujar al jugador
            StartCoroutine("Invulnerable");
        }
    }
   
    private IEnumerator Invulnerable()
    {

        Physics2D.IgnoreLayerCollision(6, 8, true); // desactivar colisiones con enemigos
        this.color.a = 0.5f;
        this.render.material.color = this.color;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(6, 8, false); // reactivar colisiones con enemigos
        this.color.a = 1f;
        this.render.material.color = this.color;

    }

    // * Empujar al jugador según hacia donde esté mirando el enemigo
    private void PushPlayer(bool flipX)
    {

        if (!flipX)
        {
            this.rg.velocity = new Vector2(PushX, PushY); // empujar a la derecha
        }
        else
        {
            this.rg.velocity = new Vector2(-PushX, PushY); // empujar a la izquierda
        }

    }
}