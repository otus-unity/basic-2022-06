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
        public Health Health => _health;

        [SerializeField]
        public Weapon _weapon;

        public bool IsAlive => _health.IsAlive;

        private void Start()
        {
            _health.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            Debug.Log("Character.OnDeath: ");
        }

        public IEnumerator Attack(Character attackedCharacter)
        {
            // jTODO if weapon is melee, then move the attacker towards the attacked, animate the attack, animate hit/death, and move back to position
            var weaponAnimationName = WeaponHelpers.GetAnimationNameFor(_weapon.Type);
            _animator.SetTrigger(weaponAnimationName);

            yield return new WaitForSeconds(2f);

            // jTODO create coroutine with animations for taking damage and death
            attackedCharacter.Health.TakeDamage(_weapon.Damage);
        }
    }
}