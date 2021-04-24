using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteractable : MonoBehaviour
{
    private PlayerController player;
    private WeaponSwitch weaponSwitch;
    public ParticleSystem grabbedParticles;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        weaponSwitch = player.GetComponentInChildren<WeaponSwitch>();
    }
    public void Collect()
    {
        Instantiate(grabbedParticles, this.transform.position, this.transform.rotation);
        gameObject.name = gameObject.name.Replace("(Clone)", "");
        weaponSwitch.grabbedWeapon(gameObject);
        Destroy(gameObject);
    }
}
