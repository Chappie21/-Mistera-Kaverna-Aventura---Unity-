using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject activeWeapon;
    private GameObject weaponContainer;
    public GameObject[] interactableWeapons;
    public PlayerCombate playerCombate;
    private GameObject[] weapons;
    private int totalWeapons;
    private int weaponActualIndex = 0;
    void Start()
    {
        playerCombate = GetComponentInParent<PlayerCombate>();
        weaponContainer = this.gameObject;
        totalWeapons = weaponContainer.transform.childCount;
        weapons = new GameObject[totalWeapons];
        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponContainer.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
    }
    public void grabbedWeapon(GameObject weapon)
    {
        foreach (var wp in weapons)
        {
            wp.SetActive(false);
        }
        for (int index = 0; index < weapons.Length; index++)
        {
            if (weapons[index].name == weapon.name)
            {
                playerCombate.dropWeapon(weapons[weaponActualIndex]);
                weaponActualIndex = index;
                break;
            }
        }
        weapons[weaponActualIndex].SetActive(true);
        activeWeapon = weapons[weaponActualIndex];
    }

}