using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController player;
    private int damageP;
    private Color color;
    private Renderer render;
    public float PushX, PushY;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        this.rb = GetComponent<Rigidbody2D>();
        this.render = GetComponent<Renderer>();
        this.color = this.render.material.color;

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 && !this.player.dashing)
        {
            damageP = col.gameObject.GetComponent<Enemy>().damage;
            player.damagePlayer(damageP);

            this.player.TempCollision(0.5f); // Tiempo de collision en el cual el jugador no puedo moverse
            PushPlayer(col.transform);
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
    private void PushPlayer(Transform enemy)
    {
        if (enemy.transform.position.x > player.transform.position.x)
        {
            rb.AddForce(new Vector2(-PushX, PushY), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(PushX, PushY), ForceMode2D.Impulse);
        }
    }
}