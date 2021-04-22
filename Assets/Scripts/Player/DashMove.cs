using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour{
    

    private Rigidbody2D body;
    public float DashDuration;
    public float DashVelocity;
    private float dashTime;
    private PlayerController player;
    private int direction;
    private float MoveInput;
    private float couldown = 0;
    public float Timecouldown;


    void Start(){

        this.body = GetComponentInParent<Rigidbody2D>(); // obtenemos la instanacia deñ Rigidbody2D
        this.player = GetComponentInParent<PlayerController>(); // obtenemos la instancia del PlayerController

        this.dashTime = this.DashDuration;
    }

    private void FixedUpdate() {

        // relizar dash siempre y cuando no este en couldown
        if(this.couldown <= 0){

            // ! direccionar dash siempre y cuando *no se este en dash previo*
            if(!   this.player.Dashing){

                if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.K)){

                    Physics2D.IgnoreLayerCollision(6, 8, true);
                    this.player.Dashing = true;
                    
                    float movX = this.player.GetPlayerAxis();

                    /*
                        En caso de que el jugador no este direccionando en X a drake,
                        este realizará el dash a donde esté "Mirando"
                    */
                    if(movX == 0){
                        if(this.player.getVista()){
                            this.direction = 1;
                        }else{
                            this.direction = -1;
                        }
                    }else{

                        // En caso de movimiento Horizontal por parte del jugador
                        if(movX == 1){
                            this.direction = 1;
                        }else{
                            this.direction = -1;
                        }
                    }

                }

            }else{

                // * reiniciar dash
                if(this.dashTime <= 0){

                    Physics2D.IgnoreLayerCollision(6, 8, false);

                    this.dashTime = this.DashDuration;
                    this.body.velocity = Vector2.zero;
                    this.player.Dashing = false;
                    this.couldown = this.Timecouldown; // comenzar couldown
                }else{

                    this.dashTime -= Time.deltaTime;
                    this.body.velocity = new Vector2(this.direction * this.DashVelocity, this.body.velocity.y);
                    
                }

            }
        }else{
            this.couldown -= Time.deltaTime; // restar tiempo de couldwon
        }
        
    }

}
