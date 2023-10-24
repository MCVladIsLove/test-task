using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable
{
    public event Action OnDamageTaken;
    public void TakeDamage(int amount);
}
