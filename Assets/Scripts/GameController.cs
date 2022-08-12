using UnityEngine;

// Show menu
// Player selects "Start Game"
// Show game intro
/* Game loop start */
// Load level 1
// Show level 1 intro

/* Level loop start */
// Character 1 Turn
// Character 2 Turn
// ...
// Character N Turn
/* Level loop finish */

// Load level 2
// ...

/* Game loop finish */

// Show game over (success or fail)
public class GameController : MonoBehaviour
{
    public Character player;
    public Character enemy;
    
    private void Start()
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            player.Attack(enemy); // Can kill enemy => should skip enemy's attack
            enemy.Attack(player);
        }
    }
}
