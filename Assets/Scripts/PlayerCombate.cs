using System.Collections;
using UnityEngine;

public class PlayerCombate : MonoBehaviour
{
    private Rigidbody2D player;
    public Animator animator;
    public bool isAttacking;
    private float attackTime;
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !isAttacking)
        {
            attackTime = 1 / weapon.velocidadAtaque;
            weapon.Attack();
            isAttacking = true;
            StartCoroutine(finalizeAttacking(attackTime));
        }
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            if (player.velocity.y > 0)
            {
                player.velocity = Vector2.zero;
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }
        }
    }

    IEnumerator finalizeAttacking(float attackTime)
    {
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }
}