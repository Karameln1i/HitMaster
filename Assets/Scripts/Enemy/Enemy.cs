using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healths;
    
    public event UnityAction<Enemy> Died;
    public event UnityAction<int> HealthDecreased;

    public void ApplyDamage(int damage)
    {
        _healths -= damage;
        HealthDecreased?.Invoke(damage);

        if (_healths<=0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Died?.Invoke(this);
    }
}
