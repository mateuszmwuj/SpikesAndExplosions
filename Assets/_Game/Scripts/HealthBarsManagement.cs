using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarsManagement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ListOfFirstPlayerHealth;
    [SerializeField] private List<GameObject> _ListOfSecondPlayerHealth;
    [SerializeField] private GameObject _Health1Bar;
    [SerializeField] private GameObject _Health2Bar;

    private int _amountOfFirstPlayerLives = 3;
    private int _amountOfSecondPlayerLives = 3;

    public void LooseFirstPlayerHealth()
    {
        _amountOfFirstPlayerLives--;
        _amountOfFirstPlayerLives = _amountOfFirstPlayerLives < 0 ? 0: _amountOfFirstPlayerLives;

        _ListOfFirstPlayerHealth[_amountOfFirstPlayerLives].SetActive(false);
    }
    public void LooseSecondPlayerHealth()
    {
        _amountOfSecondPlayerLives--;
        _amountOfSecondPlayerLives = _amountOfSecondPlayerLives <0? 0: _amountOfSecondPlayerLives;
        _ListOfSecondPlayerHealth[_amountOfSecondPlayerLives].SetActive(false);
    }
    
    public void ShowFirstPlayerHealthBar()
    {
        _Health1Bar.SetActive(true);
    }
    public void ShowSecondPlayerHealthBar()
    {
        _Health2Bar.SetActive(true);
    }
}
