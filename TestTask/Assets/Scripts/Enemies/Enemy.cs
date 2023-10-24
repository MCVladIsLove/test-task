using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IDamageable
{
    public event Action OnDamageTaken;
    public virtual void TakeDamage(int amount)
    {


        OnDamageTaken?.Invoke();
    }
}
