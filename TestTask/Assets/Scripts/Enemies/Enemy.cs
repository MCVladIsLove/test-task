using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class Enemy : MonoBehaviour, IDamageable
{
    [Inject] Player _player;

    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;
    [SerializeField] protected UIHealthBar _hpUI;
    [SerializeField] protected float _cooldown;

    protected bool _stand;
    protected float _attackTimer;
    protected Player _playerCollided;
    protected float _currentHealth;

    public event Action OnDamageTaken;
    public event Action OnDeath;

    private void Awake()
    {
        _stand = false;
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        OnDamageTaken += () => _hpUI.Refresh(_currentHealth / _maxHealth);
    }

    public virtual void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        OnDamageTaken?.Invoke();

        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();
        _attackTimer += Time.deltaTime;
    }
    protected void Move()
    {
        if (!_stand)
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
    protected void Attack(IDamageable attacked)
    {
        attacked.TakeDamage(_damage);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out _playerCollided))
            if (_attackTimer > _cooldown)
            {
                _attackTimer = 0;
                Attack(_playerCollided);
                _stand = true;
            }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out _playerCollided))
            _stand = false;
    }
}
