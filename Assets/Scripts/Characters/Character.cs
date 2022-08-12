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
            // _animator.SetTrigger("shoot");
            _animator.Play("m_pistol_shoot");
        }
        else
        {
            // _animator.SetTrigger("melee");
            _animator.Play("m_melee_combat_attack_A");
        }

        // Wait one frame so that animation state is switched and animatorStateInfo's length will show real length
        yield return null;

        var currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        
        var duration = currentAnimatorStateInfo.length;
        Debug.Log("Character.Attack: duration = " + duration);
        yield return new WaitForSeconds(duration);

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