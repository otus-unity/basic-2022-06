using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public int Health;

    public void Attack(Character attackedCharacter)
    {
        _animator.SetTrigger("shoot");

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