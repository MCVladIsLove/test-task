using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private UIHealthBar _hpUI;

    private float _currentHealth;

    public event Action OnDamageTaken;
    public event Action OnDeath;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        OnDamageTaken += () => _hpUI.Refresh(_currentHealth / _maxHealth);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        OnDamageTaken?.Invoke();

        if (_currentHealth < 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }

    }
}
