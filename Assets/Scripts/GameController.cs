using System.Collections;
using System.Linq;
using Characters;
using Helpers;
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
    [SerializeField]
    private Character[] _playerCharacters;

    [SerializeField]
    private Character[] _enemyCharacters;

    private Weapon _sniperRifle = new Weapon(WeaponType.SniperRifle, 5);

    private Queue _turns = new Queue();

    private bool _isTargetSelectionConfirmed;
    private Character _selectedTarget;


    private void Start()
    {
        foreach (var character in _playerCharacters)
        {
            _turns.Enqueue(character);
        }

        foreach (var character in _enemyCharacters)
        {
            _turns.Enqueue(character);
        }

        StartCoroutine(LevelLoop());
    }

    private IEnumerator LevelLoop()
    {
        foreach (var turn in GetTurns())
        {
            if (turn is Character character)
            {
                _isTargetSelectionConfirmed = false;

                if (character.IsAlive)
                {
                    if (IsPlayerCharacter(character))
                    {
                        yield return SelectTarget(_enemyCharacters);
                    }
                    else
                    {
                        AutoSelectTarget(_playerCharacters);
                    }

                    yield return character.Attack(_selectedTarget);

                    _selectedTarget.SelectionFrame.SetActive(false);

                    yield return new WaitForSeconds(1f);

                    // Pushing this character back to queue
                    _turns.Enqueue(character);
                }
            }
            else if (turn is Weapon weapon)
            {
                var enemy = _enemyCharacters.FirstOrDefault(character => character.IsAlive);
                if (enemy != null && enemy.IsAlive)
                {
                    enemy.Health.TakeDamage(_sniperRifle.Damage);
                }

                yield return new WaitForSeconds(1f);

                // Do NOT push sniper rifle back to queue
            }

            if (AreAllCharactersDead(_enemyCharacters))
            {
                GameWon();
                yield break;
            }

            if (AreAllCharactersDead(_playerCharacters))
            {
                GameLost();
                yield break;
            }
        }
    }


    private IEnumerable GetTurns()
    {
        while (true)
        {
            var dequeue = _turns.Dequeue();
            yield return dequeue;
        }
    }

    private bool IsPlayerCharacter(Character character)
    {
        return _playerCharacters.Contains(character);
    }

    private bool AreCharactersAlive(Character[] characters, int minAlive = 1)
    {
        int countAlive = 0;
        foreach (var character in characters)
        {
            if (character.IsAlive)
            {
                countAlive += 1;
                if (countAlive >= minAlive)
                    return true;
            }
        }

        return false;

        // LINQ
        // var numAlive = characters.Count(character => character.IsAlive);
        // return numAlive >= minAlive;
    }

    private bool AreAllCharactersDead(Character[] characters)
    {
        foreach (var character in characters)
        {
            if (character.IsAlive)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator SelectTarget(Character[] characters)
    {
        // Initiate selection 
        SwitchTarget();

        while (!_isTargetSelectionConfirmed)
        {
            yield return null;
        }

        // Real selection moved to UI button handlers
    }

    private void AutoSelectTarget(Character[] characters)
    {
        _selectedTarget = characters.First(character => character.IsAlive);

        _selectedTarget.SelectionFrame.SetActive(true);

        _isTargetSelectionConfirmed = true;
    }

    public void CallSniper()
    {
        if (_turns.Contains(_sniperRifle))
            return;

        _turns.Enqueue(_sniperRifle);
    }

    private void GameWon()
    {
        Debug.Log("GameController.GameWon: ");
    }

    private void GameLost()
    {
        Debug.Log("GameController.GameLost: ");
    }

    #region UI Button Handlers

    public void SwitchTarget()
    {
        if (AreAllCharactersDead(_enemyCharacters))
        {
            return;
        }

        if (_selectedTarget != null)
        {
            _selectedTarget.SelectionFrame.SetActive(false);
        }

        var currentTargetIndex = CharacterHelpers.GetIndexOf(_selectedTarget, _enemyCharacters);

        while (true)
        {
            currentTargetIndex += 1;
            if (currentTargetIndex >= _enemyCharacters.Length)
                currentTargetIndex = 0;

            if (_enemyCharacters[currentTargetIndex].IsAlive)
            {
                _selectedTarget = _enemyCharacters[currentTargetIndex];
                _selectedTarget.SelectionFrame.SetActive(true);
                return;
            }
        }
    }

    public void ConfirmSelectedTarget()
    {
        if (AreAllCharactersDead(_enemyCharacters))
        {
            return;
        }

        _isTargetSelectionConfirmed = true;
    }

    #endregion
}