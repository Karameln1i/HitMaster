using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody _rigidbody;
    
    public int Damage => _damage;
    
    public void FlyToGoal(Vector3 target)
    {
        var FlyJob = StartCoroutine(Fly(target));
    }

    private IEnumerator Fly(Vector3 direction)
    {
        while (gameObject.activeSelf)
        {
            _rigidbody.AddForce(direction,ForceMode.Acceleration);
       
            yield return null;
        }
    }
}
