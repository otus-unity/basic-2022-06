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

        [SerializeField] private Animation _attackEffect;
        [SerializeField] private GameObject _damageEffect;
        
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
            ShowAttackEffect();
            var weaponAnimationName = WeaponHelpers.GetAnimationNameFor(_weapon.Type);
            _animator.SetTrigger(weaponAnimationName);

            yield return new WaitForSeconds(2f);

            attackedCharacter.Health.TakeDamage(_weapon.Damage);
            attackedCharacter.ShowDamageEffect();
        }

        public void ShowAttackEffect()
        {
            if (_attackEffect) _attackEffect.Play();
        }
        
        public void ShowDamageEffect()
        {
            if (!_damageEffect) return;

            foreach (var effect in _damageEffect.GetComponentsInChildren<ParticleSystem>())
            {
                effect.Play();
            }
        }
    }
}