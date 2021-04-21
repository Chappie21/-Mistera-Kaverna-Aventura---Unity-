using System.Collections;
using UnityEngine;

public class PlayerCombate : MonoBehaviour
{
    private Rigidbody2D player;
    public Animator animator;
    public bool isAttacking;
    private float attackTime;
    private AnimatorOverrideController animatorOverrideController;
    private WeaponSwitch weaponContainer;
    private Weapon activeWeapon;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        weaponContainer = GetComponentInChildren<WeaponSwitch>();
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }
    private void Update()
    {
        activeWeapon = weaponContainer.activeWeapon.GetComponent<Weapon>();
        attackTime = 1 / activeWeapon.velocidadAtaque;
        if (Input.GetButton("Fire1") && !isAttacking)
        {
            animatorOverrideController["AtaquePorDefecto"] = activeWeapon.animationClip;
            activeWeapon.Attack();
            isAttacking = true;
            StartCoroutine(finalizeAttacking(attackTime));
        }
    }
    private void FixedUpdate()
    {
        if (isAttacking)
        {
            if (Mathf.Abs(player.velocity.y) > 0)
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