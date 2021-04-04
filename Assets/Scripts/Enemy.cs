using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20;
    public int vidaMaxima = 100;
    private int vidaActual;
    public GameObject deadParticulas;
    private Rigidbody2D enemyObj;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        enemyObj = GetComponent<Rigidbody2D>();
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
