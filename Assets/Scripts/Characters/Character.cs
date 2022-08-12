using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public int Health;

    public IEnumerator Attack(Character attackedCharacter)
    {
        if (Health > 8)
        {
            _animator.SetTrigger("shoot");
        }
        else
        {
            _animator.SetTrigger("melee");
        }

        yield return new WaitForSeconds(2f);

        attackedCharacter.Health -= 1;

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