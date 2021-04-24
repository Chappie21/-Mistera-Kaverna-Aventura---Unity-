using System.Collections;
using UnityEngine;

public class PlayerCombate : MonoBehaviour
{
    private Rigidbody2D player;
    private PlayerController playerController;
    private float direction = 1f;
    private bool isAttacking = false;
    private float attackTime;
    private Animator animator;
    private AnimatorOverrideController animatorOverrideController;
    private WeaponSwitch weaponSwitch;
    private Weapon activeWeapon;
    public float attackImpulse;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        weaponSwitch = GetComponentInChildren<WeaponSwitch>();
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }
    private void Update()
    {
        activeWeapon = weaponSwitch.activeWeapon.GetComponent<Weapon>();
        attackTime = 1 / activeWeapon.velocidadAtaque;
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            animatorOverrideController["AtaquePorDefecto"] = activeWeapon.animationClip;
            activeWeapon.Attack();
            isAttacking = true;
            StartCoroutine(finalizeAttacking(attackTime));
        }
        // Dirección a empujar el jugador
        if (Mathf.Abs(playerController.getPlayerAxis()) > 0)
        {
            direction = playerController.getPlayerAxis();
        }
    }
    private void FixedUpdate()
    {
        if (isAttacking && !playerController.dashing)
        {
            player.velocity = new Vector2(direction * attackImpulse, player.velocity.y);
        }
    }
    IEnumerator finalizeAttacking(float attackTime)
    {
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }

    public bool Attacking()
    {
        return isAttacking;
    }
    public void dropWeapon(GameObject weapon)
    {
        foreach (var intWeapon in weaponSwitch.interactableWeapons)
        {
            if (intWeapon.name == weapon.name)
            {
                Vector2 randomDir = new Vector2(Random.Range(-1f, 1f) * 3, 5);
                GameObject droppedWeapon = Instantiate(intWeapon, new Vector2(player.transform.position.x, player.transform.position.y + 1), player.transform.rotation);
                droppedWeapon.GetComponent<Rigidbody2D>().AddForce(randomDir, ForceMode2D.Impulse);
            }
        }
    }
}