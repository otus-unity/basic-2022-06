using System.Collections;
using Helpers;
using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Health _health;

        [SerializeField]
        public Weapon _weapon;

        public bool IsAlive => _health.IsAlive;


        public IEnumerator Attack(Character attackedCharacter)
        {
            var weaponAnimationName = WeaponHelpers.GetAnimationNameFor(_weapon.Type);
            _animator.SetTrigger(weaponAnimationName);

            yield return new WaitForSeconds(2f);

            attackedCharacter._health.TakeDamage(_weapon.Damage);
        }
    }
}