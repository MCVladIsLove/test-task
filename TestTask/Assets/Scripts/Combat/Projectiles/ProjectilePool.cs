using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using Zenject;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxSize;

   // [Inject] Player _player;
   // [Inject] WeaponController _weaponController;

    private ObjectPool<Projectile> _pool;
    private ProjectileFactory _factory;

    private void Awake()
    {
        _factory = new ProjectileFactory(_projectilePrefab, transform);
        _pool = new ObjectPool<Projectile>(
            Create,
            proj => OnGet(proj),
            proj => OnRelease(proj), 
            proj => OnProjectileDestroy(proj),
            false, _defaultCapacity, _maxSize);
    }

    protected virtual Projectile Create()
    {
        Projectile projectile = _factory.CreateProjectile();
        projectile.OnHit += _pool.Release;
        projectile.OnTimeOver += _pool.Release;
        return projectile;
    }

    protected virtual void OnGet(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    protected virtual void OnRelease(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
    
    protected virtual void OnProjectileDestroy(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }

    public virtual Projectile Get()
    {
        return _pool.Get();
    }

}
