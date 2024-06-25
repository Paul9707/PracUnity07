using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    public Transform[] hans;
    private Weapon[] weapons = new Weapon[2];
    private GameObject[] weaponObjs = new GameObject[2];

    public void EquipWeapon(int index, Weapon weapon)
    {
        if (index > weapons.Length)
        {
            return;
        }
        weapons[index] = weapon;

        if (weaponObjs[index] != null)
        {
            Destroy(weaponObjs[index]);
            weaponObjs[index] = null;
        }

        // �Ű����� weapon�� null�� �ƴ� ���
        if (weapon != null) // ���� ������Ʈ ����
        {
            weaponObjs[index] = Instantiate(weapon.equipPrefab, hans[index]);
        }
    }
}
