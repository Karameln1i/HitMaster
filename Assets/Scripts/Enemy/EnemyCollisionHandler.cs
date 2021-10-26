using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
   [SerializeField] private Enemy _enemy;

   private void Awake()
    {
        _enemy.GetComponent<Enemy>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _enemy.ApplyDamage(bullet.Damage);
        }
    }
}
