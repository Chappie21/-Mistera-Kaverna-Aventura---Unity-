using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public LayerMask enemiesLayer;
    public PlayerController player;
    private int damageP;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 && !this.player.Dashing)
        {
            damageP = col.gameObject.GetComponent<Enemy>().damage;
            player.damagePlayer(damageP);
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.left * 100);
        }
    }
}