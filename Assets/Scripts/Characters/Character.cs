using UnityEngine;

public class Character : MonoBehaviour
{
    public int Health;

    public void Attack(Character attackedCharacter)
    {
        attackedCharacter.Health -= 1;

        if (attackedCharacter.Health <= 0)
        {
            attackedCharacter.Die();
        }
    }

    private void Die()
    {
        
    }
}
