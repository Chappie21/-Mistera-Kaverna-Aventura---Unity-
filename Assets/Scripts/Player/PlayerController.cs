using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    // Variables globales, si son públicas se pueden cambiar desde Unity
    public static int vidaMaxima = 100;
    public static int vidaActual = vidaMaxima;
    public float saltoVelocidad = 7f;
    public float maxVelocidad = 10f;
    private float movHorizontal = 0f;
    private float movVertical = 0f;
    private bool mirandoDerecha = true;
    public Animator animator;

    public static int concentracion = 0;
    private bool CollisionEnemy = false;
    private bool isSuelo;
    public bool dashing;
    public Transform checkSuelo;
    public float checkRadio;
    public LayerMask objetosSuelo;

    // Para comprobar si se ha atacado
    private PlayerCombate playerCombate;
    public GameObject deadParticulas;

    //posicion actual
    public Vector3 posicion;

    void Awake()
    {
        // Obtener el cuerpo del jugador
        vidaActual = vidaMaxima;
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerCombate = GetComponent<PlayerCombate>();
    }

    // En el update va el input del usuario
    void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal");
        // ^ si se presiona "a" o "flechaIzq" retorna -1, y si se presiona "d" o "flechaDer" retorna 1 
        movVertical = Input.GetAxisRaw("Vertical");

        this.animator.SetBool("Dashing", this.dashing);
    }

    // Aqui van los cambios al personaje
    void FixedUpdate()
    {
        isSuelo = Physics2D.OverlapCircle(checkSuelo.position, checkRadio, objetosSuelo);
        // ! Si el jugador colisiona con un enemigo, este no podrá moverse por un periodo de tiempo
        // Si se está atacando o haciendo dash, no mover al jugador
        if (!playerCombate.Attacking() && !this.dashing && !this.CollisionEnemy)
        {
            rigidBody2D.velocity = new Vector3(maxVelocidad * movHorizontal, rigidBody2D.velocity.y);
            if (movVertical > 0 && isSuelo == true)
            {
                rigidBody2D.velocity = new Vector3(maxVelocidad * movHorizontal, rigidBody2D.velocity.y);
                if (movVertical > 0 && isSuelo == true)
                {
                    rigidBody2D.velocity = Vector2.up * saltoVelocidad;
                }
                //necesario para player_end_world
                else if (isSuelo)
                {
                    posicion = this.transform.position;
                }

            }
            if (mirandoDerecha == true && rigidBody2D.velocity.x < 0)
            {
                Voltear();
            }
            if (mirandoDerecha == false && rigidBody2D.velocity.x > 0)
            {
                Voltear();
            }
        }
        if (mirandoDerecha == true && rigidBody2D.velocity.x < 0)
        {
            Voltear();
        }
        if (mirandoDerecha == false && rigidBody2D.velocity.x > 0)
        {
            Voltear();
        }
        // Actualizar los parámetros para que funcionen las animaciones
        if (playerCombate.Attacking())
        {
            animator.SetFloat("VelocidadX", 0);
            return;
        }
        this.animator.SetFloat("VelocidadY", rigidBody2D.velocity.y);
        animator.SetFloat("VelocidadX", Mathf.Abs(rigidBody2D.velocity.x));
        animator.SetBool("isSuelo", isSuelo);
    }

    void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 Scaler = transform.localScale; // Valores de x, y, z, para el scale
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void damagePlayer(int damageRecieved)
    {
        AudioMngr.Play("danoPlayer");
        vidaActual -= damageRecieved;
        if (vidaActual <= 0)
        {
            AudioMngr.Play("muertePlayer");
            Die();
        }
    }
    void Die()
    {
        Instantiate(deadParticulas, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }

    // Obtener hacia donde "Mira" el jugador
    public bool getVista()
    {
        return this.mirandoDerecha;
    }

    public float getPlayerAxis()
    {
        return this.movHorizontal;
    }

    public float getPlayerAxisY()
    {
        return this.movVertical;
    }

    public bool isInGround()
    {
        return isSuelo;
    }

    // establecer colision con enemigo del jugador
    public void SetEnemyCollision(bool collision)
    {
        this.CollisionEnemy = collision;
    }

    // Establecer tiempo de colision con enemigo evitando movimiento del jugador
    public void TempCollision(float Time)
    {
        this.SetEnemyCollision(true);
        Invoke("DisableCollision", Time);
    }

    // ! Quitar colision con enemigo
    private void DisableCollision()
    {
        this.SetEnemyCollision(false);
    }

}