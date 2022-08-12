using System.Collections;
using Helpers;
using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        public int Health;

        [SerializeField]
        public Weapon _weapon;

        public bool IsAlive => Health > 0;


        public IEnumerator Attack(Character attackedCharacter)
        {
            var weaponAnimationName = WeaponHelpers.GetAnimationNameFor(_weapon.Type);
            _animator.SetTrigger(weaponAnimationName);

            yield return new WaitForSeconds(2f);

            attackedCharacter.Health -= _weapon.Damage;

            if (attackedCharacter.Health <= 0)
            {
                attackedCharacter.Die();
            }
        }

        private void Die()
        {
            Debug.Log($"Character.Die: {name}");
        }
    }
}