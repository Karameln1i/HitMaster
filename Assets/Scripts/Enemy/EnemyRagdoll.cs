using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodys;
    [SerializeField] private EnemyCollisionHandler _collisionHandler;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += TurnOnRagdoll;
    }

    private void OnDisable()
    {
        _enemy.Died -= TurnOnRagdoll;
    }
    
    private void TurnOnRagdoll(Enemy enemy)
    {
        _animator.enabled = false;
        
        for (int i = 0; i < _rigidbodys.Length; i++)
        {
            _rigidbodys[i].isKinematic = false;
        }
    }
}
