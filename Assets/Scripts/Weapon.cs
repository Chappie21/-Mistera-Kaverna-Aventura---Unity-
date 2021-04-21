using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Tooltip("Daño del arma")] public int damage;
    [Tooltip("Usado como 1 / velocidadAtaque")] public float velocidadAtaque;
    public float rangoAtaque;
    public Animator animator;
    public AnimationClip animationClip;
    public Transform puntoAtaque;
    public LayerMask enemiesLayer;
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(puntoAtaque.position, rangoAtaque, enemiesLayer);
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<Enemy>().RecibirAtaque(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(puntoAtaque.position, rangoAtaque);
    }
}