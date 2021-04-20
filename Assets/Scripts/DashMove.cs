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


    void Start(){

        this.body = GetComponentInParent<Rigidbody2D>(); // obtenemos la instanacia deñ Rigidbody2D
        this.player = GetComponentInParent<PlayerController>(); // obtenemos la instancia del PlayerController

        this.dashTime = this.DashDuration;
    }

   
    void Update(){
        
    }

    private void FixedUpdate() {

         if(!this.player.Dashing){

            if(Input.GetKeyDown(KeyCode.Z)){

                this.player.Dashing = true;
                
                if(this.player.getVista()){
                    this.direction = 1;
                }else{
                    this.direction = -1;
                }

            }

        }else{

            if(this.dashTime <= 0){
                this.dashTime = this.DashDuration;
                this.body.velocity = Vector2.zero;
                this.player.Dashing = false;
            }else{

                this.dashTime -= Time.deltaTime;
                this.body.velocity = new Vector2(this.direction * this.DashVelocity, this.body.velocity.y);
                
            }

        }
        
    }

}
