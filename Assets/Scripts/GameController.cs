using System.Collections;
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
        StartCoroutine(LevelLoop());
    }

    private IEnumerator LevelLoop()
    {
        while (true)
        {
            if (player.Health > 0 && enemy.Health > 0)
            {
                player.Attack(enemy);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(1f);

            if (player.Health > 0 && enemy.Health > 0)
            {
                enemy.Attack(player);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(1f);

            if (player.Health == 0 || enemy.Health == 0)
            {
                yield break;
            }
        }
    }
}