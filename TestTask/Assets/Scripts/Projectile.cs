using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    protected WeaponWithAmmo _fromWeapon;
    protected IDamageable _enemy;
    protected Vector2 _attackPosition;
    protected float _timeAlive;
    protected Player _player;

    public event Action<Projectile> OnHit;
    public event Action<Projectile> OnTimeOver;

    public virtual void Init(WeaponWithAmmo weapon, Vector2 attackPosition, Player player, float timeAlive)
    {
        _player = player;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());
        _fromWeapon = weapon;
        _attackPosition = attackPosition;
        transform.position = weapon.transform.position;
        _timeAlive = timeAlive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out _enemy))
            _enemy.TakeDamage(_fromWeapon.Damage);

        OnHit?.Invoke(this);
    }

    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _attackPosition, _fromWeapon.ProjectileSpeed * Time.deltaTime);
    }
    
    private void OnEnable()
    {
        StartCoroutine(ProjectileAliveRoutine());
    }

    protected IEnumerator ProjectileAliveRoutine()
    {
        yield return new WaitForSeconds(_timeAlive);
        OnTimeOver?.Invoke(this);
    }
}
