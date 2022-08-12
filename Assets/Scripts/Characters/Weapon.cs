using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField]
    private WeaponType _weaponType;

    [SerializeField]
    private int _damage;

    public int Damage => _damage;
}