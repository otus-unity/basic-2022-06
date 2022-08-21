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

        [SerializeField] private GameObject _selectionFrame;
        public GameObject SelectionFrame => _selectionFrame;

        [SerializeField]
        private Transform _meleeAttackerAnchor;

        public Transform MeleeAttackerAnchor => _meleeAttackerAnchor;

        [SerializeField]
        private float _speed;

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
            Vector3 originalPosition = transform.position;
            if (_weapon.Type == WeaponType.BaseballBat)
            {
                _animator.SetFloat("speed", _speed);

                // Move to the target
                float distance;
                var step = _speed * Time.deltaTime;
                do
                {
                    distance = Vector3.Distance(transform.position, attackedCharacter.MeleeAttackerAnchor.position);
                    transform.position = Vector3.MoveTowards(transform.position, attackedCharacter.MeleeAttackerAnchor.position, step);
                    yield return null;
                } while (distance > CharacterHelpers.MeleeAttackDistanceThreshold);

                _animator.SetFloat("speed", 0);
            }

            ShowAttackEffect();
            
            var weaponAnimationName = WeaponHelpers.GetAnimationNameFor(_weapon.Type);
            _animator.SetTrigger(weaponAnimationName);

            yield return new WaitForSeconds(2f);

            attackedCharacter.Health.TakeDamage(_weapon.Damage);
            attackedCharacter.ShowDamageEffect();


            if (_weapon.Type == WeaponType.BaseballBat)
            {
                // Turn to original position
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1 * transform.localScale.z);

                _animator.SetFloat("speed", _speed);

                // Move back to original position
                float distance;
                var step = _speed * Time.deltaTime;
                do
                {
                    distance = Vector3.Distance(transform.position, originalPosition);
                    transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);
                    yield return null;
                } while (distance > CharacterHelpers.MeleeAttackDistanceThreshold);

                _animator.SetFloat("speed", 0);

                // Turn to opponents
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1 * transform.localScale.z);

                yield return null;
            }
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