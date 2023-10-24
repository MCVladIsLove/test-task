using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectileFactory
{
    protected Projectile _projectilePrefab;
    protected Transform _parent;
    public ProjectileFactory(Projectile projectilePrefab, Transform parent)
    {
        _projectilePrefab = projectilePrefab;
        _parent = parent;
    }

    public virtual Projectile CreateProjectile()
    {
        return GameObject.Instantiate<Projectile>(_projectilePrefab, _parent);
    }
}
