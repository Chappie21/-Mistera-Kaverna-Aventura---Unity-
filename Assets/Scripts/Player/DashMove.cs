using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D body;
    public float DashDuration;
    public float DashVelocityX;
    public float DashVelocityY;
    private float dashTime;
    private PlayerController player;
    private int directionX;
    private int directionY;
    private float coolDown = 0;
    public float dashCooldown;

    private TrailRenderer trail;


    void Start()
    {
        this.body = GetComponentInParent<Rigidbody2D>();
        this.player = GetComponentInParent<PlayerController>();
        this.trail = GetComponent<TrailRenderer>();

        this.dashTime = this.DashDuration;
        this.trail.enabled = false;
    }

    private void FixedUpdate()
    {
        // Realizar dash siempre y cuando no este en couldown
        if (this.coolDown <= 0)
        {
            // ! Direccionar dash siempre y cuando *no se este en dash previo*
            if (!this.player.dashing)
            {

                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.K))
                {

                    Physics2D.IgnoreLayerCollision(6, 8, true);
                    this.player.dashing = true;
                    this.trail.enabled = true;
                    // Obtener movimiento direccional del jugador
                    int movX = (int)this.player.getPlayerAxis();
                    int movY = (int)this.player.getPlayerAxisY();

                    // Lo que estaba antes aquí hace lo mismo que esto
                    this.directionX = movX;
                    this.directionY = movY;
                    /*
                        En caso de que el jugador está quieto y en el suelo,
                        se realizará el dash a donde esté "Mirando"
                    */
                    if (this.directionX == 0 && player.isInGround())
                    {
                        if (player.getVista())
                        {
                            directionX = 1;
                        }
                        else
                        {
                            directionX = -1;
                        }
                    }
                    if (this.directionY == 0 && !player.isInGround())
                    {
                        directionY = 1;
                    }
                }
            }
            else
            {
                // * reiniciar dash
                if (this.dashTime <= 0)
                {
                    Physics2D.IgnoreLayerCollision(6, 8, false);

                    this.dashTime = this.DashDuration;
                    this.body.velocity = Vector2.zero;
                    this.player.dashing = false;
                    this.trail.enabled = false;
                    this.coolDown = this.dashCooldown;
                }
                else
                {

                    this.dashTime -= Time.deltaTime;
                    this.body.velocity = new Vector2(this.directionX * this.DashVelocityX, this.directionY * this.DashVelocityY);

                }

            }
        }
        else
        {
            this.coolDown -= Time.deltaTime; // restar tiempo de couldwon
        }

    }

}
