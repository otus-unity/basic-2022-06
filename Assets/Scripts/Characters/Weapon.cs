using System;
using UnityEngine;

namespace Characters
{
    [Serializable]
    public class Weapon
    {
        [SerializeField]
        private WeaponType _weaponType;

        [SerializeField]
        private int _damage;

        public int Damage => _damage;
    }
}