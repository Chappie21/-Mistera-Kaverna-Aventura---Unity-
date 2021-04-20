using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject activeWeapon;
    private GameObject weaponContainer;
    private GameObject[] weapons;
    private int totalWeapons;
    private int weaponActualIndex = 0;
    void Start()
    {
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && weaponActualIndex < totalWeapons - 1)
        {
            weapons[weaponActualIndex].SetActive(false);
            weaponActualIndex += 1;
            weapons[weaponActualIndex].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q) && weaponActualIndex > 0)
        {
            weapons[weaponActualIndex].SetActive(false);
            weaponActualIndex -= 1;
            weapons[weaponActualIndex].SetActive(true);
        }
        activeWeapon = weapons[weaponActualIndex];
    }
}