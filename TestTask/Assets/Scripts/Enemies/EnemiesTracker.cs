using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTracker : MonoBehaviour
{
    private List<Enemy> _trackedEnemies;
    private Enemy _enemyCollided;
    private CircleCollider2D _trackTrigger;

    public CircleCollider2D TrackTrigger => _trackTrigger;
    public List<Enemy> TrackedEnemies => _trackedEnemies;

    private void Awake()
    {
        _trackedEnemies = new List<Enemy>();
        _trackTrigger = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out _enemyCollided))
            _trackedEnemies.Add(_enemyCollided);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out _enemyCollided))
            _trackedEnemies.Remove(_enemyCollided);
    }

}
