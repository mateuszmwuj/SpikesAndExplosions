using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] protected int _amountOfLives = 1;

    public int AmountOfLives => _amountOfLives;

    public Action OnHealthUpdate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(Action onHealthUpdate)
    {
        OnHealthUpdate = onHealthUpdate;
    }

    virtual protected void LoseHealth()
    {
        Debug.Log($"Player lose health");
        _amountOfLives--;
        _amountOfLives = _amountOfLives < 0 ? 0 : _amountOfLives;

        OnHealthUpdate?.Invoke();
        
        if(_amountOfLives <= 0)
            Death();
    }

    virtual public void Death()
    {

    }


}
