using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteractable : MonoBehaviour
{
    public AudioSource audioDropeoArma;
    private PlayerController player;
    private WeaponSwitch weaponSwitch;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        weaponSwitch = player.GetComponentInChildren<WeaponSwitch>();
    }
    public void Collect()
    {
        audioDropeoArma.Play();
        gameObject.name = gameObject.name.Replace("(Clone)", "");
        weaponSwitch.grabbedWeapon(gameObject);
        Destroy(gameObject);
    }
}
