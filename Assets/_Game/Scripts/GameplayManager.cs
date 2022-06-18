using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private List<PlayerHealthManagement> _listOfPlayersHeath = new List<PlayerHealthManagement>();
    [SerializeField] private HealthBarsManagement _HealthBarsManagement;

    private void Update()
    {
        FindPlayersAndInit();
    }

    private void FindPlayersAndInit()
    {
        if (_listOfPlayersHeath.Count >= 2)
            return;

        var playerHealth = FindObjectOfType<PlayerHealthManagement>();
        if (playerHealth != null)
        {
            if (!_listOfPlayersHeath.Contains(playerHealth))
            {
                _listOfPlayersHeath.Add(playerHealth);
                if (_listOfPlayersHeath.Count == 1)
                {
                    playerHealth.Init(FirstPlayerLoseHealth);
                    _HealthBarsManagement.ShowFirstPlayerHealthBar();
                }
                if (_listOfPlayersHeath.Count == 2)
                {
                    playerHealth.Init(SecondPlayerLoseHealth);
                    _HealthBarsManagement.ShowSecondPlayerHealthBar();
                }
            }
        }
    }

    private void FirstPlayerLoseHealth()
    {
        Debug.Log($"Player FirstPlayerLoseHealth");
        _HealthBarsManagement.LooseFirstPlayerHealth();

        CheckForPlayersDeath();
    }
    private void SecondPlayerLoseHealth()
    {
        _HealthBarsManagement.LooseSecondPlayerHealth();

        CheckForPlayersDeath();
    }

    private void CheckForPlayersDeath()
    {
        bool isDead = false;

        foreach (var playerHealth in _listOfPlayersHeath)
        {
            if (playerHealth.AmountOfLives <= 0)
            {
                isDead = true;
                break;
            }
        }
    }
}
